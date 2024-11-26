using UnityEngine;
//using UnityEditor;
using System;
using System.Collections;
using System.Linq;
using DG.Tweening;

using nm_sphere;
using nm_canvasPanel;
using nm_monster;
using nm_cubersFile;
using FSP_Samples;
using GoogleMobileAds.Api;

namespace nm_emitter
{

    public class emitter : MonoBehaviour {

		public enum gamePlayState {
			Zero,
			Play,
			Pause
		}
		public enum BGM_State {
			start,
			play,
			Stop,
			pit
		}
		public static gamePlayState playState = gamePlayState.Zero;

		const float button_height = 50;
		const float button_width = 100;
		//public const float wangle = 15;
		const float camera_basePosition = 6.0f;
		public const string gameclear_msg = "Game Completed";
		public const string gameover_msg = "Game Failed";
		public const int startCountDownTimer = 6;	// 5以下になるとカウントダウン timerにズレが生じカウントダウン終了後も落下タイマーカウントが終了するまでモンスター表示されない
		public const int startTempTimer = 10;	//スタートタイマー　7秒 -> ５秒 -> ３秒
		public const int nextDownWaitTimer = 4;  // 落下後、次のモンスター落下待機表示までの待ち時間
        public const int bonus_time = 100; 
		public const long item_cube_gold = 1000;
		public const long item_pause_gold = 1000;
		public const long item_delay_gold = 300;
		public const long item_lostadd_gold = 300;

		public const float PAUSETIME = 15.0f;
        public const int INTERSTITIAL_AD = 6;   //テスト＝１　release=5;

		public static float cube_scale = 1.1f;
		public static float cube_obj_scale;
		// emitter初期化フラグ
		private bool initEmitter = false;

		// 可変待機時間は、ゲージ表示を行うCanvasPanelの表示処理内で設定される
		public static float gravity_Time = 10;	//スタートタイマー　10秒 -> ５秒 -> ３秒

		public static int cubeCount;
		public static int before_cubeCount;

		public const int user_stage_max = 6; // 9
		// TODO:追加　ステージレベルMAX判定に使用
		public const int stageLevel_max = 5;
		public const int chainExplosion_userLeve = 2; // 3

		public const int monsterPositionCenterGroup = 1;
		public const int monsterPositionCenterSideCenterGroup5 = 12;
		public const int monsterPositionCenterCornerGroup5 = 13;
		public const int monsterPositionSideCenterGroup = 2;
		public const int monsterPositionCornerGroup = 3;
		public static monster_color chainExplosioncolor;
		public static int greenChainExplosionLineCount;
		public static int yellowChainExplosionLineCount;
		public static int redChainExplosionLineCount;
		public static int purpleChainExplosionLineCount;
		public static int blueChainExplosionLineCount;
		public static int chainExplosionPoint;

		public static int lost_count_MAX = 3;

		public GameObject Cube_Main;
		public static GameObject[,,] cubes;
		public GameObject Floor;
		public static GameObject[,] guid_floor;

		public GameObject underFloor1;
		public static GameObject under_floor;
		public GameObject circle_delay;
		GameObject delay_obj;
		public static Vector3[] empty_cube_position;

		public static GameObject[] effect_obj;
		public static int effect_obj_count;
		public static GameObject touchEffect_obj;
		public GameObject touchChainExplosionEffect;
		public static GameObject s_touchChainExplosionEffect;
		public static GameObject shootEffect_obj;
		public static Vector3 monsterCounterPosition;
		public GameObject shootChainExplosionEffect;
		public static GameObject s_shootChainExplosionEffect;


		public Material open_cube_m;
		public Material open_cube_m_h;
		public static Material cube_m;
		public static Material cube_m_h;
		public Material close_cube_m;
		public Material close_cube_m_h;
		public  static Material c_cube_m;
		public  static Material c_cube_m_h;
		public Color wcolor;
		public Color wBaseColor;

		public float screen_width;
		public float screen_height;

		public sphere sp;

		public static bool sw_Gravity;

		public AudioClip sphere_garavity_sound;
		private AudioSource audioSource;
		
		public GameObject explosion1;
		public GameObject explosion2;
		public GameObject explosion_monster_bomb;
        public GameObject explosion_cube_bomb;
        public static GameObject s_explosion2;
		public static GameObject s_explosion_monster_bomb;
        public static GameObject s_explosion_cube_bomb;
        // BGM
        public static BGMPlayer player;
		BGMPlayer player1;
		public static float fadeInTime = 1.0f;
		public static float fadeOutTime = 1.0f;

//		public static bool select_game = false;
		public static bool sw_delay;
		public static bool sw_pause;
        public static bool sw_stop;
        public static bool sw_floorUpDown;

//		public static IDictionary response;
		public static IDictionary response2;

		// 連鎖数(ChainExplosionLine数)
		public static int chainExplosionLineCount;
		public static int chainExplosionLineTotalCount;  //　これまでの連鎖数の総数		ゲームベース情報として保存される
		public static int chainExplosionLinePlayCount;	//　ステージ攻略時の全連鎖数		ステージ攻略ランキングデータとして保存される
		public static int chainExplosionLinePlayMAX;     //　ステージ攻略時の最大連鎖数	ステージ攻略ランキングデータとして保存される
		public static int juelyItem1Cuont;          //　ジュエリー１獲得数			ゲームベース情報として保存される
		public static int goldItemCount;            //　ゴールドアイテム獲得数		ゲームベース情報として保存される
		public static int silverItemCount;          //　シルバーアイテム獲得数		ゲームベース情報として保存される
		public static int playGetSilverItemCount;          //　プレイ中シルバーアイテム獲得数		ゲームコンプリート時に累計加算され現在のアイテム表示に反映される

		public static int tempoLength;
		public const int threeCube = 10; // 1 tempゲージあたりの秒数
		public const int fourCube = 20; // 1 tempゲージあたりの秒数
		public const int fiveCube = 30; // 1 tempゲージあたりの秒数
		public const int slowTempoTime = 10;
		public const int midlleTempoTime = 7;
		public const int highTempoTime = 4;

		void Awake() {

			screen_width = Screen.width;
			screen_height = Screen.height;

		}

		// Use this for initialization
		void Start () {
			//  フレームレート設定　固定　※Project Setting→Auality→Level(Beautiful＆Vsync Count[Don`t Sync]設定が必要)
			Application.targetFrameRate = 60;

			reset_flag();

			cube_m = open_cube_m;
            cube_m_h = open_cube_m_h;
			c_cube_m = close_cube_m;
			c_cube_m_h = close_cube_m_h;

			s_explosion2 = explosion2;
			s_explosion_monster_bomb = explosion_monster_bomb;
            s_explosion_cube_bomb = explosion_cube_bomb;
            s_touchChainExplosionEffect = touchChainExplosionEffect;
			s_shootChainExplosionEffect = shootChainExplosionEffect;

			cube_obj_scale = Cube_Main.transform.localScale.y; // cube object base scale

			audioSource = this.GetComponent<AudioSource>();
			audioSource.clip = sphere_garavity_sound;

			// Google Mobile Ads Init.
			// Initialize the Google Mobile Ads SDK.
			MobileAds.Initialize(initStatus => { });

			pause_timer = PAUSETIME;

			updown_timer = nextDownWaitTimer;  // 落下後、次のモンスター落下待機表示までの待ち時間

            make_UnderFloor();
            MainMenuDsp();

		}

		private void MainMenuDsp() {

			//canvasPanel.s_mainMenu_field.gameObject.SetActive(true);
			canvasPanel.setCenterView(1);
			canvasPanel.s_center_View.gameObject.SetActive(true);
			canvasPanel.sunshinerotate = 2;
			canvasPanel.sunshinerotateTime = 20;
		}

		void start_BGM() {

			if ( player == null ) {
				player = new BGMPlayer( "paku_BGM-3" );
				player.playBGM( fadeInTime );
			} else
				player.playBGM();
			if (player1 == null)
				player1 = new BGMPlayer( "paku_BGM-1" );
		}

		public Material underMT;
		public Material underMT1;
		public Material underMT2;
		public Material underMT3;
		public Material underMT4;
		public Material underMT5;
		public Material underMT6;
		public Material underMT7;
        public Material mat;

		// UnderFloor セット
		
		public void make_UnderFloor() {
			// under floor
			if (cubersFile.game_Sceen == 0)
			{
				setUnderfloorMaerial();
				if (under_floor != null)
				{
					Destroy(under_floor);
				}
				under_floor = new GameObject();
				under_floor = (GameObject)Instantiate(underFloor1, new Vector3(-20.0f, 25.0f, -20.0f), Quaternion.identity);
			}
		}
		// underFloor material set
		public void setUnderfloorMaerial()
        {
            int mat_no = UnityEngine.Random.Range(0, 7);
            switch (mat_no)
            {
                case 0:
                    mat = new Material(underMT);
                    break;
                case 1:
                    mat = new Material(underMT1);
                    break;
                case 2:
                    mat = new Material(underMT2);
                    break;
                case 3:
                    mat = new Material(underMT3);
                    break;
                case 4:
                    mat = new Material(underMT4);
                    break;
                case 5:
                    mat = new Material(underMT5);
                    break;
                case 6:
                    mat = new Material(underMT6);
                    break;
                case 7:
                    mat = new Material(underMT7);
                    break;
            }
            underFloor1.GetComponent<MeshRenderer>().material = mat;

        }
        //Uperfloor 高さ cube_scale * cubeCount + 0.5f <- offset調整で、併せてsphere sphere_dwon()内 sphere_scale - 0.2f <-offset調整
        void make_UperFloor() {

			// guid floor
			guid_floor = new GameObject[cubeCount,cubeCount];

			int half_cubeCount = cubeCount/2;
			float offset = cubeCount%2;
			if (offset != 0) offset = 0;
			else offset = cube_scale/2;
			
			for (int jj=0; jj<cubeCount; jj++) {
				for (int ii=0; ii<cubeCount; ii++) {
					if (guid_floor [jj,ii] != null) {
						GameObject obj = guid_floor [jj,ii];
						Material mat = obj.transform.gameObject.GetComponent<Renderer>().material;
						DestroyImmediate(mat);
						Destroy(guid_floor [jj,ii]);
					}
					guid_floor [jj,ii] = (GameObject)Instantiate (Floor, new Vector3 ((-half_cubeCount + jj) * cube_scale + offset, cube_scale * cubeCount + 0.5f, (-half_cubeCount + ii) * cube_scale + offset), Quaternion.identity);
					guid_floor [jj,ii].transform.root.tag = "floor";
					guid_floor [jj,ii].transform.gameObject.GetComponent<Renderer>().material.EnableKeyword("_EMISSION");
					guid_floor [jj,ii].transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(0.23f,0.89f,0.35f));
				}
			}
		}

