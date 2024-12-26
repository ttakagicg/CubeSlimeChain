using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using static JsonSerializer;

//using SpicyPixel.Threading;

namespace nm_cubersFile
{
    // 各ステージの情報
    public class stage_Data
	{
        public long status;     // 0:未攻略ステージ 1:攻略中ステージ　2:攻略済みステージ
        public long stage_no;    // ３列＝1,2 ４列=3,4 ５列=5,6のステージ番号
        public long last_level; // クリア済み最終レベル
        public long monthlyService_SaveLevel; // 月極セーブサービス利用者のセーブレベルデータ　コンプリート時にレベルデータセーブを選択された時に保存される
        public IList leveldata; // 各ステージのレベル情報配列
	}

    // 各レベルの情報
    public class level_Data
    {
        public long status;     // 0:未攻略ステージ 1:攻略済みステージ
        public long stage_no;   // ３列＝1,2 ４列=3,4 ５列=5,6のステージ番号
        public long stagelevel_no;   // 1から5までの各ステージのレベル番号
        public long playtime;   // レベル毎のプレー時間
        public long lostcount;  // ライフロストカウント
        public long itemcount;  // 取得したアイテム数　シルバーアイテム
        public long maxchain;   // 連鎖モード時のみ使用　最大連鎖数
    }

    // イベントの情報
    public class event_Data
    {
        public long dayofweek;   //曜日情報　１：日曜　２：月曜　３：火曜　４：水曜　５：木曜　６：金曜　７：土曜
        public long startTime;   //24h表記
        public long duration;    //max 72h
        public long contents;    //１から始まる 内容について　counterソース内ロジック参照
        public long bouns;       //イベント達成時の報酬種別　counterソース内ロジック参照
    }
    // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
    // アイテムセットデータの情報
    public class itemSet_Data
    {
        public long itemSet_no;     // アイテムセット販売パターン番号
        public long itemSet_goldcoin;  // ゴールドコイン数
        public long itemSet_juely;  // ジュエリー数
        public long itemSet_price;     // セット価格
        public long itemSet_wait;      // 落下待機アイテム数
        public long itemSet_retry;     // リトライアイテム数
    }


    //public class cubersFile : ConcurrentBehaviour {

    public class cubersFile : MonoBehaviour {
        public static cubersFile cubersFile_instance;

        static Thread load_thread;
        static Thread save_thread;
        public static IDictionary response;
        // ゲームシーン設定
        public static long game_Sceen = 1;  // 0=アンダーシーンテクスチャ回転　1=ブルーダンジョン
        // ゲームプレイデータ関連
        public static stage_Data[] stage;
        public static level_Data[] stagelevel;
        public static string play_date;
        public static long user_stage = 1;
        public static long user_stagelevel = 1;
        public static long now_play_stage = 1;
        public static long now_play_stagelevel;
        // TODO:1-1-5 獲得アイテム処理 シルバーアイテムカウント＆ゴールドコインカウント
        public static long goldCoin_Count;
        public static long juely_Count;
        public static long golditem_count;
        public static long silveritem_count;

        public static long game_count;
        public static long lost_count;
        public static long pause_count;
        public static long delay_count;
        public static long lostadd_count;
        public static IList stagelist;
        public static int game_stage_max = 6;
        // TODO:修正　stageLevel MAX 変更　7 -> 5
        public static int game_stagelevel_max = 5;
        // TODO:追加　1-1-1 ３：セーブサービス利用データの作成
        //// 月額利用サービス関連データ
        public static long monthlyService;      // 月額利用サービスフラグON:利用中　OFF:未利用
        public static string monthlyService_Date; // サービス開始日
        public static long monthlyService_period; //  利用期間

        //// TODO:アイテム関連
        public static long item_wait;            // 一定時間ゲーム中断を可能とするアイテム数
        public static long item_retry;           // ゲームフェール時にゲームを再度プレイ可能とするアイテム数
        public static long chainGetItem_1;       // 連鎖時に取得したアイテム数　ゲームコンプリート時にプレイ中取得したアイテムが加算される　シルバーエッグアイテム
        public static long chainGetItem_2;       // chainGetItem_1 １０個取得で１加算されるアイテム　ゴールドエッグアイテム
        public static long chainGetItem_3;       // chainGetItem_2 １０個取得で１加算されるアイテム ジュエリーアイテム
        // TODO:ランキング関連

