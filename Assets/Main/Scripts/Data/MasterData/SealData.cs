using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SealData
{
    [Header("移動設定")]
    [SerializeField] private List<Vector3> waypoints = new List<Vector3>(); // 辿る座標
    [SerializeField, Min(0.01f)] private float smoothTime = 1.0f; // 各点への移動時間
    [SerializeField, Min(0f)] private float waitSeconds = 1f; // 各点での待機時間
    [SerializeField] private float turnSpeed = 360f; // 回転速度（度/秒）

    public List<Vector3> Waypoints => waypoints;
    public float SmoothTime => smoothTime;
    public float WaitSeconds => waitSeconds;
    public float TurnSpeed => turnSpeed;
}
