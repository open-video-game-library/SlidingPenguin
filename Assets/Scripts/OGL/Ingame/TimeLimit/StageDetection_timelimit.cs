using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
public class StageDetection_timelimit : MonoBehaviour
{
    //public GameObject gameOverTextObj;
    //Text _gameOverText;
    public GameObject IngameCanvas;
    //public GameObject ScoreCanvas;
    public GameObject penguin;
    PenguinMove penguinMove;
    SpriteRenderer _penguinrenderer;
    Color penguincolor;
    bool _gameover;
    float _alpha;
    AudioSource _missSound;
    //public GameObject goalObj;
    GoalDetection _goalDetection;
    public static bool _gameclear;
    public GameObject cam;
    public GameObject audioManager_sub;
    AudioSource _outflamesound;
    GameManager_TimeLimit GameManager_TimeLimit;
    public GameObject GameManagerObj;
    // Start is called before the first frame update
    void Start()
    {
        //_gameOverText=gameOverTextObj.GetComponent<Text>();
        //_gameOverText.text="";
        penguinMove=penguin.GetComponent<PenguinMove>();
        _penguinrenderer=penguin.GetComponent<SpriteRenderer>();
        penguincolor=penguin.GetComponent<SpriteRenderer>().color;
        _gameover=false;
        _missSound=this.gameObject.GetComponent<AudioSource>();
        _outflamesound=audioManager_sub.GetComponent<AudioSource>();
        GameManager_TimeLimit=GameManagerObj.GetComponent<GameManager_TimeLimit>();
        //_goalDetection=goalObj.GetComponent<GoalDetection>();
        //penguin.GetComponent<SpriteRenderer> ().color.a=0.3f;
    }
    float _time;
    // Update is called once per frame
    void Update()
    {
        if(GameManager_TimeLimit.limitTime<=0)
        {
            gameover();
            StartCoroutine("gameOver");
        }
        if(_gameover)
        {
            _time+=Time.deltaTime;
            float t=0.7f-_time;
            _alpha=t/0.7f;
            Debug.Log(_alpha);
            if(_alpha>0)
            {
                //penguin.GetComponent<SpriteRenderer> ().color.a=_alpha;
                penguincolor.a=_alpha;
                penguin.GetComponent<SpriteRenderer>().color=penguincolor;
            }
            
        }

        if(penguin.transform.position.y<cam.transform.position.y-10.0f)
        {
            _outflamesound.Play();
            gameover();
            StartCoroutine("gameOver");
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            gameover();
            StartCoroutine("gameOver");
        }
        if(other.gameObject.tag=="hammer")
        {
            other.gameObject.GetComponent<Collider2D>().enabled=false;
        }
    }
    
    private IEnumerator gameOver() 
    {
        IngameCanvas.SetActive(false);
        yield return new WaitForSeconds(1.0f);
        //_gameOverText.text="GameOver";    
        
        //ScoreCanvas.SetActive(true);
        SceneManager.LoadScene("Penguin_TimeLimit_Score");
    }
    void gameover()
    {   
        _missSound.Play();
        penguinMove.enabled=false;
        _gameover=true;
        _penguinrenderer.sortingLayerName="1";
        penguin.GetComponent<Collider2D>().enabled=false;
        //_gameclear=_goalDetection.gameFin;
        gameclear();

    }

    public static bool gameclear() {
        //return _gameManager.totalTime;
        return _gameclear;
    }
}
}
