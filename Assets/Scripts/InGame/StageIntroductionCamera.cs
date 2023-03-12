using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace penguin
{
    public class StageIntroductionCamera : MonoBehaviour
    {
        // ステージ紹介用カメラのTransform
        public Transform transform;

        // ステージ紹介用カメラの初期座標
        private Vector3 initialPosition;

        private void Start()
        {
            initialPosition = transform.position;
        }

        // ステージ紹介のため、カメラを動かす
        public void Move()
        {
            transform.position -= new Vector3(0, 0.4f, 0);
        }

        // 位置をリセットする
        public void Reset()
        {
            transform.position = initialPosition;
        }

    }
    

}
