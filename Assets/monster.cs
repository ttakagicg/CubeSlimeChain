using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;


namespace nm_monster
{

	// モンスターカラー
	public enum monster_color
	{
		green_monster,
		yellow_monster,
		red_monster,
		blue_monster,
		purple_monster,
		black_monster,
		white_monster,
		orange_monster,
		noColor_monster
	}
	// モンスター状況
	public enum monster_situation
	{
		noraml_monster,
		angry_monster,
		happy_monster,
		death_monster,
		sleep_monster,
		wakeup_monster,
		smile_monster,
		fear_monster,
		impatient_monster
	}

	// モンスタープロパティクラス
	public class monster_property
	{
		public string tagID { get; set; }
		public bool InOutStatus { get; set; }
		public monster_color monster_color { get; set; }
		public int monsterCubePositionGroup { get; set; } // 0: cube center position group 1: cube side center position group 2: cube side corner position group
		public int monsterColorDisplayCount { get; set; } // Multi_chainExplosion時、重複モンスターのカラーチェンジ遅延回数　通常1lineは0、2lineは1、3lineなら2回同じカラー
		public Vector3 start_position { get; set; }
		public Texture mainTexture { get; set; }
	}

	public class monster : MonoBehaviour
	{

		public Texture normal_texture;
		public Texture normal_texture_red;
		public Texture normal_texture_blue;
		public Texture normal_texture_yellow;
		public Texture normal_texture_orange;
		public Texture normal_texture_purple;
		public Texture normal_texture_green;
		public Texture angry_texture;
		public Texture angry_texture_red;
		public Texture angry_texture_blue;
		public Texture angry_texture_yellow;
		public Texture angry_texture_orange;
		public Texture angry_texture_purple;
		public Texture angry_texture_green;
		public Texture sleep_texture;
		public Texture sleep_texture_red;
		public Texture sleep_texture_blue;
		public Texture sleep_texture_yellow;
		public Texture sleep_texture_orange;
		public Texture sleep_texture_purple;
		public Texture sleep_texture_green;
		public Texture wakeup_texture;
		public Texture wakeup_texture_red;
		public Texture wakeup_texture_blue;
		public Texture wakeup_texture_yellow;
		public Texture wakeup_texture_orange;
		public Texture wakeup_texture_purple;
		public Texture wakeup_texture_green;
		public Texture smile_texture;
		public Texture smile_texture_red;
		public Texture smile_texture_blue;
		public Texture smile_texture_yellow;
		public Texture smile_texture_orange;
		public Texture smile_texture_purple;
		public Texture smile_texture_green;
		public Texture fear_texture;    // 恐怖
		public Texture fear_texture_red;
		public Texture fear_texture_blue;
		public Texture fear_texture_yellow;
		public Texture fear_texture_orange;
		public Texture fear_texture_purple;
		public Texture fear_texture_green;
		public Texture impatient_texture; // 焦る
		public Texture impatient_texture_red;
		public Texture impatient_texture_blue;
		public Texture impatient_texture_yellow;
		public Texture impatient_texture_orange;
		public Texture impatient_texture_purple;
		public Texture impatient_texture_green;
		public Texture clear_texture;
		public Texture death_texture;
		public Texture happy_texture;
		// マテリアル
		public Material monster1_yellow;
		public Material monster1_orange;
		public Material monster1_blue;
		public Material monster1_green;
		public Material monster1_red;
		public Material monster1_purple;
		public Material monster1_white;
		public Material monster1_black;
		// MESHカラーオブジェクト
		public Mesh monster2_greenMesh;
		public Mesh monster2_yellowMesh;
		public Mesh monster2_redMesh;
		public Mesh monster2_purpleMesh;
		public Mesh monster2_blueMesh;
		public Mesh monster2_whiteMesh;
		public Mesh monster2_blackMesh;
		public Mesh monster2_orangeMesh;

		const int monster_totalCount_3 = 26;
		const int monster_totalCount_4 = 56;
		const int monster_totalCount_5 = 98;
		const int cube3ChainExplosionLineCount = 8;
		const int cube4ChainExplosionLineCount = 12;
		const int cube5ChainExplosionLineCount = 16;

		public static monster monster_instance;
		public static IDictionary<string, monster_property> property;
		public static IDictionary<monster_color, int> color_count;
		public static IDictionary<monster_color, int> chainExplosionLineCount;
		public static int level_Line_count;
		public static int level_count;

		public static Texture maintexture;
		public static Material mainmaterial;
		public static Mesh mainmesh;


