using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
public class InputDataManager : MonoBehaviour
{
    private GameManager _gameManager;
    private int i=0;
    public List<float> up_on=new List<float>();
    public List<float> up_off=new List<float>();
    // Start is called before the first frame update
    void Start()
    {
        _gameManager=this.GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
    
        if(_gameManager.gameStart)
        {
            if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                up_on.Add(_gameManager.TIME);
            }

            if (Input.GetKeyUp(KeyCode.UpArrow))
            {
                up_off.Add(_gameManager.TIME);
            }
        }
        
    }
}
}