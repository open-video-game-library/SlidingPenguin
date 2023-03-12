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
 	// Hunter-Chameleonの場合は「スコア」「ヒット数」「ヒット率」
     [System.Serializable]
     public class Data
     {
         public bool Success;
         public int FishNumber;
         public string ClearTime;
         public float MovingDistance;
     }
 
 	// 試行が終わったときに呼び出す関数
    public void PostData(bool _success,int _hitCount,string _clear_time,float _distance)
     {
         Data data = new Data(); // クラスを生成
         data.Success = _success; // 成功・失敗
         data.FishNumber = _hitCount; // 獲得魚数
         data.ClearTime = _clear_time; // クリアタイム
         data.MovingDistance=_distance; // スタート地点からの到達距離(ゴールした場合"200")
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