		void Start()
		{
			// シングルトンセット
			monster_instance = this;
		}
		void Update()
		{
		}
		// モンスタープロパティ初期化
		public void init_monster_property()
		{
			if (property == null)
			{
				property = new Dictionary<string, monster_property>();
			}
			else
			{
				property.Clear();
			}
		}
		// モンスタープロパティ追加
		public void addMonster_property(string tagid, monster_property w_property)
		{
			try
			{
				property.Add(tagid, w_property);
			}
			catch
			{
				Console.WriteLine("An element with Key = " + tagid + "already exists.");
			}
		}
		// モンスター開始位置取得
		public Vector3 getMonster_position(string tagid)
		{
			monster_property mproperty = property[tagid];
			return mproperty.start_position;
		}
		// モンスターIn/Outステータス取得
		public bool getMonster_IOstatus(string tagid)
		{
			monster_property mproperty = property[tagid];
			return mproperty.InOutStatus;
		}
		// モンスターIn/Outステータス設定
		public void setMonster_IOstatus(string tagid, bool status)
		{
			monster_property mproperty = property[tagid];
			mproperty.InOutStatus = status;
			property[tagid] = mproperty;
		}
		// モンスターカラー取得
		public monster_color getMonster_color(string tagid)
		{
			monster_property mproperty = property[tagid];
			return mproperty.monster_color;
		}
		// モンスターカラー表示回数取得
		public int getMonstercolorDisplayCount(string tagid)
		{
			monster_property mproperty = property[tagid];
			return mproperty.monsterColorDisplayCount;
		}
		// モンスターキューブポジショングループ取得
		// 0: cube center position group 1: cube side center position group 2: cube side corner position group
		public int getMonsterCubePositionGroup(string tagid)
		{
			return property[tagid].monsterCubePositionGroup;
		}
		// モンスターカラー別グループ個数取得
		public int getMonsterPositionGroupCount(monster_color m_color, int group)
		{
			int groupCount = 0;
			for (int i = 1; i <= property.Count; i++)
			{
				string monster_tag = i.ToString();
				if (m_color == property[monster_tag].monster_color)
				{
					if (property[monster_tag].monsterCubePositionGroup == group)
					{
						groupCount++;
					}
				}
			}
			return groupCount;
		}
		// モンスターカラー表示回数設定
		public void setMonsterColorDisplayCount(string tagid)
		{
			property[tagid].monsterColorDisplayCount++;
		}
		// モンスターカラー変更
		public monster_color changeMonster_color(string tagid)
		{
			monster_property mproperty = property[tagid];
			monster_color color;
			int color_cnt = 0;
			//			if (mproperty.monsterColorDisplayCount >= 1) {
			//				property[tagid].monsterColorDisplayCount--;
			//				return property[tagid].monster_color;
			//			}
			switch (mproperty.monster_color)
			{
				case monster_color.green_monster:
					setMonsterColorCount(monster_color.green_monster);
					color = monster_color.yellow_monster;
					break;
				case monster_color.yellow_monster:
					setMonsterColorCount(monster_color.yellow_monster);
					color = monster_color.red_monster;
					break;
				case monster_color.red_monster:
					setMonsterColorCount(monster_color.red_monster);
					color = monster_color.purple_monster;
					break;
				case monster_color.purple_monster:
					setMonsterColorCount(monster_color.purple_monster);
					color = monster_color.blue_monster;
					break;
				case monster_color.blue_monster:
					setMonsterColorCount(monster_color.blue_monster);
					color_cnt = getChainExplosionLineCount(monster_color.green_monster);
					if (color_cnt != 0)
					{
						color = monster_color.green_monster;
						break;
					}
					color_cnt = getChainExplosionLineCount(monster_color.yellow_monster);
					if (color_cnt != 0)
					{
						color = monster_color.yellow_monster;
						break;
					}
					color_cnt = getChainExplosionLineCount(monster_color.red_monster);
					if (color_cnt != 0)
					{
						color = monster_color.red_monster;
						break;
					}
					color_cnt = getChainExplosionLineCount(monster_color.purple_monster);
					if (color_cnt != 0)
					{
						color = monster_color.purple_monster;
						break;
					}

					color = monster_color.white_monster;
					break;
				//			case monster_color.orange_monster:
				//				setMonsterColorCount(monster_color.orange_monster);
				//				color = monster_color.white_monster;
				//				break;
				default:
					setMonsterColorCount(monster_color.green_monster);
					color = monster_color.white_monster;
					break;
			}
			// カラーセット
			property[tagid].monsterColorDisplayCount = 0;
			property[tagid].monster_color = color;
			return color;
		}
		// モンスターカラー戻し　直前にカラーチェンジされたモンスターカラーの中から該当のモンスターポジショングループを探しカラーを変更前に戻す
		public void resetMonster_color(monster_color m_color, int group, int count)
		{
			//			monster_color color;
			//			switch(m_color) {
			//			case monster_color.green_monster:
			//				color = monster_color.yellow_monster;
			//				break;
			//			case monster_color.yellow_monster:
			//				color = monster_color.red_monster;
			//				break;
			//			case monster_color.red_monster:
			//				color = monster_color.purple_monster;
			//				break;
			//			case monster_color.purple_monster:
			//				color = monster_color.blue_monster;
			//				break;
			//			case monster_color.blue_monster:
			//				color = monster_color.white_monster;
			//				break;
			//			default:
			//				color = m_color;
			//				break;
			//			}
			// 該当のポジションのカラーチェンジされたモンスターカラーを戻す
			for (int i = 1; i <= property.Count; i++)
			{
				string monster_tag = i.ToString();
				if (m_color != property[monster_tag].monster_color)
				{
					if (property[monster_tag].monsterCubePositionGroup == group && !property[monster_tag].InOutStatus)
					{
						property[monster_tag].monster_color = m_color;
					}
					count--;
					if (count <= 0) return;
				}
			}
		}
		// カラーカウントマイナス
		void setMonsterColorCount(monster_color color)
		{
			int cnt = color_count[color];
			cnt--;
			if (cnt < 0) cnt = 0;
			color_count[color] = cnt;
		}
		// カラーカウントプラス
		void resetMonsterColorCount(monster_color color)
		{
			int cnt = color_count[color];
			cnt++;
			color_count[color] = cnt;
		}
		// カラーカウント取得
		public int get_monsterColorCount(monster_color color)
		{
			return color_count[color];
		}
		// カラーチェンジ判定 ラストカラー
		public bool checkMonsterColorChange(monster_color color)
		{
			if (color == monster_color.white_monster)
			{
				return false;
			}
			else
			{
				return true;
			}
		}
		// カラーカウントラスト判定
		public bool Get_monsterColorLastcheck()
		{
			if (color_count[monster_color.green_monster] <= 0
				&& color_count[monster_color.yellow_monster] <= 0
				&& color_count[monster_color.red_monster] <= 0
				&& color_count[monster_color.purple_monster] <= 0
				&& color_count[monster_color.blue_monster] <= 0)
			{
				// ラスト一つ前カラー個数が 0?
				return true;
			}
			else
			{
				return false;
			}
		}
		// 連鎖　カラー別チェーンライン数設定
		public void init_chainExplosionLineCount(long level)
		{
			if (chainExplosionLineCount == null)
			{
				chainExplosionLineCount = new Dictionary<monster_color, int>();
			}
			else
			{
				chainExplosionLineCount.Clear();
			}

			switch (level)
			{
				case 1:
				case 2:
					level_Line_count = cube3ChainExplosionLineCount;
					break;
				case 3:
				case 4:
					level_Line_count = cube4ChainExplosionLineCount;
					break;
				case 5:
				case 6:
					level_Line_count = cube5ChainExplosionLineCount;
					break;
				default:
					level_Line_count = cube3ChainExplosionLineCount;
					break;
			}
			// TODO: 連鎖　テスト処理　テスト後は必ず修正が必要　各カラー別連鎖ラインカウントセット
#if !DEBUG
			chainExplosionLineCount.Add(monster_color.green_monster, 0);
			chainExplosionLineCount.Add(monster_color.yellow_monster, 0);
			chainExplosionLineCount.Add(monster_color.red_monster, 0);
			chainExplosionLineCount.Add(monster_color.purple_monster, 0);
			chainExplosionLineCount.Add(monster_color.blue_monster, 1);
			chainExplosionLineCount.Add(monster_color.orange_monster, 0);
#else
			chainExplosionLineCount.Add(monster_color.green_monster, level_Line_count);
			chainExplosionLineCount.Add(monster_color.yellow_monster, level_Line_count);
			chainExplosionLineCount.Add(monster_color.red_monster, level_Line_count);
			chainExplosionLineCount.Add(monster_color.purple_monster, level_Line_count);
			chainExplosionLineCount.Add(monster_color.blue_monster, level_Line_count);
			chainExplosionLineCount.Add(monster_color.orange_monster, level_Line_count);
#endif
		}
		// 連鎖　カラー別連鎖ライン数取得
		public int getChainExplosionLineCount(monster_color color)
		{
			return chainExplosionLineCount[color];
		}
		// カラー別連鎖ラインカウント減算
		public void setMonsterChainExplosionLineCount(monster_color color, int linecount)
		{
			chainExplosionLineCount[color] = linecount;
		}

