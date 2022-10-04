using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMana_score : MonoBehaviour
{
    public Button[] homeButton;
    public Button[] retryButton;
    // Start is called before the first frame update
    void Start()
    {
        homeButton[0].onClick.AddListener(homebtnclick);
        retryButton[0].onClick.AddListener(retrybtnclick);
        homeButton[1].onClick.AddListener(homebtnclick);
        retryButton[1].onClick.AddListener(retrybtnclick);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void homebtnclick()
    {
        Debug.Log("333");
        StartCoroutine("load_home");
    }

    void retrybtnclick()
    {
        Debug.Log("444");
        StartCoroutine("load_main");
    }

    private IEnumerator load_home()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene ("Penguin_home");
    }

    private IEnumerator load_main()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene ("Penguin_timeattack");
    }
}
