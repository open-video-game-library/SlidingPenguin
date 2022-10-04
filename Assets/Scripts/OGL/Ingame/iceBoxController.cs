using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iceBoxController : MonoBehaviour
{
    public GameObject audioManager;
    AudioSource _poyonSound;
    // Start is called before the first frame update
    void Start()
    {
       ///_poyonSound=audioManager.GetComponent<AudioSource>();
       _poyonSound=this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="Player")
        {
            _poyonSound.Play();
        }

    }
    
}
