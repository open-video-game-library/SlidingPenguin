
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 
//using PathCreation;

namespace penguin
{
    public class GameManager_Esa : MonoBehaviour
{
    //public Button startBtn;
    //public GameObject HomeBtnObj;
    Button HomeBtn;
    //public Canvas startcanvas;
    //public GameObject startcanvas;
    public GameObject ingamecanvas;
    public GameObject timeTextObj;
    Text _timeText;
    float countdown=3.9f;
    int count=-1;
    public bool gameStart=false;
    public GameObject countdownTextObj;
    Text countdownText;
    icegroundController icegroundController;
    public GameObject icegroundControllerObj;
    public GameObject penguin;
    PenguinMove penguinmove;
    public float TIME=0;
    public static float totalTime=0;
    AudioSource _countDownSound;
    public GameObject goalObj;
    GoalDetection _goalDetection;
    bool _stageintroductionfin=false;
    bool once=false;
    //public GameObject cam;
    public GameObject SkipTextObj;
    Text _skipText; 
    public int minute=0;
    public int seconds;
    public float ms;
    float oldTime=0;
    public GameObject timeBackUI;
    public GameObject parentPenguin;
    [SerializeField]int maxTime=180;
    public float remainingtime;
    bool stageintro=false;
    public GameObject bgmObj;
    AudioSource bgm;
    //public GameObject childpenguin;
    AudioSource penguin_voice;
   
    //Follower follower;
    // Start is called before the first frame update
    void Start()
    {
        ///startBtn.onClick.AddListener(startgameBtnClicked);
        //HomeBtn=HomeBtnObj.GetComponent<Button>();
        //HomeBtn.onClick.AddListener(HomeBtnClicked);
       bgm=bgmObj.GetComponent<AudioSource>();
        countdownText=countdownTextObj.GetComponent<Text>();
        icegroundController=icegroundControllerObj.GetComponent<icegroundController>();
        penguinmove=penguin.GetComponent<PenguinMove>();
        _timeText=timeTextObj.GetComponent<Text>();
        SkipTextObj.SetActive(false);
        _countDownSound=this.gameObject.GetComponent<AudioSource>();
        _goalDetection=goalObj.GetComponent<GoalDetection>();
        timeBackUI.SetActive(false);
        StartCoroutine("CountDownSound");
       // penguin_voice=childpenguin.GetComponent<AudioSource>();
        //startcanvas.SetActive(true);
        //follower=parentPenguin.GetComponent<Follower>();
        //follower.enabled=false;
    }

    // Update is called once per frame
    void Update()
    {
         
        
       if(once)
       {
           countdown-=Time.deltaTime;
           count=(int)countdown;           
       }
        
        if(count>0)
        {
             countdownText.text=count.ToString();
        }
        if(count==0)
        {
            countdownText.text="START";
            countdownText.fontSize=60;
             penguinmove.enabled=true;
             gameStart=true;   
            countdownText.text="";
            bgm.Play();
        }

        if(gameStart)
        {
           
            TIME += Time.deltaTime;

            //タイムアタックの時間計算
            /*
            if(TIME >= 60f) 
            {
                minute++;
                TIME = TIME - 60;         
            }
            seconds=Mathf.FloorToInt(TIME);
            ms=(TIME-seconds)*100;
            _timeText.text = minute.ToString("00") + ":" + (seconds).ToString ("00")+"."+ms.ToString("00");
            */

            //指定時間内クリアタイプの時間計算
            remainingtime=(int)(maxTime-TIME);
            _timeText.text = remainingtime.ToString();
        }
            
        
            
        
        if(countdown<=0)
        {
            
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
        //penguinmove.enabled=false;
        //penguinmove.transform.position=new Vector3()
        //HomeBtn.enabled=true;
        //HomeBtnObj.SetActive(true);
    }

    void HomeBtnClicked()
    {
       ingamecanvas.SetActive(false);
       //startcanvas.enabled=true;
       //startcanvas.SetActive(true);
       SceneManager.LoadScene ("PenguinScroll");

    }

    private IEnumerator CountDownSound() 
　　{
        SkipTextObj.SetActive(false);
        timeBackUI.SetActive(true);
        yield return new WaitForSeconds (1.0f);
        //cam.SetActive(false); 
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

}

}
