using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace penguin{
    public class PenguinBehavior : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ペンギンが動く時のアニメーター
        [SerializeField] private Animator penguinMoveAnimator;
        
        // ペンギンにアタッチされたRigidBody2D。コースアウト判定は2次元で十分なため、RigidBody2Dを使用。
        [SerializeField] private Rigidbody2D penguinRigidBody;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;
        
        
        
        // ペンギンの基本感度。大きいほど入力に対する移動量が大きい。
        private float sensitivity;
        
        // 加速フラグ。速度を変更するために使用する。
        private bool isAcceleration;
        
        // ペンギンに加える力。
        private Vector3 force;
        
        
        // Start is called before the first frame update
        void Start()
        {
            sensitivity = ParameterManager.sensitivity;
        }

       
        // Update is called once per frame
        void Update()
        {
            if (statusManager.CurrentStatus == InGameStatus.InGame)
            {
                float horizon = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");
                
                // 移動入力があった際の処理
                if (vertical != 0 || horizon != 0)
                {
                    Move(vertical, horizon);
                    Rotate(vertical, horizon);
                }
                else
                {
                    penguinMoveAnimator.SetBool("IsMoving", false);
                }

                // 加速入力があった際の処理
                if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space))
                {
                    Accelerate();
                }
            }
            
        }

        private void Move(float vertical, float horizon)
        {
            // play animation
            penguinMoveAnimator.SetBool("IsMoving", true);
            
            // プレイヤーオブジェクトに力を加える
            if (!isAcceleration)
            {
                force = new Vector3(horizon, vertical, 0) * sensitivity;
            }
            else
            {
                force = new Vector3(horizon, vertical, 0) * sensitivity * 3;
            }
            penguinRigidBody.AddForce(force);

        }

        private void Rotate(float vertical, float horizon)
        {
            // プレイヤーオブジェクトが向く方向を更新する
            float angle = Mathf.Atan(vertical / horizon) * Mathf.Rad2Deg;
            
            if (horizon >= 0)
            {
                transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f);
            }
            else
            {
                transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f);
            }

        }

        private void Accelerate()
        {
            isAcceleration = true;
            StartCoroutine("PlayAccelerationAnimation");
            audio.acceleration.Play();
        }

        private IEnumerator PlayAccelerationAnimation() 
        {
            penguinMoveAnimator.SetBool("IsAcceleration", true);
            yield return new WaitForSeconds (0.7f);
            isAcceleration = false;
            penguinMoveAnimator.SetBool("IsAcceleration", false);
        }

        public IEnumerator Stop(float stopTime)
        {
            yield return new WaitForSeconds (stopTime);
            penguinRigidBody.velocity = Vector3.zero;
            penguinRigidBody.angularVelocity = 0;
        }

    }
}


