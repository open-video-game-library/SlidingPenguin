using UnityEngine;
using TMPro;

public class InputFieldManager : MonoBehaviour
{
    // パラメータを調整するInputField。調整可能パラメータを増やす場合InputFieldも追加し、参照する。
    [SerializeField] private TMP_InputField sensitivity;
    [SerializeField] private TMP_InputField limitedTime;
    [SerializeField] private TMP_InputField maximumSpeed;
    [SerializeField] private TMP_InputField acceleration;
    [SerializeField] private TMP_InputField friction;

    // Start is called before the first frame update
    void Start()
    {
        sensitivity.text = ParameterManager.sensitivity.ToString("f2");
        limitedTime.text = ParameterManager.limitedTime.ToString();
        maximumSpeed.text = ParameterManager.maximumSpeed.ToString("f2");
        acceleration.text = ParameterManager.acceleration.ToString("f2");
        friction.text = ParameterManager.friction.ToString("f2");
    }

    void Update()
    {
        if (ParameterManager.continuousPlay)
        {
            sensitivity.interactable = false;
            limitedTime.interactable = false;
            maximumSpeed.interactable = false;
            acceleration.interactable = false;
            friction.interactable = false;
        }
        else
        {
            limitedTime.interactable = true;

            if (ParameterManager.usePhysics)
            {
                sensitivity.interactable = true;
                maximumSpeed.interactable = false;
                acceleration.interactable = false;
                friction.interactable = false;
            }
            else
            {
                sensitivity.interactable = false;
                maximumSpeed.interactable = true;
                acceleration.interactable = true;
                friction.interactable = true;
            }
        }
    }

    public void SetSensitivityValue()
    {
        if (!float.TryParse(sensitivity.text, out float floatValue)
            || floatValue < 0.0f)
        {
            sensitivity.text = ParameterManager.sensitivity.ToString("f2");
            return;
        }
        ParameterManager.sensitivity = floatValue;
    }

    public void SetLimitedTimeValue()
    {
        if (!int.TryParse(limitedTime.text, out int intValue)
            || intValue < 0)
        {
            limitedTime.text = ParameterManager.limitedTime.ToString();
            return;
        }
        ParameterManager.limitedTime = intValue;
    }

    public void SetMaximumSpeedValue()
    {
        if (!float.TryParse(maximumSpeed.text, out float floatValue)
            || floatValue < 0.0f
            || floatValue < ParameterManager.acceleration)
        {
            maximumSpeed.text = ParameterManager.maximumSpeed.ToString("f2");
            return;
        }
        ParameterManager.maximumSpeed = floatValue;
    }

    public void SetAccelerationValue()
    {
        if (!float.TryParse(acceleration.text, out float floatValue)
            || floatValue < 0.0f
            || floatValue > ParameterManager.maximumSpeed)
        {
            acceleration.text = ParameterManager.acceleration.ToString("f2");
            return;
        }
        ParameterManager.acceleration = floatValue;
    }

    public void SetFrictionValue()
    {
        if (!float.TryParse(friction.text, out float floatValue)
            || floatValue < 0.0f
            || floatValue > 1.0f)
        {
            friction.text = ParameterManager.friction.ToString("f2");
            return;
        }
        ParameterManager.friction = floatValue;
    }
}
