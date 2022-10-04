using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Test
{
    public class ParameterReceive : MonoBehaviour
    {
        float penguin_sensitivity;
        public GameObject aa;
        Text tt;
        // Start is called before the first frame update
        void Start()
        {
            penguin_sensitivity=ParameterAdjust.getSensitivity();
            tt=aa.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            
            tt.text=penguin_sensitivity.ToString("f2");
        }
    }
}
