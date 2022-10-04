using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hummercollider : MonoBehaviour
{
    AudioSource audiosource;
    // Start is called before the first frame update
    void Start()
    {
        audiosource=this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="obstacle")
        {
            Destroy(other.gameObject);
            audiosource.Play();
        }
    }

    void OnCollisionEnter2D(Collision2D collisionInfo)
    {
        if(collisionInfo.gameObject.tag=="obstacle")
        {
            Destroy(collisionInfo.gameObject);
            //audiosource.Play();
        }
    }
}
