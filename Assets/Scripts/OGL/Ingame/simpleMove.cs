using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class simpleMove : MonoBehaviour
{
	//public SerialHandler serialHandler;
	public SerialHandler_inapp serialHandler_inapp;
    // 速度
	//public GameObject Ground;
    CollisionDetection CollisionDetection;
    Rigidbody2D rb; 
    [SerializeField]float SPEED;
    float defaultSpeed;
    float fighSpeed;
    float highSpeed;
	public GameObject textobj;
	public Button leftBtn;
	public Button rightBtn;
	public Button okBtn;
	Text testtext;
	bool rightBtnMapping=false;
	bool leftBtnMapping=false;
	public GameObject leftBtnNumTextObj;
	Text _leftBtnNumText;
	public GameObject rightBtnNumTextObj;
	Text _rightBtnNumText;
	public Sprite selectBtnImage;
	public Sprite normalBtnImage;
	Image leftbtnImage;
	Image rightbtnImage;
	bool _adjustMode;
	bool detareceived;
	public string[] detas;
	public string latestInput;
	public string rightBtnNum;
   public string leftBtnNum;
   public static string sendmessage;
    //bool onGround;
	// Use this for initialization
	void Start () {

        //信号を受信したときに、そのメッセージの処理を行う
        //serialHandler.OnDataReceived += OnDataReceived;
		serialHandler_inapp.OnDataReceived += OnDataReceived;

	    rb=this.GetComponent<Rigidbody2D>();
        defaultSpeed=SPEED;
        highSpeed=1.5f*SPEED;
		testtext=textobj.GetComponent<Text>();
		leftBtn.onClick.AddListener(leftBtnClicked);
		rightBtn.onClick.AddListener(rightBtnClicked);
		okBtn.onClick.AddListener(OkBtnClicked);
		_leftBtnNumText=leftBtnNumTextObj.GetComponent<Text>();
		_rightBtnNumText=rightBtnNumTextObj.GetComponent<Text>();
		rightBtnMapping=false;
	    leftBtnMapping=false;
		leftbtnImage=leftBtn.GetComponent<Image>();
		rightbtnImage=rightBtn.GetComponent<Image>();
		_adjustMode=false;
		detareceived=false;
	}
	
	// Update is called once per frame
	void Update () 
	{
		
		// 移動処理
		//Move();
		if(!_adjustMode)
		{
			if(!leftBtnMapping&&!rightBtnMapping)
			{
			leftbtnImage.sprite=normalBtnImage;
			rightbtnImage.sprite=normalBtnImage;
				if(detareceived)
				{
					//Movealpha();
				}
			}
		
		}

		if(!serialHandler_inapp.isNewMessageReceived_)
		{
			//Movealpha("100");
			//rb.velocity=new Vector2(0,0);
		}
		
		
		
	}
     
	
	void Move(string inputdeta)
	{
		
		//Vector2 Position = transform.position;
		
		if(inputdeta==rightBtnNum)
		{
			rb.velocity=new Vector2(1.0f,0)*SPEED;
		}
		else if(inputdeta==leftBtnNum)
		{
			rb.velocity=new Vector2(-1.0f,0)*SPEED;
		}
		else
		{		
			rb.velocity=new Vector2(0,0);
		}
	
		
		
	    
	}
	
	
	void OnDataReceived(string message)
   {
	   
	   detareceived=true;
	   
        //detas = message.Split(new string[]{"\n","\r"}, System.StringSplitOptions.RemoveEmptyEntries);     //

		Debug.Log(message);
		
		for(int i=0;i<detas.Length;i++)
		{
			if(detas[i]==null)
			{				
				detas[i]=detas[i+1];
				
			}
		}

	   if(leftBtnMapping)
		{
			leftBtnMap(message);
		}
		else if(rightBtnMapping)
		{
			rightBtnMap(message);
		}
		
		if(!_adjustMode)
		{
			if(!leftBtnMapping&&!rightBtnMapping)
			{
				Move(message);
			}
		}

   }
   void compareReceiveDeta(string deta)
   {
       if(testtext.text=="0")
	   {
		   Debug.Log("GG1");
	   }
	   else if(deta=="2")
	   {
		   Debug.Log("GG2");
	   }
	   else
	   {
		   Debug.Log("DD");
	   }
   }

   void leftBtnClicked()
   {
	   _adjustMode=true;
       leftBtnMapping=true;
	   rightBtnMapping=false;
	   Debug.Log("leftBtnClicked");
	   leftbtnImage.sprite=selectBtnImage;
		rightbtnImage.sprite=normalBtnImage;
   }
   

   void rightBtnClicked()
   {
	   _adjustMode=true;
       rightBtnMapping=true;
	   leftBtnMapping=false;
	   Debug.Log("rightBtnClicked");
	   rightbtnImage.sprite=selectBtnImage;
	   leftbtnImage.sprite=normalBtnImage;
   }
   

   void leftBtnMap(string message)
   {
	   
		leftBtnNum=message;
		_leftBtnNumText.text=leftBtnNum.ToString();
		leftBtnMapping=false;
		

   }

   void rightBtnMap(string message)
   {
	   /*
	   Debug.Log("rightBtnMap");
	   //Debug.Log("leftBtnMap");
	   if(serialHandler_inapp.isNewMessageReceived_)
		{
			//leftBtnNum=int.Parse(detas[0]);  
			if(detas!=null)
			{
				for(int i=0;i<detas.Length;i++)
				{
					if(detas[i]=="1"||detas[i]=="2")
					{
						rightBtnNum=detas[i];
						_rightBtnNumText.text=rightBtnNum.ToString();
						rightBtnMapping=false;
						return;
					}
				}
				
				
			}
			else
			{
				Debug.Log("else");
			}
			 
		}
		*/

	rightBtnNum=message;
	_rightBtnNumText.text=rightBtnNum.ToString();
	rightBtnMapping=false;



   }

   void OkBtnClicked()
   {
	   _adjustMode=false;
	   leftBtnMapping=false;
	   rightBtnMapping=false;
   }
}


