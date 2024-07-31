using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EditDetailParametersToggleController : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = !ParameterManager.usePhysics;
    }

    public void SetSetting()
    {
        ParameterManager.usePhysics = !toggle.isOn;
    }
}
