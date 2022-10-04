using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;              /////追加

namespace Test
{
    public class ParameterAdjust : MonoBehaviour
    {
        public GameObject sliderObj;             /////スライダオブジェクト
        Slider sensitivitySlider;                
        public static float sensitivity;        //////スライダで調整する数値
        public GameObject parameterTextObj;     ////スライダUIの下に表示させるパラメーター
        Text parameterText;
        // Start is called before the first frame update
        void Start()
        {
            sensitivitySlider = sliderObj.GetComponent<Slider>();
            parameterText=parameterTextObj.GetComponent<Text>();
        }

        // Update is called once per frame
        void Update()
        {
            sensitivity=sensitivitySlider.value;
            parameterText.text=sensitivity.ToString("f2");
            //getSensitivity();
        }

        public static float getSensitivity() {         ///別スクリプトから呼び出す関数。関数名は任意。
            
            return sensitivity;                        ////調整した変数を戻り値にする。
        }
    }
}

