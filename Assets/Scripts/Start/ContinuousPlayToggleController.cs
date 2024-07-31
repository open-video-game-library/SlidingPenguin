using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ContinuousPlayToggleController : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = ParameterManager.continuousPlay;

        // WebGLの場合もしくは、試行回数が0以下（parameter.csvにパラメータが記述されていない）の場合、CSVファイルを使った入力ができないため、トグルを操作できないようにする
        toggle.interactable = Application.platform != RuntimePlatform.WebGLPlayer && ExperimentManager.trialNum > 0;
    }

    public void SetSetting()
    {
        ParameterManager.continuousPlay = toggle.isOn;
    }
}
