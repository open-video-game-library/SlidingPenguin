using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FishToggleController : MonoBehaviour
{
    private Toggle toggle;

    // Start is called before the first frame update
    void Start()
    {
        toggle = GetComponent<Toggle>();
        toggle.isOn = ParameterManager.fish;
    }

    public void SetSetting()
    {
        ParameterManager.fish = toggle.isOn;
    }
}
