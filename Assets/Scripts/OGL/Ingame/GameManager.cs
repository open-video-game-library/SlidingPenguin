using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace penguin
{
    public class GameManager : MonoBehaviour
    {
        //Button HomeBtn;
        float countdown = 3.9f;
        int count=-1;
        public bool gameStart=false;
        public GameObject countdownTextObj;
        Text countdownText;
        public GameObject penguin; 
        public float elapsedTime;
        AudioSource _countDownSound;
        bool _stageintroductionfin=false;
        bool once=false;
        public GameObject cam;
        public int minute=0;
        public int seconds;
        public float ms;
        //float oldTime=0;
        bool stageintro=false;
        [SerializeField] GameObject ingameBgm;
        AudioSource bgm;
        //public GameObject childpenguin;
        AudioSource penguin_voice;
        public GameObject stageObj;
        StageDetection stagedetection;
        public GameObject stageintroBGMObj;
        AudioSource stageIntroBGM;
        [SerializeField] private AudioSource countDownSound;
        [SerializeField] private AudioSource rushAlert;

        public int upNum=0;
        public int downNum=0;
        public int leftNum=0;
        public int rightNum=0;
        public int dashNum=0;
        public int totalNum=0;

        private SpriteRenderer _penguinRenderer;

        [SerializeField] private Image countDownImage;

        [SerializeField] private Sprite countDownOne;
        [SerializeField] private Sprite countDownTwo;
        [SerializeField] private Sprite countDownThree;
        [SerializeField] private Sprite countDownGo;

        [SerializeField] private float limitedTime;
        private float setlimitedTime;
        [SerializeField] private Text timeText;

        [SerializeField] private PenguinMove penguinMove;

        [SerializeField] private GameObject timeTextObject;
        [SerializeField] private GameObject fishNumberTextObject;

        private bool isAlert;
        
        private void Start()
        {
            stageIntroBGM=stageintroBGMObj.GetComponent<AudioSource>();
            stagedetection=stageObj.GetComponent<StageDetection>();
            bgm = ingameBgm.GetComponent<AudioSource>();
            countdownText=countdownTextObj.GetComponent<Text>();
            _countDownSound = countDownSound.gameObject.GetComponent<AudioSource>();

            _penguinRenderer = penguin.GetComponent<SpriteRenderer>();
            countDownImage.color = new Color(0,0,0,0);
            timeTextObject.SetActive(false);
            fishNumberTextObject.SetActive(false);
            limitedTime = HomeSceneTransitionManager.GetLimitedTime();
            if (limitedTime == 0)
            {
                limitedTime = setlimitedTime;
            }
        }

        // Update is called once per frame
        private void Update()
        {
            if(!_stageintroductionfin)
            {
                StartCoroutine("childappeal");
                if(stageintro)
                {
                    cam.GetComponent<Transform>().position -= new Vector3(0,0.4f,0);
                    if(cam.GetComponent<Transform>().position.y <= 0 || Input.GetKey(KeyCode.Space))    
                    {
                        stageIntroBGM.Pause();
                        _stageintroductionfin=true;
                        timeTextObject.SetActive(true);
                        fishNumberTextObject.SetActive(true);
                        timeText.text = AdjustRemainingTime(Mathf.CeilToInt(limitedTime - elapsedTime));
                        StartCoroutine("CountDownSound");
                    }
                }
            }
            
           if(once)
           {
               countdown -= Time.deltaTime;
               count = (int)countdown;         
               SwitchUI(); 
           }

           
           if (!gameStart) return;

           
           CountInputNumber();
           JudgeResult();
        }

        private void JudgeResult()
        {
            // 制限時間をオーバーしてしまったら
            elapsedTime += Time.deltaTime;
            timeText.text = AdjustRemainingTime(Mathf.CeilToInt(limitedTime - elapsedTime));
            
            if (!isAlert)
            {
                if (limitedTime - elapsedTime <= 30)
                {
                    isAlert = true;
                    timeText.color = Color.red;
                    StartCoroutine(AlertLeftTime());
                }
                else
                {
                    return;
                }
            }
           
            if (elapsedTime >= limitedTime)
            {
                StartCoroutine(stagedetection.GameOver(StageDetection.GameOverType.TIMEUP));
            }
            
            /*
            // 画面外に行ってしまったら
            if (!_penguinRenderer.isVisible)
            {
                Debug.Log("画面外なう");
                gameStart=false;
                bgm.Pause();
                //stagedetection.gameover();
                StartCoroutine(stagedetection.GameOver(StageDetection.GameOverType.COURCEOUT));
                getmizuiroPoint();
                greenPoint();
                redPoint();
                pinkPoint();
                yellowPoint();
            }
            */
        }

        private IEnumerator AlertLeftTime()
        {
            bgm.Pause();
            rushAlert.Play();
            yield return new WaitForSeconds(1.5f);
            bgm.pitch = 1.2f;
            bgm.Play();
        }

        private string AdjustRemainingTime(int remainingTime)
        {
            int minutes = remainingTime / 60;
            int seconds = remainingTime - minutes * 60;
            
            return minutes.ToString().PadLeft(2, '0') + ":" + seconds.ToString().PadLeft(2, '0');
        }

        private void CountInputNumber()
        {
            if(Input.GetKeyDown(KeyCode.UpArrow)||Input.GetKeyDown(KeyCode.W))
            {
                upNum++;
                totalNum++;
            }
            else if(Input.GetKeyDown(KeyCode.DownArrow)||Input.GetKeyDown(KeyCode.S))
            {
                downNum++;
                totalNum++;
            }
            else if(Input.GetKeyDown(KeyCode.LeftArrow)||Input.GetKeyDown(KeyCode.A))
            {
                leftNum++;
                totalNum++;
            }
            else if(Input.GetKeyDown(KeyCode.RightArrow)||Input.GetKeyDown(KeyCode.D))
            {
                rightNum++;
                totalNum++;
            }
            else if(Input.GetKeyDown(KeyCode.Space)||Input.GetKeyDown(KeyCode.Return))
            {
                dashNum++;
                totalNum++;
            }
        }

        private void SwitchUI()
        {
            if(count>0)
            {
                if(count >= 3)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownThree;
                    //StartCoroutine(RemoveCountDownNumber());
                    return;
                }
                else if(count >= 2)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownTwo;
                    //StartCoroutine(RemoveCountDownNumber());
                    return;
                }
                else if(count >= 1)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownOne;
                    //StartCoroutine(RemoveCountDownNumber());
                    return;
                }
                
            }

            if(count == 0 && !gameStart)
            {
                countDownImage.color =  new Color(1,1,1,1);
                StartCoroutine(RemoveCountDownNumber());
                countDownImage.sprite = countDownGo;
                countdownText.fontSize=60;
                gameStart=true;   
                countdownText.text="";
                penguinMove.enabled = true;
            }
        }

       

        private IEnumerator CountDownSound() 
　　    {
          
            yield return new WaitForSeconds (1.0f);
            cam.SetActive(false); 
            yield return new WaitForSeconds (1.0f);
            once=true;
            _countDownSound.Play();
         
        
        }

        private IEnumerator RemoveCountDownNumber()
        {
            yield return new WaitForSeconds(1.0f);
            bgm.Play();
            countDownImage.color = new Color(0,0,0,0);
        }

        private  IEnumerator childappeal()
        {
            //penguin_voice.Play();
            yield return new WaitForSeconds (3.0f);

            stageintro=true;
            //SkipTextObj.SetActive(true);
        }

        public static int getmizuiroPoint() {
            return CoinController.mizuirocount;
        }
        public static int greenPoint() {
            return CoinController.greencount;
        }
        public static int redPoint() {
            return CoinController.redcount;
        }
        public static int pinkPoint() {
            return CoinController.pinkcount;
        }
        public static int yellowPoint() {
            return CoinController.yellowcount;
        }

    }

}
