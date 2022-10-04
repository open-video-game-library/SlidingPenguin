using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hogehoge : MonoBehaviour
{
  //先ほど作成したクラス
  public SerialHandler serialHandler;

  ////

  void Start()
  {
     //信号を受信したときに、そのメッセージの処理を行う
     serialHandler.OnDataReceived += OnDataReceived;
  }

  void Update()
  {
    //文字列を送信
    //serialHandler.Write("hogehoge");
  }

    //受信した信号(message)に対する処理
    void OnDataReceived(string message)
   {
        var data = message.Split(new string[]{"\n"}, System.StringSplitOptions.None);

        if (data.Length < 2) return;
        /*
        if(data.ToString()=="buttonPin_1")
        {
            Debug.Log("11111111111");
        }
        else if(data.ToString()=="buttonPin_2")
        {
            Debug.Log("222222222");
        }
        */
       try {
           var angleX = data[0].ToString();
           if(angleX=="0")
           {
              Debug.Log("let's go");
           }
           

       } catch (System.Exception e) {
           Debug.LogWarning(e.Message);
       }
   }
}
