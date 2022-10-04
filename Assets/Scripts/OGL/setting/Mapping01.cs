using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Mapping01 : MonoBehaviour
{
    public SerialHandler serialHandler;
    public simpleMove simpleMove;
    public Button right;
    public Button left;
    // Start is called before the first frame update
    void Start()
    {
        right.onClick.AddListener(rightBtnMapping);
        left.onClick.AddListener(leftBtnMapping);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void rightBtnMapping()
    {
        if(serialHandler.isNewMessageReceived_)
        {
            if(simpleMove.detas[0]=="RIGHT")  ///マッピングボタンが押されてから一番最初に入力されたものを取得し、それをマッピングする。
            {
                
            }
        }
       
    }
    void leftBtnMapping()
    {

    }

    
}
