using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trail
{
    public string timeStamp;
    public float x;
    public float y;

    public Trail(string _timeStamp, float _x, float _y)
    {
        timeStamp = _timeStamp;
        x = _x;
        y = _y;
    }
}

namespace penguin
{
    public class PenguinBehavior : MonoBehaviour
    {
        public static List<Trail> penguinTrail = new List<Trail>();

        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ペンギンが動く時のアニメーター
        [SerializeField] private Animator penguinMoveAnimator;
        
        // ペンギンにアタッチされたRigidBody2D。コースアウト判定は2次元で十分なため、RigidBody2Dを使用。
        [SerializeField] private Rigidbody2D penguinRigidBody;

        // SE再生・停止クラス
        [SerializeField] private InGameAudio audio;

        // ペンギンの現在の移動速度。
        private Vector3 speed;
        // ペンギンの速度上限。
        private float penguinMaximumSpeed;
        // ペンギンの加速度。
        private float penguinAcceleration;
        // 氷の摩擦係数。
        private float friction;

        // ペンギンの基本感度。大きいほど入力に対する移動量が大きい。
        private float sensitivity;

        // 加速フラグ。速度を変更するために使用する。
        private bool speedUp;
        
        // Start is called before the first frame update
        void Start()
        {
            penguinTrail = new List<Trail>();

            penguinMaximumSpeed = ParameterManager.maximumSpeed;
            penguinAcceleration = ParameterManager.acceleration;
            friction = ParameterManager.friction;
            sensitivity = ParameterManager.sensitivity;
        }

        void Update()
        {
            bool isInGame = (statusManager.CurrentStatus == InGameStatus.InGameNormal ||
                             statusManager.CurrentStatus == InGameStatus.HurryUp);

            if (isInGame)
            {
                DateTime currentTime = DateTime.Now;
                string year = AddLeadingZero(currentTime.Year.ToString());
                string month = AddLeadingZero(currentTime.Month.ToString());
                string day = AddLeadingZero(currentTime.Day.ToString());
                string hour = AddLeadingZero(currentTime.Hour.ToString());
                string minute = AddLeadingZero(currentTime.Minute.ToString());
                string second = AddLeadingZero(currentTime.Second.ToString());
                string millisecond = AddLeadingZeros(currentTime.Millisecond.ToString());

                penguinTrail.Add(new Trail(year + month + day + hour + minute + second + millisecond, transform.position.x, transform.position.y));

                float horizon = Input.GetAxis("Horizontal");
                float vertical = Input.GetAxis("Vertical");

                if (ParameterManager.usePhysics)
                {
                    // 移動入力があった際の処理
                    if (vertical != 0.0f || horizon != 0.0f)
                    {
                        PhysicsMove(vertical, horizon);
                        Rotate(vertical, horizon);
                    }
                    else { penguinMoveAnimator.SetBool("IsMoving", false); }
                }
                else
                {
                    Move(vertical, horizon);

                    // 移動入力があった際の処理
                    if (vertical != 0.0f || horizon != 0.0f) { Rotate(vertical, horizon); }
                    if (vertical == 0.0f && horizon == 0.0f) { penguinMoveAnimator.SetBool("IsMoving", false); }
                }

                // 加速入力があった際の処理
                if (Input.GetButtonDown("Submit") || Input.GetKeyDown(KeyCode.Space)) { SpeedUp(); }
            }
        }

        private void PhysicsMove(float vertical, float horizon)
        {
            // play animation
            penguinMoveAnimator.SetBool("IsMoving", true);

            // ペンギンに加える力
            Vector3 force;
            
            // プレイヤーオブジェクトに力を加える
            if (!speedUp) { force = new Vector3(horizon, vertical, 0) * sensitivity; }
            else { force = new Vector3(horizon, vertical, 0) * sensitivity * 3; }
            penguinRigidBody.AddForce(force);
        }

