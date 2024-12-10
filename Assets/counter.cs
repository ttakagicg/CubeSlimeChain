using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;
using nm_sphere;
using nm_emitter;
using nm_monster;
using nm_cubersFile;
using nm_canvasPanel;

namespace  nm_counter {
	public class counter : MonoBehaviour {

		int speed = 300;
		float cube_mass = 100;
		const int time_keta = 6;
		const float image_height = 70;
		const float image_width = 30;
        const float eventCheckTimer = 60;

		public Canvas canvas;
		public static int sw_animation;
        
        public static float checkEventTimer = eventCheckTimer;
        public static int[] eventStatus;
        public static DateTime[] eventStartDate;

        //		public GameObject panel_base;
        //		public GameObject[] panels;
        //		public Sprite image_1,image_2,image_3,image_4,image_5,image_6,image_7,image_8,image_9,image_0;

        //		private float screen_width;
        //		private float screen_height;

        public static float timer = sphere.startTimer;
//		public static float timer = emitter.gravity_Time;
        //public static int before_timer;

		// Use this for initialization
		void Start () {
		
			sw_animation = 0;
            checkEventTimer = eventCheckTimer;
            eventStatus = new int[cubersFile.event_max];
            eventStartDate = new DateTime[cubersFile.event_max];
            for (int i = 0; i < cubersFile.event_max; i++)
            {
                // イベントアクティブフラグオフ
                eventStatus[i] = 0;
                eventStartDate[i] = DateTime.UtcNow;
            }

/*
            //			panels = new GameObject[time_keta];
            //			screen_width = Screen.width;
            //			screen_height = Screen.height;

            //			int g = time_keta;
            /*			for (int i = 0; i < g; i++) {

                            panels[i] = (GameObject)Instantiate(panel_base, new Vector3( screen_width - image_width * (g - i - 1) - 10, screen_height - image_height, 0),Quaternion.identity);
                            panels[i].transform.SetParent(canvas.transform);
                        }
            */
        }
            
