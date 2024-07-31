using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System.IO;
using TMPro;

public class ParameterReader : MonoBehaviour
{
    // CSVの中身を入れるリスト
    public static List<string[]> parameterDatas = new List<string[]>(); 

    [SerializeField] private TMP_InputField sensitivity;
    [SerializeField] private TMP_InputField limitedTime;
    [SerializeField] private TMP_InputField maximumSpeed;
    [SerializeField] private TMP_InputField acceleration;
    [SerializeField] private TMP_InputField friction;

    void Start()
    {
        if (Application.platform == RuntimePlatform.WebGLPlayer) { return; }

        parameterDatas.Clear();
        StreamReader reader = new StreamReader(Application.dataPath + "/Parameter/parameter.csv", Encoding.GetEncoding("UTF-8"));
        string line;

        while ((line = reader.ReadLine()) != null)
        {
            string[] splitLine = line.Split(",");
            parameterDatas.Add(splitLine);
        }
        ExperimentManager.trialNum = parameterDatas.Count - 1;
    }

    public void SetParameters(int trialCount)
    {
        // ParameterManager で定義されているパラメータに、CSVファイルで設定したパラメータを上書きする
        SetSensitivityValue(parameterDatas[trialCount][0]);
        SetLimitedTimeValue(parameterDatas[trialCount][1]);
        SetMaximumSpeedValue(parameterDatas[trialCount][2]);
        SetAccelerationValue(parameterDatas[trialCount][3]);
        SetFrictionValue(parameterDatas[trialCount][4]);
        SetWaitTimeNextValue(parameterDatas[trialCount][5]);
    }

    private void SetSensitivityValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f) { return; }
        sensitivity.text = value;
        ParameterManager.sensitivity = floatValue;
    }

    private void SetLimitedTimeValue(string value)
    {
        if (!int.TryParse(value, out int intValue) || intValue < 0) { return; }
        limitedTime.text = value;
        ParameterManager.limitedTime = intValue;
    }

    private void SetMaximumSpeedValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue < ParameterManager.acceleration) { return; }
        maximumSpeed.text = value;
        ParameterManager.maximumSpeed = floatValue;
    }

    private void SetAccelerationValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue > ParameterManager.maximumSpeed) { return; }
        acceleration.text = value;
        ParameterManager.acceleration = floatValue;
    }

    private void SetFrictionValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue > 1.0f) { return; }
        friction.text = value;
        ParameterManager.friction = floatValue;
    }

    private void SetWaitTimeNextValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f) { return; }
        ParameterManager.waitTimeNext = floatValue;
    }
}
