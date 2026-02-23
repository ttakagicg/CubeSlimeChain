using UnityEngine;

namespace nm_RankBadge
{

    public class RankBadge : MonoBehaviour
    {

        public static readonly int PSUSE_BUTTON_X = 275;
        public static readonly int PSUSE_BUTTON_Y = 20;
        public static readonly int GAMEPOINT_WIDTH = 180;
        public static readonly int GAMEPOINT_LABEL_WIDTH = 80;
        public static readonly int PLAYTIME_WIDTH = 80;

        const float button_height = 35;
        const float button_width = 40;
        const int button_count = 4;

        private static float screen_width_per;
        private static float screen_height_per;

        public GameObject stage1_badge_Lv1;
        public GameObject stage1_badge_Lv2;
        public GameObject stage1_badge_Lv3;
        public GameObject stage2_badge_Lv1;
        public GameObject stage2_badge_Lv2;
        public GameObject stage2_badge_Lv3;
        public GameObject stage3_badge_Lv1;
        public GameObject stage3_badge_Lv2;
        public GameObject stage3_badge_Lv3;
        public GameObject stage4_badge_Lv1;
        public GameObject stage4_badge_Lv2;
        public GameObject stage4_badge_Lv3;
        public GameObject stage5_badge_Lv1;
        public GameObject stage5_badge_Lv2;
        public GameObject stage5_badge_Lv3;
        public GameObject stage6_badge_Lv1;
        public GameObject stage6_badge_Lv2;
        public GameObject stage6_badge_Lv3;

        //public static GameObject stage1_badge_Lv1_s;
        //public static GameObject stage1_badge_Lv2_s;
        //public static GameObject stage1_badge_Lv3_s;
        //public static GameObject stage2_badge_Lv1_s;
        //public static GameObject stage2_badge_Lv2_s;
        //public static GameObject stage2_badge_Lv3_s;
        //public static GameObject stage3_badge_Lv1_s;
        //public static GameObject stage3_badge_Lv2_s;
        //public static GameObject stage3_badge_Lv3_s;
        //public static GameObject stage4_badge_Lv1_s;
        //public static GameObject stage4_badge_Lv2_s;
        //public static GameObject stage4_badge_Lv3_s;
        //public static GameObject stage5_badge_Lv1_s;
        //public static GameObject stage5_badge_Lv2_s;
        //public static GameObject stage5_badge_Lv3_s;
        //public static GameObject stage6_badge_Lv1_s;
        //public static GameObject stage6_badge_Lv2_s;
        //public static GameObject stage6_badge_Lv3_s;



