using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
public class NewBehaviourScript : MonoBehaviour
{
    public GameObject penguin;
    // Start is called before the first frame update
    public void gameInitialize()
    {
        penguin.GetComponent<Transform>().position=new Vector3(0,-0.7f,-10);
        
    } 
}
}
