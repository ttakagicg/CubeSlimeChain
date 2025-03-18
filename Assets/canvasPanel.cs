using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using System;
using System.Collections;
using nm_emitter;
using nm_sphere;
using nm_counter;
using nm_cubersFile;
using nm_monster;
using DG.Tweening;
using TMPro;
//using GoogleMobileAds.Api;
using FSP_Samples;

using nm_RankBadge;

namespace nm_canvasPanel
{


    public class canvasPanel : MonoBehaviour {

        public static canvasPanel canvasPanel_instance;

        public static readonly int PSUSE_BUTTON_X = 275;
		public static readonly int PSUSE_BUTTON_Y = 20;
		public static readonly int GAMEPOINT_WIDTH = 180;
		public static readonly int GAMEPOINT_LABEL_WIDTH = 80;
		public static readonly int PLAYTIME_WIDTH = 80;

		const float button_height = 35;
		const float button_width = 40;
		const int button_count = 4;

		public Canvas canvas;

        public emitter Emitter;
        public sphere Sphere;

        public Image screen_Mask;
        private float do_duration = 0.5f;
        public static bool isFloorTouch = false;

		private static float screen_width_per;
		private static float screen_height_per;

		public Image header_BG;
        public Image footer_BG;
        public Image safeareaout_header_BG;
        public Image safeareaout_footer_BG;
		//public static Image s_mainMenu_field;
		public Image left_header;
		public Image center_header;
		public Image right_header;
		public Image center_View;
        public Vector3 center_View_orgSize;
        public static Image s_center_View;
		public Image gamecount;
		public Image item_View;
        public Image setting_View;
		public Image slimCard_View;
        public Image game_stage_select_view;
        public Image sunshine1;
		public Image sunshine2;

        // TODO:1-1-１4 ユーザー設定画面処理
        public Image userName_view;
        public Button userNameViewClose_BT;
        public Image userName_BG;
        public Text userName_Text;
        public Text newUserName_Title;
        public TMP_InputField newUserNameInput;
        public Button userName_OK_BT;
        public Image userNameConfirm_View_BG;
        public Text userNameConfirm_Text;
        public Button userNameConfirm_OK_BT;
        public Button userNameConfirmCancel_BT;

        // ゲーム選択画面セル ランク
        // TODO:newステージセレクト関連
        public Button selectViewClose_BT;
        public Image selectCellView1_1_BG;
        public Image selectCellView1_2_BG;
        public Image selectCellView2_1_BG;
        public Image selectCellView2_2_BG;
        public Image selectCellView3_1_BG;
        public Image selectCellView3_2_BG;
        public Button stage1_1_bt;
        public Button stage1_2_bt;
        public Button stage1_3_bt;
        public Button stage2_1_bt;
        public Button stage2_2_bt;
        public Button stage2_3_bt;
        public Button stage3_1_bt;
        public Button stage3_2_bt;
        public Button stage3_3_bt;
        public Button stage4_1_bt;
        public Button stage4_2_bt;
        public Button stage4_3_bt;
        public Button stage5_1_bt;
        public Button stage5_2_bt;
        public Button stage5_3_bt;
        public Button stage6_1_bt;
        public Button stage6_2_bt;
        public Button stage6_3_bt;
        public Image stage1_1_Mask;
        public Image stage1_2_Mask;
        public Image stage1_3_Mask;
        public Image stage2_1_Mask;
        public Image stage2_2_Mask;
        public Image stage2_3_Mask;
        public Image stage3_1_Mask;
        public Image stage3_2_Mask;
        public Image stage3_3_Mask;
        public Image stage4_1_Mask;
        public Image stage4_2_Mask;
        public Image stage4_3_Mask;
        public Image stage5_1_Mask;
        public Image stage5_2_Mask;
        public Image stage5_3_Mask;
        public Image stage6_1_Mask;
        public Image stage6_2_Mask;
        public Image stage6_3_Mask;


        // TODO:旧ステージセレクト関連
        //public Button selectViewClose_BT;
        public Image saveLevel1_1Image;
        public Image saveLevel1_2Image;
        public Image saveLevel2_1Image;
        public Image saveLevel2_2Image;
        public Image saveLevel3_1Image;
        public Image saveLevel3_2Image;
        public Image selectView1_1_BG;
        public Image selectView1_2_BG;
        public Image selectView2_1_BG;
        public Image selectView2_2_BG;
        public Image selectView3_1_BG;
        public Image selectView3_2_BG;
        public Button selectView1_1;
        public Button selectView1_2;
        public Button selectView2_1;
        public Button selectView2_2;
        public Button selectView3_1;
        public Button selectView3_2;
        // TODO:追加 1-1-6 ゲームステージ選択メニュー画面修正
        // セーブデータ有り時の確認画面
        public Image startSaveLevelConfirm_View;
        public Button startSaveLevel_BT;
        public Button startSaveLevelNext_BT;
        public Button startNewLevel_BT;
        public Button startLevelConfrm_close_BT;

        // TODO:削除　1-1-1 1:現在のレベルメニューを削除しステージ選択からの遷移を取り止め　不要となったソース部分の削除
        /*        // ゲーム選択画面セル ステージ
        public Button selectStageViewClose_BT;
        public Text selectBestStageScore1;
        public Text selectBestStageScore2;
        public Text selectBestStageScore3;
        public Text selectBestStageScore4;
        public Text selectBestStageScore5;
        public Text selectBestStageScore6;
        public Text selectBestStageScore7;
        public Text selectBestStageTime1; // 連鎖モード時　トップスコアー時の攻略時間
        public Text selectBestStageTime2;
        public Text selectBestStageTime3;
        public Text selectBestStageTime4;
        public Text selectBestStageTime5;
        public Text selectBestStageTime6;
        public Text selectBestStageTime7;
        public Text selectStageCondition1_1;
        public Text selectStageCondition1_2;
        public Text selectStageCondition1_3;
        public Text selectStageCondition1_4;
        public Text selectStageCondition1_5;
        public Text selectStageCondition1_6;
        public Text selectStageCondition1_7;
        public Text selectStageCondition2_1;
        public Text selectStageCondition2_2;
        public Text selectStageCondition2_3;
        public Text selectStageCondition2_4;
        public Text selectStageCondition2_5;
        public Text selectStageCondition2_6;
        public Text selectStageCondition2_7;
        public Text selectStageCondition3_1;
        public Text selectStageCondition3_2;
        public Text selectStageCondition3_3;
        public Text selectStageCondition3_4;
        public Text selectStageCondition3_5;
        public Text selectStageCondition3_6;
        public Text selectStageCondition3_7;
        public Image selectStageConditionIcon1_1;
        public Image selectStageConditionIcon1_2;
        public Image selectStageConditionIcon1_3;
        public Image selectStageConditionIcon1_4;
        public Image selectStageConditionIcon1_5;
        public Image selectStageConditionIcon1_6;
        public Image selectStageConditionIcon1_7;
        public Image selectStageConditionIcon2_1;
        public Image selectStageConditionIcon2_2;
        public Image selectStageConditionIcon2_3;
        public Image selectStageConditionIcon2_4;
        public Image selectStageConditionIcon2_5;
        public Image selectStageConditionIcon2_6;
        public Image selectStageConditionIcon2_7;
        public Image selectStageConditionIcon3_1;
        public Image selectStageConditionIcon3_2;
        public Image selectStageConditionIcon3_3;
        public Image selectStageConditionIcon3_4;
        public Image selectStageConditionIcon3_5;
        public Image selectStageConditionIcon3_6;
        public Image selectStageConditionIcon3_7;
        public Image selectStageViewIconImage1;
        public Image selectStageViewIconImage2;
        public Image selectStageViewIconImage3;
        public Image selectStageViewIconImage4;
        public Image selectStageViewIconImage5;
        public Image selectStageViewIconImage6;
        public Image selectStageViewIconImage7;
        public Image selectStageViewBGImage1;
        public Image selectStageViewBGImage2;
        public Image selectStageViewBGImage3;
        public Image selectStageViewBGImage4;
        public Image selectStageViewBGImage5;
        public Image selectStageViewBGImage6;
        public Image selectStageViewBGImage7;
        public Button selectStageView1;
        public Button selectStageView2;
        public Button selectStageView3;
        public Button selectStageView4;
        public Button selectStageView5;
        public Button selectStageView6;
        public Button selectStageView7;
*/
        // ゲームクリア・失敗画面
        public Image complete_view;
        public Image complete_level_image;
        public GameObject complete_level_badge1_1;
        public GameObject complete_level_badge1_2;
        public GameObject complete_level_badge1_3;
        public GameObject complete_level_badge2_1;
        public GameObject complete_level_badge2_2;
        public GameObject complete_level_badge2_3;
        public GameObject complete_level_badge3_1;
        public GameObject complete_level_badge3_2;
        public GameObject complete_level_badge3_3;
        public GameObject complete_level_badge4_1;
        public GameObject complete_level_badge4_2;
        public GameObject complete_level_badge4_3;
        public GameObject complete_level_badge5_1;
        public GameObject complete_level_badge5_2;
        public GameObject complete_level_badge5_3;
        public GameObject complete_level_badge6_1;
        public GameObject complete_level_badge6_2;
        public GameObject complete_level_badge6_3;
        public TextMeshProUGUI complete_level_text;
        public TextMeshProUGUI playtime_text;
        public TextMeshProUGUI getItem_Count_text;
        // TODO:修正・追加 1-1-3
        public Button cmp_OK_BT;
        public Image saveConfirm_View;
        public Button saveLevel_BT;
        public Button saveLevelCancel_BT;
        public Button saveLevelClose_BT;
        public Button cmp_NEXT_BT;
        public Button cmp_shop_BT;
        public bool stageCompleteInfoON = false;
        public Image stage_Clear_Info_view;
        public static Image s_stage_Clear_Info_view;
        public Text maxChainTitle;
        public Text getSilverItem;
        public GameObject LifeLostCount_text;
        public static GameObject s_LifeLostCount_text;
        public Text lifeLostCount_Zero;
        public static Text s_lifeLostCount_Zero;
        public Image lifeLostCount_Zero_star;
        public static Image s_lifeLostCount_Zero_star;
        public Image max_chain_Mes_BG;
        public static Image s_max_chain_Mes_BG;
        public Image maxChain_star;
        public static Image s_maxChain_star;
        public Image get_Item_Mes_BG;
        public static Image s_get_Item_Mes_BG;
        public Image getItem_star;
        public static Image s_getItem_star;
        public Text besttime_text;
        public static Text s_besttime_text;
        public Image besttime_text_star;
        public static Image s_besttime_text_star;
        public Image jewelry_star;
        public Image jewelry_get_star;
        // TODO:削除 ゲーム仕様変更の為
        public Image failed_view;
        public GameObject faild_level_badge1_1;
        public GameObject faild_level_badge1_2;
        public GameObject faild_level_badge1_3;
        public GameObject faild_level_badge2_1;
        public GameObject faild_level_badge2_2;
        public GameObject faild_level_badge2_3;
        public GameObject faild_level_badge3_1;
        public GameObject faild_level_badge3_2;
        public GameObject faild_level_badge3_3;
        public GameObject faild_level_badge4_1;
        public GameObject faild_level_badge4_2;
        public GameObject faild_level_badge4_3;
        public GameObject faild_level_badge5_1;
        public GameObject faild_level_badge5_2;
        public GameObject faild_level_badge5_3;
        public GameObject faild_level_badge6_1;
        public GameObject faild_level_badge6_2;
        public GameObject faild_level_badge6_3;
        public Button fld_OK_BT;
		public Button fld_RT_BT;
        public Button itemView_BT;
        public Text retryItemCount_text;
        // TODO:1-1-4追加 レベルMAX攻略時のトータル成績表示
        public Text total_playtime_text;
        public static Text s_total_playtime_text;
        public Text total_lostlife_count_text;
        public static Text s_total_lostlife_count_text;

        // 連鎖MAX数及び連鎖取得予定アイテム数表示
        public Image max_chain_count_BG;
        public static Image s_max_chain_count_BG;
        public Text max_chain_count_text;
        public static Text s_max_chain_count_text;
        public Image silver_item_GET_BG;
        public static Image s_silver_item_GET_BG;
        public Text silver_item_get_text;
        public static Text s_silver_item_get_text;

        // 連鎖無しの場合のプレイタイム表示ビュー　※連鎖カウントパネル表示領域
        public Image noChainPlayTimeDSP_Sceen2BGImage;
        public static Image s_noChainPlayTimeDSP_Sceen2BGImage;

        // TODO: アイテムボーナス 現在未使用
        public Image item_bonus;
		public Sprite item_bonusCountImage;
		public Sprite item_bonusCount_offImage;
		public Text item_bonusCount;

		public static Image s_sunshine1;
		public static Image s_sunshine2;

        // TODO: 各レベルクリア条件表示　--------------------------------------------------
        public Text play_stage_no;
        public Text play_condition1_text;
        public Text play_condition2_text;
        public Text play_condition3_text;
        public Image play_condition1;
        public Image play_condition2;
        public Image play_condition3;

       　// ゲームシーン０　ライフカウント表示
        public GameObject life_icon1_BG;
		public GameObject life_icon2_BG;
		public GameObject life_icon3_BG;
		public GameObject life_icon4_BG;
		public GameObject life_icon5_BG;
		public static GameObject s_life_icon1_BG;
		public static GameObject s_life_icon2_BG;
		public static GameObject s_life_icon3_BG;
		public static GameObject s_life_icon4_BG;
		public static GameObject s_life_icon5_BG;
		public GameObject life_icon1;
		public GameObject life_icon2;
		public GameObject life_icon3;
		public GameObject life_icon4;
		public GameObject life_icon5;

        // ゲームシーン２　ライフカウント表示
        public GameObject life_hearticon1_BG;
        public GameObject life_hearticon2_BG;
        public GameObject life_hearticon3_BG;
        public GameObject life_hearticon4_BG;
        public GameObject life_hearticon5_BG;
        public static GameObject s_life_hearticon1_BG;
        public static GameObject s_life_hearticon2_BG;
        public static GameObject s_life_hearticon3_BG;
        public static GameObject s_life_hearticon4_BG;
        public static GameObject s_life_hearticon5_BG;
        public GameObject life_hearticon1;
        public GameObject life_hearticon2;
        public GameObject life_hearticon3;
        public GameObject life_hearticon4;
        public GameObject life_hearticon5;
        public static GameObject s_life_hearticon1;
        public static GameObject s_life_hearticon2;
        public static GameObject s_life_hearticon3;
        public static GameObject s_life_hearticon4;
        public static GameObject s_life_hearticon5;

        // 落下待機経過時間表示
        public Image waitingTimerGauge_BG;
        public Image waitingTimerTop_BG;
        public static Image waitingTimerTop_BG_s;
        public GameObject Level_top;
        public GameObject Level1_1;
        public GameObject Level1_2;
		public GameObject Level1_3;
		public GameObject Level2_1;
		public GameObject Level2_2;
		public GameObject Level2_3;
		public GameObject Level3_1;
		public GameObject Level3_2;
		public GameObject Level3_3;
        public GameObject Level3_4;
        public Color Level_top_Base_Color;
        public Color Level1_1_Base_Color;
		public Color Level1_2_Base_Color;
		public Color Level1_3_Base_Color;
		public Color Level2_1_Base_Color;
		public Color Level2_2_Base_Color;
		public Color Level2_3_Base_Color;
		public Color Level3_1_Base_Color;
		public Color Level3_2_Base_Color;
		public Color Level3_3_Base_Color;
        public Color Level3_4_Base_Color;

        // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
        public GameObject playItemView_button_BG;
        public Button playItemView_button;

        // TODO:1-1-11 追加 新規設定画面処理の作成
        public GameObject playSettingView_button_BG;
		public Button playSettingView_button;

        // 落下ボタン
        public GameObject down_button_L_BG;
        public GameObject down_button_R_BG;
        public Button down_button_L;
        public Button down_button_R;

        // ゲームステータス関連
        public GameObject rank_bg;
        public Text gameStatus_text;
		public static Text s_gameStatus_text;
		public Text gameTimeEnd_text;
		public static Text s_gameTimeEnd_text;
        public Image gameTime_BG;
        public static Image s_gameTime_BG;
        public Text gameTime_text;
		public static Text s_gameTime_text;
        public Image topGameTime_BG;
        public static Image s_topGameTime_BG;
        public Text topGameTime_text;
        public static Text s_topGameTime_text;
        public TextMeshProUGUI noChainGameTime_text;
        public Image topGameTimeChainView_BG;
        public static Image s_topGameTimeChainView_BG;
        public Text topGameTimeChainView_text;
        public static Text s_topGameTimeChainView_text;
        public static TextMeshProUGUI s_noChainGameTime_text;
        public TimeSpan currentTs;
		public static TimeSpan playEndTimeSpan;
        public Text startCountDown_text;
        public TextMeshProUGUI startCountDown_text1;
        public TextMeshProUGUI startCountDown_text2;
        public TextMeshProUGUI startCountDown_text3;
        public TextMeshProUGUI startCountDown_text4;
        public TextMeshProUGUI startCountDown_text5;
        // itemGet Message disp.
        public Image itemGetView;
        public Image itemGetView_BG;
        public TextMeshProUGUI itemGetIcon;
        public TextMeshProUGUI itemGetTitle;
        public TextMeshProUGUI itemGetCount;
        public TextMeshProUGUI itemGetMessage;
        public Text gamePoint;
        public Text gamePointLabel;
        // Set SlimCard View
        public Image slimcardView;
        public Image slimcard1;
        public Image slimcard2;
        public Image slimcard3;
        public static Image s_slimcardView;

        // 取得アイテム表示
        public Text coin_text;
        public Text jewelry_text;
        public Image jewelryCountIcon;
        public Image jewelryCountStarIcon;

        public Image goldItem_BG;
        public Image goldItem_1;
        public Image goldItem_2;
        public Image goldItem_3;
        public Image goldItem_4;
        public Image goldItem_5;
        public Image goldItem_6;
        public Image goldItem_7;
        public Image goldItem_8;
        public Image goldItem_9;
        public Image goldItem_10;
        public Image silverItem_BG;
        public Image silverItem_1;
        public Image silverItem_2;
        public Image silverItem_3;
        public Image silverItem_4;
        public Image silverItem_5;
        public Image silverItem_6;
        public Image silverItem_7;
        public Image silverItem_8;
        public Image silverItem_9;
        public Image silverItem_10;

        public Image[] silverItemArray;
        public Image[] goldItemArray;

        // 連鎖カウント表示　仕様変更に伴い未使用
        public Image chain_count_BG;
        public Text chaine_count_1_text;
        public Text chaine_count_2_text;
        public Text chaine_count_3_text;

        public Text chaine_count_2_point_text;
        public Text chaine_count_3_point_text;
        public Text life_count_point_text;
        public Text add_point_text;
        public static int add_point;
        //		public Text bonus;
        //		public static Text s_bonus;
        //		public Text bonus_gold;
        //		public static Text s_bonus_gold;

        public Text level_text;
		public Text gold_count;
		public Text point_count;
		public Text gameCount_text;
		public Text lost_Count_text;
		public Text lostadd_Count_text;
		public Text pauseCount_text;
        public Text timereset_count;
        public Text lifelostinvalid_count;
        public Image pause_banner_BG;
        public Text pause_banner_text;

        public int sw_gameEndButton;
        public int gameEndButton_clickCount;

        public Sprite b_sprit1;
		public Sprite b_sprit2;

		public Button b_setting;
		public Button b_Delay;

		public Button b_Pause;
        public Button b_TimeReset;
        public Button b_LifeLostInvalid;
        public Button b_share;
        public Button b_change;

		public Button b_Lostadd;
		public Button b_Share;
		public Button b_slimCard;
        public Button b_new_game2;
        public Button b_retry;
		public Button b_item;
		//public Button b_charge;
		public static Button bs_slimCard;
        public static Button bs_new_game2;
        public static Button bs_retry;
		public static Button bs_item;
		public static Button bs_setting;
        //public static Button bs_charge;
        public Button b_game_cell;

        // TODO:1-1-10 修正 新規アイテム変換購入画面処理の作成
        // setting view Main or Play
        private bool item_BGM_Status;
        // item view
        public Button itemViewClose_BT;
        public TextMeshProUGUI itemview_jewelry_count;
        public TextMeshProUGUI itemview_pauseitem_count;
        public TextMeshProUGUI itemview_timerestitem_count;
        public TextMeshProUGUI itemview_lifelostitem_count;
        public Text goldCoin_TotalCount;
        public Button itemSet1_BT;
        public Button itemSet2_BT;
        public Button itemSet3_BT;
        public Button itemSet4_BT;
        public Button itemSet5_BT;
        public Button itemWait_BT;
        public Button itemRetry_BT;
        public Text itemSet1_coin_Count;
        public Text itemSet2_coin_Count;
        public Text itemSet3_coin_Count;
        public Text itemSet4_coin_Count;
        public Text itemSet5_coin_Count;
        public Text itemSet1_price;
        public Text itemSet2_price;
        public Text itemSet3_price;
        public Text itemSet4_price;
        public Text itemSet5_price;
        public Text itemSet1_wait_count;
        public Text itemSet2_wait_count;
        public Text itemSet3_wait_count;
        public Text itemSet4_wait_count;
        public Text itemSet5_wait_count;
        public Text itemSet1_retry_count;
        public Text itemSet2_retry_count;
        public Text itemSet3_retry_count;
        public Text itemSet4_retry_count;
        public Text itemSet5_retry_count;
        public Text itemWait_count;
        public Text itemRetry_count;
        public Image itemExchangeConfirm_View;
        public Image exchangeItem1;
        public Image exchangeItem2;
        public Text exchangeCoincount;
        public Button exchange_BT;
        public Button itemExchangeViewClose_BT;

        // TODO:1-1-11 追加 新規設定画面処理の作成
        // setting view Main or Play
        private bool setting_BGM_Status;
        private Sequence sequence;
        public Button settingViewClose_BT;
        // トグルボタン
        public Button setting_Toggle1_BT;
        public Text setting1_Title;
        public Image toggle1_Background;
        public RectTransform toggle1_Handle;
        private float toggle1_handlePosX;
        public Button setting_Toggle2_BT;
        public Text setting2_Title;
        public Image toggle2_Background;
        public RectTransform toggle2_Handle;
        private float toggle2_handlePosX;
        public Button setting_Toggle3_BT;
        public Text setting3_Title;
        public Image toggle3_Background;
        public RectTransform toggle3_Handle;
        private float toggle3_handlePosX;
        public Button setting1_InfoBT;
        public Text setting1_InfoBT_Title;
        public Button setting2_InfoBT;
        public Text setting2_InfoBT_Title;
        public Button setting3_InfoBT;
        public Text setting3_InfoBT_Title;
        // トグルカラー
        private static readonly Color OFF_BG_COLOR = new Color(0.92f, 0.92f, 0.92f);
        private static readonly Color ON_BG_COLOR = new Color(0.2f, 0.84f, 0.3f);
        private const float SWITCH_DURATION = 0.36f;

        // Setting View webView
        //public WebViewObject webViewObject;

        // TODO:1-1-7追加　メインメニュー処理修正
        //public Button bs_setting_OK;
        //public Button bs_setting_cancel;
        //public Button bs_setting_reset;

        public Text pauseTimer_text;

		// タイムアタック　スタートカウントダウン表示フラグ
		public static bool startCountDown = false;
		public static float countDownTime;

        public static int sunshinerotate = 0;
		public static float sunshinerotateTime;
		public static float statusTime;
		public static bool pauseON = false;

		// gold count dsp
		public static long goldcountDSP = 0;

		// チェーンボム　モンスターカラーカウント
		public GameObject monsterCounter2DEffect;
		public static GameObject monsterCounter2DEffect_s;
		public static GameObject Effect_2D;

        // モンスターカラー別カウント表示関連
		public static bool monsterColor = false;
		public static bool resetMonsterColor = false;
		public Image monsterColorCountView;

		public Material chainExplosionCounterM;
		//public Material chainExplosionCounterHighLightM;
		public static Image s_monsterColorCountView;
		public Sprite monsterCountBaseImage;
		public Sprite monsterCountHighImage;
		public Image greenMonsterCountImage;
        public static Image greenMonsterCountImage_s;
		public static Vector3 greenMonsterCounterPosition;
		public Image greenMonsterStarImage;
		public static Image greenMonsterStarImage_s;
		public Image yellowMonsterCountImage;
        public static Image yellowMonsterCountImage_s;
		public static Vector3 yellowMonsterCounterPosition;
		public Image purpleMonsterCountImage;
        public static Image purpleMonsterCountImage_s;
		public static Vector3 purpleMonsterCounterPosition;
		public Image redMonsterCountImage;
        public static Image redMonsterCountImage_s;
		public static Vector3 redMonsterCounterPosition;
		public Image blueMonsterCountImage;
        public static Image blueMonsterCountImage_s;
		public static Vector3 blueMonsterCounterPosition;
		public Text greenMonsterCount;
		public Text yellowMonsterCount;
		public Text purpleMonsterCount;
		public Text redMonsterCount;
		public Text blueMonsterCount;
		public Text greenMonsterPoint;
		public Text yellowMonsterPoint;
		public Text purpleMonsterPoint;
		public Text redMonsterPoint;
		public Text blueMonsterPoint;
		public Text greenMonsterLabel;
		public Text yellowMonsterLabel;
		public Text purpleMonsterLabel;
		public Text redMonsterLabel;
		public Text blueMonsterLabel;
		public static bool greenMonsterCountON;
		public static bool yellowMonsterCountON;
		public static bool orangeMonsterCountON;
		public static bool purpleMonsterCountON;
		public static bool redMonsterCountON;
		public static bool blueMonsterCountON;

        //  スライムモンスターカラー別カウント表示関連
        public Image monsterColorCountSceen2View;
        public static Image s_monsterSlimeColorCountView;
        public Image greenMonsterSlimeCountView;
        public Image greenMonsterSlimeCountImage;
        public Sprite greenMonsterSlimeCountImageTexture1;
        public Sprite greenMonsterSlimeCountImageTexture2;
        public Sprite greenMonsterSlimeCountImageTexture3;
        public Image greenMonsterSlimeCountMaskImage;
        public static Image greenMonsterSlimeCountMaskImage_s;
        public RawImage greenMonsterSlimeVideoView;
        public VideoClip greenMonsterSlimeVideoClip1;
        public VideoClip greenMonsterSlimeVideoClip2;
        public VideoClip greenMonsterSlimeVideoClip3;
        public static VideoClip s_greenMonsterSlimeVideoClip1;
        public static VideoClip s_greenMonsterSlimeVideoClip2;
        public static VideoClip s_greenMonsterSlimeVideoClip3;
        public static RawImage greenMonsterSlimeVideoView_s;
        public static Image greenMonsterSlimeCountView_s;
        //public static Vector3 greenMonsterSlimeCounterPosition;
        public Image greenMonsterSlimeCountbadgeImage;
        public static Image greenMonsterSlimeCountbadgeImage_s;
        public Image greenMonsterSlimeStarImage;
        public static Image greenMonsterSlimeStarImage_s;
        public Image yellowMonsterSlimeCountView;
        public Image yellowMonsterSlimeCountImage;
        public Sprite yellowMonsterSlimeCountImageTexture1;
        public Sprite yellowMonsterSlimeCountImageTexture2;
        public Sprite yellowMonsterSlimeCountImageTexture3;
        public Image yellowMonsterSlimeCountMaskImage;
        public static Image yellowMonsterSlimeCountMaskImage_s;
        public RawImage yellowMonsterSlimeVideoView;
        public VideoClip yellowMonsterSlimeVideoClip1;
        public static VideoClip s_yellowMonsterSlimeVideoClip1;
        public VideoClip yellowMonsterSlimeVideoClip2;
        public static VideoClip s_yellowMonsterSlimeVideoClip2;
        public VideoClip yellowMonsterSlimeVideoClip3;
        public static VideoClip s_yellowMonsterSlimeVideoClip3;
        public static RawImage yellowMonsterSlimeVideoView_s;
        public static Image yellowMonsterSlimeCountView_s;
        public static Vector3 yellowMonsterSlimeCounterPosition;
        public Image yellowMonsterSlimeCountbadgeImage;
        public static Image yellowMonsterSlimeCountbadgeImage_s;
        public Image yellowMonsterSlimeStarImage;
        public static Image yellowMonsterSlimeStarImage_s;
        public Image purpleMonsterSlimeCountView;
        public Image purpleMonsterSlimeCountImage;
        public Sprite purpleMonsterSlimeCountImageTexture1;
        public Sprite purpleMonsterSlimeCountImageTexture2;
        public Sprite purpleMonsterSlimeCountImageTexture3;
        public Image purpleMonsterSlimeCountMaskImage;
        public static Image purpleMonsterSlimeCountMaskImage_s;
        public RawImage purpleMonsterSlimeVideoView;
        public VideoClip purpleMonsterSlimeVideoClip1;
        public static VideoClip s_purpleMonsterSlimeVideoClip1;
        public VideoClip purpleMonsterSlimeVideoClip2;
        public static VideoClip s_purpleMonsterSlimeVideoClip2;
        public VideoClip purpleMonsterSlimeVideoClip3;
        public static VideoClip s_purpleMonsterSlimeVideoClip3;
        public static RawImage purpleMonsterSlimeVideoView_s;
        public static Image purpleMonsterSlimeCountView_s;
        public static Vector3 purpleMonsterSlimeCounterPosition;
        public Image purpleMonsterSlimeCountbadgeImage;
        public static Image purpleMonsterSlimeCountbadgeImage_s;
        public Image purpleMonsterSlimeStarImage;
        public static Image purpleMonsterSlimeStarImage_s;
        public Image redMonsterSlimeCountView;
        public Image redMonsterSlimeCountImage;
        public Sprite redMonsterSlimeCountImageTexture1;
        public Sprite redMonsterSlimeCountImageTexture2;
        public Sprite redMonsterSlimeCountImageTexture3;
        public Image redMonsterSlimeCountMaskImage;
        public static Image redMonsterSlimeCountMaskImage_s;
        public RawImage redMonsterSlimeVideoView;
        public VideoClip redMonsterSlimeVideoClip1;
        public static VideoClip s_redMonsterSlimeVideoClip1;
        public VideoClip redMonsterSlimeVideoClip2;
        public static VideoClip s_redMonsterSlimeVideoClip2;
        public VideoClip redMonsterSlimeVideoClip3;
        public static VideoClip s_redMonsterSlimeVideoClip3;
        public static RawImage redMonsterSlimeVideoView_s;
        public static Image redMonsterSlimeCountView_s;
        public static Vector3 redMonsterSlimeCounterPosition;
        public Image redMonsterSlimeCountbadgeImage;
        public static Image redMonsterSlimeCountbadgeImage_s;
        public Image redMonsterSlimeStarImage;
        public static Image redMonsterSlimeStarImage_s;
        public Image blueMonsterSlimeCountView;
        public Image blueMonsterSlimeCountImage;
        public Sprite blueMonsterSlimeCountImageTexture1;
        public Sprite blueMonsterSlimeCountImageTexture2;
        public Sprite blueMonsterSlimeCountImageTexture3;
        public Image blueMonsterSlimeCountMaskImage;
        public static Image blueMonsterSlimeCountMaskImage_s;
        public RawImage blueMonsterSlimeVideoView;
        public VideoClip blueMonsterSlimeVideoClip1;
        public static VideoClip s_blueMonsterSlimeVideoClip1;
        public VideoClip blueMonsterSlimeVideoClip2;
        public static VideoClip s_blueMonsterSlimeVideoClip2;
        public VideoClip blueMonsterSlimeVideoClip3;
        public static VideoClip s_blueMonsterSlimeVideoClip3;
        public static RawImage blueMonsterSlimeVideoView_s;
        public static Image blueMonsterSlimeCountView_s;
        public static Vector3 blueMonsterSlimeCounterPosition;
        public Image blueMonsterSlimeCountbadgeImage;
        public static Image blueMonsterSlimeCountbadgeImage_s;
        public Image blueMonsterSlimeStarImage;
        public static Image blueMonsterSlimeStarImage_s;
        public Image whiteMonsterSlimeCountView;
        public Image whiteMonsterSlimeCountImage;
        public Sprite whiteMonsterSlimeCountImageTexture1;
        public Sprite whiteMonsterSlimeCountImageTexture2;
        public Sprite whiteMonsterSlimeCountImageTexture3;
        public Image whiteMonsterSlimeCountMaskImage;
        public static Image whiteMonsterSlimeCountMaskImage_s;
        public RawImage whiteMonsterSlimeVideoView;
        public static RawImage whiteMonsterSlimeVideoView_s;
        public static Image whiteMonsterSlimeCountView_s;
        public static Vector3 whiteMonsterSlimeCounterPosition;
        public Image whiteMonsterSlimeCountbadgeImage;
        public static Image whiteMonsterSlimeCountbadgeImage_s;
        public Image whiteMonsterSlimeStarImage;
        public static Image whiteMonsterSlimeStarImage_s;

        public Text greenMonsterSlimeCount;
        public Text yellowMonsterSlimeCount;
        public Text purpleMonsterSlimeCount;
        public Text redMonsterSlimeCount;
        public Text blueMonsterSlimeCount;
        public Text whiteMonsterSlimeCount;
        public static bool greenMonsterSlimeCountON;
        public static bool yellowMonsterSlimeCountON;
        public static bool orangeMonsterSlimeCountON;
        public static bool purpleMonsterSlimeCountON;
        public static bool redMonsterSlimeCountON;
        public static bool blueMonsterSlimeCountON;
        public static bool whiteMonsterSlimeCountON;

        public GameObject greenMonsterLineCount;
		public GameObject yellowMonsterLineCount;
		public GameObject purpleMonsterLineCount;
		public GameObject redMonsterLineCount;
		public GameObject blueMonsterLineCount;
		public GameObject greenMonsterLineSliderCount;
		public GameObject yellowMonsterLineSliderCount;
		public GameObject purpleMonsterLineSliderCount;
		public GameObject redMonsterLineSliderCount;
		public GameObject blueMonsterLineSliderCount;
        public static Image s_safeareaout_header_BG;

