using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
public class Getdeta_score_scroll : MonoBehaviour
{
    public GameObject mizuiroScoreTextObj;
    Text _mizuiroScoreText;
    public GameObject greenScoreTextObj;
    Text _greenScoreText;
    public GameObject redScoreTextObj;
    Text _redScoreText;
    public GameObject pinkScoreTextObj;
    Text _pinkScoreText;
    public GameObject yellowScoreTextObj;
    Text _yellowScoreText;
    public GameObject ScoreCanvas;
    public GameObject GameOverCanvas;
    bool gamefin;
    // Start is called before the first frame update
    void Start()
    {
        int resultmizuiropoint = GoalDetection_scroll.getmizuiroPoint();
        int resulgreenpoint = GoalDetection_scroll.greenPoint();
        int resulredpoint = GoalDetection_scroll.redPoint();
        int resulpinkpoint = GoalDetection_scroll.pinkPoint();
        int resultyellowpoint = GoalDetection_scroll.yellowPoint();
        float resultime = GoalDetection_scroll.timePoint();
        gamefin=GoalDetection_scroll.gameclear();

        _mizuiroScoreText=mizuiroScoreTextObj.GetComponent<Text>();
        _mizuiroScoreText.text="× "+resultmizuiropoint.ToString();

        _greenScoreText=greenScoreTextObj.GetComponent<Text>();
        _greenScoreText.text="× "+resulgreenpoint.ToString();

        _redScoreText=redScoreTextObj.GetComponent<Text>();
        _redScoreText.text="× "+resulredpoint.ToString();

        _pinkScoreText=pinkScoreTextObj.GetComponent<Text>();
        _pinkScoreText.text="× "+resulpinkpoint.ToString();

        _yellowScoreText=yellowScoreTextObj.GetComponent<Text>();
        _yellowScoreText.text="× "+resultyellowpoint.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(gamefin)
        {
           ScoreCanvas.SetActive(true);
           GameOverCanvas.SetActive(false);
        }else
        {
           ScoreCanvas.SetActive(false);
           GameOverCanvas.SetActive(true);
        }
    }
}
}
