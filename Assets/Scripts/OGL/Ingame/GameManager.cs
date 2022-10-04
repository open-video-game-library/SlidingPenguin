using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 


namespace penguin
{
    public class GameManager : MonoBehaviour
    {
        Button HomeBtn;
        public GameObject ingamecanvas;
        float countdown=3.9f;
        int count=-1;
        public bool gameStart=false;
        public GameObject countdownTextObj;
        Text countdownText;
        icegroundController icegroundController;
        public GameObject icegroundControllerObj;
        public GameObject penguin;
        PenguinMove penguinmove_is;          //ここ変える
        public float TIME=0;
        public static float totalTime=0;
        AudioSource _countDownSound;
        public GameObject goalObj;
        GoalDetection _goalDetection;
        bool _stageintroductionfin=false;
        bool once=false;
        public GameObject cam;
        public int minute=0;
        public int seconds;
        public float ms;
        float oldTime=0;
        public GameObject parentPenguin;
        [SerializeField]public int maxTime=180;
        public int remainingtime;
        bool stageintro=false;
        public GameObject bgmObj;
        AudioSource bgm;
        //public GameObject childpenguin;
        AudioSource penguin_voice;
        public GameObject stageObj;
        StageDetection stagedetection;
        public GameObject stageintroBGMObj;
        AudioSource stageIntroBGM;
        public int upNum=0;
        public int downNum=0;
        public int leftNum=0;
        public int rightNum=0;
        public int dashNum=0;
        public int totalNum=0;

        private SpriteRenderer _penguinRenderer;
        void Start()
        {
            ///startBtn.onClick.AddListener(startgameBtnClicked);
            //HomeBtn=HomeBtnObj.GetComponent<Button>();
            //HomeBtn.onClick.AddListener(HomeBtnClicked);
            stageIntroBGM=stageintroBGMObj.GetComponent<AudioSource>();
            stagedetection=stageObj.GetComponent<StageDetection>();
            maxTime=HomeSceneTransitionManager.getTimelimit();
           bgm=bgmObj.GetComponent<AudioSource>();
            countdownText=countdownTextObj.GetComponent<Text>();
            icegroundController=icegroundControllerObj.GetComponent<icegroundController>();
            penguinmove_is=penguin.GetComponent<PenguinMove>();
            _countDownSound=this.gameObject.GetComponent<AudioSource>();
            _goalDetection=goalObj.GetComponent<GoalDetection>();
           

            _penguinRenderer = penguin.GetComponent<SpriteRenderer>();
        }

        // Update is called once per frame
        void Update()
        {
            if(!_stageintroductionfin)
            {
                StartCoroutine("childappeal");
                if(stageintro)
                {
                    cam.GetComponent<Transform>().position -= new Vector3(0,0.4f,0);
                    if(cam.GetComponent<Transform>().position.y<=0||Input.GetKey(KeyCode.Space))    //Input.GetKeyDown("joystick button 1"
                    {
                    //skipTextObj.SetActive(false);
                    stageIntroBGM.Pause();
                    _stageintroductionfin=true;
                    StartCoroutine("CountDownSound");  
                    remainingtime=(int)(maxTime-TIME);
                    }
                }
                
                
                
            }
            
           if(once)
           {
               countdown-=Time.deltaTime;
               count=(int)countdown;          
           }
            
            if(count>0)
            {
                 countdownText.text=count.ToString();
            }
            if(count==0&&!gameStart)
            {
                countdownText.text="START";
                countdownText.fontSize=60;
                 penguinmove_is.enabled=true;
                 gameStart=true;   
                countdownText.text="";
                bgm.Play();
            }

            if(gameStart)
            {
               
                TIME += Time.deltaTime;

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
            
            
            if (!_penguinRenderer.isVisible && gameStart)
            {
                gameStart=false;
                bgm.Pause();
                stagedetection.gameover();
                stagedetection.StartCoroutine("gameOver");
                
                getmizuiroPoint();
                greenPoint();
                redPoint();
                pinkPoint();
                yellowPoint();
            }
            
                
         
            
        }

        void startgameBtnClicked()
        {
            //startcanvas.enabled=false;
            //startcanvas.SetActive(false);
            ingamecanvas.SetActive(true);
            HomeBtn.enabled=false;
            countdownText.text="3";
        }

        void gamestarted()
        {
            gameStart=true;
            
            countdownText.text="";
        }


        public void fingame()
        {
            countdownText.enabled=true;
            
            countdownText.text="FIN";
            countdownText.fontSize=60;
            //icegroundController.Move();
            icegroundController.enabled=false;
        }

        void HomeBtnClicked()
        {
           ingamecanvas.SetActive(false);
           SceneManager.LoadScene ("PenguinScroll");

        }

        private IEnumerator CountDownSound() 
　　    {
          
            yield return new WaitForSeconds (1.0f);
            cam.SetActive(false); 
            yield return new WaitForSeconds (1.0f);
            once=true;
            _countDownSound.Play();
         
        
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