        // Use this for initialization
        void Start () {

            screen_width_per = Screen.width / 1125.0f;
            screen_height_per = Screen.height / 2436.0f;
            //Debug.Log(" screen: " + Screen.width + " " + Screen.height);

            float safeAreaHight = 0;
            float safeAreaHightUnder = 0;
            //#if UNITY_EDITOR_OSX
            s_safeareaout_header_BG = safeareaout_header_BG;
            if (Screen.width >= 1125 && Screen.height >= 2436)
            {
                safeAreaHight = safeareaout_header_BG.rectTransform.sizeDelta.y * screen_width_per;
                safeAreaHightUnder = 40 * screen_width_per;
            }
            //#endif

            s_LifeLostCount_text = LifeLostCount_text;
            s_LifeLostCount_text.GetComponent<Text>().text = "";
            s_gameTime_BG = gameTime_BG;
            s_gameTime_text = gameTime_text;
			gameTime_text.text = "";
            s_noChainGameTime_text = noChainGameTime_text;
            s_topGameTime_BG = topGameTime_BG;
            s_topGameTime_text = topGameTime_text;
            s_topGameTimeChainView_BG = topGameTimeChainView_BG;
            s_topGameTimeChainView_text = topGameTimeChainView_text;
            countDownTime = emitter.startCountDownTimer;

            emitter.playState = emitter.gamePlayState.Pause;

            // インタースティシャル初期化
            sw_gameEndButton = 0;
            gameEndButton_clickCount = emitter.INTERSTITIAL_AD;

            // 落下ボタンオフ
            //sphereDownGaugeOff();

            // View切り替えブラックマスク
            Vector3 scal_sm = screen_Mask.transform.localScale;
            scal_sm.x = scal_sm.x * screen_width_per;
            scal_sm.y = scal_sm.y * screen_width_per;
            screen_Mask.transform.localScale = scal_sm;
            screen_Mask.gameObject.SetActive(false);

            // セーフエリア外ヘッダー
            Vector3 scal_shb = safeareaout_header_BG.transform.localScale;
            scal_shb.x = scal_shb.x * screen_width_per;
            scal_shb.y = scal_shb.y * screen_width_per;
            safeareaout_header_BG.transform.localScale = scal_shb;
            Vector3 pos_shb = safeareaout_header_BG.transform.position;
            pos_shb.x = scal_shb.x * scal_shb.x;
            pos_shb.y = Screen.height - safeAreaHight;
            safeareaout_header_BG.transform.position = pos_shb;
            safeareaout_header_BG.gameObject.SetActive(false);
            // セーフエリア外フッター
            Vector3 scal_sfb = safeareaout_footer_BG.transform.localScale;
            scal_sfb.x = scal_sfb.x * screen_width_per;
            scal_sfb.y = scal_sfb.y * screen_width_per;
            safeareaout_footer_BG.transform.localScale = scal_sfb;
            Vector3 pos_sfb = safeareaout_footer_BG.transform.position;
            pos_sfb.x = pos_sfb.x * scal_sfb.x;
            pos_sfb.y = 0;
            safeareaout_footer_BG.transform.position = pos_sfb;
            safeareaout_footer_BG.gameObject.SetActive(false);
            // ヘッダー
            Vector3 scal_hb = header_BG.transform.localScale;
			scal_hb.x = scal_hb.x * screen_width_per;
			scal_hb.y = scal_hb.y * screen_width_per;
			header_BG.transform.localScale = scal_hb;
			Vector3 pos_hb = header_BG.transform.position;
            pos_hb.x = pos_hb.x * scal_hb.x;
            pos_hb.y = (Screen.height - safeAreaHight) - (header_BG.rectTransform.sizeDelta.y * scal_hb.y);
			header_BG.transform.position = pos_hb;
            header_BG.gameObject.SetActive(false);
            // フッター
            Vector3 scal_fb = footer_BG.transform.localScale;
            scal_fb.x = scal_fb.x * screen_width_per;
            scal_fb.y = scal_fb.y * screen_width_per;
            footer_BG.transform.localScale = scal_fb;
            Vector3 pos_fb = footer_BG.transform.position;
            pos_fb.x = pos_fb.x * scal_fb.x;
            pos_fb.y = safeAreaHightUnder;
            footer_BG.transform.position = pos_fb;
            footer_BG.gameObject.SetActive(false);
            // ヘッダー　レフト
            Vector3 scal = left_header.transform.localScale;
			scal.x = scal.x * screen_width_per;
			scal.y = scal.y * screen_width_per;
			left_header.transform.localScale = scal;
			Vector3 pos = left_header.transform.position;
            pos.x = pos.x * scal.x;
            pos.y = (Screen.height - safeAreaHight) - (left_header.rectTransform.sizeDelta.y * scal.y);
			left_header.transform.position = pos;
			left_header.gameObject.SetActive(false);
			// ヘッダー センター
			Vector3 scal1 = center_header.transform.localScale;
			scal1.x = scal1.x * screen_width_per;
			scal1.y = scal1.y * screen_width_per;
			center_header.transform.localScale = scal1;
			Vector3 pos1 = center_header.transform.position;
			pos1.x = pos1.x * scal1.x;
			pos1.y = (Screen.height - safeAreaHight) - (center_header.rectTransform.sizeDelta.y * scal1.y);
			center_header.transform.position = pos1;
            center_header.gameObject.SetActive(false);
            // ヘッダー　ライト
            Vector3 scal2 = right_header.transform.localScale;
			scal2.x = scal2.x * screen_width_per;
			scal2.y = scal2.y * screen_width_per;
			right_header.transform.localScale = scal2;
			Vector3 pos2 = right_header.transform.position;
			pos2.x = pos2.x * scal2.x;
			pos2.y = (Screen.height - safeAreaHight) - (right_header.rectTransform.sizeDelta.y * scal2.y);
			right_header.transform.position = pos2;
			right_header.gameObject.SetActive(false);

			// credit count inmage init
			s_life_icon1_BG = life_icon1_BG;
			s_life_icon2_BG = life_icon2_BG;
			s_life_icon3_BG = life_icon3_BG;
			s_life_icon4_BG = life_icon4_BG;
			s_life_icon5_BG = life_icon5_BG;

            s_life_hearticon1_BG = life_hearticon1_BG;
            s_life_hearticon2_BG = life_hearticon2_BG;
            s_life_hearticon3_BG = life_hearticon3_BG;
            s_life_hearticon4_BG = life_hearticon4_BG;
            s_life_hearticon5_BG = life_hearticon5_BG;

            s_life_hearticon1 = life_hearticon1;
            s_life_hearticon2 = life_hearticon2;
            s_life_hearticon3 = life_hearticon3;
            s_life_hearticon4 = life_hearticon4;
            s_life_hearticon5 = life_hearticon5;

            // 連鎖MAX数及び連鎖取得予定アイテム数表示
            Vector3 scal_chaininfo = max_chain_count_BG.transform.localScale;
            scal_chaininfo.x = scal_chaininfo.x * screen_width_per;
            scal_chaininfo.y = scal_chaininfo.y * screen_width_per;
            max_chain_count_BG.transform.localScale = scal_chaininfo;
            //Vector3 pos_chaininfo = max_chain_count_BG.transform.position;
            //pos_chaininfo.x = pos_chaininfo.x * scal_chaininfo.x;
            //pos_chaininfo.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + max_chain_count_BG.rectTransform.sizeDelta.y + 77) * scal2.y);
            //max_chain_count_BG.transform.position = pos_chaininfo;
            s_max_chain_count_BG = max_chain_count_BG;
            s_max_chain_count_text = max_chain_count_text;
            s_max_chain_count_text.text = "0";

            // 連鎖無しの場合のプレイタイム表示ビュー　※連鎖カウントパネル表示領域
            s_noChainPlayTimeDSP_Sceen2BGImage = noChainPlayTimeDSP_Sceen2BGImage;
            s_noChainPlayTimeDSP_Sceen2BGImage.gameObject.SetActive(false);

            Vector3 scal_nt = noChainPlayTimeDSP_Sceen2BGImage.transform.localScale;
            scal_nt.x = scal_nt.x * screen_width_per;
            scal_nt.y = scal_nt.y * screen_width_per;
            noChainPlayTimeDSP_Sceen2BGImage.transform.localScale = scal_nt;
            Vector3 pos_nt = noChainPlayTimeDSP_Sceen2BGImage.transform.position;
            pos_nt.x = pos_nt.x * scal_nt.x;
            // 落下待機ゲージ上部位置
            pos_nt.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + noChainPlayTimeDSP_Sceen2BGImage.rectTransform.sizeDelta.y + 50) * scal2.y);
            // 落下待機ゲージ下部位置
            //pos_mc.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + 45) * scal2.y);
            noChainPlayTimeDSP_Sceen2BGImage.transform.position = pos_nt;

            Vector3 scal_getIteminfo = silver_item_GET_BG.transform.localScale;
            scal_getIteminfo.x = scal_getIteminfo.x * screen_width_per;
            scal_getIteminfo.y = scal_getIteminfo.y * screen_width_per;
            silver_item_GET_BG.transform.localScale = scal_getIteminfo;
            Vector3 pos_getIteminfo = silver_item_GET_BG.transform.position;
            pos_getIteminfo.x = pos_getIteminfo.x * scal_getIteminfo.x;
            pos_getIteminfo.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + silver_item_GET_BG.rectTransform.sizeDelta.y + 77) * scal2.y);
            silver_item_GET_BG.transform.position = pos_getIteminfo;
            s_silver_item_GET_BG = silver_item_GET_BG;
            s_silver_item_get_text = silver_item_get_text;

            s_max_chain_count_BG.gameObject.SetActive(false);
            //s_silver_item_GET_BG.gameObject.SetActive(false);

            // TODO:1-1-１０修正 新規アイテム変換購入画面処理の作成
            Vector3 scal_tdlb = playItemView_button_BG.transform.localScale;
            scal_tdlb.x = scal_tdlb.x * screen_width_per;
            scal_tdlb.y = scal_tdlb.y * screen_width_per;
            playItemView_button_BG.transform.localScale = scal_tdlb;
            Vector3 pos_tdlb = playItemView_button_BG.transform.position;
            pos_tdlb.x = pos_tdlb.x * scal_tdlb.x;
            // TODO:1-1-11修正 新規設定画面処理の作成
            Vector3 scal_tdrb = playSettingView_button_BG.transform.localScale;
            scal_tdrb.x = scal_tdrb.x * screen_width_per;
            scal_tdrb.y = scal_tdrb.y * screen_width_per;
            playSettingView_button_BG.transform.localScale = scal_tdrb;
            Vector3 pos_tdrb = playSettingView_button_BG.transform.position;
            pos_tdrb.x = pos_tdrb.x * scal_tdrb.x;
            // アイテム画面表示ボタン
            Button pib_obj = playItemView_button.transform.GetComponent<Button>();
            pib_obj.onClick.AddListener(() => ButtonPlayItemClick());
            // 設定画面表示ボタン
            Button psb_obj = playSettingView_button.transform.GetComponent<Button>();
            psb_obj.onClick.AddListener(() => ButtonSettingPlayClick());

            // 落下待機ゲージ上部位置
            pos_tdlb.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + playItemView_button_BG.GetComponent<Image>().rectTransform.sizeDelta.y) * scal2.y);
            // 落下待機ゲージ下部位置
            //pos_tdlb.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + down_Top_button_L_BG.GetComponent<Image>().rectTransform.sizeDelta.y + 45) * scal2.y);
            playItemView_button_BG.transform.position = pos_tdlb;
            playItemView_button_BG.gameObject.SetActive(false);
            // フッター 落下LボタンBG
            Vector3 scal_fdlb = down_button_L_BG.transform.localScale;
            scal_fdlb.x = scal_fdlb.x * screen_width_per;
            scal_fdlb.y = scal_fdlb.y * screen_width_per;
            down_button_L_BG.transform.localScale = scal_fdlb;
            Vector3 pos_fdlb = down_button_L_BG.transform.position;
            pos_fdlb.x = pos_fdlb.x * scal_fdlb.x;
            pos_fdlb.y = safeAreaHightUnder;
            down_button_L_BG.transform.position = pos_fdlb;
            down_button_L_BG.gameObject.SetActive(false);

            // 落下待機ゲージ上部位置
            pos_tdrb.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + playSettingView_button_BG.GetComponent<Image>().rectTransform.sizeDelta.y) * scal2.y);
            // 落下待機ゲージ下部位置
            //pos_tdrb.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + down_Top_button_R_BG.GetComponent<Image>().rectTransform.sizeDelta.y + 45) * scal2.y);
            playSettingView_button_BG.transform.position = pos_tdrb;
            playSettingView_button_BG.gameObject.SetActive(false);
            // フッター playSettingView_button_BG
            Vector3 scal_fdrb = down_button_R_BG.transform.localScale;
            scal_fdrb.x = scal_fdrb.x * screen_width_per;
            scal_fdrb.y = scal_fdrb.y * screen_width_per;
            down_button_R_BG.transform.localScale = scal_fdrb;
            Vector3 pos_fdrb = down_button_R_BG.transform.position;
            pos_fdrb.x = pos_fdrb.x * scal_fdrb.x;
            pos_fdrb.y = safeAreaHightUnder;
            down_button_R_BG.transform.position = pos_fdrb;
            down_button_R_BG.gameObject.SetActive(false);

            Button dl_obj = down_button_L.transform.GetComponent<Button>();
            dl_obj.onClick.AddListener(() => ButtonDownClick());
            Button dr_obj = down_button_R.transform.GetComponent<Button>();
            dr_obj.onClick.AddListener(() => ButtonDownClick());


            // スケールはベースVIEW設定済みなので子供のviewは設定の必要なし

            // ゲームプレーポイント表示フォントサイズ
            //			Vector3 gamePoint_scal = gamePoint.transform.localScale;
            //			gamePoint_scal.x = gamePoint_scal.x * screen_width_per;
            //			gamePoint_scal.y = gamePoint_scal.y * screen_width_per;
            //			Vector3 gamepoint_location = gamePoint.rectTransform.localPosition;
            //			gamepoint_location.x = gamepoint_location.x * gamePoint_scal.x;
            //			gamePoint.rectTransform.localPosition = gamepoint_location;
            //			gamePoint.GetComponent<Text>().fontSize = 20;

            // ゲームプレーポイントラベル表示フォントサイズ
            //			Vector3 gamePointLabel_scal = gamePointLabel.transform.localScale;
            //			gamePointLabel_scal.x = gamePoint_scal.x * screen_width_per;
            //			gamePointLabel_scal.y = gamePoint_scal.y * screen_width_per;
            //			gamePointLabel.GetComponent<Text>().fontSize = 12;

            // プレータイム表示
            //			Vector3 playtimeLabel_scal = gameTime_text.transform.localScale;
            //			playtimeLabel_scal.x = playtimeLabel_scal.x * screen_width_per;
            //			playtimeLabel_scal.y = playtimeLabel_scal.y * screen_width_per;
            //			Vector3 playtimeposition = gameTime_text.rectTransform.localPosition;
            //			playtimeposition.x = playtimeposition.x * playtimeLabel_scal.x;
            //			gameTime_text.rectTransform.localPosition = playtimeposition;

            // ポーズボタン
            b_Pause.gameObject.SetActive(false);
            // シェアボタン
            b_share.gameObject.SetActive(false);
            // テクスチャチェンジボタン
            b_change.gameObject.SetActive(true);

            // モンスターカラーカウント表示ビュー
            monsterCounter2DEffect_s = monsterCounter2DEffect;

			Vector3 scal_mc = monsterColorCountView.transform.localScale;
			scal_mc.x = scal_mc.x * screen_width_per;
			scal_mc.y = scal_mc.y * screen_width_per;
			monsterColorCountView.transform.localScale = scal_mc;
			Vector3 pos_mc = monsterColorCountView.transform.position;
			pos_mc.x = pos_mc.x * scal_mc.x;
            // 落下待機ゲージ上部位置
            pos_mc.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y) * scal2.y);
            // 落下待機ゲージ下部位置
            //pos_mc.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + 45) * scal2.y);
            monsterColorCountView.transform.position = pos_mc;

            // モンスターカウンターイメージstaticセット  ゲームシーン０連鎖カウンターパネル２D表示位置での２Dエフェクト表示に利用　※現在未利用
            greenMonsterCountImage_s = greenMonsterCountImage;
			greenMonsterStarImage_s = greenMonsterStarImage;
			yellowMonsterCountImage_s = yellowMonsterCountImage;
			redMonsterCountImage_s = redMonsterCountImage;
			purpleMonsterCountImage_s = purpleMonsterCountImage;
			blueMonsterCountImage_s = blueMonsterCountImage;

            // モンスターカウンター座標セット  ゲームシーン０連鎖カウンターパネル２D表示位置での２Dエフェクト表示に利用　※現在未利用
            greenMonsterCounterPosition = greenMonsterCountImage.rectTransform.position;
			yellowMonsterCounterPosition = yellowMonsterCountImage.rectTransform.position;
			redMonsterCounterPosition = redMonsterCountImage.rectTransform.position;
			purpleMonsterCounterPosition = purpleMonsterCountImage.rectTransform.position;
			blueMonsterCounterPosition = blueMonsterCountImage.rectTransform.position;

			// モンスターカウンターマテリアルセット
			greenMonsterCountImage.material = chainExplosionCounterM;
			yellowMonsterCountImage.material = chainExplosionCounterM;
			redMonsterCountImage.material = chainExplosionCounterM;
			purpleMonsterCountImage.material = chainExplosionCounterM;
			blueMonsterCountImage.material = chainExplosionCounterM;

            // スライムモンスター連鎖パネル
            Vector3 scal_mc2 =  monsterColorCountSceen2View.transform.localScale;
            scal_mc2.x = scal_mc2.x * screen_width_per;
            scal_mc2.y = scal_mc2.y * screen_width_per;
            monsterColorCountSceen2View.transform.localScale = scal_mc2;
            Vector3 pos_mc2 = monsterColorCountSceen2View.transform.position;
            pos_mc2.x = pos_mc2.x * scal_mc2.x;
            // 落下待機ゲージ上部位置
            pos_mc2.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + monsterColorCountSceen2View.rectTransform.sizeDelta.y + 50) * scal2.y);
            // 落下待機ゲージ下部位置
            monsterColorCountSceen2View.transform.position = pos_mc2;

            greenMonsterSlimeCountView_s = greenMonsterSlimeCountView;
            yellowMonsterSlimeCountView_s = yellowMonsterSlimeCountView;
            redMonsterSlimeCountView_s = redMonsterSlimeCountView;
            purpleMonsterSlimeCountView_s = purpleMonsterSlimeCountView;
            blueMonsterSlimeCountView_s = blueMonsterSlimeCountView;
            whiteMonsterSlimeCountView_s = whiteMonsterSlimeCountView;

            // スライムモンスター連鎖パネルマスク
            greenMonsterSlimeCountMaskImage_s = greenMonsterSlimeCountMaskImage;
            yellowMonsterSlimeCountMaskImage_s = yellowMonsterSlimeCountMaskImage;
            redMonsterSlimeCountMaskImage_s = redMonsterSlimeCountMaskImage;
            purpleMonsterSlimeCountMaskImage_s = purpleMonsterSlimeCountMaskImage;
            blueMonsterSlimeCountMaskImage_s = blueMonsterSlimeCountMaskImage;
            whiteMonsterSlimeCountMaskImage_s = whiteMonsterSlimeCountMaskImage;
            // スライムモンスター連鎖時のカウンターパネルマスクOFF
            greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
            yellowMonsterSlimeCountMaskImage.gameObject.SetActive(false);
            redMonsterSlimeCountMaskImage.gameObject.SetActive(false);
            purpleMonsterSlimeCountMaskImage.gameObject.SetActive(false);
            blueMonsterSlimeCountMaskImage.gameObject.SetActive(false);

            // スライムモンスター連鎖ビデオビュー
            greenMonsterSlimeVideoView_s = greenMonsterSlimeVideoView;
            yellowMonsterSlimeVideoView_s = yellowMonsterSlimeVideoView;
            redMonsterSlimeVideoView_s = redMonsterSlimeVideoView;
            purpleMonsterSlimeVideoView_s = purpleMonsterSlimeVideoView;
            blueMonsterSlimeVideoView_s = blueMonsterSlimeVideoView;

            s_greenMonsterSlimeVideoClip1 = greenMonsterSlimeVideoClip1;
            s_yellowMonsterSlimeVideoClip1 = yellowMonsterSlimeVideoClip1;
            s_redMonsterSlimeVideoClip1 = redMonsterSlimeVideoClip1;
            s_purpleMonsterSlimeVideoClip1 = purpleMonsterSlimeVideoClip1;
            s_blueMonsterSlimeVideoClip1 = blueMonsterSlimeVideoClip1;
            s_greenMonsterSlimeVideoClip2 = greenMonsterSlimeVideoClip2;
            s_yellowMonsterSlimeVideoClip2 = yellowMonsterSlimeVideoClip2;
            s_redMonsterSlimeVideoClip2 = redMonsterSlimeVideoClip2;
            s_purpleMonsterSlimeVideoClip2 = purpleMonsterSlimeVideoClip2;
            s_blueMonsterSlimeVideoClip2 = blueMonsterSlimeVideoClip2;
            s_greenMonsterSlimeVideoClip3 = greenMonsterSlimeVideoClip3;
            s_yellowMonsterSlimeVideoClip3 = yellowMonsterSlimeVideoClip3;
            s_redMonsterSlimeVideoClip3 = redMonsterSlimeVideoClip3;
            s_purpleMonsterSlimeVideoClip3 = purpleMonsterSlimeVideoClip3;
            s_blueMonsterSlimeVideoClip3 = blueMonsterSlimeVideoClip3;

            // 連鎖時のカウンターパネルビデオ再生ビュー
            blueMonsterSlimeVideoView_s.gameObject.SetActive(false);
            greenMonsterSlimeVideoView_s.gameObject.SetActive(false);
            purpleMonsterSlimeVideoView_s.gameObject.SetActive(false);
            redMonsterSlimeVideoView_s.gameObject.SetActive(false);
            yellowMonsterSlimeVideoView_s.gameObject.SetActive(false);

            // スライムモンスター連鎖カウントバッジハイライト
            greenMonsterSlimeCountbadgeImage_s = greenMonsterSlimeCountbadgeImage;
            yellowMonsterSlimeCountbadgeImage_s = yellowMonsterSlimeCountbadgeImage;
            redMonsterSlimeCountbadgeImage_s = redMonsterSlimeCountbadgeImage;
            purpleMonsterSlimeCountbadgeImage_s = purpleMonsterSlimeCountbadgeImage;
            blueMonsterSlimeCountbadgeImage_s = blueMonsterSlimeCountbadgeImage;
            // スライムモンスター連鎖カウントバッジハイライトOFF
            greenMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            yellowMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            redMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            purpleMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            blueMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);

            // スライムモンスター連鎖カウントバッジスターイメージ
            greenMonsterSlimeStarImage_s = greenMonsterSlimeStarImage;
            yellowMonsterSlimeStarImage_s = yellowMonsterSlimeStarImage;
            redMonsterSlimeStarImage_s = redMonsterSlimeStarImage;
            purpleMonsterSlimeStarImage_s = purpleMonsterSlimeStarImage;
            blueMonsterSlimeStarImage_s = blueMonsterSlimeStarImage;
            // スライムモンスターカウンター座標セット  ゲームシーン０連鎖カウンターパネル２D表示位置での２Dエフェクト表示に利用　※現在未利用
            //greenMonsterSlimeCounterPosition = greenMonsterSlimeStarImage_s.rectTransform.position;
            yellowMonsterSlimeCounterPosition = yellowMonsterSlimeStarImage_s.rectTransform.position;
            redMonsterSlimeCounterPosition = redMonsterSlimeStarImage_s.rectTransform.position;
            purpleMonsterSlimeCounterPosition = purpleMonsterSlimeStarImage_s.rectTransform.position;
            blueMonsterSlimeCounterPosition = blueMonsterSlimeStarImage_s.rectTransform.position;


            // 連鎖　カラー別取得ポイントテキストクリア
            greenMonsterPoint.text = "";
			yellowMonsterPoint.text = "";
			redMonsterPoint.text = "";
			purpleMonsterPoint.text = "";
			blueMonsterPoint.text = "";

            // 落下待機時間経過ゲージビュー
            // wait time gauge Image
            Vector3 scal_wtg = waitingTimerGauge_BG.transform.localScale;
            scal_wtg.x = scal_wtg.x * screen_width_per;
            scal_wtg.y = scal_wtg.y * screen_width_per;
            waitingTimerGauge_BG.transform.localScale = scal_wtg;
            Vector3 pos_wtg = waitingTimerGauge_BG.transform.position;
            pos_wtg.x = pos_wtg.x * scal_wtg.x;
            // モンスター連鎖カウンター下部位置
            if (cubersFile.game_Sceen == 0)
            {
                pos_wtg.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y) * scal2.y);
            }
            else
            {
                pos_wtg.y = (Screen.height - safeAreaHight) - ((left_header.rectTransform.sizeDelta.y + monsterColorCountSceen2View.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + 50) * scal2.y);
            }
            // モンスター連鎖カウンター上部位置
            //pos_wtg.y = (Screen.height - safeAreaHight) - ((center_header.rectTransform.sizeDelta.y + 45) * scal2.y);
            waitingTimerGauge_BG.transform.position = pos_wtg;
            waitingTimerGauge_BG.gameObject.SetActive(false);

            waitingTimerTop_BG_s = waitingTimerTop_BG;

            Level_top_Base_Color = Level_top.gameObject.GetComponent<Image>().color;
            Level1_1_Base_Color = Level1_1.gameObject.GetComponent<Image>().color;
            Level1_2_Base_Color = Level1_2.gameObject.GetComponent<Image>().color;
            Level1_3_Base_Color = Level1_3.gameObject.GetComponent<Image>().color;
            Level2_1_Base_Color = Level2_1.gameObject.GetComponent<Image>().color;
            Level2_2_Base_Color = Level2_2.gameObject.GetComponent<Image>().color;
            Level2_3_Base_Color = Level2_3.gameObject.GetComponent<Image>().color;
            Level3_1_Base_Color = Level3_1.gameObject.GetComponent<Image>().color;
            Level3_2_Base_Color = Level3_2.gameObject.GetComponent<Image>().color;
            Level3_3_Base_Color = Level3_3.gameObject.GetComponent<Image>().color;
            Level3_4_Base_Color = Level3_4.gameObject.GetComponent<Image>().color;

            Level_top.gameObject.SetActive(false);
            Level1_1.gameObject.SetActive(false);
            Level1_2.gameObject.SetActive(false);
            Level1_3.gameObject.SetActive(false);
            Level2_1.gameObject.SetActive(false);
            Level2_2.gameObject.SetActive(false);
            Level2_3.gameObject.SetActive(false);
            Level3_1.gameObject.SetActive(false);
            Level3_2.gameObject.SetActive(false);
            Level3_3.gameObject.SetActive(false);
            Level3_4.gameObject.SetActive(false);


            // 連鎖ボーナスポイントテキストクリア
            item_bonusCount.text = "";

            // 連鎖取得アイテムオブジェクト配列セット
            setChainGetitemArray();

            // オープニングメニュー　背景 sunshine1-2
            s_sunshine1 = sunshine1;
			Vector3 scal_ss1 = sunshine1.transform.localScale;
			scal_ss1.x = scal_ss1.x * screen_height_per;
			scal_ss1.y = scal_ss1.y * screen_height_per;
			sunshine1.transform.localScale = scal_ss1;
			Vector3 pos_ss1 = sunshine1.transform.position;
			pos_ss1.y = (Screen.height - safeAreaHight) / 2;
			sunshine1.transform.position = pos_ss1;

			s_sunshine2 = sunshine2;
			Vector3 scal_ss2 = sunshine2.transform.localScale;
			scal_ss2.x = scal_ss2.x * screen_height_per;
			scal_ss2.y = scal_ss2.y * screen_height_per;
			sunshine2.transform.localScale = scal_ss2;
			Vector3 pos_ss2 = sunshine2.transform.position;
			pos_ss2.y = (Screen.height - safeAreaHight) / 2;
			sunshine2.transform.position = pos_ss2;

			s_sunshine1.gameObject.SetActive(false);
			s_sunshine2.gameObject.SetActive(false);

            // オープニングメニュー背景
            //s_mainMenu_field = mainMenu_field;
            //Vector3 scal_m = s_mainMenu_field.transform.localScale;
            //scal_m.x = scal_m.x * screen_width_per;
            //scal_m.y = scal_m.y * screen_height_per;
            //s_mainMenu_field.transform.localScale = scal_m;

            // TODO:1-1-１4 追加 ユーザー設定画面処理
            Vector3 scal_unvView = userName_view.transform.localScale;
            scal_unvView.x = scal_unvView.x * screen_width_per;
            scal_unvView.y = scal_unvView.y * screen_width_per;
            userName_view.transform.localScale = scal_unvView;
            //Vector3 pos_unvView = userName_view.transform.position;
            //pos_unvView.y = -(Screen.height - safeAreaHight);
            //userName_view.transform.position = pos_unvView;
            userName_view.gameObject.SetActive(false);
            userNameViewClose_BT.gameObject.SetActive(false);
            userName_BG.gameObject.SetActive(false);
            newUserName_Title.text = "USER NAME : ";

            // menu center field 
            s_center_View = center_View;
			Vector3 scal_c = s_center_View.transform.localScale;
			scal_c.x = scal_c.x * screen_width_per;
			scal_c.y = scal_c.y * screen_width_per;
            s_center_View.transform.localScale = scal_c;
			Vector3 pos_c = s_center_View.transform.position;
			pos_c.x = pos_c.x * screen_width_per;
			pos_c.y = (Screen.height - safeAreaHight) / 2 - s_center_View.rectTransform.sizeDelta.y * scal1.y / 2;
            s_center_View.transform.position = pos_c;

			// Complete View
			Vector3 scal_cmpView = complete_view.transform.localScale;
			scal_cmpView.x = scal_cmpView.x * screen_width_per;
			scal_cmpView.y = scal_cmpView.y * screen_width_per;
			complete_view.transform.localScale = scal_cmpView;
			Vector3 pos_cmpView = complete_view.transform.position;
			pos_cmpView.x = pos_cmpView.x * screen_width_per;
			pos_cmpView.y = (Screen.height - safeAreaHight) / 2 - complete_view.rectTransform.sizeDelta.y * scal1.y / 2;
			complete_view.transform.position = pos_cmpView;

			// Failed View
			Vector3 scal_fldView = failed_view.transform.localScale;
			scal_fldView.x = scal_fldView.x * screen_width_per;
			scal_fldView.y = scal_fldView.y * screen_width_per;
			failed_view.transform.localScale = scal_fldView;
			Vector3 pos_fldView = failed_view.transform.position;
			pos_fldView.x = pos_fldView.x * screen_width_per;
			pos_fldView.y = (Screen.height - safeAreaHight) / 2 - failed_view.rectTransform.sizeDelta.y * scal1.y / 2 - 40.0f;
			failed_view.transform.position = pos_fldView;

            // TODO:1-1-１4 追加 ユーザー設定画面処理
            Button obj_unv_close_BT = userNameViewClose_BT.transform.GetComponent<Button>();
            obj_unv_close_BT.onClick.AddListener(() => ButtonUserNameCloseClick());
            userNameViewClose_BT.gameObject.SetActive(false);

            Button obj_unv_ok_BT = userName_OK_BT.transform.GetComponent<Button>();
            obj_unv_ok_BT.onClick.AddListener(() => ButtonUserNameOKClick());

            Button obj_unc_ok_BT = userNameConfirm_OK_BT.transform.GetComponent<Button>();
            obj_unc_ok_BT.onClick.AddListener(() => ButtonUserNameConfirmOKClick());

            Button obj_unc_cancel_BT = userNameConfirmCancel_BT.transform.GetComponent<Button>();
            obj_unc_cancel_BT.onClick.AddListener(() => ButtonUserNameConfirmCancelClick());


            // new game select button
            bs_slimCard = b_slimCard;
			Button obj_n = b_slimCard.transform.GetComponent<Button>();
			obj_n.onClick.AddListener(() => ButtonSlimCardClick());
            b_slimCard.gameObject.SetActive(false);

            // new game select 2 button
            bs_new_game2 = b_new_game2;
            Button obj_n2 = b_new_game2.transform.GetComponent<Button>();
            obj_n2.onClick.AddListener(() => ButtonNewGame2Click());
            b_new_game2.gameObject.SetActive(false);

            // game retry button
            //bs_retry = b_retry;
            //Button obj_r = b_retry.transform.GetComponent<Button>();
            //obj_r.onClick.AddListener(() => ButtonRetryClick());
            //b_retry.gameObject.SetActive(false);

            // game item button
            bs_item = b_item;
			Button obj_o = b_item.transform.GetComponent<Button>();
			obj_o.onClick.AddListener(() => ButtonItemClick());
			b_item.gameObject.SetActive(false);

            // game setting button
            bs_setting = b_setting;
			Button obj_c = b_setting.transform.GetComponent<Button>();
			obj_c.onClick.AddListener(() => ButtonSettingClick());
            b_setting.gameObject.SetActive(false);

			// game end next & game select button
			Button cmp_OK_BT_o = cmp_OK_BT.transform.GetComponent<Button>();
			cmp_OK_BT_o.onClick.AddListener(() => ButtonGameEndNewGameClick());
            //cmp_OK_BT_o.onClick.AddListener(() => ButtonGameEndNewGameClick());
            Button cmp_NEXT_BT_o = cmp_NEXT_BT.transform.GetComponent<Button>();
            cmp_NEXT_BT_o.onClick.AddListener(() => ButtonGameEndRetryClick());
			Button fld_OK_BT_o = fld_OK_BT.transform.GetComponent<Button>();
			fld_OK_BT_o.onClick.AddListener(() => ButtonGameEndNewGameClick());
			Button fld_RT_BT_o = fld_RT_BT.transform.GetComponent<Button>();
			fld_RT_BT_o.onClick.AddListener(() => ButtonGameEndRetryClick());

            // TODO:修正・追加 1-1-3 月極サービス利用者用攻略レベルセーブボタン
            Button saveLevel_BT_o = saveLevel_BT.transform.GetComponent<Button>();
            saveLevel_BT_o.onClick.AddListener(() => ButtonSaveLevelClick());
            Button saveLevelCancel_BT_o = saveLevelCancel_BT.transform.GetComponent<Button>();
            saveLevelCancel_BT_o.onClick.AddListener(() => ButtonSaveLevelCancelClick());
            Button saveLevelClose_BT_o = saveLevelClose_BT.transform.GetComponent<Button>();
            saveLevelCancel_BT_o.onClick.AddListener(() => ButtonSaveLevelCloseClick());

            Vector3 scal_saveView = saveConfirm_View.transform.localScale;
            scal_saveView.x = scal_saveView.x * screen_width_per;
            scal_saveView.y = scal_saveView.y * screen_width_per;
            saveConfirm_View.transform.localScale = scal_saveView;
            Vector3 pos_saveView = saveConfirm_View.transform.position;
            pos_saveView.x = pos_saveView.x * screen_width_per;
            pos_saveView.y = (Screen.height - safeAreaHight) / 2 - saveConfirm_View.rectTransform.sizeDelta.y * scal1.y / 2 - 40.0f;
            saveConfirm_View.transform.position = pos_saveView;
            saveConfirm_View.gameObject.SetActive(false);

            // TODO:追加　1-1-2  アイテム購入画面表示ボタン
            Button itemView_BT_o = itemView_BT.transform.GetComponent<Button>();
            itemView_BT_o.onClick.AddListener(() => ButtonItemClick());

            // TODO:追加　1-1-2  アイテム購入画面表示ボタン
            Button cmp_shop_BT_o = cmp_shop_BT.transform.GetComponent<Button>();
            cmp_shop_BT_o.onClick.AddListener(() => ButtonItemClick());

            // TODO:追加　1-1-6 ゲームステージ選択メニュー画面修正
            // ステージ選択ボタン押下時の確認画面にて、新規スタートレベル選択
            Button startNewLevel_BT_o = startNewLevel_BT.transform.GetComponent<Button>();
            startNewLevel_BT_o.onClick.AddListener(() => buttonSelectStartNewLevel());
            // ステージ選択ボタン押下時の確認画面にて、スタートセーブレベル選択
            Button startSaveLevel_BT_o = startSaveLevel_BT.transform.GetComponent<Button>();
            startSaveLevel_BT_o.onClick.AddListener(() => buttonSelectStartSaveLevel());
            // ステージ選択ボタン押下時の確認画面にて、スタートセーブレベルの次のレベル選択
            Button startSaveLevelNext_BT_o = startSaveLevelNext_BT.transform.GetComponent<Button>();
            startSaveLevel_BT_o.onClick.AddListener(() => buttonSelectStartSaveNextLevel());
            // ステージ選択ボタン押下時の確認画面にて、クローズボタン選択
            Button startLevelConfrm_close_BT_o = startLevelConfrm_close_BT.transform.GetComponent<Button>();
            startLevelConfrm_close_BT_o.onClick.AddListener(() => buttonSelectConfirmClose());

            // タイムアタックカウントダウン
            Vector3 scal_st = startCountDown_text.transform.localScale;
			scal_st.x = scal_st.x * screen_width_per;
			scal_st.y = scal_st.y * screen_width_per;
			startCountDown_text.transform.localScale = scal_st;
			Vector3 pos_st = startCountDown_text.transform.position;
			pos_st.x = pos_st.x * screen_width_per;
            //pos_st.y = pos_st.y * screen_width_per;
            // monsterColorCountView 下
            pos_st.y = (Screen.height - safeAreaHight) - (center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + startCountDown_text.rectTransform.sizeDelta.y + 120) * scal2.y;
            //pos_st.y = monsterColorCountView.transform.position.y - (startCountDown_text.rectTransform.sizeDelta.y * screen_width_per);
            startCountDown_text.transform.position = pos_st;

            // アイテムゲットテキスト表示
            Vector3 scal_igt = itemGetView.transform.localScale;
            scal_igt.x = scal_igt.x * screen_width_per;
            scal_igt.y = scal_igt.y * screen_width_per;
            itemGetView.transform.localScale = scal_igt;
            Vector3 pos_igt = itemGetView.transform.position;
            pos_igt.x = pos_igt.x * screen_width_per;
            pos_igt.y = (Screen.height - safeAreaHight) - (center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + itemGetView.rectTransform.sizeDelta.y + 40) * scal2.y;
            itemGetView.transform.position = pos_igt;
            itemGetView.gameObject.SetActive(false);

            jewelryCountStarIcon.gameObject.SetActive(false);

            // set slim card表示
            Vector3 scal_sc = slimcardView.transform.localScale;
            scal_sc.x = scal_sc.x * screen_width_per;
            scal_sc.y = scal_sc.y * screen_width_per;
            slimcardView.transform.localScale = scal_sc;
            Vector3 pos_sc = slimcardView.transform.position;
            pos_sc.x = pos_sc.x * screen_width_per;
            pos_sc.y = 5 * screen_width_per + safeAreaHightUnder + (b_Pause.gameObject.GetComponent<Image>().rectTransform.sizeDelta.y + 20.0f) * scal2.y;
            //pos_sc.y = (Screen.height - safeAreaHight) - (center_header.rectTransform.sizeDelta.y + monsterColorCountView.rectTransform.sizeDelta.y + waitingTimerGauge_BG.rectTransform.sizeDelta.y + topGameTimeChainView_BG.rectTransform.sizeDelta.y + slimcardView.rectTransform.sizeDelta.y + 40.0f) * scal2.y;
            slimcardView.transform.position = pos_sc;

            s_slimcardView = slimcardView;
            s_slimcardView.gameObject.SetActive(false);

            s_monsterColorCountView = monsterColorCountView;
            s_monsterColorCountView.gameObject.SetActive(false);
            s_monsterSlimeColorCountView = monsterColorCountSceen2View;
            s_monsterSlimeColorCountView.gameObject.SetActive(false);

            // center view waku
            //			s_center_waku = center_waku;

            // play time end dsp
            s_gameTimeEnd_text = gameTimeEnd_text;
			gameTimeEnd_text.text = "";

			// game status
			s_gameStatus_text = gameStatus_text;
			gameStatus_text.text = "";

            s_center_View.gameObject.SetActive(false);

			// complete view
			complete_view.gameObject.SetActive(false);

            // Failed view
            failed_view.gameObject.SetActive(false);

			// high Score dsp
            s_LifeLostCount_text = LifeLostCount_text;
            life_count_point_text.gameObject.SetActive(false);
            s_besttime_text = besttime_text;
            besttime_text.gameObject.SetActive(false);
            s_besttime_text_star = besttime_text_star;
            besttime_text_star.gameObject.SetActive(false);
            s_lifeLostCount_Zero = lifeLostCount_Zero;
            lifeLostCount_Zero.gameObject.SetActive(false);
            s_lifeLostCount_Zero_star = lifeLostCount_Zero_star;
            lifeLostCount_Zero_star.gameObject.SetActive(false);
            s_max_chain_Mes_BG = max_chain_Mes_BG;
            max_chain_Mes_BG.gameObject.SetActive(false);
            s_get_Item_Mes_BG = get_Item_Mes_BG;
            get_Item_Mes_BG.gameObject.SetActive(false);

            s_stage_Clear_Info_view = stage_Clear_Info_view;
            stage_Clear_Info_view.gameObject.SetActive(false);

            //			gameTimeEnd_text.gameObject.SetActive(false);
            //			s_bonus = bonus;
            //			bonus.gameObject.SetActive(false);
            //			bonus_gold.text = emitter.bonus_time.ToString() + " G";
            //			s_bonus_gold = bonus_gold;
            //			bonus_gold.gameObject.SetActive(false);




            // new game select view
            Vector3 gselect_scal = slimCard_View.transform.localScale;
            gselect_scal.x = gselect_scal.x * screen_width_per;
            gselect_scal.y = gselect_scal.y * screen_width_per;
            slimCard_View.transform.localScale = gselect_scal;
            slimCard_View.gameObject.SetActive(false);

            // new game stage select view
            Vector3 gsselect_scal = game_stage_select_view.transform.localScale;
            gsselect_scal.x = gsselect_scal.x * screen_width_per;
            gsselect_scal.y = gsselect_scal.y * screen_width_per;
            game_stage_select_view.transform.localScale = gselect_scal;
            //Vector3 gsf_pos = game_stage_select_view.transform.position;
            //gsf_pos.y = -(Screen.height - safeAreaHight);
            //game_stage_select_view.transform.position = gsf_pos;

            // item Bonus
            Vector3 bn_scal = item_bonus.transform.localScale;
			bn_scal.x = bn_scal.x * screen_width_per;
			bn_scal.y = bn_scal.y * screen_width_per;
			item_bonus.transform.localScale = bn_scal;
			Vector3 bn_pos = item_bonus.transform.position;
			bn_pos.x = bn_pos.x * bn_scal.x;
			bn_pos.y = header_BG.transform.position.y - header_BG.rectTransform.sizeDelta.y - (22.0f * screen_height_per);
			item_bonus.transform.position = bn_pos;

			// delay button
			Vector3 b_scal = b_Delay.transform.localScale;
			b_scal.x = b_scal.x * screen_width_per;
			b_scal.y = b_scal.y * screen_width_per;
			b_Delay.transform.localScale = b_scal;
			Vector3 b_pos = b_Delay.transform.position;
			b_pos.x = b_pos.x * screen_width_per;
            b_pos.y = 5 * screen_width_per + safeAreaHightUnder;
			b_Delay.transform.position = b_pos;

			Button obj = b_Delay.transform.GetComponent<Button>();
			obj.onClick.AddListener(() => ButtonDelayClick());

			// lostadd button
			Vector3 b_scal_l = b_Lostadd.transform.localScale;
			b_scal_l.x = b_scal_l.x * screen_width_per;
			b_scal_l.y = b_scal_l.y * screen_width_per;
			b_Lostadd.transform.localScale = b_scal_l;
			Vector3 b_pos_l = b_Lostadd.transform.position;
			b_pos_l.x = b_pos_l.x * screen_width_per;
			b_pos_l.y = header_BG.transform.position.y - header_BG.rectTransform.sizeDelta.y - (20.0f * screen_height_per);
			b_Lostadd.transform.position = b_pos_l;
			
			Button obj0 = b_Lostadd.transform.GetComponent<Button>();
			obj0.onClick.AddListener(() => ButtonLostaddClick());

			// pause button
			Vector3 b_scal_p = b_Pause.transform.localScale;
			b_scal_p.x = b_scal_p.x * screen_width_per;
			b_scal_p.y = b_scal_p.y * screen_width_per;
			b_Pause.transform.localScale = b_scal_p;
			Vector3 b_pos_p = b_Pause.transform.position;
			b_pos_p.x = b_pos_p.x * screen_width_per;
            b_pos_p.y = 5 * screen_width_per + safeAreaHightUnder;
            b_Pause.transform.position = b_pos_p;

            Button obj1 = b_Pause.transform.GetComponent<Button>();
            obj1.onClick.AddListener(() => ButtonPauseClick());

            // time reset button
            Vector3 b_scal_tr = b_TimeReset.transform.localScale;
            b_scal_tr.x = b_scal_tr.x * screen_width_per;
            b_scal_tr.y = b_scal_tr.y * screen_width_per;
            b_TimeReset.transform.localScale = b_scal_tr;

            Button obj12 = b_TimeReset.transform.GetComponent<Button>();
            obj12.onClick.AddListener(() => ButtonTimeResetClick());

            // life lost invalid button
            Vector3 b_scal_lf = b_LifeLostInvalid.transform.localScale;
            b_scal_lf.x = b_scal_lf.x * screen_width_per;
            b_scal_lf.y = b_scal_lf.y * screen_width_per;
            b_LifeLostInvalid.transform.localScale = b_scal_lf;

            Button obj13 = b_LifeLostInvalid.transform.GetComponent<Button>();
            obj13.onClick.AddListener(() => ButtonLifeLostInvalidClick());

            // share button
            Vector3 b_scal_s = b_share.transform.localScale;
            b_scal_s.x = b_scal_s.x * screen_width_per;
            b_scal_s.y = b_scal_s.y * screen_width_per;
            b_share.transform.localScale = b_scal_s;
            Vector3 b_pos_s = b_share.transform.position;
            b_pos_s.x = b_pos_s.x * screen_width_per;
            b_pos_s.y = 5 * screen_width_per + safeAreaHightUnder;
            b_share.transform.position = b_pos_s;

            Button obj2 = b_share.transform.GetComponent<Button>();
            obj2.onClick.AddListener(() => ButtonShareClick());

            // change button
            Vector3 b_scal_cg = b_change.transform.localScale;
            b_scal_cg.x = b_scal_cg.x * screen_width_per;
            b_scal_cg.y = b_scal_cg.y * screen_width_per;
            b_change.transform.localScale = b_scal_cg;
            Vector3 b_pos_cg = b_change.transform.position;
            b_pos_cg.x = b_pos_cg.x * screen_width_per;
            b_pos_cg.y = 5 * screen_width_per + safeAreaHightUnder;
            b_change.transform.position = b_pos_cg;

            Button obj3 = b_change.transform.GetComponent<Button>();
            obj3.onClick.AddListener(() => ButtonChangeClick());

            // pause Message "floor touch ..."
            Vector3 t_scal_pb = pause_banner_BG.transform.localScale;
            t_scal_pb.x = t_scal_pb.x * screen_width_per;
            t_scal_pb.y = t_scal_pb.y * screen_width_per;
            pause_banner_BG.transform.localScale = t_scal_pb;
            Vector3 t_pos_pb = pause_banner_BG.transform.position;
            t_pos_pb.x = t_pos_pb.x * screen_width_per;
            t_pos_pb.y = t_pos_pb.y * screen_height_per;
            pause_banner_BG.transform.position = t_pos_pb;
            pause_banner_BG.gameObject.SetActive(false);

			// item view
			Vector3 pf_scal_m = item_View.transform.localScale;
			pf_scal_m.x = pf_scal_m.x * screen_width_per;
			pf_scal_m.y = pf_scal_m.y * screen_height_per;
            item_View.transform.localScale = pf_scal_m;
			//Vector3 pf_pos = item_View.transform.position;
			//pf_pos.y = -(Screen.height - safeAreaHight);
   //         item_View.transform.position = pf_pos;
            item_View.gameObject.SetActive(false);

            // setting view
            Vector3 ps_scal_m = setting_View.transform.localScale;
            ps_scal_m.x = ps_scal_m.x * screen_width_per;
            ps_scal_m.y = ps_scal_m.y * screen_height_per;
            setting_View.transform.localScale = ps_scal_m;
            //Vector3 ps_pos = setting_View.transform.position;
            //ps_pos.y = -(Screen.height - safeAreaHight);
            //setting_View.transform.position = ps_pos;
            setting_View.gameObject.SetActive(false);

            // TODO:1-1-１０修正 新規アイテム変換購入画面処理の作成
            // item View Main or Play
            item_BGM_Status = false;
            // item View Button
            Button obj_itemViewClose_BT = itemViewClose_BT.transform.GetComponent<Button>();
            obj_itemViewClose_BT.onClick.AddListener(() => ButtonItemCloseClick());

            Button obj_itemSet1 = itemSet1_BT.transform.GetComponent<Button>();
            obj_itemSet1.GetComponent<Button>().onClick.RemoveAllListeners();
            obj_itemSet1.GetComponent<Button>().onClick.AddListener(() => ButtonItemSet(obj_itemSet1));
            Button obj_itemSet2 = itemSet2_BT.transform.GetComponent<Button>();
            obj_itemSet2.GetComponent<Button>().onClick.RemoveAllListeners();
            obj_itemSet2.GetComponent<Button>().onClick.AddListener(() => ButtonItemSet(obj_itemSet2));
            Button obj_itemSet3 = itemSet3_BT.transform.GetComponent<Button>();
            obj_itemSet3.GetComponent<Button>().onClick.RemoveAllListeners();
            obj_itemSet3.GetComponent<Button>().onClick.AddListener(() => ButtonItemSet(obj_itemSet3));
            Button obj_itemSet4 = itemSet4_BT.transform.GetComponent<Button>();
            obj_itemSet4.GetComponent<Button>().onClick.RemoveAllListeners();
            obj_itemSet4.GetComponent<Button>().onClick.AddListener(() => ButtonItemSet(obj_itemSet4));
            Button obj_itemSet5 = itemSet5_BT.transform.GetComponent<Button>();
            obj_itemSet5.GetComponent<Button>().onClick.RemoveAllListeners();
            obj_itemSet5.GetComponent<Button>().onClick.AddListener(() => ButtonItemSet(obj_itemSet5));

            Button obj_itemWait_BT = itemWait_BT.transform.GetComponent<Button>();
            obj_itemWait_BT.onClick.AddListener(() => ButtonItemExchange(obj_itemWait_BT));

            Button obj_itemRetry_BT = itemRetry_BT.transform.GetComponent<Button>();
            obj_itemRetry_BT.onClick.AddListener(() => ButtonItemExchange(obj_itemRetry_BT));

            Button obj_exchange_BT = exchange_BT.transform.GetComponent<Button>();
            obj_exchange_BT.onClick.AddListener(() => ButtonItemExchange(obj_exchange_BT));

            Button obj_itemExchangeViewClose_BT = itemExchangeViewClose_BT.transform.GetComponent<Button>();
            obj_itemExchangeViewClose_BT.onClick.AddListener(() => ButtonItemExchange(obj_itemExchangeViewClose_BT));
            itemExchangeConfirm_View.gameObject.SetActive(false);

            // TODO:1-1-11 追加 新規設定画面処理の作成
            // setting view Main or Play
            setting_BGM_Status = false;

            Button obj_settingViewClose_BT = settingViewClose_BT.transform.GetComponent<Button>();
            obj_settingViewClose_BT.onClick.AddListener(() => ButtonSettingCloseClick());

            toggle1_handlePosX = Mathf.Abs(toggle1_Handle.anchoredPosition.x);
            Button obj_setting_Toggle1_BT = setting_Toggle1_BT.transform.GetComponent<Button>();
            obj_setting_Toggle1_BT.onClick.AddListener(() => SwitchToggle(obj_setting_Toggle1_BT));

            toggle2_handlePosX = Mathf.Abs(toggle2_Handle.anchoredPosition.x);
            Button obj_setting_Toggle2_BT = setting_Toggle2_BT.transform.GetComponent<Button>();
            obj_setting_Toggle2_BT.onClick.AddListener(() => SwitchToggle(obj_setting_Toggle2_BT));

            toggle3_handlePosX = Mathf.Abs(toggle3_Handle.anchoredPosition.x);
            Button obj_setting_Toggle3_BT = setting_Toggle3_BT.transform.GetComponent<Button>();
            obj_setting_Toggle3_BT.onClick.AddListener(() => SwitchToggle(obj_setting_Toggle3_BT));

            Button obj_setting1_BT = setting1_InfoBT.transform.GetComponent<Button>();
            obj_setting1_BT.onClick.AddListener(() => Setting_InfoBT_Click(obj_setting1_BT));

            Button obj_setting2_BT = setting2_InfoBT.transform.GetComponent<Button>();
            obj_setting2_BT.onClick.AddListener(() => Setting_InfoBT_Click(obj_setting2_BT));

            Button obj_setting3_BT = setting3_InfoBT.transform.GetComponent<Button>();
            obj_setting3_BT.onClick.AddListener(() => Setting_InfoBT_Click(obj_setting3_BT));

            /*
            // TODO:1-1-11 追加 新規設定画面処理の webView Init.
            // Setting webview init.
            webViewObject.Init(ld: (msg) => Debug.Log(string.Format("CallOnLoaded[{0}]", msg)),enableWKWebView: true);

#if UNITY_EDITOR_OSX || UNITY_STANDALONE_OSX
            webViewObject.bitmapRefreshCycle = 1;
#endif
            webViewObject.SetMargins(10, 200, 10, 200);
            webViewObject.SetVisibility(true);
            webViewObject.gameObject.SetActive(false);
            */

