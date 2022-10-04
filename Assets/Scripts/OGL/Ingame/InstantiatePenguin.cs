using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiatePenguin : MonoBehaviour
{
    public GameObject penguin;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    public void penguinRespawn()
    {
        GameObject penguin_instance=Instantiate(penguin,new Vector3(0,-6.0f,0),Quaternion.identity);
        Vector3 flowDirection=new Vector3(0,70,0);
        penguin_instance.GetComponent<Rigidbody2D>().AddForce(flowDirection);
    }
}
