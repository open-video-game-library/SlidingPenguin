using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharkMove : MonoBehaviour
{
    [SerializeField]private float sharkSpeed;
   
    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(0,1,0) * Time.deltaTime * sharkSpeed;
    }
}
