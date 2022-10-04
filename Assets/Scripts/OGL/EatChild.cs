using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatChild : MonoBehaviour
{
    public GameObject wantFishColor;
    /*
    public Sprite spriteBlue;
    public Sprite spriteGreen;
    public Sprite spriteRed;
    public Sprite spritePink;
    public Sprite spriteYellow;
    */

   // CoinController CoinController;
    public GameObject CoinControllerobj;
    public Sprite[] fishSp;
    public Sprite transparent;
    public GameObject handfish;
    public int handStateNum;    ///0=blue,1=green,2=red,3=pink,4=yellow
    public int color=0;
    // Start is called before the first frame update
    void Start()
    {
        //CoinController=CoinControllerobj.GetComponent<CoinController>();
        handStateNum=10;
        color=Random.Range(0,4);
        wantFishColor.gameObject.GetComponent<SpriteRenderer> ().sprite = fishSp[color];
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="child")
        {
            Silyuukei();
        }

        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        HandFish(other);
        
    }

    void Silyuukei()
    {
        //次の魚をランダム決定
        

        if(color==handStateNum)
        {
            //color=Random.Range(0,4);
            color++;
            wantFishColor.gameObject.GetComponent<SpriteRenderer> ().sprite = fishSp[color%5];
            handfish.GetComponent<SpriteRenderer>().sprite=transparent;
        }
    }

    void HandFish(Collider2D other)
    {
        if(other.gameObject.tag=="mizuiro")
        {
            handfish.GetComponent<SpriteRenderer>().sprite = fishSp[0];
            handStateNum=0;
        }
        if(other.gameObject.tag=="green")
        {
            handfish.GetComponent<SpriteRenderer>().sprite = fishSp[1];
            handStateNum=1;
        }
        if(other.gameObject.tag=="red")
        {
            handfish.GetComponent<SpriteRenderer>().sprite = fishSp[2];
            handStateNum=2;
        }
        if(other.gameObject.tag=="pink")
        {
            handfish.GetComponent<SpriteRenderer>().sprite = fishSp[3];
           handStateNum=3;
        }
        if(other.gameObject.tag=="yellow")
        {
            handfish.GetComponent<SpriteRenderer>().sprite = fishSp[4];
            handStateNum=4;
        }
    }
}
