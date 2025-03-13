using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using DG.Tweening;

using nm_counter;
using nm_emitter;
using nm_canvasPanel;
using nm_monster;
using nm_cubersFile;
using nm_sphere;

namespace  nm_monsterTrigger {

    public class monsterTrigger : MonoBehaviour {

        public sphere Sphere;
        public emitter Emitter;

        // Use this for initialization
        void Start () {

		}
		
		// Update is called once per frame
		void Update () {
		
		}



		//OnTriggerEnter(Collider col)
		//物体同士衝突した時に一度だけ呼ばれるメソッド
		//colliderは当たったオブジェクト
		//OnTriggerEnterのイベントを発行するためにはColliderのIsTriggerフラグをON
		//IsTriggerフラグをONにすると、イベントの判定を行うが、物理エンジンの影響を受けなくなる
		//OnTriggerEnter発生時、IsTriggerフラグをfalseに設定すると物理エンジンが有効となり障害物と衝突する
		//	this.GetComponent<Collider>().isTrigger = true or false;

		void OnTriggerEnter(Collider col){

            bool rotate_on = false;
            if (emitter.turn_move)
            {
                GameObject obj = GameObject.Find("emitter").gameObject;
                if (obj.GetComponent<emitter>().cube_rotate_check(col.gameObject))
                {
                    rotate_on = true;
                }
            }

            if (col.gameObject.transform.root.tag == "cube_empty" && !rotate_on) {

				GameObject child1 = this.gameObject;
                if (!monster.monster_instance.getMonster_IOstatus(child1.tag))
                {

                    nm_sphere.sphere.now_gravitySpheres_count--;

                    monster.monster_instance.setMonster_IOstatus(child1.tag, true);
                    child1.GetComponent<Collider>().isTrigger = false;

                    child1.GetComponent<Rigidbody>().isKinematic = true;

                    //接触後、所定ポジション移動
                    child1.GetComponent<Rigidbody>().useGravity = false;
                    child1.transform.position = col.gameObject.transform.root.position;

                    GameObject child = col.gameObject;

                    child.transform.root.tag = "cube_close";
                    // キューブマテリアル　透明セット
                    nm_sphere.sphere.material_change(col.transform.root.gameObject);

                    // キューブ破壊エフェクト処理
                    emitter.cube_explosion(child);
                    Singleton<SoundPlayer>.instance.playSE("hit008", 2);

                    Animator ani = child1.GetComponent<Animator>();
                    string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.noraml_monster, cubersFile.game_Sceen);
                    ani.Play(str);
                    //ani.Play("fall01");
                    int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
                    monster_color color;
                    if (mod != 0)
                    {
                        color = monster_color.noColor_monster;
                    }
                    else
                    {
                        color = monster.monster_instance.getMonster_color(child1.tag);
                    }
                    nm_sphere.sphere.change_MonsterMaterial(child1, monster_situation.smile_monster, color);

                    //// TODO::削除　ポイント加算
                    //int p = nm_sphere.sphere.gamePointADD(0);
                    //nm_sphere.sphere.point_count = nm_sphere.sphere.point_count + p;
                    //nm_sphere.sphere.hitPointDSP(child1.transform.position, 0);//cube position set

                    //ガイドフロアーハイライトクリア
                    nm_sphere.sphere.reset_Guid_Floor();

                    if (nm_sphere.sphere.gravitySpheres_count <= 0)
                    {
                        nm_sphere.sphere.now_gravity = false;
                        emitter.emptyCubePosition = true;
                    }
                    // game clear check
                    int u_level = (int)cubersFile.now_play_stage / emitter.chainExplosion_userLeve;
                    switch ((int)cubersFile.now_play_stage) {
                        case 1:
                        case 3:
                        case 5:
                            // 連鎖無し　ノーマル
                            if (nm_sphere.sphere.sphere_totalCount - nm_sphere.sphere.now_sphere_count <= 0 && nm_sphere.sphere.now_gravitySpheres_count <= 0) {

                                nm_sphere.sphere.timer_Stop = true;
                                // レベル・ランク更新
                                if (cubersFile.user_stage < emitter.user_stage_max) cubersFile.user_stage++;

                                nm_sphere.sphere.sw_sphere = false;
                                nm_sphere.sphere.game_complete_proc();
                                nm_sphere.sphere.complete = true;
                                emitter.sw_floorUpDown = false;
                                nm_sphere.sphere.gameStatus_text = emitter.gameclear_msg;
                                canvasPanel.statusTime = 2;

                                // point dsp off
                                nm_sphere.sphere.pointDSPOff();
                                nm_sphere.sphere.obj_3dtext = null;
                                nm_sphere.sphere.obj_pointText = null;
                                nm_sphere.sphere.anim_pointText = null;

                                // BGM Stop
                                emitter.BGMstate = emitter.BGM_State.Stop;
                            }
                            break;
                        case 2:
                        case 4:
                        case 6:
                            // 連鎖有り　ノーマル
                            // ポイント加算
                            int p = nm_sphere.sphere.gamePointADD(0);
                            nm_sphere.sphere.point_count = nm_sphere.sphere.point_count + p;
                            nm_sphere.sphere.hitPointDSP(child1.transform.position, 0);//cube position set

                            // TODO:連鎖　仕様変更による見直し箇所 現状は、レベル毎にゲーム攻略条件をチェックして攻略か失敗かを判定させているが、ここの部分は廃止となる為、下記削除対象
                            if (nm_sphere.sphere.sphere_totalCount - nm_sphere.sphere.now_sphere_count <= 0 && nm_sphere.sphere.now_gravitySpheres_count <= 0)
                            {
                                if (monster.monster_instance.Get_monsterColorLastcheck())
                                {
                                    // 全ライン０　オールクリア
                                    // 条件チェック
                                    int confition_chain_count = canvasPanel.chaine_count_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                                    // ３連鎖回数チェック
                                    //if (confition_chain_count <= canvasPanel.chain_3_count)
                                    //{
                                        // 条件連鎖クリア
                                        nm_sphere.sphere.timer_Stop = true;
                                        // レベル・ランク更新
                                        if (cubersFile.user_stage < emitter.user_stage_max) cubersFile.user_stage++;

                                        nm_sphere.sphere.sw_sphere = false;
                                        nm_sphere.sphere.game_complete_proc();
                                        nm_sphere.sphere.complete = true;
                                        emitter.sw_floorUpDown = false;
                                        nm_sphere.sphere.gameStatus_text = emitter.gameclear_msg;
                                        canvasPanel.statusTime = 2;

                                        // point dsp off
                                        nm_sphere.sphere.pointDSPOff();
                                        nm_sphere.sphere.obj_3dtext = null;
                                        nm_sphere.sphere.obj_pointText = null;
                                        nm_sphere.sphere.anim_pointText = null;

                                        // BGM Stop
                                        emitter.BGMstate = emitter.BGM_State.Stop;

                                        // Game Data Save
                                        cubersFile.cubersFile_instance.save_gameEncryptionData();

                                    //}
                                    //else
                                    //{
                                    //    // 条件連鎖未満
                                    //    // TODO:連鎖　仕様変更による見直し箇所
                                    //    gameOverProc();
                                    //    return;
                                    //}
                                }
                                else
                                {
                                    // ライン残あり　キューブが全て埋まった状態
                                    // TODO:連鎖　仕様変更による見直し箇所
                                    gameOverProc();
                                    return;
                                }
                            }
                            break;
                        // 連鎖モード

                    }
                }

			}
			else if(col.gameObject.transform.root.tag == "cube_close" || rotate_on) {

                GameObject child1 = this.gameObject;

                // ライフ消滅無効アイテムON？
                sphere spherescript;
                GameObject obj = GameObject.Find("emitter");
                spherescript = obj.GetComponent<sphere>();
                var seq = DOTween.Sequence();
                if (spherescript.get_CardSlimDSP_Status(emitter.item_Slim_No.gurdlife_slim))
                {
                    // パーティクルエフェクト処理
                    emitter.effect_explosion = true;
                    emitter.monster_Explosion(child1, 2);

                    nm_sphere.sphere.monster_reset(child1);

                    if (nm_sphere.sphere.now_sphere_count > 0) nm_sphere.sphere.now_sphere_count--;
                    nm_sphere.sphere.complete = false;
                    nm_sphere.sphere.reset_Guid_Floor();
                    if (nm_sphere.sphere.gravitySpheres_count <= 0)
                    {
                        nm_sphere.sphere.now_gravity = false;
                        seq.Append(spherescript.Sphere_CardItemSlim_3.transform.DORotate(Vector3.up * 360f, 2f));
                        seq.OnComplete(() =>
                        {
                            // アニメーションが終了時によばれる
                            spherescript.sphere_CardSlime_Clear(emitter.item_Slim_No.gurdlife_slim);
                        });
                    }

                    //spherescript.sphere_CardSlim_Particle_Start(emitter.item_Slim_No.gurdlife_slim);
                    return;
                }

				// in object collider?
				if (monster.monster_instance.getMonster_IOstatus(child1.tag)) {
//					Debug.Log("--------------HIT!!!!--------------");
					return;
				}

				nm_sphere.sphere.complete = false;

				// パーティクルエフェクト処理
				emitter.effect_explosion = true;
				emitter.monster_Explosion(child1, 1);

				nm_sphere.sphere.monster_reset(child1);

				nm_sphere.sphere.lost_Spheres--;
				if (nm_sphere.sphere.lost_Spheres<= 0) {
                    // ゲームオーバー処理
                    // TODO:連鎖　仕様変更による見直し箇所
                    gameOverProc();
					return;
				}
				
				if (nm_sphere.sphere.now_sphere_count > 0) nm_sphere.sphere.now_sphere_count--;

				if (nm_sphere.sphere.gravitySpheres_count <= 0) {
					nm_sphere.sphere.now_gravity = false;
				}

				nm_sphere.sphere.reset_Guid_Floor();

			}
			else if(col.gameObject.transform.root.tag == "floor") {

				col.gameObject.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
				col.gameObject.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.85f,0.03f,0.26f));
			}
		}
        // TODO:連鎖　仕様変更による見直し箇所
        public void gameOverProc()
        {
            // point dsp off
            nm_sphere.sphere.pointDSPOff();
            nm_sphere.sphere.obj_3dtext = null;
            nm_sphere.sphere.obj_pointText = null;
            nm_sphere.sphere.anim_pointText = null;

            nm_sphere.sphere.timer_Stop = true;

            // ゲームオーバー処理
            nm_sphere.sphere.sw_sphere = false;
            nm_sphere.sphere.game_over_proc();
            nm_sphere.sphere.gameover = true;

            // セーブデータ
            cubersFile.lost_count = 0;

            emitter.sw_floorUpDown = false;
            nm_sphere.sphere.gameStatus_text = emitter.gameover_msg;
            canvasPanel.statusTime = 2;

            // BGM Stop
            emitter.BGMstate = emitter.BGM_State.Stop;

            // Game Data Save
            cubersFile.cubersFile_instance.save_gameEncryptionData();

        }
    }
}