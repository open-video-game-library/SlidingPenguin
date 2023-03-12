using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;
using UnityEngine.UI;

namespace penguin
{
    public class SliderManager : MonoBehaviour
    {
        /// <summary>
        /// GUI上で調整可能なパラメータ。
        /// パラメータを追加する場合、ParameterManagerにpublicな変数を追加してください。
        /// </summary>
        
        // パラメータを調整するスライダー。調整可能パラメータを増やす場合sliderも追加し、参照する。
        [SerializeField] private Slider sensitivity;
        [SerializeField] private Slider limitedTime;
        
        // スライダーによって調整したパラメータの値を表示するテキスト
        [SerializeField] private Text sensitivityValueText;
        [SerializeField] private Text limitedTimeValueText;

        // SE再生・停止クラス
        [SerializeField] private StartSceneAudio audio;
        
        
        // Start is called before the first frame update
        private void Start()
        {
            InitializeValue();
            
            sensitivity.onValueChanged.AddListener(SetSensitivityValue);
            limitedTime.onValueChanged.AddListener(SetLimitedTimeValue);

        }
        
        // ParameterManagerに記載されている初期値に各パラメータをセット。
        // 逆に、初期値を変えたい場合ParameterManagerを変える。
        private void InitializeValue()
        {
            sensitivity.value = (float)ParameterManager.sensitivity / 6.0f;
            sensitivityValueText.text = ParameterManager.sensitivity.ToString("f2");
            limitedTime.value = ParameterManager.limitedTime;
            limitedTimeValueText.text = ParameterManager.limitedTime.ToString();
        }

        
        // InGameではParameterManagerのパラメータを参照するため、スライダーで調整した結果は、ParameterManagerにセットする。
        private void SetSensitivityValue(float value)
        {
            ParameterManager.sensitivity = value * 6;
            sensitivityValueText.text = (value * 6).ToString("f2");
            audio.SliderValueChange.Play();
        }
        
        // InGameではParameterManagerのパラメータを参照するため、スライダーで調整した結果は、ParameterManagerにセットする。
        private void SetLimitedTimeValue(float value)
        {
            ParameterManager.limitedTime = (int)value;
            limitedTimeValueText.text = value.ToString();
            audio.SliderValueChange.Play();
        }
        
    }

}
