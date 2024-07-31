using System.Collections;
using UnityEngine;
using penguin;

public class RespawnManager : MonoBehaviour
{
    // 現在のステータスを管理するクラス
    [SerializeField] private InGameStatusManager statusManager;
    // ペンギンのGameObject
    [SerializeField] private GameObject penguin;
    // ペンギンのモデル
    [SerializeField] private GameObject penguinModel;
    // ペンギンの挙動を制御するクラス
    [SerializeField] private PenguinBehavior penguinBehavior;
    // InGameシーンのSE再生・停止クラス
    [SerializeField] private InGameAudio audio;

    // 復活できる箇所を管理するクラス
    [SerializeField] private CheckPointsManager checkPoints;

    [SerializeField] private RespawnCamera respawnCamera;

    public IEnumerator Respawn()
    {
        if (statusManager.CurrentStatus == InGameStatus.InGameNormal || statusManager.CurrentStatus == InGameStatus.HurryUp)
        {
            InGameStatus originalState = statusManager.CurrentStatus;
            Vector3 originalPenguinPosition = penguin.transform.position;

            // ペンギンを停止させ、操作をoffにする
            StartCoroutine(penguinBehavior.Stop(0.5f));
            penguinModel.SetActive(false);
            audio.drop.Play();
            statusManager.CurrentStatus = InGameStatus.CourseOut;

            // ペンギンをスタート地点に戻す処理
            yield return new WaitForSeconds(1.50f);

            respawnCamera.Teleport();
            penguin.transform.position = checkPoints.DecideRespawnPosition(originalPenguinPosition);
            penguin.transform.eulerAngles = Vector3.zero;
            penguin.GetComponent<PenguinBehavior>().enabled = true;
            penguinModel.SetActive(true);
            statusManager.CurrentStatus = originalState;
        }
    }
}
