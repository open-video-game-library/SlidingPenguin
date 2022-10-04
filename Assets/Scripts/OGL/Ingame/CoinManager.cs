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
    CoinController CoinController;
    public GameObject gameManagerObj;
    public GameObject AudioManager;
    private GameManager _gameManager;
    public GameObject addTimeTextObj;
    private Text _addTimeText;
    private bool _addTimeDisplay=false;
    //Renderer _spriterenderer;
    // Start is called before the first frame update
    
    
    void Start()
    {
        //_audiodata=audioManager.gameObject.GetComponent<AudioSource>();
        //_audioplayer=audioManager.GetComponent<AudioPlayer>();
       _coinsound=AudioManager.GetComponent<AudioSource>();
       CoinController=gameManagerObj.GetComponent<CoinController>();
       _gameManager=GameObject.Find("GameManager").GetComponent<GameManager>();
       _addTimeText=addTimeTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(!_addTimeDisplay)
        {
            _addTimeText.text=" ";
        }
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
           
        
        }
    }

    private void sounda()
    {
        
        _coinsound.Play();
        _gameManager.maxTime+=2;
       StartCoroutine ("Sample");
        
    }

    private IEnumerator Sample() 
    {
        _addTimeDisplay=true;
        _addTimeText.text="+2";
        yield return new WaitForSeconds (0.3f);
        _addTimeText.text=" ";
        yield return new WaitForSeconds (0.1f);
        _addTimeText.text="+2";
        yield return new WaitForSeconds (0.3f);
        _addTimeText.text=" ";
        yield return new WaitForSeconds (0.1f);
        _addTimeText.text="+2";
        yield return new WaitForSeconds (0.3f);
        _addTimeText.text=" ";
        _addTimeDisplay=false;
        
    }


}

}