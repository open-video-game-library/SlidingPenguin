using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;
using UnityEngine.Serialization;

public class OutputDataManager : MonoBehaviour
{
    #if UNITY_WEBGL && !UNITY_EDITOR
     [DllImport("__Internal")]
     private static extern void addData(string jsonData);
 
     [DllImport("__Internal")]
     private static extern void downloadData();
    #endif

    // 取得するデータのクラスを定義
    [System.Serializable]
     public class Data
     {
         // プレイ結果のパラメータ
         public bool Success;
         public int FishNumber;
         public string ClearTime;
         public float MovingDistance;

         // 設定パラメータ
         public float Sensitivity;
         public int LimitedTime;
     }
 
 	// 試行が終わったときに呼び出す関数
    public void PostData(bool success, int fishNumber, string clearTime, float distance, float sensitivity, int limitedTime)
     {
         Data data = new Data(); // クラスを生成
         data.Success = success; // 成功・失敗
         data.FishNumber = fishNumber; // 獲得魚数
         data.ClearTime = clearTime; // クリアタイム
         data.MovingDistance　=　distance; // スタート地点からの到達距離(ゴールした場合"200")
         data.Sensitivity = sensitivity; //操作感度
         data.LimitedTime = limitedTime; // 制限時間
         string json = JsonUtility.ToJson(data); // json形式に変換してjsに渡す
 #if UNITY_WEBGL && !UNITY_EDITOR
         addData(json);
 #endif
     }
 
 	// ダウンロードボタンを押したときに呼び出す関数
     public void GetData()
     {
 #if UNITY_WEBGL && !UNITY_EDITOR
         downloadData();
 #endif
     }
}
