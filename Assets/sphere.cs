using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using System;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using nm_counter;
using nm_emitter;
using nm_canvasPanel;
using nm_monster;
using nm_cubersFile;
using nm_monsterTrigger;

namespace  nm_sphere {

	public class char_obj_animation
	{
		public int sw_anim; // 0:off 1:on
		public float set_angle; // roteto angle
		public float one_angle; //1frame angel
		public float now_angle; // one_angle count
		public float wait_time; //animation wait time
	}

	public class sphere : MonoBehaviour {

		public float screen_width;
		public float screen_height;

		// sw_sphere(モンスター初期化終了まで２、3秒掛かる為カウントダウンがない場合、モンスター表示までタイムラグあり)
		public const int startTimer = 1; // 1秒設定しても上記理由で２、3秒掛かる
		const int sphere_totalCount_3 = 26;
		const int sphere_totalCount_4 = 56;
		const int sphere_totalCount_5 = 98;
		const int monster_colorGrouptotalCount_3 = 30;
		const int monster_colorGrouptotalCount_4 = 64;
		const int monster_colorGrouptotalCount_5 = 110;
		public static int sphere_totalCount;

		public GameObject canvas;
		public static GameObject s_canvas;

		public static long point_count;

		public GameObject Sphere_Main;
		public GameObject Sphere_CardItemSlim_1;
		public GameObject Sphere_CardItemSlim_2;
		public GameObject Sphere_CardItemSlim_3;
		public static GameObject[,,] spheres;
		public static GameObject[] spheres_A;
		public static GameObject[] spheres_cardSlim;
		public int item_slime_count;
		public static char_obj_animation[,,] char_obj_anim;
		public Material Spher_r;

		public GameObject chaineCountGreenText;
		public GameObject chaineCountYellowText;
		public GameObject chaineCountRedText;
		public GameObject chaineCountPurpleText;
		public GameObject chaineCountBlueText;
		public static GameObject s_chaineCountGreenText;
		public static GameObject s_chaineCountYellowText;
		public static GameObject s_chaineCountRedText;
		public static GameObject s_chaineCountPurpleText;
		public static GameObject s_chaineCountBlueText;
		public static GameObject[] obj_pointText;
		public static GameObject pointText_w;

		public GameObject number;
		public static GameObject s_number;
		public Texture num_0;
		public Texture num_1;
		public Texture num_2;
		public Texture num_3;
		public Texture num_4;
		public Texture num_5;
		public Texture num_6;
		public Texture num_7;
		public Texture num_8;
		public Texture num_9;
		public static Texture s_num_0;
		public static Texture s_num_1;
		public static Texture s_num_2;
		public static Texture s_num_3;
		public static Texture s_num_4;
		public static Texture s_num_5;
		public static Texture s_num_6;
		public static Texture s_num_7;
		public static Texture s_num_8;
		public static Texture s_num_9;
		public static GameObject[] obj_3dtext;

		public static bool sw_sphere;
		public static bool now_gravity;
		public static int lost_Spheres;
		public static string gameStatus_text;
		public static bool gameover;
		public static bool complete;
		static Material mat;

		static float sphere_scale;
		public static int sphere_Count = 0;
		public static int before_sphere_Count;
		static int complete_Count;
		static int lost_Count;
		public static int hitpointcount = 0;
		public static bool gravity_ON;
		public static bool start_game;
		public static bool timer_Stop = true;
		public static double monster_floor_position_correction;

		public static object emit_obj;

		// Use this for initialization
		void Start() {

			start_game = false;
			sw_sphere = false;
			gameover = false;
			complete = false;
			timer_Stop = true;

			gravity_ON = false;

			mat = emitter.c_cube_m;

			screen_width = Screen.width;
			screen_height = Screen.height;

			sphere_scale = emitter.cube_scale;

			gameStatus_text = "";

			s_chaineCountGreenText = chaineCountGreenText;
			s_chaineCountYellowText = chaineCountYellowText;
			s_chaineCountRedText = chaineCountRedText;
			s_chaineCountPurpleText = chaineCountPurpleText;
			s_chaineCountBlueText = chaineCountBlueText;
			s_canvas = canvas;

			s_number = number;
			s_num_0 = num_0;
			s_num_1 = num_1;
			s_num_2 = num_2;
			s_num_3 = num_3;
			s_num_4 = num_4;
			s_num_5 = num_5;
			s_num_6 = num_6;
			s_num_7 = num_7;
			s_num_8 = num_8;
			s_num_9 = num_9;

			int enumlength = Enum.GetValues(typeof(emitter.item_Slim_No)).Length;
			spheres_cardSlim = new GameObject[enumlength];

		}

		// Update is called once per frame
		public static float timer = 10;
		const int time_keta = 2;
		void Update() {

			if (gameover) {
				//				point_count = 0;
				GetComponent<emitter>().stop_BGM();
			}
			else if (complete) {
				GetComponent<emitter>().stop_BGM();
			}
			else if (start_game) {

				point_count = 0;
				//canvasPanel.s_mainMenu_field.gameObject.SetActive(false);
				canvasPanel.s_center_View.gameObject.SetActive(false);
				gameStatus_text = "";
				// モンスタープロパティ初期化
				GetComponent<monster>().init_monster_property();

				game_start();
				start_game = false;
				timer_Stop = false;
			}
			else if (hitpointcount > 0) {

				for (int i = 0; i < hitpointcount; i++) {
					//					obj_3dtext[i].transform.position = new Vector3(obj_3dtext[i].transform.position.x, Mathf.PingPong(Time.time,0.5f) + 1.5f,obj_3dtext[i].transform.position.z);
					//					obj_3dtext[i].transform.position = new Vector3(obj_3dtext[i].transform.position.x, Mathf.PingPong(Time.time,0.2f) + 1.5f,obj_3dtext[i].transform.position.z);
				}
			}
			else {
				// char obj rotetoAnim
				if (emitter.playState == emitter.gamePlayState.Play)
					char_roteto_animation();

			}
		}
		// char obj wait animation
		void char_roteto_animation() {

			for (int j = 0; j < emitter.cubeCount; j++) {
				for (int k = 0; k < emitter.cubeCount; k++) {
					for (int i = 0; i < emitter.cubeCount; i++) {
						// char obj
						if (char_obj_anim[j, k, i] != null && spheres[j, k, i] != null) {

							if (char_obj_anim[j, k, i].wait_time != 0) {

								char_obj_anim[j, k, i].wait_time -= Time.deltaTime;
								int ke = time_keta;
								string st = @"D" + ke.ToString();
								int val = (int)char_obj_anim[j, k, i].wait_time;
								string str = val.ToString(st);

								if (int.Parse(str) <= 0) {
									//  roteto angle set
									char_obj_anim[j, k, i].set_angle = UnityEngine.Random.Range(0, 180);
									// 1frame roteto angle
									char_obj_anim[j, k, i].one_angle = UnityEngine.Random.Range(1, 20);
									// roteto cunt reset
									char_obj_anim[j, k, i].now_angle = 0;

									char_obj_anim[j, k, i].wait_time = 0;

								}
							}
							else {

								char_obj_anim[j, k, i].now_angle++;

								spheres[j, k, i].transform.Rotate(Vector3.up * char_obj_anim[j, k, i].one_angle);

								if (char_obj_anim[j, k, i].now_angle >= char_obj_anim[j, k, i].set_angle / char_obj_anim[j, k, i].one_angle) {
									// animation wait time set
									char_obj_anim[j, k, i].wait_time = UnityEngine.Random.Range(1, 3);

									/*									// スライムモンスター待機アニメーション切り替え処理
																		if (cubersFile.game_Sceen == 2)
																		{
																			Animator ani = spheres[j, k, i].GetComponent<Animator>();
																			AnimatorClipInfo[] clipInfo = ani.GetCurrentAnimatorClipInfo(0);
																			string clipName = clipInfo[0].clip.name;
																			// TODO: 待機中アニメーション複数設定
																			if (ani.GetCurrentAnimatorStateInfo(0).IsName("Anim_Slime_Walking_04"))
																			{
																				string str1 = monster.monster_instance.PlayMonsterAnimation(monster_situation.noraml_monster, cubersFile.game_Sceen);
																				ani.Play(str1);
																			}
																			else
																			{
																				string str1 = monster.monster_instance.PlayMonsterAnimation(monster_situation.wakeup_monster, cubersFile.game_Sceen);
																				ani.Play(str1);
																			}
																		} */
								}
							}

							// y position check
							if (spheres[j, k, i].transform.position.y < -sphere_scale * sphere_Count) {
								// IOStatus true == IN
								monster.monster_instance.setMonster_IOstatus(spheres[j, k, i].tag, false);
								monster_reset(spheres[j, k, i].gameObject);
								now_sphere_count--;
							}

						}
					}
				}
			}

		}

