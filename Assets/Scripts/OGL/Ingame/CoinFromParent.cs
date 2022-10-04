using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{

public class CoinFromParent : MonoBehaviour
{
    float interval;
    public GameObject gameManagerObj;
    GameManager gamemanager;
    public GameObject item;
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        gamemanager=gameManagerObj.GetComponent<GameManager>();
        audiosource=this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gamemanager.gameStart)
        {
            interval+=Time.deltaTime;

            if(interval>3)
            {
                interval=0;
                 
                PutItem();
            }
        }
    }

    void PutItem()
    {
        GameObject fish=Instantiate(item);
        fish.transform.position=this.transform.position;
        audiosource.Play();

    }
}

}