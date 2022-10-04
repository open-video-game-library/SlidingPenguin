using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; 

namespace penguin
{
    public class HomeSceneTransitionManager : MonoBehaviour
    {
        [SerializeField] private Button _startGameButton;
        [SerializeField] private Button _settingButton;
        [SerializeField] private Button _homeButton;
        [SerializeField] private GameObject audiomanager;
        public static float sensitivity;
        public static string name;
        public static string age;
        public GameObject sensitivitysliderObject;
        private Slider sensitivitySlider;
        [SerializeField] private static int timelimit;
        [SerializeField] private  GameObject timelimitsliderObject;
        private Slider timelimitSlider;
        [SerializeField] private  GameObject homecanvas;
        [SerializeField] private  GameObject adjustcanvas;
        [SerializeField] private  GameObject infoInputcanvas;
        [SerializeField] private  AudioSource settingsound;
        //Player Info
        public GameObject nameTextObj;
        public GameObject ageTextObj;
        private Text _nameText;
        private Text _ageText;
        
        // Start is called before the first frame update
        void Start()
        {
            _homeButton.onClick.AddListener(HomeButtonClicked);
            _startGameButton.onClick.AddListener(StartButtonClicked);
            _settingButton.onClick.AddListener(SettingButtonClicked);
            settingsound = audiomanager.GetComponent<AudioSource>();
            sensitivitySlider = sensitivitysliderObject.GetComponent<Slider>();
            timelimitSlider = timelimitsliderObject.GetComponent<Slider>();
            //Player Info
            _nameText = nameTextObj.GetComponent<Text>();
            _ageText = ageTextObj.GetComponent<Text>();
            infoInputcanvas.SetActive(false);
            homecanvas.SetActive(true);
            adjustcanvas.SetActive(false);
            StartCoroutine(BGMstart());
        }



        void StartButtonClicked()
        {
            StartCoroutine("load");
            name = _nameText.text;
            age = _ageText.text;
            sensitivity = sensitivitySlider.value * 6;
            timelimit = (int)timelimitSlider.value;
            getSensitivity();
            getTimelimit();
            getPlayerName();
            getPlayerAge();
        }

        public void SettingButtonClicked()
        {
            adjustcanvas.SetActive(true);
            settingsound.Play();
            //homecanvas.SetActive(false);
            //infoInputcanvas.SetActive(false);
        }

        void HomeButtonClicked()
        {
            homecanvas.SetActive(true);
            adjustcanvas.SetActive(false);
            infoInputcanvas.SetActive(false);
            BGMstart();
        }

        public static string getPlayerName() {
            //return _gameManager.totalTime;
            return name;
        }

        public static string getPlayerAge() {
            //return _gameManager.totalTime;
            return age;
        }

        public static float getSensitivity() {
            //return _gameManager.totalTime;
            return sensitivity;
        }

        public static int getTimelimit() {
            //return _gameManager.totalTime;
            return timelimit;
        }

        private IEnumerator BGMstart()
        {
            yield return new WaitForSeconds(1.0f);
            GetComponent<AudioSource>().Play();
        }

        private IEnumerator load()
        {
            yield return new WaitForSeconds(0.8f);
            GetComponent<AudioSource>().Pause();
            SceneManager.LoadScene ("InGame");
        }
    }

}