		void reset_Game() {

			timer -= Time.deltaTime;
			int k = time_keta;
			string st = @"D" + k.ToString();
			int val = (int)timer;
			string str = val.ToString(st);

			if (int.Parse(str) < 0) {

				gameover = false;
				complete = false;

				int on = 1;
				canvasPanel.setCenterView(on);
				timer = 10;
			}
		}

		void game_start() {

			int off = 0;
			canvasPanel.setCenterView(off);
			canvasPanel panel = GetComponentInChildren<canvasPanel>();
			panel.setCompleteView(2);

			// 落下モンスターフロアーY位置補正　モンスター種別毎に調整設定
			if (cubersFile.game_Sceen == 0)
			{
				monster_floor_position_correction = 2;
			}
			else if (cubersFile.game_Sceen == 1)
			{
				monster_floor_position_correction = 5;
			}
			else if (cubersFile.game_Sceen == 2)
			{
				monster_floor_position_correction = 5;
			}

			Resources.UnloadUnusedAssets();
			sphere_clear();
			sphere_on();
			GetComponent<emitter>().reset_Cube();
			if (lost_Spheres < emitter.lost_count_MAX) lost_Spheres = emitter.lost_count_MAX;
			gravitySpheres_count = 0;
			emitter.playState = emitter.gamePlayState.Zero;
			// タイムアタック　スタートカウントダウン表示フラグ set
			canvasPanel.startCountDown = true;
			//canvasPanel.timeChangeは、タイマースタート以外にモンスターの動きにも関係するプレーステータスの設定も行われる
			// timerの値が０だと途中でBGMの音が消える＜ー原因不明　なので必ずcounter.timerの値は1以上　emitter.startCountDownTimerは３以上に
			if (canvasPanel.startCountDown) {
				canvasPanel.timeChange = false;
				counter.timer = startTimer;
				//				counter.timer = emitter.startCountDownTimer;
				//				counter.timer = emitter.gravity_Time;
				//				counter.timer = 1;
			}
			else {
				counter.timer = startTimer;
				//				counter.timer = emitter.gravity_Time;
				//				counter.timer = 1;
			}
			// カウントダウンを含めた開始までのタイマー　タイマー0で落下オブジェクトが出現する
			//			counter.timer = emitter.startCountDownTimer - 2;
			//			emitter.sw_floorUpDown = true;
			//			emitter.updown_timer = -1;
		}

		public static void game_over_proc() {

			emitter.playState = emitter.gamePlayState.Pause;
			canvasPanel.timeChange = true;

			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			monster_color color;

			for (int j = 0; j < sphere_Count; j++) {
				for (int k = 0; k < sphere_Count; k++) {
					for (int i = 0; i < sphere_Count; i++) {

						if (spheres[j, k, i] != null) {
							if (mod == 0) {
								color = monster_color.green_monster;
							} else {
								color = monster.monster_instance.getMonster_color(spheres[j, k, i].tag);
							}
							change_MonsterMaterial(spheres[j, k, i], monster_situation.death_monster, color);
							Animator ani = spheres[j, k, i].GetComponent<Animator>();
							string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.death_monster, cubersFile.game_Sceen);
							ani.Play(str);
							//ani.Play("deth01");
						}
					}
				}
			}
		}