        public static void levelCheck(long level) {

//			float screen_width_per = Screen.width / 320.0f;

			before_cubeCount = cubeCount;

			switch(level) {
			case 1:
			case 2:
				cubeCount = 3;
				lost_count_MAX = 3;
				break;
			case 3:
			case 4:
				cubeCount = 4;
				lost_count_MAX = 4;
				break;
			case 5:
			case 6:
				cubeCount = 5;
				lost_count_MAX = 5;
				break;
			}

//			float screen_width_per = Screen.width / 320.0f;

			// 開発している画面を元に縦横比取得 (縦画面) iPhone6, 6sサイズ
			float developAspect = 750.0f / 1624.0f;
//			float developAspect = 750.0f / 1334.0f;
			// 横画面で開発している場合は以下の用に切り替えます
//			float developAspect = 1334.0f / 750.0f;

			// 実機のサイズを取得して、縦横比取得
			float deviceAspect = (float)Screen.width / (float)Screen.height;
			float w1 = Screen.width;
			float w2 = Screen.height;
			// 実機と開発画面との対比
			float scale = deviceAspect / developAspect;

			Camera mainCamera = Camera.main;

			// カメラに設定していたorthographicSizeを実機との対比でスケール
			float deviceSize = mainCamera.orthographicSize;
			// scaleの逆数
			float deviceScale = 1.0f / scale;
			// orthographicSizeを計算し直す
			mainCamera.orthographicSize = deviceSize * deviceScale;


			if (before_cubeCount == 0) before_cubeCount = cubeCount;

			// iPhoneX 
			float iPhoneX_offset = 0;
			if (Screen.height >= 1624) iPhoneX_offset = 1.5f;
			Vector3 pos = Camera.main.transform.position;
			if (cubeCount == 3) {
				pos.x = camera_basePosition + cubeCount - 0.5f + iPhoneX_offset;
				pos.y = camera_basePosition + cubeCount - 1.1f + iPhoneX_offset;
				pos.z = camera_basePosition + cubeCount - 0.5f + iPhoneX_offset;
			} 
			else if (cubeCount == 4) {
				pos.x = camera_basePosition + cubeCount + 1.5f + iPhoneX_offset;
				pos.y = camera_basePosition + cubeCount + 0.2f + iPhoneX_offset;
				pos.z = camera_basePosition + cubeCount + 1.5f + iPhoneX_offset;
			}
			else {
				pos.x = camera_basePosition + cubeCount + 2.15f + iPhoneX_offset;
				pos.y = camera_basePosition + cubeCount + 0.9f + iPhoneX_offset;
				pos.z = camera_basePosition + cubeCount + 2.1f + iPhoneX_offset;
			}

			Camera.main.transform.position = pos;

			if (sphere.sphere_Count != 0) sphere.before_sphere_Count = sphere.sphere_Count;
			else sphere.before_sphere_Count = cubeCount;
			sphere.sphere_Count = cubeCount;

		}

		public Texture texture1;

		//   cube base make
		void make_cube() {

			cubes = new GameObject[cubeCount,cubeCount,cubeCount];
			if (empty_cube_position != null) empty_cube_position = null;
			empty_cube_position = new Vector3[cubeCount * cubeCount *cubeCount];

			int half_cubeCount = cubeCount/2;
			float offset = cubeCount%2;
			if (offset != 0) offset = 0;
			else offset = cube_scale/2;
			int setCubeCount = 0;
            var intensity = -4;
            var factor = Mathf.Pow(1.5f, intensity);
            //wBaseColor = new Color((255.0f / 255.0f) * factor, (255.0f / 255.0f) * factor, (255.0f / 255.0f) * factor, 80.0f / 255.0f); // 白
            wBaseColor = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 80.0f / 255.0f); // 白
			int mod = (int)cubersFile.now_play_stage;
			//			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			switch (mod) {
			case 1:
			case 2:
//				texture1 = (Texture)Resources.Load ("0 star/juwelly");
				texture1 = (Texture)Resources.Load ("0 star/star_1");