		// 連鎖　カラーカウント初期化
		public void init_chainExplosionCounter(long level)
		{
			if (color_count == null)
			{
				color_count = new Dictionary<monster_color, int>();
			}
			else
			{
				color_count.Clear();
			}

			switch (level)
			{
				case 1:
				case 2:
					level_count = monster_totalCount_3;
					break;
				case 3:
				case 4:
					level_count = monster_totalCount_4;
					break;
				case 5:
				case 6:
					level_count = monster_totalCount_5;
					break;
				default:
					level_count = monster_totalCount_5;
					break;
			}
			// TODO: 連鎖　テスト処理　各カラーカウントセット
#if !DEBUG
		color_count.Add(monster_color.green_monster, 0);
		color_count.Add(monster_color.yellow_monster, 0);
		color_count.Add(monster_color.red_monster, 0);
		color_count.Add(monster_color.purple_monster, 0);
		color_count.Add(monster_color.blue_monster, 1);
		color_count.Add(monster_color.orange_monster, 0);
#else
		color_count.Add(monster_color.green_monster, level_count);
		color_count.Add(monster_color.yellow_monster, level_count);
		color_count.Add(monster_color.red_monster, level_count);
		color_count.Add(monster_color.purple_monster, level_count);
		color_count.Add(monster_color.blue_monster, level_count);
		color_count.Add(monster_color.orange_monster, level_count);
#endif
		}

