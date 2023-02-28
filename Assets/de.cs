using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class de : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        for(int i = 0; i < 3; i++)
        {
            this.GetComponent<MeshRenderer>().materials[i].color = new Color32(0,0,0,0);
        }
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
