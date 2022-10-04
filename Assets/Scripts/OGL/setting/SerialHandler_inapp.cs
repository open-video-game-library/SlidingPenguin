using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Collections;
using System.IO.Ports;
using System.Threading;

public class SerialHandler_inapp : MonoBehaviour
{
    public delegate void SerialDataReceivedEventHandler(string message);
    public event SerialDataReceivedEventHandler OnDataReceived;


    //ポート名
    //例
    //Linuxでは/dev/ttyUSB0
    //windowsではCOM1
    //Macでは/dev/tty.usbmodem1421など
    public string portName = "/dev/cu.usbmodem1401";
    public int baudRate    = 9600;
    public SerialPort serialPort_;
    private Thread thread_;
    private bool isRunning_ = false;

    public string message_;
    public bool isNewMessageReceived_ = false;
    public GameObject comInfoBtnObj;
    Button comInfoBtn;
    public GameObject portNameTextObj;
    Text portNameText;
    public GameObject baudRateTextObj;
    Text baudRateText;
    public GameObject infoInputCanvas;
    public GameObject inputAssignCanvas;

    void Awake()
    {
        //Open();
    }
    void Start()
    {
        comInfoBtn=comInfoBtnObj.GetComponent<Button>();
        comInfoBtn.onClick.AddListener(comInfoFulFill);
        portNameText=portNameTextObj.GetComponent<Text>();
        baudRateText=baudRateTextObj.GetComponent<Text>();
    }

    void Update()
    {
        if (isNewMessageReceived_) {
            OnDataReceived(message_);
        }
        isNewMessageReceived_ = false;
       
       
    }

    void OnDestroy()
    {
        Close();
    }

    private void Open()
    {
        
        //serialPort_ = new SerialPort(portName, baudRate, Parity.None, 8, StopBits.One);
         //または
         serialPort_ = new SerialPort(portName, baudRate);
        serialPort_.Open();

        isRunning_ = true;

        thread_ = new Thread(Read);
        thread_.Start();
    }

    private void Close()
    {
        isNewMessageReceived_ = false;
        isRunning_ = false;

        if (thread_ != null && thread_.IsAlive) {
            thread_.Join();
        }

        if (serialPort_ != null && serialPort_.IsOpen) {
            serialPort_.Close();
            serialPort_.Dispose();
        }
    }

    private void Read()
    {
        while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
            try {
               message_ = serialPort_.ReadLine();
                //message_ = serialPort_.ReadChar();  ///readexistig
               
                
                isNewMessageReceived_ = true;
            } catch (System.Exception e) {
                Debug.LogWarning(e.Message);
            }
        }
    }

    public void Write(string message)
    {
        try {
            serialPort_.Write(message);
        } catch (System.Exception e) {
            Debug.LogWarning(e.Message);
        }
    }

    void comInfoFulFill()
    {
        //portNameText=portNameTextObj.GetComponent<Text>();
        //baudRateText=baudRateTextObj.GetComponent<Text>();
        //Debug.Log(portNameText.ToString());
        portName=portNameText.text.ToString();
        baudRate=int.Parse(baudRateText.text.ToString());
        infoInputCanvas.SetActive(false);
        inputAssignCanvas.SetActive(true);

        Open();
    }
}

