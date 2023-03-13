using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;


namespace penguin
{
    public class CountDown : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // 残り時間を管理・表示するクラス
        [SerializeField] private RemainingTimeText remainingTimeText;

        // InGameシーンのUIスイッチを担当するクラス
        [SerializeField] private InGameUISwitcher inGameUISwitcher;
        
        // カウントダウン用画像
        [SerializeField] private Image countDownImage;
        [SerializeField] private Sprite countDownThree;
        [SerializeField] private Sprite countDownTwo;
        [SerializeField] private Sprite countDownOne;
        [SerializeField] private Sprite countDownGo;
        
        private float countdown = 6.0f;
        private int count = 10;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;
        

        private void Initialize()
        {
            countDownImage.color = new Color(0,0,0,0);
            remainingTimeText.Set(ParameterManager.limitedTime);
            inGameUISwitcher.ActivateInGameUI();
        }
        
        public IEnumerator ChangeMode()
        {
            Initialize();
            statusManager.CurrentStatus = InGameStatus.CountDown;
            yield return new WaitForSeconds(2.0f);
            audio.countdown.Play();
        }

        private void FixedUpdate()
        {
            if (statusManager.CurrentStatus == InGameStatus.CountDown)
            {
                countdown -= Time.deltaTime;
                count = (int)countdown;         
                SwitchUI(); 
            }
        }
        
        private void SwitchUI()
        {
            if(count > 0)
            {
                if(count == 3)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownThree;
                    return;
                }
                
                if(count == 2)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownTwo;
                    return;
                }
                
                if(count == 1)
                {
                    countDownImage.color = new Color(1,1,1,1);
                    countDownImage.sprite = countDownOne;
                }
            }
            else
            {
                countDownImage.color = new Color(1,1,1,1);
                countDownImage.sprite = countDownGo;
                StartCoroutine(SwitchInGame());
            }
        }
        
        private IEnumerator SwitchInGame()
        {
            statusManager.CurrentStatus = InGameStatus.InGameNormal;
            yield return new WaitForSeconds(1.0f);
            audio.bgm.Play();
            countDownImage.color = new Color(0,0,0,0);
        }
    }
}