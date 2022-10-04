using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

////動くだけ。修正しない
public class MoveOnly : MonoBehaviour
{
    
    CollisionDetection CollisionDetection;
    Rigidbody2D rb; 
    [SerializeField]public float SPEED;
    float defaultSpeed;
    float fighSpeed;
    float highSpeed;
    Transform transform;
    //public GameObject VeloObj;
    Text VeloTex;
    public GameObject sensiobj;
    [SerializeField]float brake=0.99f;
    Text sensitext;
    //public AudioSource brakesoud;
    public AudioClip brakeclip;
    Animator animator;
    bool jump;
    Vector3 Force;
    // Start is called before the first frame update
    void Start()
    {
        rb=this.GetComponent<Rigidbody2D>();
        transform=this.gameObject.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizon=Input.GetAxis("Horizontal");
        float vertical=Input.GetAxis("Vertical");
        if(vertical!=null||horizon!=null)
        {
            /*
            if(!jump)
            {
                Force=new Vector3(horizon,vertical,0)*SPEED;
            }
            else{
                Force=new Vector3(horizon,vertical,0)*SPEED*3;
            }
            
            rb.AddForce(Force);
            float angle=Mathf.Atan(vertical/horizon)*Mathf.Rad2Deg;
            if(horizon>=0)
            {
                transform.rotation=Quaternion.Euler(0,0,angle-90.0f); 
            }
            else
            {
                transform.rotation=Quaternion.Euler(0,0,angle+90.0f); 
            }
             */
        }
        
        if(Input.GetKeyDown("left")){
			rb.velocity=new Vector2(-1.0f,0)*SPEED;
            Debug.Log("A");
		} else if(Input.GetKeyDown("right")){ // 右キーを押し続けていたら
			rb.velocity=new Vector2(1.0f,0)*SPEED;         
		} 
		
		else if(Input.GetKeyDown("up")){ // 右キーを押し続けていたら
            //onGround=false;
			rb.velocity=new Vector2(0,1.0f)*SPEED;         
		} 
        

        if(Input.GetKeyUp("left")){
			rb.velocity=new Vector2(0,0);
            Debug.Log("A");
		} else if(Input.GetKeyUp("right")){ // 右キーを押し続けていたら
			rb.velocity=new Vector2(0,0);         
		} else if(Input.GetKeyUp("up")){ // 右キーを押し続けていたら
			rb.velocity=new Vector2(0,0);         
		} 
    }
}
