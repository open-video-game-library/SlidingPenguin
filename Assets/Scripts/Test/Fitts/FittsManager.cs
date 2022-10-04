using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Runtime.InteropServices;

namespace Fitts
{


    public class FittsManager : MonoBehaviour
    {
        private Vector2 _mousePosPre = Vector3.zero;
        public float _totalTime;
        float _stopTime;
        Text _timeText;
        Text _stopTimeText;
        Text _finallyTimeText;
        Text _distanceText;
        Text _widthText;
        Text _sppedText;
        Text _resultText;
        public GameObject timeText;
        public GameObject finallyTimeText;
        public GameObject distanceText;
        public GameObject stopTimeText;
        public GameObject widthText;
        public GameObject speedText;
        public GameObject resultText;
        [SerializeField] GameObject goalPrehab;
        [SerializeField] float _distance;
        [SerializeField] GameObject startrcursorPrehab;
        public GameObject startButton;
        public GameObject backButton;
        Button _startbutton;       
        Button _backButton;       
        [SerializeField]float width;
        Ontrigger ontrigger;
        GameObject _goal;
        GameObject _cursor;
        public bool _testPlaying;
        [SerializeField] float sensitivity = 0.3f;
        float _result;
        float _devicespeed;
        // Start is called before the first frame update
        void Start()
        {
            //text
            _timeText = timeText.GetComponent<Text>();
            _finallyTimeText = finallyTimeText.GetComponent<Text>();
            _distanceText = distanceText.GetComponent<Text>();
            _widthText = widthText.GetComponent<Text>();
            _sppedText = speedText.GetComponent<Text>();
            _stopTimeText = stopTimeText.GetComponent<Text>();
            _resultText = resultText.GetComponent<Text>();
            //button
            _startbutton = startButton.GetComponent<Button>();
            _startbutton.onClick.AddListener(StarBtnClicked);
            _backButton = backButton.GetComponent<Button>();
            _backButton.onClick.AddListener(BackBtnClicked);
            ontrigger=goalPrehab.GetComponent<Ontrigger>();
            //bool
            _testPlaying = false;
            backButton.SetActive(false);
        }

        // Update is called once per frame
        void Update()
        {

            Vector2 _mousePosition = Input.mousePosition;

            if (_testPlaying)
            {
                _totalTime += Time.deltaTime;
                _timeText.text = "Elapsed time " + _totalTime;

                if (_mousePosition == _mousePosPre)
                {
                    _stopTime += Time.deltaTime;
                    _stopTimeText.text = "a time " + _stopTime;
                }

                if (_cursor != null)
                {

                    float mouse_move_x = Input.GetAxis("Mouse X") * sensitivity;
                    float mouse_move_y = Input.GetAxis("Mouse Y") * sensitivity;
                    //_cursor.transform.position = new Vector3((_cursor.transform.position.x+(_mousePosition - _mousePosPre).x), (_cursor.transform.position.y + (_mousePosition - _mousePosPre).y),0.0f);
                    _cursor.transform.position += new Vector3(mouse_move_x, mouse_move_y, 0);
                }

            }


            //_sppedText.text=((_mousePosition - _mousePosPre) / Time.deltaTime).magnitude.ToString();
            
            _mousePosPre = _mousePosition;
        }

        void StarBtnClicked()
        {
            startButton.SetActive(false);    // turn true when test finish.
            _testPlaying = true;
            Cursor.visible = false;
            //decide each position
            Vector2 firstCursorPos = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f));
            Vector2 GoalPos = new Vector2(Random.Range(-8.0f, 8.0f), Random.Range(-4.0f, 4.0f));

            //culculate angle
            float _angle = GetAngle(firstCursorPos, GoalPos);
            //culculate distance
            _distance = (GoalPos - firstCursorPos).magnitude;
            _distanceText.text =  "D="+_distance.ToString();
            //reposition startcursor & Instantiate goal

            //SetCursorPos(firstCursorPos.x, firstCursorPos.y);
            _cursor = Instantiate(startrcursorPrehab, firstCursorPos, Quaternion.identity);
            _goal = Instantiate(goalPrehab, GoalPos, Quaternion.Euler(0.0f, 0.0f, _angle)); 
            width = Random.Range(0.2f, 0.7f);
            float _w=_goal.GetComponent<SpriteRenderer>().bounds.size.x;
            _goal.GetComponent<Transform>().localScale = new Vector3(width, width, width);
            _widthText.text = "W="+_w.ToString();
            
            //_goal.GetComponent<BoxCollider2D>().size = new Vector2(width, width);
        }

        void BackBtnClicked()
        {
            startButton.SetActive(true);
            backButton.SetActive(false);
            _distanceText.text = "";
            _widthText.text = "";
            _timeText.text = "";
            _finallyTimeText.text = "";
            _totalTime = 0;
            _distance = 0;
            width = 0;
            Destroy(_goal);
            Destroy(_cursor);
        }

        public void TestFinished()
        {
            Debug.Log("testfin");
            backButton.SetActive(true);
            _finallyTimeText.text = "T=" + _totalTime;
            _testPlaying = false;
            _timeText.text = "";
            _devicespeed = _distance / (_totalTime-_stopTime);                            ///kari
            _sppedText.text = "b="+(_devicespeed).ToString();

            _result = _stopTime + _devicespeed * Mathf.Log(1 + _distance / width, 2);

            _resultText.text = _result.ToString();
        }

        float GetAngle(Vector2 startPos, Vector2 endPos)    ///trigonometric function
        {
            Vector2 dt = endPos - startPos;
            float rad = Mathf.Atan2(dt.y, dt.x);
            float degree = rad * Mathf.Rad2Deg;
            Debug.Log(degree);
            return degree;
        }
    }
}