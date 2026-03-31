public class GamePauseState : IGameState
{
    public void OnEnter(GameStateMachine context)
    {
        // ポーズUIを表示する
        context.PauseCanvas.SetActive(true);

        // ポーズ処理
        PauseUtility.Pause();
    }

    public void OnExecute(GameStateMachine context)
    {
        // ポーズ解除の入力を待つ
        if (InputDataManager.Instance.inputData.pause)
        {
            // 自分自身をスタックから降ろす
            context.PopState();
        }
    }

    public void OnExit(GameStateMachine context)
    {
        // ポーズ解除処理
        PauseUtility.Unpause();

        // ポーズUIを非表示にする
        context.PauseCanvas.SetActive(false);
    }

    public void OnSuspend() { }
    public void OnResume() { }
}
