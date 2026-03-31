using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class SettingButtonHandler : MonoBehaviour
{
    private Button settingButton;

    private void Awake()
    {
        settingButton = GetComponent<Button>();
        settingButton.onClick.AddListener(OnSettingButtonClicked);
    }

    private void OnSettingButtonClicked()
    {
        Debug.Log("Setting button clicked");

        AudioManager.Instance?.se.Play(SeTypeSystem.ButtonClickTransition);
        SceneLoadUtility.LoadScene("Setting");
    }
}
