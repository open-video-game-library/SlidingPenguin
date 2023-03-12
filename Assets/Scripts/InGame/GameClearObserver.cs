using System.Collections;
using System.Collections.Generic;
using penguin;
using UnityEngine;

namespace MyNamespace
{
    public class GameClearObserver : MonoBehaviour
    {
        // クリア時の処理を記述するクラス
        [SerializeField] private GameClearManager gameClearManager;

        void OnTriggerEnter2D(Collider2D other)
        { 
            if(other.gameObject.tag=="Player")
            {
                gameClearManager.GameClear();
            }
        
        }
    }

}