		public static void game_complete_proc() {

			emitter.playState = emitter.gamePlayState.Pause;
			canvasPanel.timeChange = true;
			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			monster_color color;

			float speed = 3;
			for (int j = 0; j < sphere_Count; j++) {
				for (int k = 0; k < sphere_Count; k++) {
					for (int i = 0; i < sphere_Count; i++) {

						if (spheres[j, k, i] != null) {
							if (mod == 0) {
								color = monster_color.green_monster;
							} else {
								color = monster.monster_instance.getMonster_color(spheres[j, k, i].tag);
							}
							change_MonsterMaterial(spheres[j, k, i], monster_situation.happy_monster, color);
							Animator ani = spheres[j, k, i].GetComponent<Animator>();
							string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.happy_monster, cubersFile.game_Sceen);
							ani.Play(str);
							//ani.Play("paku");

							GameObject obj = spheres[j, k, i].gameObject;
							obj.GetComponent<Rigidbody>().isKinematic = false;

							int direction = UnityEngine.Random.Range(1, 7);
							switch (direction) {
								case 1:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.VelocityChange);
									break;
								case 2:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.down * speed, ForceMode.VelocityChange);
									break;
								case 3:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.left * speed, ForceMode.VelocityChange);
									break;
								case 4:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.right * speed, ForceMode.VelocityChange);
									break;
								case 5:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.forward * speed, ForceMode.VelocityChange);
									break;
								case 6:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.back * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.back * speed, ForceMode.VelocityChange);
									break;
								default:
									obj.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.Acceleration);
									obj.GetComponent<Rigidbody>().AddForce(Vector3.up * speed, ForceMode.VelocityChange);
									break;
							}

						}
					}
				}
			}
			emitter.game_complete = true;
		}

		// モンスターマテリアルカラーチェンジ
		public static void change_MonsterMaterial(GameObject child1, monster_situation situation, monster_color color) {
			if (child1.GetComponent<Renderer>() == null)
			{
				if (cubersFile.game_Sceen == 1)
				{
					GameObject obj = child1.transform.GetChild(0).gameObject;
					obj.GetComponent<SkinnedMeshRenderer>().material = monster.monster_instance.GetMonsterMaterial(situation, color);
				} else if (cubersFile.game_Sceen == 2)
				{
					// カラーオブジェクト変更処理　Piloto Studio Char. SlimeChar導入時のカラーチェンジ
					// 頂点カラーの変更の為、SkinnedMeshRenderer内のMESHを変更
					GameObject obj = child1.transform.GetChild(1).gameObject;
					obj.GetComponent<SkinnedMeshRenderer>().sharedMesh = monster.monster_instance.GetMonsterColorMesh(situation, color);
				}
			}
			else
			{
				if (cubersFile.game_Sceen == 0)
				{
					GameObject obj = child1.transform.Find("dpt_ball").gameObject;
					GameObject obj2 = obj.transform.Find("sk").gameObject;
					GameObject obj3 = obj2.transform.Find("body_mdl").gameObject;
					obj3.GetComponent<Renderer>().material.mainTexture = monster.monster_instance.GetMonsterTexture(situation, color);
				}
			}
		}
		// アイテム、スライムカードの出現スライムオブジェクト作成
		GameObject itemslimobj;
		bool cardslim_ON = false;
		Vector3 before_pos_1;
		Vector3 before_pos_2;
		Vector3 before_pos_3;
		public void waitTimerCountDown_DSP(string time)
        {
			GameObject obj1 = itemslimobj.transform.GetChild(1).gameObject;
			obj1.gameObject.GetComponent<TMPro.TextMeshPro>().text = time;

		}
		public void set_Sphere_CardSlime(emitter.item_Slim_No slim_No)
        {
			if (cardslim_ON) return;
			cardslim_ON = true;
			float offset = emitter.cubeCount % 3;
			offset *= 1.5f;

			switch (slim_No)
            {
				case emitter.item_Slim_No.waitTime_slim:
					itemslimobj = Sphere_CardItemSlim_1;
					before_pos_1 = itemslimobj.transform.position;
					break;
				case emitter.item_Slim_No.resetTime_slim:
					itemslimobj = Sphere_CardItemSlim_2;
					before_pos_2 = itemslimobj.transform.position;
					break;
				case emitter.item_Slim_No.gurdlife_slim:
					itemslimobj = Sphere_CardItemSlim_3;
					before_pos_3 = itemslimobj.transform.position;
					break;
			}
			Vector3 pos = itemslimobj.transform.position;
			pos.x += emitter.cube_scale * offset;
			pos.y += emitter.cube_scale * offset;
            pos.z += emitter.cube_scale * offset;
			itemslimobj.transform.position = pos;


			GameObject obj1 = itemslimobj.transform.GetChild(0).gameObject;
			Animator ani = obj1.gameObject.GetComponent<Animator>();
			GameObject obj_mesh = obj1.transform.GetChild(1).gameObject;
			obj_mesh.GetComponent<SkinnedMeshRenderer>().sharedMesh = monster.monster_instance.GetItemCardSlimMesh((int)slim_No);

			string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.noraml_monster, cubersFile.game_Sceen);
			ani.Play(str);

			itemslimobj.gameObject.SetActive(true);

			//int half_cubeCount = emitter.cubeCount / 2;
			//float offset = emitter.cubeCount % 2;

			//if (spheres_cardSlim[(int)slim_No] != null) {
			//	Destroy(spheres_cardSlim[(int)slim_No]);
			//	spheres_cardSlim[(int)slim_No] = null;
			//}
			//spheres_cardSlim[(int)slim_No] = (GameObject)Instantiate(Sphere_CardItemSlim, new Vector3((-half_cubeCount + offset + 2) * emitter.cube_scale, (half_cubeCount + offset + 2) * emitter.cube_scale, (half_cubeCount + offset + 2) * emitter.cube_scale), Quaternion.identity);
			//GameObject obj = spheres_cardSlim[(int)slim_No].transform.GetChild(1).gameObject;
			//obj.GetComponent<SkinnedMeshRenderer>().sharedMesh = monster.monster_instance.GetItemCardSlimMesh((int)slim_No);

			//Animator ani = spheres_cardSlim[(int)slim_No].GetComponent<Animator>();
			//string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.wakeup_monster, cubersFile.game_Sceen);
			//ani.Play(str);

		}
		public void sphere_CardSlime_Clear(emitter.item_Slim_No slim_No)
        {
			if (before_pos_1 != Vector3.zero)
			switch (slim_No)
			{
				case emitter.item_Slim_No.waitTime_slim:
					itemslimobj = Sphere_CardItemSlim_1;
					if (before_pos_1 != Vector3.zero) itemslimobj.transform.position = before_pos_1;
					break;
				case emitter.item_Slim_No.resetTime_slim:
					itemslimobj = Sphere_CardItemSlim_2;
					if (before_pos_2 != Vector3.zero) itemslimobj.transform.position = before_pos_2;
					break;
				case emitter.item_Slim_No.gurdlife_slim:
					itemslimobj = Sphere_CardItemSlim_3;
					if (before_pos_3 != Vector3.zero) itemslimobj.transform.position = before_pos_3;
					break;
			}
			cardslim_ON = false;
			itemslimobj.gameObject.SetActive(false);

			//if (spheres_cardSlim[(int)slim_No] != null)
			//{
			//	Destroy(spheres_cardSlim[(int)slim_No]);
			//	spheres_cardSlim[(int)slim_No] = null;
			//}
		}
		public void sphere_CardSlime_allClear()
		{
			cardslim_ON = false;
			Sphere_CardItemSlim_1.transform.position = before_pos_1;
			Sphere_CardItemSlim_1.gameObject.SetActive(false);
			Sphere_CardItemSlim_2.transform.position = before_pos_2;
			Sphere_CardItemSlim_2.gameObject.SetActive(false);
			Sphere_CardItemSlim_3.transform.position = before_pos_3;
			Sphere_CardItemSlim_3.gameObject.SetActive(false);

			//int itemslimlength = Enum.GetValues(typeof(emitter.item_Slim_No)).Length;
			//if (spheres_cardSlim != null)
			//{
			//	for (int i = 0; i < itemslimlength; i++)
			//	{
			//		Destroy(spheres_cardSlim[i]);
			//		spheres_cardSlim[i] = null;
			//	}
			//}
		}
		// 洗濯ステージに該当するモンスターオブジェクト群を初期化（準備）
		public void sphere_on() {

			if (!sw_sphere) {

				sw_sphere = true;

				if (sphere_Count == 3) sphere_totalCount = sphere_totalCount_3;
				if (sphere_Count == 4) sphere_totalCount = sphere_totalCount_4;
				if (sphere_Count == 5) sphere_totalCount = sphere_totalCount_5;

				int monsterCubePositionGroup = 0;

				screen_width = Screen.width;
				screen_height = Screen.height;
				float scale = emitter.cube_scale * 10;

				int half_sphereount = sphere_Count / 2;
				float offset = sphere_Count % 2;
				if (offset != 0) offset = 0;
				else offset = scale / 2;

				char_obj_anim = new char_obj_animation[sphere_Count, sphere_Count, sphere_Count];

				useGravitySpheres = new GameObject[sphere_Count * 2];
				if (spheres == null) {
					int tagNameCount = 0;
					spheres = new GameObject[sphere_Count, sphere_Count, sphere_Count];
					Sphere_Main.GetComponent<Rigidbody>().useGravity = false;
					Sphere_Main.GetComponent<SphereCollider>().enabled = false;

					int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
					monster_color color;

					Vector3 pos1;
					string str_x1;
					string str_y1;
					string str_z1;
					Double wx1;
					Double wy1;
					Double wz1;
					for (int j = 0; j < sphere_Count; j++) {
						for (int k = 0; k < sphere_Count; k++) {
							for (int i = 0; i < sphere_Count; i++) {

								// cube position group set
								monsterCubePositionGroup = setMosterPositionGroup(j, k, i);

								if (sphere_Count == 3) {
									// 3 × 3 × 3
									if (k == 1 && i == 1 && j == 1) {

									}
									else if (k == 1 && (i == 0 || i == 2) && j != 1) {
										wx1 = Math.Round((-half_sphereount + i) * scale, 1, MidpointRounding.AwayFromZero);
										str_x1 = wx1.ToString();
										pos1.x = float.Parse(str_x1) / 10;
										wy1 = Math.Round((-half_sphereount + k) * scale + 200.0f, 1, MidpointRounding.AwayFromZero);
										str_y1 = wy1.ToString();
										pos1.y = float.Parse(str_y1) / 10;
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(pos1.x, pos1.y, 0.0f), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale, (-half_sphereount + k) * scale + 20.0f, 0.0f), Quaternion.identity);
									}
									else if (k == 1 && (i == 0 || i == 2) && j == 1) {
										wy1 = Math.Round((-half_sphereount + k) * scale + 200.0f, 1, MidpointRounding.AwayFromZero);
										str_y1 = wy1.ToString();
										pos1.y = float.Parse(str_y1) / 10;
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(0.0f, pos1.y, 0.0f), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 (0.0f, (-half_sphereount + k) * scale + 20.0f, 0.0f), Quaternion.identity);
									}
									else if (k == 1 && i == 1 && (j == 0 || j == 2)) {
										wy1 = Math.Round((-half_sphereount + k) * scale + 200.0f, 1, MidpointRounding.AwayFromZero);
										str_y1 = wy1.ToString();
										pos1.y = float.Parse(str_y1) / 10;
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(0.0f, pos1.y, 0.0f), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 (0.0f, (-half_sphereount + k) * scale + 20.0f, 0.0f), Quaternion.identity);
									}
									else {
										wx1 = Math.Round((-half_sphereount + i) * scale, 1, MidpointRounding.AwayFromZero);
										str_x1 = wx1.ToString();
										pos1.x = float.Parse(str_x1) / 10;
										wy1 = Math.Round((-half_sphereount + k) * scale + 200.0f, 1, MidpointRounding.AwayFromZero);
										str_y1 = wy1.ToString();
										pos1.y = float.Parse(str_y1) / 10;
										wz1 = Math.Round((-half_sphereount + j) * scale, 1, MidpointRounding.AwayFromZero);
										str_z1 = wz1.ToString();
										pos1.z = float.Parse(str_z1) / 10;
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(pos1.x, pos1.y, pos1.z), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + j) * scale), Quaternion.identity);
									}
								}
								else if (sphere_Count == 4) {
									// 4 × 4 × 4
									if ((k == 1 || k == 2) && (i == 1 || i == 2) && (j == 1 || j == 2)) {

									}
									else if ((k == 1 || k == 2) && (i == 0 || i == 3) && (j == 0 || j == 3)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + k) * scale + offset) / 10, ((-half_sphereount + i) * scale + 200.0f) / 10, ((-half_sphereount + j) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + k) * scale + offset, (-half_sphereount + i) * scale + 20.0f, (-half_sphereount + j) * scale + offset), Quaternion.identity);
									}
									else if ((k == 1 || k == 2) && (i == 0 || i == 3) && (j == 1 || j == 2)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + k) * scale + offset) / 10, ((-half_sphereount + i) * scale + 200.0f) / 10, ((-half_sphereount + j) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + k) * scale + offset, (-half_sphereount + i) * scale + 20.0f, (-half_sphereount + j) * scale + offset), Quaternion.identity);
									}
									else if ((k == 1 || k == 2) && (i == 1 || i == 2) && (j == 0 || j == 3)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + i) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + k) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale + offset, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + k*10) * scale + offset), Quaternion.identity);
									}
									else {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + i) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + j) * scale + offset) / 10), Quaternion.identity);
										//?										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale + offset, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + j) * scale + offset), Quaternion.identity);
									}
								}
								else if (sphere_Count == 5) {
									// 5 × 5 × 5
									if ((k == 1 || k == 2 || k == 3) && (i == 1 || i == 2 || i == 3) && (j == 1 || j == 2 || j == 3)) {

									}
									else if ((k == 1 || k == 2 || k == 3) && (i == 0 || i == 4) && (j == 0 || j == 4)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + i) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + k) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale + offset, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + k) * scale + offset), Quaternion.identity);
									}
									else if ((k == 1 || k == 2 || k == 3) && (i == 0 || i == 4) && (j == 1 || j == 2 || j == 3)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + k) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + j) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + k) * scale + offset, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + j) * scale + offset), Quaternion.identity);
									}
									else if ((k == 1 || k == 2 || k == 3) && (i == 1 || i == 2 || i == 3) && (j == 0 || j == 4)) {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + i) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + k) * scale + offset) / 10), Quaternion.identity);
									}
									else {
										spheres[j, k, i] = (GameObject)Instantiate(Sphere_Main, new Vector3(((-half_sphereount + i) * scale + offset) / 10, ((-half_sphereount + k) * scale + 200.0f) / 10, ((-half_sphereount + j) * scale + offset) / 10), Quaternion.identity);
										//										spheres [j,k,i] = (GameObject)Instantiate (Sphere_Main, new Vector3 ((-half_sphereount + i) * scale + offset, (-half_sphereount + k) * scale + 20.0f, (-half_sphereount + j) * scale + offset), Quaternion.identity);
									}

								}
								if (spheres[j, k, i] != null) {

									Vector3 pos = spheres[j, k, i].transform.position;

									tagNameCount++;
									make_Tag(tagNameCount.ToString());
									spheres[j, k, i].tag = tagNameCount.ToString();
									monster_property m_property = new monster_property();

									m_property.tagID = tagNameCount.ToString();
									m_property.InOutStatus = false;
									m_property.monsterCubePositionGroup = monsterCubePositionGroup;
#if !DEBUG
									m_property.monster_color = monster_color.blue_monster;
#else
									m_property.monster_color = monster_color.green_monster;
#endif
									m_property.start_position = pos;
									GetComponent<monster>().addMonster_property(tagNameCount.ToString(), m_property);
									if (mod == 0) {
#if !DEBUG
                                        color = monster_color.blue_monster;
#else
										if (cubersFile.game_Sceen == 2)
										{
											color = monster_color.white_monster;
										}
										else
										{
											color = monster_color.green_monster;
										}
#endif
									}
									else {
										if (cubersFile.game_Sceen != 2)
										{
											color = monster.monster_instance.getMonster_color(spheres[j, k, i].tag);
										}
										else
										{
											color = monster_color.white_monster;
										}
									}
									change_MonsterMaterial(spheres[j, k, i], monster_situation.sleep_monster, color);
									//Animator ani = spheres[j, k, i].GetComponent<Animator>();
									//string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.noraml_monster, cubersFile.game_Sceen);
									//ani.Play(str);

									// char_wait_animation
									char_obj_anim[j, k, i] = new char_obj_animation();
									char_obj_anim[j, k, i].wait_time = UnityEngine.Random.Range(1, 3);
									char_obj_anim[j, k, i].now_angle = 0.0f;
									char_obj_anim[j, k, i].set_angle = 0.0f;
									char_obj_anim[j, k, i].one_angle = 0.0f;
								}
							}
						}
					}
				}

			}
		}
		// cube position group set
		// return 0: cube center position group 1: cube side center position group 2: cube side corner position group
		int setMosterPositionGroup(int j, int k, int i) {
			// j:x k:y i:z
			if (sphere_Count == 3) {
				if (k == 1 && j == 1 && i == 1) {
					return 0;
				}
				else if ((k == 1 && j == 1) || (k == 1 && i == 1) || (j == 1 && i == 1)) {
					// 0: center
					return 1;
				}
				else if (((k == 0 || k == 2) && (j == 1 || i == 1))
					|| ((k == 1) && (j == 0 || j == 2))
					|| ((k == 1) || (i == 0 || i == 2))) {
					// 1:side center
					return 2;
				}
				else if ((k == 0 || k == 2) && (j == 0 || j == 2) && (i == 0 || i == 2)) {
					// 2:side cornor
					return 3;
				}
			}
			else if (sphere_Count == 4) {
				if ((k == 1 || k == 2) && (j == 1 || j == 2) && (i == 1 || i == 2)) {
					return 0;
				}
				else if (((k == 1 || k == 2) && (j == 1 || j == 2))
					|| ((k == 1 || k == 2) && (i == 1 || i == 2))
					|| ((j == 1 || j == 2) && (i == 1 || i == 2))) {
					// ４＊４の場合、centerは２＊２だが識別は１一つで問題ない
					// 0: center
					return 1;
				}
				else if (((k == 0 || k == 3) && (j == 1 || j == 2 || i == 1 || i == 2))
					|| ((k == 1 || k == 2) && ((j == 0 || j == 3) && (i == 0 || i == 3)))) {
					// 1:side center
					return 2;
				}
				else if ((k == 0 || k == 3) && (j == 0 || j == 3) && (i == 0 || i == 3)) {
					// 2:side cornor
					return 3;
				}
			}
			else if (sphere_Count == 5) {
				if ((k == 1 || k == 2 || k == 3) && (j == 1 || j == 2 || j == 3) && (i == 1 || i == 2 || i == 3)) {
					return 0;
				}
				else if (((k == 1 || k == 2 || k == 3) && (j == 1 || j == 2 || j == 3))
					|| ((k == 1 || k == 2 || k == 3) && (i == 1 || i == 2 || i == 3))
					|| ((j == 1 || j == 2 || k == 3) && (i == 1 || i == 2 || i == 3))) {
					// 0: center
					// ５＊５の場合、centerも３＊３の情報を付加する必要がある
					if (j == 2 && k == 2 && i == 2) return 1; // center center
					if ((j == 2 && (i == 1 || i == 3)) || (k == 2 && (j == 1 || j == 3)) || (i == 2 && (j == 1 || j == 3))) return 12; // center side center
					if ((j == 1 || j == 3) && (k == 1 || k == 3) && (i == 1 || i == 3)) return 13; // center corner
					return 1;
				}
				else if (((k == 0 || k == 4) && (j == 1 || j == 2 || j == 3 || i == 1 || i == 2 || i == 3))
					|| ((k == 1 || k == 2 || k == 3) && ((j == 0 || j == 4) && (i == 0 || i == 4)))) {
					// 1:side center
					return 2;
				}
				else if ((k == 0 || k == 3) && (j == 0 || j == 3) && (i == 0 || i == 3)) {
					// 2:side cornor
					return 3;
				}
			}
			return -1;
		}

		void make_Tag(string tagName) {
#if UNITY_EDITOR
			UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
			if ((asset != null) && (asset.Length > 0)) {
				SerializedObject so = new SerializedObject(asset[0]);
				SerializedProperty tags = so.FindProperty("tags");

				for (int i = 0; i < tags.arraySize; ++i) {
					if (tags.GetArrayElementAtIndex(i).stringValue == tagName) {
						return;
					}
				}

				int index = tags.arraySize;
				tags.InsertArrayElementAtIndex(index);
				tags.GetArrayElementAtIndex(index).stringValue = tagName;
				so.ApplyModifiedProperties();
				so.Update();
			}
#endif
		}
		public void sphere_clear() {

			if (spheres == null) return;

			sw_sphere = false;
			screen_width = Screen.width;
			screen_height = Screen.height;
			for (int j = 0; j < before_sphere_Count; j++) {
				for (int k = 0; k < before_sphere_Count; k++) {
					for (int i = 0; i < before_sphere_Count; ++i) {

						if (spheres[j, k, i] != null) {
							if (cubersFile.game_Sceen == 0)
							{
								GameObject obj = spheres[j, k, i].transform.Find("dpt_ball").gameObject;
								GameObject obj2 = obj.transform.Find("sk").gameObject;
								GameObject obj3 = obj2.transform.Find("body_mdl").gameObject;
								Material mat1 = obj3.transform.gameObject.GetComponent<Renderer>().material;
								DestroyImmediate(mat1);
							}
							Destroy(spheres[j, k, i]);
							spheres[j, k, i] = null;
						}
					}
				}
			}
			for (int ii = 0; ii < before_sphere_Count; ii++) {
				if (useGravitySpheres[ii] != null) {
					if (cubersFile.game_Sceen == 0)
					{
						GameObject wobj1 = useGravitySpheres[ii];
						Material mat1 = wobj1.transform.gameObject.GetComponent<Renderer>().material;
						DestroyImmediate(mat1);
					}
					Destroy(useGravitySpheres[ii]);
					useGravitySpheres[ii] = null;
				}
			}
			spheres = null;
			now_sphere_count = 0;

			//			reset_Guid_Floor();
		}
		public void sphere_nowclear()
		{

			if (spheres == null) return;

			sw_sphere = false;
			screen_width = Screen.width;
			screen_height = Screen.height;
			for (int j = 0; j < sphere_Count; j++)
			{
				for (int k = 0; k < sphere_Count; k++)
				{
					for (int i = 0; i < sphere_Count; ++i)
					{

						if (spheres[j, k, i] != null)
						{
							if (cubersFile.game_Sceen == 0)
							{
								GameObject obj = spheres[j, k, i].transform.Find("dpt_ball").gameObject;
								GameObject obj2 = obj.transform.Find("sk").gameObject;
								GameObject obj3 = obj2.transform.Find("body_mdl").gameObject;
								Material mat1 = obj3.transform.gameObject.GetComponent<Renderer>().material;
								DestroyImmediate(mat1);
							}
							Destroy(spheres[j, k, i]);
							spheres[j, k, i] = null;
						}
					}
				}
			}
			for (int ii = 0; ii < sphere_Count; ii++)
			{
				if (useGravitySpheres[ii] != null)
				{
					if (cubersFile.game_Sceen == 0)
					{
						GameObject wobj1 = useGravitySpheres[ii];
						Material mat1 = wobj1.transform.gameObject.GetComponent<Renderer>().material;
						DestroyImmediate(mat1);
					}
					Destroy(useGravitySpheres[ii]);
					useGravitySpheres[ii] = null;
				}
			}
			spheres = null;
			now_sphere_count = 0;
		}

		const int cube_corner_count = 8;
		const int cube_center_count = 6;
		const int cube_edge_center_count = 12;
		const float sphere_A_start_Position1 = 1.1f;
		const float sphere_A_start_Position2 = 0;
		const float sphere_A_start_Position3 = -1.1f;
		public static GameObject[] useGravitySpheres;
		public static int now_sphere_count = 0;
		public static int gravitySpheres_count = 0;
		public static int now_gravitySpheres_count = 0;

		// 落下モンスタをフロアーへセット
		public void sphere_dwon() {

			if (sw_sphere) {

				now_gravity = false;
				gravity_ON = false;
				now_gravitySpheres_count = 0;

				// point dsp off
				pointDSPOff();
				//				obj_3dtext = null;
				obj_pointText = null;
				anim_pointText = null;

				GameObject[] w_useGravitySpheres;
				for (int i = 0; i < sphere_Count; i++)
					useGravitySpheres[i] = null;

				if (now_sphere_count >= sphere_totalCount) return;

				screen_width = Screen.width;
				screen_height = Screen.height;

				//落下オブジェ数　選択ステージの範囲を設定
				int min_count = canvasPanel.gravity_number_min_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
				int max_count = canvasPanel.gravity_number_max_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];

				int c_sphere = UnityEngine.Random.Range(min_count, max_count + 1);  // int型UnityEngine.Random.Rangeは MAX値は最大値を含まない為、１加算
				/*
                                if (sphere_Count == 3)
                                    c_sphere = UnityEngine.Random.Range(1,sphere_Count + 2);
                                else if (sphere_Count == 4)
                                    c_sphere = UnityEngine.Random.Range(1,sphere_Count - 1);
                                else if (sphere_Count == 5)
                                    c_sphere = UnityEngine.Random.Range(1,sphere_Count - 2);
                //				int c_sphere = UnityEngine.Random.Range(1,sphere_Count + 1);
                */
				int ww = sphere_totalCount - now_sphere_count;
				if (ww >= c_sphere) {
					gravitySpheres_count = c_sphere;
				}
				else {
					gravitySpheres_count = ww;
				}

				w_useGravitySpheres = new GameObject[gravitySpheres_count * 2];
				int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
				monster_color color;

				for (int i = 0; i < gravitySpheres_count; i++) {

					w_useGravitySpheres[i] = setGravitySphere();

					if (w_useGravitySpheres[i] != null) {

						GameObject child1 = w_useGravitySpheres[i];
						// マテリアルチェンジ
						if (mod != 0) {
							color = monster_color.noColor_monster;
						} else {
							color = monster.monster_instance.getMonster_color(child1.tag);
						}
						change_MonsterMaterial(child1, monster_situation.sleep_monster, color);

						Vector3 pos_1 = get_round_position(child1.transform.position);
						//						pos_1.y= sphere_scale * sphere_Count + 0.4f;
						Double wy = Math.Round(((sphere_Count + 1) * (sphere_scale * 10) - monster_floor_position_correction), 1, MidpointRounding.AwayFromZero);
						string str_y = wy.ToString();
						pos_1.y = float.Parse(str_y) / 10;
						child1.transform.position = pos_1;

						now_sphere_count++;
					}
					else {
						gravitySpheres_count = i;
						break;
					}
				}


				//重複位置オブジェクト検索
				//				int resetCount = 0;
				GameObject[] ww_useGravitySpheres;
				ww_useGravitySpheres = new GameObject[gravitySpheres_count * 2];
				for (int i = 0; i < gravitySpheres_count; i++) ww_useGravitySpheres = w_useGravitySpheres;
				// ここからww_useGravitySpheresを使用
				if (gravitySpheres_count > 1) {

					int dec_monster_count = 0;

					for (int i = 0; i < gravitySpheres_count - 1; i++) {
						for (int ii = i + 1; ii < gravitySpheres_count; ii++) {

							int pos_1 = get_SelectedMonster_PositionNumber(w_useGravitySpheres[i].transform.position);
							int pos_2 = get_SelectedMonster_PositionNumber(w_useGravitySpheres[ii].transform.position);
							if (pos_1 == pos_2) {
								// 重複あり yポジションリセット
								ww_useGravitySpheres[i].transform.position = get_round_position(monster.monster_instance.getMonster_position(ww_useGravitySpheres[i].tag));
								// 落下モンスター数減算
								dec_monster_count++;
								break;
							}
						}
					}
					if (dec_monster_count != 0) {
						int incpos = 0;
						// フロアーyポジション
						//						float w_y = sphere_scale * sphere_Count + 0.4f;
						Double wy = Math.Round(((sphere_Count + 1) * (sphere_scale * 10) - monster_floor_position_correction), 1, MidpointRounding.AwayFromZero);
						string str_y = wy.ToString();
						float w_y = float.Parse(str_y) / 10;
						for (int i = 0; i < gravitySpheres_count; i++) {

							Vector3 pos_1 = get_round_position(ww_useGravitySpheres[i].transform.position);
							// 重複　フロアーyポジションリセット有りオブジェクトかチェック
							if (pos_1.y == w_y) {
								// w_useGravitySpheres にセットし直す
								w_useGravitySpheres[incpos] = ww_useGravitySpheres[i];
								incpos++;

							}
						}
						// 落下モンスター数減算
						gravitySpheres_count = gravitySpheres_count - dec_monster_count;
						now_sphere_count = now_sphere_count - dec_monster_count;
					}
				}

				// 落下設定
				for (int i = 0; i < gravitySpheres_count; i++) {

					useGravitySpheres[i] = w_useGravitySpheres[i];
					GameObject child1 = useGravitySpheres[i];
					child1.GetComponent<Collider>().isTrigger = true;
					child1.GetComponent<SphereCollider>().enabled = true;
					child1.GetComponent<Rigidbody>().isKinematic = false;

					Animator ani = child1.GetComponent<Animator>();
					//					ani.speed = 1.5f;
					string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.noraml_monster, cubersFile.game_Sceen);
					ani.Play(str);
					//ani.Play("sleep");
				}

				//				counter.timer = emitter.gravity_Time + 1;
				now_gravitySpheres_count = gravitySpheres_count;

			}
		}

		// 落下モンスターの位置番号の取得
		// x:1 〜　sphere_Count ＋　z:10 〜　sphere_Count
		// 11 〜　(sphere_Count+sphere_Count)
		public int get_SelectedMonster_PositionNumber(Vector3 pos) {

			int positionNumber;
			float scale = emitter.cube_scale;
			int half_cubeCount = sphere_Count / 2;
			float offset = sphere_Count % 2;
			if (offset != 0) offset = 0;
			else offset = scale / 2;

			Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			float obj_X_Position = float.Parse(str_x) / 10;
			Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			float obj_Z_Position = float.Parse(str_z) / 10;

			// x
			for (int jj = 0; jj < sphere_Count; jj++) {
				for (int ii = 0; ii < sphere_Count; ii++) {
					float base_x_position = (-half_cubeCount + jj) * scale + offset;
					float base_z_position = (-half_cubeCount + ii) * scale + offset;
					if (obj_X_Position == base_x_position && obj_Z_Position == base_z_position) {
						positionNumber = jj + (ii * 10);
						return positionNumber;
					}
				}
			}
			return -1;
		}

		public Vector3 get_round_position(Vector3 pos) {

			Vector3 round_pos;
			Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
			round_pos.y = float.Parse(str_y) / 10;
			Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			round_pos.x = float.Parse(str_x) / 10;
			Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			round_pos.z = float.Parse(str_z) / 10;

			return round_pos;
		}
		public static Vector3 get_s_round_position(Vector3 pos) {

			Vector3 round_pos;
			Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
			round_pos.y = float.Parse(str_y) / 10;
			Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			round_pos.x = float.Parse(str_x) / 10;
			Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			round_pos.z = float.Parse(str_z) / 10;

			return round_pos;
		}

		// empty cube position set
		public Vector3 set_sphere_position() {

			int ww = sphere_totalCount - now_sphere_count;
			int p = UnityEngine.Random.Range(0, ww);
			Vector3 pos = emitter.empty_cube_position[p];

			for (int i = p; i < ww - 1; i++) {
				emitter.empty_cube_position[i] = emitter.empty_cube_position[i + 1]; ;
			}
			return pos;
		}

		//落下するオブジェ選択
		int now_cube_corner_count;
		int now_cube_center_count;
		int now_cube_edge_center_count;
		//座標位置 0を含まないオブジェクトは、端
		//座標位置 0を一つだけ含むオブジェクトは、端中央
		//座標位置 0を二つ含むオブジェクトは、面中央
		private GameObject setGravitySphere() {

			GameObject[] extract_obj;
			int ww = sphere_totalCount - now_sphere_count;
			extract_obj = new GameObject[ww];
			int extract_obj_count = 0;

			for (int j = 0; j < sphere_Count; j++) {
				for (int k = 0; k < sphere_Count; k++) {
					for (int i = 0; i < sphere_Count; i++) {
						//キューブ中心は除外
						if (spheres[j, k, i] == null) {
						}
						else {
							Double wy = Math.Round(spheres[j, k, i].transform.position.y * 10, 1, MidpointRounding.AwayFromZero);
							string str_y = wy.ToString();
							float p_y = float.Parse(str_y) / 10;
							//待機オブジェクト
							if (p_y > sphere_scale * 10) {
								extract_obj[extract_obj_count] = spheres[j, k, i];
								if (extract_obj_count >= ww) {
									break;
								}
								extract_obj_count++;
							}
						}
					}
				}
			}

			int jj = UnityEngine.Random.Range(0, extract_obj_count);
			if (extract_obj[jj] == null) {
				Debug.Log("extract_obj:" + extract_obj_count);
			}
			return extract_obj[jj];
		}
		/*
				//OnTriggerEnter(Collider col)
				//物体同士衝突した時に一度だけ呼ばれるメソッド
				//colliderは当たったオブジェクト
				//OnTriggerEnterのイベントを発行するためにはColliderのIsTriggerフラグをON
				//IsTriggerフラグをONにすると、イベントの判定を行うが、物理エンジンの影響を受けなくなる
				//OnTriggerEnter発生時、IsTriggerフラグをfalseに設定すると物理エンジンが有効となり障害物と衝突する
				//	this.GetComponent<Collider>().isTrigger = true or false;

				void OnTriggerEnter(Collider col){

					if(col.gameObject.transform.root.tag == "cube_empty") {

						GameObject child1 = this.gameObject;
						if (!monster.monster_instance.getMonster_IOstatus(child1.tag)) {

							now_gravitySpheres_count--;

							monster.monster_instance.setMonster_IOstatus(child1.tag, true);
							child1.GetComponent<Collider>().isTrigger = false;

							child1.GetComponent<Rigidbody>().isKinematic = true;

							//接触後、所定ポジション移動
							child1.GetComponent<Rigidbody>().useGravity = false;
							child1.transform.position = col.gameObject.transform.root.position;

							GameObject child = col.gameObject;
			//				child.GetComponent<Collider>().isTrigger = true;
			//				s_cube = col.gameObject;

		//					child.GetComponent<FixedJoint>().connectedBody = child1.GetComponent<Rigidbody>();
		//					child.GetComponent<FixedJoint>().connectedAnchor = child1.transform.position;
		//					child.GetComponent<FixedJoint>().breakForce = 1.0f;
							child.transform.root.tag = "cube_close";
							material_change(col.transform.root.gameObject);

							Singleton<SoundPlayer>.instance.playSE( "hit008" ,2);

							Animator ani = child1.GetComponent<Animator>();
							ani.Play("fall01");
							int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
							monster_color color;
							if (mod != 0) {
								color = monster_color.noColor_monster;
							} else {
								color = monster.monster_instance.getMonster_color(child1.tag);
							}
							change_MonsterMaterial(child1, monster_situation.smile_monster, color);

							// ポイント加算
							int p = gamePointADD();
							point_count = point_count + p;
							hitPointDSP(child1.transform.position, 0);//cube position set

							//ガイドフロアーハイライトクリア
							reset_Guid_Floor();

							if (gravitySpheres_count <= 0) {
								now_gravity = false;
								emitter.emptyCubePosition = true;
							}
							// game clear check
							if (sphere_totalCount - now_sphere_count <= 0 && now_gravitySpheres_count <= 0) {
								timer_Stop = true;
								if ((cubersFile.user_stage < emitter.user_stage_max) && (cubersFile.now_play_stage == cubersFile.user_stage)) cubersFile.user_stage++;
								sw_sphere = false;
								game_complete_proc();
								complete = true;
								emitter.sw_floorUpDown = false;
								gameStatus_text = emitter.gameclear_msg;

								// point dsp off
								pointDSPOff();
								obj_3dtext = null;

							}
						}
						else {
						}


					}
					else if(col.gameObject.transform.root.tag == "cube_close") {

						GameObject child1 = this.gameObject;

						// in object collider?
						if (monster.monster_instance.getMonster_IOstatus(child1.tag)) {
		//					Debug.Log("--------------HIT!!!!--------------");
							return;
						}

						complete = false;

						// パーティクルエフェクト処理
						emitter.effect_explosion = true;
						emitter.monster_bomb(child1);

						monster_reset(child1);

						lost_Spheres--;
						if (lost_Spheres<= 0) {

							// point dsp off
							pointDSPOff();
							obj_3dtext = null;

							timer_Stop = true;

							point_count = 0;
							// ゲームオーバー処理
							sw_sphere = false;
							game_over_proc();
							gameover = true;

							// セーブデータ
							cubersFile.lost_count = 0;

		//					emitter.swCubersfile = 2; // save cubersfile
		//					GetComponent<cubersFile>().save_gameEncryptionData();
		//					emitter.save_gameEncryptionData();

							emitter.sw_floorUpDown = false;
		//					GetComponent<emitter>().stop_BGM();
							gameStatus_text = emitter.gameover_msg;
		//					timer = 10;
		//					counter.timer = 13;
							return;
						}

						if (now_sphere_count > 0) now_sphere_count--;

						if (gravitySpheres_count <= 0) {
		//					sw_sphere = false;
							now_gravity = false;
						}

						reset_Guid_Floor();

					}
					else if(col.gameObject.transform.root.tag == "floor") {

						col.gameObject.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
						col.gameObject.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.85f,0.03f,0.26f));
					}
				}
		*/
		// monster reset
		public static void monster_reset(GameObject obj) {

			obj.GetComponent<Rigidbody>().useGravity = false;
			obj.GetComponent<Rigidbody>().isKinematic = true;
			obj.GetComponent<Collider>().isTrigger = false;
			obj.GetComponent<SphereCollider>().enabled = false;

			//			Destroy(obj.GetComponent<FixedJoint>().enableCollision);

			//			Vector3 obj_start_position = obj.transform.position;
			//			obj_start_position = obj.GetComponent<paku>().getStartPosition();

			//			Vector3 obj_start_position = emit_obj

			obj.transform.position = get_s_round_position(monster.monster_instance.getMonster_position(obj.tag));
			//			Vector3 obj_start_position =  monster.monster_instance.getMonster_position(obj.tag);
			//			obj.transform.position = obj_start_position;
			//			Debug.Log("obj_start_position: " + obj_start_position);

			//			now_sphere_count--;

		}
		// point dsp off
		public static void pointDSPOff() {
			// point dsp off
			if (sphere.obj_pointText != null) {
				int tt = sphere.obj_pointText.Length;
				for (int t = 0; t < tt; t++) {
					if (obj_pointText[t] != null) {
						Destroy(obj_pointText[t]);
						obj_pointText[t] = null;
					}
				}
			}
			if (sphere.anim_pointText != null) {
				int tt = anim_pointText.GetLength(0);
				int ttt = anim_pointText.GetLength(1);
				for (int t = 0; t < tt; t++) {
					for (int i = 0; i < ttt; i++) {
						if (anim_pointText[t, i] != null) {
							Destroy(anim_pointText[t, i]);
							anim_pointText[t, i] = null;
						}
					}
				}
			}
			hitpointcount = 0;

			canvasPanel.chainInfoEffectDSPOff();
		}

		[SerializeField]
		public static GameObject[,] anim_pointText;
		const float fontsize = 22.0f;


		// TODO:: 連鎖数及び連鎖取得アイテム数の表示処理
		// ChainExplosionCount dsp　
		public static void chainExplosionLineCountDSP(Vector3 pos, monster_color color)
		{

			if (anim_pointText == null) anim_pointText = new GameObject[emitter.cubeCount * emitter.cubeCount * emitter.cubeCount, emitter.cubeCount * emitter.cubeCount * emitter.cubeCount];

			Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
			float obj_Y_Position = float.Parse(str_y) / 10;
			Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			float obj_X_Position = float.Parse(str_x) / 10;
			Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			float obj_Z_Position = float.Parse(str_z) / 10;

			// HitPoint dsp position set
			int cubeCount = emitter.cubeCount;
			float cube_scale = emitter.cube_scale;
			int half_cubeCount = cubeCount / 2;
			float offset = cubeCount % 2;
			if (offset != 0) offset = 0;
			else offset = cubeCount / 2;
			// テキスト表示ポジション調整
			if (obj_X_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset)
			{
				pos.x += 0.2f;
			}
			if (obj_X_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset))
			{
				pos.x += 1.2f;
			}
			if (obj_Z_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset)
			{
				pos.z += 0.2f;
			}
			if (obj_Z_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset))
			{
				pos.z += 1.2f;
			}
			pos.y -= 1.5f;
			var text_pos = Camera.main.WorldToScreenPoint(pos);
			// 表示テキストセット
			String str = "";
			str = emitter.chainExplosionLineCount.ToString() + " Chain Line";

			// TODO:キューブ上でのヒットポイント表示処理
			setChainExplosionInfoAnimation(setHitPointPosition(text_pos), str, color);
		}

		// TODO:Hit point dsp　連鎖エッグ表示処理は下記スイッチ１から３の処理を修正 ※未使用により要コメントアウト
		public static void hitPointDSP(Vector3 pos, int sw) {

			if (obj_pointText == null) obj_pointText = new GameObject[emitter.cubeCount * emitter.cubeCount * emitter.cubeCount];
			if (anim_pointText == null) anim_pointText = new GameObject[emitter.cubeCount * emitter.cubeCount * emitter.cubeCount, emitter.cubeCount * emitter.cubeCount * emitter.cubeCount];

			int tt = hitpointcount;

			Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
			float obj_Y_Position = float.Parse(str_y) / 10;
			Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			float obj_X_Position = float.Parse(str_x) / 10;
			Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			float obj_Z_Position = float.Parse(str_z) / 10;

			// HitPoint dsp position set
			int cubeCount = emitter.cubeCount;
			float cube_scale = emitter.cube_scale;
			int half_cubeCount = cubeCount / 2;
			float offset = cubeCount % 2;
			if (offset != 0) offset = 0;
			else offset = cubeCount / 2;

			if (sw != 0) {
				if (obj_Y_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
					pos.y -= 0.1f;
				}
				if (obj_Y_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
					pos.y -= 0.1f;
				}
				if (obj_X_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
					pos.x -= 0.2f;
				}
				if (obj_X_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
					pos.x -= 1.2f;
				}
				if (obj_Z_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
					pos.z -= 0.2f;
				}
				if (obj_Z_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
					pos.z -= 1.2f;
				}
				//				if (obj_Y_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
				//					pos.y += 0.1f;
				//				}
				//				if (obj_Y_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
				//					pos.y += 0.1f;
				//				}
				//				if (obj_X_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
				//					pos.x += 0.2f;
				//				}
				//				if (obj_X_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
				//					pos.x -= 0.2f;
				//				}
				//				if (obj_Z_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
				//					pos.z += 0.2f;
				//				}
				//				if (obj_Z_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
				//					pos.z -= 0.2f;
				//				}

			}
			else {
				pos.y -= 2.2f;
			}

			var text_pos = Camera.main.WorldToScreenPoint(pos);

			if (obj_pointText[tt] != null) {
				//				GameObject wobj1 = obj_pointText[tt];
				//				Material mat1 = wobj1.transform.gameObject.GetComponent<Renderer>().material;
				//				DestroyImmediate(mat1);
				Destroy(obj_pointText[tt]);
			}
			//			obj_pointText[tt] = (GameObject)Instantiate(s_pointText, new Vector3(s_pointText.transform.position.x, s_pointText.transform.position.y, s_pointText.transform.position.z), Quaternion.identity);
			//			obj_pointText[tt].transform.SetParent(s_canvas.transform);
			//			obj_pointText[tt].transform.position = setHitPointPosition(text_pos);
			String str = "";
			switch (sw) {
				case 0:
					str = "10pt";
					break;
				case 1:
					str = "20pt";
					break;
				case 2:
					str = "30pt";
					break;
				case 3:
					str = "1000pt";
					break;
			}

			// キューブ上でのヒットポイント表示処理　TODO::連鎖でのエッグ表示を行う場合下記メソッド修正
			//setHitPointAnimation(setHitPointPosition(text_pos), str, tt, 1);

			hitpointcount++;

		}

		private static float screen_width_per;

		// HitPointアニメーション
		// pos テキスト座標 
		// text 文字列
		// anim アニメーション種別
		/*		// TODO:連鎖でのキューブ上での文字表示処理
				public static void setHitPointAnimation(Vector3 pos,string text, int line_count,int anim) {

					screen_width_per = Screen.width / 1125.0f;
					//screen_width_per = Screen.width / 320.0f;

					var textcount = text.ToString().Length;
					float window_size = Screen.height;
					int font_size = 14;

					for (int i = 0; i < textcount; i++) {
						if (anim_pointText[line_count,i] != null) {
							Destroy(anim_pointText[line_count,i]);
						}
						anim_pointText[line_count,i] = (GameObject)Instantiate(s_pointText, new Vector3(s_pointText.transform.position.x, s_pointText.transform.position.y, s_pointText.transform.position.z), Quaternion.identity);
						anim_pointText[line_count,i].transform.SetParent(s_canvas.transform);
						anim_pointText[line_count,i].transform.position = pos + new Vector3((font_size + 3) * screen_width_per * i, 0.0f, 0.0f);

						anim_pointText[line_count,i].gameObject.GetComponent<Text>().text = text.Substring(i, 1);
						anim_pointText[line_count,i].gameObject.GetComponent<Text>().fontSize = font_size;
						anim_pointText[line_count,i].gameObject.GetComponent<TextEffect>().delay = 0.1f * i;
						anim_pointText[line_count,i].gameObject.GetComponent<TextEffect>().SetVerticesDirty();

						Vector3 scal = anim_pointText[line_count,i].gameObject.GetComponent<Text>().transform.localScale;
						scal.x = scal.x * screen_width_per;
						scal.y = scal.y * screen_width_per;
						anim_pointText[line_count,i].gameObject.GetComponent<Text>().transform.localScale = scal;
					}
				}
		*/
		// TODO:連鎖でのキューブ上での文字表示処理
		// 連鎖数及び取得連鎖アイテム数表示処理
		public static void setChainExplosionInfoAnimation(Vector3 pos, string text, monster_color color)
		{

			// 表示オフはemmiterの// Update() → if (chain_explosion)で親子関係を解除する // chain Explosion reset cheack コメント
			screen_width_per = Screen.width / 1125.0f;
			var textcount = text.ToString().Length;
			float window_size = Screen.height;
			int font_size = 48;
			string sprite_s;
			long sprite_no = (cubersFile.now_play_stage / 2 - 1) * 5;

			switch (color)
            {
				case monster_color.green_monster:
					pointText_w = (GameObject)Instantiate(s_chaineCountGreenText, new Vector3(s_chaineCountGreenText.transform.position.x, s_chaineCountGreenText.transform.position.y, s_chaineCountGreenText.transform.position.z), Quaternion.identity);
					sprite_no += 0;
					break;
				case monster_color.yellow_monster:
					pointText_w = (GameObject)Instantiate(s_chaineCountYellowText, new Vector3(s_chaineCountYellowText.transform.position.x, s_chaineCountYellowText.transform.position.y, s_chaineCountYellowText.transform.position.z), Quaternion.identity);
					sprite_no += 1;
					break;
				case monster_color.red_monster:
					pointText_w = (GameObject)Instantiate(s_chaineCountRedText, new Vector3(s_chaineCountRedText.transform.position.x, s_chaineCountRedText.transform.position.y, s_chaineCountRedText.transform.position.z), Quaternion.identity);
					sprite_no += 2;
					break;
				case monster_color.purple_monster:
					pointText_w = (GameObject)Instantiate(s_chaineCountPurpleText, new Vector3(s_chaineCountPurpleText.transform.position.x, s_chaineCountPurpleText.transform.position.y, s_chaineCountPurpleText.transform.position.z), Quaternion.identity);
					sprite_no += 3;
					break;
				case monster_color.blue_monster:
					pointText_w = (GameObject)Instantiate(s_chaineCountBlueText, new Vector3(s_chaineCountBlueText.transform.position.x, s_chaineCountBlueText.transform.position.y, s_chaineCountBlueText.transform.position.z), Quaternion.identity);
					sprite_no += 4;
					break;
			}

			sprite_s = "<sprite=" + sprite_no.ToString() + ">";
			text = sprite_s + text;

			pointText_w.transform.SetParent(s_canvas.transform);
			pointText_w.transform.position = pos;
			pointText_w.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = text;

            Vector3 scal = pointText_w.gameObject.transform.localScale;
			scal.x = 0.1f;
            scal.y = 0.1f;
			pointText_w.gameObject.transform.localScale = scal;

			var seq = DOTween.Sequence();
			seq.Append(pointText_w.transform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
			seq.Append(pointText_w.transform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));　// 表示時間の為２度設定 1.0f→2.0fよりスムーズ
            seq.OnComplete(() =>
			{
				// アニメーションが終了時によばれる
				pointText_w.gameObject.transform.parent = null;
            });
		}


		// HitPoint表示座標設定
		public static Vector3 Position;
		public static Vector3 setHitPointPosition(Vector3 pos) {
			Position = pos;
			return Position;
		}
		// ポイント加算
		public static int gamePointADD(int sw) {

			int point = 0;
			switch(sw) {
			case 0:
				point = 10;
				break;
			case 1:
				point = 20;
				break;
			case 2:
				point = 30;
				break;
			case 3:
				point = 1000;
				break;
			}
			return point;
		}

