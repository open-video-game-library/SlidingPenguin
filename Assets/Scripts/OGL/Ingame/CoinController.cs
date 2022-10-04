using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinController : MonoBehaviour
{
    public GameObject mizuiroCoin;
    public GameObject yellowCoin;
    public GameObject redCoin;
    public GameObject greenCoin;
    public GameObject pinkCoin;
    public static int mizuirocount=0;
    public static int yellowcount=0;
    public static int redcount=0;
    public static int greencount=0;
    public static int pinkcount=0;
    public GameObject mizuiroTextObj;
    Text mizuiroText;
    public GameObject blue1;
    public GameObject blue2;
    public GameObject blue3;
    public GameObject fishUI;
    AudioSource audio_yeah;
    //public GameObject yellowTextObj;
    //Text yellowText;
    //public GameObject redTextObj;
    //Text redText;
   // public GameObject greenTextObj;
    //Text greenText;
   //4 public GameObject pinkTextObj;
    //Text pinkText;

    // Start is called before the first frame update
    void Start()
    {
        mizuiroText=mizuiroTextObj.GetComponent<Text>();
        mizuiroText.text="";
        /*
        yellowText=yellowTextObj.GetComponent<Text>();
        redText=redTextObj.GetComponent<Text>();
        greenText=greenTextObj.GetComponent<Text>();
        pinkText=pinkTextObj.GetComponent<Text>();
        */
        mizuirocount=0;
        yellowcount=0;
        redcount=0;
        greencount=0;
        pinkcount=0;

        audio_yeah=fishUI.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void getmizuirocoin()
    {
        mizuirocount++;
        mizuiroText.text=mizuirocount+"/3";
        mizuiroText.color=new Color32(41,174,255,255);
        if(mizuirocount==1)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(mizuirocount==2)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(mizuirocount==3)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/blue_fish");       
           StartCoroutine("TextInactive");
        }

    }
    public void getgreencoin()
    {
        greencount++;
        mizuiroText.text=greencount+"/3";
        mizuiroText.color=new Color32(0,229,53,255);
        
        if(greencount==1)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(greencount==2)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(greencount==3)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/green_fish");       
           StartCoroutine("TextInactive");
        }
        
    }
    public void getredcoin()
    {
        redcount++;
        mizuiroText.text=redcount+"/3";
        mizuiroText.color=new Color32(255,5,77,255);
        if(redcount==1)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(redcount==2)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(redcount==3)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/red_fish");       
           StartCoroutine("TextInactive");
        }
    }
    public void getyellowcoin()
    {
        yellowcount++;
        mizuiroText.text=yellowcount+"/3";
        mizuiroText.color=new Color32(255,236,38,255);
        if(yellowcount==1)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(yellowcount==2)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(yellowcount==3)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/yellow_fish");       
           StartCoroutine("TextInactive");
        }
    }
    public void getpinkcoin()
    {
        pinkcount++;
        mizuiroText.text=pinkcount+"/3";
        mizuiroText.color=new Color32(255,119,168,255);
        if(pinkcount==1)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(pinkcount==2)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/fish_collect");
        }
        if(pinkcount==3)
        {
           blue1.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           blue2.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");
           blue3.GetComponent<RawImage>().texture = Resources.Load<Texture>("Sprite/pinkfish02");       
           StartCoroutine("TextInactive");
        }
    }


    public IEnumerator TextInactive()
    {
        yield return new WaitForSeconds (0.3f);
        audio_yeah.Play();
        yield return new WaitForSeconds (3.0f);
        //mizuiroText.text="";
        /*
        mizuiroTextObj.SetActive(false);
        yellowTextObj.SetActive(false);
        redTextObj.SetActive(false);
        greenTextObj.SetActive(false);
        pinkTextObj.SetActive(false);
        */
    }
}
