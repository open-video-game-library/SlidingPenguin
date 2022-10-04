using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{

public class ShootController : MonoBehaviour
{
    public GameObject hummer;
    GameObject ShootingObj;
    public GameObject mouse;
    [SerializeField]float power;
    Vector2 direction;
    Vector2 backdirection;
    Rigidbody2D rb;
    public bool shootable;
    public GameObject hummerillust;
    GameManager _gameManager;
    public GameObject gameManagerObj;
    AudioSource _throwSound;
    public AudioClip throwsoud;
    // Start is called before the first frame update
    void Start()
    {
        shootable=true;
        _gameManager=gameManagerObj.GetComponent<GameManager>();
        _throwSound=this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        //var direction = transform.rotation*power;
        if(_gameManager.gameStart)
        {
            if(shootable)
            {
                if(Input.GetKeyDown(KeyCode.Space))
                {
                   hummerillust.GetComponent<Image>().color=new Color32(255,255,255,55);
                   shootable=false;
                   calculatedetection();
                   ShootingObj=Instantiate(hummer,this.transform.position,Quaternion.identity);
                   rb=ShootingObj.GetComponent<Rigidbody2D>();
                   rb.velocity=direction.normalized*power;
                   ShootingObj.transform.position = transform.position;
                   //sound
                   _throwSound.clip=throwsoud;
                   _throwSound.Play();
                   StartCoroutine ("timekeep");
                }    
                if(Input.GetKeyDown("joystick button 1"))
                {
                   hummerillust.GetComponent<Image>().color=new Color32(255,255,255,55);
                   shootable=false;
                   calculatedetection();
                   ShootingObj=Instantiate(hummer,this.transform.position,Quaternion.identity);
                   rb=ShootingObj.GetComponent<Rigidbody2D>();
                   rb.velocity=direction.normalized*power;
                   ShootingObj.transform.position = transform.position;
                   //sound
                   _throwSound.clip=throwsoud;
                   _throwSound.Play();
                   StartCoroutine ("timekeep");
                }    
            }
        }
        
        

        if(ShootingObj)
        {
            ShootingObj.transform.Rotate(0,0,30);
        }
    }

    void calculatedetection()
    {
        direction=mouse.transform.position-this.gameObject.transform.position;
    }
    /*
    void calculatebackdetection(Vector3 now_pos)
    {
        backdirection=direction=this.transform.position-now_pos;
    }

    
    // コルーチン  
    private IEnumerator Sample() 
    {
        yield return new WaitForSeconds (2.0f);
        calculatebackdetection(ShootingObj.transform.position);
        rb.velocity=backdirection.normalized*power;
        ShootingObj.transform.position = transform.position;
    }

    */
    private IEnumerator timekeep() 
    {
        yield return new WaitForSeconds (2.0f);
        ShootingObj.GetComponent<Collider2D>().enabled=false;
        shootable=true;
        //hummerillust.GetComponent<Image>().color=new Color(0,0,0,0);
        
        hummerillust.GetComponent<Image>().color=new Color32(255,255,255,255);
        
    }
    
}

}