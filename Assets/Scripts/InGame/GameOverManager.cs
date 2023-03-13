using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace penguin
{
    public enum GameOverType
    {
        TIMEUP,
        COURCEOUT
    }
    
    public class GameOverManager : MonoBehaviour
    {
        
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // InGameシーンのSE再生・停止クラス
        [SerializeField] private InGameAudio audio;

        // ペンギンのモデル
        [SerializeField] private GameObject penguinModel;
        
        // ペンギンの挙動を制御するクラス
        [SerializeField] private  PenguinBehavior _penguinBehavior;

        // InGameシーンのUIスイッチ処理を扱うクラス
        [SerializeField] private InGameUISwitcher inGameUISwitcher;

        // CSVファイルで出力するデータをまとめるクラス
        [SerializeField] private OutputDataManager outputDataManager;
        
        // ペンギンのスタート地点のy座標。進んだ距離を算出するために参照
        private float penguinStartPositionY;
        
        
        // Start is called before the first frame update
        void Start()
        {
            penguinStartPositionY = penguinModel.transform.position.y;
        }
  
        public void GameOver(GameOverType gameOverType) 
        {
            // UIをoffにする
            inGameUISwitcher.UnActivateInGameUI();
            
            // ペンギンを停止させ、操作をoffにする
            StartCoroutine(_penguinBehavior.Stop(0.5f));


            // ゲームオーバーの仕方によって異なる処理
            if (gameOverType == GameOverType.COURCEOUT)
            {
                statusManager.CurrentStatus = InGameStatus.CourseOut;
                penguinModel.SetActive(false);
                audio.drop.Play();
            }
            else if (gameOverType == GameOverType.TIMEUP)
            {
                statusManager.CurrentStatus = InGameStatus.TimeUp;
                inGameUISwitcher.ActivateTimeUpUI();
                audio.timeUp.Play();
                
            }



            // ポストデータをセット
            SetPostData();
           
            StartCoroutine(PlayClearSound());
            StartCoroutine(LoadResultScene());
        }

        // CSV出力するデータをセットし、postする関数を叩く。
        private void SetPostData()
        {
            if (outputDataManager != null)
            {
                int fishNum = FishManager.GetAcquiredNumber();
                float distance = penguinModel.transform.position.y - penguinStartPositionY;
                outputDataManager.PostData(false, fishNum, "undefined", distance, ParameterManager.sensitivity, ParameterManager.limitedTime);        
            }
        }
        
        // SE/bgmの再生
        private IEnumerator PlayClearSound()
        {
            audio.bgm.Pause();
            yield return new WaitForSeconds(1.0f);
            audio.gameOver.Play();
        }

        // リザルトシーンのロード
        private IEnumerator LoadResultScene()
        {
            yield return new WaitForSeconds(3.0f);
            SceneManager.LoadScene("Result");
        }

        
    }

}