/*            // TODO:1-1-7追加　メインメニュー処理修正
            Button obj_setting_OK = bs_setting_OK.transform.GetComponent<Button>();
            obj_setting_OK.onClick.AddListener(() => ButtonSettingOKClick());

            Button obj_setting_CANCEL = bs_setting_cancel.transform.GetComponent<Button>();
            obj_setting_CANCEL.onClick.AddListener(() => ButtonSettingCANCELClick());

            Button obj_setting_reset = bs_setting_reset.transform.GetComponent<Button>();
            obj_setting_reset.onClick.AddListener(() => ButtonSettingRESETClick());
*/
        }
        /*
                // TODO:AD バナー広告の初期化
                private BannerView bannerView;
                // AdMob init.
                private void RequestBanner()
                {
                    // Banner ID.
                    // TODO::リリース時必ずIDを本番用に変更する事
        #if UNITY_ANDROID
                    string adUnitId = "ca-app-pub-3940256099942544/6300978111";
        #elif UNITY_IPHONE
                    string adUnitId = "ca-app-pub-3940256099942544/2934735716";
        #else
                    string adUnitId = "unexpected_platform";
        #endif
                    // Clean up banner ad before creating a new one.
                    if (this.bannerView != null)
                    {
                        this.bannerView.Destroy();
                    }
                    // Calculates the width of the screen (safe area where available) in points.
                    float widthInPixels =
                            Screen.safeArea.width > 0 ? Screen.safeArea.width : Screen.width;
                    int width = (int)(widthInPixels / MobileAds.Utils.GetDeviceScale());
                    MonoBehaviour.print("requesting width: " + width.ToString());
                    AdSize adaptiveSize =
                            AdSize.GetCurrentOrientationAnchoredAdaptiveBannerAdSizeWithWidth(width);

                    this.bannerView = new BannerView(adUnitId, adaptiveSize, AdPosition.Bottom);

                    // Called when an ad request has successfully loaded.
                    this.bannerView.OnAdLoaded += this.HandleOnAdLoaded;
                    // Called when an ad request failed to load.
                    this.bannerView.OnAdFailedToLoad += this.HandleOnAdFailedToLoad;
                    // Called when an ad is clicked.
                    this.bannerView.OnAdOpening += this.HandleOnAdOpened;
                    // Called when the user returned from the app after an ad click.
                    this.bannerView.OnAdClosed += this.HandleOnAdClosed;
                    // Called when the ad click caused the user to leave the application.
                    this.bannerView.OnAdLeavingApplication += this.HandleOnAdLeavingApplication;

                    // Create an empty ad request.
                    AdRequest request = new AdRequest.Builder()
                        //.AddTestDevice(AdRequest.TestDeviceSimulator)
                        .AddTestDevice("2077ef9a63d2b398840261c8221a0c9b")  // TODO::リリース時必ず削除する事
                        .Build();

                    // Load the banner with the request.
                    this.bannerView.LoadAd(request);
                }
                public void HandleOnAdLoaded(object sender, EventArgs args)
                {
                    Debug.Log("HandleAdLoaded event received");
                }

                public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
                {
                    Debug.Log("HandleFailedToReceiveAd event received with message: "
                                        + args.Message);
                }

                public void HandleOnAdOpened(object sender, EventArgs args)
                {
                    // Banner click timer stop!!
                    emitter.sw_stop = true;
                    Debug.Log("HandleAdOpened event received");
                }

                public void HandleOnAdClosed(object sender, EventArgs args)
                {
                    Debug.Log("HandleAdClosed event received");
                }

                public void HandleOnAdLeavingApplication(object sender, EventArgs args)
                {
                    // Banner click timer stop!!
                    emitter.sw_stop = true;
                    Debug.Log("HandleAdLeavingApplication event received");
                }
        */

        // TODO:AD インタースティシャル広告表示
        // インターステイシャル初期化
        /*private InterstitialAd interstitial;

        private void RequestInterstitial()
        {
#if UNITY_ANDROID
        string adUnitId = "ca-app-pub-3940256099942544/1033173712";
#elif UNITY_IPHONE
            string adUnitId = "ca-app-pub-3940256099942544/4411468910";
#else
        string adUnitId = "unexpected_platform";
#endif

            // Initialize an InterstitialAd.
            this.interstitial = new InterstitialAd(adUnitId);

            // Called when an ad request has successfully loaded.
            this.interstitial.OnAdLoaded += HandleOnAdLoadedInter;
            // Called when an ad request failed to load.
            this.interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoadInter;
            // Called when an ad is shown.
            this.interstitial.OnAdOpening += HandleOnAdOpenedInter;
            // Called when the ad is closed.
            this.interstitial.OnAdClosed += HandleOnAdClosedInter;
            // Called when the ad click caused the user to leave the application.
            this.interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplicationInter;

            // Create an empty ad request.
            AdRequest request = new AdRequest.Builder().Build();
            // Load the interstitial with the request.
            this.interstitial.LoadAd(request);
        }

        public void HandleOnAdLoadedInter(object sender, EventArgs args)
        {
            Debug.Log("HandleAdLoadedInter event received");
            this.interstitial.Show();
        }

        public void HandleOnAdFailedToLoadInter(object sender, AdFailedToLoadEventArgs args)
        {
            Debug.Log("HandleFailedToReceiveAdInter event received with message: "
                                + args.Message);
            interstitial.Destroy();
            if (sw_gameEndButton == 1)
            {
                ButtonGameEndNewGameClick();
            }
            else
            {
                ButtonGameEndRetryClick();
            }
        }

        public void HandleOnAdOpenedInter(object sender, EventArgs args)
        {
            Debug.Log("HandleAdOpenedInter event received");
        }

        public void HandleOnAdClosedInter(object sender, EventArgs args)
        {
            Debug.Log("HandleAdClosedInter event received");
            interstitial.Destroy();
            if (sw_gameEndButton == 1)
            {
                ButtonGameEndNewGameClick();
            }
            else
            {
                ButtonGameEndRetryClick();
            }
        }

        public void HandleOnAdLeavingApplicationInter(object sender, EventArgs args)
        {
            Debug.Log("HandleAdLeavingApplicationInter event received");
        }
*/



        // set chainExplosionStarEffectPosition
        [SerializeField]
        static VideoPlayer videoPlayer;
        public static void showChainExplosionCounterPanelEffect(monster_color color) {
            var seq = DOTween.Sequence();
            Vector2 scale;
            switch (cubersFile.game_Sceen)
            {
                case 0:
                    greenMonsterStarImage_s.gameObject.SetActive(true);
                    Vector3 monsterCounterPosition = new Vector3(0.0f, 0.0f, 0.0f);

                    switch (color)
                    {
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
                    monsterCounterPosition.x += 15;
                    monsterCounterPosition.y += 40;
                    greenMonsterStarImage_s.rectTransform.position = monsterCounterPosition;
                    scale = greenMonsterStarImage_s.rectTransform.localScale;
                    scale.x = 0.1f;
                    scale.y = 0.1f;
                    greenMonsterStarImage_s.rectTransform.localScale = scale;
                    greenMonsterStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

                    seq = DOTween.Sequence();
                    seq.Append(greenMonsterStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                    seq.Join(greenMonsterStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                        2.0f                    // アニメーション時間
                    ));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる
                        greenMonsterStarImage_s.gameObject.SetActive(false);
                    });
                    break;
                case 2:
                    // スライム連鎖時のカウンターパネルでのダメージビデオ再生処理
                    int stage = (int)cubersFile.now_play_stage;
                    switch (color)
                    {
                        case monster_color.green_monster:
                            switch (stage)
                            {
                                case 1:
                                case 2:
                                    greenMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_greenMonsterSlimeVideoClip1;
                                    break;
                                case 3:
                                case 4:
                                    greenMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_greenMonsterSlimeVideoClip2;
                                    break;
                                case 5:
                                case 6:
                                    greenMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_greenMonsterSlimeVideoClip3;
                                    break;
                                default:
                                    break;
                            }
                            greenMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            greenMonsterSlimeCountbadgeImage_s.gameObject.SetActive(true);

                            videoPlayer = greenMonsterSlimeVideoView_s.gameObject.GetComponent<VideoPlayer>();
                            videoPlayer.loopPointReached += LoopPointReached;
                            videoPlayer.Play();

                            scale = greenMonsterSlimeStarImage_s.rectTransform.localScale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            greenMonsterSlimeStarImage_s.rectTransform.localScale = scale;
                            greenMonsterSlimeStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                            seq = DOTween.Sequence();
                            seq.Append(greenMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.3f, 1.3f), 1.0f));
                            seq.Join(greenMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                            seq.Join(greenMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.Append(greenMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(greenMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(greenMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.OnComplete(() =>
                            {
                                // アニメーションが終了時によばれる
                                greenMonsterSlimeVideoView_s.gameObject.SetActive(false);
                            });
                            break;
                        case monster_color.yellow_monster:
                            switch (stage)
                            {
                                case 1:
                                case 2:
                                    yellowMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_yellowMonsterSlimeVideoClip1;
                                    break;
                                case 3:
                                case 4:
                                    yellowMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_yellowMonsterSlimeVideoClip2;
                                    break;
                                case 5:
                                case 6:
                                    yellowMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_yellowMonsterSlimeVideoClip3;
                                    break;
                                default:
                                    break;
                            }
                            yellowMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            yellowMonsterSlimeCountbadgeImage_s.gameObject.SetActive(true);

                            videoPlayer = yellowMonsterSlimeVideoView_s.gameObject.GetComponent<VideoPlayer>();
                            videoPlayer.loopPointReached += LoopPointReached;
                            videoPlayer.Play();

                            scale = yellowMonsterSlimeStarImage_s.rectTransform.localScale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            yellowMonsterSlimeStarImage_s.rectTransform.localScale = scale;
                            yellowMonsterSlimeStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                            seq = DOTween.Sequence();
                            seq.Append(yellowMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.3f, 1.3f), 1.0f));
                            seq.Join(yellowMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                            seq.Join(yellowMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.Append(yellowMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(yellowMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(yellowMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.OnComplete(() =>
                            {
                                // アニメーションが終了時によばれる
                                yellowMonsterSlimeVideoView_s.gameObject.SetActive(false);
                            });
                            break;
                        case monster_color.orange_monster:
                            //blueMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            break;
                        case monster_color.red_monster:
                            switch (stage)
                            {
                                case 1:
                                case 2:
                                    redMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_redMonsterSlimeVideoClip1;
                                    break;
                                case 3:
                                case 4:
                                    redMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_redMonsterSlimeVideoClip2;
                                    break;
                                case 5:
                                case 6:
                                    redMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_redMonsterSlimeVideoClip3;
                                    break;
                                default:
                                    break;
                            }
                            redMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            redMonsterSlimeCountbadgeImage_s.gameObject.SetActive(true);

                            videoPlayer = redMonsterSlimeVideoView_s.gameObject.GetComponent<VideoPlayer>();
                            videoPlayer.loopPointReached += LoopPointReached;
                            videoPlayer.Play();

                            scale = redMonsterSlimeStarImage_s.rectTransform.localScale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            redMonsterSlimeStarImage_s.rectTransform.localScale = scale;
                            redMonsterSlimeStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                            seq = DOTween.Sequence();
                            seq.Append(redMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.3f, 1.3f), 1.0f));
                            seq.Join(redMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                            seq.Join(redMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.Append(redMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(redMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(redMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.OnComplete(() =>
                            {
                                // アニメーションが終了時によばれる
                                redMonsterSlimeVideoView_s.gameObject.SetActive(false);
                            });
                            break;
                        case monster_color.purple_monster:
                            switch (stage)
                            {
                                case 1:
                                case 2:
                                    purpleMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_purpleMonsterSlimeVideoClip1;
                                    break;
                                case 3:
                                case 4:
                                    purpleMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_purpleMonsterSlimeVideoClip2;
                                    break;
                                case 5:
                                case 6:
                                    purpleMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_purpleMonsterSlimeVideoClip3;
                                    break;
                                default:
                                    break;
                            }
                            purpleMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            purpleMonsterSlimeCountbadgeImage_s.gameObject.SetActive(true);

                            videoPlayer = purpleMonsterSlimeVideoView_s.gameObject.GetComponent<VideoPlayer>();
                            videoPlayer.loopPointReached += LoopPointReached;
                            videoPlayer.Play();

                            scale = purpleMonsterSlimeStarImage_s.rectTransform.localScale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            purpleMonsterSlimeStarImage_s.rectTransform.localScale = scale;
                            purpleMonsterSlimeStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                            seq = DOTween.Sequence();
                            seq.Append(purpleMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.3f, 1.3f), 1.0f));
                            seq.Join(purpleMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                            seq.Join(purpleMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.Append(purpleMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(purpleMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(purpleMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.OnComplete(() =>
                            {
                                // アニメーションが終了時によばれる
                                purpleMonsterSlimeVideoView_s.gameObject.SetActive(false);
                            });
                            break;
                        case monster_color.blue_monster:
                            switch (stage)
                            {
                                case 1:
                                case 2:
                                    blueMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_blueMonsterSlimeVideoClip1;
                                    break;
                                case 3:
                                case 4:
                                    blueMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_blueMonsterSlimeVideoClip2;
                                    break;
                                case 5:
                                case 6:
                                    blueMonsterSlimeVideoView_s.GetComponent<VideoPlayer>().clip = s_blueMonsterSlimeVideoClip3;
                                    break;
                                default:
                                    break;
                            }
                            blueMonsterSlimeVideoView_s.gameObject.SetActive(true);
                            blueMonsterSlimeCountbadgeImage_s.gameObject.SetActive(true);

                            videoPlayer = blueMonsterSlimeVideoView_s.gameObject.GetComponent<VideoPlayer>();
                            videoPlayer.loopPointReached += LoopPointReached;
                            videoPlayer.Play();

                            scale = blueMonsterSlimeStarImage_s.rectTransform.localScale;
                            scale.x = 0.1f;
                            scale.y = 0.1f;
                            blueMonsterSlimeStarImage_s.rectTransform.localScale = scale;
                            blueMonsterSlimeStarImage_s.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
                            seq = DOTween.Sequence();
                            seq.Append(blueMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.3f, 1.3f), 1.0f));
                            seq.Join(blueMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                            seq.Join(blueMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.Append(blueMonsterSlimeCountView_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(blueMonsterSlimeStarImage_s.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
                            seq.Join(blueMonsterSlimeStarImage_s.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                                1.0f                    // アニメーション時間
                            ));
                            seq.OnComplete(() =>
                            {
                                // アニメーションが終了時によばれる
                                blueMonsterSlimeVideoView_s.gameObject.SetActive(false);
                            });
                            break;
                        default:
                            break;
                    }
                    break;
            }
				
		}
        // 動画再生完了時の処理
        // アニメーションが終了時によばれる Todo: 呼ばれたり呼ばれられなかったりとするので
        // resetChainExplosionMonsterColorCountView()に処理をうつした！
        public static void LoopPointReached(VideoPlayer vp)
        {

            //greenMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            //yellowMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            //redMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            //purpleMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
            //blueMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);

        }
        // Credit CountImage init.
        public static void creditCountImageInit(int cubecount) {
            switch (cubersFile.game_Sceen)
            {
                case 0:
                    switch (cubecount)
                    {
                        case 3:
                            s_life_icon1_BG.gameObject.SetActive(true);
                            s_life_icon2_BG.gameObject.SetActive(true);
                            s_life_icon3_BG.gameObject.SetActive(true);
                            s_life_icon4_BG.gameObject.SetActive(false);
                            s_life_icon5_BG.gameObject.SetActive(false);
                            break;
                        case 4:
                            s_life_icon1_BG.gameObject.SetActive(true);
                            s_life_icon2_BG.gameObject.SetActive(true);
                            s_life_icon3_BG.gameObject.SetActive(true);
                            s_life_icon4_BG.gameObject.SetActive(true);
                            s_life_icon5_BG.gameObject.SetActive(false);
                            break;
                        case 5:
                            s_life_icon1_BG.gameObject.SetActive(true);
                            s_life_icon2_BG.gameObject.SetActive(true);
                            s_life_icon3_BG.gameObject.SetActive(true);
                            s_life_icon4_BG.gameObject.SetActive(true);
                            s_life_icon5_BG.gameObject.SetActive(true);
                            break;
                        default:
                            s_life_icon1_BG.gameObject.SetActive(false);
                            s_life_icon2_BG.gameObject.SetActive(false);
                            s_life_icon3_BG.gameObject.SetActive(false);
                            s_life_icon4_BG.gameObject.SetActive(false);
                            s_life_icon5_BG.gameObject.SetActive(false);
                            break;
                    }
                    break;

                case 2:
                    switch (cubecount)
                    {
                        case 3:
                            s_life_hearticon1.gameObject.SetActive(true);
                            s_life_hearticon2.gameObject.SetActive(true);
                            s_life_hearticon3.gameObject.SetActive(true);
                            s_life_hearticon4.gameObject.SetActive(false);
                            s_life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 4:
                            s_life_hearticon1.gameObject.SetActive(true);
                            s_life_hearticon2.gameObject.SetActive(true);
                            s_life_hearticon3.gameObject.SetActive(true);
                            s_life_hearticon4.gameObject.SetActive(true);
                            s_life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 5:
                            s_life_hearticon1.gameObject.SetActive(true);
                            s_life_hearticon2.gameObject.SetActive(true);
                            s_life_hearticon3.gameObject.SetActive(true);
                            s_life_hearticon4.gameObject.SetActive(true);
                            s_life_hearticon5.gameObject.SetActive(true);
                            break;
                        default:
                            s_life_hearticon1.gameObject.SetActive(false);
                            s_life_hearticon2.gameObject.SetActive(false);
                            s_life_hearticon3.gameObject.SetActive(false);
                            s_life_hearticon4.gameObject.SetActive(false);
                            s_life_hearticon5.gameObject.SetActive(false);
                            break;
                    }
                    break;
            }
				
			
		}

        // 取得アイテム表示
        public void showGetItem(int golditem, int silveritem)
        {
            for(int i = 0; i < goldItemArray.Length; i++)
            {
                if (i < golditem)
                {
                    goldItemArray[i].GetComponent<Image>().color = new Color(255.0f/255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
                }
                else
                {
                    goldItemArray[i].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 0.4f);
                }
                if (i < silveritem)
                {
                    silverItemArray[i].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 1.0f);
                }
                else
                {
                    silverItemArray[i].GetComponent<Image>().color = new Color(255.0f / 255.0f, 255.0f / 255.0f, 255.0f / 255.0f, 0.4f);
                }
            }
        }

        private void setChainGetitemArray()
        {
            goldItemArray = new Image[10];
            silverItemArray = new Image[10];

            goldItemArray[0] = goldItem_1;
            goldItemArray[1] = goldItem_2;
            goldItemArray[2] = goldItem_3;
            goldItemArray[3] = goldItem_4;
            goldItemArray[4] = goldItem_5;
            goldItemArray[5] = goldItem_6;
            goldItemArray[6] = goldItem_7;
            goldItemArray[7] = goldItem_8;
            goldItemArray[8] = goldItem_9;
            goldItemArray[9] = goldItem_10;

            silverItemArray[0] = silverItem_1;
            silverItemArray[1] = silverItem_2;
            silverItemArray[2] = silverItem_3;
            silverItemArray[3] = silverItem_4;
            silverItemArray[4] = silverItem_5;
            silverItemArray[5] = silverItem_6;
            silverItemArray[6] = silverItem_7;
            silverItemArray[7] = silverItem_8;
            silverItemArray[8] = silverItem_9;
            silverItemArray[9] = silverItem_10;
        }

        // TODO:連鎖　MAX chain count情報及び取得予定アイテム数表示の拡大表示をノーマル表示に戻す処理
        public static void chainInfoEffectDSPOff()
        {
            /*
            Vector3 scal = s_silver_item_GET_BG.transform.localScale;
            scal.x = m_hit_reset;
            scal.y = m_hit_reset;
            scal.z = m_hit_reset;
            s_silver_item_GET_BG.transform.localScale = scal;

            Vector3 scal_max = s_max_chain_count_BG.transform.localScale;
            scal_max.x = m_hit_reset;
            scal_max.y = m_hit_reset;
            scal_max.z = m_hit_reset;
            s_max_chain_count_BG.transform.localScale = scal_max;
            */
        }
        // TODO:連鎖　MAX chain count情報及び取得予定アイテム数表示の拡大表示処理
        public void chainInfoEffectDSP()
        {

            // MAX連鎖総数check&DSP
            if (s_max_chain_count_text.text == "")
            {
                s_max_chain_count_text.text = "0";
            }
            if (int.Parse(s_max_chain_count_text.text) < emitter.chainExplosionLinePlayMAX)
            {
                s_max_chain_count_text.text = emitter.chainExplosionLinePlayMAX.ToString();
            }

            // 連鎖総数チェック
            String sprite_s = "";
            int slim_count = 0;
            int max_chain_count = 0;
            int jewelry_count = 0;
            if (emitter.green_OneFallChainCount > 0)
            {
                sprite_s = "<sprite=0>";
                slim_count = 1;
                max_chain_count = emitter.green_OneFallChainCount;
            }
            if (emitter.yellow_OneFallChainCount > 0)
            {
                String st = "<sprite=1>";
                sprite_s += st;
                slim_count++;
                if (max_chain_count < emitter.yellow_OneFallChainCount)
                {
                    max_chain_count = emitter.yellow_OneFallChainCount;
                }
            }
            if (emitter.red_OneFallChainCount > 0)
            {
                String st = "<sprite=2>";
                sprite_s += st;
                slim_count++;
                if (max_chain_count < emitter.red_OneFallChainCount)
                {
                    max_chain_count = emitter.red_OneFallChainCount;
                }
            }
            if (emitter.purple_OneFallChainCount > 0)
            {
                String st = "<sprite=3>";
                sprite_s += st;
                slim_count++;
                if (max_chain_count < emitter.purple_OneFallChainCount)
                {
                    max_chain_count = emitter.purple_OneFallChainCount;
                }
            }
            if (emitter.blue_OneFallChainCount > 0)
            {
                String st = "<sprite=4>";
                sprite_s += st;
                slim_count++;
                if (max_chain_count < emitter.blue_OneFallChainCount)
                {
                    max_chain_count = emitter.blue_OneFallChainCount;
                }
            }

            // slim 3種以上で同時連鎖　slim種数分魔法数ゲット！
            if (slim_count >= 3)
            {
                jewelry_count = slim_count;
            }
            //  MAX連鎖数6以上 スライム複数でその総数のmax_chain_countが６以上もあり - 5の魔法石Get!
            if (max_chain_count >= 6)
            //if (max_chain_count >= 1)
            {
                // slim 3種以上の場合もあるので加算
                //jewelry_count += max_chain_count;
                jewelry_count += max_chain_count - 5;
            }
            // 取得jewelry無しの場合は、表示しない
            if (jewelry_count <= 0)
            {
                jewelry_count = 0;
                return;
            }
            // 各スライム連鎖カウントリセット
            emitter.green_OneFallChainCount = 0;
            emitter.yellow_OneFallChainCount = 0;
            emitter.red_OneFallChainCount = 0;
            emitter.purple_OneFallChainCount = 0;
            emitter.blue_OneFallChainCount = 0;

            // 取得jewelryありの場合
            itemGetIcon.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = sprite_s;
            itemGetTitle.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = slim_count.ToString() + " Slim " + max_chain_count.ToString() + " Chain";
            itemGetMessage.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = " x   " + jewelry_count.ToString();

            // play get total jewelry Count -> game complete時に　jewelry_Count_totalがcubeFile.jewelry_Count に加算される
            emitter.jewelry_Count_total += jewelry_count;

            //  SunShain disp.
            Vector2 scale1 = itemGetView_BG.rectTransform.localScale;
            scale1.x = 0.1f;
            scale1.y = 0.1f;
            itemGetView_BG.rectTransform.localScale = scale1;
            itemGetView_BG.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

            var seq1 = DOTween.Sequence();
            seq1.Append(itemGetView_BG.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 2.0f));
            seq1.Join(itemGetView_BG.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                2.0f                    // アニメーション時間
            ));
            seq1.OnComplete(() => {
                // アニメーションが終了時によばれる
            });

            // Star Dsp.
            Vector2 scale2 = jewelry_get_star.rectTransform.localScale;
            scale2.x = 0.1f;
            scale2.y = 0.1f;
            jewelry_get_star.rectTransform.localScale = scale2;
            jewelry_get_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
            var seq2 = DOTween.Sequence();
            seq2.Append(jewelry_get_star.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
            seq2.Join(jewelry_get_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                2.0f                    // アニメーション時間
            ));
            jewelry_get_star.gameObject.SetActive(true);
            seq2.OnComplete(() => {
                // アニメーションが終了時によばれる
                jewelry_get_star.gameObject.SetActive(false);
            });

            /*// ジュエリーカウントアップエフェクト表示
            var seq = DOTween.Sequence();
            seq.Append(jewelryCountIcon.transform.DOScale(new Vector3(1.5f, 1.5f), 0.5f));
            seq.Append(jewelryCountIcon.transform.DOScale(new Vector3(1.5f, 1.5f), 2.0f));
            seq.OnComplete(() =>
            {
                // アニメーションが終了時によばれる
                Vector3 scal = jewelryCountIcon.gameObject.transform.localScale;
                scal.x = 1.0f;
                scal.y = 1.0f;
                jewelryCountIcon.gameObject.transform.localScale = scal;
            });
            //  star disp.
            Vector2 scale1 = jewelryCountStarIcon.rectTransform.localScale;
            scale1.x = 0.1f;
            scale1.y = 0.1f;
            jewelryCountStarIcon.rectTransform.localScale = scale1;
            jewelryCountStarIcon.rectTransform.rotation = Quaternion.Euler(0, 0, 0);
            jewelryCountStarIcon.gameObject.SetActive(true);

            var seq1 = DOTween.Sequence();
            seq1.Append(jewelryCountStarIcon.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
            seq1.Join(jewelryCountStarIcon.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                2.0f                    // アニメーション時間
            ));
            seq1.OnComplete(() => {
                // アニメーションが終了時によばれる
                jewelryCountStarIcon.gameObject.SetActive(false);
            });
            */
            // ジュエリーアイテムゲットメッセージ表示
            itemGetView.gameObject.SetActive(true);

            Vector3 scal_igt = itemGetView.transform.localScale;
            var seq3 = DOTween.Sequence();
            seq3.Append(itemGetView.transform.DOScale(new Vector3(scal_igt.x, scal_igt.y), 2.0f));
            seq3.OnComplete(() =>
            {
                // アニメーションが終了時によばれる
                itemGetView.gameObject.SetActive(false);
            });


            ////s_max_chain_count_BG.gameObject.SetActive(true);
            ////s_silver_item_GET_BG.gameObject.SetActive(true);
            ///*
            //Vector3 scal = s_silver_item_GET_BG.transform.localScale;
            //scal.x = m_hit_zoom;
            //scal.y = m_hit_zoom;
            //scal.z = m_hit_zoom;
            //s_silver_item_GET_BG.transform.localScale = scal;
            //*/
            //s_silver_item_get_text.text = "✖︎　" + emitter.chainExplosionLinePlayCount.ToString();
        }




        public const float m_hit_zoom = 1.2f;
		public const float m_hit_reset = 1.0f;
        //
        // モンスターカラーカウント表示 updataで毎回呼ばれる　連鎖時にON/OFFされアイコン強調表示制御も行われる
        public void monsterColorCount() {

            // TODO:連鎖仕様変更に伴い下記未使用　確認後削除！！
			// 連鎖時のボーナス加算あり？
			if (emitter.chainExplosionLineCount >= 2) {
				item_bonus.sprite = item_bonusCountImage;
				int kk = 2;
				string st = @"D" + kk.ToString();
				int val = (int) emitter.chainExplosionLineCount * 10;
				string str = val.ToString(st);
				item_bonusCount.text = str + "p";
			}

//			int k = 1;
//			string st0 = @"D" + k.ToString();
//			int val0 = (int) emitter.chainExplosionPoint;
//			string str0 = val0.ToString(st0);
			//残り表示
			chainExplosionZanCount();

			if (blueMonsterCountON) {
//				int cnt = monster.monster_instance.get_monsterColorCount(monster_color.blue_monster);
				blueMonsterCountImage.sprite = monsterCountHighImage;
//				if (cnt <= 0) blueMonsterCountImage.sprite = monsterCountBaseImage;
				Vector3 scal = blueMonsterCountImage.transform.localScale;
				scal.x = m_hit_zoom;
				scal.y = m_hit_zoom;
				scal.z = m_hit_zoom;
				blueMonsterCountImage.transform.localScale = scal;
//				blueMonsterCountImage.material = chainExplosionCounterHighLightM;
//				blueMonsterPoint.text = "";
//				blueMonsterLabel.text = "";
//				monsterZanCount();
//				blueMonsterPoint.text = str0 + "p";
//				blueMonsterLabel.text = "Monster";
			}
			else if (greenMonsterCountON) {
//				int cnt = monster.monster_instance.get_monsterColorCount(monster_color.green_monster);
				greenMonsterCountImage.sprite = monsterCountHighImage;
//				if (cnt <= 0) greenMonsterCountImage.sprite = monsterCountBaseImage;
//				else greenMonsterCountImage.sprite = monsterCountHighImage;
				Vector3 scal = greenMonsterCountImage.transform.localScale;
				scal.x = m_hit_zoom;
				scal.y = m_hit_zoom;
				scal.z = m_hit_zoom;
				greenMonsterCountImage.transform.localScale = scal;
//				greenMonsterCountImage.material = chainExplosionCounterHighLightM;
//				greenMonsterCount.text = "";
//				greenMonsterPoint.text = "";
//				greenMonsterLabel.text = "";
//				monsterZanCount();
//				greenMonsterPoint.text = str0 + "p";
//				greenMonsterLabel.text = "Monster";
			}
			else if (purpleMonsterCountON) {
//				int cnt = monster.monster_instance.get_monsterColorCount(monster_color.purple_monster);
				purpleMonsterCountImage.sprite = monsterCountHighImage;
//				if (cnt <= 0) purpleMonsterCountImage.sprite = monsterCountBaseImage;
				Vector3 scal = purpleMonsterCountImage.transform.localScale;
				scal.x = m_hit_zoom;
				scal.y = m_hit_zoom;
				scal.z = m_hit_zoom;
				purpleMonsterCountImage.transform.localScale = scal;
//				purpleMonsterCountImage.material = chainExplosionCounterHighLightM;
//				purpleMonsterPoint.text = "";
//				purpleMonsterLabel.text = "";
//				monsterZanCount();
//				purpleMonsterPoint.text = str0 + "p";
//				purpleMonsterLabel.text = "Monster";
			}
			else if (redMonsterCountON) {
//				int cnt = monster.monster_instance.get_monsterColorCount(monster_color.red_monster);
				redMonsterCountImage.sprite = monsterCountHighImage;
//				if (cnt <= 0) redMonsterCountImage.sprite = monsterCountBaseImage;
				Vector3 scal = redMonsterCountImage.transform.localScale;
				scal.x = m_hit_zoom;
				scal.y = m_hit_zoom;
				scal.z = m_hit_zoom;
				redMonsterCountImage.transform.localScale = scal;
//				redMonsterCountImage.material = chainExplosionCounterHighLightM;
//				redMonsterPoint.text = "";
//				redMonsterLabel.text = "";
//				monsterZanCount();
//				redMonsterPoint.text = str0 + "p";
//				redMonsterLabel.text = "Monster";
			}
			else if (yellowMonsterCountON) {
//				int cnt = monster.monster_instance.get_monsterColorCount(monster_color.yellow_monster);
				yellowMonsterCountImage.sprite = monsterCountHighImage;
//				if (cnt <= 0) yellowMonsterCountImage.sprite = monsterCountBaseImage;
//				else yellowMonsterCountImage.sprite = monsterCountHighImage;
				Vector3 scal = yellowMonsterCountImage.transform.localScale;
				scal.x = m_hit_zoom;
				scal.y = m_hit_zoom;
				scal.z = m_hit_zoom;
				yellowMonsterCountImage.transform.localScale = scal;
//				yellowMonsterCountImage.material = chainExplosionCounterHighLightM;
//				yellowMonsterPoint.text = "";
//				yellowMonsterLabel.text = "";
//				monsterZanCount();
//				yellowMonsterPoint.text = str0 + "p";
//				yellowMonsterLabel.text = "Monster";
			}
			else {
				chainExplosionZanCount();
			}
		}

		void resetChainExplosionMonsterColorCountView() {

			item_bonus.sprite = item_bonusCount_offImage;
			item_bonusCount.text = "";
            // 連鎖　カラー別取得ポイントテキストクリア
            greenMonsterPoint.text = "";
			yellowMonsterPoint.text = "";
			redMonsterPoint.text = "";
			purpleMonsterPoint.text = "";
			blueMonsterPoint.text = "";

            int cnt_b = monster.monster_instance.get_monsterColorCount(monster_color.blue_monster);
            int cnt_g = monster.monster_instance.get_monsterColorCount(monster_color.green_monster);
            int cnt_y = monster.monster_instance.get_monsterColorCount(monster_color.yellow_monster);
            int cnt_r = monster.monster_instance.get_monsterColorCount(monster_color.red_monster);
            int cnt_p = monster.monster_instance.get_monsterColorCount(monster_color.purple_monster);
            Vector3 scal;
            switch (cubersFile.game_Sceen)
            {
                case 0:
                    scal = blueMonsterCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    blueMonsterCountImage.transform.localScale = scal;
                    if (cnt_b <= 0)
                    {
                        blueMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    else
                    {
                        blueMonsterCountImage.material = chainExplosionCounterM;
                        blueMonsterCountImage.sprite = monsterCountBaseImage;
                    }

                    scal = greenMonsterCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    greenMonsterCountImage.transform.localScale = scal;
                    if (cnt_g <= 0)
                    {
                        greenMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    else
                    {
                        greenMonsterCountImage.material = chainExplosionCounterM;
                        greenMonsterCountImage.sprite = monsterCountBaseImage;
                    }

                    scal = purpleMonsterCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    purpleMonsterCountImage.transform.localScale = scal;
                    if (cnt_p <= 0)
                    {
                        purpleMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    else
                    {
                        purpleMonsterCountImage.material = chainExplosionCounterM;
                        purpleMonsterCountImage.sprite = monsterCountBaseImage;
                    }

                    scal = redMonsterCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    redMonsterCountImage.transform.localScale = scal;
                    if (cnt_r <= 0)
                    {
                        redMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    else
                    {
                        redMonsterCountImage.material = chainExplosionCounterM;
                        redMonsterCountImage.sprite = monsterCountBaseImage;
                    }

                    scal = yellowMonsterCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    yellowMonsterCountImage.transform.localScale = scal;
                    if (cnt_y <= 0)
                    {
                        yellowMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    else
                    {
                        yellowMonsterCountImage.material = chainExplosionCounterM;
                        yellowMonsterCountImage.sprite = monsterCountBaseImage;
                    }
                    break;

                case 2:
                    //  game_sceen 2
                    scal = blueMonsterSlimeCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    blueMonsterSlimeCountImage.transform.localScale = scal;
                    scal = blueMonsterSlimeStarImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    blueMonsterSlimeStarImage.transform.localScale = scal;
                    if (cnt_b <= 0)
                    {
                        blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(true);
                    }
                    else
                    {
                        blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                    }

                    scal = greenMonsterSlimeCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    greenMonsterSlimeCountImage.transform.localScale = scal;
                    scal = greenMonsterSlimeStarImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    greenMonsterSlimeStarImage.transform.localScale = scal;
                    if (cnt_g <= 0)
                    {
                        greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(true);
                    }
                    else
                    {
                        greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                    }

                    scal = purpleMonsterSlimeCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    purpleMonsterSlimeCountImage.transform.localScale = scal;
                    scal = purpleMonsterSlimeStarImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    purpleMonsterSlimeStarImage.transform.localScale = scal;
                    if (cnt_p <= 0)
                    {
                        purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(true);
                    }
                    else
                    {
                        purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                    }

                    scal = redMonsterSlimeCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    redMonsterSlimeCountImage.transform.localScale = scal;
                    scal = redMonsterSlimeStarImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    redMonsterSlimeStarImage.transform.localScale = scal;
                    if (cnt_r <= 0)
                    {
                        redMonsterSlimeCountMaskImage_s.gameObject.SetActive(true);
                    }
                    else
                    {
                        redMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                    }

                    scal = yellowMonsterSlimeCountImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    yellowMonsterSlimeCountImage.transform.localScale = scal;
                    scal = yellowMonsterSlimeStarImage.transform.localScale;
                    scal.x = m_hit_reset;
                    scal.y = m_hit_reset;
                    scal.z = m_hit_reset;
                    yellowMonsterSlimeStarImage.transform.localScale = scal;
                    if (cnt_y <= 0)
                    {
                        yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(true);
                    }
                    else
                    {
                        yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                    }

                    // TODO:動画再生終了の検知が上手くできていないので、ここでバッジ及びスターエフェクトビューのOFFを行う
                    greenMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
                    yellowMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
                    redMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
                    purpleMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);
                    blueMonsterSlimeCountbadgeImage_s.gameObject.SetActive(false);

                    // 連鎖時動画ビューOFF　ここでパネルリサイズ後にOFFする事でイメージ画像との繋ぎの不自然を少し解消させる
                    greenMonsterSlimeVideoView_s.gameObject.SetActive(false);
                    purpleMonsterSlimeVideoView_s.gameObject.SetActive(false);
                    redMonsterSlimeVideoView_s.gameObject.SetActive(false);
                    yellowMonsterSlimeVideoView_s.gameObject.SetActive(false);
                    blueMonsterSlimeVideoView_s.gameObject.SetActive(false);

                    //greenMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    //yellowMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    //redMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    //purpleMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    //blueMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    //whiteMonsterSlimeCountImage_s.canvas.sortingOrder = 1;
                    break;

            }

			chainExplosionZanCount();
		}


        // 連鎖残り数表示
        public void chainExplosionZanCount() {
            int green = monster.monster_instance.getChainExplosionLineCount(monster_color.green_monster);
            int yellow = monster.monster_instance.getChainExplosionLineCount(monster_color.yellow_monster);
            int purple = monster.monster_instance.getChainExplosionLineCount(monster_color.purple_monster);
            int red = monster.monster_instance.getChainExplosionLineCount(monster_color.red_monster);
            int blue = monster.monster_instance.getChainExplosionLineCount(monster_color.blue_monster);

            switch (cubersFile.game_Sceen)
            {
                case 0:
                    if (green > 0)
                    {
                        greenMonsterCount.text = green.ToString();
                        greenMonsterLabel.text = "Line";

                        greenMonsterLineSliderCount.SetActive(true);
                        greenMonsterLineCount.GetComponent<Text>().text = green.ToString() + "/" + monster.level_Line_count;
                        greenMonsterLineSliderCount.GetComponent<Slider>().value = (float)green / (float)monster.level_Line_count;

                        //				greenMonsterCountImage.sprite = monsterCountBaseImage;
                    }
                    else
                    {
                        greenMonsterCount.text = "";
                        greenMonsterLabel.text = "";
                        greenMonsterLineCount.GetComponent<Text>().text = "";
                        greenMonsterLineSliderCount.GetComponent<Slider>().value = 0;
                        greenMonsterLineSliderCount.SetActive(false);
                        //				greenMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    if (yellow > 0)
                    {
                        yellowMonsterCount.text = yellow.ToString();
                        yellowMonsterLabel.text = "Line";

                        yellowMonsterLineSliderCount.SetActive(true);
                        yellowMonsterLineCount.GetComponent<Text>().text = yellow.ToString() + "/" + monster.level_Line_count;
                        yellowMonsterLineSliderCount.GetComponent<Slider>().value = (float)yellow / (float)monster.level_Line_count;
                        //				yellowMonsterCountImage.sprite = monsterCountBaseImage;
                    }
                    else
                    {
                        yellowMonsterCount.text = "";
                        yellowMonsterLabel.text = "";
                        yellowMonsterLineCount.GetComponent<Text>().text = "";
                        yellowMonsterLineSliderCount.GetComponent<Slider>().value = 0;
                        yellowMonsterLineSliderCount.SetActive(false);
                        //				yellowMonsterCountImage.sprite = monsterCountHighImage;
                    }
                    if (purple > 0)
                    {
                        purpleMonsterCount.text = purple.ToString();
                        purpleMonsterLabel.text = "Line";

                        purpleMonsterLineSliderCount.SetActive(true);
                        purpleMonsterLineCount.GetComponent<Text>().text = purple.ToString() + "/" + monster.level_Line_count;
                        purpleMonsterLineSliderCount.GetComponent<Slider>().value = (float)purple / (float)monster.level_Line_count;
                    }
                    else
                    {
                        purpleMonsterCount.text = "";
                        purpleMonsterLabel.text = "";
                        purpleMonsterLineCount.GetComponent<Text>().text = "";
                        purpleMonsterLineSliderCount.GetComponent<Slider>().value = 0;
                        purpleMonsterLineSliderCount.SetActive(false);
                    }
                    if (red > 0)
                    {
                        redMonsterCount.text = red.ToString();
                        redMonsterLabel.text = "Line";

                        redMonsterLineSliderCount.SetActive(true);
                        redMonsterLineCount.GetComponent<Text>().text = red.ToString() + "/" + monster.level_Line_count;
                        redMonsterLineSliderCount.GetComponent<Slider>().value = (float)red / (float)monster.level_Line_count;
                    }
                    else
                    {
                        redMonsterCount.text = "";
                        redMonsterLabel.text = "";
                        redMonsterLineCount.GetComponent<Text>().text = "";
                        redMonsterLineSliderCount.GetComponent<Slider>().value = 0;
                        redMonsterLineSliderCount.SetActive(false);
                    }
                    if (blue > 0)
                    {
                        blueMonsterCount.text = blue.ToString();
                        blueMonsterLabel.text = "Line";

                        blueMonsterLineSliderCount.SetActive(true);
                        blueMonsterLineCount.GetComponent<Text>().text = blue.ToString() + "/" + monster.level_Line_count;
                        blueMonsterLineSliderCount.GetComponent<Slider>().value = (float)blue / (float)monster.level_Line_count;
                    }
                    else
                    {
                        blueMonsterCount.text = "";
                        blueMonsterLabel.text = "";
                        blueMonsterLineCount.GetComponent<Text>().text = "";
                        blueMonsterLineSliderCount.GetComponent<Slider>().value = 0;
                        blueMonsterLineSliderCount.SetActive(false);
                    }
                    break;

                case 2:
                    if (green > 0)
                    {
                        greenMonsterSlimeCount.text = green.ToString();
                    }
                    else
                    {
                        greenMonsterSlimeCount.text = "";
                    }
                    if (yellow > 0)
                    {
                        yellowMonsterSlimeCount.text = yellow.ToString();
                    }
                    else
                    {
                        yellowMonsterSlimeCount.text = "";
                    }
                    if (purple > 0)
                    {
                        purpleMonsterSlimeCount.text = purple.ToString();
                    }
                    else
                    {
                        purpleMonsterSlimeCount.text = "";
                    }
                    if (red > 0)
                    {
                        redMonsterSlimeCount.text = red.ToString();
                    }
                    else
                    {
                        redMonsterSlimeCount.text = "";
                    }
                    if (blue > 0)
                    {
                        blueMonsterSlimeCount.text = blue.ToString();
                    }
                    else
                    {
                        blueMonsterSlimeCount.text = "";
                    }
                    break;
            }
		}
		// モンスター残り数表示
		public void monsterZanCount() {
			int green = monster.monster_instance.get_monsterColorCount(monster_color.green_monster);
			if (green > 0) greenMonsterCount.text = green.ToString();
			else greenMonsterCount.text = "";
			int yellow = monster.monster_instance.get_monsterColorCount(monster_color.yellow_monster);
			if (yellow > 0) yellowMonsterCount.text = yellow.ToString();
			else yellowMonsterCount.text = "";
			int purple = monster.monster_instance.get_monsterColorCount(monster_color.purple_monster);
			if (purple > 0) purpleMonsterCount.text = purple.ToString();
			else purpleMonsterCount.text = "";
			int red = monster.monster_instance.get_monsterColorCount(monster_color.red_monster);
			if (red > 0) redMonsterCount.text = red.ToString();
			else redMonsterCount.text = "";
			int blue = monster.monster_instance.get_monsterColorCount(monster_color.blue_monster);
			if (blue > 0) blueMonsterCount.text = blue.ToString();
			else blueMonsterCount.text = "";
		}
		// game center menu field set
		public static void setCenterView(int sw) {

			switch(sw) {
			// center view off
			case 0:
				bs_slimCard.gameObject.SetActive(false);
                // TODO:1-1-7削除　メインメニュー処理修正
                bs_new_game2.gameObject.SetActive(false);
                //bs_retry.gameObject.SetActive(false);
                bs_item.gameObject.SetActive(false);
                bs_setting.gameObject.SetActive(false);

//				s_center_waku.gameObject.SetActive(false);

				s_sunshine1.gameObject.SetActive(false);
				s_sunshine2.gameObject.SetActive(false);
				sunshinerotate = 0;
				break;

			 // main menu dsp
			case 1:
/*                var safeAreaHight = s_safeareaout_header_BG.rectTransform.sizeDelta.y * screen_width_per;

                Vector3 scal_c = s_center_View.transform.localScale;
                Vector3 pos_c = s_center_View.transform.position;
                pos_c.y = (Screen.height - safeAreaHight) / 2 - s_center_View.rectTransform.sizeDelta.y * scal_c.y / 2;
                s_center_View.transform.position = pos_c;
*/
                s_gameStatus_text.text = "";

                bs_slimCard.gameObject.SetActive(true);
                // TODO:1-1-7削除　メインメニュー処理修正
                bs_new_game2.gameObject.SetActive(true);
                //bs_retry.gameObject.SetActive(true);
                bs_item.gameObject.SetActive(true);
                bs_setting.gameObject.SetActive(true);

				s_center_View.gameObject.SetActive(true);

                break;
/*
			// Complete dsp
			case 2:
				s_gameTimeEnd_text.text = s_gameTime_text.text;
//				s_besttime_text.gameObject.SetActive(true);
//				s_bonus.gameObject.SetActive(true);
//				s_bonus_gold.gameObject.SetActive(true);
				
				Vector2 size1 = s_center_field.rectTransform.sizeDelta;
				size1.y = s_highscore_text.GetComponent<Text>().rectTransform.sizeDelta.y + s_playPoint_text.GetComponent<Text>().rectTransform.sizeDelta.y;
//				size1.y = s_besttime_text.rectTransform.sizeDelta.y + s_gameTimeEnd_text.rectTransform.sizeDelta.y + s_bonus.rectTransform.sizeDelta.y + s_bonus_gold.rectTransform.sizeDelta.y;
				s_center_field.rectTransform.sizeDelta = size1;
				Vector3 pos1 = s_center_field.transform.position;
				pos1.y = Screen.height/2 - (s_center_field.rectTransform.sizeDelta.y * screen_width_per /2);
				s_center_field.transform.position = pos1;
				
				sunshinerotate = 1;
				sunshinerotateTime = 10;
				sphere.timer = 8.5f;

				s_center_field.gameObject.SetActive(true);

				s_playPoint_text.GetComponent<Text>().text = sphere.point_count.ToString();
//				s_gameTimeEnd_text.text = s_gameTime_text.text;

				break;
*/
			}

		}
		// complete View
		public void setCompleteView (int sw) {
			switch(sw) {
			case 0:
                // ロストライフカウントView ON
                // ゲーム終了時の確認及び各処理内でセットしているので未使用
                s_LifeLostCount_text.GetComponent<Text>().text = (emitter.lost_count_MAX - sphere.lost_Spheres).ToString();
                break;
			case 1:
				// ハイスコアView ON
				// ゲーム終了時の確認及び各処理内でセットしているので未使用
				s_gameTimeEnd_text.text = s_gameTime_text.text;
				break;
			case 2:
				// View OFF
				besttime_text.gameObject.SetActive(false);
                lifeLostCount_Zero.gameObject.SetActive(false);
                max_chain_Mes_BG.gameObject.SetActive(false);
                get_Item_Mes_BG.gameObject.SetActive(false);
                stage_Clear_Info_view.gameObject.SetActive(false);
                break;
			}
		}

        // TODO:1-1-6 ゲームステージ選択メニュー画面修正
        // ステージ選択メニュー処理　-----------------------------------------------------------
        public Image clearlevel1_1Image;
        public Image clearlevel1_2Image;
        public Image clearlevel2_1Image;
        public Image clearlevel2_2Image;
        public Image clearlevel3_1Image;
        public Image clearlevel3_2Image;
        public Text cleartime1_1;
        public Text cleartime1_2;
        public Text cleartime2_1;
        public Text cleartime2_2;
        public Text cleartime3_1;
        public Text cleartime3_2;
        public Text totallost1_1_count;
        public Text totallost1_2_count;
        public Text totallost2_1_count;
        public Text totallost2_2_count;
        public Text totallost3_1_count;
        public Text totallost3_2_count;
        // ステージメニューの作成　gameselectView
        private void Create_GameSelectView() {

            // TODO:旧ステージセレクト関連
            selectView1_1.transform.tag = "1";
			selectView1_1.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView1_1.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView1_1));
            setGameData(selectView1_1,1);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(1);

            selectView1_2.transform.tag = "2";
            selectView1_2.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView1_2.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView1_2));
			setGameData(selectView1_2,2);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(2);

            selectView2_1.transform.tag = "3";
            selectView2_1.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView2_1.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView2_1));
			setGameData(selectView2_1,3);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(3);

            selectView2_2.transform.tag = "4";
            selectView2_2.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView2_2.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView2_2));
			setGameData(selectView2_2,4);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(4);

            selectView3_1.transform.tag = "5";
            selectView3_1.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView3_1.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView3_1));
			setGameData(selectView3_1,5);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(5);

            selectView3_2.transform.tag = "6";
            selectView3_2.GetComponent<Button>().onClick.RemoveAllListeners();
			selectView3_2.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell(selectView3_2));
			setGameData(selectView3_2,6);
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            setStageSelectBTTotalClearInfo(6);

        }
        private void Create_GameStageSelectView()
        {
            selectViewClose_BT.transform.tag = "99";
            selectViewClose_BT.GetComponent<Button>().onClick.RemoveAllListeners();
            selectViewClose_BT.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(1, 99));
            // TODO:newステージセレクト関連
            stage1_1_bt.transform.tag = "1";
            stage1_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage1_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(1, 1));
            setGameBadge(stage1_1_bt, 1, 1);

            stage1_2_bt.transform.tag = "2";
            stage1_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage1_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(1, 2));
            setGameBadge(stage1_2_bt, 1, 2);

            stage1_3_bt.transform.tag = "3";
            stage1_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage1_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(1, 3));
            setGameBadge(stage1_3_bt, 1, 3);

            stage2_1_bt.transform.tag = "4";
            stage2_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage2_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(2, 1));
            setGameBadge(stage2_1_bt, 2, 1);

            stage2_2_bt.transform.tag = "5";
            stage2_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage2_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(2, 2));
            setGameBadge(stage2_2_bt, 2, 2);

            stage2_3_bt.transform.tag = "6";
            stage2_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage2_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(2, 3));
            setGameBadge(stage2_3_bt, 2, 3);

            stage3_1_bt.transform.tag = "7";
            stage3_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage3_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(3, 1));
            setGameBadge(stage3_1_bt, 3, 1);

            stage3_2_bt.transform.tag = "8";
            stage3_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage3_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(3, 2));
            setGameBadge(stage3_2_bt, 3, 2);

            stage3_3_bt.transform.tag = "9";
            stage3_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage3_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(3, 3));
            setGameBadge(stage3_3_bt, 3, 3);

            stage4_1_bt.transform.tag = "10";
            stage4_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage4_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(4, 1));
            setGameBadge(stage4_1_bt, 4, 1);

            stage4_2_bt.transform.tag = "11";
            stage4_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage4_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(4, 2));
            setGameBadge(stage4_2_bt, 4, 2);

            stage4_3_bt.transform.tag = "12";
            stage4_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage4_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(4, 3));
            setGameBadge(stage4_3_bt, 4, 3);

            stage5_1_bt.transform.tag = "13";
            stage5_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage5_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(5, 1));
            setGameBadge(stage5_1_bt, 5, 1);

            stage5_2_bt.transform.tag = "14";
            stage5_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage5_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(5, 2));
            setGameBadge(stage5_2_bt, 5, 2);

            stage5_3_bt.transform.tag = "15";
            stage5_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage5_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(5, 3));
            setGameBadge(stage5_3_bt, 5, 3);

            stage6_1_bt.transform.tag = "16";
            stage6_1_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage6_1_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(6, 1));
            setGameBadge(stage6_1_bt, 6, 1);

            stage6_2_bt.transform.tag = "17";
            stage6_2_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage6_2_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(6, 2));
            setGameBadge(stage6_2_bt, 6, 2);

            stage6_3_bt.transform.tag = "18";
            stage6_3_bt.GetComponent<Button>().onClick.RemoveAllListeners();
            stage6_3_bt.GetComponent<Button>().onClick.AddListener(() => buttonSelectCell2(6, 3));
            setGameBadge(stage6_3_bt, 6, 3);

        }
            // TODO:new ゲームステージ選択メニュー画面修正
            /*        void setStageLevelSelectBTTotalClearInfo(int stageno, int level)
                    {
                        // トータルプレイ時間
                        long totalPlayTime = 0;
                        long totalLostCount = 0;

                        IDictionary dt = (IDictionary)cubersFile.stage[stageno - 1].leveldata[level - 1];
                        // プレイ時間（秒）
                        totalPlayTime += (long)dt["playtime"];
                        // トータルロストカウント
                        totalLostCount += (long)dt["lostcount"];
                        var span = new TimeSpan(0, 0, (int)totalPlayTime);
                        var hhmmss = span.ToString(@"hh\:mm\:ss");
                        switch (stageno)
                        {
                            case 1:
                                cleartime1_1.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost1_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                            case 2:
                                cleartime1_2.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost1_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                            case 3:
                                cleartime2_1.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost2_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                            case 4:
                                cleartime2_2.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost2_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                            case 5:
                                cleartime3_1.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost3_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                            case 6:
                                cleartime3_2.gameObject.GetComponent<Text>().text = hhmmss;
                                totallost3_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                                break;
                        }
                    }
            */
            // TODO:1-1-6 ゲームステージ選択メニュー画面修正
            void setStageSelectBTTotalClearInfo(int stageno)
        {
            // トータルプレイ時間
            long totalPlayTime = 0;
            long totalLostCount = 0;
            for (int i = 0; i < emitter.stageLevel_max; i++)
            {
                IDictionary dt = (IDictionary)cubersFile.stage[stageno - 1].leveldata[i];
                // プレイ時間（秒）
                totalPlayTime += (long)dt["playtime"];
                // トータルロストカウント
                totalLostCount += (long)dt["lostcount"];
            }
            var span = new TimeSpan(0, 0, (int)totalPlayTime);
            var hhmmss = span.ToString(@"hh\:mm\:ss");
            switch(stageno)
            {
                case 1:
                    cleartime1_1.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost1_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
                case 2:
                    cleartime1_2.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost1_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
                case 3:
                    cleartime2_1.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost2_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
                case 4:
                    cleartime2_2.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost2_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
                case 5:
                    cleartime3_1.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost3_1_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
                case 6:
                    cleartime3_2.gameObject.GetComponent<Text>().text = hhmmss;
                    totallost3_2_count.gameObject.GetComponent<Text>().text = totalLostCount.ToString();
                    break;
            }
        }


        // TODO:削除　1-1-1 1:現在のレベルメニューを削除しステージ選択からの遷移を取り止め　不要となったソース部分の削除
        /*        public Color selctstagecolor;
                // ステージメニューの作成
                private void Create_GameStageSelectView()
                {
                    int w_stage = (int)cubersFile.now_play_stage;
                    switch(w_stage)
                    {
                        case 1:
                        case 2:
                            selctstagecolor = new Color(0.58f, 1.0f, 0.58f);
                            break;
                        case 3:
                        case 4:
                            selctstagecolor = new Color(0.99f, 1.0f, 0.46f);
                            break;
                        case 5:
                        case 6:
                            selctstagecolor = new Color(1.0f, 0.48f, 0.48f);
                            break;
                    }

                    selectStageViewClose_BT.transform.tag = "99";
                    selectStageViewClose_BT.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageViewClose_BT.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageViewClose_BT));

                    selectStageView1.transform.tag = "1";
                    selectStageView1.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView1.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView1));
                    setStageGameData(selectStageView1, 1, selctstagecolor);

                    selectStageView2.transform.tag = "2";
                    selectStageView2.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView2.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView2));
                    setStageGameData(selectStageView2, 2, selctstagecolor);

                    selectStageView3.transform.tag = "3";
                    selectStageView3.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView3.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView3));
                    setStageGameData(selectStageView3, 3, selctstagecolor);

                    selectStageView4.transform.tag = "4";
                    selectStageView4.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView4.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView4));
                    setStageGameData(selectStageView4, 4, selctstagecolor);

                    selectStageView5.transform.tag = "5";
                    selectStageView5.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView5.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView5));
                    setStageGameData(selectStageView5, 5, selctstagecolor);

                    selectStageView6.transform.tag = "6";
                    selectStageView6.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView6.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView6));
                    setStageGameData(selectStageView6, 6, selctstagecolor);

                    selectStageView7.transform.tag = "7";
                    selectStageView7.GetComponent<Button>().onClick.RemoveAllListeners();
                    selectStageView7.GetComponent<Button>().onClick.AddListener(() => buttonStageSelectCell(selectStageView7));
                    setStageGameData(selectStageView7, 7, selctstagecolor);

                }
        */
        // ステージ選択ボタンマスクチェック＆バッジセット
        void setGameBadge(Button bt, int i, int level)
        {
            img = null;
            int laststage;
            for (int m = 0; m < cubersFile.game_stage_max; m++)
            {
                if (cubersFile.stage[m].stage_no == i)
                {
                    int sts = (int)cubersFile.stage[m].status;
                    laststage = (int)cubersFile.stage[m].last_level;
                    IDictionary dt = (IDictionary)cubersFile.stage[i - 1].leveldata[level - 1];
                    long levelstatus = (long)dt["status"];
                    switch (i)
                    {
                        // stage 1
                        case 1:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage1_1_bt.gameObject.SetActive(false);
                                        stage1_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage1_1_bt.gameObject.SetActive(true);
                                        stage1_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage1_2_bt.gameObject.SetActive(false);
                                        stage1_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage1_2_bt.gameObject.SetActive(true);
                                        stage1_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage1_3_bt.gameObject.SetActive(false);
                                        stage1_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage1_3_bt.gameObject.SetActive(true);
                                        stage1_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                        // stage 2
                        case 2:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage2_1_bt.gameObject.SetActive(false);
                                        stage2_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage2_1_bt.gameObject.SetActive(true);
                                        stage2_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage2_2_bt.gameObject.SetActive(false);
                                        stage2_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage2_2_bt.gameObject.SetActive(true);
                                        stage2_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage2_3_bt.gameObject.SetActive(false);
                                        stage2_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage2_3_bt.gameObject.SetActive(true);
                                        stage2_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                        // stage 3
                        case 3:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage3_1_bt.gameObject.SetActive(false);
                                        stage3_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage3_1_bt.gameObject.SetActive(true);
                                        stage3_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage3_2_bt.gameObject.SetActive(false);
                                        stage3_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage3_2_bt.gameObject.SetActive(true);
                                        stage3_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage3_3_bt.gameObject.SetActive(false);
                                        stage3_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage3_3_bt.gameObject.SetActive(true);
                                        stage3_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                        // stage 4
                        case 4:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage4_1_bt.gameObject.SetActive(false);
                                        stage4_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage4_1_bt.gameObject.SetActive(true);
                                        stage4_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage4_2_bt.gameObject.SetActive(false);
                                        stage4_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage4_2_bt.gameObject.SetActive(true);
                                        stage4_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage4_3_bt.gameObject.SetActive(false);
                                        stage4_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage4_3_bt.gameObject.SetActive(true);
                                        stage4_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                        // stage 5
                        case 5:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage5_1_bt.gameObject.SetActive(false);
                                        stage5_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage5_1_bt.gameObject.SetActive(true);
                                        stage5_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage5_2_bt.gameObject.SetActive(false);
                                        stage5_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage5_2_bt.gameObject.SetActive(true);
                                        stage5_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage5_3_bt.gameObject.SetActive(false);
                                        stage5_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage5_3_bt.gameObject.SetActive(true);
                                        stage5_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                        // stage 6
                        case 6:
                            switch (level)
                            {
                                case 1:
                                    if (levelstatus == 0)
                                    {
                                        stage6_1_bt.gameObject.SetActive(false);
                                        stage6_1_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage6_1_bt.gameObject.SetActive(true);
                                        stage6_1_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 2:
                                    if (levelstatus == 0)
                                    {
                                        stage6_2_bt.gameObject.SetActive(false);
                                        stage6_2_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage6_2_bt.gameObject.SetActive(true);
                                        stage6_2_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                                case 3:
                                    if (levelstatus == 0)
                                    {
                                        stage6_3_bt.gameObject.SetActive(false);
                                        stage6_3_Mask.gameObject.SetActive(true);
                                    }
                                    else
                                    {
                                        stage6_3_bt.gameObject.SetActive(true);
                                        stage6_3_Mask.gameObject.SetActive(false);
                                    }
                                    break;
                            }
                            break;
                    }
                    // リソースステージバッジイメージデータのセット
                    //getResourceLevelImageData(i, laststage, img);
                    break;
                }
            }

        }
        private Sprite spt;
        private Image img;
        // ステージ選択ボタンマスクチェック＆バッジセット
        void setGameData(Button bt,int i) {

            img = null;
            int laststage;
            for (int m = 0; m < cubersFile.game_stage_max; m++)
            {
                if (cubersFile.stage[m].stage_no == i)
                {
                    int sts = (int)cubersFile.stage[m].status;
                    laststage = (int)cubersFile.stage[m].last_level;
                    switch (i)
                    {
                        case 1:
                            if (sts == 0)
                            {
                                selectView1_1_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView1_1_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel1_1Image.GetComponent<Image>();
                                    saveLevel1_1Image.gameObject.SetActive(true);
                                    clearlevel1_1Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel1_1Image.GetComponent<Image>();
                                    clearlevel1_1Image.gameObject.SetActive(true);
                                    saveLevel1_1Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                        case 2:
                            if (sts == 0)
                            {
                                selectView1_2_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView1_2_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel1_2Image.GetComponent<Image>();
                                    saveLevel1_2Image.gameObject.SetActive(true);
                                    clearlevel1_2Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel1_2Image.GetComponent<Image>();
                                    clearlevel1_2Image.gameObject.SetActive(true);
                                    saveLevel1_2Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                        case 3:
                            if (sts == 0)
                            {
                                selectView2_1_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView2_1_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel2_1Image.GetComponent<Image>();
                                    saveLevel2_1Image.gameObject.SetActive(true);
                                    clearlevel2_1Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel2_1Image.GetComponent<Image>();
                                    clearlevel2_1Image.gameObject.SetActive(true);
                                    saveLevel2_1Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                        case 4:
                            if (sts == 0)
                            {
                                selectView2_2_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView2_2_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel2_2Image.GetComponent<Image>();
                                    saveLevel2_2Image.gameObject.SetActive(true);
                                    clearlevel2_2Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel2_2Image.GetComponent<Image>();
                                    clearlevel2_2Image.gameObject.SetActive(true);
                                    saveLevel2_2Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                        case 5:
                            if (sts == 0)
                            {
                                selectView3_1_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView3_1_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel3_1Image.GetComponent<Image>();
                                    saveLevel3_1Image.gameObject.SetActive(true);
                                    clearlevel3_1Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel3_1Image.GetComponent<Image>();
                                    clearlevel3_1Image.gameObject.SetActive(true);
                                    saveLevel3_1Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                        case 6:
                            if (sts == 0)
                            {
                                selectView3_2_BG.gameObject.SetActive(true);
                            }
                            else
                            {
                                selectView3_2_BG.gameObject.SetActive(false);
                                bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
                                if (monthlyservice)
                                {
                                    img = saveLevel3_2Image.GetComponent<Image>();
                                    saveLevel3_2Image.gameObject.SetActive(true);
                                    clearlevel3_2Image.gameObject.SetActive(false);
                                }
                                else
                                {
                                    img = clearlevel3_2Image.GetComponent<Image>();
                                    clearlevel3_2Image.gameObject.SetActive(true);
                                    saveLevel3_2Image.gameObject.SetActive(false);
                                }
                            }
                            break;
                    }
                    // リソースステージバッジイメージデータのセット
                    getResourceLevelImageData(i, laststage, img);
                    break;
                }
            }
        }

        // ステージクリア条件情報
        // モンスター落下個数 最低 配列
        public static int[,] gravity_number_min_array = {
            { 1, 2, 2},     // 3cube タイムチャレンジ
            { 1, 2, 2},     // 3cube 連鎖モード
            { 2, 2, 2},     // 4cube タイムチャレンジ
            { 2, 2, 2},     // 4cube 連鎖モード
            { 3, 3, 3},     // 5cube タイムチャレンジ
            { 3, 3, 3}      // 5cube 連鎖モード
            };
        // モンスター落下個数 最高 配列
        public static int[,] gravity_number_max_array = {
            { 2, 3, 4},     // 3cube タイムチャレンジ
            { 2, 3, 4},     // 3cube 連鎖モード
            { 3, 4, 5},     // 4cube タイムチャレンジ
            { 3, 4, 5},     // 4cube 連鎖モード
            { 4, 5, 6},     // 5cube タイムチャレンジ
            { 4, 5, 6}      // 5cube 連鎖モード
            };
        // 落下待機時間 (秒)　配列　０の場合、10s から　５s可変
        public static int[,] gravity_time_array = {
            { 10, 7, 4},     // 3cube タイムチャレンジ
            { 10, 7, 4},     // 3cube 連鎖モード
            { 10, 7, 4},     // 4cube タイムチャレンジ
            { 10, 7, 4},     // 4cube 連鎖モード
            { 10, 7, 4},     // 5cube タイムチャレンジ
            { 10, 7, 4}      // 5cube 連鎖モード
            };
        /*// 落下待機時間 (秒)　可変間隔時間　配列　０の場合、可変無し
        public static int[,,] gravity_time_changeinterval_array = {
            {{ 0, 0, 0},{ 0, 2, 0}, { 0, 2, 12}},     // 3cube タイムチャレンジ
            {{ 0, 0, 0},{ 0, 12, 0}, { 0, 12, 12}},     // 3cube 連鎖モード
            {{ 0, 0, 0},{ 0, 12, 0}, { 0, 12, 12}},     // 4cube タイムチャレンジ
            {{ 0, 0, 0},{ 0, 12, 0}, { 0, 12, 12}},     // 4cube 連鎖モード　レベル１
            {{ 0, 0, 0},{ 0, 12, 0}, { 0, 12, 12}},     // 5cube タイムチャレンジ　レベル１
            {{ 0, 0, 0},{ 0, 12, 0}, { 0, 12, 12}}      // 5cube 連鎖モード　レベル１
            };*/
        // ３連鎖必要回数 配列 ０の場合は、非表示
        public static int[,] chaine_count_array = {
            { 0, 0, 0, 0, 0, 0 ,0},     // 3cube タイムチャレンジ
            { 1, 1, 3, 3, 6, 6 ,6},     // 3cube 連鎖モード
            { 0, 0, 0, 0, 0, 0 ,0},     // 4cube タイムチャレンジ
            { 1, 1, 3, 3, 6, 6 ,6},     // 4cube 連鎖モード
            { 0, 0, 0, 0, 0, 0 ,0},     // 5cube タイムチャレンジ
            { 1, 1, 3, 3, 6, 6 ,6}      // 5cube 連鎖モード
            };
        // 
        /*        // TODO:削除　1-1-1 1:現在のレベルメニューを削除しステージ選択からの遷移を取り止め　不要となったソース部分の削除
                void setStageGameData(Button bt, int i, Color color)
                {

                    IList stgdata = (IList)cubersFile.stage[(int)cubersFile.now_play_stage - 1].leveldata;
                    IDictionary stg = (IDictionary)stgdata[i - 1];
                    var status = (long)stg["status"];
                    var level = (int)cubersFile.now_play_stage;
                    img = null;

                    switch (i)
                    {
                        case 1:
                            img = selectStageViewIconImage1.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView1.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_1.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_1.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0) 
                                selectStageCondition1_1.gameObject.GetComponent<Text>().text = "10-6s"; 
                            else
                                selectStageCondition1_1.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_1.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_1.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage1.gameObject.SetActive(true);

                                selectBestStageScore1.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime1.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage1.gameObject.SetActive(false);

                                //yellowMonsterLineCount.GetComponent<Text>().text = yellow.ToString() + "/" + monster.level_Line_count;

                                selectBestStageScore1.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime1.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 2:
                            img = selectStageViewIconImage2.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView2.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_2.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_2.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_2.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_2.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_2.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_2.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage2.gameObject.SetActive(true);

                                selectBestStageScore2.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime2.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage2.gameObject.SetActive(false);

                                selectBestStageScore2.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime2.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 3:
                            img = selectStageViewIconImage3.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView3.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_3.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_3.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_3.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_3.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_3.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_3.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage3.gameObject.SetActive(true);

                                selectBestStageScore3.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime3.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage3.gameObject.SetActive(false);

                                selectBestStageScore3.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime3.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 4:
                            img = selectStageViewIconImage4.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView4.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_4.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_4.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_4.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_4.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_4.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_4.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage4.gameObject.SetActive(true);

                                selectBestStageScore4.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime4.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage4.gameObject.SetActive(false);

                                selectBestStageScore4.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime4.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 5:
                            img = selectStageViewIconImage5.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView5.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_5.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_5.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_5.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_5.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_5.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_5.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage5.gameObject.SetActive(true);

                                selectBestStageScore5.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime5.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage5.gameObject.SetActive(false);

                                selectBestStageScore5.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime5.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 6:
                            img = selectStageViewIconImage6.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView6.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_6.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_6.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_6.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_6.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_6.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_6.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage6.gameObject.SetActive(true);

                                selectBestStageScore6.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime6.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage6.gameObject.SetActive(false);

                                selectBestStageScore6.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime6.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                        case 7:
                            img = selectStageViewIconImage7.GetComponent<Image>();
                            // リソースステージバッジイメージデータのセット
                            getResourceLevelImageData(level, i, img);

                            selectStageView7.GetComponent<Image>().color = color;

                            // クリア条件表示
                            // 連鎖条件アイコン　オン・オフ
                            if (chaine_count_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                            {
                                selectStageConditionIcon3_7.gameObject.SetActive(false);
                            }
                            else
                            {
                                selectStageConditionIcon3_7.gameObject.SetActive(true);
                            }
                            // 条件テキスト
                            if (gravity_time_array[cubersFile.now_play_stage - 1, i - 1] == 0)
                                selectStageCondition1_7.gameObject.GetComponent<Text>().text = "10-6s";
                            else
                                selectStageCondition1_7.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, i - 1].ToString() + "s";
                            selectStageCondition2_7.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, i - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, i - 1].ToString();
                            selectStageCondition3_7.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, i - 1].ToString();

                            if (status == 0)
                            {
                                selectStageViewBGImage7.gameObject.SetActive(true);
                                //img.enabled = true;

                                selectBestStageScore7.gameObject.GetComponent<Text>().text = "- - -";
                                selectBestStageTime7.gameObject.GetComponent<Text>().text = "- - -";
                            }
                            else
                            {
                                selectStageViewBGImage7.gameObject.SetActive(false);

                                selectBestStageScore7.gameObject.GetComponent<Text>().text = stg["point"].ToString();
                                selectBestStageTime7.gameObject.GetComponent<Text>().text = stg["time"].ToString();
                            }
                            break;
                    }

                }
        */
        // 新ステージバッジ　イメージリソースセット
        void setLevelImageBadge(int stageNo, int levelNo, int gamestatus)
        {
            if (gamestatus == 1)
            {
                complete_level_badge1_1.gameObject.SetActive(false);
                complete_level_badge1_2.gameObject.SetActive(false);
                complete_level_badge1_3.gameObject.SetActive(false);
                complete_level_badge2_1.gameObject.SetActive(false);
                complete_level_badge2_2.gameObject.SetActive(false);
                complete_level_badge2_3.gameObject.SetActive(false);
                complete_level_badge3_1.gameObject.SetActive(false);
                complete_level_badge3_2.gameObject.SetActive(false);
                complete_level_badge3_3.gameObject.SetActive(false);
                complete_level_badge4_1.gameObject.SetActive(false);
                complete_level_badge4_2.gameObject.SetActive(false);
                complete_level_badge4_3.gameObject.SetActive(false);
                complete_level_badge5_1.gameObject.SetActive(false);
                complete_level_badge5_2.gameObject.SetActive(false);
                complete_level_badge5_3.gameObject.SetActive(false);
                complete_level_badge6_1.gameObject.SetActive(false);
                complete_level_badge6_2.gameObject.SetActive(false);
                complete_level_badge6_3.gameObject.SetActive(false);
            } else
            {
                faild_level_badge1_1.gameObject.SetActive(false);
                faild_level_badge1_2.gameObject.SetActive(false);
                faild_level_badge1_3.gameObject.SetActive(false);
                faild_level_badge2_1.gameObject.SetActive(false);
                faild_level_badge2_2.gameObject.SetActive(false);
                faild_level_badge2_3.gameObject.SetActive(false);
                faild_level_badge3_1.gameObject.SetActive(false);
                faild_level_badge3_2.gameObject.SetActive(false);
                faild_level_badge3_3.gameObject.SetActive(false);
                faild_level_badge4_1.gameObject.SetActive(false);
                faild_level_badge4_2.gameObject.SetActive(false);
                faild_level_badge4_3.gameObject.SetActive(false);
                faild_level_badge5_1.gameObject.SetActive(false);
                faild_level_badge5_2.gameObject.SetActive(false);
                faild_level_badge5_3.gameObject.SetActive(false);
                faild_level_badge6_1.gameObject.SetActive(false);
                faild_level_badge6_2.gameObject.SetActive(false);
                faild_level_badge6_3.gameObject.SetActive(false);

            }
            switch (stageNo)
            {
                case 1:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge1_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge1_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge1_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge1_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge1_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge1_3.gameObject.SetActive(true);
                    break;
                case 2:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge2_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge2_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge2_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge2_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge2_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge2_3.gameObject.SetActive(true);
                    break;
                case 3:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge3_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge3_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge3_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge3_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge3_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge3_3.gameObject.SetActive(true);
                    break;
                case 4:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge4_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge4_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge4_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge4_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge4_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge4_3.gameObject.SetActive(true);
                    break;
                case 5:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge5_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge5_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge5_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge5_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge5_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge5_3.gameObject.SetActive(true);
                    break;
                case 6:
                    if (gamestatus == 1 && levelNo == 1) complete_level_badge6_1.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 2) complete_level_badge6_2.gameObject.SetActive(true);
                    if (gamestatus == 1 && levelNo == 3) complete_level_badge6_3.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 1) faild_level_badge6_1.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 2) faild_level_badge6_2.gameObject.SetActive(true);
                    if (gamestatus == 2 && levelNo == 3) faild_level_badge6_3.gameObject.SetActive(true);
                    break;
            }
        }
        // 旧ステージバッジ　イメージリソースセット
        void getResourceLevelImageData(int levelNo, int stageNo, Image image)
        {
            switch (stageNo)
            {
                case 0:
                    spt = Resources.Load<Sprite>("11 2D/stage/no_medal");
                    break;
                case 1:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze1");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze1");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver1");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver1");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold1");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold1");
                    break;
                case 2:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze2");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze2");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver2");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver2");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold2");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold2");
                    break;
                case 3:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze3");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze3");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver3");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver3");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold3");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold3");
                    break;
                case 4:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze4");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze4");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver4");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver4");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold4");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold4");
                    break;
                case 5:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze5");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze5");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver5");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver5");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold5");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold5");
                    break;
                case 6:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze6");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze6");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver6");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver6");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold6");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold6");
                    break;
                case 7:
                    if (levelNo == 1) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_bronze7");
                    if (levelNo == 2) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_bronze7");
                    if (levelNo == 3) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_silver7");
                    if (levelNo == 4) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_silver7");
                    if (levelNo == 5) spt = Resources.Load<Sprite>("11 2D/stage/time_medal_gold7");
                    if (levelNo == 6) spt = Resources.Load<Sprite>("11 2D/stage/rank_medal_gold7");
                    break;
            }
            // イメージデータセット
            if (image != null)
            {
                image.sprite = spt;
            }
        }


        string setLevelText(int level) {

			string levelText = null;
			switch(level) {
			case 1:
				levelText = "1-1";
				break;
			case 2:
				levelText = "1-2";
				break;
			case 3:
				levelText = "1-3";
				break;
			case 4:
				levelText = "2-1";
				break;
			case 5:
				levelText = "2-2";
				break;
			case 6:
				levelText = "2-3";
				break;
			case 7:
				levelText = "3-1";
				break;
			case 8:
				levelText = "3-2";
				break;
			case 9:
				levelText = "3-3";
				break;
			}
			return levelText;
		}

        // TODO:1-1-3追加
		// game complete Life Lost Count Set & check
		void setLostCount() {

            // レベルロストカウントセット
            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];

            dt["lostcount"] = emitter.lost_count_MAX - sphere.lost_Spheres;
            cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1] = dt;

            cubersFile.cubersFile_instance.save_gameEncryptionData();
            if (sphere.lost_Spheres == emitter.lost_count_MAX)
            {
                //  ロスト０
                //lifeLostCount_Zero.gameObject.SetActive(true);
            }
            else
            {
                //lifeLostCount_Zero.gameObject.SetActive(false);
            }

		}
        // TODO:1-1-3追加
        // game complete time set & check
        void setPlayTime() {

            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];

            long playtime = (long)playEndTimeSpan.TotalMilliseconds;
            var time = (long)dt["playtime"];

            playtime_text.text = gameTimeEnd_text.text;

            // プレイ時間更新　プレイ時間が少ない程Good
            if (time > playtime || time == 0) {
                besttime_text.text = playtime.ToString();
                besttime_text.gameObject.SetActive(true);
                 // プレイタイム更新保存
                dt["playtime"] = playtime;
                cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1] = dt;
                cubersFile.cubersFile_instance.save_gameEncryptionData();
            }
            else
            {
                // New Complete View Used
                besttime_text.gameObject.SetActive(false);
            }

		}

        // TODO:1-1-3追加
        // 連鎖モード時のレベルクリア最大連鎖数データ保存＆更新チェック、演出処理
        void setMaxChainCount()
        {
            // 取得したシルバーアイテム個数
            long playMaxChain = emitter.chainExplosionLinePlayMAX;

            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];
            var maxChain = (long)dt["maxchain"];

            // プレイ時間更新　プレイ時間が少ない程Good
            if (playMaxChain > maxChain)
            {
                max_chain_Mes_BG.gameObject.SetActive(true);
                // 最大連鎖数更新保存
                dt["maxchain"] = maxChain;
                cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1] = dt;
                cubersFile.cubersFile_instance.save_gameEncryptionData();
            }
            else
            {
                //max_chain_Mes_BG.gameObject.SetActive(false);
            }
        }

        // TODO:1-1-3追加
        // game complete get item count set
        void setGetItemData()
        {
            // プレイ中に取得したシルバーアイテム、もしくは記録更新で取得したボーナスアイテム
            // TODO:1-1-5 獲得アイテム処理  獲得シルバーアイテム加算＆保存
            var goldcountAdd = emitter.playGetSilverItemCount / 10;
            var coinAdd = (showGoldItem + goldcountAdd) / 10;
            cubersFile.goldCoin_Count =+ (long)(coinAdd* bouns);

            // showGoldItemの変更はここではしない　showChangeItem() で行う為            
            cubersFile.golditem_count =+ goldcountAdd;

            cubersFile.silveritem_count = +(long)emitter.playGetSilverItemCount;

            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];
            dt["itemcount"] = (long)emitter.playGetSilverItemCount; // <- Level play infoの情報としてセーブ　必要ないと思うので削除
            cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1] = dt;

            cubersFile.cubersFile_instance.save_gameEncryptionData();

            if (emitter.playGetSilverItemCount != 0)
            {
                //get_Item_Mes_BG.gameObject.SetActive(true);
            }
        }

        // TODO:1-1-4追加　レベルMAXクリア情報表示処理
        void setStageTotalClearInfo()
        {
            // トータルプレイ時間
            long totalPlayTime = 0;
            long totalLostCount = 0;
            for (int i = 0; i < emitter.stageLevel_max; i++)
            {
                IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[i];
                // プレイ時間（秒）
                totalPlayTime += (long)dt["playtime"];
                // トータルロストカウント
                totalLostCount += (long)dt["lostcount"];
            }
            var span = new TimeSpan(0, 0, (int)totalPlayTime);
            var hhmmss = span.ToString(@"hh\:mm\:ss");
            total_playtime_text.gameObject.GetComponent<Text>().text = "TOTAL PLAY TIME " + hhmmss;

            total_lostlife_count_text.gameObject.GetComponent<Text>().text = "TOTAL LOST LIFE  " + totalLostCount;

            //ranking_text.gameObject.GetComponent<Text>().text = "RANKING : ";

            stage_Clear_Info_view.gameObject.SetActive(true);
        }
        // game point display
        void gamePointDSP(long gamepoint) {
			int k = 7;
			string st4 = @"D" + k.ToString();
			long val4 = sphere.point_count;
			if (val4 > 9999999) val4 = 9999999; // limit dsp 9999999
//			string str4 = val4.ToString(st4);

//			long l = sphere.point_count;
			gamePoint.gameObject.GetComponent<Text>().text = val4.ToString(st4);
		}
		// chainExplosion monster counter view ON
		public static void setChainExplosionMonsterColorCountView(monster_color color) {
			switch (color) {
			case monster_color.blue_monster:
				blueMonsterCountON = true;
				break;
			case monster_color.green_monster:
				greenMonsterCountON = true;
				break;
			case monster_color.purple_monster:
				purpleMonsterCountON = true;
				break;
			case monster_color.red_monster:
				redMonsterCountON = true;
				break;
			case monster_color.yellow_monster:
				yellowMonsterCountON = true;
				break;
			default:
				break;
			}
		}

		static Animator ani;
		// chainExplosion monster counter view Effect
		public static void setChainExplosionMonsterColorCountEffect(monster_color color) {
			if (Effect_2D != null) {
				Destroy(Effect_2D);
			}
			// 2D -> 3D座標を取得
			Effect_2D = Instantiate (monsterCounter2DEffect_s);
			ani = Effect_2D.GetComponent<Animator>();

			switch (color) {
			case monster_color.blue_monster:
				Effect_2D.transform.SetParent (blueMonsterCountImage_s.transform, false);
				break;
			case monster_color.green_monster:
				Effect_2D.transform.SetParent (greenMonsterCountImage_s.transform, false);
				break;
			case monster_color.purple_monster:
				Effect_2D.transform.SetParent (purpleMonsterCountImage_s.transform, false);
				break;
			case monster_color.red_monster:
				Effect_2D.transform.SetParent (redMonsterCountImage_s.transform, false);
				break;
			case monster_color.yellow_monster:
				Effect_2D.transform.SetParent (yellowMonsterCountImage_s.transform, false);
				break;
			default:
				break;
			}
			ani.Play("explosion-18");
		}
		// chainExplosion monster counter view OFF
		public static void setChainExplosionMonsterColorCountView() {
			blueMonsterCountON = false;
			greenMonsterCountON = false;
			orangeMonsterCountON = false;
			purpleMonsterCountON = false;
			redMonsterCountON = false;
			yellowMonsterCountON = false;
		}


		// ロストicon表示
		void lostIcon() {
            switch (cubersFile.game_Sceen)
            {
                case 0:
                    switch (sphere.lost_Spheres)
                    {
                        case 1:
                            life_icon1.gameObject.SetActive(true);
                            life_icon2.gameObject.SetActive(false);
                            life_icon3.gameObject.SetActive(false);
                            life_icon4.gameObject.SetActive(false);
                            life_icon5.gameObject.SetActive(false);
                            break;
                        case 2:
                            life_icon1.gameObject.SetActive(true);
                            life_icon2.gameObject.SetActive(true);
                            life_icon3.gameObject.SetActive(false);
                            life_icon4.gameObject.SetActive(false);
                            life_icon5.gameObject.SetActive(false);
                            break;
                        case 3:
                            life_icon1.gameObject.SetActive(true);
                            life_icon2.gameObject.SetActive(true);
                            life_icon3.gameObject.SetActive(true);
                            life_icon4.gameObject.SetActive(false);
                            life_icon5.gameObject.SetActive(false);
                            break;
                        case 4:
                            life_icon1.gameObject.SetActive(true);
                            life_icon2.gameObject.SetActive(true);
                            life_icon3.gameObject.SetActive(true);
                            life_icon4.gameObject.SetActive(true);
                            life_icon5.gameObject.SetActive(false);
                            break;
                        case 5:
                            life_icon1.gameObject.SetActive(true);
                            life_icon2.gameObject.SetActive(true);
                            life_icon3.gameObject.SetActive(true);
                            life_icon4.gameObject.SetActive(true);
                            life_icon5.gameObject.SetActive(true);
                            break;
                        default:
                            life_icon1.gameObject.SetActive(false);
                            life_icon2.gameObject.SetActive(false);
                            life_icon3.gameObject.SetActive(false);
                            life_icon4.gameObject.SetActive(false);
                            life_icon5.gameObject.SetActive(false);
                            break;
                    }
                    break;
                case 2:
                    switch (sphere.lost_Spheres)
                    {
                        case 1:
                            life_hearticon1.gameObject.SetActive(true);
                            life_hearticon2.gameObject.SetActive(false);
                            life_hearticon3.gameObject.SetActive(false);
                            life_hearticon4.gameObject.SetActive(false);
                            life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 2:
                            life_hearticon1.gameObject.SetActive(true);
                            life_hearticon2.gameObject.SetActive(true);
                            life_hearticon3.gameObject.SetActive(false);
                            life_hearticon4.gameObject.SetActive(false);
                            life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 3:
                            life_hearticon1.gameObject.SetActive(true);
                            life_hearticon2.gameObject.SetActive(true);
                            life_hearticon3.gameObject.SetActive(true);
                            life_hearticon4.gameObject.SetActive(false);
                            life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 4:
                            life_hearticon1.gameObject.SetActive(true);
                            life_hearticon2.gameObject.SetActive(true);
                            life_hearticon3.gameObject.SetActive(true);
                            life_hearticon4.gameObject.SetActive(true);
                            life_hearticon5.gameObject.SetActive(false);
                            break;
                        case 5:
                            life_hearticon1.gameObject.SetActive(true);
                            life_hearticon2.gameObject.SetActive(true);
                            life_hearticon3.gameObject.SetActive(true);
                            life_hearticon4.gameObject.SetActive(true);
                            life_hearticon5.gameObject.SetActive(true);
                            break;
                        default:
                            life_hearticon1.gameObject.SetActive(false);
                            life_hearticon2.gameObject.SetActive(false);
                            life_hearticon3.gameObject.SetActive(false);
                            life_hearticon4.gameObject.SetActive(false);
                            life_hearticon5.gameObject.SetActive(false);
                            break;
                    }
                    break;
            }
		}

        public static int gametempoCount = 0; //１０秒毎に１加算され緑範囲、黄範囲、赤範囲で各範囲毎にテンポが変化する　サウンド速度が早くなり落下速度もそれに応じて早くなる
        public int temp_distance = 10;
		// ゲームテンポ表示リセット
        public void gameTempoReset () {
            waitingTimerGauge_BG.gameObject.SetActive(false);
            Level_top.gameObject.SetActive(false);
            Level1_1.gameObject.SetActive(false);
            Level1_2.gameObject.SetActive(false);
            Level1_3.gameObject.SetActive(false);
            Level2_1.gameObject.SetActive(false);
            Level2_2.gameObject.SetActive(false);
            Level2_3.gameObject.SetActive(false);
            Level3_1.gameObject.SetActive(false);
            Level3_2.gameObject.SetActive(false);
            Level3_3.gameObject.SetActive(false);
            Level3_4.gameObject.SetActive(false);

            emitter.player.playBGM(0);
        }
        public static int beforeTime = 0;
        // 落下待機時間の範囲に応じて　BG関連表示、カラー、BGMに変化をつける
        public void gravityWaitTemp(int w_time)
        {
            int temp = 0;
            emitter.wait_variable_timerCount--;
/*            Debug.Log(" gravityWaitTemp w_time = " + w_time);
            Debug.Log(" gravityWaitTemp wait_variable_timerCount = " + emitter.wait_variable_timerCount);
            Debug.Log(" gravityWaitTemp gravity_Timespan = " + emitter.gravity_Timespan); */
            // 可変待機時間更新かチェック
            if (emitter.wait_variable_timerCount <= 0) {
                if(emitter.gravity_Timespan < 2) emitter.gravity_Timespan++;
                emitter.wait_variable_timerCount = emitter.wait_timer_variable;
            }

            if (w_time == 0)
            {
                switch(cubersFile.now_play_stagelevel)
                {
                    case 1:
                        temp = emitter.slowTempoTime;
                        break;
                    case 2:
                        if (emitter.gravity_Timespan == 0)
                        {
                            temp = emitter.slowTempoTime;
                        }
                        else if (emitter.gravity_Timespan >= 1)
                        {
                            temp = emitter.midlleTempoTime;
                        }
                        break;
                    case 3:
                        if (emitter.gravity_Timespan == 0)
                        {
                            temp = emitter.slowTempoTime;
                        }
                        else if (emitter.gravity_Timespan == 1)
                        {
                            temp = emitter.midlleTempoTime;
                        } else
                        {
                            temp = emitter.highTempoTime;
                        }
                        break;
                }
            }
            //Debug.Log(" gravityWaitTemp temp = " + temp);

            waitingTimerGauge_BG.gameObject.SetActive(true);
            Level_top.gameObject.SetActive(true);

            //float brk = Mathf.PingPong(Time.time * 2.0f, 1.0f);
            Color cl;

            /*if (w_time == 0)
            {
                gametempoCount = gametempoCount + temp_distance;
                if (gametempoCount > temp_distance * 10)
                {
                    gametempoCount = temp_distance * 10;
                }
            }
            int temp = gametempoCount / temp_distance;
            */
            switch (temp)
            {
                case 0:
                case 10:
                case 9:
                case 8:
                    // １０秒から8秒落下
                    // 連鎖あり？
                    if (swChangeTempo != 0)
                    {
                        // １連鎖　から　３連鎖含めテンポリセット 
                        gametempoCount = 0;
                        swChangeTempo = 0;
                    }
                    else
                    {
                        // 連鎖無し
                        emitter.gravity_Time = emitter.slowTempoTime;
                        emitter.gravity_Time += 0.99f;
                    }
                    cl = Level1_1.gameObject.GetComponent<Image>().color;
                    Level_top.gameObject.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1.0f);
                    //Level_top.gameObject.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1.0f);
                    // BGM pitch設定
                    emitter.player.playBGM(0);
                    break;
                case 7:
                case 6:
                case 5:
                    //7秒から5秒落下
                    // 連鎖あり？
                    if (swChangeTempo != 0)
                    {
                        // １連鎖　から　３連鎖含めテンポリセット 
                        gametempoCount = 0;
                        swChangeTempo = 0;
                    }
                    else
                    {
                        // 連鎖無し
                        emitter.gravity_Time = emitter.midlleTempoTime;
                        emitter.gravity_Time += 0.99f;
                    }
                    cl = Level2_1.gameObject.GetComponent<Image>().color;
                    Level_top.gameObject.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1.0f);
                    // BGM pitch設定
                    emitter.player.playBGM(1);
                    break;
                case 4:
                case 3:
                case 2:
                case 1:
                    //4秒落下
                    // 連鎖あり？
                    if (swChangeTempo != 0)
                    {
                        if (swChangeTempo == 1)
                        {
                            // １連鎖
                            gametempoCount = temp_distance * 10 * 3;
                        }
                        else
                        {
                            //　２連鎖　から　３連鎖
                            gametempoCount = 0;
                        }
                        swChangeTempo = 0;
                    }
                    else
                    {
                        emitter.gravity_Time = emitter.highTempoTime;
                        emitter.gravity_Time += 0.99f;
                    }
                    cl = Level3_1.gameObject.GetComponent<Image>().color;
                    Level_top.gameObject.GetComponent<Image>().color = new Color(cl.r, cl.g, cl.b, 1.0f);
                    // BGM pitch設定
                    emitter.player.playBGM(2);
                    break;
            }
            //Debug.Log(" gravityWaitTemp gravity_Time = " + emitter.gravity_Time);

        }

        /*
                // ゲームテンポゲージ表示
                void gameTempo() {

                    float brk = Mathf.PingPong(Time.time * 2.0f, 1.0f);
                    Color cl;
                    Debug.Log("Time:" + gametempoCount);
                    int gauge = (int)gametempoCount/emitter.tempoLength;
                    if (gauge >= 9) gauge = 9; //ゲージ個数９個
                    switch(gauge) {
                    case 0:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(true);
                        Level1_2.gameObject.SetActive(true);
                        Level1_3.gameObject.SetActive(true);
                        Level2_1.gameObject.SetActive(true);
                        Level2_2.gameObject.SetActive(true);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
        //				Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level1_1.gameObject.GetComponent<Image>().color;
                        Level1_1.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 1:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(true);
                        Level1_3.gameObject.SetActive(true);
                        Level2_1.gameObject.SetActive(true);
                        Level2_2.gameObject.SetActive(true);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
        //				Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level1_2.gameObject.GetComponent<Image>().color;
                        Level1_2.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 2:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(true);
                        Level2_1.gameObject.SetActive(true);
                        Level2_2.gameObject.SetActive(true);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
        //				Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level1_3.gameObject.GetComponent<Image>().color;
                        Level1_3.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 3:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(true);
                        Level2_2.gameObject.SetActive(true);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
        //				Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level2_1.gameObject.GetComponent<Image>().color;
                        Level2_1.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 4:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(true);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
        //				Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level2_2.gameObject.GetComponent<Image>().color;
                        Level2_2.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 5:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(false);
                        Level2_3.gameObject.SetActive(true);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
        //				Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level2_3.gameObject.GetComponent<Image>().color;
                        Level2_3.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 6:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(false);
                        Level2_3.gameObject.SetActive(false);
                        Level3_1.gameObject.SetActive(true);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
        //				Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level3_1.gameObject.GetComponent<Image>().color;
                        Level3_1.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 7:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(false);
                        Level2_3.gameObject.SetActive(false);
                        Level3_1.gameObject.SetActive(false);
                        Level3_2.gameObject.SetActive(true);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
        //				Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level3_2.gameObject.GetComponent<Image>().color;
                        Level3_2.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 8:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(false);
                        Level2_3.gameObject.SetActive(false);
                        Level3_1.gameObject.SetActive(false);
                        Level3_2.gameObject.SetActive(false);
                        Level3_3.gameObject.SetActive(true);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
        //				Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        Level3_4.gameObject.GetComponent<Image>().color = Level3_4_Base_Color;
                        cl = Level3_3.gameObject.GetComponent<Image>().color;
                        Level3_3.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    case 9:
                        Level_top.gameObject.SetActive(true);
                        Level1_1.gameObject.SetActive(false);
                        Level1_2.gameObject.SetActive(false);
                        Level1_3.gameObject.SetActive(false);
                        Level2_1.gameObject.SetActive(false);
                        Level2_2.gameObject.SetActive(false);
                        Level2_3.gameObject.SetActive(false);
                        Level3_1.gameObject.SetActive(false);
                        Level3_2.gameObject.SetActive(false);
                        Level3_3.gameObject.SetActive(false);
                        Level3_4.gameObject.SetActive(true);
                        Level_top.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level1_1.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level1_2.gameObject.GetComponent<Image>().color = Level1_2_Base_Color;
                        Level1_3.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        Level2_1.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        Level2_2.gameObject.GetComponent<Image>().color = Level2_2_Base_Color;
                        Level2_3.gameObject.GetComponent<Image>().color = Level2_3_Base_Color;
                        Level3_1.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        Level3_2.gameObject.GetComponent<Image>().color = Level3_2_Base_Color;
                        Level3_3.gameObject.GetComponent<Image>().color = Level3_3_Base_Color;
                        cl = Level3_4.gameObject.GetComponent<Image>().color;
                        Level3_4.gameObject.GetComponent<Image>().color = new Color(cl.r,cl.g,cl.b,brk);
                        break;
                    }

                }

                // モンスター落下ボタンゲージ表示
                public void sphereDownGauge(float mod) {

                    int gauge = (int)gametempoCount/emitter.tempoLength;
                    if (gauge >= 9) gauge = 9; //ゲージ個数９個
                    switch(gauge) {
                    case 0:
                    case 1:
                    case 2:
                        // １０秒落下
                        emitter.gravity_Time = emitter.slowTempoTime;
                        sphereDownGaugeBrink(1, mod);
                        break;
                    case 3:
                    case 4:
                    case 5:
                        // ５秒落下
                        emitter.gravity_Time = emitter.midlleTempoTime;
                        sphereDownGaugeBrink(2, mod);
                        break;
                    case 6:
                    case 7:
                    case 8:
                        // ３秒落下
                        emitter.gravity_Time = emitter.highTempoTime;
                        sphereDownGaugeBrink(3, mod);
                        break;
                    }
                }


                // モンスター落下ボタンゲージ表示OFF
                public void sphereDownGaugeOff() {

                    down_button_L_1.gameObject.SetActive(false);
                    down_button_L_2.gameObject.SetActive(false);
                    down_button_L_3.gameObject.SetActive(false);
                    down_button_L_4.gameObject.SetActive(false);
                    down_button_L_5.gameObject.SetActive(false);
                    down_button_L_6.gameObject.SetActive(false);
                    down_button_L_7.gameObject.SetActive(false);
                    down_button_R_1.gameObject.SetActive(false);
                    down_button_R_2.gameObject.SetActive(false);
                    down_button_R_3.gameObject.SetActive(false);
                    down_button_R_4.gameObject.SetActive(false);
                    down_button_R_5.gameObject.SetActive(false);
                    down_button_R_6.gameObject.SetActive(false);
                    down_button_R_7.gameObject.SetActive(false);
                }

                // モンスター落下ボタンゲージブリンク処理
                void sphereDownGaugeBrink(int tempo, float mod) {
                    switch(tempo) {
                    case 1:
                        // 10秒落下　２秒毎に落下ボタン表示切り替え アニメ５コマ
        //				brk = Mathf.PingPong(Time.time * 2.0f, 1.0f);
                        if (mod < 2) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(false);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(false);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                            }
                            else 
                        if (mod < 4) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 6) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 8) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 10) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(true);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(true);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(true);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(true);
                        }
                        // BGM pitch設定
                        emitter.player.playBGM(0);
                        break;

                    case 2:
                        // ５秒落下　１秒毎に落下ボタン表示切り替え
        //				brk = Mathf.PingPong(Time.time * 1.5f, 0.75f);
                        if (mod < 1) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(false);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(false);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 2) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 3) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 4) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 5) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(true);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(true);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(true);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(true);
                        }
                        // BGM pitch設定
                        emitter.player.playBGM(1);
                        break;

                    case 3:
                        // ３秒落下　0.6秒毎に落下ボタン表示切り替え
        //				brk = Mathf.PingPong(Time.time * 1.0f, 0.5f);
                        if (mod < 0.6f) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(false);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(false);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 1.2f) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(false);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(false);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 1.8f) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(false);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(false);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(false);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(false);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 2.4f) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(false);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(false);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(false);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(false);
                        } else
                        if (mod < 3) {
                            down_button_L_1.gameObject.SetActive(true);
                            down_button_L_2.gameObject.SetActive(true);
                            down_button_L_3.gameObject.SetActive(true);
                            down_button_L_4.gameObject.SetActive(true);
                            down_button_L_5.gameObject.SetActive(true);
                            down_button_L_6.gameObject.SetActive(true);
                            down_button_L_7.gameObject.SetActive(true);
                            down_button_R_1.gameObject.SetActive(true);
                            down_button_R_2.gameObject.SetActive(true);
                            down_button_R_3.gameObject.SetActive(true);
                            down_button_R_4.gameObject.SetActive(true);
                            down_button_R_5.gameObject.SetActive(true);
                            down_button_R_6.gameObject.SetActive(true);
                            down_button_R_7.gameObject.SetActive(true);
                        }
                        // BGM pitch設定
                        emitter.player.playBGM(2);
                        break;

                    default:
                        break;
                    }
                }
        */
        public void chainExplosionTempoChange (int chaincount) {

			switch(chaincount) {
			case 1:
				gametempoCount = gametempoCount - emitter.tempoLength * 2;
				if (gametempoCount < 0) gametempoCount = 0;
				break;
			case 2:
                if (emitter.gravity_Time > emitter.midlleTempoTime)
    				gametempoCount = gametempoCount - emitter.tempoLength * 3;
				if (gametempoCount < 0) gametempoCount = 0;
				break;
			case 3:
				gametempoCount = emitter.slowTempoTime;
				if (gametempoCount < 0) gametempoCount = 0;
				break;
			default:
				break;
			}

		}

        public static int eventCount = 0;
        // イベントアイコン表示処理
        public void setEventIcon() 
        {
            // イベント内容 
            int length = counter.eventStatus.Length;
            for (int i = 0; i < length; i++)
            {
                if (counter.eventStatus[i] == 1)
                {
                    // イベント２個表示中？
                    if (eventCount == 2) return;
                    eventCount++;
                    // イベント発生中 イベント情報取得
                    long eventData = cubersFile.eventData[i].contents;
                    switch(eventData)
                    {
                        // イベント並列は最大２つまで
                        case 1:
                        // タイムアタック　規程時間内に
                            break;
                        case 2:
                            break;
                        case 3:
                            break;
                        case 4:
                            break;
                    }
                }
            }

        }
        // TODO:追加　1-1-5 獲得アイテム表示処理　メソッド
        // プレイ開始時にシルバー、ゴールド、コイン表示を行う
        float showChainExplosionItemTimer = 0;
        static long showSilverItem = 0;
        static long showGoldItem = 0;
        static long showCoin = 0;
        static long showjewelry = 0;
        static int coinAdd = 10;
        static int jewelryAdd = 10;
        static float bouns = 1.0f;
        // アイテム表示非表示処理　SW：１シルバーアイテム　２：ゴールドアイテム
        void showItemAllClear(int sw)
        {
            // プレイ画面ゴールド、シルバーアイテム表示セット
            for (int i = 0; i < 10; i++)
            {
                if (sw == 1)
                {
                    silverItemArray[i].gameObject.SetActive(false);
                }
                if (sw == 2)
                {
                    goldItemArray[i].gameObject.SetActive(false);
                }
            }
        }
        public void showTopTimeDSP()
        {
            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];

            var time = (long)dt["playtime"];

            // プレイ時間更新
            if (time == 0)
            {
                s_topGameTime_text.text = "TopTime 00:00:00:00";
                s_topGameTimeChainView_text.text = "TopTime 00:00:00:00";
            }
            else
            {
                TimeSpan interval = TimeSpan.FromMilliseconds(time);
                s_topGameTime_text.text = "TopTime " + ConvertTimeSpanToString(interval);
                s_topGameTimeChainView_text.text = "TopTime " + ConvertTimeSpanToString(interval);
            }

        }
        public void showItemDSP()
        {
            // シルバーアイテムの表示個数を計算
            showSilverItem = cubersFile.silveritem_count % 10;
            // ゴールドアイテムの表示個数を計算
            showGoldItem = cubersFile.golditem_count % 10;
            // 表示コイン数セット
            showCoin = cubersFile.goldCoin_Count;
            // 表示コイン数セット
            showjewelry = cubersFile.jewelry_Count;

            // プレイ画面ゴールド、シルバーアイテム表示セット
            for (int i = 0; i < 10; i++)
            {
                // 表示済みシルバーアイテム拡大ー＞ノーマルサイズへ変更処理
                Vector3 scal = silverItemArray[i].gameObject.GetComponent<Image>().transform.localScale;
                scal.x = m_hit_reset;
                scal.y = m_hit_reset;
                scal.z = m_hit_reset;
                silverItemArray[i].gameObject.GetComponent<Image>().transform.localScale = scal;

                // 表示済みゴールドアイテム拡大ー＞ノーマルサイズへ変更処理
                Vector3 scal_g = goldItemArray[i].gameObject.GetComponent<Image>().transform.localScale;
                scal_g.x = m_hit_reset;
                scal_g.y = m_hit_reset;
                scal_g.z = m_hit_reset;
                goldItemArray[i].gameObject.GetComponent<Image>().transform.localScale = scal_g;

                if (showSilverItem < i)
                {
                    silverItemArray[i].gameObject.SetActive(true);
                }
                else
                {
                    silverItemArray[i].gameObject.SetActive(false);
                }
                if (showGoldItem < i)
                {
                    goldItemArray[i].gameObject.SetActive(true);
                }
                else
                {
                    goldItemArray[i].gameObject.SetActive(false);
                }
            }
            //　コイン数表示
            coin_text.text = cubersFile.goldCoin_Count.ToString();
            //　juely数表示
            jewelry_text.text = cubersFile.jewelry_Count.ToString();

        }
        // TODO:追加　1-1-5 獲得アイテム表示処理　メソッド
        // コンプリート時、取得アイテム変更表示処理
        void showChangeItem()
        {
            // 表示済みシルバーアイテム拡大ー＞ノーマルサイズへ変更処理
            Vector3 scal_s = silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale;
            scal_s.x = m_hit_reset;
            scal_s.y = m_hit_reset;
            scal_s.z = m_hit_reset;
            silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_s;

            // 表示済みゴールドアイテム拡大ー＞ノーマルサイズへ変更処理
            Vector3 scal_g = goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale;
            scal_g.x = m_hit_reset;
            scal_g.y = m_hit_reset;
            scal_g.z = m_hit_reset;
            goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_g;

            showSilverItem++;
            // シルバーアイテムMAX10超え?
            if (showSilverItem > 10)
            {
                // シルバーアイテム表示リセット
                showSilverItem = 1;
                showItemAllClear(1);

                // 表示済みシルバーアイテム拡大処理
                scal_s = silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale;
                scal_s.x = m_hit_zoom;
                scal_s.y = m_hit_zoom;
                scal_s.z = m_hit_zoom;
                silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_s;
                silverItemArray[showSilverItem - 1].gameObject.SetActive(true);

            }
            // シルバーMAX１０？
            else if (showSilverItem == 10)
            {
                // 表示済みシルバーアイテム拡大処理
                scal_s = silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale;
                scal_s.x = m_hit_zoom;
                scal_s.y = m_hit_zoom;
                scal_s.z = m_hit_zoom;
                silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_s;
                silverItemArray[showSilverItem - 1].gameObject.SetActive(true);

                showGoldItem++;
                // ゴールドアイテムMAX１０超え？
                if (showGoldItem > 10)
                {
                    // ゴールドアイテム表示リセット
                    showGoldItem = 1;
                    showItemAllClear(2);
                    // 表示済みゴールドアイテム拡大処理
                    scal_g = goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale;
                    scal_g.x = m_hit_zoom;
                    scal_g.y = m_hit_zoom;
                    scal_g.z = m_hit_zoom;
                    goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_g;
                    goldItemArray[showSilverItem - 1].gameObject.SetActive(true);
                }
                if (showGoldItem == 10)
                {
                    // 表示済みゴールドアイテム拡大処理
                    scal_g = goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale;
                    scal_g.x = m_hit_zoom;
                    scal_g.y = m_hit_zoom;
                    scal_g.z = m_hit_zoom;
                    goldItemArray[showGoldItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_g;
                    goldItemArray[showSilverItem - 1].gameObject.SetActive(true);

                    // ゴールドアイテムMAX１０ー＞コイン加算ボーナス
                    // コイン加算処理は、setItemData()で処理済み
                    showCoin =+ (long)(coinAdd * bouns);
                    coin_text.text = showCoin.ToString();
                    showjewelry = +(long)(jewelryAdd * bouns);
                    jewelry_text.text = showjewelry.ToString();
                }
            }
            else
            {
                // 表示済みシルバーアイテム拡大処理
                scal_s = silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale;
                scal_s.x = m_hit_zoom;
                scal_s.y = m_hit_zoom;
                scal_s.z = m_hit_zoom;
                silverItemArray[showSilverItem - 1].gameObject.GetComponent<Image>().transform.localScale = scal_s;
                silverItemArray[showSilverItem - 1].gameObject.SetActive(true);
            }
        }

        // Update is called once per frame
        emitter.gamePlayState state = emitter.gamePlayState.Zero;
		TimeSpan lastStopTimeSpan;
		DateTime startDateTime;
		public static bool timeChange = false;
		//public static bool startDwonGaugeBrink = false;

		public static int swChangeTempo = 0;

        public static bool swAddPointDSP = false;

        // 連鎖カウント
        public static int chain_1_count = 0;    //　１連鎖回数
        public static int chain_2_count = 0;    //　２連鎖回数
        public static int chain_3_count = 0;    //　３連鎖回数

        float b_Speed = 10;
		float f_Speed = 40;
		bool bf_Move = false;
		bool bf_Up = false;
		bool if_Move = false;
		bool if_Up = false;
        bool is_Move = false;
        bool is_Up = false;
        bool tt_Move = false;
		bool tt_Up = false;
		bool gf_Move = false;
		bool gf_Up = false;
        bool gsf_Move = false;
        bool gsf_Up = false;
        bool nv_Move = false;
        bool nv_Up = false;

        const int time_keta = 6;

        bool gameClearGetItemDSP = false;         //  ゲームクリア時の取得アイテム表示処理

       　// 連鎖取得アイテム表示処理　宝石、ゴールド卵、シルバー卵
        public static bool changeChainExplosionbItem = false;

		void Update () {

            // floorTouch 落下フラグチェック
            if (isFloorTouch)
            {
                ButtonDownClick();
                isFloorTouch = false;
            }

            int k = 1;

			// garabity lost count
			string st0 = @"D" + k.ToString();
			int val0 = sphere.lost_Spheres;
			if (val0 > 999) val0 = 999; // limit dsp 999
			string str0 = val0.ToString(st0);

			lost_Count_text.text = "x " + str0.ToString();
			// ロストicon表示
			lostIcon();


			// slow count
			string st1 = @"D" + k.ToString();
			int val1 = (int)cubersFile.delay_count;
			if (val1 > 999) val1 = 999; // limit dsp 999
			string str1 = val1.ToString(st1);
			
			// game retry count
			string st2 = @"D" + k.ToString();
			int val2 = (int)cubersFile.game_count;
			if (val2 > 9999) val2 = 9999; // limit dsp 9999
			string str2 = "x " + val2.ToString(st2);
			
			gameCount_text.text = str2.ToString();

			long w_point = sphere.point_count;
			gamePointDSP(w_point);


			// pauseitem count
			string st5 = @"D" + k.ToString();
			int val5 = (int)cubersFile.pauseitem_count;
			if (val5 > 999) val5 = 999; // limit dsp 999
			string str5 = val5.ToString(st5);
			
			pauseCount_text.text = str5.ToString();

            // timeresetitem count
            string st51 = @"D" + k.ToString();
            int val51 = (int)cubersFile.timeresetitem_count;
            if (val51 > 999) val51 = 999; // limit dsp 999
            string str51 = val51.ToString(st51);

            timereset_count.text = str51.ToString();

            // lifelostinvaliditem count
            string st52 = @"D" + k.ToString();
            int val52 = (int)cubersFile.lifelostinvaliditem_count;
            if (val52 > 999) val52 = 999; // limit dsp 999
            string str52 = val52.ToString(st52);

            lifelostinvalid_count.text = str52.ToString();

            // lostadd count
            string st6 = @"D" + k.ToString();
			int val6 = (int)cubersFile.lostadd_count;
			if (val6 > 999) val6 = 999; // limit dsp 999
			string str6 = val6.ToString(st6);
			
			lostadd_Count_text.text = str6.ToString();

			// モンスターカラーカウント表示ON?
			if (monsterColor) {
				// カラー別残りモンスター数を再表示
				monsterColorCount();
			}
			if (resetMonsterColor) {
                // 連鎖カウンター２Dパネル表示リセット
                setChainExplosionMonsterColorCountView();
				resetChainExplosionMonsterColorCountView();
				resetMonsterColor = false;
			}

            // イベントアイコン表示
            GameObject emi = GameObject.Find("emitter"); // gameObject. .GetComponent<counter>();
             bool eventstatus = emi.GetComponent<counter>().getEventInfo();
            if (eventstatus)
            {
                // イベントあり 該当アイコン表示
                setEventIcon();
            }
            // TODO:連鎖回数表示 画面デザイン変更に伴う削除
            /*
            chaine_count_1_text.gameObject.GetComponent<Text>().text = chain_1_count.ToString();
            chaine_count_2_text.gameObject.GetComponent<Text>().text = chain_2_count.ToString();
            chaine_count_3_text.gameObject.GetComponent<Text>().text = chain_3_count.ToString();
            */

            // タイムアタック　スタートカウントダウン表示フラグはsphere game_start()でセット
            if (startCountDown) {

				lastStopTimeSpan = new TimeSpan(0);

                // カウントダウン表示制御　連鎖開始時もカウントダウン有りに
                startCountDown_text.gameObject.SetActive(true);
                // テキストメッシュアニメーションカウントダウン５表示
                startCountDown_text5.gameObject.SetActive(true);
                //            switch (cubersFile.now_play_stage) {
                //	case 1:
                //	case 3:
                //	case 5:
                //		// スタートカウントダウンとりあえず非表示に コメントを外すとカウンターが表示される
                //		startCountDown_text.gameObject.SetActive(true);
                //		break;
                //	default:			
                //		startCountDown_text.gameObject.SetActive(false);
                //		break;
                //}
                countDownTime -= Time.deltaTime;

				int kk = 1;
				string st = @"D" + kk.ToString();
				int val = (int)countDownTime;
				string str = val.ToString(st);
				
				if (int.Parse(str) <= 0) {
					startCountDown_text.gameObject.SetActive(false);
                    // テキストメッシュアニメーションカウントダウン1非表示
                    startCountDown_text1.gameObject.SetActive(false);

                    startCountDown = false;
					countDownTime = emitter.startCountDownTimer;

                    int wait_timer = gravity_time_array[cubersFile.now_play_stage - 1, emitter.gravity_Timespan];
                    //int wait_timer = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                    emitter.player.playBGM(0);
                    /*if (wait_timer == 0)
                    {
                        emitter.gravity_Time = emitter.slowTempoTime;
                        emitter.gravity_Time += 0.99f;
                        emitter.player.playBGM(0);
                    }
                    else
                    {
                        emitter.gravity_Time = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                        emitter.gravity_Time += 0.99f;
                        switch ((int)emitter.gravity_Time)
                        {
                            case 1:
                            case 2:
                            case 3:
                            case 4:
                                emitter.player.playBGM(2);
                                break;
                            case 5:
                            case 6:
                            case 7:
                                emitter.player.playBGM(1);
                                break;
                            case 8:
                            case 9:
                            case 10:
                                emitter.player.playBGM(0);
                                break;
                        }
                    }
                    */
                    counter.timer = 0;
					timeChange = true; //true時、タイマースタート以外にモンスターの動きにも関係するプレーステータスの設定も行われる
				}
				else {
                    //startCountDown_text.text = str;
                    // テキストメッシュアニメーションカウントダウン非表示ON/OFF
                    switch (int.Parse(str))
                    {
                        case 1:
                            startCountDown_text1.gameObject.SetActive(true);
                            startCountDown_text2.gameObject.SetActive(false);
                            startCountDown_text3.gameObject.SetActive(false);
                            startCountDown_text4.gameObject.SetActive(false);
                            startCountDown_text5.gameObject.SetActive(false);
                            break;
                        case 2:
                            startCountDown_text1.gameObject.SetActive(false);
                            startCountDown_text2.gameObject.SetActive(true);
                            startCountDown_text3.gameObject.SetActive(false);
                            startCountDown_text4.gameObject.SetActive(false);
                            startCountDown_text5.gameObject.SetActive(false);
                            break;
                        case 3:
                            startCountDown_text1.gameObject.SetActive(false);
                            startCountDown_text2.gameObject.SetActive(false);
                            startCountDown_text3.gameObject.SetActive(true);
                            startCountDown_text4.gameObject.SetActive(false);
                            startCountDown_text5.gameObject.SetActive(false);
                            break;
                        case 4:
                            startCountDown_text1.gameObject.SetActive(false);
                            startCountDown_text2.gameObject.SetActive(false);
                            startCountDown_text3.gameObject.SetActive(false);
                            startCountDown_text4.gameObject.SetActive(true);
                            startCountDown_text5.gameObject.SetActive(false);
                            break;
                        case 5:
                            startCountDown_text1.gameObject.SetActive(false);
                            startCountDown_text2.gameObject.SetActive(false);
                            startCountDown_text3.gameObject.SetActive(false);
                            startCountDown_text4.gameObject.SetActive(false);
                            startCountDown_text5.gameObject.SetActive(true);
                            break;
                    }
                }
            }


			// game time プレー中の時間表示
			if (timeChange) changeTimeStats();
			// startCountDownは、ゲーム開始時のカウントダウン表示フラグ
			if (!sphere.timer_Stop && !startCountDown) {
				// ゲームプレイ時間表示
				UpdateTime();
                // 連鎖時のボーナス減処理ありか？ swChangeTempoが0以外の時チェーンボムボーナスあり
                //if (swChangeTempo != 0) {
                //	chainExplosionTempoChange(swChangeTempo);
                //	swChangeTempo = 0;
                //}
                // ゲームテンポゲージ表示
                //gametempoCount += Time.deltaTime;
                //gameTempo();
                // モンスター落下ボタンゲージ表示
                //				sphereDownGauge();
            }

            // ポーズ中か？
            if (emitter.sw_pause && !emitter.sw_stop)
            {
                //pauseTimer_text.gameObject.SetActive(true);
                int kk = 1;
                string st = @"D" + kk.ToString();
                int val = (int)emitter.pause_timer;
                string str = val.ToString(st);
                pauseTimer_text.text = str;
                Sphere.waitTimerCountDown_DSP(str);
            }
            else if (emitter.sw_pause && emitter.sw_stop)
            {
                // Banner click after
                pauseTimer_text.text = "∞";

            }
            else
            {
                pauseTimer_text.gameObject.SetActive(false);
                // TODO:AD バナー広告の初期化
                //if (bannerView != null)
                //{
                //    bannerView.Destroy();
                //}
            }

			// pause ON
			if (pauseON) {
				Color cl = b_Pause.image.color;
				float alp = Mathf.PingPong(Time.time * 2.0f, 1.0f);
				b_Pause.image.color = new Color(cl.r,cl.g,cl.b,alp);
			}
			else {
				//pause_text.gameObject.SetActive(false);
                pause_banner_BG.gameObject.SetActive(false);
                Color cl = b_Pause.image.color;
				float alp = 1.0f;
				b_Pause.image.color = new Color(cl.r,cl.g,cl.b,alp);
			}

            // --------------------------------------------------------------------------------------------------------------------------------
            //  ゲームエンド時の処理
            // --------------------------------------------------------------------------------------------------------------------------------
            // ゲーム終了時の確認及び各処理　status&playtime
            // ゲームステータス表示有か？　ゲームステータスの表示の有無で判定
            if (sphere.gameStatus_text != "") {
				// センターフィールド表示中？
				//if (!s_center_View.gameObject.activeSelf) {
    //                // 表示前なら　センターフィールドの表示ポジション計算及び表示、センターフィールドへの内容表示までの待機時間設定
    //                Vector2 size = s_center_View.rectTransform.sizeDelta;
    //                center_View_orgSize = size;
    //                size.y = gameStatus_text.rectTransform.sizeDelta.y+ 20;
    //                s_center_View.rectTransform.sizeDelta = size;
				//	Vector3 pos = s_center_View.transform.position;
				//	pos.y = Screen.height/2 - s_center_View.rectTransform.sizeDelta.y/2;
    //                s_center_View.transform.position = pos;

				//	Vector3 pos_s = gameStatus_text.transform.position;
				//	pos_s.y = s_center_View.transform.position.y + s_center_View.rectTransform.sizeDelta.y/2 - gameStatus_text.rectTransform.sizeDelta.y/2;
				//	gameStatus_text.transform.position = pos_s;

    //                s_center_View.gameObject.SetActive(true);
				//	//s_gameStatus_text.gameObject.SetActive(true);

				//	gameStatus_text.text = sphere.gameStatus_text;
				//	statusTime = 2;

				//}
				//else {
					// センターフィールド内容表示までのカウントダウン
					statusTime -= Time.deltaTime;
					
					int kk = 1;
					string st = @"D" + kk.ToString();
					int val = (int)statusTime;
					string str = val.ToString(st);
					
					if (int.Parse(str) <= 0) {

						if (sphere.gameStatus_text == emitter.gameclear_msg) {

                            // --------------------------------------------------------------------------------------------------------------------------------
                            //  ゲームコンプリート処理
                            gameClearGetItemDSP = true;         //  ゲームクリア時の取得アイテム表示処理ON

                            sphere.gameStatus_text = "";

                            // TODO:1-1-3修正ステージクリア情報セット
                            IDictionary dt = (IDictionary)cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1];
                            // レベルクリア済みデータセット
                            dt["status"] = 1;
                            cubersFile.stage[cubersFile.now_play_stage - 1].leveldata[(int)cubersFile.now_play_stagelevel - 1] = dt;
                            cubersFile.cubersFile_instance.save_gameEncryptionData();

                            // TODO:1-1-3修正　レベル攻略情報デザイン変更に伴い下記修正
                            // ロストライフ＆プレータイムデータセット
                            s_LifeLostCount_text.GetComponent<Text>().text = (emitter.lost_count_MAX - sphere.lost_Spheres).ToString();
                            //s_gameTimeEnd_text.text = s_gameTime_text.text;

                            // ゲームクリアステータスメッセージオフ
                            s_center_View.gameObject.SetActive(false);
                            s_gameStatus_text.gameObject.SetActive(false);

                            // ゲームクリアビューオン
                            complete_view.gameObject.SetActive(true);
							//sphere.gameover = false;
							//sphere.complete = false;
                            // 念の為ゲーム失敗表示ビューオフ
                            failed_view.gameObject.SetActive(false);

                            // レベルタイトル
                            // TODO:削除　レベルバッジをレベル数に差し替える場合、下記レベルタイトルセットは削除
                            complete_level_text.gameObject.GetComponent<TMPro.TextMeshProUGUI>().text = "Stage: " + cubersFile.now_play_stage.ToString() + " Level: " + cubersFile.now_play_stagelevel.ToString() + " -";
                            // レベルバッジ表示
                            img = complete_level_image.GetComponent<Image>();
                            var stage = (int)cubersFile.now_play_stage;
                            var level = (int)cubersFile.now_play_stagelevel;
                            // リソースステージバッジイメージデータのセット
                            setLevelImageBadge(stage, level, 1);
                            complete_level_image.gameObject.SetActive(true);

                            // TODO:1-1-3 修正　
                            // レベルロストカウントセット
                            // ゲームクリアなら　プレーロストカウント0かのチェック＆ロストカウントセーブ
                            // lostCountCheck()内で ロストカウントをセーブ
                            setLostCount();
                            // TODO:1-1-3 修正　
                            // playTimeCheck()内でプレイ時間をセーブし、ベストタイムなら更新演出表示
                            setPlayTime();
                            // TODO:1-1-3 追加
                            // 最大連鎖数データセット＆連鎖数更新チェック
                            setMaxChainCount();
                            // TODO:1-1-3 追加
                            // 取得アイテム確認メッセージ
                            setGetItemData();

                            // TODO:1-1-5 追加　各データ更新時のスター表示演出処理
                            setScoreUpdateStarEffect();

                            // New 25-03 Get jewelry Count add & Star DSP.
                            setGetJewelryCount();


                            // TODO:1-1-4追加 レベルMAX時チェック
                            // レベルMAX攻略か？
                            if ((int)cubersFile.now_play_stagelevel ==  cubersFile.game_stagelevel_max)
                            {
/*                                // レベルMAX時、ステージクリア情報を表示する
                                setStageTotalClearInfo();
                                // レベルMAX時、ステージクリア情報をセットする
                                stage_Data stg1 = cubersFile.stage[(int)cubersFile.now_play_stage - 1];
                                // ステージ攻略済み
                                stg1.status = 2;
                                stg1.last_level = cubersFile.game_stagelevel_max;
                                cubersFile.stage[(int)cubersFile.now_play_stage - 1] = stg1;
                                // 次のロックステージをオフする
                                if ((int)cubersFile.now_play_stage != emitter.user_stage_max)
                                {
                                    stage_Data stg2 = cubersFile.stage[(int)cubersFile.now_play_stage];
                                    // ステージプレイ中ステータスに変更
                                    stg2.status = 1;
                                    cubersFile.stage[(int)cubersFile.now_play_stage] = stg2;
                                }
                                cubersFile.cubersFile_instance.save_gameEncryptionData();
*/
                            }
                            else
                            {
                                // レベル攻略中ステージクリア情報をセットする
/*                                stage_Data stg1 = cubersFile.stage[(int)cubersFile.now_play_stage - 1];
                                // ステージ攻略済み
                                stg1.status = 2;
                                // 最後に攻略したレベルを保存　セーブレベルデータ有りの場合からの再開は、そのレベルを起点として最後に攻略したレベルとなる
                                // レベル１からの再開の場合、保存された攻略レベルステータスを０リセットする　そのほかの内容は、そのままでもデータ自身無効
                                stg1.last_level = cubersFile.now_play_stagelevel;
                                cubersFile.stage[(int)cubersFile.now_play_stage - 1] = stg1;

                                cubersFile.cubersFile_instance.save_gameEncryptionData();
 */                           }
                            // ボタン入力待ち
                            gameStatus_text.text = "";

                        }
                        else {
                            // --------------------------------------------------------------------------------------------------------------------------------
                            // ゲームオーバー時の処理
                            //// ゲームクリアメッセージオフ
                            failed_view.gameObject.SetActive(true);
                            sphere.gameStatus_text = "";
                            //sphere.gameover = false;
							//sphere.complete = false;

                            var stage = (int)cubersFile.now_play_stage;
                            var level = (int)cubersFile.now_play_stagelevel;
                            // リソースステージバッジイメージデータのセット
                            setLevelImageBadge(stage, level, 2);

/*                            // TODO:追加 リトライアイテム個数表示
                            if (cubersFile.item_retry > 999)
                            {
                                retryItemCount_text.fontSize = 42;
                                retryItemCount_text.text = "+999";
                            }
                            else
                            {
                                retryItemCount_text.fontSize =  58;
                                retryItemCount_text.text = cubersFile.item_retry.ToString();
                            }

                            Vector2 size = s_center_View.rectTransform.sizeDelta;
							Vector3 pos = s_center_View.transform.position;
							pos.y = pos.y - size.y + 20;
							Vector3 pos_failed = failed_view.transform.position;
							pos_failed.y = pos.y;
							failed_view.transform.position = pos_failed;
 */                          // ボタン入力待ち
                            gameStatus_text.text = "";
                            //s_center_View.gameObject.SetActive(false);
                            //s_center_View.rectTransform.sizeDelta = center_View_orgSize;

                            //Debug.Log("pos_failed:" + pos_failed);

                        }

                    }
				//}
			}

            // --------------------------------------------------------------------------------------------------------------------------------
            // TODO:追加　1-1-5 ２：レベル攻略の連鎖獲得アイテム表示処理
            //  ゲームクリア時の取得アイテム表示処理
            if (gameClearGetItemDSP)
            {
                 if (emitter.playGetSilverItemCount <= 0)
                {
                    // アイテム表示（拡大演出）リセット
                    showItemDSP();
                    // ネクスト、エンドボタンをgameClearGetItemDSPフラグをオフする事により有効化となる　各ボタン処理でgameClearGetItemDSPがオン時はスルーされる
                    gameClearGetItemDSP = false;
                }
                 else
                {
                    if (showChainExplosionItemTimer <= 0)
                    {
                        // next Item
                        showChainExplosionItemTimer = 0.2f;

                        // 取得済みシルバーアイテム数１減算
                        emitter.playGetSilverItemCount--;
                        // プレイ画面シルバー、ゴールドアイコン表示処理
                        showChangeItem();
                    }
                    else
                    {
                        // 表示ウェイト
                        showChainExplosionItemTimer -= Time.deltaTime;
                    }
                }
            }

            // --------------------------------------------------------------------------------------------------------------------------------
            // TODO:追加　1-1-2 2:アイテム購入画面遷移ボタン処理を追加する
            // itemViewスライド
            // --------------------------------------------------------------------------------------------------------------------------------

            // slim card control view -> gacha
            if (gf_Move) {
				if (gf_Up) {

                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        slimCard_View.gameObject.SetActive(true);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    gf_Move = false;
                }
                else {
                    int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
                    if (mod == 0)
                    {
                        // 連鎖パネル表示リセット　パネルマスクオン時のリセットが無いのでここで非表示とする　連鎖カウント等は別個所でセット
                        greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        redMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        whiteMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        s_monsterSlimeColorCountView.gameObject.SetActive(false);
                    }
                    else
                    {
                        // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオフにする
                        s_monsterSlimeColorCountView.gameObject.SetActive(false);
                    }

                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        slimCard_View.gameObject.SetActive(false);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });

                    /*int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
                    if (mod == 0)
                    {
                        // 連鎖パネル表示リセット　パネルマスクオン時のリセットが無いのでここで非表示とする　連鎖カウント等は別個所でセット
                        greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        redMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        whiteMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオンにする
                        s_monsterSlimeColorCountView.gameObject.SetActive(true);
                    }
                    else
                    {
                        // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオフにする
                        s_monsterSlimeColorCountView.gameObject.SetActive(false);
                    }

                    var seq = DOTween.Sequence();
                    seq.Append(game_select_view.rectTransform.DOMove(new Vector3(0, -Screen.height, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる

                    });*/
                    gf_Move = false;
                }
            }
            // game stage_select field
            if (gsf_Move)
            {
                if (gsf_Up)
                {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        game_stage_select_view.gameObject.SetActive(true);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    /*var seq = DOTween.Sequence();
                    seq.Append(game_stage_select_view.rectTransform.DOMove(new Vector3(0, pos_gs.y, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる
                    });
                    */
                    gsf_Move = false;

                    //game_stage_select_view.GetComponent<RectTransform>().Translate(new Vector3(0, 100, 0) * f_Speed * Time.deltaTime);
                    //if (game_stage_select_view.transform.position.y >= pos_gs.y)
                    //{
                    //    Vector3 pos = game_stage_select_view.GetComponent<RectTransform>().position;
                    //    pos.y = pos_gs.y;
                    //    game_stage_select_view.rectTransform.position = pos;
                    //    gsf_Move = false;
                    //}

                }
                else
                {
                    int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
                    if (mod == 0)
                    {
                        // 連鎖パネル表示リセット　パネルマスクオン時のリセットが無いのでここで非表示とする　連鎖カウント等は別個所でセット
                        greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        redMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        whiteMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                        // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオンにする
                        s_monsterSlimeColorCountView.gameObject.SetActive(false);
                    }
                    else
                    {
                        // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオフにする
                        s_monsterSlimeColorCountView.gameObject.SetActive(false);
                    }

                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        game_stage_select_view.gameObject.SetActive(false);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });

                    /*var seq = DOTween.Sequence();
                    seq.Append(game_stage_select_view.rectTransform.DOMove(new Vector3(0, -Screen.height, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる

                    });*/
                    gsf_Move = false;

                }
            }
			// item View
			if (if_Move) {
				if (if_Up) {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        item_View.gameObject.SetActive(true);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    if_Move = false;

/*                    seq.Append(item_View.rectTransform.DOMove(new Vector3(0, pos_gs.y, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる
                    });
                    if_Move = false;
*/

/*                    item_View.GetComponent<RectTransform>().Translate(new Vector3 (0,100,0) * f_Speed * Time.deltaTime);
					if (item_View.transform.position.y >= 0) {
						Vector3 pos = item_View.GetComponent<RectTransform>().position;
						pos.y = 0.0f;
                        item_View.rectTransform.position = pos;
						if_Move = false;
					}
*/				}
				else {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        item_View.gameObject.SetActive(false);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    if_Move = false;

/*                    var seq = DOTween.Sequence();
                    seq.Append(item_View.rectTransform.DOMove(new Vector3(0, -Screen.height, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる

                    });
                    if_Move = false;
*/
/*                    item_View.GetComponent<RectTransform>().Translate(new Vector3 (0,-100,0) * f_Speed * Time.deltaTime);
					if (item_View.transform.position.y <= -item_View.rectTransform.sizeDelta.y) {
						Vector3 pos = item_View.GetComponent<RectTransform>().position;
						pos.y = -item_View.rectTransform.sizeDelta.y;
                        item_View.GetComponent<RectTransform>().position = pos;
						if_Move = false;
                        item_View.gameObject.SetActive(false);
					}
*/				}
			}
            // TODO:1-1-11 追加 新規設定画面処理の作成
            // setting view
            if (is_Move)
            {
                if (is_Up)
                {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        setting_View.gameObject.SetActive(true);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    /*var seq = DOTween.Sequence();
                    seq.Append(setting_View.rectTransform.DOMove(new Vector3(0, pos_gs.y, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる
                    });*/
                    is_Move = false;
/*
                    setting_View.GetComponent<RectTransform>().Translate(new Vector3(0, 100, 0) * f_Speed * Time.deltaTime);
                    if (setting_View.transform.position.y >= 0)
                    {
                        Vector3 pos = setting_View.GetComponent<RectTransform>().position;
                        pos.y = 0.0f;
                        setting_View.rectTransform.position = pos;
                        is_Move = false;
                    }
*/                }
                else
                {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        setting_View.gameObject.SetActive(false);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    /*var seq = DOTween.Sequence();
                    seq.Append(setting_View.rectTransform.DOMove(new Vector3(0, -Screen.height, 0), 1));
                    seq.OnComplete(() =>
                    {
                        // アニメーションが終了時によばれる

                    });*/
                    is_Move = false;
/*
                    setting_View.GetComponent<RectTransform>().Translate(new Vector3(0, -100, 0) * f_Speed * Time.deltaTime);
                    if (setting_View.transform.position.y <= -setting_View.rectTransform.sizeDelta.y)
                    {
                        Vector3 pos = setting_View.GetComponent<RectTransform>().position;
                        pos.y = -setting_View.rectTransform.sizeDelta.y;
                        setting_View.GetComponent<RectTransform>().position = pos;
                        is_Move = false;
                        setting_View.gameObject.SetActive(false);
                    }
*/                }
            }
            // TODO:1-1-１4 追加 ユーザー設定画面処理
            // user name view
            if (nv_Move)
            {
                if (nv_Up)
                {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        userName_view.gameObject.SetActive(true);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    nv_Move = false;
                    /*userName_view.GetComponent<RectTransform>().Translate(new Vector3(0, 100, 0) * f_Speed * Time.deltaTime);
                    if (userName_view.transform.position.y >= 0)
                    {
                        Vector3 pos = userName_view.GetComponent<RectTransform>().position;
                        pos.y = 0.0f;
                        userName_view.rectTransform.position = pos;
                        nv_Move = false;
                    }*/
                }
                else
                {
                    screen_Mask.gameObject.SetActive(true);
                    var seq = DOTween.Sequence();
                    seq.Append(screen_Mask.DOFade(1, do_duration));
                    seq.OnComplete(() =>
                    {
                        userName_view.gameObject.SetActive(false);
                        var seq = DOTween.Sequence();
                        seq.Append(screen_Mask.DOFade(0, do_duration));
                        seq.OnComplete(() =>
                        {
                            screen_Mask.gameObject.SetActive(false);
                        });
                    });
                    nv_Move = false;
                    /*userName_view.GetComponent<RectTransform>().Translate(new Vector3(0, -100, 0) * f_Speed * Time.deltaTime);
                    if (userName_view.transform.position.y <= -userName_view.rectTransform.sizeDelta.y)
                    {
                        Vector3 pos = userName_view.GetComponent<RectTransform>().position;
                        pos.y = -userName_view.rectTransform.sizeDelta.y;
                        userName_view.GetComponent<RectTransform>().position = pos;
                        nv_Move = false;
                        userName_view.gameObject.SetActive(false);
                    }*/
                }
            }
        }
        // TODO:追加　1-1-5 獲得アイテム処理
        // set ScoreUpdate Star Effect disp.
        public void  setScoreUpdateStarEffect()
        {
            /*if (max_chain_Mes_BG.gameObject.activeSelf == true)
            {
                // 連鎖最高数更新あり
                Vector2 scale1 = s_maxChain_star.rectTransform.localScale;
                scale1.x = 0.1f;
                scale1.y = 0.1f;
                s_maxChain_star.rectTransform.localScale = scale1;
                s_maxChain_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

                var seq1 = DOTween.Sequence();
                seq1.Append(s_maxChain_star.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                seq1.Join(s_maxChain_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                    2.0f                    // アニメーション時間
                ));
                seq1.OnComplete(() => {
                    // アニメーションが終了時によばれる
                    s_maxChain_star.gameObject.SetActive(false);
                });

            }
            if (get_Item_Mes_BG.gameObject.activeSelf == true)
            {
                // アイテム取得あり
                Vector2 scale2 = s_getItem_star.rectTransform.localScale;
                scale2.x = 0.1f;
                scale2.y = 0.1f;
                s_getItem_star.rectTransform.localScale = scale2;
                s_getItem_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

                var seq2 = DOTween.Sequence();
                seq2.Append(s_getItem_star.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                seq2.Join(s_getItem_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                    2.0f                    // アニメーション時間
                ));
                seq2.OnComplete(() => {
                    // アニメーションが終了時によばれる
                    s_getItem_star.gameObject.SetActive(false);
                });

            }
            if (lifeLostCount_Zero.gameObject.activeSelf == true)
            {
                // ライフロスト０？
                Vector2 scale1 = s_lifeLostCount_Zero_star.rectTransform.localScale;
                scale1.x = 0.1f;
                scale1.y = 0.1f;
                s_lifeLostCount_Zero_star.rectTransform.localScale = scale1;
                s_lifeLostCount_Zero_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

                var seq1 = DOTween.Sequence();
                seq1.Append(s_lifeLostCount_Zero_star.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                seq1.Join(s_lifeLostCount_Zero_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                    2.0f                    // アニメーション時間
                ));
                s_lifeLostCount_Zero_star.gameObject.SetActive(true);
                seq1.OnComplete(() => {
                    // アニメーションが終了時によばれる
                    s_lifeLostCount_Zero_star.gameObject.SetActive(false);
                });

            }*/
                    if (besttime_text.gameObject.activeSelf == true)
            {
                // プレイ時間更新？
                Vector2 scale2 = s_besttime_text_star.rectTransform.localScale;
                scale2.x = 0.1f;
                scale2.y = 0.1f;
                s_besttime_text_star.rectTransform.localScale = scale2;
                s_besttime_text_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

                var seq2 = DOTween.Sequence();
                seq2.Append(s_besttime_text_star.rectTransform.DOScale(new Vector3(2.0f, 2.0f), 1.0f));
                seq2.Join(s_besttime_text_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                    2.0f                    // アニメーション時間
                ));
                s_besttime_text_star.gameObject.SetActive(true);
                seq2.OnComplete(() => {
                    // アニメーションが終了時によばれる
                    s_besttime_text_star.gameObject.SetActive(false);
                });

            }
        }

        // New 25-03 Get jewelry Count add & Star DSP.
        public void setGetJewelryCount()
        {
            // 所持魔法石に連鎖でゲットした魔法石を加算して表示と獲得魔法石を加算した数値をcubersFileにセーブ
            jewelry_text.text = ((long)emitter.jewelry_Count_total + cubersFile.jewelry_Count).ToString();
            cubersFile.jewelry_Count += (long)emitter.jewelry_Count_total;
            cubersFile.cubersFile_instance.save_gameEncryptionData();

            getItem_Count_text.text = emitter.jewelry_Count_total.ToString();

            // ジュエリーカウントアップエフェクト表示
            var seq = DOTween.Sequence();
            seq.Append(jewelryCountIcon.transform.DOScale(new Vector3(1.5f, 1.5f), 0.5f));
            seq.Append(jewelryCountIcon.transform.DOScale(new Vector3(1.5f, 1.5f), 2.0f));
            seq.OnComplete(() =>
            {
                // アニメーションが終了時によばれる
                Vector3 scal = jewelryCountIcon.gameObject.transform.localScale;
                scal.x = 1.0f;
                scal.y = 1.0f;
                jewelryCountIcon.gameObject.transform.localScale = scal;
            });

            // Star Dsp.
            Vector2 scale2 = jewelry_star.rectTransform.localScale;
            scale2.x = 0.1f;
            scale2.y = 0.1f;
            jewelry_star.rectTransform.localScale = scale2;
            jewelry_star.rectTransform.rotation = Quaternion.Euler(0, 0, 0);

            var seq2 = DOTween.Sequence();
            seq2.Append(jewelry_star.rectTransform.DOScale(new Vector3(1.0f, 1.0f), 1.0f));
            seq2.Join(jewelry_star.rectTransform.DORotate(new Vector3(0f, 0f, 180f),   // 終了時点のRotation
                2.0f                    // アニメーション時間
            ));
            jewelry_star.gameObject.SetActive(true);
            seq2.OnComplete(() => {
                // アニメーションが終了時によばれる
                jewelry_star.gameObject.SetActive(false);
            });
        }

        //動画視聴完了時
        private void OnFinished(){
			Debug.Log ("完了");
			tt_Move = true;
			tt_Up = false;
		}

		//動画視聴失敗時
		private void OnFailed(){
			Debug.Log ("失敗");
		}

		//動画視聴キャンセル時
		private void OnSkipped(){
			Debug.Log ("キャンセル");
		}

		// gameplay time update
		void UpdateTime() {

			// ポーズ時に時間を止める場合、下記判定からポーズを外してプレーのみとする
			if (emitter.playState == emitter.gamePlayState.Play || emitter.playState == emitter.gamePlayState.Pause) {
//			if (emitter.playState == emitter.gamePlayState.Play) {
				TimeSpan ts = DateTime.UtcNow - startDateTime;
				currentTs = ts + lastStopTimeSpan;

			} else {
				currentTs = lastStopTimeSpan;
			}
            int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
            if (mod == 0) {
                // 連鎖時のプレイタイム表示
                if (gameTime_text != null)
                {
                    gameTime_text.text = ConvertTimeSpanToString(currentTs);
                    gameTimeEnd_text.text = gameTime_text.text;
                    playEndTimeSpan = currentTs;
                }
            }
            else {
                // 連鎖無し時のプレイタイム表示
                if (noChainGameTime_text != null)
                {
                    noChainGameTime_text.text = ConvertTimeSpanToString(currentTs);
                    gameTimeEnd_text.text = noChainGameTime_text.text;
                    playEndTimeSpan = currentTs;
                }
            }
        }

		static public string ConvertTimeSpanToString(TimeSpan ts) {
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3}", ts.Days * 24 + ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds.ToString("000").Substring(0, 2));
   //         if (ts.Hours > 0 || ts.Days > 0) {
			//	return string.Format("{0}:{1:D2}:{2:D2}.{3}", ts.Days * 24 + ts.Hours, ts.Minutes, ts.Seconds, ts.Milliseconds.ToString("000").Substring(0, 2));
			//} else {
			//	return string.Format("{0:D2}:{1:D2}.{2}", ts.Minutes, ts.Seconds, ts.Milliseconds.ToString("000").Substring(0, 2));
			//}
		}

		public void changeTimeStats() {

			state = emitter.playState;

			if (state == emitter.gamePlayState.Play || state == emitter.gamePlayState.Pause) {
//			if (state == emitter.gamePlayState.Play) {
//				startDateTime = DateTime.UtcNow;
			}
			// ポーズ時に時間を止める場合、下記コメントを外して上記判定からポーズを外す
//			else if (state == emitter.gamePlayState.Pause) {
//				TimeSpan ts = DateTime.UtcNow - startDateTime;
//				lastStopTimeSpan = ts + lastStopTimeSpan;
//			}
			else if (state == emitter.gamePlayState.Zero) {
				lastStopTimeSpan = new TimeSpan(0);
				startDateTime = DateTime.UtcNow;
				emitter.playState = emitter.gamePlayState.Play;

				// ゲームテンポカウンターリセット
				gametempoCount = 0;
			}
			timeChange = false;
		}

        // TODO:追加　1-1-6 ゲームステージ選択メニュー画面修正
        //   ステージ選択ボタン押下時のレベル確認画面クローズ処理
        public void buttonSelectConfirmClose()
        {
            // レベル確認画面
            startSaveLevelConfirm_View.gameObject.SetActive(false);
            // ステージ選択メニュー表示
            ButtonSlimCardClick();

        }
        // ステージ選択ボタン押下時の確認画面にて、スタートセーブレベル選択
        public void buttonSelectStartSaveLevel()
        {
            // 開始レベル確認画面
            startSaveLevelConfirm_View.gameObject.SetActive(false);
            stage_Data stg1 = cubersFile.stage[(int)cubersFile.now_play_stage - 1];
            var saveLevel = (int)stg1.monthlyService_SaveLevel;
            if (saveLevel == 0) saveLevel = 1;
            setStageSelectLevel(saveLevel);                     // セーブサービス利用　セーブレベルデータを設定

        }

        // ステージ選択ボタン押下時の確認画面にて、スタートセーブレベル選択
        public void buttonSelectStartSaveNextLevel()
        {
            // 開始レベル確認画面
            startSaveLevelConfirm_View.gameObject.SetActive(false);
            stage_Data stg1 = cubersFile.stage[(int)cubersFile.now_play_stage - 1];
            var saveLevel = (int)stg1.monthlyService_SaveLevel;
            if (saveLevel == cubersFile.game_stagelevel_max)
            {
                setStageSelectLevel(saveLevel);                     // セーブサービス利用　セーブレベルデータを設定
            }
            else
            {
                saveLevel++;
                setStageSelectLevel(saveLevel);                     // セーブサービス利用　セーブレベルデータを設定
            }
        }

        // ステージ選択ボタン押下時の確認画面にて、新規スタートレベル選択
        public void buttonSelectStartNewLevel()
        {
            // 開始レベル確認画面
            startSaveLevelConfirm_View.gameObject.SetActive(false);
            setStageSelectLevel(1);     // セーブサービス利用無し　レベル１データを設定
        }

        // TODO:連鎖ありカウントパネルイメージ設定
        public void setChainBombPanelImage(int stage)
        {
            switch(stage)
            {
                case 2:
                    greenMonsterSlimeCountImage.GetComponent<Image>().sprite = greenMonsterSlimeCountImageTexture1;
                    yellowMonsterSlimeCountImage.GetComponent<Image>().sprite = yellowMonsterSlimeCountImageTexture1;
                    redMonsterSlimeCountImage.GetComponent<Image>().sprite = redMonsterSlimeCountImageTexture1;
                    purpleMonsterSlimeCountImage.GetComponent<Image>().sprite = purpleMonsterSlimeCountImageTexture1;
                    blueMonsterSlimeCountImage.GetComponent<Image>().sprite = blueMonsterSlimeCountImageTexture1;
                    whiteMonsterSlimeCountImage.GetComponent<Image>().sprite = whiteMonsterSlimeCountImageTexture1;
                    break;
                case 4:
                    greenMonsterSlimeCountImage.GetComponent<Image>().sprite = greenMonsterSlimeCountImageTexture2;
                    yellowMonsterSlimeCountImage.GetComponent<Image>().sprite = yellowMonsterSlimeCountImageTexture2;
                    redMonsterSlimeCountImage.GetComponent<Image>().sprite = redMonsterSlimeCountImageTexture2;
                    purpleMonsterSlimeCountImage.GetComponent<Image>().sprite = purpleMonsterSlimeCountImageTexture2;
                    blueMonsterSlimeCountImage.GetComponent<Image>().sprite = blueMonsterSlimeCountImageTexture2;
                    whiteMonsterSlimeCountImage.GetComponent<Image>().sprite = whiteMonsterSlimeCountImageTexture2;
                    break;
                case 6:
                    greenMonsterSlimeCountImage.GetComponent<Image>().sprite = greenMonsterSlimeCountImageTexture3;
                    yellowMonsterSlimeCountImage.GetComponent<Image>().sprite = yellowMonsterSlimeCountImageTexture3;
                    redMonsterSlimeCountImage.GetComponent<Image>().sprite = redMonsterSlimeCountImageTexture3;
                    purpleMonsterSlimeCountImage.GetComponent<Image>().sprite = purpleMonsterSlimeCountImageTexture3;
                    blueMonsterSlimeCountImage.GetComponent<Image>().sprite = blueMonsterSlimeCountImageTexture3;
                    whiteMonsterSlimeCountImage.GetComponent<Image>().sprite = whiteMonsterSlimeCountImageTexture3;
                    break;
            }
        }
        public RankBadge rankbadge;
        //   ステージ選択ボタン押下処理
        public void buttonSelectCell(Button level)
        {
            if (level.gameObject.tag == "99")
            {
                //s_center_field.gameObject.SetActive(true);
                //s_mainMenu_field.gameObject.SetActive(true);
                //s_center_View.rectTransform.sizeDelta = center_View_orgSize;
                setCenterView(1);

                gf_Move = true;
                gf_Up = false;
                return;
            }

            //canvasPanel.s_mainMenu_field.gameObject.SetActive(false);       //背景フルのブラック半透明　オン・オフ
			cubersFile.now_play_stage = int.Parse(level.gameObject.tag);    // ステージ選択 番号

            // TODO:連鎖ありカウントパネルイメージ設定
            setChainBombPanelImage((int)cubersFile.now_play_stage);

            //// TODO:Rank Badge setting
            //rankbadge.setRankBadge((int)cubersFile.now_play_stage, (int)cubersFile.now_play_stagelevel);

            // TODO:削除　1-1-1 1:現在のレベルメニューを削除しステージ選択からの遷移を取り止め　不要となったソース部分の削除
            //Create_GameStageSelectView();

            // TODO:追加　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更　↓
            // セーブサービス利用可能チェック＆レベル設定、レベル基本データ設定処理
            bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
            if (monthlyservice)
            {
                // 開始レベル確認画面
                startSaveLevelConfirm_View.gameObject.SetActive(true);

            } else
            {
                setStageSelectLevel(1);     // セーブサービス利用無し　レベル１データを設定
            }
            // TODO:追加　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更  ↑

            gf_Move = true;
            gf_Up = false;

            // TODO:追加　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更　 レベル選択メニュー廃止の為、下記処理削除
            //if (!gsf_Up)
            //{

            //    Vector3 gselect_scal = game_stage_select_view.transform.localScale;
            //    pos_gs = game_stage_select_view.transform.position;
            //    pos_gs.y = (Screen.height / 2) - (game_stage_select_view.rectTransform.sizeDelta.y * gselect_scal.y / 2);

            //    //mainMenu_field.gameObject.SetActive(true);
            //    game_stage_select_view.gameObject.SetActive(true);
            //    gsf_Up = true;
            //    gsf_Move = true;

            //}
            //else
            //{
            //    gsf_Up = false;

            //}

        }

        //   ステージ選択ボタン押下処理
        public void buttonSelectCell2(int stage, int level)
        {
            if (level == 99)
            {
                //s_center_field.gameObject.SetActive(true);
                //s_mainMenu_field.gameObject.SetActive(true);
                //s_center_View.rectTransform.sizeDelta = center_View_orgSize;
                setCenterView(1);

                gsf_Move = true;
                gsf_Up = false;
                return;
            }

            cubersFile.now_play_stage = stage;    // ステージ選択 番号

            // TODO:連鎖ありカウントパネルイメージ設定
            setChainBombPanelImage((int)cubersFile.now_play_stage);

            setStageSelectLevel(level);     // セーブサービス利用無し　レベル１データを設定
                                            // TODO:追加　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更  ↑

            gsf_Move = true;
            gsf_Up = false;

        }

        // TODO:追加　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更
        // StageLevel Dataを設定する
        public void setStageSelectLevel(int selectLevel)
        {

            cubersFile.now_play_stagelevel = selectLevel;
            emitter.levelCheck(cubersFile.now_play_stage);

            // start処理は、sphereのstart_gameフラグによる呼び出しのgame_start()でcube処理もリセットされる
            sphere.start_game = true;

            gsf_Move = true;
            gsf_Up = false;

            sunshinerotate = 0;

            // 背景設定
            GameObject sceenBG = this.transform.root.gameObject;
            sceenBG.GetComponent<emitter>().setSceenDsp((int)cubersFile.now_play_stage);

            safeareaout_header_BG.gameObject.SetActive(true);
            safeareaout_footer_BG.gameObject.SetActive(true);
            //header_BG.gameObject.SetActive(true);
            //footer_BG.gameObject.SetActive(true);
            playItemView_button_BG.gameObject.SetActive(true);
            playSettingView_button_BG.gameObject.SetActive(true);
            down_button_L_BG.gameObject.SetActive(true);
            down_button_R_BG.gameObject.SetActive(true);
            right_header.gameObject.SetActive(true);
            left_header.gameObject.SetActive(true);
            center_header.gameObject.SetActive(true);
            b_Pause.gameObject.SetActive(true);

            //emitter.BGMstate = emitter.BGM_State.start;
            //emitter.playState = emitter.gamePlayState.Play;

            // ステージバッジ表示
            // TODO:バッジ変更に伴う修正
            img = rank_bg.GetComponent<Image>();
            var stage = (int)cubersFile.now_play_stage;
            var level = (int)cubersFile.now_play_stagelevel;
            rankbadge.setRankBadge(stage,level);
            // リソースステージバッジイメージデータのセット
            //getResourceLevelImageData(stage, level, img);
            //rank_bg.gameObject.SetActive(true);

            // TODO: 削除　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更　画面デザイン変更に伴い削除(コメントアウト)
            // ポイント、タイム表示
            //switch (stage)
            //{
            //    case 1:
            //    case 3:
            //    case 5:
            //        chain_count_BG.gameObject.SetActive(false);
            //        play_condition3.gameObject.SetActive(false);
            //        break;
            //    case 2:
            //    case 4:
            //    case 6:
            //        chain_count_BG.gameObject.SetActive(true);
            //        play_condition3.gameObject.SetActive(true);
            //        break;
            //}
            // ステージ条件表示
            //play_stage_no.gameObject.GetComponent<Text>().text = "STAGE\n" + cubersFile.now_play_stagelevel.ToString();
            //if (gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1] == 0)
            //    play_condition1_text.gameObject.GetComponent<Text>().text = "10-6s";
            //else
            //    play_condition1_text.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString() + "s";
            //play_condition2_text.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString();
            //play_condition3_text.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString();

            //switch (level)
            //{
            //    case 1:
            //    case 2:
            //        play_condition1.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
            //        play_condition2.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
            //        break;
            //    case 3:
            //    case 4:
            //        play_condition1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f);
            //        play_condition2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f);
            //        break;
            //    case 5:
            //    case 6:
            //    case 7:
            //        play_condition1.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
            //        play_condition2.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
            //        break;
            //}

            // 落下待機時間表示初期設定 ステージレベル選択時
            emitter.gravity_Timespan = 0;     // 可変落下時間配列のポジション開始10秒から
            emitter.gravity_Time = emitter.slowTempoTime;
            // wait_variable_timerCount　１カウント＝10秒刻み
            emitter.wait_variable_timerCount = emitter.wait_timer_variable;
            //emitter.wait_variable_timerCount = gravity_time_changeinterval_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1, emitter.gravity_Timespan_array];
            emitter.gravity_Time += 0.99f;

            /* int wait_timer = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
            if (wait_timer == 0)
            {
                emitter.gravity_Time = emitter.slowTempoTime; 
                emitter.gravity_Time += 0.99f;
            }
            else
            {
                emitter.gravity_Time = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                emitter.gravity_Time += 0.99f;
            }
            */
            setGravityWaitTimeDSP((int)emitter.gravity_Time);
            // sound Play setting
            //emitter.player.playBGM();
            //emitter.BGMstate = emitter.BGM_State.play;

        }

        // TODO:削除　1-1-1 2:レベル選択で行われていたデータ設定処理をステージ選択で行なうように変更
        //  選択ボタン押下処理
        /*       public void buttonStageSelectCell(Button levelBT)
               {

                   if (levelBT.gameObject.tag == "99")
                   {
                       gsf_Move = true;
                       gsf_Up = false;

                       game_select_view.gameObject.SetActive(true);
                       gf_Move = true;
                       gf_Up = true;
                       return;
                   }

                   //canvasPanel.s_mainMenu_field.gameObject.SetActive(false);
                   cubersFile.now_play_stagelevel = int.Parse(levelBT.gameObject.tag);
                   emitter.levelCheck(cubersFile.now_play_stage);

                   // start処理は、sphereのstart_gameフラグによる呼び出しのgame_start()でcube処理もリセットされる
                   sphere.start_game = true;

                   gsf_Move = true;
                   gsf_Up = false;

                   sunshinerotate = 0;

                   safeareaout_header_BG.gameObject.SetActive(true);
                   safeareaout_footer_BG.gameObject.SetActive(true);
                   header_BG.gameObject.SetActive(true);
                   footer_BG.gameObject.SetActive(true);
                   down_Top_button_L_BG.gameObject.SetActive(true);
                   down_Top_button_R_BG.gameObject.SetActive(true);
                   down_button_L_BG.gameObject.SetActive(true);
                   down_button_R_BG.gameObject.SetActive(true);
                   right_header.gameObject.SetActive(true);
                   left_header.gameObject.SetActive(true);
                   center_header.gameObject.SetActive(true);
                   b_Pause.gameObject.SetActive(true);
                   //b_share.gameObject.SetActive(true);
                   //b_change.gameObject.SetActive(true);

                   mainMenu_field.gameObject.SetActive(false);

                   emitter.BGMstate = emitter.BGM_State.start;

                   emitter.playState = emitter.gamePlayState.Play;

                   // ステージバッジ表示
                   img = rank_bg.GetComponent<Image>();
                   var stage = (int)cubersFile.now_play_stage;
                   var level = (int)cubersFile.now_play_stagelevel;
                   // リソースステージバッジイメージデータのセット
                   getResourceLevelImageData(stage, level, img);
                   rank_bg.gameObject.SetActive(true);

                   // ポイント、タイム表示
                   switch(stage)
                   {
                       case 1:
                       case 3:
                       case 5:
                           chain_count_BG.gameObject.SetActive(false);
                           //gamePoint.gameObject.SetActive(false);
                           play_condition3.gameObject.SetActive(false);
                           break;
                       case 2:
                       case 4:
                       case 6:
                           chain_count_BG.gameObject.SetActive(true);
                           //gamePoint.gameObject.SetActive(true);
                           play_condition3.gameObject.SetActive(true);
                           break;
                   }
                   // ステージ条件表示
                   play_stage_no.gameObject.GetComponent<Text>().text = "STAGE\n" + cubersFile.now_play_stagelevel.ToString();
                   if (gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1] == 0)
                       play_condition1_text.gameObject.GetComponent<Text>().text = "10-6s";
                   else
                       play_condition1_text.gameObject.GetComponent<Text>().text = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString() + "s";
                   play_condition2_text.gameObject.GetComponent<Text>().text = gravity_number_min_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString() + ".." + gravity_number_max_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString();
                   play_condition3_text.gameObject.GetComponent<Text>().text = chaine_count_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1].ToString();

                   switch (level)
                   {
                       case 1:
                       case 2:
                           play_condition1.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
                           play_condition2.GetComponent<Image>().color = new Color(0.0f, 1.0f, 0.0f);
                           break;
                       case 3:
                       case 4:
                           play_condition1.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f);
                           play_condition2.GetComponent<Image>().color = new Color(1.0f, 1.0f, 0.0f);
                           break;
                       case 5:
                       case 6:
                       case 7:
                           play_condition1.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
                           play_condition2.GetComponent<Image>().color = new Color(1.0f, 0.0f, 0.0f);
                           break;
                   }

                   // 落下待機時間表示初期設定
                   int wait_timer = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                   if (wait_timer == 0)
                   {
                       emitter.gravity_Time = emitter.slowTempoTime;
                       emitter.gravity_Time += 0.99f;
                       //emitter.player.playBGM(0);
                   }
                   else
                   {
                       emitter.gravity_Time = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
                       emitter.gravity_Time += 0.99f;
                       //switch ((int)emitter.gravity_Time)
                       //{
                       //    case 1:
                       //    case 2:
                       //    case 3:
                       //    case 4:
                       //        emitter.player.playBGM(2);
                       //        break;
                       //    case 5:
                       //    case 6:
                       //    case 7:
                       //        emitter.player.playBGM(1);
                       //        break;
                       //    case 8:
                       //    case 9:
                       //    case 10:
                       //        emitter.player.playBGM(0);
                       //        break;
                       //}
                   }
                   setGravityWaitTimeDSP((int)emitter.gravity_Time);


               }
        */
        public bool[] active_flg = { true, true, true, true, true, true, true, true, true, true };

        // 落下待機時間表示設定
        public void setGravityWaitTimeDSP(int w_time)
        {
            //Debug.Log("w_temp = " + w_time.ToString());
            if (w_time == beforeTime) return;
            beforeTime = w_time;

            //int w_temp = gravity_time_array[cubersFile.now_play_stage - 1, emitter.gravity_Timespan_array];
            //int w_temp = gravity_time_array[cubersFile.now_play_stage - 1, cubersFile.now_play_stagelevel - 1];
            // ラスト落下モンスタ時の待機時間　４s　gravityLastMonsterがオンの時ラストモンスタ落下モード
            if (w_time != 0) 
            //if (w_temp != 0 || emitter.gravityLastMonster)
            {
                waitingTimerGauge_BG.gameObject.SetActive(true);
                Level_top.gameObject.SetActive(true);

                switch (w_time)
                {
                    // 4秒以下　赤
                    case 1:
                    case 2:
                    case 3:
                    case 4:
                        Level_top.gameObject.GetComponent<Image>().color = Level3_1_Base_Color;
                        break;
                    // 7から5秒　黄
                    case 5:
                    case 6:
                    case 7:
                        Level_top.gameObject.GetComponent<Image>().color = Level2_1_Base_Color;
                        break;
                    // 10から8秒　緑
                    case 8:
                    case 9:
                    case 10:
                        Level_top.gameObject.GetComponent<Image>().color = Level1_1_Base_Color;
                        break;
                }
            }
            else
            {
                // 可変テンポ処理
                //if (sphere.gravitySpheres_count != 0)
                //{
                    gravityWaitTemp(w_time);
                //}
            }
            // 秒単位ゲージ表示
            for (int i = 0; i < 10; i++)
            {
                // 一旦すべてtrueへ
                active_flg[i] = true;
            }
            for (int i = w_time; i < 10; i++)
            {
                active_flg[i] = false;
            }
            Level1_1.gameObject.SetActive(active_flg[9]);
            Level1_2.gameObject.SetActive(active_flg[8]);
            Level1_3.gameObject.SetActive(active_flg[7]);
            Level2_1.gameObject.SetActive(active_flg[6]);
            Level2_2.gameObject.SetActive(active_flg[5]);
            Level2_3.gameObject.SetActive(active_flg[4]);
            Level3_1.gameObject.SetActive(active_flg[3]);
            Level3_2.gameObject.SetActive(active_flg[2]);
            Level3_3.gameObject.SetActive(active_flg[1]);
            Level3_4.gameObject.SetActive(active_flg[0]);

        }

        public Vector3 pos_gs;

        // TODO:修正・追加 1-1-3 月極サービス利用者用攻略レベルセーブ処理
        public void ButtonSaveLevelClick()
        {
            // 攻略レベルセーブ処理＆メインメニュー表示
            stage_Data stg1 = cubersFile.stage[(int)cubersFile.now_play_stage - 1];
            // ステージ攻略済み
            stg1. monthlyService_SaveLevel = cubersFile.now_play_stagelevel;
            cubersFile.stage[(int)cubersFile.now_play_stage - 1] = stg1;

            cubersFile.cubersFile_instance.save_gameEncryptionData();

            // メインメニュー表示
            sphere.gameStatus_text = "";

            ButtonSlimCardClick();

            // 攻略レベルセーブ確認画面オフ
            saveConfirm_View.gameObject.SetActive(false);

        }
        public void ButtonSaveLevelCancelClick()
        {
            // セーブキャンセル
            // メインメニュー表示
            sphere.gameStatus_text = "";

            ButtonSlimCardClick();

        }
        public void ButtonSaveLevelCloseClick()
        {
            // セーブ確認クローズ＆攻略ビュー再表示
            // 攻略レベルセーブ確認画面オフ
            saveConfirm_View.gameObject.SetActive(false);
            complete_view.gameObject.SetActive(true);

        }

        public void ButtonGameEndNewGameClick() {

            // インタースティシャル広告表示制御
            // TODO:広告表示関連処理
            /*            gameEndButton_clickCount--;
                        if (gameEndButton_clickCount <= 0)
                        {
                            gameEndButton_clickCount = emitter.INTERSTITIAL_AD;
                            sw_gameEndButton = 1;   // ButtonClick New Game
                            // TODO:AD インタースティシャル広告表示
                            //RequestInterstitial();
                            return;
                        }
            */
            // TODO:修正・追加 1-1-3 月極サービス利用者用攻略レベルセーブ処理
            /*
            bool monthlyservice = cubersFile.cubersFile_instance.checkMonthlyService();
            if (monthlyservice)
            {
                // 攻略レベルセーブ確認画面オン
                saveConfirm_View.gameObject.SetActive(true);
                complete_view.gameObject.SetActive(false);
                return;
            }
            */
            //safeareaout_header_BG.gameObject.SetActive(false);
            //safeareaout_footer_BG.gameObject.SetActive(false);
            //header_BG.gameObject.SetActive(true);
            //footer_BG.gameObject.SetActive(true);

            cubersFile.cubersFile_instance.load_gameEncryptionData();

            playItemView_button_BG.gameObject.SetActive(false);
            playSettingView_button_BG.gameObject.SetActive(false);
            down_button_L_BG.gameObject.SetActive(false);
            down_button_R_BG.gameObject.SetActive(false);
            right_header.gameObject.SetActive(false);
            left_header.gameObject.SetActive(false);
            center_header.gameObject.SetActive(false);
            b_Pause.gameObject.SetActive(false);
            noChainPlayTimeDSP_Sceen2BGImage.gameObject.SetActive(false);
            monsterColorCountSceen2View.gameObject.SetActive(false);
            waitingTimerGauge_BG.gameObject.SetActive(false);
            complete_view.gameObject.SetActive(false);
			failed_view.gameObject.SetActive(false);

            Sphere.sphere_nowclear();
            Emitter.cube_nowclear();
            sphere.gameover = false;
            sphere.complete = false;

            //sphere.gameStatus_text = "";

            //s_center_View.rectTransform.sizeDelta = center_View_orgSize;
            screen_Mask.gameObject.SetActive(true);
            var seq = DOTween.Sequence();
            seq.Append(screen_Mask.DOFade(1, do_duration));
            seq.OnComplete(() =>
            {
                setCenterView(1);
                var seq = DOTween.Sequence();
                seq.Append(screen_Mask.DOFade(0, do_duration));
                seq.OnComplete(() =>
                {
                    screen_Mask.gameObject.SetActive(false);
                });
            });
		}
        // Slim Card 管理画面
        public void ButtonSlimCardClick() {
            return;
			/*if (gf_Move) return;
			else gf_Move = true;

            s_center_View.gameObject.SetActive(false);
            // ステージ選択画面ビュー作成処理
            Create_GameSelectView();

            if (!gf_Up) {
				
				//Vector3 gselect_scal = game_select_view.transform.localScale;
				//pos_gs = game_select_view.transform.position;
				//pos_gs.y = (Screen.height / 2) - (game_select_view.rectTransform.sizeDelta.y * gselect_scal.y / 2);

				game_select_view.gameObject.SetActive(true);
				gf_Up = true;
			}
			else {
				gf_Up = false;

                safeareaout_header_BG.gameObject.SetActive(true);
                safeareaout_footer_BG.gameObject.SetActive(true);
                playItemView_button_BG.gameObject.SetActive(true);
                playSettingView_button_BG.gameObject.SetActive(true);
                down_button_L_BG.gameObject.SetActive(true);
                down_button_R_BG.gameObject.SetActive(true);
                //header_BG.gameObject.SetActive(true);
                //footer_BG.gameObject.SetActive(true);
                right_header.gameObject.SetActive(true);
				b_Pause.gameObject.SetActive(true);
            }*/
        }
        // new stage select view
        public void ButtonNewGame2Click()
        {

            if (gsf_Move) return;
            else gsf_Move = true;

            s_center_View.gameObject.SetActive(false);
            // ステージ選択画面ビュー作成処理
            Create_GameStageSelectView();

            if (!gsf_Up)
            {
                //game_stage_select_view.gameObject.SetActive(true);
                gsf_Up = true;
            }
            else
            {
                gsf_Up = false;

                safeareaout_header_BG.gameObject.SetActive(true);
                safeareaout_footer_BG.gameObject.SetActive(true);
                playItemView_button_BG.gameObject.SetActive(true);
                playSettingView_button_BG.gameObject.SetActive(true);
                down_button_L_BG.gameObject.SetActive(true);
                down_button_R_BG.gameObject.SetActive(true);
                //header_BG.gameObject.SetActive(true);
                //footer_BG.gameObject.SetActive(true);
                right_header.gameObject.SetActive(true);
                b_Pause.gameObject.SetActive(true);
                sphere.gameover = false;
                sphere.complete = false;
            }
        }

        // TODO:追加 ネクスト処理
        public void ButtonGameEndNextClick()
        {
            // TODO:追加　1-1-3  ネクストボタン処理

            // インタースティシャル広告表示制御
            // TODO:広告表示関連処理
            //gameEndButton_clickCount--;
            //if (gameEndButton_clickCount <= 0)
            //{
            //    gameEndButton_clickCount = emitter.INTERSTITIAL_AD;
            //    sw_gameEndButton = 2;   // ButtonClick Retry;
            //    // TODO:AD インタースティシャル広告表示
            //    //RequestInterstitial();
            //    return;
            //}

            cubersFile.cubersFile_instance.load_gameEncryptionData();

            emitter.BGMstate = emitter.BGM_State.start;
            emitter.BGMstate = emitter.BGM_State.play;

            s_center_View.gameObject.SetActive(false);

            sphere.gameStatus_text = "";

            complete_view.gameObject.SetActive(false);
            failed_view.gameObject.SetActive(false);

            // TODO:New StageSElectView Open
            ButtonNewGame2Click();
            /*
            int nextLevel = (int)cubersFile.now_play_stagelevel;
            if (nextLevel == emitter.stageLevel_max)
            {
                // MAXレベルの為、繰り返しプレイ
                setStageSelectLevel(nextLevel);
            }
            else
            {
                // ネクストレベルデータセット
                nextLevel++;
                setStageSelectLevel(nextLevel);
            }
            */
        }
        // TODO:連鎖 リトライ処理
        public void ButtonGameEndRetryClick() {
            /*
            // TODO:追加　1-1-2  リトライアイテム制御
            if(cubersFile.item_retry == 0)
            {
                //  リトライアイテム無し アイテムビュー表示
                ButtonItemClick();
                return;
            }            
            // リトライアイテム１使用
            cubersFile.item_retry--;
            */
            // インタースティシャル広告表示制御
            // TODO:広告表示関連処理
            //gameEndButton_clickCount--;
            //if (gameEndButton_clickCount <= 0)
            //{
            //    gameEndButton_clickCount = emitter.INTERSTITIAL_AD;
            //    sw_gameEndButton = 2;   // ButtonClick Retry;
            //    // TODO:AD インタースティシャル広告表示
            //    //RequestInterstitial();
            //    return;
            //}

            cubersFile.cubersFile_instance.load_gameEncryptionData();

            emitter.BGMstate = emitter.BGM_State.start;
            emitter.BGMstate = emitter.BGM_State.play;

            s_center_View.gameObject.SetActive(false);
			//s_mainMenu_field.gameObject.SetActive(false);

			sphere.gameStatus_text = "";

			complete_view.gameObject.SetActive(false);
			failed_view.gameObject.SetActive(false);

            ButtonRetryClick();
        }
        // TODO:連鎖　リトライ処理
        public void ButtonRetryClick() {

			// start処理は、sphereのstart_gameフラグによる呼び出しのgame_start()でcube処理もリセットされる
			emitter.levelCheck(cubersFile.now_play_stage);
			sphere.start_game = true;
			sunshinerotate = 0;

            emitter.wait_variable_timerCount = emitter.wait_timer_variable;
            emitter.gravity_Timespan = 0;

            safeareaout_header_BG.gameObject.SetActive(true);
            safeareaout_footer_BG.gameObject.SetActive(true);
            playItemView_button_BG.gameObject.SetActive(true);
            playSettingView_button_BG.gameObject.SetActive(true);
            down_button_L_BG.gameObject.SetActive(true);
            down_button_R_BG.gameObject.SetActive(true);
            //header_BG.gameObject.SetActive(true);
            //footer_BG.gameObject.SetActive(true);
            right_header.gameObject.SetActive(true);
			left_header.gameObject.SetActive(true);
            center_header.gameObject.SetActive(true);
            sphere.gameover = false;
            sphere.complete = false;

            //gamePoint.gameObject.SetActive(true);
            b_Pause.gameObject.SetActive(true);
            //b_share.gameObject.SetActive(true);
            //b_change.gameObject.SetActive(true);

            int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
            if (mod == 0)
            {
                // 連鎖パネル表示リセット　パネルマスクオン時のリセットが無いのでここで非表示とする　連鎖カウント等は別個所でセット
                greenMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                yellowMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                redMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                purpleMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                blueMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                whiteMonsterSlimeCountMaskImage_s.gameObject.SetActive(false);
                // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオンにする
                s_monsterSlimeColorCountView.gameObject.SetActive(true);
            }
            else
            {
                // 連鎖無しステージ選択時、ここで連鎖パネルビューを強制的にオフにする
                s_monsterSlimeColorCountView.gameObject.SetActive(false);
            }

            /* TODO: 連鎖関連修正 連鎖１プレーでカウントリセットを継続保持に変更の為、コメントアウト
            chain_1_count = 0;
            chain_2_count = 0;
            chain_3_count = 0;
            */

        }
        // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
        private float itemViewWaitStopTime;
        public void ButtonPlayItemClick()
        {
            // 再生中BGMオフ
            item_BGM_Status = true;
            // プレイ中ゲームポーズ
            emitter.playState = emitter.gamePlayState.Pause;
            timeChange = true;
            emitter.sw_Gravity = false;
            emitter.sw_pause = true;
            emitter.sw_stop = true;
            pauseON = true;

            itemViewWaitStopTime = counter.timer;
            ButtonItemClick();
        }

        public void ButtonItemClick() {

			if (if_Move) return;
			else if_Move = true;

            //sphere.gameover = false;
            //sphere.complete = false;

            if (!if_Up) {
                //item_View.gameObject.SetActive(true);
				setItemViewData();
				if_Up = true;
                // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
                // アイテム画面表示時、BGMを停止する
                emitter.BGMstate = emitter.BGM_State.Stop;
            }
            else {
				if_Up = false;
			}

		}

        // TODO:1-1-１０修正 新規アイテム変換購入画面処理の作成
        void setItemViewData()
        {
            itemview_jewelry_count.text = cubersFile.jewelry_Count.ToString();
            itemview_pauseitem_count.text = cubersFile.pauseitem_count.ToString();
            itemview_timerestitem_count.text = cubersFile.timeresetitem_count.ToString();
            itemview_lifelostitem_count.text = cubersFile.lifelostinvaliditem_count.ToString();

            /*// 所持ゴールドコイン数表示
            goldCoin_TotalCount.text = cubersFile.goldCoin_Count.ToString();

            // アイテムセットボタン表示
            for(int i = 0; i < cubersFile.itemSet_max; i++)
            {
                switch(i)
                {
                    case 0:
                        itemSet1_coin_Count.text = cubersFile.itemSetData[1].itemSet_goldcoin.ToString() + "G";
                        itemSet1_price.text = "¥" + cubersFile.itemSetData[i].itemSet_price.ToString();
                        itemSet1_wait_count.text = "×" + cubersFile.itemSetData[i].itemSet_wait.ToString();
                        itemSet1_retry_count.text = "×" + cubersFile.itemSetData[i].itemSet_retry.ToString();
                        break;
                    case 1:
                        itemSet2_coin_Count.text = cubersFile.itemSetData[1].itemSet_goldcoin.ToString() + "G";
                        itemSet2_price.text = "¥" + cubersFile.itemSetData[i].itemSet_price.ToString();
                        itemSet2_wait_count.text = "×" + cubersFile.itemSetData[i].itemSet_wait.ToString();
                        itemSet2_retry_count.text = "×" + cubersFile.itemSetData[i].itemSet_retry.ToString();
                        break;
                    case 2:
                        itemSet3_coin_Count.text = cubersFile.itemSetData[1].itemSet_goldcoin.ToString() + "G";
                        itemSet3_price.text = "¥" + cubersFile.itemSetData[i].itemSet_price.ToString();
                        itemSet3_wait_count.text = "×" + cubersFile.itemSetData[i].itemSet_wait.ToString();
                        itemSet3_retry_count.text = "×" + cubersFile.itemSetData[i].itemSet_retry.ToString();
                        break;
                    case 3:
                        itemSet4_coin_Count.text = cubersFile.itemSetData[1].itemSet_goldcoin.ToString() + "G";
                        itemSet4_price.text = "¥" + cubersFile.itemSetData[i].itemSet_price.ToString();
                        itemSet4_wait_count.text = "×" + cubersFile.itemSetData[i].itemSet_wait.ToString();
                        itemSet4_retry_count.text = "×" + cubersFile.itemSetData[i].itemSet_retry.ToString();
                        break;
                    case 4:
                        itemSet5_coin_Count.text = cubersFile.itemSetData[1].itemSet_goldcoin.ToString() + "G";
                        itemSet5_price.text = "¥" + cubersFile.itemSetData[i].itemSet_price.ToString();
                        itemSet5_wait_count.text = "×" + cubersFile.itemSetData[i].itemSet_wait.ToString();
                        itemSet5_retry_count.text = "×" + cubersFile.itemSetData[i].itemSet_retry.ToString();
                        break;
                }
            }
            
            //  交換アイテムゴールドコイン数
            itemWait_count.text = "×" + cubersFile.item_wait.ToString();
            itemRetry_count.text = "×" + cubersFile.item_retry.ToString();

            
                        item_gold_count_text.text = cubersFile.goldcoin_count.ToString();
                        item_gold_count = cubersFile.goldcoin_count;
                        item_now_gameCount_text.text = cubersFile.game_count.ToString();
                        item_now_pauseCount_text.text = cubersFile.pause_count.ToString();
                        item_now_delayCount_text.text = cubersFile.delay_count.ToString();
                        item_now_lostadd_Count_text.text = cubersFile.lostadd_count.ToString();

                        item_gameCount = 0;
                        item_gameCount_text.text = item_gameCount.ToString();
                        item_pauseCount = 0;
                        item_pauseCount_text.text = item_pauseCount.ToString();
                        item_delayCount = 0;
                        item_delayCount_text.text = item_delayCount.ToString();
                        item_lostadd_Count = 0;
                        item_lostadd_Count_text.text = item_lostadd_Count.ToString();
            */
        }
        // TODO:1-1-１０修正 新規アイテム変換購入画面処理の作成
        void setItemData()
        {
            // 取得ゴールドコイン数加算
            cubersFile.goldCoin_Count += cubersFile.itemSetData[itemSetNumber].itemSet_goldcoin;
            // 取得落下待機アイテム数加算
            cubersFile.item_wait += cubersFile.itemSetData[itemSetNumber].itemSet_wait;
            // 取得リトライアイテム数加算
            cubersFile.item_retry += cubersFile.itemSetData[itemSetNumber].itemSet_retry;

            /*			
                        cubersFile.gold_count = item_gold_count;
                        cubersFile.game_count = cubersFile.game_count + item_gameCount;
                        cubersFile.pause_count = cubersFile.pause_count + item_pauseCount;
                        cubersFile.delay_count = cubersFile.delay_count + item_delayCount;
                        cubersFile.lostadd_count = cubersFile.lostadd_count + item_lostadd_Count;

                        cubersFile.cubersFile_instance.save_gameEncryptionData();
            */
        }
        private int itemSetNumber;
        public void ButtonItemSet(Button itemsetbt)
        {
            int sw = int.Parse(itemsetbt.gameObject.tag);
            switch (sw)
            {
                case 1:
                    // item set 1 button select
                    itemSetNumber = 1;
                    break;
                case 2:
                    // item set 2 button select
                    itemSetNumber = 2;
                    break;
                case 3:
                    // item set 3 button select
                    itemSetNumber = 3;
                    break;
                case 4:
                    // item set 4 button select
                    itemSetNumber = 4;
                    break;
                case 5:
                    // item set 5 button select
                    itemSetNumber = 5;
                    break;
            }
            // ストアー購入処理 ---------------------------------------------------

            // -----------------------------------------------------------------

            // ストアー購入完了後処理
            setItemData();
            // アイテムメニュー表示の更新
            setItemViewData();
        }
        // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
        private int exchangeItem;       // 1:wait 2:retry
        public void ButtonItemExchange(Button itembt)
        {
            // ゴールドコインー＞アイテム交換処理
            // 交換確認ビュー表示＆アイテム交換処理
            int sw = int.Parse(itembt.gameObject.tag);
            switch (sw)
            {
                case 0:
                    // item exchange view close button select
                    itemExchangeConfirm_View.gameObject.SetActive(false);
                    exchangeItem = 0;
                    break;
                case 1:
                    // wait item button select
                    exchangeItem = 1;
                    exchangeItem1.gameObject.SetActive(true);
                    exchangeItem2.gameObject.SetActive(false);
                    exchangeCoincount.text = cubersFile.itemWaitExchangecoincount.ToString() + "G";
                    itemExchangeConfirm_View.gameObject.SetActive(true);
                    break;
                case 2:
                    // retry item button select
                    exchangeItem = 2;
                    exchangeItem1.gameObject.SetActive(false);
                    exchangeItem2.gameObject.SetActive(true);
                    exchangeCoincount.text = cubersFile.itemRetryExchangecoincount.ToString() + "G";
                    itemExchangeConfirm_View.gameObject.SetActive(true);
                    break;
                case 3:
                    // item exchange confirm button select
                    if (exchangeItem == 1)
                    {
                        cubersFile.goldCoin_Count -= cubersFile.itemWaitExchangecoincount;
                        cubersFile.item_wait++;
                        cubersFile.cubersFile_instance.save_gameEncryptionData();
                    }
                    if (exchangeItem == 2)
                    {
                        cubersFile.goldCoin_Count -= cubersFile.itemRetryExchangecoincount;
                        cubersFile.item_retry++;
                        cubersFile.cubersFile_instance.save_gameEncryptionData();
                    }
                    exchangeItem = 0;
                    break;
            }

        }
        public void ButtonItemCloseClick()
        {
            // 画面表示時にオフしたBGMを、プレイ画面で再開する　但し、BGM設定がオフの場合は再生されない
            if (item_BGM_Status)
            {
                emitter.BGMstate = emitter.BGM_State.play;
                item_BGM_Status = false;
                // プレイ画面からのアイテム画面表示では、中断しているゲームを再開させる
                if (pauseON)
                {
                    pauseON = false;
                    timeChange = true;
                    emitter.sw_Gravity = true;
                    emitter.playState = emitter.gamePlayState.Play;
                    emitter.BGMstate = emitter.BGM_State.play;
                    emitter.sw_pause = false;
                    emitter.sw_stop = false;
                    // 停止中落下時間カウントの再開
                    counter.timer = itemViewWaitStopTime;
                }
            }
            if (if_Move) return;
            else if_Move = true;

            if_Up = false;
        }
        public void ButtonItemRESETClick()
        {
            setItemViewData();
        }
        // TODO:1-1-7追加　メインメニュー処理修正
        public void ButtonSettingClick()
        {

            //  TODO: テスト用　初期化時、cube_baseファイルに設定されたデータが読み込まれる
            // cube_baseファイルの
            // "level":1,"stage": 1,"time": 123000,"point": 1000000, "status": 2},
            // 最後の"status":の値と0とすると非表示 1,2で表示されるがトライ中は1,攻略完了は2となる
            // ゲームコンプリート時にこの値がセットされ CubeFileに暗号がされて保存される
            //  デバック時に、設定ボタン押下で下記命令が実行されcube_baseファイルが読み込まれその内容にデータに初期化される
            // 通常はコメントアウト状態
            //cubersFile.cubersFile_instance.init_gameEncryptionData(); 

            if (is_Move) return;
            else is_Move = true;

            if (!is_Up)
            {
                initToggle();
                //setting_View.gameObject.SetActive(true);
                setSettingViewData();
                is_Up = true;

                // TODO:1-1-11 追加 新規設定画面処理の作成
                // 設定画面表示時、BGMを停止する
                emitter.BGMstate = emitter.BGM_State.Stop;

            }
            else
            {
                is_Up = false;
            }
        }
        // プレイ画面からの設定画面呼び出し
        private float settingViewWaitStopTime;
        public void ButtonSettingPlayClick()
        {
            // 再生中BGMオフ
            setting_BGM_Status = true;
            // プレイ中ゲームポーズ
            emitter.playState = emitter.gamePlayState.Pause;
            timeChange = true;
            emitter.sw_Gravity = false;
            emitter.sw_pause = true;
            emitter.sw_stop = true;
            settingViewWaitStopTime = counter.timer;
            pauseON = true;
            // 設定画面表示
            ButtonSettingClick();
        }

        // TODO:1-1-11 追加 新規設定画面処理の作成
        public void ButtonSettingCloseClick()
        {
            // 画面表示時にオフしたBGMを、プレイ画面で再開する　但し、BGM設定がオフの場合は再生されない
            if (setting_BGM_Status) {
                emitter.BGMstate = emitter.BGM_State.play;
                setting_BGM_Status = false;
                // プレイ画面からの設定画面表示では、中断しているゲームを再開させる
                if (pauseON)
                {
                    pauseON = false;
                    timeChange = true;
                    emitter.sw_Gravity = true;
                    emitter.playState = emitter.gamePlayState.Play;
                    emitter.BGMstate = emitter.BGM_State.play;
                    emitter.sw_pause = false;
                    emitter.sw_stop = false;
                    // 停止中落下時間カウントの再開
                    counter.timer = settingViewWaitStopTime;

                }
            }
            //webViewObject.gameObject.SetActive(false);

            if (is_Move) return;
            else is_Move = true;

            is_Up = false;
        }
        // 設定画面トグルボタン処理
        public void SwitchToggle(Button toggle)
        {
            int toggleValue;
            Color bgColor;
            float handleDestX;
            var toggleTag =  int.Parse(toggle.tag);
            switch(toggleTag)
            {
                case 1:
                    // BGM
                    toggleValue = (int)cubersFile.setting_BGM;
                    if (toggleValue == 0)
                    {
                        toggleValue = 1;
                        bgColor = ON_BG_COLOR;
                        handleDestX = toggle1_handlePosX;
                    }
                    else
                    {
                        toggleValue = 0;
                        bgColor = OFF_BG_COLOR;
                        handleDestX = -toggle1_handlePosX;
                    }
                    cubersFile.setting_BGM = toggleValue;
                    UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle1_Background, toggle1_Handle);
                    break;
                case 2:
                    // SoundEffect
                    toggleValue = (int)cubersFile.setting_SoundEffect;
                    if (toggleValue == 0)
                    {
                        toggleValue = 1;
                        bgColor = ON_BG_COLOR;
                        handleDestX = toggle2_handlePosX;
                    }
                    else
                    {
                        toggleValue = 0;
                        bgColor = OFF_BG_COLOR;
                        handleDestX = -toggle2_handlePosX;
                    }
                    cubersFile.setting_SoundEffect = toggleValue;
                    UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle2_Background, toggle2_Handle);
                    break;
                case 3:
                    // BG Animation
                    toggleValue = (int)cubersFile.setting_BG_Animation;
                    if (toggleValue == 0)
                    {
                        toggleValue = 1;
                        bgColor = ON_BG_COLOR;
                        handleDestX = toggle3_handlePosX;
                        // BGアニメーションオフ
                        emitter.under_floor.GetComponent<SpinAnimation>().AnimationSpeed = 5;
                    }
                    else
                    {
                        toggleValue = 0;
                        bgColor = OFF_BG_COLOR;
                        handleDestX = -toggle3_handlePosX;
                        // BGアニメーションオン
                        emitter.under_floor.GetComponent<SpinAnimation>().AnimationSpeed = 0;
                    }
                    cubersFile.setting_BG_Animation = toggleValue;
                    UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle3_Background, toggle3_Handle);
                    break;
            }
            // トグルボタン設定ファイルセーブ
            cubersFile.cubersFile_instance.save_gameEncryptionData();
        }
        // 状態を反映させる
        private void UpdateToggle(float duration, Color togglecolor, float handleDestX, Image backgroundImage, RectTransform handle)
        {
            sequence?.Complete();
            sequence = DOTween.Sequence();
            sequence.Append(backgroundImage.DOColor(togglecolor, duration))
                .Join(handle.DOAnchorPosX(handleDestX, duration / 2));
        }
        // setting ToggleButton 初期表示
        public void initToggle()
        {
            Color bgColor;
            float handleDestX;

            if (cubersFile.setting_BGM == 0)
            {
                bgColor = OFF_BG_COLOR;
                handleDestX = -toggle1_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle1_Background, toggle1_Handle);
            }
            else
            {
                bgColor = ON_BG_COLOR;
                handleDestX = toggle1_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle1_Background, toggle1_Handle);
            }
            if (cubersFile.setting_SoundEffect == 0)
            {
                bgColor = OFF_BG_COLOR;
                handleDestX = -toggle2_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle2_Background, toggle2_Handle);
            }
            else
            {
                bgColor = ON_BG_COLOR;
                handleDestX = toggle2_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle2_Background, toggle2_Handle);
            }
            if (cubersFile.setting_BG_Animation == 0)
            {
                bgColor = OFF_BG_COLOR;
                handleDestX = -toggle3_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle3_Background, toggle3_Handle);
            }
            else
            {
                bgColor = ON_BG_COLOR;
                handleDestX = toggle3_handlePosX;
                UpdateToggle(SWITCH_DURATION, bgColor, handleDestX, toggle3_Background, toggle3_Handle);
            }
        }
        // Setting WebView BT Click
        public void Setting_InfoBT_Click(Button settingbt)
        {
            if (settingbt.tag == "1")
            {
                // TODO:1-1-１4 ユーザー設定画面処理
                // ユーザー情報編集
                if (nv_Move) return;
                else nv_Move = true;
                if (!nv_Up)
                {
                    //userName_view.gameObject.SetActive(true);
                    userNameViewClose_BT.gameObject.SetActive(true);
                    userName_BG.gameObject.SetActive(true);
                    newUserName_Title.text = "NEW NAME : ";
                    userName_Text.text = cubersFile.user_name;
                    nv_Up = true;
                }
                else
                {
                    nv_Up = false;
                }
            }
            else if (settingbt.tag == "2")
            {
                // TODO:1-1-11 追加 新規設定画面処理の作成テスト用URL
                //webViewObject.LoadURL("https://www.google.co.jp");
                //webViewObject.gameObject.SetActive(true);
            }
            else if (settingbt.tag == "3")
            {
                // TODO:1-1-11 追加 新規設定画面処理の作成テスト用URL
                //webViewObject.LoadURL("https://www.apple.com/jp/");
                //webViewObject.gameObject.SetActive(true);
            }
        }

        // TODO:1-1-１4 追加 ユーザー設定画面処理
        public void ButtonUserNameCloseClick()
        {

            if (nv_Move) return;
            else nv_Move = true;

            nv_Up = false;
        }
        // ユーザー名入力確認
        public void ButtonUserNameOKClick()
        {
            // ブランク(空)は スルー
            if (newUserNameInput.text.Length == 0)
            {
                return;
            }
            // すべての文字がブランクかチェック
            int w_count = 0;
            for (int i = 0; i < newUserNameInput.text.Length; i++)
            {
                string w_char = newUserNameInput.text.Substring(i, 1);
                if (w_char != " ")
                {
                    // ブランク以外なのでOK
                    break;
                }
                w_count++;
            }
            if (w_count == newUserNameInput.text.Length)
            {
                return;
            }
            userNameConfirm_View_BG.gameObject.SetActive(true);
        }
        // ユーザー名入力確認確定
        public void ButtonUserNameConfirmOKClick()
        {
            cubersFile.user_name = newUserNameInput.text;
            cubersFile.cubersFile_instance.save_gameEncryptionData();
            userNameConfirm_View_BG.gameObject.SetActive(false);
            ButtonUserNameCloseClick();
        }
        // ユーザー名入力確認キャンセル
        public void ButtonUserNameConfirmCancelClick()
        {
            userNameConfirm_View_BG.gameObject.SetActive(false);
        }
        // ユーザー名入力
        public void InputUserName()
        {
            // ブランク(空)は スルー
            if (newUserNameInput.text.Length == 0)
            {
                return;
            }
        // 入力文字チェック ９文字以上は切り捨て
            int w_length = newUserNameInput.text.Length;
            if (w_length > 8)
            {
                w_length = 8;
            }
            string inputText = newUserNameInput.text.Substring(0, w_length);
            // 入力確認ビューの名前表示
            newUserNameInput.text = inputText;
            userNameConfirm_Text.text = inputText;
        }

        public void ButtonMainClick()
        {

            if (bf_Move) return;
            else bf_Move = true;

            if (!bf_Up)
            {
                bf_Up = true;
            }
            else
            {
                bf_Up = false;
            }
        }

        int speed = 300;
		float cube_mass = 100;

		public void ButtonDownClick () {

			if (sphere.gravitySpheres_count == 0) return;

            Sphere.sphere_CardSlime_Clear(emitter.item_Slim_No.waitTime_slim);

            emitter.sw_floorUpDown = true;
			emitter.sw_Gravity = true;
			if (pauseON) {
				pauseON = false;
				timeChange = true;
				emitter.playState = emitter.gamePlayState.Play;
				emitter.BGMstate = emitter.BGM_State.play;
				emitter.sw_pause = false;
                emitter.sw_stop = false;
                emitter.pause_timer = 0;
			}
                
            
            counter.timer = 0.5f;
            //counter.timer = 1.1f;
			for (int jj=0; jj< emitter.cubeCount; jj++) {
				for (int ii=0; ii<emitter.cubeCount; ii++) {
					emitter.guid_floor[jj,ii].gameObject.SetActive(false);
					nm_sphere.sphere.reset_Guid_Floor();
				}
			}

			int mod = (int)cubersFile.now_play_stage % emitter.chainExplosion_userLeve;
			monster_color color;

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
					// 落下アニメ設定
					Animator ani = sphere.useGravitySpheres[i].GetComponent<Animator>();
					nm_sphere.sphere.change_MonsterMaterial(sphere.useGravitySpheres[i],monster_situation.fear_monster,color);
                    string str = monster.monster_instance.PlayMonsterAnimation(monster_situation.happy_monster, cubersFile.game_Sceen);
                    ani.Play(str);
                    //ani.Play("pakupaku03");
				}
			}

			// 落下SE設定
			Singleton<SoundPlayer>.instance.playSE( "fall003",1);

			sphere.gravitySpheres_count = 0;
			//startDwonGaugeBrink = false;
			// 落下ゲージボタンオフ
			//sphereDownGaugeOff();
			counter.timer = emitter.nextDownWaitTimer;  // 落下後、次のモンスター落下待機表示までの待ち時間

            gravityWaitTemp(0);

            Debug.Log("落下Button!!! " + emitter.start_OneFallChainCountCollection + " !!!");
            // スライム設置から落下開始までに連鎖ありかチェック
            if (emitter.start_OneFallChainCountCollection)
            {
                // スライム設置から落下開始までに行われた連鎖情報修正フラグOFF
                emitter.start_OneFallChainCountCollection = false;
                // １落下サイクル時の連鎖情報表示及び魔法石（ジュエリー）獲得チェック
                GameObject w_obj1 = GameObject.Find("Canvas");
                w_obj1.GetComponent<canvasPanel>().chainInfoEffectDSP();
                emitter.green_OneFallChainCount = 0;
                emitter.yellow_OneFallChainCount = 0;
                emitter.red_OneFallChainCount = 0;
                emitter.purple_OneFallChainCount = 0;
                emitter.blue_OneFallChainCount = 0;
                Debug.Log("chainInfoEffectDSP!!");
            }

        }

        public void ButtonPauseClick() {

			if (cubersFile.pauseitem_count <= 0) return;
			if (sphere.gravitySpheres_count == 0) return;

			//if (emitter.sw_Gravity) {

            cubersFile.pauseitem_count--;
            cubersFile.cubersFile_instance.save_gameEncryptionData();
            emitter.playState = emitter.gamePlayState.Pause;
            emitter.BGMstate = emitter.BGM_State.Stop;
            timeChange = true;
			emitter.sw_Gravity = false;
			//emitter.BGMstate = emitter.BGM_State.Stop;
			emitter.sw_pause = true;

			emitter.pause_timer += emitter.PAUSETIME;
			counter.timer = 0; // pause_timer値を0になったらtimer=0として待機時間０でモンスターを落下させる

            //pause_text.gameObject.SetActive(true);
            //pause_banner_BG.gameObject.SetActive(true);
            Sphere.set_Sphere_CardSlime(emitter.item_Slim_No.waitTime_slim);
            gamecount.gameObject.SetActive(false);
			pauseON = true;
            // AdMob init.
            // TODO:AD バナー広告の初期化
            //this.RequestBanner();
        //}
        }
        // アップテンポタイマーリセット　7or4を10へ
        public void ButtonTimeResetClick()
        {

            if (cubersFile.timeresetitem_count <= 0) return;
            if (sphere.gravitySpheres_count == 0) return;

            cubersFile.timeresetitem_count--;
            cubersFile.cubersFile_instance.save_gameEncryptionData();
            counter.timer = 10; // pause_timer値を0になったらtimer=0として待機時間０でモンスターを落下させる

            Sphere.set_Sphere_CardSlime(emitter.item_Slim_No.resetTime_slim);
        }

        // ライフ消滅無効
        public void ButtonLifeLostInvalidClick()
        {
            if (cubersFile.lifelostinvaliditem_count <= 0) return;
            if (sphere.gravitySpheres_count == 0) return;

            cubersFile.lifelostinvaliditem_count--;
            cubersFile.cubersFile_instance.save_gameEncryptionData();
            Sphere.set_Sphere_CardSlime(emitter.item_Slim_No.gurdlife_slim);
        }

        // シェアボタンクリック処理
        public IEnumerator ButtonShareClick() {

			if (emitter.sw_Gravity) emitter.sw_Gravity = false;
			else emitter.sw_Gravity = true;
			Debug.Log("stop");
            //StartCoroutine("_share");
            ScreenCapture.CaptureScreenshot("image.png");
            yield return null;
            SocialConnector.SocialConnector.Share("Social Connector", "https://github.com/anchan828/social-connector", imagePath);

        }

        string imagePath
        {
            get
            {
                return Application.persistentDataPath + "/image.png";
            }
        }

        // テクスチャチェンジボタンクリック処理 ->  TODO:テスト用としてCubeFilesの初期化を行う
        public void ButtonChangeClick()
        {
            // CubeFiles Init.
            cubersFile.cubersFile_instance.init_gameEncryptionData();
            cubersFile.cubersFile_instance.load_gameEncryptionData();
            /*if (emitter.sw_Gravity) emitter.sw_Gravity = false;
            else emitter.sw_Gravity = true;
            Debug.Log("stop");
            */
        }
        // TODO:ステージ及びレベルリセット　ステージ１　レベル１へCubeFilesのデータをリセット
        static bool sw_cubefiles_stageStatus = false;
        public void ButtonDelayClick() {

            if (sw_cubefiles_stageStatus) {
                sw_cubefiles_stageStatus = false;
            } else
            {
                sw_cubefiles_stageStatus = true;
            }

            for (int m = 0; m < cubersFile.game_stage_max; m++)
            {
                if (m == 0)
                {
                    cubersFile.stage[m].status = 2;
                } else
                {
                    if (sw_cubefiles_stageStatus)
                    {
                        cubersFile.stage[m].status = 0;
                    } else
                    {
                        cubersFile.stage[m].status = 2;
                    }
                }
                IList levelData = cubersFile.stage[m].leveldata;
                for (int i = 0; i < cubersFile.game_stagelevel_max; i++)
                {
                    IDictionary dt = (IDictionary)levelData[i];
                    //IDictionary dt = (IDictionary)cubersFile.stage[m].leveldata[i];
                    if (m == 0 && i == 0)
                    {
                        dt["status"] = 2;
                    } else
                    {
                        if (sw_cubefiles_stageStatus)
                        {
                            dt["status"] = 0;
                        }
                        else
                        {
                            dt["status"] = 2;
                        }
                    }
                    levelData[i] = dt;
                    //cubersFile.stage[m].leveldata[i] = dt;
                }
                cubersFile.stage[m].leveldata = levelData;
            }
            cubersFile.cubersFile_instance.save_gameEncryptionData();
            cubersFile.cubersFile_instance.load_gameEncryptionData();

            /*if (emitter.sw_delay) return;
			if (cubersFile.delay_count <= 0) return;
			if (!emitter.sw_Gravity) return;

			emitter.delay_timer = 5.0f; //delay_timerは、ポーズエフェクト表示時間　この設定値経過後、下記timer値の差分がエフェクト(縮小)非表示までの時間となる
			--cubersFile.delay_count;
			counter.timer = 10.0f; // delay_timer値を含むポーズ終了までの時間を設定する　この場合、ポーズボタンでの待機時間はこのTimer値となる
			emitter.sw_delay = true;

			GameObject obj = this.transform.root.gameObject;
			obj.GetComponent<emitter>().circle_Delay();
			emitter.BGMstate = emitter.BGM_State.pit;
            */
        }

        // lost count add
        public void ButtonLostaddClick() {

			if (cubersFile.lostadd_count <= 0) return;

			cubersFile.lost_count++;
			sphere.lost_Spheres++;
			cubersFile.lostadd_count--;

		}

		public void ButtonClose1Click() {

			if (if_Move) return;
			else if_Move = true;
			
			if_Up = false;
		}

        // TODO:1-1-11 追加 新規設定画面処理の作成
        void setSettingViewData()
        {
        }
        void setSettingData()
        {

        }
        //public void ButtonSettingOKClick()
        //{

        //    setSettingData();

        //    if (is_Move) return;
        //    else is_Move = true;

        //    is_Up = false;

        //}
        //public void ButtonSettingCANCELClick()
        //{
        //    if (is_Move) return;
        //    else is_Move = true;

        //    is_Up = false;
        //}
        //public void ButtonSettingRESETClick()
        //{
        //    setSettingViewData();
        //}

        // TODO:1-1-１０削除 新規アイテム変換購入画面処理の作成
        /*
        public void buttonItemUpDownCell(Button item) {

			int sw = int.Parse(item.gameObject.tag);
			switch(sw) {
			case 1:
				 // gamecount up
				if (item_gameCount < 99999) {
					if (item_gold_count - emitter.item_cube_gold >= 0) {
						item_gameCount++;
						item_gameCount_text.text = item_gameCount.ToString();
						item_gold_count = item_gold_count - emitter.item_cube_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 2:
				// gamecount down
				if (item_gameCount > 0) {
					if (item_gold_count + emitter.item_cube_gold <= 9999999) {
						item_gameCount--;
						item_gameCount_text.text = item_gameCount.ToString();
						item_gold_count = item_gold_count + emitter.item_cube_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 3:
				// pausecount up
				if (item_pauseCount < 99999) {
					if (item_gold_count - emitter.item_pause_gold >= 0) {
						item_pauseCount++;
						item_pauseCount_text.text = item_pauseCount.ToString();
						item_gold_count = item_gold_count - emitter.item_pause_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 4:
				// pausecount down
				if (item_pauseCount > 0) {
					if (item_gold_count + emitter.item_pause_gold <= 9999999) {
						item_pauseCount--;
						item_pauseCount_text.text = item_pauseCount.ToString();
						item_gold_count = item_gold_count + emitter.item_pause_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 5:
				// delaycount up
				if (item_delayCount < 99999) {
					if (item_gold_count - emitter.item_delay_gold >= 0) {
						item_delayCount++;
						item_delayCount_text.text = item_delayCount.ToString();
						item_gold_count = item_gold_count - emitter.item_delay_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 6:
				// delaycount down
				if (item_delayCount > 0) {
					if (item_gold_count + emitter.item_delay_gold <= 9999999) {
						item_delayCount--;
						item_delayCount_text.text = item_delayCount.ToString();
						item_gold_count = item_gold_count + emitter.item_delay_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 7:
				// lostaddcount up
				if (item_lostadd_Count < 99999) {
					if (item_gold_count - emitter.item_lostadd_gold >= 0) {
						item_lostadd_Count++;
						item_lostadd_Count_text.text = item_lostadd_Count.ToString();
						item_gold_count = item_gold_count - emitter.item_lostadd_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			case 8:
				// lostaddcount down
				if (item_lostadd_Count > 0) {
					if (item_gold_count + emitter.item_lostadd_gold <= 9999999) {
						item_lostadd_Count--;
						item_lostadd_Count_text.text = item_lostadd_Count.ToString();
						item_gold_count = item_gold_count + emitter.item_lostadd_gold;
						item_gold_count_text.text = item_gold_count.ToString();
					}
				}
				break;
			}

		}
        */


        // unityads用callbackで呼ばれるメソッド 
        public void unityadsVideoFinishedCallBack(){
		}




		// パネルスライドアニメーション

		public AnimationCurve animCurve = AnimationCurve.Linear(0, 0, 1, 1);
		public Vector3 inPosition;        // スライドイン後の位置
		public Vector3 outPosition;      // スライドアウト後の位置
		public float duration = 0.5f;    // スライド時間（秒）

		// スライドイン（Pauseボタンが押されたときに、これを呼ぶ）
		public void SlideIn(Image w_panel){
			StartCoroutine( StartSlidePanel(true,w_panel));
		}

		// スライドアウト
		public void SlideOut(Image w_panel){
			StartCoroutine( StartSlidePanel(false,w_panel));
		}

		private IEnumerator StartSlidePanel( bool isSlideIn ,Image w_panel){
			float startTime = Time.time;    // 開始時間
			Vector3 startPos = w_panel.transform.localPosition;  // 開始位置
			Vector3 moveDistance;            // 移動距離および方向

			if( isSlideIn )
				moveDistance = (inPosition - startPos);
			else{
				moveDistance = (outPosition - startPos);

				while((Time.time - startTime) < duration){
					w_panel.transform.localPosition = startPos + moveDistance * animCurve.Evaluate((Time.time - startTime) / duration);
					yield return 0;        // 1フレーム後、再開
				}
				w_panel.transform.localPosition = startPos + moveDistance;
			}
		}



	}

}