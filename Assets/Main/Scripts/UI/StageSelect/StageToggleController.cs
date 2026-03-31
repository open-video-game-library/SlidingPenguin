using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class StageToggleController : MonoBehaviour
{
    [SerializeField]
    private TMP_Text label;

    private Toggle toggle;
    private StageType stageType;

    public void Initialize(StageType type, ToggleGroup toggleGroup)
    {
        stageType = type;
        toggle = GetComponent<Toggle>();
        toggle.group = toggleGroup;

        // "GameScoreStore"‚ÉŒ»İ“o˜^‚³‚ê‚Ä‚¢‚é StageType ‚Ì Toggle ‚ğ ON ‚É‚·‚é
        if (type == StageGenerator.GetStageType())
        {
            toggle.isOn = true;
        }
        toggle.onValueChanged.AddListener(OnToggleChanged);

        // ƒ‰ƒxƒ‹‚Ìİ’è(•R‚Ã‚¢‚Ä‚¢‚é StageType ‚ğƒ‰ƒxƒ‹‚Éİ’è)
        SetLabel(type.ToString());
    }

    private void SetLabel(string newLabel)
    {
        string spacedWord = StringCaseUtility.ToSpacedWords(newLabel);
        label.SetText(spacedWord);
    }

    public void OnToggleChanged(bool isOn)
    {
        if(isOn)
        {
            StageGenerator.SetStageType(stageType);
        }
    }
}