        void Start()
        {

            screen_width_per = Screen.width / 1125.0f;
            screen_height_per = Screen.height / 2436.0f;
            //Debug.Log(" screen: " + Screen.width + " " + Screen.height);

            // stage1-1
            Vector3 scal_rb1_1 = stage1_badge_Lv1.transform.localScale;
            scal_rb1_1.x = scal_rb1_1.x * screen_width_per;
            scal_rb1_1.y = scal_rb1_1.y * screen_width_per;
            stage1_badge_Lv1.transform.localScale = scal_rb1_1;
            stage1_badge_Lv1.gameObject.SetActive(false);
            // stage1-2
            Vector3 scal_rb1_2 = stage1_badge_Lv2.transform.localScale;
            scal_rb1_2.x = scal_rb1_2.x * screen_width_per;
            scal_rb1_2.y = scal_rb1_2.y * screen_width_per;
            stage1_badge_Lv2.transform.localScale = scal_rb1_2;
            stage1_badge_Lv2.gameObject.SetActive(false);
            // stage1-3
            Vector3 scal_rb1_3 = stage1_badge_Lv3.transform.localScale;
            scal_rb1_3.x = scal_rb1_3.x * screen_width_per;
            scal_rb1_3.y = scal_rb1_3.y * screen_width_per;
            stage1_badge_Lv3.transform.localScale = scal_rb1_3;
            stage1_badge_Lv3.gameObject.SetActive(false);

            // stage2-1
            Vector3 scal_rb2_1 = stage2_badge_Lv1.transform.localScale;
            scal_rb2_1.x = scal_rb2_1.x * screen_width_per;
            scal_rb2_1.y = scal_rb2_1.y * screen_width_per;
            stage2_badge_Lv1.transform.localScale = scal_rb2_1;
            stage2_badge_Lv1.gameObject.SetActive(false);
            // stage2-2
            Vector3 scal_rb2_2 = stage2_badge_Lv2.transform.localScale;
            scal_rb2_2.x = scal_rb2_2.x * screen_width_per;
            scal_rb2_2.y = scal_rb2_2.y * screen_width_per;
            stage2_badge_Lv2.transform.localScale = scal_rb2_2;
            stage2_badge_Lv2.gameObject.SetActive(false);
            // stage2-3
            Vector3 scal_rb2_3 = stage2_badge_Lv3.transform.localScale;
            scal_rb2_3.x = scal_rb2_3.x * screen_width_per;
            scal_rb2_3.y = scal_rb2_3.y * screen_width_per;
            stage2_badge_Lv3.transform.localScale = scal_rb2_3;
            stage2_badge_Lv3.gameObject.SetActive(false);

            // stage4-1
            Vector3 scal_rb4_1 = stage4_badge_Lv1.transform.localScale;
            scal_rb4_1.x = scal_rb4_1.x * screen_width_per;
            scal_rb4_1.y = scal_rb4_1.y * screen_width_per;
            stage4_badge_Lv1.transform.localScale = scal_rb4_1;
            stage4_badge_Lv1.gameObject.SetActive(false);
            // stage1-2
            Vector3 scal_rb4_2 = stage4_badge_Lv2.transform.localScale;
            scal_rb4_2.x = scal_rb4_2.x * screen_width_per;
            scal_rb4_2.y = scal_rb4_2.y * screen_width_per;
            stage4_badge_Lv2.transform.transform.localScale = scal_rb4_2;
            stage4_badge_Lv2.gameObject.SetActive(false);
            // stage1-3
            Vector3 scal_rb4_3 = stage4_badge_Lv3.transform.localScale;
            scal_rb4_3.x = scal_rb4_3.x * screen_width_per;
            scal_rb4_3.y = scal_rb4_3.y * screen_width_per;
            stage4_badge_Lv3.transform.localScale = scal_rb4_3;
            stage4_badge_Lv3.gameObject.SetActive(false);

            // stage5-1
            Vector3 scal_rb5_1 = stage5_badge_Lv1.transform.localScale;
            scal_rb5_1.x = scal_rb5_1.x * screen_width_per;
            scal_rb5_1.y = scal_rb5_1.y * screen_width_per;
            stage5_badge_Lv1.transform.localScale = scal_rb5_1;
            stage5_badge_Lv1.gameObject.SetActive(false);
            // stage5-2
            Vector3 scal_rb5_2 = stage5_badge_Lv2.transform.localScale;
            scal_rb5_2.x = scal_rb5_2.x * screen_width_per;
            scal_rb5_2.y = scal_rb5_2.y * screen_width_per;
            stage5_badge_Lv2.transform.localScale = scal_rb5_2;
            stage5_badge_Lv2.gameObject.SetActive(false);
            // stage5-3
            Vector3 scal_rb5_3 = stage5_badge_Lv3.transform.localScale;
            scal_rb5_3.x = scal_rb5_3.x * screen_width_per;
            scal_rb5_3.y = scal_rb5_3.y * screen_width_per;
            stage5_badge_Lv3.transform.localScale = scal_rb5_3;
            stage5_badge_Lv3.gameObject.SetActive(false);

            // stage6-1
            Vector3 scal_rb6_1 = stage6_badge_Lv1.transform.localScale;
            scal_rb6_1.x = scal_rb6_1.x * screen_width_per;
            scal_rb6_1.y = scal_rb6_1.y * screen_width_per;
            stage6_badge_Lv1.transform.localScale = scal_rb6_1;
            stage6_badge_Lv1.gameObject.SetActive(false);
            // stage6-2
            Vector3 scal_rb6_2 = stage6_badge_Lv2.transform.localScale;
            scal_rb6_2.x = scal_rb6_2.x * screen_width_per;
            scal_rb6_2.y = scal_rb6_2.y * screen_width_per;
            stage6_badge_Lv2.transform.localScale = scal_rb6_2;
            stage6_badge_Lv2.gameObject.SetActive(false);
            // stage6-3
            Vector3 scal_rb6_3 = stage6_badge_Lv3.transform.localScale;
            scal_rb6_3.x = scal_rb6_3.x * screen_width_per;
            scal_rb6_3.y = scal_rb6_3.y * screen_width_per;
            stage6_badge_Lv3.transform.localScale = scal_rb6_3;
            stage6_badge_Lv3.gameObject.SetActive(false);

            //stage1_badge_Lv1_s = stage1_badge_Lv1;
            //stage1_badge_Lv2_s = stage1_badge_Lv2;
            //stage1_badge_Lv3_s = stage1_badge_Lv3;
            //stage2_badge_Lv1_s = stage2_badge_Lv1;
            //stage2_badge_Lv2_s = stage2_badge_Lv2;
            //stage2_badge_Lv3_s = stage2_badge_Lv3;
            //stage3_badge_Lv1_s = stage3_badge_Lv1;
            //stage3_badge_Lv2_s = stage3_badge_Lv2;
            //stage3_badge_Lv3_s = stage3_badge_Lv3;
            //stage4_badge_Lv1_s = stage4_badge_Lv1;
            //stage4_badge_Lv2_s = stage4_badge_Lv2;
            //stage4_badge_Lv3_s = stage4_badge_Lv3;
            //stage5_badge_Lv1_s = stage5_badge_Lv1;
            //stage5_badge_Lv2_s = stage5_badge_Lv2;
            //stage5_badge_Lv3_s = stage5_badge_Lv3;
            //stage6_badge_Lv1_s = stage6_badge_Lv1;
            //stage6_badge_Lv2_s = stage6_badge_Lv2;
            //stage6_badge_Lv3_s = stage6_badge_Lv3;

        }