		// モンスターカラー変更の為、頂点カラーを利用したキャラオブジェクトのMESHオブジェクトを変更する処理の為
		// fbx内のMESHオブジェクトをカラー指定のあるオブジェクトを返す
		public Mesh GetMonsterColorMesh(monster_situation situation, monster_color color)
        {
			switch (situation)
			{
				case monster_situation.noraml_monster:
				case monster_situation.angry_monster:
				case monster_situation.sleep_monster:
				case monster_situation.wakeup_monster:
				case monster_situation.smile_monster:
				case monster_situation.fear_monster:
				case monster_situation.impatient_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							mainmesh = monster2_blueMesh;
							break;
						case monster_color.green_monster:
							mainmesh = monster2_greenMesh;
							break;
						case monster_color.orange_monster:
							mainmesh = monster2_orangeMesh;
							break;
						case monster_color.red_monster:
							mainmesh = monster2_redMesh;
							break;
						case monster_color.yellow_monster:
							mainmesh = monster2_yellowMesh;
							break;
						case monster_color.purple_monster:
							mainmesh = monster2_purpleMesh;
							break;
						case monster_color.white_monster:
							mainmesh = monster2_whiteMesh;
							break;
						case monster_color.black_monster:
							mainmesh = monster2_blackMesh;
							break;
					}
					break;
				case monster_situation.happy_monster:
					mainmesh = monster2_whiteMesh;
					break;
				case monster_situation.death_monster:
					mainmesh = monster2_blackMesh;
					break;
				default:
					mainmesh = monster2_greenMesh;
					break;
			}
			return mainmesh;
		}

