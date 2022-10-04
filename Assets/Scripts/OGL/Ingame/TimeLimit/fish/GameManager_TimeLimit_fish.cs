using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

namespace penguin
{
    public class GameManager_TimeLimit_fish : MonoBehaviour
{
    //public Button startBtn;
    //public GameObject HomeBtnObj;
    Button HomeBtn;
    //public Canvas startcanvas;
    //public GameObject startcanvas;
    public GameObject ingamecanvas;
    float countdown=3.9f;
    int count=-1;
    public bool gameStart=false;
    public GameObject countdownTextObj;
    Text countdownText;
    //icegroundController icegroundController;
    //public GameObject icegroundControllerObj;
    public GameObject penguin;
    PenguinMove penguinmove;
    public float TIME=0;
    public static float totalTime=0;
    AudioSource _countDownSound;
    public GameObject goalObj;
    GoalDetection_timelimit_fish _goalDetection;
    bool _stageintroductionfin=false;
    bool once=false;
    public GameObject cam;
    public GameObject SkipTextObj;
    Text _skipText; 
    [SerializeField]public float limitTime=100.0f;
    public GameObject timeLimitTextObj;
    Text _timeLimitText;
    // Start is called before the first frame update
    void Start()
    {
        ///startBtn.onClick.AddListener(startgameBtnClicked);
        //HomeBtn=HomeBtnObj.GetComponent<Button>();
        //HomeBtn.onClick.AddListener(HomeBtnClicked);
        countdownText=countdownTextObj.GetComponent<Text>();
        //icegroundController=icegroundControllerObj.GetComponent<icegroundController>();
        penguinmove=penguin.GetComponent<PenguinMove>();     
        _countDownSound=this.gameObject.GetComponent<AudioSource>();
        _goalDetection=goalObj.GetComponent<GoalDetection_timelimit_fish>();
        //startcanvas.SetActive(true);
        _timeLimitText=timeLimitTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_stageintroductionfin)
        {
            cam.GetComponent<Transform>().position-=new Vector3(0,0.3f,0);
            SkipTextObj.SetActive(true);
            
            if(cam.GetComponent<Transform>().position.y<=0||Input.GetKey(KeyCode.Space))
            {
                
                _stageintroductionfin=true;
                StartCoroutine("CountDownSound");     
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
        if(count==0)
        {
            countdownText.text="START";
            countdownText.fontSize=60;
            penguinmove.enabled=true;
        }

        if(gameStart&&!_goalDetection._fin)
        {
            limitTime=limitTime-Time.deltaTime;
            _timeLimitText.text=((int)limitTime).ToString();
        }
            
        
        if(countdown<=0)
        {
            gamestarted();
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
        //icegroundController.enabled=false;
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
        yield return new WaitForSeconds (1.0f);
        cam.SetActive(false); 
        yield return new WaitForSeconds (1.0f);
        once=true;
        _countDownSound.Play();
     
    
    }

}

}
