using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinvoiceController : MonoBehaviour
{
    AudioSource audio;
    float t;
    // Start is called before the first frame update
    void Start()
    {
       audio= GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        t+=Time.deltaTime;
        audio.volume=(Mathf.Lerp(3,0,t/8))*0.1f;
    }
}
