
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager_esa : MonoBehaviour
{
    AudioSource _audiodata;
    //public GameObject audioManager;
    AudioPlayer _audioplayer;
    AudioSource seAudioSource;
    AudioSource _coinsound;
    CoinController CoinController;
    public GameObject gameManagerObj;
    public GameObject AudioManager;
   
    //Renderer _spriterenderer;
    // Start is called before the first frame update
    
    
    void Start()
    {
        //_audiodata=audioManager.gameObject.GetComponent<AudioSource>();
        //_audioplayer=audioManager.GetComponent<AudioPlayer>();
       _coinsound=AudioManager.GetComponent<AudioSource>();
       CoinController=gameManagerObj.GetComponent<CoinController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    /*
    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Player")
        {
            Destroy(this.gameObject);
        }
    }
    */

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            //_audioplayer.GetCoin();
            
            sounda();/*
        var _spriterenderer=this.gameObject.GetComponent<Renderer>();
        _spriterenderer.enabled=false;
        */
        this.gameObject.SetActive(false);

        if(this.gameObject.tag=="green")
        {
            //CoinController.getgreencoin();
            
        }else if(this.gameObject.tag=="mizuiro")
        {
            //CoinController.getmizuirocoin();
            
        }else if(this.gameObject.tag=="pink")
        {
           // CoinController.getpinkcoin();
           
        }else if(this.gameObject.tag=="yellow")
        {
           // CoinController.getyellowcoin();
          
        }else if (this.gameObject.tag=="red")
        {
           // CoinController.getredcoin();
          
        }
           
        
        }
    }

    private void sounda()
    {
        
        _coinsound.Play();
       // StartCoroutine ("Sample");
        
    }

    private IEnumerator Sample() 
    {
        yield return new WaitForSeconds (1.0f);
        _coinsound.enabled=false;
    }


}
