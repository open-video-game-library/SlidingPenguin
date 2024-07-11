using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

namespace penguin
{
    public class SceneSwitcher : MonoBehaviour
    {
        // Startシーンに遷移するボタン
        [SerializeField] private Button homeButton;
        
        // InGameシーンに遷移し再プレイするボタン
        [SerializeField] private Button retryButton;
        
        // SE再生・停止クラス
        [SerializeField] private ResultSceneAudio audio;
        
        // Start is called before the first frame update
        void Start()
        {
            homeButton.onClick.AddListener(() => StartCoroutine("LoadStartScene"));
            retryButton.onClick.AddListener(() => StartCoroutine("LoadInGameScene"));
        }
        
        private IEnumerator LoadStartScene()
        {
            ExperimentManager.trialCount = 1;
            GameDataExport.SaveCSV(ExportData.ScoreData);

            audio.TransitionClick.Play();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene ("Start");
        }
    
        private IEnumerator LoadInGameScene()
        {
            ExperimentManager.trialCount++;
            GameDataExport.CreateTrailCSV();

            audio.TransitionClick.Play();
            yield return new WaitForSeconds(1.0f);
            SceneManager.LoadScene ("InGame");
        }
    }
}
