using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
public class GoalDetection : MonoBehaviour
{
    public static bool gameFin;
    public GameObject GameManager;
    GameManager _gameManager;
    private HomeSceneTransitionManager _sceneMana_home;
    public GameObject IngameCanvas;
    //public GameObject ScoreCanvas;
    CoinController CoinController;
    public static float minutes;
    public static float seconds;
    public static float ms;
    public GameObject clearTextObj;
    AudioSource _goalSound;
    public bool _fin;
    public AudioClip clearsound;
    PenguinMove penguinMove;           ///ここ変える
    public GameObject penguin;
    public static int a;
    public GameObject dataManagerObj;
    DataManager dataManager;
    float start_pos_y=0;
    public float _distance;
    public GameObject bgmObj;
    AudioSource bgm;
    private InputDataManager _inputDataManager;
    public string _name;
    public string _age;
    /*
    public GameObject mizuiroScoreTextObj;
    public GameObject greenScoreTextObj;
    public GameObject redScoreTextObj;
    public GameObject pinkScoreTextObj;
    public GameObject yellowScoreTextObj;
    Text mizuiroScoreText;
    Text greenScoreText;
    Text redScoreText;
    Text pinkScoreText;
    Text yellowScoreText;
    */
    // Start is called before the first frame update
    void Start()
    {
        _name = HomeSceneTransitionManager.getPlayerName();
        _age = HomeSceneTransitionManager.getPlayerAge();
        bgm=bgmObj.GetComponent<AudioSource>();
        dataManager=dataManagerObj.GetComponent<DataManager>();
        gameFin=false;
        //ScoreCanvas.SetActive(false);
        CoinController=GameManager.GetComponent<CoinController>();
        _gameManager=GameManager.GetComponent<GameManager>();
        clearTextObj.SetActive(false);
        _goalSound = gameObject.GetComponent<AudioSource>();
        _fin=false;
        penguinMove=penguin.GetComponent<PenguinMove>(); 
        /*
        mizuiroScoreText=mizuiroScoreTextObj.GetComponent<Text>();
        greenScoreText=greenScoreTextObj.GetComponent<Text>();
        redScoreText=redScoreTextObj.GetComponent<Text>();
        pinkScoreText=pinkScoreTextObj.GetComponent<Text>();
        yellowScoreText=yellowScoreTextObj.GetComponent<Text>();
        */
        _inputDataManager=GameObject.Find("GameManager").GetComponent<InputDataManager>();
        
    }

    

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.tag=="Player")
        {
            bgm.Pause();
            gameFin=true;
            _fin=true;
            gamefinish();
            dataManager.postData(_name,_age,true,penguinMove.fishcounter,_gameManager.elapsedTime,180.0f,(float)_gameManager.totalNum/_gameManager.elapsedTime,(float)_gameManager.upNum/_gameManager.elapsedTime,(float)_gameManager.downNum/_gameManager.elapsedTime,(float)_gameManager.leftNum/_gameManager.elapsedTime,(float)_gameManager.rightNum/_gameManager.elapsedTime,(float)_gameManager.dashNum/_gameManager.elapsedTime,_inputDataManager.up_on,_inputDataManager.up_off); 
            penguinMove.enabled=false;
            Rigidbody2D rb = penguin.GetComponent<Rigidbody2D>();
            rb.velocity = Vector3.zero;
        }
        
    }

    void gamefinish()
    {
        _gameManager.gameStart=false;
        minutes=_gameManager.minute;
        seconds=_gameManager.seconds;
        ms=_gameManager.ms;
        getmizuiroPoint();
        greenPoint();
        redPoint();
        pinkPoint();
        yellowPoint();
        MinutePoint();
        SecondPoint();
        MsPoint();
        //getfishPoint();
        StartCoroutine("gameClear");
        clearTextObj.SetActive(true);

        //sound
        _goalSound.Play();
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
    public static float MinutePoint() {
        //return _gameManager.totalTime;
        return minutes;
    }
    public static float SecondPoint() {
        //return _gameManager.totalTime;
        return seconds;
    }
    public static float MsPoint() {
        //return _gameManager.totalTime;
        return ms;
    }
    public static bool gameclear() {
        //return _gameManager.totalTime;
        return gameFin;
    }
    /*
    public static int getfishPoint() {
        //return _gameManager.totalTime;
        a=penguinMove.fishcounter;
        return a;
    }*/
    


    private IEnumerator gameClear() 
    {
        yield return new WaitForSeconds(2.0f);
        _goalSound.clip=clearsound;
        _goalSound.Play();
        //scaleAnimation = true;
        yield return new WaitForSeconds(1.0f);
        //scaleAnimation = false;
        SceneManager.LoadScene("Result");
    }
    
    // Update is called once per frame
    void FixedUpdate()
    {
        if (!scaleAnimation) return;

        itemCountUI.transform.localScale += new Vector3(Time.deltaTime, Time.deltaTime, Time.deltaTime) * 0.07f;
    }

    private bool scaleAnimation;
    [SerializeField] private GameObject itemCountUI;

}
}