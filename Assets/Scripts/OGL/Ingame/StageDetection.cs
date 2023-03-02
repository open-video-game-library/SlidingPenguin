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
        AudioSource _missSound;
        public GameObject goalObj;
        GoalDetection _goalDetection;
        public static bool _gameclear;
        public GameObject timeTextObj;
        public AudioClip gameOverSound;
        [SerializeField] private AudioClip dropSound;
        [SerializeField] private AudioClip timeUpSound;

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
        [SerializeField] private Rigidbody2D penguinRigidBody;

        [SerializeField] private GameObject timeUpText;

        [SerializeField] private PenguinDisappear penguinDisappear;
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
            datastatusText=datastatusTextObj.GetComponent<Text>();
            dataManager = dataManagerObj.GetComponent<DataManager>();
            _penguinShadowRenderer=penguinShadow.GetComponent<SpriteRenderer>();
            penguinMove=penguinShadow.GetComponent<PenguinMove>();
            CourseOut=false;
            _missSound=gameObject.GetComponent<AudioSource>();
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
            
            /*
            if(other.gameObject.tag=="fish")
            {
                other.gameObject.GetComponent<Collider2D>().enabled=false;
                //Destroy(other.gameObject);
                _fishrenderer=other.gameObject.GetComponent<SpriteRenderer>();
                _fishrenderer.sortingLayerName="1";
               // other.gameObject.GetComponent<fishGet>().enabled=false;
            }
            */

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
                _missSound.clip = dropSound;
                
                _penguinShadowRenderer.sortingLayerName="1";
                penguinShadow.GetComponent<Collider2D>().enabled=false;
            }
            else
            {
                timeUpText.SetActive(true);
                _missSound.clip = timeUpSound;
                penguinRigidBody.velocity = Vector3.zero;
                penguinRigidBody.angularVelocity = 0;
            }
            
            
            
            gameclear();

            if(dataManager==null)
            {
                datastatusText.text="null";
            }
            else
            {
                int fish_num=penguinMove.fishcounter;
                _distance=penguinShadow.transform.position.y-start_pos_y;
                dataManager.postData(_goalDetection._name,_goalDetection._age,false,fish_num,100000000,_distance,(float)gamemanager.totalNum/gamemanager.elapsedTime,(float)gamemanager.upNum/gamemanager.elapsedTime,(float)gamemanager.downNum/gamemanager.elapsedTime,(float)gamemanager.leftNum/gamemanager.elapsedTime,(float)gamemanager.rightNum/gamemanager.elapsedTime,(float)gamemanager.dashNum/gamemanager.elapsedTime,_inputDataManager.up_on,_inputDataManager.up_off);             ///データポストpublic void postData(bool success,float _cleartime, int _fish_num) penguinMove_IS.fishcounter
                datastatusText.text="post";
            }
            
            
            
            yield return new WaitForSeconds(0.1f);
            _missSound.Play();
            yield return new WaitForSeconds(1.0f);
            _missSound.clip = gameOverSound;
            _missSound.Play();
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