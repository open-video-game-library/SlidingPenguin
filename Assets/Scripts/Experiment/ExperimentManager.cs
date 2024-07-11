using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ExperimentManager : MonoBehaviour
{
    public static int trialCount = 1;
    public static bool finish = false;
    public static int trialNum = 0;
    public static bool countDown;

    private float waitTime;

    [SerializeField]
    private Button homeButton;
    [SerializeField]
    private Button retryButton;
    [SerializeField]
    private Button downloadButton;
    [SerializeField]
    private GameObject dataSaveMessage;

    [SerializeField]
    private GameObject informationPanel;
    [SerializeField]
    private TMP_Text informationMessage;

    // Start is called before the first frame update
    void Start()
    {
        finish = trialCount == trialNum;

        homeButton.interactable = !ParameterManager.continuousPlay || finish;
        retryButton.interactable = !ParameterManager.continuousPlay;
        downloadButton.interactable = Application.platform == RuntimePlatform.WebGLPlayer;
        dataSaveMessage.SetActive(!downloadButton.interactable);

        informationPanel.SetActive(ParameterManager.continuousPlay);

        if (ParameterManager.continuousPlay && !finish) { StartCoroutine(AutoRetry()); }
        else if (ParameterManager.continuousPlay && finish) { informationMessage.text = "The experiment is finished. Thank you for your hard work."; }
    }

    private IEnumerator AutoRetry()
    {
        informationMessage.text = "";
        yield return new WaitUntil(() => countDown);

        waitTime = ParameterManager.waitTimeNext;
        while (waitTime > 0)
        {
            if (waitTime > 1.0f) { informationMessage.text = "After " + waitTime.ToString() + " seconds, the next trial starts automatically."; }
            else { informationMessage.text = "After " + waitTime.ToString() + " second, the next trial starts automatically."; }
            yield return new WaitForSeconds(1.0f);
            waitTime -= 1.0f;
        }

        // カウントダウンが終わったら実行する処理
        countDown = false;
        trialCount++;
        SetNextParameters(trialCount);
        GameDataExport.CreateTrailCSV();
        SceneManager.LoadScene("InGame");
    }

    private void SetNextParameters(int trialCount)
    {
        // ParameterManager で定義されているパラメータに、CSVファイルで設定したパラメータを上書きする
        SetSensitivityValue(ParameterReader.parameterDatas[trialCount][0]);
        SetLimitedTimeValue(ParameterReader.parameterDatas[trialCount][1]);
        SetMaximumSpeedValue(ParameterReader.parameterDatas[trialCount][2]);
        SetAccelerationValue(ParameterReader.parameterDatas[trialCount][3]);
        SetFrictionValue(ParameterReader.parameterDatas[trialCount][4]);
        SetWaitTimeNextValue(ParameterReader.parameterDatas[trialCount][5]);
    }

    private void SetSensitivityValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f) { return; }
        ParameterManager.sensitivity = floatValue;
    }

    private void SetLimitedTimeValue(string value)
    {
        if (!int.TryParse(value, out int intValue) || intValue < 0) { return; }
        ParameterManager.limitedTime = intValue;
    }

    private void SetMaximumSpeedValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue < ParameterManager.acceleration) { return; }
        ParameterManager.maximumSpeed = floatValue;
    }

    private void SetAccelerationValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue > ParameterManager.maximumSpeed) { return; }
        ParameterManager.acceleration = floatValue;
    }

    private void SetFrictionValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f || floatValue > 1.0f) { return; }
        ParameterManager.friction = floatValue;
    }

    private void SetWaitTimeNextValue(string value)
    {
        if (!float.TryParse(value, out float floatValue) || floatValue < 0.0f) { return; }
        ParameterManager.waitTimeNext = floatValue;
    }
}
