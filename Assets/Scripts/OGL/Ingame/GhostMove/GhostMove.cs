using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GhostMove : MonoBehaviour {

    //記録する周期(秒)
    private const int RecordCycleSecond = 1;

    //記録する時間(分)
    private const int RecordMinutes = 3;

    //-------------------------------------

    //時間表示
    [SerializeField]
    private Text TimeText;

    //動くやつ
    [SerializeField]
    private GameObject CameraGO;

    //記録をたどるやつ
    [SerializeField]
    public GameObject GhostGO;

    //移動の跡
    [SerializeField]
    private LineRenderer LineRend;

    //-------------------------------------

    //記録開始からの経過時間
    private float LeftTime = 0;

    //タイマー用　経過時間保持
    private float Timer = RecordCycleSecond;

    //移動座標を保存する配列　記録周期(秒)を分になおして　RecordMinutes分記録できる想定
    private Vector3[] PathLog = new Vector3[RecordCycleSecond * (60 / RecordCycleSecond) * RecordMinutes];
    //移動時間を保存する配列
    private float[] PathTime = new float[RecordCycleSecond * (60 / RecordCycleSecond) * RecordMinutes];

    private int PathCount = 0;

    //記録中か
    private bool isRecording = false;

    //再生中か
    private bool isPlaying = false;

    private int PlayPathCount = 0;

	
	// Update is called once per frame
	void Update () {

        //記録中のとき
        if (isRecording)
        {
            //記録時間加算 出力
            LeftTime += Time.deltaTime;
            TimeText.text = "記録時間 " + LeftTime.ToString();

            //タイマー処理
            Timer += Time.deltaTime;
            //周期ごとに実行
            if (Timer >= RecordCycleSecond)
            {
                Timer -= RecordCycleSecond;//初期化

                RecordPosition();
            }
        }

        //再生中のとき
        if (isPlaying)
        {
            //次のPathに近づいたら　移動先を更新
            if (Vector3.Distance(GhostGO.transform.position, PathLog[PlayPathCount]) < 0.2f)
            {
                PlayPathCount++;
            }

            //最初　開始位置にピョンして抜ける
            if (PlayPathCount == 0)
            {
                GhostGO.transform.position = PathLog[PlayPathCount];
                return;
            }

            //最後 終了処理して抜ける
            if (PathCount == PlayPathCount)
            {
                isPlaying = false;

                return;
            }

            //各点の 速さ＝距離÷時間
            float speed = Vector3.Distance(PathLog[PlayPathCount], PathLog[PlayPathCount - 1]) / (PathTime[PlayPathCount] - PathTime[PlayPathCount - 1]);

            //Pathへ移動
            GhostGO.transform.position = Vector3.MoveTowards(GhostGO.transform.position, PathLog[PlayPathCount], speed * Time.deltaTime);
            GhostGO.transform.LookAt(new Vector3(PathLog[PlayPathCount].x, GhostGO.transform.position.y, PathLog[PlayPathCount].z));
            GhostGO.transform.rotation=Quaternion.Euler(0, 0, 0);
        }
    }


    private void RecordPosition()
    {
        PathLog[PathCount] = CameraGO.transform.position;
        PathTime[PathCount] = LeftTime;
        PathCount++;

        LineRend.positionCount = PathCount;
        for (int i = 0; i < PathCount; i++)
        {
            LineRend.SetPosition(i, PathLog[i] + Vector3.up * 0.1f);
        }

        //Path保存の限界に行ったら強制記録終了
        if (PathCount >= PathLog.Length - 1)
        {
            isRecording = false;
            Debug.Log("タイムアップ！");
        }
    }

    public void PushRecordButton()
    {
        if (isRecording)
        {
            //停止
            isRecording = false;

            Debug.Log("記録終了");
        }
        else
        {
            //記録開始
            isRecording = true;

            Debug.Log("記録開始");

            //LineRendererつける
            LineRend.enabled = true;

            //初期化
            Timer = RecordCycleSecond;
            LeftTime = 0;
            PathLog = new Vector3[RecordCycleSecond * (60 / RecordCycleSecond) * RecordMinutes];
            PathTime = new float[RecordCycleSecond * (60 / RecordCycleSecond) * RecordMinutes];
            PathCount = 0;
        }
    }

    public void PushPlayButton()
    {
        //記録中なら抜ける
        if (isRecording) return;
        //記録がなくても抜ける
        //if (PlayPathCount == 0) return;

        //開始処理
        isPlaying = true;

        //初期化
        PlayPathCount = 0;
    }
}