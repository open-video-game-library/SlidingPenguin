using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace penguin
{
    public class PlayButton : MonoBehaviour
    {
        // UIスイッチ処理に伴うSE再生のために参照
        [SerializeField] private StartSceneAudio audio;
        
        // ボタン押下時のUIスイッチ処理のために参照
        [SerializeField] private HomeUISwitcher uiSwitcher;
        
        // Start is called before the first frame update
        private void Start()
        {
            gameObject.GetComponent<Button>().onClick.AddListener(Clicked);
        }

        private void Clicked()
        {
            audio.bgm.Pause();
            audio.TransitionClick.Play();
            uiSwitcher.StartCoroutine("ActivateInGameUI");
        }
        
    }

}
