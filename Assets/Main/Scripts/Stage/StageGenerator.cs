using System.Collections.Generic;
using UnityEngine;

public enum StageType
{
    Practice = 0,
    FirstStage = 1,
    SecondStage = 2,
    ThirdStage = 3,
}

public class StageGenerator : MonoBehaviour
{
    [SerializeField]
    private static StageType stageType = StageType.Practice;

    [SerializeField]
    private List<GameObject> stagePrefabs;

    // ===== プレイ時のシーンが本番用か設定用かを判別するための変数 =====
    [SerializeField]
    private bool isSettingMode = false;
    public bool IsSettingMode => isSettingMode;
    
    private static bool isLatestSceneSettingMode; // 最後にプレイしたモードが本番用か設定用かを判別するための変数

    private void Awake()
    {
        GenerateStage((int)stageType);
        isLatestSceneSettingMode = isSettingMode;
    }

    private void GenerateStage(int index)
    {
        Debug.Log("Generating stage with index: " + index);

        // リストの範囲内にインデックスを正規化
        int normalizedIndex = ((index % stagePrefabs.Count) + stagePrefabs.Count) % stagePrefabs.Count;
        Instantiate(stagePrefabs[normalizedIndex], Vector3.zero, Quaternion.identity);
    }

    public static void SetStageType(StageType newStageType)
    {
        stageType = newStageType;
    }

    public static StageType GetStageType()
    {
        return stageType;
    }

    public static bool GetIsLatestSceneSettingMode()
    {
        return isLatestSceneSettingMode;
    }
}