        public void setRankBadge(int stage_no, int level)
        {
            stage1_badge_Lv1.gameObject.SetActive(false);
            stage1_badge_Lv2.gameObject.SetActive(false);
            stage1_badge_Lv3.gameObject.SetActive(false);
            stage2_badge_Lv1.gameObject.SetActive(false);
            stage2_badge_Lv2.gameObject.SetActive(false);
            stage2_badge_Lv3.gameObject.SetActive(false);
            stage3_badge_Lv1.gameObject.SetActive(false);
            stage3_badge_Lv2.gameObject.SetActive(false);
            stage3_badge_Lv3.gameObject.SetActive(false);
            stage4_badge_Lv1.gameObject.SetActive(false);
            stage4_badge_Lv2.gameObject.SetActive(false);
            stage4_badge_Lv3.gameObject.SetActive(false);
            stage5_badge_Lv1.gameObject.SetActive(false);
            stage5_badge_Lv2.gameObject.SetActive(false);
            stage5_badge_Lv3.gameObject.SetActive(false);
            stage6_badge_Lv1.gameObject.SetActive(false);
            stage6_badge_Lv2.gameObject.SetActive(false);
            stage6_badge_Lv3.gameObject.SetActive(false);

            switch (stage_no)
            {
                case 1:
                    switch(level)
                    {
                        case 1:
                            stage1_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage1_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage1_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 2:
                    switch (level)
                    {
                        case 1:
                            stage2_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage2_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage2_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 3:
                    switch (level)
                    {
                        case 1:
                            stage3_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage3_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage3_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 4:
                    switch (level)
                    {
                        case 1:
                            stage4_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage4_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage4_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 5:
                    switch (level)
                    {
                        case 1:
                            stage5_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage5_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage5_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
                case 6:
                    switch (level)
                    {
                        case 1:
                            stage6_badge_Lv1.gameObject.SetActive(true);
                            break;
                        case 2:
                            stage6_badge_Lv2.gameObject.SetActive(true);
                            break;
                        case 3:
                            stage6_badge_Lv3.gameObject.SetActive(true);
                            break;
                    }
                    break;
            }
        }
    }
}