        private int befoeTimer;
		// Update is called once per frame
		void Update () {

			// タイマー０時、
			// 落下オブジェクトがない場合、落下オブジェクト設定
			// 落下オブジェクトがある場合、落下開始設定
			// 通常タイムカウントダウンで０になったら上記設定が行われるが、
			// 外部よりtimerを０設定すると状況に応じて即上記設定が行われる

			// pause?
			if (!emitter.sw_Gravity) return;

			// sw_sphere(モンスター初期化終了まで２、3秒掛かる為カウントダウンがない場合、モンスター表示までタイムラグあり)
			if (!sphere.sw_sphere) return;

			// カウントダウン中
			if (canvasPanel.startCountDown) return;

			timer -= Time.deltaTime;
            

            if (befoeTimer != (int)timer) { 
                //Debug.Log("countdownTime: " + (int)timer);
                befoeTimer = (int)timer;
            }
            if (sphere.gravitySpheres_count != 0)
            {
                canvasPanel canvasp = GetComponentInChildren<canvasPanel>();
                int w_timer = (int)timer;
                canvasp.setGravityWaitTimeDSP(w_timer);

                //int temp = canvasPanel.gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                //if (temp == 0)
                //{
                //    canvasp.gravityWaitTemp();
                //}
            }

            //before_timer = (int)timer;

            /*
                        // 落下ゲージボタンアニメ表示
                        canvasPanel downGaugeBrink = GetComponentInChildren<canvasPanel>();
                        if (sphere.gravitySpheres_count != 0) {
                            float z_time = emitter.gravity_Time - timer;
                            downGaugeBrink.sphereDownGauge(z_time);
                        }
            */
            int k = time_keta;
			string st = @"D" + k.ToString();
			int val = (int)timer;
			string str = val.ToString(st);



			monster_color color;
			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
/*
            // タイムチャレンジ時、モンスターマテリアルチェンジ
            if (cubersFile.now_play_stage == 1 || cubersFile.now_play_stage == 3 || cubersFile.now_play_stage == 5)
            {
                // フロアーモンスターマテリアル変更１
                if (int.Parse(str) >= emitter.gravity_Time / 3 && int.Parse(str) < emitter.gravity_Time / 3 * 2)
                {

                    if (sw_animation == 0)
                    {
                        sw_animation = 1;
                        for (int i = 0; i < sphere.gravitySpheres_count; i++)
                        {
                            if (sphere.useGravitySpheres[i] != null)
                            {
                                if (mod != 0)
                                {
                                    //color = monster.monster_instance.getMonster_color(sphere.useGravitySpheres[i].tag);
                                    color = monster_color.noColor_monster;
                                }
                                else
                                {
                                    color = monster.monster_instance.getMonster_color(sphere.useGravitySpheres[i].tag);
                                }
                                //							Animator ani = sphere.useGravitySpheres[i].GetComponent<Animator>();
                                int jj = UnityEngine.Random.Range(0, 3);
                                switch (jj)
                                {
                                    case 0:
                                        //								ani.Play("wakeup");
                                        nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i], monster_situation.wakeup_monster, color);
                                        //								sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.wakeup_monster,color);
                                        break;
                                    case 1:
                                        //								ani.Play("idel020");
                                        nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i], monster_situation.noraml_monster, color);
                                        //								sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.noraml_monster,color);
                                        break;
                                    case 2:
                                        //								ani.Play("idel01");
                                        nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i], monster_situation.noraml_monster, color);
                                        //								sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.noraml_monster,color);
                                        break;
                                }
                            }
                        }
                    }
                }
                // フロアーモンスターマテリアル変更２
                if (int.Parse(str) > 0 && int.Parse(str) <= emitter.gravity_Time / 3)
                {

                    if (sw_animation == 1)
                    {
                        sw_animation = 2;
                        for (int i = 0; i < sphere.gravitySpheres_count; i++)
                        {
                            if (sphere.useGravitySpheres[i] != null)
                            {
                                if (mod != 0)
                                {
                                    color = monster_color.noColor_monster;
                                }
                                else
                                {
                                    color = monster.monster_instance.getMonster_color(sphere.useGravitySpheres[i].tag);
                                }
                                //							Animator ani = sphere.useGravitySpheres[i].GetComponent<Animator>();
                                int jj = UnityEngine.Random.Range(0, 3);
                                switch (jj)
                                {
                                    case 0:
                                        //								ani.Play("idel020");
                                        nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i], monster_situation.noraml_monster, color);
                                        //								sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.noraml_monster,color);
                                        break;
                                    case 1:
                                        //								ani.Play("wakeup");
                                        nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i], monster_situation.wakeup_monster, color);
                                        //								sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.wakeup_monster,color);
                                        break;
                                }
                            }
                        }
                    }
                }
            }
*/
            // カウントダウン プレースタート開始チェック
            if (int.Parse(str) <= 0 && sphere.sw_sphere) {
				// タイマーカウント０
				if (sphere.gravitySpheres_count != 0) { 
					//  モンスターキャラ落下開始　重力落下フラグON　落下アニメーションセット　落下サウンドON
					emitter.sw_floorUpDown = true;
					for (int jj=0; jj< emitter.cubeCount; jj++) {
						for (int ii=0; ii<emitter.cubeCount; ii++) {
							emitter.guid_floor[jj,ii].gameObject.SetActive(false);
						}
					}
                    // 落下モンスターキューブ破壊エフェクトリセット
                    for (int i = 0; i < emitter.effect_explosion_obj_count; i++)
                    {
                        Destroy(emitter.effect_explosion_obj[i]);
                    }

                    // 落下開始設定
                    for (int i = 0; i < sphere.gravitySpheres_count; i++) {
						if (sphere.useGravitySpheres[i] != null) {
							if (mod != 0) {
								color = monster_color.noColor_monster;
							} else {
								color = monster.monster_instance.getMonster_color(sphere.useGravitySpheres[i].tag);
							}
							sphere.useGravitySpheres[i].transform.GetComponent<Rigidbody>().mass = cube_mass; // speed high 1 <-> 100 low
							sphere.useGravitySpheres[i].transform.GetComponent<Rigidbody>().useGravity = true;
							sphere.useGravitySpheres[i].transform.GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Force);
							// 落下マテリアルチェンジ
							nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.fear_monster,color);
                            // 落下アニメ設定
                            Animator ani = sphere.useGravitySpheres[i].GetComponent<Animator>();
                            string str1 = monster.monster_instance.PlayMonsterAnimation(monster_situation.happy_monster, cubersFile.game_Sceen);
                            ani.Play(str1);
                            sw_animation = 0;
						}
					}
					// 落下SE設定
					Singleton<SoundPlayer>.instance.playSE( "fall003",1);

					// 次回落下モンスター表示までの待機時間
					sphere.gravitySpheres_count = 0;
					//canvasPanel.startDwonGaugeBrink = false;
					// 落下ゲージボタンオフ
					//downGaugeBrink.sphereDownGaugeOff();
					timer = emitter.nextDownWaitTimer;  // 落下後、次のモンスター落下待機表示までの待ち時間
                    canvasPanel.beforeTime = (int)timer + 1;
                    //canvasPanel canvasp = GetComponentInChildren<canvasPanel>();
                    //canvasp.setGravityWaitTimeDSP((int)timer);

                }
                else if (sphere.gravitySpheres_count == 0) {
					// タイマーカウント０　プレー開始処理　落下モンスター設定
					// point dsp off
					sphere.pointDSPOff();
                    // 落下オブジェクト設定
                    GameObject w_obj = GameObject.Find("emitter");
                    w_obj.GetComponent<sphere>().sphere_dwon();
                    //GetComponent<sphere>().sphere_dwon();
                    // 落下までの待機時間セット 可変待機時間は、ゲージ表示を行うCanvasPanelの表示処理内で設定される
                    if (canvasPanel.startCountDown) { // <-このタイミングでは、既にfalseになっているので下記設定は実行されない。下記設定は、canvasPanel内のUpdate()ー＞if (startCountDown)で行っている
						emitter.gravity_Time = emitter.startTempTimer;
						timer = emitter.startCountDownTimer;
                        canvasPanel.beforeTime = (int)timer + 1;
                        canvasPanel canvasp = GetComponentInChildren<canvasPanel>();
                        canvasp.setGravityWaitTimeDSP((int)timer);
                    }
                    else {
                        // 連鎖時、ラストモンスターでhighTempoTimeが設定される
                        timer = emitter.gravity_Time;
                        canvasPanel.beforeTime = (int)timer + 1;
                        canvasPanel canvasp = GetComponentInChildren<canvasPanel>();
                        canvasp.setGravityWaitTimeDSP((int)timer);
                    }

                    //canvasPanel.startDwonGaugeBrink = true;
                }
				sphere.timer_Stop = false;