//		public static int gamePointADD() {
//
//			int level = (int)cubersFile.now_play_stage;
//			int point = 0;
//			switch(level) {
//			case 1:
//				point = 1;
//				break;
//			case 2:
//				point = 1;
//				break;
//			case 3:
//				point = 1;
//				break;
//			case 4:
//				point = 1;
//				break;
//			case 5:
//				point = 1;
//				break;
//			case 6:
//				point = 1;
//				break;
//			case 7:
//				point = 1;
//				break;
//			case 8:
//				point = 1;
//				break;
//			case 9:
//				point = 1;
//				break;
//			}
//			return point;
//		}

		// material change　モンスター落下時の衝突無しのキューブを消す処理
        // キューブ破壊エフェクト追加
		public static void material_change(GameObject child) {

			GameObject child1 = child.transform.Find("Cube1").gameObject;
			Material mat1 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat1);
			child1.GetComponent<Renderer>().material = mat;

			GameObject child2 = child.transform.Find("Cube2").gameObject;
            Material mat2 = child2.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat2);
			child2.GetComponent<Renderer>().material = mat;
            
			GameObject child3 = child.transform.Find("Cube3").gameObject;
            Material mat3 = child3.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat3);
			child3.GetComponent<Renderer>().material = mat;
            
			GameObject child4 = child.transform.Find("Cube4").gameObject;
            Material mat4 = child4.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat4);
			child4.GetComponent<Renderer>().material = mat;
            
			GameObject child5 = child.transform.Find("Cube5").gameObject;
            Material mat5 = child5.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat5);
			child5.GetComponent<Renderer>().material = mat;
            
			GameObject child6 = child.transform.Find("Cube6").gameObject;
            Material mat6 = child6.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat6);
			child6.GetComponent<Renderer>().material = mat;

		}
		//ガイドフロアーハイライトクリア
		public static void reset_Guid_Floor() {
			
			for (int jj=0; jj<sphere_Count; jj++) {
				for (int ii=0; ii<sphere_Count; ii++) {
					
					emitter.guid_floor[jj,ii].gameObject.transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
					emitter.guid_floor[jj,ii].gameObject.transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.23f,0.89f,0.35f));
				}
			}
		}

	}
}


