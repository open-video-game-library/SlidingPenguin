using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class penguinDelete : MonoBehaviour
{
    InstantiatePenguin InstantiatePenguin;
    public GameObject penguin;
    // Start is called before the first frame update
    void Start()
    {
        InstantiatePenguin=penguin.GetComponent<InstantiatePenguin>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag=="Player")
        {
            InstantiatePenguin.penguinRespawn();
            Destroy(collision.gameObject);
        }
    }
}
