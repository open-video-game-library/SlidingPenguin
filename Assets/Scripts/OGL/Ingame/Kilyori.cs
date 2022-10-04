using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
public class Kilyori : MonoBehaviour
{
    [SerializeField]float zentilyou;
    StageDetection stageDetection;
    public GameObject stage;
    public GameObject penguin;
    float penguinPos;
    public static int persentage;
    // Start is called before the first frame update
    void Start()
    {
        stageDetection=stage.GetComponent<StageDetection>();
        persentage=0;
    }

    // Update is called once per frame
    void Update()
    {
        if(stageDetection._gameover&&persentage==0)
        {
            
            penguinPos=penguin.transform.position.y+6;
            persentage=(int)(100*penguinPos/zentilyou);
            
            kyoriPoint();
        }
    }

    public static int kyoriPoint() {
        return persentage;
    }
}
}