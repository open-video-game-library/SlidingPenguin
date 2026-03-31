using System.Collections;
using UnityEngine;

public class GamePlayingState : IGameState
{
    private bool warned = false;
    private bool isActive = false;

    private PlayerController playerController;
    private TimeKeeper timeKeeper;
    private PlayingCanvasManager playingCanvasManager;

    private GameStateMachine currentContext;

    private Coroutine contextCoroutine;

    public void OnEnter(GameStateMachine context)
    {
        Debug.Log("Enter GamePlayingState");

        isActive = true;
        currentContext = context;

        ScoreManager.Instance.Initialize();

        GradeManager.Instance.Initialize();
        GradeManager.Instance.SetStageInfo();

        context.PlayingCanvas.SetActive(true);
        context.PauseCanvas.SetActive(false);
        context.CountDownCanvas.SetActive(false);
        context.GameOverCanvas.SetActive(false);

        context.CameraSwitcher.SwitchCamera(CameraSwitcher.CameraType.PlayerCamera);
        AudioManager.Instance.bgm.Change(BgmType.InGame);

        playerController = context.PlayerController;
        playerController.enabled = true;
        playerController.Initialize();

        timeKeeper = new TimeKeeper(DataManager.Instance.timerData["TimerKeeper"].timeLimit);
        timeKeeper.StartTime();

        playingCanvasManager = context.PlayingCanvas.GetComponent<PlayingCanvasManager>();
        playingCanvasManager.Initialize();

        warned = false;

        if (!context.StageGenerator.IsSettingMode)
        {
            // ここから試行を開始し、ログの記録を開始
            DataLogger.Instance.StartTrial();
            DataLogger.Instance.StartStream();
        }
    }

    public void OnExecute(GameStateMachine context)
    {
        // ポーズの入力を待つ
        if (InputDataManager.Instance.inputData.pause)
        {
            context.PushState(new GamePauseState());
            return;
        }

        timeKeeper.UpdateTime(Time.deltaTime);
        float t = timeKeeper.GetRemainingTime();

        if (!warned && t <= DataManager.Instance.timerData["TimerKeeper"].warningThreshold)
        {
            warned = true;
            playingCanvasManager.StartWarnBlink();
            PlayAlert();
        }

        if (timeKeeper.IsTimeUp)
        {
            context.ChangeState(new GameOverState());
        }

        playingCanvasManager.UpdatePlayingUI(timeKeeper);
    }

    public void OnExit(GameStateMachine context)
    {
        Debug.Log("Exit GamePlayingState");

        isActive = false;

        if (contextCoroutine != null)
        {
            context.StopCoroutine(contextCoroutine);
            contextCoroutine = null;
        }

        context.PlayingCanvas.SetActive(false);

        timeKeeper.StopTime();

        ScoreManager.Instance.SetCount("ClearTimeBonus", (int)timeKeeper.GetRemainingTime());

        playerController.enabled = false;
    }

    public void OnSuspend()
    {

    }

    public void OnResume()
    {

    }

    private void PlayAlert()
    {
        if (currentContext == null)
        {
            return;
        }

        if (contextCoroutine != null)
        {
            currentContext.StopCoroutine(contextCoroutine);
            contextCoroutine = null;
        }

        contextCoroutine = currentContext.StartCoroutine(PlayAlertCoroutine());
    }

    private IEnumerator PlayAlertCoroutine()
    {
        AudioManager.Instance.bgm.Stop();
        AudioManager.Instance.se.Play(SeTypeSystem.RushStart);

        yield return new WaitForSeconds(1.5f);
        if (!Application.isPlaying || !isActive) { yield break; }

        AudioManager.Instance.bgm.Change(BgmType.InGame);
        AudioManager.Instance.bgm.SetPitch(1.2f);

        contextCoroutine = null;
    }
}