                //wcolor = new Color(28.0f/255.0f, 220.0f / 255.0f, 28.0f / 255.0f, 80.0f / 255.0f); // グリーン
                wcolor = new Color((28.0f/255.0f) * factor, (220.0f / 255.0f) * factor, (28.0f /255.0f) * factor, 80.0f / 255.0f); // グリーン
				//wcolor = new Color(229.0f/255.0f,156.0f/255.0f,91.0f/255.0f,136.0f/255.0f); //オレンジ
				//wcolor = new Color(17.0f/255.0f,47.0f/255.0f,151.0f/255.0f,200.0f/255.0f);
				//wcolor = new Color(0,141.0f/255.0f,123.0f/255.0f);
//				wcolor = new Color(0.683f,0,0);
				break;
			case 3:
			case 4:
				texture1 = (Texture)Resources.Load ("0 star/Heart_3");
				wcolor = new Color((220.0f/255.0f) * factor,(220.0f /255.0f) * factor, (20.0f/255.0f) * factor, 80.0f / 255.0f); //オレンジ
				//wcolor = new Color(220.0f/255.0f,220.0f/255.0f,20.0f/255.0f, 80.0f / 255.0f); //オレンジ
				//wcolor = new Color(156.0f/255.0f,0.0f/255.0f,87.0f/255.0f);
//				wcolor = new Color(0,0.683f,0);
				break;
			case 5:
			case 6:
				texture1 = (Texture)Resources.Load ("0 star/dai_1");
				wcolor = new Color((220.0f/255.0f) * factor, (28.0f/255.0f) * factor, (28.0f/255.0f) * factor, 80.0f / 255.0f);
				//wcolor = new Color(220.0f/255.0f, 28.0f/255.0f, 28.0f/255.0f, 80.0f / 255.0f);
//				wcolor = new Color(91.0f/255.0f,229.0f/255.0f,109.0f/255.0f,136.0f/255.0f); // グリーン
				//wcolor = new Color(121.0f/255.0f,128.0f/255.0f,0.0f/255.0f);
//				wcolor = new Color(0.683f,0.683f,0);
				break;
			}


            //cube_m.SetTexture("_MainTex", texture1);
            cube_m.SetColor("_EmissionColor", wcolor);
            //cube_m.SetColor("_SpecColor", wcolor);
            cube_m.SetColor("_Color", wBaseColor);
            //cube_m.SetColor("_Color", wcolor);


            //cube_m.SetColor("_Albedo", wcolor);
            //cube_m.SetColor("_EmissionColor", wcolor);
            //cube_m.SetColor("_Color", wcolor);
            //cube_m_h.SetColor("_Color", wcolor);



            for (int j=0; j<cubeCount; j++) {
				for (int k=0; k<cubeCount; k++) {
					for (int i=0; i<cubeCount; i++) {
						
						if ((j > 0 && j < cubeCount - 1) && (k > 0 && k < cubeCount - 1) && (i > 0 && i < cubeCount - 1)) {
						}
						else { 
							if (cubes [j,k,i] != null) {
								destroyCubeMaterial(cubes [j,k,i]);
								Destroy(cubes [j,k,i]);
							}
							cubes [j,k,i] = (GameObject)Instantiate (Cube_Main, new Vector3 ((-half_cubeCount + i) * cube_scale + offset, (-half_cubeCount + k) * cube_scale + offset, (-half_cubeCount + j) * cube_scale + offset), Quaternion.identity);
							cubes [j,k,i].transform.root.tag = "cube_empty";
							
							empty_cube_position[setCubeCount] = cubes[j,k,i].transform.position;
							setCubeCount++;
							
							GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
							child1.GetComponent<Collider>().isTrigger = false;
							child1.GetComponent<Renderer>().material = cube_m;
                            GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
							child2.GetComponent<Renderer>().material = cube_m;
							child2.GetComponent<Collider>().isTrigger = false;
                            GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
							child3.GetComponent<Collider>().isTrigger = false;
							child3.GetComponent<Renderer>().material = cube_m;
                            GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
							child4.GetComponent<Collider>().isTrigger = false;
							child4.GetComponent<Renderer>().material = cube_m;
                            GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
							child5.GetComponent<Collider>().isTrigger = false;
							child5.GetComponent<Renderer>().material = cube_m;
                            GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
							child6.GetComponent<Collider>().isTrigger = false;
							child6.GetComponent<Renderer>().material = cube_m;
                        }
                    }
				}
			}
		}
		void floor_clear() {

			if (guid_floor == null) return;
			for (int jj=0; jj<before_cubeCount; jj++) {
				for (int ii=0; ii<before_cubeCount; ii++) {
					if (guid_floor [jj,ii] != null) {
						GameObject obj = guid_floor [jj,ii];
						Material mat = obj.transform.gameObject.GetComponent<Renderer>().material;
						DestroyImmediate(mat);
						Destroy(guid_floor [jj,ii]);
						guid_floor [jj,ii] = null;
					}
				}
			}
		}
		public void reset_Cube(){
			
			screen_width = Screen.width;
			screen_height = Screen.height;

			effect_obj = new GameObject[cubeCount * cubeCount * cubeCount];
			effect_explosion_obj = new GameObject[cubeCount * cubeCount * cubeCount * 20];
			touchEffect_obj = new GameObject();
			shootEffect_obj = new GameObject();

			start_BGM();

			floor_clear();
			make_UperFloor();
            make_UnderFloor();
			cube_clear();
			make_cube();

			canvasPanel.creditCountImageInit(cubeCount);
			canvasPanel.s_gameTime_text.text = "00:00:00";
			canvasPanel.gametempoCount = 0;
			canvasPanel tempochg = GetComponentInChildren<canvasPanel>();
			tempochg.gameTempoReset();

			initGameTempo();
				
			reset_flag();
			reset_effect();
			reset_chainExplosionCounter();

			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			if (mod == 0) {
				canvasPanel.s_monsterColorCountView.gameObject.SetActive(true);
				canvasPanel.monsterColor = true;
			} else {
				canvasPanel.s_monsterColorCountView.gameObject.SetActive(false);
			}

		}

		// ゲーム落下tempo 設定 
		void initGameTempo () {
			int cubecount = emitter.cubeCount;
			switch(cubecount) {
			case 3:
				tempoLength = threeCube;
				break;
			case 4:
				tempoLength = fourCube;
				break;
			case 5:
				tempoLength = fiveCube;
				break;
			default:
				tempoLength = threeCube;
				break;
			}
		}

		// 連鎖カウンターリセット
		public void reset_chainExplosionCounter() {
			// １プレー中連鎖ライン数累計カウンター&最大ライン数保存値リセット
			chainExplosionLinePlayCount = 0;
			chainExplosionLinePlayMAX = 0;
			playGetSilverItemCount = 0;

			monster.monster_instance.init_chainExplosionLineCount(cubersFile.now_play_stage);
			monster.monster_instance.init_chainExplosionCounter(cubersFile.now_play_stage);
		}
		public void reset_flag() {

			initEmitter = true;
			playState = gamePlayState.Zero;
			canvasPanel.timeChange = true;

			sw_Gravity = true;
			sw_delay = false;

			material_ck = false;
			game_complete = false;

			reset_cubeAngle();

			effect_explosion = false;
		}
		// エフェクトオブジェクトクリア
		void reset_effect() {
			// effect clear
			int ii = effect_obj.Length;
			for (int i = 0; i < ii; i++) {
				if (effect_obj[i] != null) {
//					GameObject obj = effect_obj[i];
//					Material mat = obj.transform.gameObject.GetComponent<Renderer>().material;
//					DestroyImmediate(mat);
					Destroy(effect_obj[i]);
					effect_obj[i] = null;
				}
			}
			effect_obj_count = 0;

			if (touchEffect_obj != null) {
				Destroy(touchEffect_obj);
				touchEffect_obj = null;
			}
			if (shootEffect_obj != null) {
				Destroy(shootEffect_obj);
				shootEffect_obj = null;
			}

			int iii = effect_explosion_obj.Length;
			for (int i = 0; i < iii; i++) {
				if (effect_explosion_obj[i] != null) {
//					GameObject obj = effect_explosion_obj[i];
//					Material mat = obj.transform.gameObject.GetComponent<Renderer>().material;
//					DestroyImmediate(mat);
					Destroy(effect_explosion_obj[i]);
					effect_explosion_obj[i] = null;
				}
			}
			effect_explosion_obj_count = 0;
		}
		void reset_cubeAngle() {

			turn_move = false;
            turn_end = false;
            turn_angle = 0;
			right_up_rotate = false; right_down_rotate = false; left_up_rotate = false; left_down_rotate = false;
			left_rotate = false; right_rotate = false;
			left_turn = 999; right_turn = 999;
			left_up_turn = 999; right_up_turn = 999;
			left_down_turn = 999; right_down_turn = 999;
			
		}
		
		// cube roteto guid on
		static Vector3 obj_Position;
         static Vector3 cube_Position;

		public static void touchcube_guid_ON(GameObject obj) {
			
             obj_Position = setObjectLocation(obj);
            
			for (int j=0; j< cubeCount; j++) {
				for (int k=0; k< cubeCount; k++) {
					for (int i=0; i< cubeCount; i++) {

						if (cubes[j,k,i] != null) {

                               cube_Position = setObjectLocation(cubes[j, k, i]);
							
							if (cube_Position.y == obj_Position.y
							    || (cube_Position.x == obj_Position.x
                                   && cube_Position.y == obj_Position.y)) {
                                
								if ((j > 0 && j < cubeCount - 1) && (k > 0 && k < cubeCount - 1) && (i > 0 && i < cubeCount - 1)) {
								}
								else { 
									
									if (cubes[j,k,i].transform.root.tag == "cube_empty") {

										GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
										child1.GetComponent<Renderer>().material = cube_m_h;
										GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
										child2.GetComponent<Renderer>().material = cube_m_h;
										GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
										child3.GetComponent<Renderer>().material = cube_m_h;
										GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
										child4.GetComponent<Renderer>().material = cube_m_h;
										GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
										child5.GetComponent<Renderer>().material = cube_m_h;
										GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
										child6.GetComponent<Renderer>().material = cube_m_h;
									}
									else {

										GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
										child1.GetComponent<Renderer>().material = c_cube_m_h;
										GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
										child2.GetComponent<Renderer>().material = c_cube_m_h;
										GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
										child3.GetComponent<Renderer>().material = c_cube_m_h;
										GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
										child4.GetComponent<Renderer>().material = c_cube_m_h;
										GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
										child5.GetComponent<Renderer>().material = c_cube_m_h;
										GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
										child6.GetComponent<Renderer>().material = c_cube_m_h;
									}
								}
							}
						}
					}
				}
			}
		}

		public static GameObject[] effect_explosion_obj;
		public static int effect_explosion_obj_count;
		public static bool effect_explosion;
		public static float effect_Explosion_timer;
		// monster explosion
		public static void monster_Explosion(GameObject obj) {

			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			monster_color color;
			Color explosion_color;
			if (mod != 0) {
				color = monster_color.noColor_monster;
			} else {
				color = monster.monster_instance.getMonster_color(obj.tag);
			}
			switch (color) {
			case monster_color.blue_monster:
				explosion_color = new Color(0.18f, 0.66f, 1.0f, 0.94f);
				break;
			case monster_color.green_monster:
				explosion_color = new Color(0.25f, 1.0f, 0.11f, 0.94f);
				break;
			case monster_color.red_monster:
				explosion_color = new Color(1.0f, 0.33f, 0.17f, 0.94f);
				break;
			case monster_color.purple_monster:
				explosion_color = new Color(0.64f, 0.0f, 1.0f, 0.94f);
				break;
			case monster_color.yellow_monster:
				explosion_color = new Color(1.0f, 0.89f, 0.04f, 0.94f);
				break;
			case monster_color.orange_monster:
				explosion_color = new Color(0.74f, 0.36f, 0.01f, 0.94f);
				break;
			default:
				explosion_color = new Color(.97f, 0.84f, 0.29f, 0.94f);
				break;
			}
			if (effect_explosion_obj[effect_explosion_obj_count] != null) {
				Destroy(effect_explosion_obj[effect_explosion_obj_count]);
			}
			effect_explosion_obj[effect_explosion_obj_count] = (GameObject)Instantiate(s_explosion_monster_bomb, 
				new Vector3(s_explosion_monster_bomb.transform.position.x, s_explosion_monster_bomb.transform.position.y, s_explosion_monster_bomb.transform.position.z),
				Quaternion.identity);
			Vector3 effect_position = obj.transform.position;
			effect_position.y -= 1.0f;
			effect_explosion_obj[effect_explosion_obj_count].transform.position = effect_position;

			GameObject obj1 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Stamp_pfireball01").gameObject;
			var main1 = obj1.GetComponent<ParticleSystem>().main;
			main1.startColor = explosion_color;
			effect_explosion_obj_count++;

			Singleton<SoundPlayer>.instance.playSE_2( "bomb005" ,2);

			effect_Explosion_timer = 2;
		}
        // Cube boemb
        public static void cube_explosion(GameObject obj)
        {

            if (effect_explosion_obj[effect_explosion_obj_count] != null)
            {
                Destroy(effect_explosion_obj[effect_explosion_obj_count]);
            }
            effect_explosion_obj[effect_explosion_obj_count] = (GameObject)Instantiate(s_explosion_cube_bomb,
                new Vector3(s_explosion_cube_bomb.transform.position.x, s_explosion_cube_bomb.transform.position.y, s_explosion_cube_bomb.transform.position.z),
                Quaternion.identity);
            Vector3 effect_position = obj.transform.position;
            effect_position.y -= 1.0f;
            effect_explosion_obj[effect_explosion_obj_count].transform.position = effect_position;

            // 破壊されるキューブのマテリアルをセット
            GameObject child1 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube1").gameObject;
            child1.GetComponent<Renderer>().material = cube_m;
            GameObject child2 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube2").gameObject;
            child2.GetComponent<Renderer>().material = cube_m;
            GameObject child3 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube3").gameObject;
            child3.GetComponent<Renderer>().material = cube_m;
            GameObject child4 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube4").gameObject;
            child4.GetComponent<Renderer>().material = cube_m;
            GameObject child5 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube5").gameObject;
            child5.GetComponent<Renderer>().material = cube_m;
            GameObject child6 = effect_explosion_obj[effect_explosion_obj_count].transform.Find("Cube6").gameObject;
            child6.GetComponent<Renderer>().material = cube_m;

            effect_explosion_obj_count++;

			effect_Explosion_timer = 0.1f;
        }

		// monster chain explosion 
		static Vector3 monster_Position;
         static Vector3 monster2_Position;

		static Vector3 chainExplosion_Touch_Position;

		static GameObject[] Y_surface_monster;
		static GameObject[] X_surface_monster;
		static GameObject[] Z_surface_monster;

		static GameObject[] chain_monster;

		// TODO:連鎖数をセット　setMonsterChainObectでカウントセット　monster_chain_explosionで連鎖爆破エフェクトセット
		static int chain_count = 0;

		static bool chain_explosion = false;
		static float chain_explosion_timer = 1.8f;
