using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace penguin
{
    public class CourseOutPenguin : MonoBehaviour
    {
        // 現在のステータスを管理するクラス
        [SerializeField] private InGameStatusManager statusManager;

        // ペンギンの影を表すオブジェクト。透明度を下げて海に落ちる様子を表現するために参照。
        [SerializeField] private GameObject penguinShadow;

        // コースアウトしてから経過した時間。ペンギンの透明度変化に利用する。
        private float courseOutTime;

        // ペンギンの透明度を指定する変数。
        private float alpha;

        private void FixedUpdate()
        {
            if (statusManager.CurrentStatus != InGameStatus.CourseOut)
            {
                penguinShadow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 255);
                courseOutTime = 0.0f;
                return;
            }

            // 以降コースアウト時のみ実行
            courseOutTime += Time.deltaTime;
            float t = 0.7f - courseOutTime;
            alpha = t / 0.7f;
            if (alpha >= 0)
            {
                penguinShadow.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, alpha);
            }
        }
    }
}