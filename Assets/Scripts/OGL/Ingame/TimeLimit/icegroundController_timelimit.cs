using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class icegroundController_timelimit : MonoBehaviour
    {
        Vector3 groundTransform;
        [SerializeField]float CamSpeed;
        float fullTime;
        public GameObject gameManagerObj;
        GameManager_TimeLimit gamemanager;
        public GameObject penguin;
        [SerializeField]float MaxScrollParameter;
        // Start is called before the first frame update
        void Start()
        {
            gamemanager=gameManagerObj.GetComponent<GameManager_TimeLimit>();
        }

        // Update is called once per frame
        void Update()
        {
            if(gamemanager.gameStart)
            {
                fullTime+=Time.deltaTime;
                //Debug.Log(Mathf.Lerp(0,5,fullTime/30));
            }
            
            Move();
        }
        public void Move()
        {
            //scroll
            float _x=penguin.GetComponent<Transform>().position.x;
            this.gameObject.transform.position += new Vector3(0, Time.deltaTime*Mathf.Lerp(0,MaxScrollParameter,fullTime/30),0);
            this.gameObject.transform.position=new Vector3(_x,this.gameObject.transform.position.y,this.gameObject.transform.position.z);
            //penguin center
           
            
        
        }
    }

}
