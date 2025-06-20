using UnityEngine;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private TitleUIController titleUIController;
    [SerializeField] private GameHUDController gameHUDController;

    private int currentAppleScore = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        ShowTitleUI(); // 起動時にタイトル画面を表示
    }

    /// <summary>
    /// リンゴスコアを更新し、全UIに反映
    /// </summary>
    public void UpdateAppleScore(int score)
    {
        currentAppleScore = score;

        if (gameHUDController != null)
        {
            gameHUDController.UpdateAppleScore(score);
        }

        if (titleUIController != null)
        {
            titleUIController.SetAppleScore(score); // ★ここでタイトルUIにも反映
        }
    }

    /// <summary>
    /// タイトル画面を表示し、スコアなどを表示
    /// </summary>
    public void ShowTitleUI()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;

        titleUIController?.SetAppleScore(currentAppleScore);
    }

    /// <summary>
    /// ゲームを開始（UIとタイムスケール切り替え）
    /// </summary>
    public void StartGame()
    {
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;

        currentAppleScore = 0;
        UpdateAppleScore(currentAppleScore);

        // ステージデータから初期ナイフ数を取得してUI初期化
        int knifeCount = StageManager.Instance.GetCurrentStageData().knifeCount;
        gameHUDController?.InitializeIcons(knifeCount);
    }

    /// <summary>
    /// ステージ変更時のUI更新
    /// </summary>
    public void OnStageChanged(int stageIndex)
    {
        // ステージに応じた演出やUI変更が必要であれば追加
        // 例えばステージレベル表示やステージ名更新など
    }

    public GameHUDController GetGameHUDController()
    {
        return gameHUDController;
    }
}
