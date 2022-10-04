using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class icegroundController : MonoBehaviour
    {
        Vector3 groundTransform;
        [SerializeField]float CamSpeed;
        float fullTime;
        public GameObject gameManagerObj;
        GameManager gamemanager;
        public GameObject penguin;
        [SerializeField]float MaxScrollParameter;
        // Start is called before the first frame update
        void Start()
        {
            gamemanager=gameManagerObj.GetComponent<GameManager>();
        }

        // Update is called once per frame
        void Update()
        {
            if(gamemanager.gameStart)
            {
                fullTime+=Time.deltaTime;
                Move();
            }
            
            
        }
        public void Move()
        {
            this.gameObject.transform.position += new Vector3(0, Time.deltaTime*Mathf.Lerp(0,MaxScrollParameter,fullTime + 5 / 30),0);
        }
    }

}
