using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
    public class GoalController : MonoBehaviour
{
    GameManager gamemanager;
    public GameObject gamemanagerObj;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager=gamemanagerObj.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
           gamemanager.fingame();
        }
    }
}
}

