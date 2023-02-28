using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace penguin
{
public class CoinManager : MonoBehaviour
{
    AudioSource _audiodata;
    //public GameObject audioManager;
    AudioPlayer _audioplayer;
    AudioSource seAudioSource;
    AudioSource _coinsound;
    public GameObject gameManagerObj;
    public GameObject AudioManager;
    private GameManager _gameManager;
    
    // Start is called before the first frame update
    
    
    void Start()
    {
        //_audiodata=audioManager.gameObject.GetComponent<AudioSource>();
        //_audioplayer=audioManager.GetComponent<AudioPlayer>();
       _coinsound=AudioManager.GetComponent<AudioSource>();
       _gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
       
    }

    // Update is called once per frame
  
    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="Player")
        {
            transform.parent.gameObject.SetActive(false);

            /*
            if(this.gameObject.tag=="green")
            {
                CoinController.getgreencoin();
            }else if(this.gameObject.tag=="mizuiro")
            {
                CoinController.getmizuirocoin();
            }else if(this.gameObject.tag=="pink")
            {
                CoinController.getpinkcoin();
            }else if(this.gameObject.tag=="yellow")
            {
                CoinController.getyellowcoin();
            }else if (this.gameObject.tag=="red")
            {
                CoinController.getredcoin();
            }
            */
            
           
        
        }
    }
    

}

}