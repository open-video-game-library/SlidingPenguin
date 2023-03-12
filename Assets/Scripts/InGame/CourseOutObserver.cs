using System.Collections;
using System.Collections.Generic;
using penguin;
using UnityEngine;

public class CourseOutObserver : MonoBehaviour
{
    // ゲーム終了時の処理をするクラス
    [SerializeField] private GameOverManager gameOverManager;

    private void OnTriggerExit2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            // ゲームオーバー時の処理を呼ぶ。
            gameOverManager.GameOver(GameOverType.COURCEOUT);
        }
    }

}