        // TODO:イベント関連データ
        public static event_Data[] eventData;
        public static IList eventlist;
        public static int event_dayofweek;      //曜日情報　１：日曜　２：月曜　３：火曜　４：水曜　５：木曜　６：金曜　７：土曜
        public static int event_startTime;      //24h表記
        public static int event_duration;       //max 72h
        public static int event_contents;       //１から始まる 内容について　counterソース内ロジック参照
        public static int event_bouns;          //イベント達成時の報酬種別　counterソース内ロジック参照
        public static int event_max = 7;            //イベントデータ個数MAX

        // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
        public static itemSet_Data[] itemSetData;
        public static int itemSet_max = 5;            //イベントデータ個数MAX
        public static long itemWaitExchangecoincount; //落下待機アイテム交換ゴールドコイン数
        public static long itemRetryExchangecoincount; //リトライアイテム交換ゴールドコイン数
        public static IList itemSetlist;

        // TODO:1-1-11 追加 新規設定画面処理の作成
        public static long setting_BGM;
        public static long setting_SoundEffect;
        public static long setting_BG_Animation;

        // TODO:1-1-１4 ユーザー設定画面処理
        public static string user_name;
        public static long user_id;

        // CuberFile 読み込みフラグ
        public static bool cubersfile_Loaded = false;

        // Use this for initialization
        void Start() {

            // シングルトンセット
            cubersFile_instance = this;
            cubersfile_Loaded = false;

            stage = new stage_Data[game_stage_max];
            stagelevel = new level_Data[game_stagelevel_max];
            eventData = new event_Data[event_max];
            itemSetData = new itemSet_Data[itemSet_max];
            load_gameEncryptionData();
        }

        // Update is called once per frame
        void Update() {

        }

        public void load_gameEncryptionData() {
            load_Thread();
            // マルチスレッド
            //load_thread = new Thread(load_Thread);
            //load_thread.Start();
        }

