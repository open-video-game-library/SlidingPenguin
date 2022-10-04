using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
public class StageDetection : MonoBehaviour
{
    //public GameObject gameOverTextObj;
    //Text _gameOverText;
    public GameObject IngameCanvas;
    //public GameObject ScoreCanvas;
    public GameObject penguin;
    PenguinMove penguinMove_IS;        //ここ変える
    public GameObject fish;
    PenguinMove penguinMove;
    SpriteRenderer _penguinrenderer;
    SpriteRenderer _fishrenderer;
    Color penguincolor;
    public bool _gameover;
    float _alpha;
    AudioSource _missSound;
    public GameObject goalObj;
    GoalDetection _goalDetection;
    public static bool _gameclear;
    public GameObject timeTextObj;
    Text _timeText;
    public AudioClip gameOverSound;
    CoinController CoinController;
    public GameObject GameManager;
    GameManager gamemanager;
    public GameObject dataManagerObj;
    DataManager dataManager;
    public GameObject datastatusTextObj;
    Text datastatusText;
    float start_pos_y=0;
    public float _distance;
    public GameObject bgmObj;
    AudioSource bgm;

    private InputDataManager _inputDataManager;
    //fishGet fishGet;
    // Start is called before the first frame update
    void Start()
    {
        bgm=bgmObj.GetComponent<AudioSource>();
        datastatusText=datastatusTextObj.GetComponent<Text>();
        dataManager = dataManagerObj.GetComponent<DataManager>();
        //penguinMove=penguin.GetComponent<PenguinMove>();
        _penguinrenderer=penguin.GetComponent<SpriteRenderer>();
        penguinMove_IS=penguin.GetComponent<PenguinMove>();
        //_fishrenderer=fish.GetComponent<SpriteRenderer>();
        penguincolor=penguin.GetComponent<SpriteRenderer>().color;
        _gameover=false;
        _missSound=this.gameObject.GetComponent<AudioSource>();
        _timeText=timeTextObj.GetComponent<Text>();
        CoinController=GameManager.GetComponent<CoinController>();
        gamemanager=GameManager.GetComponent<GameManager>();
        //fishGet=fish.GetComponent<fishGet>();
        _goalDetection=goalObj.GetComponent<GoalDetection>();
        //penguin.GetComponent<SpriteRenderer> ().color.a=0.3f;

        _inputDataManager=GameObject.Find("GameManager").GetComponent<InputDataManager>();
        
    }
    float _time;
    // Update is called once per frame
    void Update()
    {
        

        if(_gameover)
        {
            _time+=Time.deltaTime;
            float t=0.7f-_time;
            _alpha=t/0.7f;
            //Debug.Log(_alpha);
            if(_alpha>0)
            {
                //penguin.GetComponent<SpriteRenderer> ().color.a=_alpha;
                penguincolor.a=_alpha;
                penguin.GetComponent<SpriteRenderer>().color=penguincolor;
            }
            
        }

        
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            gameover();
            StartCoroutine("gameOver");
            getmizuiroPoint();
            greenPoint();
            redPoint();
            pinkPoint();
           yellowPoint();
        }
        if(other.gameObject.tag=="hammer")
        {
            other.gameObject.GetComponent<Collider2D>().enabled=false;
        }
        if(other.gameObject.tag=="fish")
        {
            other.gameObject.GetComponent<Collider2D>().enabled=false;
            //Destroy(other.gameObject);
            _fishrenderer=other.gameObject.GetComponent<SpriteRenderer>();
            _fishrenderer.sortingLayerName="1";
           // other.gameObject.GetComponent<fishGet>().enabled=false;
        }

    }
    
    public IEnumerator gameOver() 
    {
        yield return new WaitForSeconds(1.0f);
        _missSound.clip=gameOverSound;
        _missSound.Play();
        //_gameOverText.text="GameOver";    
       // IngameCanvas.SetActive(false);        //コメントアウト
        //ScoreCanvas.SetActive(true);
        yield return new WaitForSeconds(1.8f);
        SceneManager.LoadScene("Result");
    }
    public void gameover()
    {   
        gamemanager.gameStart=false;
        bgm.Pause();
        timeTextObj.SetActive(false);
        _missSound.Play();
        penguinMove_IS.enabled=false;

        _gameover=true;
        _penguinrenderer.sortingLayerName="1";
        penguin.GetComponent<Collider2D>().enabled=false;
        //_gameclear=_goalDetection.gameFin;
        gameclear();

        if(dataManager==null)
        {
            datastatusText.text="null";

        }
        else
        {
            int fish_num=penguinMove_IS.fishcounter;
            _distance=penguin.transform.position.y-start_pos_y;
            dataManager.postData(_goalDetection._name,_goalDetection._age,false,fish_num,100000000,_distance,(float)gamemanager.totalNum/gamemanager.TIME,(float)gamemanager.upNum/gamemanager.TIME,(float)gamemanager.downNum/gamemanager.TIME,(float)gamemanager.leftNum/gamemanager.TIME,(float)gamemanager.rightNum/gamemanager.TIME,(float)gamemanager.dashNum/gamemanager.TIME,_inputDataManager.up_on,_inputDataManager.up_off);             ///データポストpublic void postData(bool success,float _cleartime, int _fish_num) penguinMove_IS.fishcounter
            datastatusText.text="post";
        }
       

    }

    public static bool gameclear() {
        //return _gameManager.totalTime;
        return _gameclear;
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