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
    //float defaultSpeed;
    float fighSpeed;
    //float highSpeed;
    Transform transform;
    //public GameObject VeloObj;
    Text VeloTex;
    public GameObject sensiobj;
    //[SerializeField]float brake=0.99f;
    Text sensitext;
    //public AudioSource brakesoud;
    //public AudioClip audioClip1;
    //Animator animator;
    private bool acceleration;
    Vector3 Force;
    [SerializeField] private Text fishNumberText;
    private float _speed;

    [SerializeField] private AudioSource acquiredSound;
    [SerializeField] private AudioSource accelerationSound;
    [SerializeField] private Animator penguinMoveAnimator;
    // Start is called before the first frame update
    void Start()
    {
        SPEED = HomeSceneTransitionManager.getSensitivity();
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector3(0, 0, 0);
        transform = gameObject.GetComponent<Transform>();
        enabled = false;
        sensitext = sensiobj.GetComponent<Text>();
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

    public void Move()
    {
        float horizon = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        
        // 移動入力があった際の処理
        if (vertical != 0 || horizon != 0)
        {
            // play animation
            penguinMoveAnimator.SetBool("IsMoving", true);
            
            // プレイヤーオブジェクトに力を加える
            if (!acceleration)
            {
                Force = new Vector3(horizon, vertical, 0) * SPEED;
            }
            else
            {
                Force = new Vector3(horizon, vertical, 0) * SPEED * 3;
            }
            rb.AddForce(Force);
            
            
            // プレイヤーオブジェクトが向く方向を更新する
            float angle = Mathf.Atan(vertical / horizon) * Mathf.Rad2Deg;
            Debug.Log(angle);
            if (horizon >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);

                if (Mathf.Abs(angle - 90.0f) > 0.1)
                {
                    //transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
                }
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f);

                if (Mathf.Abs(angle - 90.0f) > 0.1)
                {
                    //transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f);
                }
            }

            return;
        }

        penguinMoveAnimator.SetBool("IsMoving", false);

    }

    private void Brake()
    {
        if(Input.GetKeyDown("joystick button 2")||Input.GetKey(KeyCode.Space)||Input.GetKey(KeyCode.Return))
        {

            acceleration = true;
            StartCoroutine("PlayAccelerationAnimation");
            
            accelerationSound.Play();
        }
      
        if(Input.GetKeyUp("joystick button 2")||Input.GetKey(KeyCode.Space))
        {
            this.GetComponent<AudioSource>().Stop();
        }
    }

    private IEnumerator PlayAccelerationAnimation() 
    {
        penguinMoveAnimator.SetBool("IsAcceleration", true);
        yield return new WaitForSeconds (0.7f);
        acceleration = false;
        penguinMoveAnimator.SetBool("IsAcceleration", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag== "Fish")
        {
            fishcounter ++;
            fishNumberText.text = "×" + fishcounter;
            acquiredSound.Play();
        }
    }
    
}
}


