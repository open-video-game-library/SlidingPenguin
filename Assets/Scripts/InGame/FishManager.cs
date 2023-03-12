using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace  penguin
{
    /// <summary>
    /// ペンギンオブジェクトにアタッチし、魚（アイテム）との衝突時の処理を記述する。
    /// </summary>
    public class FishManager : MonoBehaviour
    {
        // 獲得した魚の数
        [HideInInspector] private static int FishNumber = 0;
 
        // 獲得した魚の数を表示するテキスト
        [SerializeField] private Text fishNumberText;
        
        // 魚獲得時のSE再生処理を参照
        [SerializeField] private InGameAudio audio;

        private static int maximumFishNumber;

        private void Start()
        {
            maximumFishNumber = GameObject.FindGameObjectsWithTag("Fish").Length;
            FishNumber = 0;
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if(other.gameObject.tag== "Fish")
            {
                FishNumber ++;
                fishNumberText.text = "×" + FishNumber;
                audio.itemAcquire.Play();
                other.gameObject.transform.parent.gameObject.SetActive(false);
            }
        }
        
        public static int GetMaximumNumber()
        {
            return maximumFishNumber;
        }

        public static int GetAcquiredNumber()
        {
            return FishNumber;
        }
    }

}