				emitter.sw_delay = false;
				GameObject obj = this.transform.root.gameObject;
				obj.GetComponent<emitter>().delayObj_clear();
				emitter.BGMstate = emitter.BGM_State.play;
			}
                
            // イベントチェック
            checkEventTimer -= Time.deltaTime;
            val = (int)checkEventTimer;
            str = val.ToString(st);

            if (int.Parse(str) <= 0) { 
                checkEvent();
                checkEventTimer = eventCheckTimer;
            }
        }

        // イベントチェック
        private int dayOfWeekJa;
        void checkEvent()
        {
            // 世界標準時間取得
            DateTime Now = DateTime.UtcNow;
            switch (Now.DayOfWeek)
            {
                case DayOfWeek.Sunday:
                    dayOfWeekJa = 1;
                    break;
                case DayOfWeek.Monday:
                    dayOfWeekJa = 2;
                    break;
                case DayOfWeek.Tuesday:
                    dayOfWeekJa = 3;
                    break;
                case DayOfWeek.Wednesday:
                    dayOfWeekJa = 4;
                    break;
                case DayOfWeek.Thursday:
                    dayOfWeekJa = 5;
                    break;
                case DayOfWeek.Friday:
                    dayOfWeekJa = 6;
                    break;
                case DayOfWeek.Saturday:
                    dayOfWeekJa = 7;
                    break;
            }
                    
            // イベントデータチェック
            for (int i = 0; i < cubersFile.event_max; i++)
            {
                if (cubersFile.eventData[i].dayofweek == dayOfWeekJa)
                {
                    // 該当曜日のイベント有り
                    if (eventStatus[i] == 0)
                    {
                        // イベント未対応
                        // イベント開始時間が同じか超えているか？
                        if (Now.Hour >= cubersFile.eventData[i].startTime)
                        {
                            eventStatus[i] = 1;     // イベント開始
                            eventStartDate[i] = DateTime.UtcNow;
                        }
                    } else if (eventStatus[i] == 1)
                    {
                        // イベント中でイベント期間終了チェック 
                        long wAddhours = cubersFile.eventData[i].duration;
                        // イベント終了日時取得
                        DateTime future = eventStartDate[i].AddHours(wAddhours).AddMinutes(0).AddSeconds(0);
                        // イベント終了期間を超えたか？
                        if (Now >= future)
                        {
                            //イベント設定データクリア処理
                            eventStatus[i] = 3;     // イベント期間終了ステータスセット　0:イベント無し 1:イベント中 2:イベント達成 3:イベントオフ(イベント期間内未達成)
                        }
                    }

                }
            }
        }
            
        // イベント発生中かの確認
        public bool getEventInfo()
        {
            for (int i = 0; i < cubersFile.event_max; i++)
            {
                if (eventStatus[i] == 1)
                {
                    // イベントあり
                    return true;
                }
            }
            // イベントなし                
            return false;
        }
                
            
            
        void OnTimer() {

		}
	}
}