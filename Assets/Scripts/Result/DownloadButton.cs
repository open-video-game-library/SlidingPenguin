using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
    public class DownloadButton : MonoBehaviour
    {
        // データをダウンロードするために呼ぶ関数を持つクラス
        [SerializeField] private OutputDataManager outputDataManager;
        
        // データをダウンロードするボタン
        [SerializeField] private Button dataDownloadButton;
        
        // SE再生・停止クラス
        [SerializeField] private ResultSceneAudio audio;
     
         void Start()
         {
             dataDownloadButton.onClick.AddListener(Clicked);
         }
         private void Clicked()
         {
             outputDataManager.GetData();
             audio.NormalClick.Play();
         }
    }

}
