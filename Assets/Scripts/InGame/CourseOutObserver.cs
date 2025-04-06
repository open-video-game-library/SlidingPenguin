using System.Collections;
using System.Collections.Generic;
using penguin;
using UnityEngine;

public class CourseOutObserver : MonoBehaviour
{
    // ゲーム終了時の処理をするクラス
    [SerializeField] private GameOverManager gameOverManager;
    // リスポーンする処理をするクラス
    [SerializeField] private RespawnManager respawnManager;
    // 現在のステータスを管理するクラス
    [SerializeField] private InGameStatusManager statusManager;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // 既にコースアウト判定になっている場合は、以降の処理を呼ばない
            if (statusManager.CurrentStatus == InGameStatus.CourseOut) { return; }

            if (ParameterManager.respawn)
            {
                // スタート地点から復活
                StartCoroutine(respawnManager.Respawn());
            }
            else
            {
                // ゲームオーバー時の処理を呼ぶ。
                gameOverManager.GameOver(GameOverType.COURCEOUT);
            }
        }
    }
}