        private void Move(float vertical, float horizon)
        {
            // play animation
            penguinMoveAnimator.SetBool("IsMoving", true);

            // プレイヤーオブジェクトを加速度運動させる
            if (speedUp) { penguinAcceleration = ParameterManager.acceleration * 3.0f; }
            else { penguinAcceleration = ParameterManager.acceleration; }

            // 速度を、加速度をもとに計算
            if (vertical < 0.0f)
            {
                // 左に動く
                if (speed.y - penguinAcceleration > -penguinMaximumSpeed * Mathf.Abs(vertical)) { speed.y -= penguinAcceleration; }
                else { speed.y += penguinAcceleration; }
            }
            else if (vertical > 0.0f)
            {
                // 右に動く
                if (speed.y + penguinAcceleration < penguinMaximumSpeed * Mathf.Abs(vertical)) { speed.y += penguinAcceleration; }
                else { speed.y -= penguinAcceleration; }
            }
            else { speed.y *= friction; }

            if (horizon > 0.0f)
            {
                // 前に進む
                if (speed.x + penguinAcceleration < penguinMaximumSpeed * Mathf.Abs(horizon)) { speed.x += penguinAcceleration; }
                else { speed.x -= penguinAcceleration; }
            }
            else if (horizon < 0.0f)
            {
                // 後ろに進む
                if (speed.x - penguinAcceleration > -penguinMaximumSpeed * Mathf.Abs(horizon)) { speed.x -= penguinAcceleration; }
                else { speed.x += penguinAcceleration; }
            }
            else { speed.x *= friction; }

            transform.Translate(speed * Time.deltaTime, Space.World);
        }

        private void Rotate(float vertical, float horizon)
        {
            // プレイヤーオブジェクトが向く方向を更新する
            float angle = Mathf.Atan(vertical / horizon) * Mathf.Rad2Deg;
            
            if (horizon >= 0) { transform.rotation = Quaternion.Euler(0, 0, angle - 90.0f); }
            else { transform.rotation = Quaternion.Euler(0, 0, angle + 90.0f); }
        }

        private void SpeedUp()
        {
            speedUp = true;
            StartCoroutine("PlayAccelerationAnimation");
            audio.acceleration.Play();
        }

        private IEnumerator PlayAccelerationAnimation() 
        {
            penguinMoveAnimator.SetBool("IsAcceleration", true);
            yield return new WaitForSeconds (0.7f);
            speedUp = false;
            penguinMoveAnimator.SetBool("IsAcceleration", false);
        }

        public IEnumerator Stop(float stopTime)
        {
            if (ParameterManager.usePhysics)
            {
                yield return new WaitForSeconds(stopTime);
                penguinRigidBody.velocity = Vector3.zero;
                penguinRigidBody.angularVelocity = 0;
                enabled = false;
            }
            else
            {
                yield return new WaitForSeconds(stopTime);
                speed = Vector3.zero;
                penguinAcceleration = 0.0f;
                enabled = false;
            }
        }

        // 数字が一桁の場合に頭に0をつけるメソッド
        private string AddLeadingZero(string input)
        {
            // 入力文字列が数字であるかどうかを確認
            if (int.TryParse(input, out int number))
            {
                // 数字が一桁の場合
                if (number >= 0 && number < 10)
                {
                    // 頭に0をつける
                    return number.ToString("D2");
                }
            }
            // それ以外の場合は元の文字列を返す
            return input;
        }

        private string AddLeadingZeros(string input)
        {
            // 入力文字列が数字であるかどうかを確認
            if (int.TryParse(input, out int number))
            {
                // 数字の桁数に応じて頭に0を追加
                if (number >= 0 && number < 10)
                {
                    return "000" + input;
                }
                else if (number >= 10 && number < 100)
                {
                    return "00" + input;
                }
                else if (number >= 100 && number < 1000)
                {
                    return "0" + input;
                }
            }
            // それ以外の場合は元の文字列を返す
            return input;
        }
    }
}