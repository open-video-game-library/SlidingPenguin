using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Fitts
{

    public class Ontrigger : MonoBehaviour
    {
        
        public GameObject finallyTimeText;
        Text _finallyTimeText;
        GameObject _manager;
        FittsManager fittsmanager;


        void Start()
        {
            _manager = GameObject.Find("Manager");
            fittsmanager = _manager.GetComponent<FittsManager>();
            _finallyTimeText = finallyTimeText.GetComponent<Text>();
        }

        /*
        void OnCollisionStay2D(Collision2D collision)
        {
            Debug.Log("touched");

            if (collision.gameObject.tag == "Player")
            {
                Debug.Log("touched");
                fittsmanager._testPlaying = false;
                Cursor.visible = true;
                manager.GetComponent<FittsManager>().TestFinished();
            }
        }
       */
        void OnTriggerEnter2D(Collider2D collider)
        {
            Debug.Log("d");
            if (collider.gameObject.tag == "Player")
            {
                float _time = fittsmanager._totalTime;
                fittsmanager._testPlaying = false;
                Cursor.visible = true;
                Debug.Log("Time is "+_time);
                fittsmanager.TestFinished();
                //_finallyTimeText.text = fittsmanager._totalTime.ToString();
            }
        }
    }
}