		// モンスターマテリアル変更
		public Material GetMonsterMaterial(monster_situation situation, monster_color color)
		{
			switch (situation)
			{
				case monster_situation.noraml_monster:
				case monster_situation.angry_monster:
				case monster_situation.happy_monster:
				case monster_situation.death_monster:
				case monster_situation.sleep_monster:
				case monster_situation.wakeup_monster:
				case monster_situation.smile_monster:
				case monster_situation.fear_monster:
				case monster_situation.impatient_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							mainmaterial = monster1_blue;
							break;
						case monster_color.green_monster:
							mainmaterial = monster1_green;
							break;
						case monster_color.orange_monster:
							mainmaterial = monster1_orange;
							break;
						case monster_color.red_monster:
							mainmaterial = monster1_red;
							break;
						case monster_color.yellow_monster:
							mainmaterial = monster1_yellow;
							break;
						case monster_color.purple_monster:
							mainmaterial = monster1_purple;
							break;
						case monster_color.white_monster:
							mainmaterial = monster1_white;
							break;
						case monster_color.black_monster:
							mainmaterial = monster1_black;
							break;
					}
					break;
				default:
					mainmaterial = monster1_green;
					break;
			}
			return mainmaterial;
		}

		// モンスターテクスチャ変更
		public Texture GetMonsterTexture(monster_situation situation, monster_color color)
		{
			switch (situation)
			{
				case monster_situation.noraml_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = normal_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = normal_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = normal_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = normal_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = normal_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = normal_texture;
							break;
					}
					break;
				case monster_situation.angry_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = angry_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = angry_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = angry_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = angry_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = angry_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = angry_texture;
							break;
					}
					break;
				case monster_situation.happy_monster:
					switch (color)
					{
						case monster_color.blue_monster:
						case monster_color.green_monster:
						case monster_color.orange_monster:
						case monster_color.red_monster:
						case monster_color.yellow_monster:
						case monster_color.purple_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = happy_texture;
							break;
					}
					break;
				case monster_situation.death_monster:
					switch (color)
					{
						case monster_color.blue_monster:
						case monster_color.green_monster:
						case monster_color.orange_monster:
						case monster_color.red_monster:
						case monster_color.yellow_monster:
						case monster_color.purple_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = death_texture;
							break;
					}
					break;
				case monster_situation.sleep_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = sleep_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = sleep_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = sleep_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = sleep_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = sleep_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = sleep_texture;
							break;
					}
					break;
				case monster_situation.wakeup_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = wakeup_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = wakeup_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = wakeup_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = wakeup_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = wakeup_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = wakeup_texture;
							break;
					}
					break;
				case monster_situation.smile_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = smile_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = smile_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = smile_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = smile_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = smile_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = smile_texture;
							break;
					}
					break;
				case monster_situation.fear_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = fear_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = fear_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = fear_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = fear_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = fear_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = fear_texture;
							break;
					}
					break;
				case monster_situation.impatient_monster:
					switch (color)
					{
						case monster_color.blue_monster:
							maintexture = impatient_texture_blue;
							break;
						case monster_color.green_monster:
							maintexture = impatient_texture_green;
							break;
						case monster_color.purple_monster:
							maintexture = impatient_texture_purple;
							break;
						case monster_color.red_monster:
							maintexture = impatient_texture_red;
							break;
						case monster_color.yellow_monster:
							maintexture = impatient_texture_yellow;
							break;
						case monster_color.orange_monster:
						case monster_color.white_monster:
						case monster_color.black_monster:
						default:
							maintexture = impatient_texture;
							break;
					}
					break;

				default:
					break;
			}
			return maintexture;
		}
		// モンスターアニメーション設定
		public string PlayMonsterAnimation(monster_situation situation, long gamesceen)
		{
			string animationName = "pakupaku03";
			switch (situation)
			{
				case monster_situation.noraml_monster:
				case monster_situation.fear_monster:
					if (gamesceen == 0)
					{
						animationName = "pakupaku03";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_idle";
					}
					if (gamesceen == 2)
					{
						//animationName = "Anim_Slime_Idle";
						animationName = "Anim_Slime_Walking_02";
					}
					break;
				case monster_situation.angry_monster:
				case monster_situation.impatient_monster:
					if (gamesceen == 0)
					{
						animationName = "pakupaku03";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_attack";
					}
					if (gamesceen == 2)
					{
						animationName = "Anim_Slime_Attack_03";
					}
					break;
				case monster_situation.happy_monster:
				case monster_situation.smile_monster:
					if (gamesceen == 0)
					{
						animationName = "paku";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_move";
					}
					if (gamesceen == 2)
					{
                        animationName = "Anim_Slime_WalkingJump";
					}
					break;
				case monster_situation.death_monster:
					if (gamesceen == 0)
					{
						animationName = "deth01";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_die";
					}
					if (gamesceen == 2)
					{
						animationName = "Anim_Slime_Dying_01";
					}
					break;
				case monster_situation.sleep_monster:
					if (gamesceen == 0)
					{
						animationName = "pakupaku03";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_damage";
					}
					if (gamesceen == 2)
					{
						animationName = "Anim_Slime_idle";
					}
					break;
				case monster_situation.wakeup_monster:
					if (gamesceen == 0)
					{
						animationName = "pakupaku03";
					}
					if (gamesceen == 1)
					{
						animationName = "rabbit_damage";
					}
					if (gamesceen == 2)
					{
						animationName = "Anim_Slime_Walking_04";
						//animationName = "Anim_Slime_WalkingJump3";
					}
					break;
				default:
					break;
			}
			return animationName;
		}
	}
}