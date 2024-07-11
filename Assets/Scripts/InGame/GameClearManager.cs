using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

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
        [SerializeField] private GameDataExport gameDataExport;

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

            int fishNum = FishManager.GetAcquiredNumber();


            // 動作プラットフォームに応じた手法でデータポスト
            if (Application.platform == RuntimePlatform.WebGLPlayer)
            {
                outputDataManager.PostData(true, fishNum, timeKeeper.elapsedTime.ToString(), 200.0f,
                    ParameterManager.sensitivity, ParameterManager.limitedTime, ParameterManager.maximumSpeed, ParameterManager.acceleration, ParameterManager.friction);
            }
            else
            {
                GameDataExport.ExportGameData(true, fishNum, timeKeeper.elapsedTime.ToString(), 200.0f, PenguinBehavior.penguinTrail,
                    ParameterManager.sensitivity, ParameterManager.limitedTime, ParameterManager.maximumSpeed, ParameterManager.acceleration, ParameterManager.friction);
            }

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