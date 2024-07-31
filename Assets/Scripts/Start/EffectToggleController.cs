using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EffectToggleController : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = ParameterManager.gameAnimation;
    }

    public void SetSetting()
    {
        ParameterManager.gameAnimation = toggle.isOn;
    }
}
