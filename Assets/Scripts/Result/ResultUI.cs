using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;
using Random = UnityEngine.Random;

namespace penguin
{
public class ResultUI : MonoBehaviour
{
    //public GameObject ScoreCanvas;

    // 画面遷移のためのボタン。
    [SerializeField] private GameObject retryButton;
    [SerializeField] private GameObject homeButton;

    
    // リザルト画面のタイトル画像。成功・失敗の2パターン。
    [SerializeField] private RawImage resultSprite;
    [SerializeField] private Texture gameClearSprite;
    [SerializeField] private Texture gameOverSprite;

    // 獲得した魚の数
    private int acquiredFishNumber;
    
    // 獲得した魚の数を表示するテキスト
    [SerializeField] private Text acquiredFishNumberText;
    
    // ステージ上にある魚の総数を表示するテキスト
    [SerializeField] private Text itemMaximumNumberText;
    
    // 獲得した魚のカウント時に落下させる魚の骨オブジェクト
    [SerializeField] private GameObject fishBone;

    // SE再生・停止クラス
    [SerializeField] private ResultSceneAudio audio;


    // Start is called before the first frame update
    void Start()
    {
        InitializeText();
        SetTitle();
    }

    // リザルトテキストを初期設定
    private void InitializeText()
    {
        acquiredFishNumberText.text = "0";
        itemMaximumNumberText.text = "/" + FishManager.GetMaximumNumber();
    }

    // ゲームの成功・失敗に応じてタイトルを設定
    private void SetTitle()
    {
        if(GameClearManager.IsClear())
        { 
            resultSprite.texture = gameClearSprite;
            StartCoroutine("CountUpFishNumber");
        }
        else
        {
            resultSprite.texture = gameOverSprite;
        }
    }

    // 獲得した魚をカウントする演出を開始
    private IEnumerator CountUpFishNumber()
    {
        acquiredFishNumber= FishManager.GetAcquiredNumber();
        for (int i = 0; i < acquiredFishNumber; i++)
        {
            yield return new WaitForSeconds (0.05f);

            GameObject fishBoneInstance = Instantiate(fishBone, new Vector3(0, 300, 0), quaternion.Euler(0, 0,Random.Range(-20,20)));
            Rigidbody2D rb = fishBoneInstance.GetComponent<Rigidbody2D>();
            Vector2 forceDirection = new Vector2(Random.Range(-4000, 4000), 0);
            rb.AddForce(forceDirection);
            yield return new WaitForSeconds (0.6f);
            if (i == acquiredFishNumber - 1)
            {
                acquiredFishNumberText.color = Color.yellow;
            }
            acquiredFishNumberText.text = (i + 1).ToString();
            audio.CountUp.Play();
        }
        

        retryButton.SetActive(true);
        homeButton.SetActive(true);
    }
}
}