/*
// Hit point dsp
public static void hitPointDSP(Vector3 pos, int sw) {

	if (obj_3dtext == null) obj_3dtext = new GameObject[emitter.cubeCount * emitter.cubeCount * emitter.cubeCount];

	int tt = hitpointcount;

	Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
	string str_y = wy.ToString();
	float obj_Y_Position = float.Parse(str_y)/10;
	Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
	string str_x = wx.ToString();
	float obj_X_Position = float.Parse(str_x)/10;
	Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
	string str_z = wz.ToString();
	float obj_Z_Position = float.Parse(str_z)/10;

	// HitPoint dsp position set
	int cubeCount = emitter.cubeCount;
	float cube_scale = emitter.cube_scale;
	int half_cubeCount = cubeCount/2;
	float offset = cubeCount%2;
	if (offset != 0) offset = 0;
	else offset = cubeCount/2;

	if (sw != 0) {
		if (obj_Y_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
			pos.y += 0.2f;
		}
		if (obj_Y_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
			pos.y += 0.2f;
		}
		if (obj_X_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
			pos.x += 0.5f;
		}
		if (obj_X_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
			pos.x -= 0.5f;
		}
		if (obj_Z_Position == (-half_cubeCount + cubeCount - 1) * cube_scale + offset) {
			pos.z += 0.5f;
		}
		if (obj_Z_Position == -((-half_cubeCount + cubeCount - 1) * cube_scale + offset)) {
			pos.z -= 0.5f;
		}
	}
	else {
		pos.y += 0.2f;
	}
	if (obj_3dtext[tt] != null) {
		GameObject wobj1 = obj_3dtext[tt];
		Material mat1 = wobj1.transform.gameObject.GetComponent<Renderer>().material;
		DestroyImmediate(mat1);
		Destroy(obj_3dtext[tt]);
	}
	obj_3dtext[tt] = (GameObject)Instantiate(s_number, new Vector3(s_number.transform.position.x, s_number.transform.position.y, s_number.transform.position.z), Quaternion.identity);
	obj_3dtext[tt].transform.position = setHitPointPosition(pos);

	switch(sw) {
	case 0:
		obj_3dtext[tt].GetComponent<ParticleSystem>().startSpeed = 2.5f;
		obj_3dtext[tt].GetComponent<ParticleSystem>().startLifetime = 0.6f;
		obj_3dtext[tt].GetComponent<ParticleSystem>().maxParticles = 1;
		break;
	case 1:
		obj_3dtext[tt].GetComponent<ParticleSystem>().startSpeed = 2;
		obj_3dtext[tt].GetComponent<ParticleSystem>().maxParticles = 2;
		break;
	}

	obj_3dtext[tt].transform.Rotate(Vector3.left * 90);
	int p = gamePointADD();
	switch(p) {
	case 0:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_0;
		break;
	case 1:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_1;
		break;
	case 2:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_2;
		break;
	case 3:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_3;
		break;
	case 4:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_4;
		break;
	case 5:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_5;
		break;
	case 6:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_6;
		break;
	case 7:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_7;
		break;
	case 8:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_8;
		break;
	case 9:
		obj_3dtext[tt].GetComponent<Renderer>().material.mainTexture = s_num_9;
		break;
	}

	hitpointcount++;
}

// point dsp off
public static void pointDSPOff() {
	// point dsp off
	if (sphere.obj_3dtext != null) {
		int tt = sphere.obj_3dtext.Length;
		for (int t = 0; t < tt;t++) {
			if (obj_3dtext[t] != null) {
				GameObject wobj1 = obj_3dtext[t];
				Material mat1 = wobj1.transform.gameObject.GetComponent<Renderer>().material;
				DestroyImmediate(mat1);
				Destroy(obj_3dtext[t]);
				obj_3dtext[t] = null;
			}
		}
	}

	hitpointcount = 0;
}

*/
