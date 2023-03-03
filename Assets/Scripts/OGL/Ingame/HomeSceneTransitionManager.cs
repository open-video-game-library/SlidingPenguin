using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace penguin
{
    public class HomeSceneTransitionManager : MonoBehaviour
    {
        [FormerlySerializedAs("_startGameButton")] [SerializeField] private Button startGameButton;
        [FormerlySerializedAs("_settingButton")] [SerializeField] private Button settingButton;
        [FormerlySerializedAs("_homeButton")] [SerializeField] private Button homeButton;
        private static float sensitivity;
        [FormerlySerializedAs("sensitivitysliderObject")] public GameObject sensitivitySliderObject;
        private Slider sensitivitySlider;
        private static int timeLimit;
        [SerializeField] private  GameObject timelimitsliderObject;
        private Slider timelimitSlider;
        [FormerlySerializedAs("homecanvas")] [SerializeField] private  GameObject homeCanvas;
        [FormerlySerializedAs("adjustcanvas")] [SerializeField] private  GameObject adjustCanvas;
        [SerializeField] private StartSceneAudioManager audioManager;

        // Start is called before the first frame update
        private void Start()
        {
            // Initial button assignments
            homeButton.onClick.AddListener(HomeButtonClicked);
            startGameButton.onClick.AddListener(StartButtonClicked);
            settingButton.onClick.AddListener(SettingButtonClicked);
            
            // Screen active setting at startup
            homeCanvas.SetActive(true);
            adjustCanvas.SetActive(false);
            
            // Play BGM
            StartCoroutine(BGMStart());
            
            // Slider assignment
            sensitivitySlider = sensitivitySliderObject.GetComponent<Slider>();
            timelimitSlider = timelimitsliderObject.GetComponent<Slider>();
        }



        private void StartButtonClicked()
        {
            audioManager.PlayTransitionClickSound();
            StartCoroutine("TransitionToMainScene");
            sensitivity = sensitivitySlider.value * 6;
            timeLimit = (int)timelimitSlider.value;
            GetSensitivity();
            GetLimitedTime();
        }

        private void SettingButtonClicked()
        {
            homeCanvas.SetActive(false);
            adjustCanvas.SetActive(true);
            audioManager.PlayNormalClickSound();
        }

        private void HomeButtonClicked()
        {
            homeCanvas.SetActive(true);
            adjustCanvas.SetActive(false);
            //BGMStart();
        }
        
        public static float GetSensitivity() 
        {
            return sensitivity;
        }

        public static int GetLimitedTime()
        {
            return timeLimit;
        }

        private IEnumerator BGMStart()
        {
            yield return new WaitForSeconds(1.0f);
            audioManager.PlayBGM();
        }

        private IEnumerator TransitionToMainScene()
        {
            audioManager.PauseBGM();
            yield return new WaitForSeconds(0.8f);
            SceneManager.LoadScene ("InGame");
        }
    }

}
