using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class stringtest : MonoBehaviour
{
    public string a;
    public Button b;
    // Start is called before the first frame update
    void Start()
    {
        b.onClick.AddListener(()=>coompare(a));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void coompare(string message)
    {
        if(message=="TA")
        {
            Debug.Log("ddddd");
        }
    }
}
