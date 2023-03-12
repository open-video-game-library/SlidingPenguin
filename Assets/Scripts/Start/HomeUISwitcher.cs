using System;
using System.Collections;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace penguin
{
    public class HomeUISwitcher : MonoBehaviour
    {
        // 表示をスイッチするキャンバス
        [SerializeField] private  GameObject homeCanvas;
        [SerializeField] private  GameObject adjustCanvas;
      
        public void ActivateHomeUI()
        {
            homeCanvas.SetActive(true);
            adjustCanvas.SetActive(false);
        }
        
        public void ActivateSettingUI()
        {
            adjustCanvas.SetActive(true);
            homeCanvas.SetActive(false);
        }
        
        public IEnumerator ActivateInGameUI()
        {
            yield return new WaitForSeconds(0.8f);
            SceneManager.LoadScene ("InGame");
        }
        
    }

}
