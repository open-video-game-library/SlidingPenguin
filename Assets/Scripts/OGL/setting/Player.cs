using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO.Ports;

public class Player : MonoBehaviour
{
    private SerialPort serialPort;
    // Start is called before the first frame update
    void Start()
    {
        // SerialPortの第1引数はArduinoIDEで設定したシリアルポートを設定
        // ArduinoIDEの右下から確認できる
        serialPort = new SerialPort("/dev/cu.usbmodem1401", 115200); // ここを自分の設定したシリアルポート名に変えること
        serialPort.Open();
    }

    // Update is called once per frame
    void Update()
    {
        if (serialPort.IsOpen)
        {
            string data = serialPort.ReadLine();
            Debug.Log(data);
        }
    }
}

