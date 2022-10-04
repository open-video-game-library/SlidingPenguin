using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    AudioSource _coinaudiosource;
    // Start is called before the first frame update
    void Start()
    {
        _coinaudiosource=this.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetCoin()
    {
        Debug.Log("getcoin");
        //_coinaudiosource.Play();
        AudioSource a=this.gameObject.GetComponent<AudioSource>();
        a.Play();
    }
}
