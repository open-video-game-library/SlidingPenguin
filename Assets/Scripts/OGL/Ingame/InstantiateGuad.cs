using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class InstantiateGuad : MonoBehaviour
    {
        public GameObject goalObj;
        GoalDetection goalDetection;
        // Start is called before the first frame update
        void Start()
        {
            GetComponent<Collider2D>().enabled=false;
            goalDetection=goalObj.GetComponent<GoalDetection>();
        }

        // Update is called once per frame
        void Update()
        {
            if(goalDetection._fin)
            {
                StartCoroutine("guadactive");
            }
        }

        private IEnumerator guadactive()
        {
            yield return new WaitForSeconds(0.5f);
            GetComponent<Collider2D>().enabled=true;
        }
    }
}
