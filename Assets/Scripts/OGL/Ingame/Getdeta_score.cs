using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace penguin
{
public class Getdeta_score : MonoBehaviour
{
    public GameObject ScoreCanvas;
    bool gamefin;

    private int acquiredItemNumber;
    
    public GameObject restartBtn;
    public GameObject homeBtn;

    [SerializeField] private RawImage resultSprite;
    [SerializeField] private Texture clearSprite;
    [SerializeField] private Texture gameOverSprite;

    [SerializeField] private Text itemNumberText;
    [SerializeField] private Text itemMaximumNumberText;
    

    [SerializeField] private GameObject fishBone;

    private int maximumFishNumber;

    public float vert;
    bool once=true;

    [SerializeField] private AudioSource countSE;
    // Start is called before the first frame update
    void Start()
    {
        gamefin=GoalDetection.gameclear();
        itemNumberText.text = "0";
        maximumFishNumber = GoalDetection.GetMaxItemNumber();
        itemMaximumNumberText.text = "/" + maximumFishNumber;
    }

    // Update is called once per frame
    void Update()
    {
        if(gamefin)
        {
            resultSprite.texture = clearSprite;
           ScoreCanvas.SetActive(true);
           if(once)
           {
               acquiredItemNumber=GoalDetection.GetItemNumber();
               StartCoroutine ("CalculateFishNum");
               once = false;
           }
           
        }
        else
        {
            resultSprite.texture = gameOverSprite;
            if(once)
           {
               acquiredItemNumber=GoalDetection.GetItemNumber();
               once = false;
           }
          
        }
    }

    private IEnumerator CalculateFishNum()
    {
        for (int i = 0; i < acquiredItemNumber; i++)
        {
            yield return new WaitForSeconds (0.5f);

            GameObject fishBoneInstance = Instantiate(fishBone, new Vector3(0, 300, 0), quaternion.Euler(0, 0,Random.Range(-20,20)));
            Rigidbody2D rb = fishBoneInstance.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = new Vector2(Random.Range(-vert, vert), 0);
            rb.AddForce(forceDirection);
            yield return new WaitForSeconds (0.5f);
            if (i == acquiredItemNumber - 1)
            {
                itemNumberText.color = Color.yellow;
            }
            itemNumberText.text = (i + 1).ToString();
            countSE.Play();
        }
        

        restartBtn.SetActive(true);
        homeBtn.SetActive(true);
    }
}
}