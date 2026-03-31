using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class HomeButtonHandler : MonoBehaviour
{
    private Button homeButton;

    private void Awake()
    {
        homeButton = GetComponent<Button>();
        homeButton.onClick.AddListener(OnHomeButtonClicked);
    }

    private void OnHomeButtonClicked()
    {
        Debug.Log("Home button clicked");

        AudioManager.Instance?.se.Play(SeTypeSystem.ButtonClickTransition);
        SceneLoadUtility.LoadScene("Title");
    }
}
