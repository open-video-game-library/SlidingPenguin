using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin{
public class RandomFishGene : MonoBehaviour
{
    [SerializeField]float geneInterval;
    public GameObject[] geneFishes;
    float keikaTime;
    GameObject fish;
    GameManager_Esa gameManager_Esa;
    public GameObject gameManagerObj;
    int a=0;
    // Start is called before the first frame update
    void Start()
    {
        gameManager_Esa=gameManagerObj.GetComponent<GameManager_Esa>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager_Esa.gameStart) ///ゲームスタートしたら
        {
            keikaTime+=Time.deltaTime;

             if(keikaTime>geneInterval)
             {
                 keikaTime=0;
                a++;
                 //fish=Instantiate(geneFishes[Random.RandomRange(0,5)]);
                 fish=Instantiate(geneFishes[a%5]);
                 fish.transform.position=new Vector2(Random.RandomRange(-10,10)*2,Random.RandomRange(-6,6)*2);

             }
        }
    }
}
}
