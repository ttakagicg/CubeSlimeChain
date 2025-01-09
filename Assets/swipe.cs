using UnityEngine;
using System;
using System.Collections;
using UnityEngine.UI;
using nm_emitter;
using nm_sphere;
using nm_counter;
using nm_canvasPanel;
using nm_monster;
using nm_cubersFile;

public class swipe : MonoBehaviour {

    public bool flgSwip = false;
	//スワイプ判定の最低距離
	public float minSwipeDistX;
	public float minSwipeDistY;
	//実際にスワイプした距離
	private float swipeDistX;
	private float swipeDistY;
    //前回にスワイプした距離
    private float beforeSwipeDistX;
    private float beforeSwipeDistY;
    //方向判定に使うSign値
    float SignValueX;
	float SignValueY;
	//タッチしたポジション
	private Vector2 startPos;
	//タッチを移動したポジション
	private Vector2 movePos;
    //タッチを離したポジション
    private Vector2 endPos;
    //表示するテキスト
    public Text text;
	static int touchCube_X_Position;
	static int touchCube_Y_Position;
	static int touchCube_Z_Position;
	static float obj_X_Position;
	static float obj_Y_Position;
	static float obj_Z_Position;

	static float sphere_scale;
	static bool floor_touch;
	// 
	// Use this for initialization
	void Start () {

        floor_touch = false;
		sphere_scale = emitter.cube_scale;

		if (minSwipeDistX <= 0) {
			minSwipeDistX = 40 * sphere_scale;
		}
		if (minSwipeDistY <= 0) {
			minSwipeDistY = 40 * sphere_scale;
		}

	}
	
//	int speed = 300;
//	float cube_mass = 100;
	// Update is called once per frame
	void Update () {
	
		// ゲームエンド処理中？
		if (sphere.gameStatus_text != "") return;
        // モンスタ落下開始フラグオン？
        // モンスター落下中はキューブの回転を止める
        // 落下モンスタの本来落ちるべき位置がズレる問題を回避するため落下開始でキューブの回転を止める、もしくは90度移動を完了させる
        if (counter.timer >= emitter.nextDownWaitTimer - 1 && emitter.sw_floorUpDown) {
            emitter.turn_end = true;
            emitter.touchcube_guid_OFF();
            return;
        }

        //タッチされたら
        if (Input.touchCount > 0)
        {
            if (flgSwip) return;
            flgSwip = true;
            //タッチを取得
            Touch touch = Input.GetTouch(0);
            //Touch touch = Input.touches [0];
            //タッチフェーズによって場合分け
            switch (touch.phase) {
				
				//タッチ開始時
			case TouchPhase.Began:
                if (floor_touch || (emitter.turn_end && emitter.turn_move))
                {
                    //Debug.Log("!!!!!!!!!floor begin");
                    flgSwip = false;
                    emitter.touchcube_guid_OFF();
                    return;
                }

                startPos = touch.position;
				Ray ray = Camera.main.ScreenPointToRay(startPos);
				RaycastHit hit = new RaycastHit();
                if (!emitter.turn_end)
                {
                    emitter.wangle = 0;    // 1ターン　角度90度セット
                    emitter.turn_angle = 0;

                    setRotateMove();

                }
                // スワイプ移動方向チェックフラグオフ
                emitter.turn_move = false;
                emitter.turn_end = false;
                touchCube_X_Position = 0;
				touchCube_Y_Position = 0;
				touchCube_Z_Position = 0;
				obj_X_Position = 0;
				obj_Y_Position = 0;
				obj_Z_Position = 0;

                int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;

				if (Physics.Raycast(ray, out hit)){
                        //Debug.Log("hit!!!!!!!!!!");

                        GameObject obj = hit.collider.gameObject;
                        if (obj.transform.root.CompareTag("Untagged"))
                        {
                            break;
                        }
                        //					Debug.Log("gameObject:" + obj + " " + obj.transform.position.y);
                        // タッチがキューブか判定
                        if (obj.transform.root.tag == "cube_empty" || obj.transform.root.tag == "cube_close")
                        {

                            touchCube_X_Position = 1;
                            touchCube_Y_Position = 1;
                            touchCube_Z_Position = 1;

                            Double wy = Math.Round(obj.transform.position.y * 10, 1, MidpointRounding.AwayFromZero);
                            string str_y = wy.ToString();
                            obj_Y_Position = float.Parse(str_y) / 10;
                            Double wx = Math.Round(obj.transform.root.position.x * 10, 1, MidpointRounding.AwayFromZero);
                            string str_x = wx.ToString();
                            obj_X_Position = float.Parse(str_x) / 10;
                            Double wz = Math.Round(obj.transform.root.position.z * 10, 1, MidpointRounding.AwayFromZero);
                            string str_z = wz.ToString();
                            obj_Z_Position = float.Parse(str_z) / 10;

                            int cnt = emitter.cubeCount;
                            //					int c_int = cnt / 2;

                            //						Debug.Log(obj.transform.position.y + " " + cnt * sphere_scale + sphere_scale/2);
                            if ((emitter.cube_obj_scale / 2) + (sphere_scale / 2 * (cnt - 1)) <= obj_Y_Position)
                                touchCube_Y_Position = cnt + 1;

                            // cube roteto guid
                            emitter.touchcube_guid_ON(obj);
                            // chain Explosion chaeck
                            if (mod == 0)
                            {
                                //Debug.Log("monster_chain_explosion!!!!!!!!!!");
                                // 連鎖チェック
                                emitter.monster_chain_Explosion(obj);    // level 2、4、6 
                            }

                        }

                        else if (obj.transform.root.tag == "floor" || !monster.monster_instance.getMonster_IOstatus(obj.transform.root.tag))
                        {
                            // フロアータッチで落下
                            //floor_touch = true;
                            canvasPanel.isFloorTouch = true;
                        }
                    }

				break;

				//タッチ moved
			case TouchPhase.Moved:
                beforeSwipeDistX = swipeDistX;
                beforeSwipeDistY = swipeDistY;
                //タッチ移動ポジションをmovePosに代入
                movePos = new Vector2(touch.position.x, touch.position.y);
                //横方向判定
                //X方向にスワイプした距離を算出
                swipeDistX = (new Vector3(movePos.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                //縦方向判定
                //Y方向にスワイプした距離を算出
                swipeDistY = (new Vector3(0, movePos.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                //x座標の差分のサインを計算
                //xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                SignValueX = Mathf.Sign(movePos.x - startPos.x);
                //y座標の差分のサインを計算
                //yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                SignValueY = Mathf.Sign(movePos.y - startPos.y);

                if (!emitter.turn_move)
                {
                        if (swipeDistX > minSwipeDistX || swipeDistY > minSwipeDistY)
                    {
                        setRotateData();
                        emitter.turn_move = true;
                    }
                }
                else if (beforeSwipeDistX != swipeDistX || beforeSwipeDistY != swipeDistY)
                {
                    // 下記必要無し
                    //setRotateMove();
                }
                break;
				
				//タッチ終了時
			case TouchPhase.Ended:
                if (!emitter.turn_end && emitter.turn_move)
                {
                    emitter.turn_end = true;

                    //beforeSwipeDistX = swipeDistX;
                    //beforeSwipeDistY = swipeDistY;

                    ////タッチ移動ポジションをmovePosに代入
                    //movePos = new Vector2(touch.position.x, touch.position.y);
                    ////横方向判定
                    ////X方向にスワイプした距離を算出
                    //swipeDistX = (new Vector3(movePos.x, 0, 0) - new Vector3(startPos.x, 0, 0)).magnitude;
                    ////縦方向判定
                    ////Y方向にスワイプした距離を算出
                    //swipeDistY = (new Vector3(0, movePos.y, 0) - new Vector3(0, startPos.y, 0)).magnitude;
                    ////x座標の差分のサインを計算
                    ////xの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                    //SignValueX = Mathf.Sign(movePos.x - startPos.x);
                    ////y座標の差分のサインを計算
                    ////yの差分をとっているので絶対にサインの値は1(90度)か-1(270度)
                    //SignValueY = Mathf.Sign(movePos.y - startPos.y);

                    //setRotateMove();

                    startPos.x = 0;
                    startPos.y = 0;
                    movePos.x = 0;
                    movePos.y = 0;
                    endPos.x = 0;
                    endPos.y = 0;
                }
                // cube roteto guid off
                if (emitter.cubes != null) { 
                    emitter.touchcube_guid_OFF();
                }
                break;
			}
            flgSwip = false; 

        }
    }

    // 回転データ設定　(移動・エンド)
    // 回転時の角度を引き渡す　タッチからエンドまでの最大回転角度は90度
    // タッチ移動量に応じて回転角度を計算キューブの端から端までのサイズが９０度となる様に計算し、終了時は90度に足りない分の角度を引き渡す様にする
    // 角度にはプラスとマイナスがある　エンドを認識させるフラグと移動中フラグ２点を用意し、実際の回転はemitter内の obj_rotate()で行う
    private void setRotateData()
    {
        int cnt = emitter.cubeCount;

        // 1ターンで回る角度90度に対してそれを満たす移動距離で割るとスワイプ移動距離に応じて何度キューブが回転するか産出
        // 算出された角度をemitteのwangleに設定する
        float anglePerDistance = 90.0f / Screen.width; // スクリーンの幅の移動で90度回転

        // CUBE TOP Y surface
        if (touchCube_Y_Position == cnt + 1)
        {
            //右方向&上方向にスワイプしたとき
            if (SignValueX > 0 && SignValueY > 0)
            {
                left_up_roteto(touchCube_Z_Position);
            }
            //右方向&下方向にスワイプしたとき
            else if (SignValueX > 0 && SignValueY < 0)
            {
                right_down_roteto(touchCube_X_Position);
            }
            //左方向&上方向にスワイプしたとき
            else if (SignValueX < 0 && SignValueY > 0)
            {
                right_up_roteto(touchCube_X_Position);
            }
            //左方向&下方向にスワイプしたとき
            else if (SignValueX < 0 && SignValueY < 0)
            {
                left_down_roteto(touchCube_Z_Position);
            }
        }
        else if (swipeDistX > swipeDistY)
        {
            if (SignValueX > 0)
            {
                //右方向にスワイプしたとき
                right_roteto(touchCube_Y_Position);
                //                          Debug.Log("RightSwipe");
            }
            else if (SignValueX < 0)
            {
                //左方向にスワイプしたとき
                left_roteto(touchCube_Y_Position);
                //                          Debug.Log("LEFTSwipe");
            }
        }
        else
        {
            // cube Z or X surface
            if (SignValueY > 0)
            {
                //sin = 1
                //上方向にスワイプしたとき
                if (touchCube_X_Position == cnt + 1 || startPos.x <= Screen.width / 2)
                {
                    //                          if (touchCube_X_Position == cnt + 1 || touch.position.x <= Screen.width / 2) {
                    if (touchCube_Z_Position == cnt + 1) touchCube_Z_Position = 1;
                    left_up_roteto(touchCube_Z_Position);
                    //                              Debug.Log("UPSwipe-1 " + touchCube_Z_Position);
                }
                else if (touchCube_Z_Position == cnt + 1 || startPos.x > Screen.width / 2)
                {
                    //                          else if (touchCube_Z_Position == cnt + 1 || touch.position.x > Screen.width / 2) {
                    if (touchCube_X_Position == cnt + 1) touchCube_X_Position = 1;
                    right_up_roteto(touchCube_X_Position);
                    //                              Debug.Log("UPSwipe-2 " + touchCube_X_Position);
                }
                else
                {
                    //                              Debug.Log("UPSwipe");
                }
            }
            else if (SignValueY < 0)
            {
                //sin = -1
                //下方向にスワイプしたとき
                if (touchCube_X_Position == cnt + 1 || startPos.x <= Screen.width / 2)
                {
                    //                          if (touchCube_X_Position == cnt + 1 || touch.position.x <= Screen.width / 2) {
                    if (touchCube_Z_Position == cnt + 1) touchCube_Z_Position = 1;
                    left_down_roteto(touchCube_Z_Position);
                    //                              Debug.Log("DownSwipe-1 " + touchCube_Z_Position);
                }
                else if (touchCube_Z_Position == cnt + 1 || startPos.x > Screen.width / 2)
                {
                    //                          else if (touchCube_Z_Position == cnt + 1 || touch.position.x > Screen.width / 2) {
                    if (touchCube_X_Position == cnt + 1) touchCube_X_Position = 1;
                    right_down_roteto(touchCube_X_Position);
                    //                              Debug.Log("DownSwipe-2 " + touchCube_X_Position);
                }
                else
                {
                    //                              Debug.Log("DownSwipe");
                }
            }
        }

    }

    private void setRotateMove()
    {
        // emitter内のRotateAroundはフレーム更新毎に回転させる角度を渡す
        // 回転させた角度が90度になったらturn_end及びturn_moveをオフして回転を止める
        // turn_endをオフする　turn_end及びturn_moveがtrueの間はturn_check()及びobj_rotateは呼び続けられる
        // ６０フレームレートで５　３０フレームレートなら１０
        int w_distance = 5;
        // フレームレート３００で回転角(wangle)１を基準に設定する
        //float fps = 1f / Time.deltaTime;
        //Debug.Log("fps = " + fps);
        //w_distance = Mathf.RoundToInt(300.0f / fps);
        //if (w_distance <= 0) w_distance = 1;
        //if (w_distance >= 10) w_distance = 10;
        //int w_distance = 10;
        emitter.wangle = w_distance;
    }

    //右方向にスワイプしたとき
    private void  right_roteto(int touch_position) {

		if (emitter.turn_end) return;
		switch (touch_position) {
		case 0:
			emitter.right_rotate = true;
			emitter.right_turn = 999;
//										Debug.Log ("RIGHT all" + "swipe Y is" + SignValueX.ToString ());
			break;
		default :
            emitter.right_turn = obj_Y_Position;
//			Debug.Log ("RIGHT" + "swipe Y is" + SignValueX.ToString () + "  " + obj_Y_Position);
			break;
		}
	}

	//左方向にスワイプしたとき
	private void  left_roteto(int touch_position) {
		
		if (emitter.turn_end) return;
		switch (touch_position) {
		case 0:
			emitter.left_rotate = true;
			emitter.left_turn = 999;
//										Debug.Log ("LEFT" + "swipe Y is" + SignValueX.ToString ());
			break;
		default:
            emitter.left_turn = obj_Y_Position;
//			Debug.Log ("LEFT" + "swipe Y is" + SignValueX.ToString () + "  " + obj_Y_Position);
			break;
		}
		
	}

	// 上方向にスワイプしたとき
	private void right_up_roteto(int touch_position) {

		if (emitter.turn_end) return;
//		Debug.Log("turn start" + "  " + obj_X_Position);
		switch (touch_position) {
		case 0:
			emitter.right_up_rotate = true;
			emitter.right_up_turn = 999;
			break;
		default:
            emitter.right_up_turn = obj_X_Position;
//			Debug.Log ("RIGHT UP" + "swipe X is" + SignValueX.ToString ());
			break;
		}
	}
	//下方向にスワイプしたとき
	private void right_down_roteto(int touch_position) {
		
		if (emitter.turn_end) return;

		switch (touch_position) {
		case 0:
			emitter.right_down_rotate = true;
			emitter.right_down_turn = 999;
			break;
		default:
            emitter.right_down_turn = obj_X_Position;
//			Debug.Log ("RIGHT DOWN" + "swipe X is" + SignValueX.ToString ());
			break;
		}
	}
	// 上方向にスワイプしたとき
	private void left_up_roteto(int touch_position) {
		
		if (emitter.turn_end) return;
//		Debug.Log("turn start" + "  " + obj_Z_Position);

		switch (touch_position) {
		case 0:
			emitter.left_up_rotate = true;
			emitter.left_up_turn = 999;
			break;
		default:
            emitter.left_up_turn = obj_Z_Position;
//			Debug.Log ("LEFT UP" + "swipe Z is" + SignValueX.ToString ());
			break;
		}
	}
	//下方向にスワイプしたとき
	private void left_down_roteto(int touch_position) {
		
		if (emitter.turn_end) return;
		
		switch (touch_position) {
		case 0:
			emitter.left_down_rotate = true;
			emitter.left_down_turn = 999;
			break;
		default:
            emitter.left_down_turn = obj_Z_Position;
//			Debug.Log ("LEFT DOWN" + "swipe Z is" + SignValueX.ToString ());
			break;
		}
	}

}
