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
        
        [SerializeField] private Slider sensitivity;
        [SerializeField] private Slider limitedTime;
        
        [SerializeField] private Text sensitivityValueText;
        [SerializeField] private Text limitedTimeValueText;

        [SerializeField] private StartSceneAudio audio;
        
        // Start is called before the first frame update
        private void Start()
        {
            sensitivity.onValueChanged.AddListener(SetSensitivityValue);
            limitedTime.onValueChanged.AddListener(SetLimitedTimeValue);

            InitializeValue();
        }

        private void SetSensitivityValue(float value)
        {
            ParameterManager.sensitivity = value * 6;
            sensitivityValueText.text = (value * 6).ToString("f2");
            audio.SliderValueChange.Play();
        }
        
        private void SetLimitedTimeValue(float value)
        {
            ParameterManager.limitedTime = (int)value;
            limitedTimeValueText.text = value.ToString();
            audio.SliderValueChange.Play();
        }

        private void InitializeValue()
        {
            sensitivity.value = ParameterManager.sensitivity;
            limitedTime.value = ParameterManager.limitedTime;
        }
    }

}
