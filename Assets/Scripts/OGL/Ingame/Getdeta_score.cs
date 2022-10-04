using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace penguin
{
public class Getdeta_score : MonoBehaviour
{
    public GameObject timeTextObj;
    Text _timeText;
    public GameObject ScoreCanvas;
    public GameObject GameOverCanvas;
    bool gamefin;
    public GameObject percentageTextObj;
    public GameObject aniUI;
    Text _percentageText;
    public GameObject blue;
    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;
    public GameObject green1;
    public GameObject green2;
    public GameObject green3;
    public GameObject red1;
    public GameObject red2;
    public GameObject red3;
    public GameObject pink1;
    public GameObject pink2;
    public GameObject pink3;
    public GameObject yellow1;
    public GameObject yellow2;
    public GameObject yellow3;

    private Image bluefish1;
    private Image bluefish2;
    private Image bluefish3;

    int bluefishNum;
    int greenfishNum;
    int redfishNum;
    int pinkfishNum;
    int yellowfishNum;
    public Sprite BlueFishImg;
    public GameObject restartBtn;
    public GameObject homeBtn;
    public GameObject resultTextObj;
    Text resultText;
    Animator anim;
    AudioSource audio;

    bool once=true;
    // Start is called before the first frame update
    void Start()
    {
        //sprite = Resources.Load<Sprite>("Sprite/blue_fish");
        //image = blue1.GetComponent<Image>();
        //image.sprite = sprite;
        //Image a=blue.GetComponent<Image>();
        //a.sprite=BlueFishImg;
        resultText=resultTextObj.GetComponent<Text>();
        anim=aniUI.GetComponent<Animator>();
        audio=this.GetComponent<AudioSource>();
        float resultsecond = GoalDetection.SecondPoint();
        float resultminute = GoalDetection.MinutePoint();
        

        float resultms = GoalDetection.MsPoint();
        gamefin=GoalDetection.gameclear();
        int processPercent=Kilyori.kyoriPoint();
        _timeText=timeTextObj.GetComponent<Text>();
        _timeText.text="Time : "+resultminute.ToString("00") + ":" + (resultsecond).ToString ("00")+"."+resultms.ToString("00");
        _percentageText=percentageTextObj.GetComponent<Text>();
        _percentageText.text=processPercent.ToString()+" %";
    }

    // Update is called once per frame
    void Update()
    {
        if(gamefin)
        {
            resultText.text="Clear";
           ScoreCanvas.SetActive(true);
           GameOverCanvas.SetActive(false);
           if(once)
           {
               bluefishNum=GoalDetection.getmizuiroPoint();
                greenfishNum=GoalDetection.greenPoint();
                redfishNum=GoalDetection.redPoint();
                pinkfishNum=GoalDetection.pinkPoint();
                yellowfishNum=GoalDetection.yellowPoint();
               StartCoroutine ("CalculateFishNum");
               once=false;
           }
           
        }else
        {
            resultText.text="Game over";
           //ScoreCanvas.SetActive(false);
           //GameOverCanvas.SetActive(true);
           if(once)
           {
               bluefishNum=StageDetection.getmizuiroPoint();
                greenfishNum=StageDetection.greenPoint();
                redfishNum=StageDetection.redPoint();
                pinkfishNum=StageDetection.pinkPoint();
                yellowfishNum=StageDetection.yellowPoint();
               StartCoroutine ("CalculateFishNum");
               once=false;
           }
          
        }
    }

    private IEnumerator CalculateFishNum()
    {
        
         yield return new WaitForSeconds (1.0f);

        if(bluefishNum==1)
        {
            audio.Play();
            blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");

        }
        else if(bluefishNum==2)
        {
            audio.Play();
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           yield return new WaitForSeconds (0.5f);
           audio.Play();
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           
        }
        else if (bluefishNum==3)
        {
            audio.Play();
            blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
        }
        if(greenfishNum!=0)
        {
            yield return new WaitForSeconds (1.0f);
        }
        

        if(greenfishNum==1)
        {
            audio.Play();
            green1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");

        }
        else if(greenfishNum==2)
        {
            audio.Play();
           green1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           yield return new WaitForSeconds (0.5f);
           audio.Play();
           green2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           
        }
        else if (greenfishNum==3)
        {
            audio.Play();
            green1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            green2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            green3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
        }
        if(redfishNum!=0)
        {
            yield return new WaitForSeconds (1.0f);
        }
        

        if(redfishNum==1)
        {
            audio.Play();
            red1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");

        }
        else if(redfishNum==2)
        {
            audio.Play();
           red1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           yield return new WaitForSeconds (0.5f);
           audio.Play();
           red2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           
        }
        else if (redfishNum==3)
        {
            audio.Play();
            red1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            red2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            red3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
        }
        if(pinkfishNum!=0)
        {
            yield return new WaitForSeconds (1.0f);

        }
        
        if(pinkfishNum==1)
        {
            audio.Play();
            pink1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");

        }
        else if(pinkfishNum==2)
        {
            audio.Play();
           pink1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           yield return new WaitForSeconds (0.5f);
           audio.Play();
           pink2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           
        }
        else if (pinkfishNum==3)
        {
            audio.Play();
            pink1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            pink2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            pink3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
        }
        if(yellowfishNum!=0)
        {
            yield return new WaitForSeconds (1.0f);
        }
        

        if(yellowfishNum==1)
        {
            audio.Play();
            yellow1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");

        }
        else if(yellowfishNum==2)
        {
            audio.Play();
           yellow1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           yield return new WaitForSeconds (0.5f);
           audio.Play();
           yellow2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           
        }
        else if (yellowfishNum==3)
        {
            audio.Play();
            yellow1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            yellow2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
            yield return new WaitForSeconds (0.5f);
            audio.Play();
            yellow3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
        }

        yield return new WaitForSeconds (1.0f);

        restartBtn.SetActive(true);
        homeBtn.SetActive(true);
        if(gamefin)
        {
            anim.SetBool("PlayUIAni", true);
        }
        else
        {
            //失敗時のエフェクト
        }

    }
}
}