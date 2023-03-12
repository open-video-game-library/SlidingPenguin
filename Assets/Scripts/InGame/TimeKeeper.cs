using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class TimeKeeper : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;
        
        // 残り時間を表示するクラス
        [SerializeField] private RemainingTimeText remainingTimeText;
        
        // ゲームオーバー時の処理ををするクラス
        [SerializeField] private GameOverManager gameOverManager;
        
        // 経過時間
        public float elapsedTime;
        
        // ParameterManagerが保持する制限時間を参照
        private float limitedTime;
        
        // 残り時間(s)
        private int remainingTime;
        
        // 急ぐ演出を表示するタイミング。残りhurryUpTiming秒時点で表示。
        [SerializeField] private int hurryUpTiming = 30;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;
        
        
        // Start is called before the first frame update
        void Start()
        {
            limitedTime = ParameterManager.limitedTime;
        }
    
        // Update is called once per frame
        void Update()
        {
            bool isInGame = (statusManager.CurrentStatus == InGameStatus.InGameNormal ||
                            statusManager.CurrentStatus == InGameStatus.HurryUp);
            if (isInGame)
            {
                elapsedTime += Time.deltaTime;
                
                ObserveEvent();
            }
            
        }
        
        
        private void ObserveEvent()
        {
            remainingTime = (int)(limitedTime - elapsedTime);
            remainingTimeText.Set(remainingTime);
            
            
            if (remainingTime <= 0)
            {
                statusManager.CurrentStatus = InGameStatus.TimeUp;
                // ゲームオーバー時の処理を呼ぶ。
                gameOverManager.GameOver(GameOverType.TIMEUP);
            }
            else if (remainingTime <= hurryUpTiming)
            {
                
                if (statusManager.CurrentStatus == InGameStatus.InGameNormal)
                {
                    statusManager.CurrentStatus = InGameStatus.HurryUp;
                    remainingTimeText.TurnRed();
                    StartCoroutine(AlertLeftTime());
                }
                
            }
        }

        private IEnumerator AlertLeftTime()
        {
            audio.bgm.Pause();
            audio.timeAlert.Play();
            yield return new WaitForSeconds(1.5f);
            audio.bgm.pitch = 1.2f;
            audio.bgm.Play();
        }

    }

}
