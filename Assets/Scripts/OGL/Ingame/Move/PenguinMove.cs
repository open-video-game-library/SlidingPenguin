using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin{
    public class PenguinMove : MonoBehaviour
{
    //public GameObject Ground;
    public int fishcounter=0;
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
    public AudioClip audioClip1;
    Animator animator;
    bool jump;
    Vector3 Force;
    public GameObject counterTextObj;
    Text CounterText;
    AudioSource audioSource;
    public GameObject slidingsound;
    private float _speed;
    // Start is called before the first frame update
    void Start()
    {
        SPEED = HomeSceneTransitionManager.getSensitivity();
        rb = this.GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 0, 0);
        defaultSpeed = SPEED;
        highSpeed = 2.5f * SPEED;
        //onGround=true;
        //CollisionDetection=Ground.GetComponent<CollisionDetection>();
        transform = this.gameObject.GetComponent<Transform>();
        //VeloTex=VeloObj.GetComponent<Text>();
        this.enabled = false;
        sensitext = sensiobj.GetComponent<Text>();
        animator = this.GetComponent<Animator>();
       // fishcounter=0;
       CounterText = counterTextObj.GetComponent<Text>();
       audioSource = slidingsound.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
        Move();
        Brake();
        sensitext.text = SPEED.ToString();
        if(SPEED == 0)
        {
            SPEED = 3;
        }
    }

    public void Move(){
		    

        ///joystick
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        if(vertical != null || horizon != null)
        {
            if(!jump)
            {
                Force = new Vector3(horizon, vertical, 0) * SPEED;
            }
            else{
                Force = new Vector3(horizon, vertical, 0) * SPEED * 3;
            }
            
            rb.AddForce(Force);
            float angle = Mathf.Atan(vertical / horizon) * Mathf.Rad2Deg;
            
            if(horizon >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f); 
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f); 
            }
             
        
        
        }		

        
	}

    void Brake()
    {
        if(Input.GetKeyDown("joystick button 2")||Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.Return))
        {
            Debug.Log("C");
            jump = true;
            StartCoroutine("Samples");
            
            animator.SetBool("jump",true);
            
            if(audioSource.clip!=null)
            {
                audioSource.Play();
                Debug.Log("A");
            }
            else
            {
                Debug.Log("B");
            }
            

        }
        if(Input.GetKey("joystick button 2"))
        {
            //rb.velocity *= brake;
            //brakesoud.Play();
            
        }
        
        if(Input.GetKeyUp("joystick button 2")||Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<AudioSource>().Stop();
            
        }
    }

    IEnumerator Samples() 
    {
        yield return new WaitForSeconds (0.7f);
        jump = false;
        animator.SetBool("jump",false);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag=="yellow"||other.gameObject.tag=="green"||other.gameObject.tag=="red"||other.gameObject.tag=="mizuiro"||other.gameObject.tag=="pink")
        {
            fishcounter++;
            CounterText.text="×"+fishcounter.ToString();
        }
    }
}
}


