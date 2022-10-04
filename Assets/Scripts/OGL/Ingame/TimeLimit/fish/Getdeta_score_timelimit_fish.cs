
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
public class Getdeta_score_timelimit_fish : MonoBehaviour
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
        int resultmizuiropoint = GoalDetection_timelimit_fish.getmizuiroPoint();
        int resulgreenpoint = GoalDetection_timelimit_fish.greenPoint();
        int resulredpoint = GoalDetection_timelimit_fish.redPoint();
        int resulpinkpoint = GoalDetection_timelimit_fish.pinkPoint();
        int resultyellowpoint = GoalDetection_timelimit_fish.yellowPoint();
        float resultime = GoalDetection_timelimit_fish.timePoint();
        gamefin=GoalDetection_timelimit_fish.gameclear();

        _mizuiroScoreText=mizuiroScoreTextObj.GetComponent<Text>();
        _mizuiroScoreText.text=(resultmizuiropoint/7).ToString();

        _greenScoreText=greenScoreTextObj.GetComponent<Text>();
        _greenScoreText.text=(resulgreenpoint/7).ToString();

        _redScoreText=redScoreTextObj.GetComponent<Text>();
        _redScoreText.text=(resulredpoint/7).ToString();

        _pinkScoreText=pinkScoreTextObj.GetComponent<Text>();
        _pinkScoreText.text=(resulpinkpoint/7).ToString();

        _yellowScoreText=yellowScoreTextObj.GetComponent<Text>();
        _yellowScoreText.text=(resultyellowpoint/7).ToString();

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
