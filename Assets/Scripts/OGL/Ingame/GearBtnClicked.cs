using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GearBtnClicked : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject adjustCanvas;
    public Button button;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(GearBtnClick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void GearBtnClick()
    {
        startCanvas.SetActive(false);
        adjustCanvas.SetActive(true);
    }
}
