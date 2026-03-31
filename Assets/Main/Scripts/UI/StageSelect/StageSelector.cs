using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(ToggleGroup))]
public class StageSelector : MonoBehaviour
{
    private ToggleGroup toggleGroup;

    [SerializeField]
    private GameObject stageTogglePrefab;

    [SerializeField]
    private StartButtonHandler startButton;

    private void Start()
    {
        toggleGroup = GetComponent<ToggleGroup>();

        // 登録されているステージ数を基に、Toggleを生成
        foreach (StageType stage in Enum.GetValues(typeof(StageType)))
        {
            GameObject toggleObject = Instantiate(stageTogglePrefab, transform);

            StageToggleController toggleController = toggleObject.GetComponent<StageToggleController>();
            toggleController.Initialize(stage, toggleGroup);
        }
    }
}
