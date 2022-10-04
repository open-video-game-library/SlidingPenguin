using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class DataManager : MonoBehaviour
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
         public float inputNum;
         public float upNum;
         public float downNum;
         public float leftNum;
         public float rightNum;
         public float dashNum;
         public bool success;
         public string age;
         //public int fish_num;
         //public int score;
         public string name;
         public int fish_num;
         public float clear_time;
         public float distance;
         public List<float> up_on;
         public List<float> up_off;
         //public float hit_rate;
     }
 
 	// 試行が終わったときに呼び出す関数
 	// Hunter-Chameleonでは、ゲーム終了のときに「スコア」「ヒット数」「トリガーを引いた数」を引数としてこの関数を呼び出しています
 	// ゲームに応じて分かりやすい変数名にしてください
     public void postData(string _name,string _age,bool _success,int _hitCount,float _clear_time,float _distance,float _InputNumperSec,float _upNum,float _downNum,float _leftNum,float _dashNum,float _rightNum,List<float> _up_on,List<float> _up_off)
     {
         Data data = new Data(); // クラスを生成
         data.name = _name;  //名前
         data.age = _age;  //年齢
         data.success = _success; // スコア
         data.fish_num = _hitCount; // ヒット数
         data.clear_time = _clear_time; // ヒット数
         data.distance=_distance;
         data.inputNum=_InputNumperSec;
         data.upNum=_upNum;
         data.downNum=_downNum;
         data.leftNum=_leftNum;
         data.rightNum=_rightNum;
         data.dashNum=_dashNum;
         data.up_on=_up_on;
         data.up_off=_up_off;
         //data.hit_rate = (float)_hitCount / (float)_triggerCount; // ヒット率
         string json = JsonUtility.ToJson(data); // json形式に変換してjsに渡す
 #if UNITY_WEBGL && !UNITY_EDITOR
         addData(json);
 #endif
     }
 
 	// ダウンロードボタンを押したときに呼び出す関数
     public void getData()
     {
 #if UNITY_WEBGL && !UNITY_EDITOR
         downloadData();
 #endif
     }
}
