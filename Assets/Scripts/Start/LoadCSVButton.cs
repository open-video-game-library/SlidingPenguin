using UnityEngine;
using UnityEngine.UI;

public class LoadCSVButton : MonoBehaviour
{
    [SerializeField]
    private ParameterReader parameterReader;

    private Button readCSVButton;

    // Start is called before the first frame update
    void Start()
    {
        readCSVButton = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        // parameter.csvに記述されたパラメータをもとに連続で試行を行う場合かつ、試行回数が0以下（parameter.csvにパラメータが記述されていない）の場合
        readCSVButton.interactable = !ParameterManager.continuousPlay && ExperimentManager.trialNum > 0;
    }

    public void OnClickButton()
    {
        parameterReader.SetParameters(1);
    }
}
