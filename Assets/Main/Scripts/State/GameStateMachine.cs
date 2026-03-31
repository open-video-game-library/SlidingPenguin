using UnityEngine;
using System.Collections.Generic;

public class GameStateMachine : MonoBehaviour
{
    private readonly Stack<IGameState> stateStack = new Stack<IGameState>();

    public CameraSwitcher CameraSwitcher { get; private set; }
    public PlayerCameraController PlayerCameraController { get; private set; }
    public CountDownController CountDownController { get; private set; }
    public PlayerController PlayerController { get; private set; }
    public StageGenerator StageGenerator { get; private set; }

    public GameObject GoalObject { get; private set; }

    public GameObject PlayingCanvas { get; private set; }
    public GameObject PauseCanvas {  get; private set; }
    public GameObject CountDownCanvas { get; private set; }
    public GameObject GameOverCanvas { get; private set; }

    private void Start()
    {
        Application.targetFrameRate = 60;

        GameObject cameras = GameObject.Find("Cameras");
        CameraSwitcher = cameras.GetComponent<CameraSwitcher>();

        PlayerCameraController = FindObjectOfType<PlayerCameraController>();

        CountDownController = FindObjectOfType<CountDownController>();

        PlayerController = FindObjectOfType<PlayerController>();
        PlayerController.enabled = false;

        StageGenerator = FindObjectOfType<StageGenerator>();

        GoalObject = GameObject.FindGameObjectWithTag("Goal");

        PlayingCanvas = GameObject.Find("PlayingCanvas");
        PauseCanvas = GameObject.Find("PauseCanvas");
        CountDownCanvas = GameObject.Find("CountDownCanvas");
        GameOverCanvas = GameObject.Find("GameOverCanvas");

        // 現在がSetting用のシーンかどうかで遷移先を分岐
        if (StageGenerator.IsSettingMode) { ChangeState(new GamePlayingState()); }
        else { ChangeState(new GameCourseIntroState()); }
    }

    private void Update()
    {
        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnExecute(this);
        }
    }

    public void ChangeState(IGameState newState)
    {
        // CurrentStateがnullでない場合、Exitメソッドを呼び出して現在の状態を終了する
        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnExit(this);
        }

        stateStack.Clear();

        stateStack.Push(newState);

        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnEnter(this);
        }
    }

    public void PushState(IGameState newState)
    {
        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnSuspend();
        }

        stateStack.Push(newState);

        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnEnter(this);
        }
    }

    public void PopState()
    {
        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnExit(this);
            stateStack.Pop();
        }

        if(stateStack.Count > 0)
        {
            stateStack.Peek().OnResume();
        }
    }
}
