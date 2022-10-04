using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
public class GoalDetection_timelimit : MonoBehaviour
{
    public static bool gameFin;
    public GameObject GameManager;
    GameManager_TimeLimit _gameManager;
    public GameObject IngameCanvas;
    //public GameObject ScoreCanvas;
    CoinController CoinController;
    public static float timeee;
    public GameObject clearTextObj;
    AudioSource _goalSound;
    public bool _fin;
    
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
        gameFin=false;
        //ScoreCanvas.SetActive(false);
        CoinController=GameManager.GetComponent<CoinController>();
        _gameManager=GameManager.GetComponent<GameManager_TimeLimit>();
        clearTextObj.SetActive(false);
        _goalSound=this.gameObject.GetComponent<AudioSource>();
        _fin=false;
        /*
        mizuiroScoreText=mizuiroScoreTextObj.GetComponent<Text>();
        greenScoreText=greenScoreTextObj.GetComponent<Text>();
        redScoreText=redScoreTextObj.GetComponent<Text>();
        pinkScoreText=pinkScoreTextObj.GetComponent<Text>();
        yellowScoreText=yellowScoreTextObj.GetComponent<Text>();
        */
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    { 
        if(other.gameObject.tag=="Player")
        {
            gameFin=true;
            _fin=true;
            gamefinish();
        }
        
    }

    void gamefinish()
    {
        /*
        IngameCanvas.SetActive(false);
        ScoreCanvas.SetActive(true);
        mizuiroScoreText.text=CoinController.mizuirocount.ToString();
        greenScoreText.text=CoinController.greencount.ToString();
        redScoreText.text=CoinController.redcount.ToString();
        pinkScoreText.text=CoinController.pinkcount.ToString();
        yellowScoreText.text=CoinController.yellowcount.ToString();
 */     
        _gameManager.gameStart=false;
        timeee=_gameManager.TIME;
        getmizuiroPoint();
        greenPoint();
        redPoint();
        pinkPoint();
        yellowPoint();
        timePoint();
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
    public static float timePoint() {
        //return _gameManager.totalTime;
        return timeee;
    }
    public static bool gameclear() {
        //return _gameManager.totalTime;
        return gameFin;
    }

    private IEnumerator gameClear() 
    {
        yield return new WaitForSeconds(4.0f);
        SceneManager.LoadScene("Penguin_TimeLimit_Score");
    }

    
}
}
