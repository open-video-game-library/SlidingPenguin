using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovebyJoystick : MonoBehaviour
{
    [SerializeField]float SPEED;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        float horizon=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        if(vertical!=null||horizon!=null)
        {
            this.GetComponent<Rigidbody2D>().velocity=new Vector2(horizon,vertical)*SPEED;
        }
    }
}
