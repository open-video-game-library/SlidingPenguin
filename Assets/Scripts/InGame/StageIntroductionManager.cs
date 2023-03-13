using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class StageIntroductionManager : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ステージ紹介用カメラの挙動を管理するクラス
        [SerializeField] private StageIntroductionCamera stageIntroductionCamera;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;

        // ゲーム開始前カウントダウン処理をするクラス
        [SerializeField] private CountDown countDown;
        
    
        // Update is called once per frame
        void FixedUpdate()
        {
            if(statusManager.CurrentStatus == InGameStatus.StageIntroduction)
            {
                
                // ステージ紹介用カメラを動かす。
                stageIntroductionCamera.Move();

                
                bool isReachStartPosition = stageIntroductionCamera.transform.position.y <= 15;
                bool isPauseInput = Input.GetKeyDown(KeyCode.Space) || Input.GetButtonDown("Submit");
                
                // カメラが開始地点に到達 OR イントロ中断入力がされたときの処理。
                if(isReachStartPosition || isPauseInput)
                {
                    Finish();
                }
            }
        }

        // ステージ紹介が終了した際に呼び、UIやモードを切り替える関数。
        private void Finish()
        {
            stageIntroductionCamera.Reset();
            stageIntroductionCamera.gameObject.SetActive(false);
            audio.stageIntoro.Pause();
            StartCoroutine(countDown.ChangeMode());
        }
        
    }

}
