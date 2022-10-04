using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    [SerializeField]float sharkSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //this.transform.position+=Vector3.forward*Time.deltaTime;
        this.transform.position+=new Vector3(0,1,0)*Time.deltaTime*sharkSpeed;
    }
}
