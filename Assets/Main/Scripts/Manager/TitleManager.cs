using UnityEngine;

public class TitleManager : MonoBehaviour
{
    private void Start()
    {
        AudioManager.Instance.bgm.Change(BgmType.Title);
    }
}
