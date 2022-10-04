using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DownloadButton : MonoBehaviour
{
    DataManager dataManager;
    //public GameObject testobj;
    //Text testtex;
    Button btn;
    
 
     void Start()
     {
         dataManager = GameObject.Find("DataManager").GetComponent<DataManager>();
         btn=GetComponent<Button>();
         btn.onClick.AddListener(getinfo);
         //testtex=testobj.GetComponent<Text>();
     }
     
     // ボタンを押したら
     /*
     public void OnClickButton()
     {
        dataManager.getData();

     }
     */
     public void getinfo()
     {
         dataManager.getData();
         //testtex.text="getdata";
     }
}
