using System.Collections.Generic;
using UnityEngine;
public class inputDemo : MonoBehaviour {
    
    // Update is called once per frame
    void Update () {
        float lsh = Input.GetAxis ("L_Stick_H");
        float lsv = Input.GetAxis ("L_Stick_V");
        if(( lsh != 0) || (lsv != 0 )){
            Debug.Log ("L stick:"+lsh+","+lsv );
        }
        
        if (Input.GetKeyDown ("joystick button 0")) {
            Debug.Log ("button0");
        }
        if (Input.GetKeyDown ("joystick button 1")) {
            Debug.Log ("button1");
        }
        if (Input.GetKeyDown ("joystick button 2")) {
            Debug.Log ("button2");
        }
        if (Input.GetKeyDown ("joystick button 3")) {
            Debug.Log ("button3");
        }
        if (Input.GetKeyDown ("joystick button 4")) {
            Debug.Log ("button4");
        }
        if (Input.GetKeyDown ("joystick button 5")) {
            Debug.Log ("button5");
        }
        if (Input.GetKeyDown ("joystick button 6")) {
            Debug.Log ("button6");
        }
        if (Input.GetKeyDown ("joystick button 7")) {
            Debug.Log ("button7");
        }
        if (Input.GetKeyDown ("joystick button 8")) {
            Debug.Log ("button8");
        }
        if (Input.GetKeyDown ("joystick button 9")) {
            Debug.Log ("button9");
        }
        float hori = Input.GetAxis ("Horizontal");
        float vert = Input.GetAxis ("Vertical");
        if(( hori != 0) ||  (vert != 0) ){
            //Debug.Log ("stick:"+hori+","+vert );
            float angle=Mathf.Atan(vert/hori)*Mathf.Rad2Deg;
            if(hori>=0)
            {
                Debug.Log(Mathf.Atan(vert/hori)*Mathf.Rad2Deg);
            }else
            {
                Debug.Log(Mathf.Atan(vert/hori)*Mathf.Rad2Deg+180);
            }
        }

        float XAxis = Input.GetAxis ("X-Axis");
        if (XAxis!=0) {
            Debug.Log (XAxis);
        }

        float YAxis = Input.GetAxis ("Y-Axis");
        if (XAxis!=0) {
            Debug.Log (YAxis);
        }
    }
}