        public void save_gameEncryptionData() {
            save_Thread();
            // マルチスレッド
            //save_thread = new Thread(save_Thread);
            //save_thread.Start();
        }
        public void init_gameEncryptionData() {

            // 初期化時、cube_baseファイルに設定されたデータが読み込まれる
            // cube_baseファイルの
            // "level":1,"stage": 1,"time": 123000,"point": 1000000, "status": 2},
            // 最後の"status":の値と0とすると非表示 1,2で表示されるがトライ中は1,攻略完了は2となる
            // ゲームコンプリート時にこの値も含めてセットされ CubeFileに暗号がされて保存される
            // デバック時に、設定ボタン押下（CanvasPanel内のButtonSettingClick()）でこのメソッドが実行されcube_baseファイルの内容に初期化される
            // 通常はコメントアウト状態にしてあるのでそれを外す

            var textAsset = Resources.Load("cube_base") as TextAsset;
            var jsonText = textAsset.text;
            var json = (IDictionary)MiniJSON.Json.Deserialize(jsonText);

            Dictionary<string, object> dic = new Dictionary<string, object>();
            dic.Add("result", json["result"]);
            dic.Add("response", json["response"]);
            Save(dic, "userData");

            // イベントデータ
            var etextAsset = Resources.Load("cubeevent_test") as TextAsset;
            var ejsonText = textAsset.text;
            var ejson = (IDictionary)MiniJSON.Json.Deserialize(ejsonText);

            Dictionary<string, object> edic = new Dictionary<string, object>();
            edic.Add("result", ejson["result"]);
            edic.Add("response", ejson["response"]);
            Save(edic, "eventData");

        }
        // load cubersfile
        public void Load_Cubersfile() {
            //IEnumerator Load_Cubersfile() {

            Dictionary<string, object> dic = Load("userData");
            // TODO:Load_Cubersfileの初期化を行う際は、dic != nullにして保存済みuserDataを更新する
            if (dic != null) {
                init_gameEncryptionData();  //userDataが無い場合、cube_baseのデバッグデータファイルが読み込まれる
                dic = Load("userData");
            }
            response = (IDictionary)dic["response"];
            user_id = (long)response["id"];
            play_date = (string)response["date"];
            game_Sceen = (long)response["gamesceen"];
            user_stage = (long)response["userstage"];
            user_stagelevel = (long)response["userstagelevel"];
            now_play_stage = (long)response["playstage"];
            now_play_stagelevel = (long)response["playstagelevel"];
            goldCoin_Count = (long)response["goldcoin"];
            juely_Count = (long)response["juely"];
            golditem_count = (long)response["golditem"];
            silveritem_count = (long)response["silveritem"];
            game_count = (long)response["gamecount"];
            lost_count = (long)response["lost"];
            pause_count = (long)response["pause"];
            delay_count = (long)response["delay"];
            lostadd_count = (long)response["lostadd"];

            // TODO:追加　1-1-1 3:セーブサービス利用データの作成
            monthlyService = (long)response["monthlyService"];
            monthlyService_Date = (string)response["monthlyService_Date"];
            monthlyService_period = (long)response["monthlyService_period"];
            //monthlyService_SaveLevel = (long)response["monthlyService_SaveLevel"];
            item_wait = (long)response["itemwait"];
            item_retry = (long)response["itemretry"];
            chainGetItem_1 = (long)response["chainGetItem_1"];
            chainGetItem_2 = (long)response["chainGetItem_2"];
            chainGetItem_3 = (long)response["chainGetItem_3"];

            stagelist = (IList)response["stage"];
            for (int n = 0; n < game_stage_max; n++)
            {
                var lavel_d = (IDictionary)stagelist[n];
                stage[n] = new stage_Data();
                stage[n].status = (long)lavel_d["status"];
                stage[n].stage_no = (long)lavel_d["stage"];
                stage[n].last_level = (long)lavel_d["lastlevel"];
                stage[n].monthlyService_SaveLevel = (long)lavel_d["monthlyServiceSaveLevel"];
                var level_list = (IList)lavel_d["levellist"];
                stage[n].leveldata = level_list;
            }

            // イベントデータロード
            eventlist = (IList)response["event"];
            
            event_max = eventlist.Count;
            for (int n = 0; n < event_max; n++)
            {
                var event_d = (IDictionary)eventlist[n];
                eventData[n] = new event_Data();
                eventData[n].dayofweek = (long)event_d["dayofweek"]; //曜日情報　１：日曜　２：月曜　３：火曜　４：水曜　５：木曜　６：金曜　７：土曜
                eventData[n].startTime = (long)event_d["startTime"]; //24h表記
                eventData[n].duration = (long)event_d["duration"];   //max 72h
                eventData[n].contents = (long)event_d["contents"];   //１から始まる 内容について　counterソース内ロジック参照
                eventData[n].bouns = (long)event_d["bouns"];         //イベント達成時の報酬種別　counterソース内ロジック参照
            }

            // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
            // アイテムセット内容データ読み込み
            itemSetlist = (IList)response["itemset"];
            for (int n = 0; n < itemSet_max; n++)
            {
                var itemset_d = (IDictionary)itemSetlist[n];
                itemSetData[n] = new itemSet_Data();
                itemSetData[n].itemSet_no = (long)itemset_d["itemSetno"];
                itemSetData[n].itemSet_goldcoin = (long)itemset_d["itemSetgoldcoin"];
                itemSetData[n].itemSet_juely = (long)itemset_d["itemSetjuely"];
                itemSetData[n].itemSet_price = (long)itemset_d["itemSetprice"];
                itemSetData[n].itemSet_wait = (long)itemset_d["itemSetwait"];
                itemSetData[n].itemSet_retry = (long)itemset_d["itemSetretry"];
            }
            itemWaitExchangecoincount = (long)response["itemwaitexchange"];
            itemRetryExchangecoincount = (long)response["itemretryexchange"];

            // TODO:1-1-11 追加 新規設定画面処理の作成
            setting_BGM = (long)response["setting_BGM"];
            setting_SoundEffect = (long)response["setting_SoundEffect"];
            setting_BG_Animation = (long)response["setting_BG_Animation"];

            // TODO:1-1-１4 ユーザー設定画面処理
            user_name = (string)response["user_name"];

            // Cubersfile 読み込み済みフラグオン
            cubersfile_Loaded = true;
        }
        public void load_Thread() {
            Load_Cubersfile();
            //taskFactory.StartNew(Load_Cubersfile());
            //			Thread.Sleep(5000);

        }
        // 該当ステージのデータの取得
        public level_Data GetStageData(int stage_no,int stagelevel_no)
        {
            return (level_Data)stage[stage_no].leveldata[stagelevel_no];
        }
        // 該当ステージのデータの保存
        public void SetStageData(level_Data leveldata)
        {
            stage[now_play_stage].leveldata[(int)now_play_stagelevel] = leveldata;
        }
        // save cubersfile
        //IEnumerator Save_Cubersfile() {
        public void Save_Cubersfile()
        {

            Dictionary<string, object> dic = new Dictionary<string, object>();

			response["userstage"] = user_stage;
            response["userstagelevel"] = user_stagelevel;
            DateTime p_date = DateTime.Now;
			play_date = p_date.ToString("G");
			response["date"] = play_date;
            response["gamesceen"] = game_Sceen;
			response["playstage"] = now_play_stage;
            response["playstagelevel"] = now_play_stagelevel;
            response["goldcoin"] = goldCoin_Count;
            response["juely"] = juely_Count;
            response["silveritem"] = silveritem_count;
            response["itemwait"] = item_wait;
            response["itemretry"] = item_retry;
            response["gamecount"] = game_count;
			response["lost"] = lost_count;
			response["pause"] = pause_count;
			response["delay"] = delay_count;
			response["lostadd"] = lostadd_count;
            // TODO:追加　1-1-1 3:セーブサービス利用データの作成
            response["monthlyService"] = monthlyService;
            response["monthlyService_Date"] = monthlyService_Date;
            response["monthlyService_period"] = monthlyService_period;
            response["itemwait"] = item_wait;
            response["itemretry"] = item_retry;
            response["chainGetItem_1"] = chainGetItem_1;
            response["chainGetItem_2"] = chainGetItem_2;
            response["chainGetItem_3"] = chainGetItem_3;

            for (int n = 0; n < game_stage_max; n++) {
				IDictionary wdic = (IDictionary)stagelist[n];
                wdic["status"] = stage[n].status;
				wdic["stage"] = stage[n].stage_no;
                wdic["lastlevel"] = stage[n].last_level;
                wdic["monthlyServiceSaveLevel"] = stage[n].monthlyService_SaveLevel;
                wdic["levellist"] = (IList)stage[n].leveldata;
                stagelist[n] = wdic;
            }

            response["stage"] = stagelist;

            // TODO:1-1-１０追加 新規アイテム変換購入画面処理の作成
            // アイテムセット内容データ読み込み
            for (int n = 0; n < itemSet_max; n++)
            {
                IDictionary itemset_d = (IDictionary)itemSetlist[n];
                itemset_d["itemSetno"] = itemSetData[n].itemSet_no;
                itemset_d["itemSetgoldcoin"] = itemSetData[n].itemSet_goldcoin;
                itemset_d["itemSetjuely"] = itemSetData[n].itemSet_juely;
                itemset_d["itemSetprice"] = itemSetData[n].itemSet_price;
                itemset_d["itemSetwait"] = itemSetData[n].itemSet_wait;
                itemset_d["itemSetretry"] = itemSetData[n].itemSet_retry;
                itemSetlist[n] = itemset_d;
            }

            response["itemset"] = itemSetlist;

            response["itemwaitexchange"] = itemWaitExchangecoincount;
            response["itemretryexchange"] = itemRetryExchangecoincount;

            // TODO:1-1-11 追加 新規設定画面処理の作成
            response["setting_BGM"] = setting_BGM;
            response["setting_SoundEffect"] = setting_SoundEffect;
            response["setting_BG_Animation"] = setting_BG_Animation;

            // TODO:1-1-１4 ユーザー設定画面処理
            response["user_name"] = user_name;

            dic.Add ("result", "ok");
			dic.Add ("response", response);
            Save(dic, "userData");
			//yield return null;
		}
		public void save_Thread() {
            Save_Cubersfile();
            //taskFactory.StartNew(Save_Cubersfile());
            //			Thread.Sleep(5000);

        }

        // TODO:追加
        public bool checkMonthlyService()
        {
            // サービス利用開始日をDateTimeへ変換
            DateTime startDate =　DateTime.Parse(monthlyService_Date);
            // サービス利用期間（月）を加算し、サービス終了予定日を取得
            DateTime endDate = startDate.AddMonths((int)monthlyService_period);
            DateTime nowDate = DateTime.Now;
            // 本日日付がサービス終了期日を超えたかチェック
            if (endDate < nowDate)
            {
                // サービス終了
                return false;
            }
            else
            {
                // サービス利用中
                return true;
            }
        }
	}
}
