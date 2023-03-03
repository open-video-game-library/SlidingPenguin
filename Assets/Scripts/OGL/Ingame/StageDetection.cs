using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace penguin
{
    public class StageDetection : MonoBehaviour
    {
        [SerializeField] private  GameObject penguinShadow;
        PenguinMove penguinMove;       
        SpriteRenderer _penguinShadowRenderer;
        SpriteRenderer _fishrenderer;
        public bool CourseOut;
        private float _alpha;
        public GameObject goalObj;
        GoalDetection _goalDetection;
        public static bool _gameclear;
        public GameObject timeTextObj;

        public GameObject GameManager;
        GameManager gamemanager;
        public GameObject dataManagerObj;
        DataManager dataManager;
        float start_pos_y=0;
        public float _distance;
        public GameObject bgmObj;
        AudioSource bgm;
        [SerializeField] private Rigidbody2D penguinRigidBody;

        [SerializeField] private GameObject timeUpText;

        [SerializeField] private PenguinDisappear penguinDisappear;

        [SerializeField] private InGameAudioManager audioManager;
        public enum GameOverType
        {
            TIMEUP,
            COURCEOUT
        }

        private InputDataManager _inputDataManager;
        //fishGet fishGet;
        // Start is called before the first frame update
        void Start()
        {
            bgm=bgmObj.GetComponent<AudioSource>();
            dataManager = dataManagerObj.GetComponent<DataManager>();
            _penguinShadowRenderer=penguinShadow.GetComponent<SpriteRenderer>();
            penguinMove=penguinShadow.GetComponent<PenguinMove>();
            CourseOut=false;
            gamemanager=GameManager.GetComponent<GameManager>();
            _goalDetection=goalObj.GetComponent<GoalDetection>();
            timeUpText.SetActive(false);
            _inputDataManager=GameObject.Find("GameManager").GetComponent<InputDataManager>();


            

        }
        float _time;
        // Update is called once per frame
        private void FixedUpdate()
        {
            if(CourseOut)
            {
                _time += Time.deltaTime;
                float t = 0.7f - _time;
                _alpha = t / 0.7f;
                //Debug.Log(_alpha);
                if(_alpha >= 0)
                {
                    penguinDisappear.Disappear(_alpha);
                }
                
            }

            
        }

        void OnTriggerExit2D(Collider2D other)
        {
            if(other.gameObject.tag == "Player")
            {
                StartCoroutine(GameOver(GameOverType.COURCEOUT));
                getmizuiroPoint();
                greenPoint();
                redPoint();
                pinkPoint();
                yellowPoint();
            }
        }
        
        public IEnumerator GameOver(GameOverType gameOverType) 
        {
            gamemanager.gameStart=false;
            bgm.Pause();
            timeTextObj.SetActive(false);
            penguinMove.enabled=false;

            if (gameOverType == GameOverType.COURCEOUT)
            {
                CourseOut=true;
                audioManager.drop.Play();
                
                _penguinShadowRenderer.sortingLayerName="1";
                penguinShadow.GetComponent<Collider2D>().enabled=false;
            }
            else
            {
                timeUpText.SetActive(true);
                audioManager.timeUp.Play();
                penguinRigidBody.velocity = Vector3.zero;
                penguinRigidBody.angularVelocity = 0;
            }
            
            
            
            gameclear();

            if (dataManager != null)
            {
                 int fish_num=penguinMove.fishcounter;
                _distance=penguinShadow.transform.position.y-start_pos_y;
                dataManager.postData(false,fish_num,100000000,_distance,(float)gamemanager.totalNum/gamemanager.elapsedTime,(float)gamemanager.upNum/gamemanager.elapsedTime,(float)gamemanager.downNum/gamemanager.elapsedTime,(float)gamemanager.leftNum/gamemanager.elapsedTime,(float)gamemanager.rightNum/gamemanager.elapsedTime,(float)gamemanager.dashNum/gamemanager.elapsedTime,_inputDataManager.up_on,_inputDataManager.up_off);        
            }
            
           
            
            
            
            yield return new WaitForSeconds(0.1f);
            audioManager.timeUp.Play();
            yield return new WaitForSeconds(1.0f);
            audioManager.gameOver.Play();
            yield return new WaitForSeconds(1.8f);
            SceneManager.LoadScene("Result");
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