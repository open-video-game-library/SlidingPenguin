using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneMana_score : MonoBehaviour
{
    public Button homeButton;
    public Button retryButton;
    // Start is called before the first frame update
    void Start()
    {
        homeButton.onClick.AddListener(homebtnclick);
        retryButton.onClick.AddListener(retrybtnclick);
    }
    

    void homebtnclick()
    {
        StartCoroutine("load_home");
    }

    void retrybtnclick()
    {
        StartCoroutine("load_main");
    }

    private IEnumerator load_home()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene ("Start");
    }

    private IEnumerator load_main()
    {
        yield return new WaitForSeconds(1.0f);
        SceneManager.LoadScene ("InGame");
    }
}
