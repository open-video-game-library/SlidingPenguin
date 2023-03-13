using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

namespace penguin
{
    public class GameClearManager : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ゲームの成功・失敗フラグ
        private static bool IsSuccess;
        
        // InGameシーンの時間管理クラス
        [SerializeField] private TimeKeeper timeKeeper;
        
        // CSVファイルで出力するデータをまとめるクラス
        [SerializeField] private OutputDataManager outputDataManager;

        // ペンギンの挙動を制御するクラス
        [SerializeField] private PenguinBehavior penguinBehavior;
        
        // SE/BGMの管理クラス
        [SerializeField] private InGameAudio audio;
        
        // InGameシーンのUIスイッチ処理を扱うクラス
        [SerializeField] private InGameUISwitcher inGameUISwitcher;


        private void Start()
        {
            IsSuccess = false;
        }

        public void GameClear()
        {
            statusManager.CurrentStatus = InGameStatus.ReachGoal;
            IsSuccess=true;
            
            // UIをoffにする
            inGameUISwitcher.UnActivateInGameUI();

            // データポスト
            outputDataManager.PostData(true, FishManager.GetAcquiredNumber(), timeKeeper.elapsedTime.ToString(), 200.0f, ParameterManager.sensitivity, ParameterManager.limitedTime); 
            
            // ペンギンを停止させ、操作をoffにする
            StartCoroutine(penguinBehavior.Stop(0.1f));

            StartCoroutine(PlayClearSound());
            StartCoroutine(LoadResultScene());

        }

        
        // SE/bgmの再生・切り替え
        private IEnumerator PlayClearSound()
        {
            audio.bgm.Pause();
            audio.applause.Play();
            yield return new WaitForSeconds(2.0f);
            audio.gameClear.Play();
        }

        // リザルトシーンのロード
        private IEnumerator LoadResultScene()
        {
            yield return new WaitForSeconds(4.0f);
            SceneManager.LoadScene("Result");
        }

        
        public static bool IsClear() 
        {
            return IsSuccess;
        }
        
    }
}