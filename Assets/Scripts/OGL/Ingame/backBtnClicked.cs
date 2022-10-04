using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
public class backBtnClicked : MonoBehaviour
{
    public GameObject startCanvas;
    public GameObject adjustCanvas;
    public Button button;

    public GameObject sliderObj;
    Slider sensitivitySlider;
    public GameObject sensitivityTextObj;
    Text _sensitivityText;


    public GameObject timelimitsliderObj;
    Slider timelimitSlider;
    public GameObject timelimitTextObj;
    Text _timelimitText;
    // Start is called before the first frame update
    void Start()
    {
        button.onClick.AddListener(BackBtnClick);
        adjustCanvas.SetActive(false);
        sensitivitySlider = sliderObj.GetComponent<Slider>();
        _sensitivityText=sensitivityTextObj.GetComponent<Text>();
        timelimitSlider = timelimitsliderObj.GetComponent<Slider>();
        _timelimitText=timelimitTextObj.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        //sensitivity=sensitivitySlider.value*6;
        _sensitivityText.text=(sensitivitySlider.value*6).ToString("f2");
        _timelimitText.text=(timelimitSlider.value).ToString();
    }


    void BackBtnClick()
    {
        
        startCanvas.SetActive(true);
        adjustCanvas.SetActive(false);
    }
    
}
}