//		static bool shoot_bomb = false;

        static Vector3 setObjectLocation(GameObject obj)
        {
            Vector3 wlocation;
            Double wy = Math.Round(obj.transform.root.position.y * 10, 1, MidpointRounding.AwayFromZero);
            string str_y = wy.ToString();
            wlocation.y = float.Parse(str_y) / 10;
            Double wx = Math.Round(obj.transform.root.position.x * 10, 1, MidpointRounding.AwayFromZero);
            string str_x = wx.ToString();
            wlocation.x = float.Parse(str_x) / 10;
            Double wz = Math.Round(obj.transform.root.position.z * 10, 1, MidpointRounding.AwayFromZero);
            string str_z = wz.ToString();
            wlocation.z = float.Parse(str_z) / 10;
            
            return wlocation;

        }

        // タッチされた面に繋がるモンスターを抽出
        public static void checkMonsterChain(Vector3 checkOBJPosition, float offset1, monster_color m_color)
        {
            // monster in touch cube
            // 連鎖条件に合致するモンスターオブジェクトをチェック
            for (int jj = 0; jj < cubeCount; jj++)
            {
                for (int kk = 0; kk < cubeCount; kk++)
                {
                    for (int ii = 0; ii < cubeCount; ii++)
                    {

                        if (sphere.spheres[jj, kk, ii] != null && monster.monster_instance.getMonster_IOstatus(sphere.spheres[jj, kk, ii].transform.tag))
                        {
                            monster2_Position = setObjectLocation(sphere.spheres[jj, kk, ii]);
                            // Hit obj position == Y surface -> chain check
                            // Y面(天井水平面またはY下部)をタッチの場合　そこにあるモンスターオブジェクトをセット
                            if ((checkOBJPosition.y == offset1 && monster2_Position.y == offset1)
                                || (checkOBJPosition.y == -offset1 && monster2_Position.y == -offset1))
                            {
                                monster_color m2_color = monster.monster_instance.getMonster_color(sphere.spheres[jj, kk, ii].tag);

                                Vector3 wloc = setObjectLocation(sphere.spheres[jj, kk, ii]);
                                monster2_Position.x = wloc.x;
                                monster2_Position.z = wloc.z;
                                // Y line chain
                                if (m_color == m2_color && checkOBJPosition.x == monster2_Position.x)
                                {
                                    YX_lineobj[YX_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    YX_lineobjCount++;
                                }
                                // Y line chain
                                if (m_color == m2_color && checkOBJPosition.z == monster2_Position.z)
                                {
                                    YZ_lineobj[YZ_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    YZ_lineobjCount++;
                                }
                            }
                            // Hit obj position == X surface -> chain check
                            // X面(右垂直側面)をタッチ もしくは
                            // Y面(左垂直側面)の左端をタッチの場合　隠れいてるX面にあるモンスターオブジェクトをセット
                            if ((checkOBJPosition.x == offset1 && monster2_Position.x == offset1)
                                || (checkOBJPosition.x == -offset1 && monster2_Position.x == -offset1))
                            {
                                monster_color m2_color = monster.monster_instance.getMonster_color(sphere.spheres[jj, kk, ii].tag);

                                Vector3 wloc = setObjectLocation(sphere.spheres[jj, kk, ii]);
                                monster2_Position.z = wloc.z;
                                monster2_Position.y = wloc.y;
                                // X line chain
                                // Z line chain
                                if (m_color == m2_color && checkOBJPosition.z == monster2_Position.z)
                                {
                                    XZ_lineobj[XZ_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    XZ_lineobjCount++;
                                }
                                if (m_color == m2_color && checkOBJPosition.y == monster2_Position.y)
                                {
                                    XY_lineobj[XY_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    XY_lineobjCount++;
                                }
                            }
                            // X面(右垂直側面)の右端をタッチした場合　もしくは
                            // Y面(左垂直側面)をタッチの場合　そこにあるモンスターオブジェクトをセット
                            if ((checkOBJPosition.z == -offset1 && monster2_Position.z == -offset1)
                                || (checkOBJPosition.z == offset1 && monster2_Position.z == offset1))
                            {
                                monster_color m2_color = monster.monster_instance.getMonster_color(sphere.spheres[jj, kk, ii].tag);

                                Vector3 wloc = setObjectLocation(sphere.spheres[jj, kk, ii]);
                                monster2_Position.x = wloc.x;
                                monster2_Position.y = wloc.y;
                                // X line chain
                                if (m_color == m2_color && checkOBJPosition.x == monster2_Position.x)
                                {
                                    ZX_lineobj[ZX_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    ZX_lineobjCount++;
                                }
                                // X line chain
                                if (m_color == m2_color && checkOBJPosition.y == monster2_Position.y)
                                {
                                    ZY_lineobj[ZY_lineobjCount] = sphere.spheres[jj, kk, ii];
                                    ZY_lineobjCount++;
                                }
                            }
                        }
                    }
                }
            }

        }
        // 抽出された連鎖をセット            
        public static bool setMonsterChainObect(monster_color m_color)
        {
            //Debug.Log("YX_lineobjCount = " + YX_lineobjCount);
            //Debug.Log("YZ_lineobjCount = " + YZ_lineobjCount);
            //Debug.Log("XZ_lineobjCount = " + XZ_lineobjCount);
            //Debug.Log("XY_lineobjCount = " + XY_lineobjCount);
            //Debug.Log("ZX_lineobjCount = " + ZX_lineobjCount);
            //Debug.Log("ZY_lineobjCount = " + ZY_lineobjCount);
            bool status = false;
            // 連鎖チェック＆エフェクトセット
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (YX_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < YX_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = YX_lineobj[t];
                    setChainExplosionEffect(YX_lineobj[t]);
                }
                chain_count += YX_lineobjCount;
                status = true;
            }
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (YZ_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < YZ_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = YZ_lineobj[t];
                    setChainExplosionEffect(YZ_lineobj[t]);
                }
                chain_count += YZ_lineobjCount;
                status = true;
            }
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (XZ_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < XZ_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = XZ_lineobj[t];
                    setChainExplosionEffect(XZ_lineobj[t]);
                }
                chain_count += XZ_lineobjCount;
                status = true;
            }
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (XY_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < XY_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = XY_lineobj[t];
                    setChainExplosionEffect(XY_lineobj[t]);
                }
                chain_count += XY_lineobjCount;
                status = true;
            }
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (ZX_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < ZX_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = ZX_lineobj[t];
                    setChainExplosionEffect(ZX_lineobj[t]);
                }
                chain_count += ZX_lineobjCount;
                status = true;
            }
            // Cubeカウント==同色連鎖モンスタライン個数？
            if (ZY_lineobjCount >= cubeCount && m_color != monster_color.white_monster)
            {
                // 連鎖発生！！
                for (int t = 0; t < ZY_lineobjCount; t++)
                //for (int t = 0; t < cubeCount; t++)
                {
                    chain_monster[chain_count + t] = ZY_lineobj[t];
                    setChainExplosionEffect(ZY_lineobj[t]);
                }
                chain_count += ZY_lineobjCount;
                status = true;
            }
        return status;
        }
            
        // 連鎖モンスターの重複登録をチェック 
        public static bool checkChainMonsterDuplicate(GameObject obj, int arrayPosition)
        {
            bool status = false;
            Vector3 checkMonster_position = obj.transform.position;
            for (int i = arrayPosition - 1; 0 < i; i--)
            {
                Vector3 chainMonster_position = chain_monster[i].transform.position;
                // 設定済みならそのまま戻る
                if (checkMonster_position == chainMonster_position)
                {
                    status = true;
                }
            }
            return status;
        }

        static GameObject[] YX_lineobj;
        static GameObject[] YZ_lineobj;
        static GameObject[] XY_lineobj;
        static GameObject[] XZ_lineobj;
        static GameObject[] ZY_lineobj;
        static GameObject[] ZX_lineobj;
        static int YX_lineobjCount = 0;
        static int YZ_lineobjCount = 0;
        static int XY_lineobjCount = 0;
        static int XZ_lineobjCount = 0;
        static int ZY_lineobjCount = 0;
        static int ZX_lineobjCount = 0;

        public static bool gravityLastMonster = false;
        // obj = touch cube
        // 連鎖 モード　連鎖をチェック
        public static void monster_chain_Explosion(GameObject obj) {

			// 連鎖 中？
			if (chain_explosion) return;

			chain_explosion = false;
			chain_explosion_timer = 0;

			chainExplosionLineCount = 0;

			chain_count = 0;

            YX_lineobj = new GameObject[cubeCount*cubeCount*cubeCount];
			YZ_lineobj	= new GameObject[cubeCount*cubeCount*cubeCount];
			XY_lineobj	= new GameObject[cubeCount*cubeCount*cubeCount];
			XZ_lineobj	= new GameObject[cubeCount*cubeCount*cubeCount];
			ZY_lineobj	= new GameObject[cubeCount*cubeCount*cubeCount];
			ZX_lineobj	= new GameObject[cubeCount*cubeCount*cubeCount];

            // タッチされたポジションのモンスターの座標セット
            obj_Position = setObjectLocation(obj);

			chainExplosion_Touch_Position = obj.transform.root.position;

            // 中心が０だからoffset1は＋ーで面の終端側を指す、面の終端の位置を判断する為に利用
            int half_cubeCount = cubeCount / 2;
            float offset = cubeCount % 2;
            if (offset != 0) offset = 0;
            else offset = cube_scale / 2;
            Double offs = Math.Round(offset * 10, 1, MidpointRounding.AwayFromZero);
            string str_offs = offs.ToString();
            offset = float.Parse(str_offs) / 10;

            Double offs1 = Math.Round(((-half_cubeCount + cubeCount - 1) * cube_scale + offset) * 10, 1, MidpointRounding.AwayFromZero);
            string str_offs1 = offs1.ToString();
            float offset1 = float.Parse(str_offs1) / 10;

            // タッチオブジェクト判定ループ
            // 画面タッチしたポジションのモンスターを基準に連鎖をチェック
            for (int j=0; j< cubeCount; j++) {
				for (int k=0; k< cubeCount; k++) {
					for (int i=0; i< cubeCount; i++) {
						
						if (sphere.spheres[j,k,i] != null) {
                        
                            monster_color m_color = monster.monster_instance.getMonster_color(sphere.spheres[j, k, i].tag);
                            // モンスターの位置情報セット
                            monster_Position = setObjectLocation(sphere.spheres[j, k, i]);
							// タッチオブジェクト判定
                            // タッチされたモンスタのオブジェクトを抽出
							if (monster_Position.y == obj_Position.y
							    && (monster_Position.x == obj_Position.x 
							    && monster_Position.z == obj_Position.z)) {

                                // ラストカラーモンスタフラグオフ　このフラグがオンの場合、モンスタ落下待機時間が速くなる
                                gravityLastMonster = false;
                                
                                // 以下の処理実行後脱ける
                                // monster in touch cube
                                // タッチされた位置より連鎖条件に合致するモンスターオブジェクトをチェック
                                checkMonsterChain(monster_Position, offset1, m_color);
                                
                                // touch position obj hit
                                // タッチされたモンスター
                                chain_monster = new GameObject[cubeCount * cubeCount * cubeCount * 20];

                                // タッチされたモンスターを基準に抽出された連鎖オブジェクトをチェック＆セット
                                if (setMonsterChainObect(m_color)) {
                                     // 連鎖あり！！
                                     // タッチ位置以外の抽出された連鎖モンスタの連鎖チェック
                                    int iii = 0;
                                    do
                                    {
                                        // チェックするモンスターの位置情報セット
                                        if (!checkChainMonsterDuplicate(chain_monster[iii], iii)) {
                                            YX_lineobjCount = 0;
                                            YZ_lineobjCount = 0;
                                            XY_lineobjCount = 0;
                                            XZ_lineobjCount = 0;
                                            ZY_lineobjCount = 0;
                                            ZX_lineobjCount = 0;
                                            monster_Position = setObjectLocation(chain_monster[iii]);
                                            // タッチ以外で抽出されたモンスターの連鎖もチェックし有れば chain_monsterにせっとする
                                            checkMonsterChain(monster_Position, offset1, m_color);
                                            setMonsterChainObect(m_color);
                                        }
                                        iii++;
                                        //Debug.Log("iii = " + iii);
                                        //Debug.Log("chain_count = " + chain_count);
                                    }
                                    while (iii < chain_count);

                                    // モンスターカラー設定　 連鎖発生！！
                                    for (int i1 = 0; i1 < chain_count; i1++)
                                    {
                                        monster_color m2_color = monster.monster_instance.getMonster_color(chain_monster[i1].tag);
                                        if (m_color == m2_color)
                                        {
                                            // changeMonster_colorで残り同一カラーモンスターの数をセットしている
                                            monster.monster_instance.changeMonster_color(chain_monster[i1].tag);
                                        }
                                    }
									// 連鎖ライン数チェック chainExplosionLineCountが実際の連鎖ライン本数となる
									// 連鎖ライン数はエフェクトオブジェクト個数を２で割った数　奇数時の余りは切り捨て
									int w_linecount = effect_obj_count / 2;
                                    chainExplosionLineCount = w_linecount;
                                    int p = sphere.gamePointADD(w_linecount);
                                    chainExplosionPoint += p;
									// 連鎖時の落下テンポゲージ減ボーナススイッチセット　swChangeTempo＝０の時は、何もされない
									canvasPanel.swChangeTempo = w_linecount;
                                    canvasPanel.chain_1_count++;
                                    
                                    //各カラー連鎖条件クリア時の処理
                                    int colorLineCount = monster.monster_instance.getChainExplosionLineCount(m_color);
									colorLineCount -= chainExplosionLineCount;
                                    if (colorLineCount < 0) colorLineCount = 0;
									monster.monster_instance.setMonsterChainExplosionLineCount(m_color,colorLineCount);

									if (colorLineCount <= 0) {

										// カラー別連鎖ライン数０で同一の連鎖以外の残りモンスターカラーを次のモンスターカラーに変更
										// キューブインしているモンスターは連鎖オブジェクトに追加して爆破させキューブから消す
										for (int jj=0; jj< cubeCount; jj++) {
											for (int kk=0; kk< cubeCount; kk++) {
												for (int ii=0; ii< cubeCount; ii++) {

													if (sphere.spheres[jj,kk,ii] != null) {
														monster_color color = monster.monster_instance.getMonster_color(sphere.spheres[jj,kk,ii].tag);
														if (color == m_color) {
															// モンスターキューブイン？
															if (monster.monster_instance.getMonster_IOstatus(sphere.spheres[jj,kk,ii].tag)) {
                                                                if (chain_count > 0)
                                                                {
                                                                    chain_monster[chain_count] = sphere.spheres[jj, kk, ii];
                                                                    setChainExplosionEffect(chain_monster[chain_count]);
                                                                    chain_count++;
                                                                }
															}
															// 残りモンスターカラー変更
															monster.monster_instance.changeMonster_color(sphere.spheres[jj,kk,ii].tag);
														}
													}
												}
											}
										}
                                        // ランク別連鎖オールクリア後のホワイトモンスター落下テンポをハイスピードにする
                                        if (monster.monster_instance.Get_monsterColorLastcheck()) { 
                                            // ランク最後の連鎖無しモンスターの場合、落下待機時間を highTempoTime とする counterソース内、update()でwaittimeリセット時にセットされる
                                            gravity_Time = highTempoTime;
                                            gravityLastMonster = true;
                                        }
                                    }

                                    chain_explosion = true;

									setChainExplosionTouchEffect(sphere.spheres[j,k,i], m_color);
									setChainExplosionStarEffect(m_color);
									chainExplosioncolor = m_color;
								}
								if (chain_explosion) chain_explosion_timer = 1.8f;
                                
                                YX_lineobjCount = 0;
                                YZ_lineobjCount = 0;
                                XY_lineobjCount = 0;
                                XZ_lineobjCount = 0;
                                ZY_lineobjCount = 0;
                                ZX_lineobjCount = 0;
                                // 連鎖関連データセット
                                setChainExplosionDataItem();

                                // TODO: 連鎖 テスト　連鎖カウント
                                //Debug.Log("chainExplosionLineCount = " + chainExplosionLineCount);
                                return;
							}
						}
					}
				}
			}
		}
		/* 連鎖関連　メソッド群　*/

		// 連鎖関連データ及び連鎖取得アイテム数のセット処理
		public const int bounsAdd_Cube4 = 2;
		public const int bounsAdd_Cube5 = 4;
		public static void setChainExplosionDataItem()
        {
			// 累計連鎖数加算
			chainExplosionLineTotalCount += chainExplosionLineCount;
			// プレー中連鎖数加算　プレー開始時、reset_chainExplosionCounter() 内で０リセット
			chainExplosionLinePlayCount += chainExplosionLineCount;
			// プレー中の最大連鎖数チェック＆保存　プレー開始時、reset_chainExplosionCounter() 内で０リセット
			if (chainExplosionLinePlayMAX < chainExplosionLineCount)
            {
				chainExplosionLinePlayMAX = chainExplosionLineCount;
			}
			// シルバーアイテム取得チェック＆ゴールドアイテム加算処理
			//int w_juelyitem,w_golditem,w_silveritem;
			// 連鎖２ライン以上でアイテムゲット
			if (chainExplosionLineCount > 1) {
				playGetSilverItemCount += chainExplosionLineCount;
				switch (emitter.cubeCount)
				{
					case 4:
						playGetSilverItemCount += bounsAdd_Cube4;
						break;
					case 5:
						playGetSilverItemCount += bounsAdd_Cube5;
						break;
				}
				/*
				w_golditem = Math.DivRem(silverItemCount, 10, out w_silveritem);
				silverItemCount = w_silveritem;
				goldItemCount += w_golditem;
				w_juelyitem = Math.DivRem(goldItemCount, 10, out w_golditem);
				goldItemCount = w_golditem;
				juelyItem1Cuont += w_juelyitem;
				*/
			}
			// 連鎖取得アイテム表示処理
			//canvasPanel.changeChainExplosionbItem = true;
		}

		static int center = 0;
		static int centerSideCenter = 0;
		static int centerCorner = 0;
		static int sideCenter = 0;
		static int corner = 0;
		// カラー別モンスターポジショングループの各個数取得
		static void getMonsterColorPositionGroupCount(monster_color m_color) {
			int u_level = (int)cubersFile.now_play_stage / emitter.chainExplosion_userLeve;
			if (u_level == 1) {
				center = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCenterGroup);
				sideCenter = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionSideCenterGroup);
				corner = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCornerGroup);
			}
			else if (u_level == 2) {
				center = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCenterGroup);
				sideCenter = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionSideCenterGroup);
				corner = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCornerGroup);
			}
			else {
				// ５＊５cube
				center = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCenterGroup);
				centerSideCenter = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCenterSideCenterGroup5);
				centerCorner = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCenterCornerGroup5);
				sideCenter = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionSideCenterGroup);
				corner = monster.monster_instance.getMonsterPositionGroupCount(m_color,monsterPositionCornerGroup);
			}
		}
		// chaon Explosion monsterpositiongroup count check 
		// 連鎖時、モンスターの数が足りなくなりカラー単位の連鎖が出来ないモンスターが発生する為、モンスターをカラーチェンジしないでそのまま残すかチェックする
		static void checkChainExplosionMonsterColorChange(monster_color m_color) {
			int u_level = (int)cubersFile.now_play_stage / emitter.chainExplosion_userLeve;
			if (u_level == 1) {
				// ３＊３
				if (center * 2 > sideCenter) {
					// center * 2よりsidecenter個数が少ない場合、center * 2と同じになる様 sidecenterモンスターのカラーを連鎖カラーに戻す
					int count = center * 2 - sideCenter;
					monster.monster_instance.resetMonster_color(m_color, monsterPositionSideCenterGroup, count);
				}
				int mod = corner % 2;
				if (mod != 0) {
					monster.monster_instance.resetMonster_color(m_color, monsterPositionCornerGroup, 1);
				}
			}
			else if (u_level == 2) {
				// ４＊４
				int mod = center % 2;
				if (mod != 0) {
					// center個数が２の倍数でなくなる場合、１centerモンスターのカラーチェンジをしない。（２の倍数とする）
					int count = mod;
					monster.monster_instance.resetMonster_color(m_color, monsterPositionCenterGroup, count);
				}
				if (center > sideCenter) {
					// centerよりsidecenter個数が少ない場合、centerと同じになる様 sidecenterモンスターのカラーを連鎖カラーに戻す
					int count = center - sideCenter;
					monster.monster_instance.resetMonster_color(m_color, monsterPositionSideCenterGroup, count);
				}
				int mod1 = corner % 2;
				if (mod1 != 0) {
					monster.monster_instance.resetMonster_color(m_color, monsterPositionCornerGroup, 1);
				}
			}
			else {
				// ５＊５
				int mod = center % 3;
				if (mod != 0) {
					// center個数が3の倍数でなくなる場合、１centerモンスターのカラーチェンジをしない。（3の倍数とする）
					if (mod == 1) {
						int mod1 = centerSideCenter % 2;
						if (mod1 != 0) {
							monster.monster_instance.resetMonster_color(m_color, monsterPositionCenterSideCenterGroup5, 1);
						}
						int mod2 = centerCorner % 2;
						if (mod2 != 0) {
							monster.monster_instance.resetMonster_color(m_color, monsterPositionCenterCornerGroup5, 1);
						}
					}
					if (mod == 2) {
						int mod1 = centerSideCenter % 2;
						if (mod1 != 0) {
							monster.monster_instance.resetMonster_color(m_color, monsterPositionCenterSideCenterGroup5, 1);
						}
						int mod2 = centerCorner % 2;
						if (mod2 != 0) {
							monster.monster_instance.resetMonster_color(m_color, monsterPositionCenterCornerGroup5, 1);
						}
					}
				}
				if (center / 3 * 2 > sideCenter) {
					// center / 3 * 2よりsidecenter個数が少ない場合、centerと同じになる様 sidecenterモンスターのカラーを連鎖カラーに戻す
					int count = center / 3 * 2 - sideCenter;
					monster.monster_instance.resetMonster_color(m_color, monsterPositionSideCenterGroup, count);
				}
				int mod3 = corner % 2;
				if (mod3 != 0) {
					monster.monster_instance.resetMonster_color(m_color, monsterPositionCornerGroup, 1);
				}
			}
		}
		// set chain effect
		static void setChainExplosionEffect(GameObject obj) {

			Vector3 effect_position = obj.transform.position;
			effect_position.y += 0.5f;
			// 設定済みエフェクトチェック
			for (int i = 0; i < effect_obj_count; i++) {
				Vector3 ef_position = effect_obj[i].transform.position;
				// 設定済みならそのまま戻る
				if (effect_position == ef_position) {
					return;
				}
			}
			if (effect_obj[effect_obj_count] != null) {
				Destroy(effect_obj[effect_obj_count]);
			}
			effect_obj[effect_obj_count] = (GameObject)Instantiate(s_explosion2, new Vector3(s_explosion2.transform.position.x, s_explosion2.transform.position.y, s_explosion2.transform.position.z), Quaternion.identity);
			effect_obj[effect_obj_count].transform.position = effect_position;

			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			monster_color color;
			Color chainExplosion_color;
			if (mod != 0) {
				color = monster_color.noColor_monster;
			} else {
				color = monster.monster_instance.getMonster_color(obj.tag);
			}
			switch (color) {
			case monster_color.blue_monster:
				chainExplosion_color = new Color(0.09f, 0.27f, 1.0f, 1.0f);
				break;
			case monster_color.green_monster:
				chainExplosion_color = new Color(0.24f, 1.0f, 0.31f, 1.0f);
				break;
			case monster_color.purple_monster:
				chainExplosion_color = new Color(0.64f, 0.0f, 1.0f, 0.94f);
				break;
			case monster_color.orange_monster:
				chainExplosion_color = new Color(0.74f, 0.32f, 0.06f, 1.0f);
				break;
			case monster_color.red_monster:
				chainExplosion_color = new Color(1.0f, 0.1f, 0.1f, 1.0f);
				break;
			case monster_color.yellow_monster:
				chainExplosion_color = new Color(0.95f, 1.0f, 0.58f, 1.0f);
				break;
			default:
				chainExplosion_color = new Color(0.61f, 0.58f, 0.67f, 1.0f);
				break;
			}
			var delayTime = 0.2f;
			GameObject obj1 = effect_obj[effect_obj_count].transform.Find("ring1").gameObject;
			var main = obj1.GetComponent<ParticleSystem>().main;
			main.startDelay = delayTime;
			GameObject obj2 = obj1.transform.Find("par1").gameObject;
			var main1 = obj2.GetComponent<ParticleSystem>().main;
			main1.startColor = chainExplosion_color;
			main1.startDelay = delayTime;
			GameObject obj3 = obj1.transform.Find("glitter1").gameObject;
			var main2 = obj3.GetComponent<ParticleSystem>().main;
			main2.startColor = chainExplosion_color;
			main2.startDelay = delayTime;
			GameObject obj4 = obj1.transform.Find("glitter2").gameObject;
			var main3 = obj4.GetComponent<ParticleSystem>().main;
			main3.startColor = chainExplosion_color;
			main3.startDelay = delayTime;
			GameObject obj5 = obj1.transform.Find("par3").gameObject;
			var main4 = obj5.GetComponent<ParticleSystem>().main;
			main4.startColor = chainExplosion_color;
			main4.startDelay = delayTime;
			GameObject obj6 = obj1.transform.Find("ring2").gameObject;
			var main5 = obj6.GetComponent<ParticleSystem>().main;
			main5.startColor = chainExplosion_color;
			main5.startDelay = delayTime;

			Singleton<SoundPlayer>.instance.playSE_2( "bomb004" ,0);

			effect_obj_count++;

		}


		// 連鎖タッチ部エフェクト処理
		static void setChainExplosionTouchEffect(GameObject obj, monster_color color) {

			Vector3 effect_position = obj.transform.position;
			effect_position.y += 0.5f;
			// 設定済みエフェクトチェック
			if (touchEffect_obj != null) {
				Vector3 ef_position = touchEffect_obj.transform.position;
				// 設定済みならそのまま戻る
				if (effect_position == ef_position) {
					return;
				}
			}
			if (touchEffect_obj != null) {
				Destroy(touchEffect_obj);
			}
			touchEffect_obj = (GameObject)Instantiate(s_touchChainExplosionEffect, new Vector3(s_touchChainExplosionEffect.transform.position.x, s_touchChainExplosionEffect.transform.position.y, s_touchChainExplosionEffect.transform.position.z), Quaternion.identity);
			touchEffect_obj.transform.position = effect_position;

		}

		// 連鎖モンスターカウントスターアニメーション
		static void setChainExplosionStarEffect(monster_color color) {

			canvasPanel.setchainExplosionStarEffectPosition(color);

		}

		// 連鎖モンスターカウントシュートエフェクト
		static void setChainExplosionShootEffect(GameObject obj, monster_color color) {

			Vector3 effect_position = obj.transform.position;
			effect_position.y += 0.5f;
			// 設定済みエフェクトチェック
			if (shootEffect_obj != null) {
				Vector3 ef_position = shootEffect_obj.transform.position;
				// 設定済みならそのまま戻る
				if (effect_position == ef_position) {
					return;
				}
			}
			if (shootEffect_obj != null) {
				Destroy(shootEffect_obj);
			}
			shootEffect_obj = (GameObject)Instantiate(s_shootChainExplosionEffect, new Vector3(s_shootChainExplosionEffect.transform.position.x, s_shootChainExplosionEffect.transform.position.y, s_shootChainExplosionEffect.transform.position.z), Quaternion.identity);
			shootEffect_obj.transform.position = effect_position;

			monsterCounterPosition = new Vector3(0.0f, 0.0f, 0.0f);

			switch (color) {
			case monster_color.blue_monster:
				monsterCounterPosition = canvasPanel.blueMonsterCounterPosition;
				break;
			case monster_color.green_monster:
				monsterCounterPosition = canvasPanel.greenMonsterCounterPosition;
				break;
			case monster_color.purple_monster:
				monsterCounterPosition = canvasPanel.purpleMonsterCounterPosition;
				break;
			case monster_color.orange_monster:
//				monsterCounterPosition = canvasPanel.orangeMonsterCounterPosition;
				break;
			case monster_color.red_monster:
				monsterCounterPosition = canvasPanel.redMonsterCounterPosition;
				break;
			case monster_color.yellow_monster:
				monsterCounterPosition = canvasPanel.yellowMonsterCounterPosition;
				break;
			default:
				break;
			}
			monsterCounterPosition.y += 50;
			monsterCounterPosition.x += 50;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(monsterCounterPosition - Camera.main.transform.forward * camera_basePosition);

			var seq = DOTween.Sequence();
			seq.Append(shootEffect_obj.transform.DOMove(worldPos, 1.0f).SetDelay(0.1f));
			seq.Append(shootEffect_obj.transform.DOScale(new Vector3(2.1f, 2.1f), 1.1f));

		}

		// target cube reset
		void cube_reset(GameObject obj) {

			obj.transform.root.tag = "cube_empty";
			cube_material_reset(obj);
		}
		// target cube material reset
		void cube_material_reset(GameObject obj) {
			
			GameObject child1 = obj.transform.Find("Cube1").gameObject;
			child1.GetComponent<Renderer>().material = cube_m;
            GameObject child2 = obj.transform.Find("Cube2").gameObject;
			child2.GetComponent<Renderer>().material = cube_m;
            GameObject child3 = obj.transform.Find("Cube3").gameObject;
			child3.GetComponent<Renderer>().material = cube_m;
            GameObject child4 = obj.transform.Find("Cube4").gameObject;
			child4.GetComponent<Renderer>().material = cube_m;
            GameObject child5 = obj.transform.Find("Cube5").gameObject;
			child5.GetComponent<Renderer>().material = cube_m;
            GameObject child6 = obj.transform.Find("Cube6").gameObject;
			child6.GetComponent<Renderer>().material = cube_m;
        }
        // monster reset
        void monster_reset(GameObject obj) {

			// IOStatus true == IN
			if (!monster.monster_instance.getMonster_IOstatus(obj.transform.tag)) return;

			monster.monster_instance.setMonster_IOstatus(obj.tag, false);
			sphere.now_sphere_count--;
			sphere.monster_reset(obj);
		}
		// monster position cube search
		GameObject searchCubeInMonster(Vector3 monsterPosition) {

			Double wy = Math.Round(monsterPosition.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
			monster_Position.y = float.Parse(str_y)/10;
			Double wx = Math.Round(monsterPosition.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			monster_Position.x = float.Parse(str_x)/10;
			Double wz = Math.Round(monsterPosition.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			monster_Position.z = float.Parse(str_z)/10;

			GameObject cube_obj;
			for (int j=0; j< cubeCount; j++) {
				for (int k=0; k< cubeCount; k++) {
					for (int i=0; i< cubeCount; i++) {
						
						if (cubes[j,k,i] != null) {

							cube_obj = cubes[j,k,i];
                               cube_Position = setObjectLocation(cube_obj);

							if (monster_Position.y == cube_Position.y
							    && (monster_Position.x == cube_Position.x 
							    && monster_Position.z == cube_Position.z)) {
								return cube_obj;
							}
						}
					}
				}
			}
			return null;
		}
		// cube roteto guid off
		public static void touchcube_guid_OFF() {
			
			for (int j=0; j< cubeCount; j++) {
				for (int k=0; k< cubeCount; k++) {
					for (int i=0; i< cubeCount; i++) {
						
						if (cubes[j,k,i] != null) {
							
							if ((j > 0 && j < cubeCount - 1) && (k > 0 && k < cubeCount - 1) && (i > 0 && i < cubeCount - 1)) {
							}
							else { 
								
								if (cubes[j,k,i].transform.root.tag == "cube_empty") {
									
									GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
									child1.GetComponent<Renderer>().material = cube_m;
									GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
									child2.GetComponent<Renderer>().material = cube_m;
									GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
									child3.GetComponent<Renderer>().material = cube_m;
									GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
									child4.GetComponent<Renderer>().material = cube_m;
									GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
									child5.GetComponent<Renderer>().material = cube_m;
									GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
									child6.GetComponent<Renderer>().material = cube_m;
								}
								else {
									
									GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
									child1.GetComponent<Renderer>().material = c_cube_m;
									GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
									child2.GetComponent<Renderer>().material = c_cube_m;
									GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
									child3.GetComponent<Renderer>().material = c_cube_m;
									GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
									child4.GetComponent<Renderer>().material = c_cube_m;
									GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
									child5.GetComponent<Renderer>().material = c_cube_m;
									GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
									child6.GetComponent<Renderer>().material = c_cube_m;
								}
							}
						}
					}
				}
			}
		}
		

		const int time_keta = 2;

		public static Vector3 offset;
        // *_rotate -> 0=false 1 〜 98 = cubePosition 99 = all
         public static int wangle;
        public static int turn_angle;
        public static bool left_up_rotate;
		public static bool left_down_rotate;
		public static bool right_up_rotate;
		public static bool right_down_rotate;
		public static bool left_rotate;
		public static bool right_rotate;
		public static float left_turn;
		public static float right_turn;
		public static float left_up_turn;
		public static float right_up_turn;
		public static float left_down_turn;
		public static float right_down_turn;

		public static bool turn_move;
         public static bool turn_end;
         public static bool material_ck;
		public static bool game_complete;
		public static bool emptyCubePosition = false;

		public static BGM_State BGMstate;
		private static bool sw = false;
//		private static bool sw_sphere = false;
		public static float pause_timer = PAUSETIME;
		public static float delay_timer = 5.0f;
		public static float updown_timer = 1.0f;
		// Update is called once per frame

		void Update () {

			// start処理は、sphereのstart_gameフラグによる呼び出しのgame_start()でcube処理もリセットされる
			//			if (start_game && init_game) {
//
////				make_cube();
//
//				start_game = false;
//				init_game = false;
//			}
//
//			if (init_game) return;

			// cubersfile load/save check
//			switch(swCubersfile) {
//			case 1:
//				GetComponent<cubersFile>().load_gameEncryptionData();
//				swCubersfile = 0;
//				break;
//			case 2:
//				GetComponent<cubersFile>().save_gameEncryptionData();
//				swCubersfile = 0;
//				break;
//			case 3:
//				GetComponent<cubersFile>().init_gameEncryptionData();
//				swCubersfile = 0;
//				break;
//			}

			// game complete check
			if (game_complete) {
				game_complete_cube_proc();
				game_complete = false;
			}
			else {
				//  turn ON
				if (turn_move && !game_complete) {
                    turn_check();
                }

				if (!turn_move && emptyCubePosition) {
					emptyCubePosition = false;

					setEmptyCubePosition();
				} 

				if (turn_move && !material_ck) {
					material_ck = true;
					match_check();
				}
			}	

			// floor up/down
			if (sw_floorUpDown) {

				updown_timer -= Time.deltaTime;
				int k = time_keta;
				string st = @"D" + k.ToString();
				int val = (int)updown_timer;
				string str = val.ToString(st);
				
				if (int.Parse(str) <= 0) {
                    sw_floorUpDown = false;
					updown_timer = nextDownWaitTimer;  // 落下後、次のモンスター落下待機表示までの待ち時間
					for (int jj=0; jj<cubeCount; jj++) {
						for (int ii=0; ii<cubeCount; ii++) {
							guid_floor[jj,ii].gameObject.SetActive(true);
//							Vector3 scale = guid_floor[jj,ii].transform.localScale;
//							scale.x = 0.1f;
//							scale.y = 0.1f;
//							scale.z = 0.1f;
//							guid_floor[jj,ii].transform.localScale = scale;
						}
					}
				}
				else {
					for (int jj=0; jj<cubeCount; jj++) {
						for (int ii=0; ii<cubeCount; ii++) {
							guid_floor[jj,ii].gameObject.SetActive(false);
//							Vector3 scale = guid_floor[jj,ii].transform.localScale;
//							scale.x -= 0.002f;
//							scale.y -= 0.002f;
//							scale.z -= 0.002f;
//							guid_floor[jj,ii].transform.localScale = scale;
						}
					}
				}

			}

			// Pause floor fadeout/in
			if (sw_pause && !sw_stop) {
				float alp = Mathf.PingPong(Time.time * 2.0f, 1.0f);
				for (int jj=0; jj<cubeCount; jj++) {
					for (int ii=0; ii<cubeCount; ii++) {
						guid_floor [jj,ii].transform.gameObject.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(alp,alp,alp));
					}
				}
				int k = time_keta;
				string st = @"D" + k.ToString();
				int val = (int)pause_timer;
				string str = val.ToString(st);
                pause_timer -= Time.deltaTime;

                if (int.Parse(str) <= 0) {
                    sphere.sw_sphere = true;
					sw_Gravity = true;
					canvasPanel.pauseON = false;
					BGMstate = emitter.BGM_State.play;
					sw_pause = false;
    				}
        		}

                // delay ON?
                if (sw_delay && delay_obj != null) {

				// circle scale down timer
				delay_timer -= Time.deltaTime;
				int k = time_keta;
				string st = @"D" + k.ToString();
				int val = (int)delay_timer;
				string str = val.ToString(st);
				
				if (int.Parse(str) < 0) {
					// circle scale down
					Vector3 scale = delay_obj.transform.localScale;
					scale.x -= 0.01f;
					scale.z -= 0.01f;
					delay_obj.transform.localScale = scale;
				}
			}
			// Explosion effect reset cheak
			if (effect_explosion) {

				effect_Explosion_timer -= Time.deltaTime;
				int k = time_keta;
				string st = @"D" + k.ToString();
				int val = (int)effect_Explosion_timer;
				string str = val.ToString(st);

				if (int.Parse(str) < 0) {
					int ii = effect_explosion_obj.Length;
					for (int i = 0; i < ii; i++) {
						if (effect_explosion_obj[i] != null) {
//							GameObject wobj = effect_explosion_obj[i];
//							Material mat = wobj.transform.gameObject.GetComponent<Renderer>().material;
//							DestroyImmediate(mat);
							Destroy(effect_explosion_obj[i]);
							effect_explosion_obj[i] = null;
						}
					}
					effect_explosion = false;
				}
			}
			// chain Explosion reset cheack
			if (chain_explosion) {

				if (chain_explosion_timer == -1) {

					canvasPanel.monsterColor = false;
					canvasPanel.resetMonsterColor = true;
					// Explosion effect clear
					int ii = effect_obj.Length;
					for (int i = 0; i < ii; i++) {
						if (effect_obj[i] != null) {
//							GameObject wobj = effect_obj[i];
//							Material mat = wobj.transform.gameObject.GetComponent<Renderer>().material;
//							DestroyImmediate(mat);
							Destroy(effect_obj[i]);
							effect_obj[i] = null;
						}
					}
					Destroy(touchEffect_obj);
					touchEffect_obj = null;
					Destroy(shootEffect_obj);
					shootEffect_obj = null;

					effect_obj_count = 0;
					chain_explosion = false;
					chain_explosion_timer = 1.8f;
					sphere.hitpointcount = 0;
					chainExplosionPoint = 0;

				}
				else {
//					// モンスターカラーカウント&強調表示表示ON
//					canvasPanel.monsterColor = true;


					chain_explosion_timer -= Time.deltaTime;
//					int k = time_keta;
//					string st = @"D" + k.ToString();
//					int val = (int)chain_explosion_timer;
//					string str = val.ToString(st);

					// monsterCounter Material High
					if (chain_explosion_timer > 0) {
//					if (chain_explosion_timer >= 0.5f && chain_explosion_timer < 1.0f) {
						// モンスターカラーカウント&強調表示表示ON
						canvasPanel.setChainExplosionMonsterColorCountView(chainExplosioncolor);
						canvasPanel.monsterColor = true;

						if (shootEffect_obj != null) {
							Vector3 worldPos = Camera.main.ScreenToWorldPoint(monsterCounterPosition - Camera.main.transform.forward * camera_basePosition);
							if (worldPos.y <= shootEffect_obj.transform.position.y) {
								canvasPanel.setChainExplosionMonsterColorCountEffect(chainExplosioncolor);
								Destroy(shootEffect_obj);
							}
						}
					}
					else {
						if (chain_explosion_timer <= -0.5f) {
							//						if (int.Parse(str) < 0) {

							// TODO:連鎖 追加
							sphere.chainExplosionLineCountDSP(chainExplosion_Touch_Position);
							canvasPanel canvasp = GetComponentInChildren<canvasPanel>();
							canvasp.chainInfoEffectDSP();
							//canvasPanel.canvasPanel_instance.chainInfoEffectDSP();Anima2D
							/*
							switch (chainExplosionLineCount) {
							case 1:
								sphere.chainExplosionLineCountDSP(chainExplosion_Touch_Position,1);
								break;
							case 2:
								sphere.chainExplosionLineCountDSP(chainExplosion_Touch_Position,2);
								break;
							case 3:
								sphere.chainExplosionLineCountDSP(chainExplosion_Touch_Position,3);
								break;
							}
							*/
							for (int i = 0; i < chain_count; i++)
                            {
                                GameObject obj = chain_monster[i];
                                if (obj == null) continue;
                                GameObject obj1 = searchCubeInMonster(obj.transform.position);
                                if (obj1 == null) continue;

                                monster_reset(chain_monster[i]);
                                cube_reset(obj1);
                            }
							chain_explosion_timer = -1;
						}
					}
				}
			}

			// BGMコントロール
			if ( player != null )
			switch (BGMstate) {
				case BGM_State.play:
					player.playBGM();
					player1.pauseBGM();
				break;

				case BGM_State.Stop:
					player.pauseBGM();
				break;

				case BGM_State.pit:
					player.pauseBGM();
					player1.playBGM((int)0);
					break;
				default:
					player.update();
				break;
			}

			// TODO:1-1-11 追加 新規設定画面処理の作成
			if (cubersFile.cubersfile_Loaded && initEmitter)
			{
				initEmitter = false;
				if (cubersFile.setting_BG_Animation == 0 && cubersFile.game_Sceen == 0)
				{
					// BGアニメーションオフ
					under_floor.GetComponent<SpinAnimation>().AnimationSpeed = 0;
				}
				else
				{
					// BGアニメーションオン
					under_floor.GetComponent<SpinAnimation>().AnimationSpeed = 5;
				}
			}
		}

		// empty cube position search&set
		void setEmptyCubePosition() {

			int setCubeCount = 0;

			float pluspos;
			float minuspos;
			int half_cubeCount = cubeCount/2;
			float offset = cubeCount%2;
			if (offset != 0) {
				Double wscale = Math.Round(cube_scale * 100, 1, MidpointRounding.AwayFromZero);
				Double pos = half_cubeCount * wscale;
				string str_p = pos.ToString();
				string str_m = (pos * -1).ToString();
				pluspos = float.Parse(str_p)/100;
				minuspos = float.Parse(str_m)/100;
//				offset = 0;
			}
			else { 
//				offset = cube_scale/2;
				Double wscale = Math.Round(cube_scale * 100, 1, MidpointRounding.AwayFromZero);
				Double woffset = wscale/2;
				Double pos = half_cubeCount * wscale;
				string str_p = (pos - woffset).ToString();
				string str_m = (-pos + woffset).ToString();
				pluspos = float.Parse(str_p)/100;
				minuspos = float.Parse(str_m)/100;
			}
			
			for (int j=0; j<cubeCount; j++) {
				for (int k=0; k<cubeCount; k++) {
					for (int i=0; i<cubeCount; i++) {

						if (cubes[j,k,i] != null) {
							if ((j > 0 && j < cubeCount - 1) && (k > 0 && k < cubeCount - 1) && (i > 0 && i < cubeCount - 1)) {
							}
							else { 

								if (cubes[j,k,i].transform.root.tag == "cube_empty") {

									Vector3 pos = cubes[j,k,i].transform.position;
									Double wx = Math.Round(pos.x * 10, 1, MidpointRounding.AwayFromZero);
									string str_x = wx.ToString();
									float p_x = float.Parse(str_x)/10;
									Double wy = Math.Round(pos.y * 10, 1, MidpointRounding.AwayFromZero);
									string str_y = wy.ToString();
									float p_y = float.Parse(str_y)/10;
									Double wz = Math.Round(pos.z * 10, 1, MidpointRounding.AwayFromZero);
									string str_z = wz.ToString();
									float p_z = float.Parse(str_z)/10;

//									Debug.Log("pluspos " + pluspos);
//									Debug.Log("minuspos " + minuspos);

									if(p_y < pluspos && p_y > minuspos) {
//										Debug.Log("p_x: " + p_x);
//										Debug.Log("p_y: " + p_y);
//										Debug.Log("p_z: " + p_z);
										if ((p_x >= pluspos || p_x <= minuspos)
										    && (p_z >= pluspos || p_z <= minuspos)) {
//											Debug.Log("p_xz: hit!!");
											empty_cube_position[setCubeCount] = pos;
											empty_cube_position[setCubeCount].x = pos.y;
											empty_cube_position[setCubeCount].y = half_cubeCount * cube_scale - offset;
											setCubeCount++;
										}
										else if (p_x < pluspos && p_x > minuspos) {
//											Debug.Log("p_x: hit!!");
											empty_cube_position[setCubeCount] = pos;
											empty_cube_position[setCubeCount].z = pos.y;
											empty_cube_position[setCubeCount].y = half_cubeCount * cube_scale - offset;
											setCubeCount++;
										}
										else if (p_z < pluspos && p_z > minuspos) {
//											Debug.Log("p_z: hit!!");
											empty_cube_position[setCubeCount] = pos;
											empty_cube_position[setCubeCount].x = pos.y;
											empty_cube_position[setCubeCount].y = half_cubeCount * cube_scale - offset;
											setCubeCount++;
										}
									}
									else {
//										Debug.Log("hold!!");
										empty_cube_position[setCubeCount] = pos;
										setCubeCount++;
									}
								}
							}
						}
					}
				}
			}
//			Debug.Log("setCubeCount: " + setCubeCount);
		}
  
		// delay particle
		public void circle_Delay() {

			Vector3 pos = guid_floor[0,0].transform.position;
			delay_obj = (GameObject)Instantiate (circle_delay, new Vector3 (0, pos.y + 1.0f, 0), Quaternion.identity);

		}
		public void delayObj_clear() {

			if (delay_obj != null) {
				Material mat = delay_obj.transform.gameObject.GetComponent<Renderer>().material;
				DestroyImmediate(mat);
				Destroy(delay_obj);
				delay_obj = null;
			}
		}

		// match check
		private void match_check() {

//			material_change();
		}

		// material change
		private void material_Allchange() {
			
			Shader shd;
			if (sw) {
				shd = Shader.Find("Mobile/Particles/Alpha Blended");
				//				shd = Shader.Find("Nature/Tree Creator Leaves");
				sw = false;
			} else {
				shd = Shader.Find("Mobile/Particles/Alpha Blended");
				//				shd = Shader.Find("Particles/Additive (Soft)");
				sw = true;
			}
			
			for (int j=0; j<cubeCount; j++) {
				for (int k=0; k<cubeCount; k++) {
					for (int i=0; i<cubeCount; i++) {
						
						GameObject child1 = cubes [j,k,i].transform.Find("Cube1").gameObject;
						child1.GetComponent<Renderer>().material.shader = shd;
						GameObject child2 = cubes [j,k,i].transform.Find("Cube2").gameObject;
						child2.GetComponent<Renderer>().material.shader = shd;
						GameObject child3 = cubes [j,k,i].transform.Find("Cube3").gameObject;
						child3.GetComponent<Renderer>().material.shader = shd;
						GameObject child4 = cubes [j,k,i].transform.Find("Cube4").gameObject;
						child4.GetComponent<Renderer>().material.shader = shd;
						GameObject child5 = cubes [j,k,i].transform.Find("Cube5").gameObject;
						child5.GetComponent<Renderer>().material.shader = shd;
						GameObject child6 = cubes [j,k,i].transform.Find("Cube6").gameObject;
						child6.GetComponent<Renderer>().material.shader = shd;
					}
				}
			}
		}

		//  cube clear
		void cube_clear() {

			if (cubes == null) return;
			int ii = 0;
			for (int j=0; j<before_cubeCount; j++) {
				for (int k=0; k<before_cubeCount; k++) {
					for (int i=0; i<before_cubeCount; i++) {
						ii++;
						if (cubes [j,k,i] != null) {
							destroyCubeMaterial(cubes [j,k,i]);
							Destroy(cubes [j,k,i]);
							cubes [j,k,i] = null;
						}
					}
				}
			}

		}
		// ゲームクリア処理
		void game_complete_cube_proc() {

			int ii = 0;
			effect_obj_count = 0;
			for (int j=0; j<cubeCount; j++) {
				for (int k=0; k<cubeCount; k++) {
					for (int i=0; i<cubeCount; i++) {

						ii++;
						if (cubes[j,k,i] != null) {

							GameObject obj = cubes[j,k,i].gameObject;

							if (effect_obj[effect_obj_count] != null) {
								// paerticleはMaterialがアタッチされていないのでオブジェだけDestory
								Destroy(effect_obj[effect_obj_count]);
							}
							effect_obj[effect_obj_count] = (GameObject)Instantiate(explosion1, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
							effect_obj_count++;

							Singleton<SoundPlayer>.instance.playSE_2( "bomb002" ,3);

							destroyCubeMaterial(cubes [j,k,i]);
							Destroy(cubes [j,k,i]);
							cubes [j,k,i] = null;

//							obj.GetComponent<Rigidbody>().isKinematic = false;
//							obj.GetComponent<Rigidbody>().useGravity = true;
							
						}
					}
				}
			}
		}
		// Cube Material Destory
		public void destroyCubeMaterial(GameObject obj) {
			
			GameObject child1 = obj.transform.Find("Cube1").gameObject;
			Material mat1 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat1);
			GameObject child2 = obj.transform.Find("Cube2").gameObject;
			Material mat2 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat2);
			GameObject child3 = obj.transform.Find("Cube3").gameObject;
			Material mat3 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat3);
			GameObject child4 = obj.transform.Find("Cube4").gameObject;
			Material mat4 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat4);
			GameObject child5 = obj.transform.Find("Cube5").gameObject;
			Material mat5 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat5);
			GameObject child6 = obj.transform.Find("Cube6").gameObject;
			Material mat6 = child1.transform.gameObject.GetComponent<Renderer>().material;
			DestroyImmediate(mat6);

		}
		// BGM Stop
		public void stop_BGM() {

			player.stopBGM(fadeOutTime);
//			Singleton<SoundPlayer>.instance.stopBGM( 0.5f );

		}

		// object turn check
		private void turn_check() {

			if (!sphere.now_gravity) {

				for (int j=0; j<cubeCount; j++) {
					for (int k=0; k<cubeCount; k++) {
						for (int i=0; i<cubeCount; i++) {
							// cube
							if ((j > 0 && j < cubeCount - 1) && (k > 0 && k < cubeCount - 1) && (i > 0 && i < cubeCount - 1)) {
							}
							else if(cubes[j,k,i] != null) {
								obj_rotate(cubes[j,k,i],0);
							}
							// sphere
							if(sphere.spheres[j,k,i] != null) {
								obj_rotate(sphere.spheres[j,k,i],1);
							}
						}
					}
				}
			}
            int befor_turn_angle = turn_angle;
            turn_angle += wangle;
            if (befor_turn_angle != turn_angle)
                Debug.Log("turn_angle = " + turn_angle);
            if (turn_angle >= 90 || turn_angle <= -90) {
				
				reset_cubeAngle();
			}

		}

		private void obj_rotate(GameObject obj,int sw) {

			int half_cubeCount = cubeCount/2;

			Double wy = Math.Round(obj.transform.position.y * 10, 1, MidpointRounding.AwayFromZero);
			string str_y = wy.ToString();
            float p_y = float.Parse(str_y) / 10;

			if (p_y > half_cubeCount * cube_scale + cube_scale) return; // 2.2f

			Double wx = Math.Round(obj.transform.position.x * 10, 1, MidpointRounding.AwayFromZero);
			string str_x = wx.ToString();
			float p_x = float.Parse(str_x)/10;
			Double wz = Math.Round(obj.transform.position.z * 10, 1, MidpointRounding.AwayFromZero);
			string str_z = wz.ToString();
			float p_z = float.Parse(str_z)/10;

			//Debug.Log("sw = "+ sw + "wangle = "+ wangle);
            // left 90 turn
            if (left_rotate || (p_y == left_turn)) {
				obj.transform.RotateAround(new Vector3 (0.0f, p_y, 0.0f), Vector3.up, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.up);
            }

            // right 90 turn
            if (right_rotate || (p_y == right_turn)) {
				obj.transform.RotateAround(new Vector3 (0.0f, p_y, 0.0f), Vector3.down, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.down);
            }


            // right up 90 rotate
            if (right_up_rotate || (p_x == right_up_turn)) {
				obj.transform.RotateAround(new Vector3 (p_x, 0.0f, 0.0f), Vector3.left, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.left);
            }

            // right down 90 rotate
            if (right_down_rotate || (p_x == right_down_turn)) {
				obj.transform.RotateAround(new Vector3 (p_x, 0.0f, 0.0f), Vector3.right, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.right);
            }

            // left up 90 rotate
            if (left_up_rotate || (p_z == left_up_turn)) {
				obj.transform.RotateAround(new Vector3 (0.0f, 0.0f, p_z), Vector3.forward, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.forward);
            }

            // left down 90 rotate
            if (left_down_rotate || (p_z == left_down_turn)) {
				obj.transform.RotateAround(new Vector3 (0.0f, 0.0f, p_z), Vector3.back, wangle);
				if (sw == 1) obj.transform.rotation = Quaternion.AngleAxis(-wangle,Vector3.back);
            }

        }

		public Texture button_base_2;
		void OnGUI() {
/*	
			// GUI.Button multietap Don't use  -> GUITexture & location check
			if (GUI.Button (new Rect(5, screen_height - button_height - 20, button_width, button_height),  "Gravity_Start")) {
				sw_Gravity = true;
			}

			if (GUI.Button (new Rect(screen_width - button_width - 5, screen_height - button_height - 20, button_width, button_height), "Gravity_Stop")) {
				sw_Gravity = false;
			}

*/			// sphere fall
//			if (GUI.Button (new Rect(screen_width/2 - button_width/2, screen_height - button_height - 20, button_width, button_height), "complete_chk")) {
//				GetComponent<sphere>().game_complete_proc();
//			}

		}


		// in:touch座標 x,y
		// out:cube y_position status
		public Canvas canvas;
		public int getCubeTouchPoint(Vector2 touchPosition) {

			int t_position = 0;

			for (int j=0; j<cubeCount; j++) {
				for (int k=0; k<cubeCount; k++) {
					for (int i=0; i<cubeCount; i++) {
						
						Vector3 scale = cubes[j,k,i].transform.localScale;
						// タッチ位置のCUBEビューポート座標取得 point Cubeがメインカメラのどこに表示されているかを取得
						Vector3 cubePosition = cubes[j,k,i].transform.position;
						Vector3 CubeViewportPoint = Camera.main.WorldToViewportPoint(cubePosition);

						RectTransform CanvasRect = canvas.GetComponent<RectTransform>();
						Vector2 CubeViewPortToCanvasPoint = new Vector2(
							(CubeViewportPoint.x*CanvasRect.sizeDelta.x),
							(CubeViewportPoint.y*CanvasRect.sizeDelta.y));
						if (touchPosition.y >= CubeViewPortToCanvasPoint.y && touchPosition.y <= CubeViewPortToCanvasPoint.y + scale.y) {
							Debug.Log("HIT!!");
						}
					}
				}
			}

			return t_position;

		}


	}
}

public class TagHelper : MonoBehaviour {
/*
	void Start () {
		AddTag("HogeTag01");
		AddTag("HogeTag02");
		AddTag("HogeTag03");
	}
	
	static void AddTag(string tagname) {
		UnityEngine.Object[] asset = AssetDatabase.LoadAllAssetsAtPath("ProjectSettings/TagManager.asset");
		if ((asset != null) && (asset.Length > 0)) {
			SerializedObject so = new SerializedObject(asset[0]);
			SerializedProperty tags = so.FindProperty("tags");
			
			for (int i = 0; i < tags.arraySize; ++i) {
				if (tags.GetArrayElementAtIndex(i).stringValue == tagname) {
					return;
				}
			}
			
			int index = tags.arraySize;
			tags.InsertArrayElementAtIndex(index);
			tags.GetArrayElementAtIndex(index).stringValue = tagname;
			so.ApplyModifiedProperties();
			so.Update();
		}
	}
	
	void Update () {
	}
*/
}
