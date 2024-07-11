using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointsManager : MonoBehaviour
{
    private GameObject[] checkPoints;
    private Vector3[] checkPointsPositions;

    // Start is called before the first frame update
    void Start()
    {
        // 子オブジェクトの数を取得
        int childCount = transform.childCount;
        checkPoints = new GameObject[childCount];
        for (int i = 0; i < childCount; i++) { checkPoints[i] = transform.GetChild(i).gameObject; }

        checkPointsPositions = new Vector3[checkPoints.Length];
        for (int i = 0; i < checkPointsPositions.Length; i++) { checkPointsPositions[i] = checkPoints[i].transform.position; }
    }

    public Vector3 DecideRespawnPosition(Vector3 penguinPosition)
    {
        float nearestDistance = Mathf.Infinity;
        Vector3 nearestPosition = checkPointsPositions[0];

        for (int i = 0; i < checkPointsPositions.Length; i++)
        {
            if (checkPointsPositions[i].y > penguinPosition.y) { continue; }

            float distance = Vector3.Distance(penguinPosition, checkPointsPositions[i]);
            if (distance < nearestDistance)
            {
                nearestDistance = distance;
                nearestPosition = checkPointsPositions[i];
            }
        }

        return nearestPosition;
    }
}
