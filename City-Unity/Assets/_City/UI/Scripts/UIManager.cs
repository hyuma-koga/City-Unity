using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private TitleUIController titleUIController;
    [SerializeField] private GameHUDController gameHUDController;
    [SerializeField] private Text stageNameText_Title;
    [SerializeField] private Text stageNameText_Game;
    [SerializeField] private Text stageNameText_GameOver;

    [Header("ステージ進行イメージ")]
    [SerializeField] private Image[] stageImages;  
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color highlightColor = Color.yellow;

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
    /// 指定した数だけリンゴスコアを加算
    /// </summary>
    public void AddAppleScore(int amount)
    {
        currentAppleScore += amount;
        UpdateAppleScore(currentAppleScore); // UIにも反映
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

        var currentStageData = StageManager.Instance.GetCurrentStageData();
        UpdateStageName(currentStageData.stageDisplayName);
    }

    /// <summary>
    /// ゲームを開始（UIとタイムスケール切り替え）
    /// </summary>
    public void StartGame()
    {
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;

        UpdateAppleScore(currentAppleScore);

        var currentStageData = StageManager.Instance.GetCurrentStageData();
        UpdateStageName(currentStageData.stageDisplayName);

        // ステージデータから初期ナイフ数を取得してUI初期化
        int knifeCount = StageManager.Instance.GetCurrentStageData().knifeCount;
        gameHUDController?.InitializeIcons(knifeCount);
    }

    public GameHUDController GetGameHUDController()
    {
        return gameHUDController;
    }

    /// <summary>
    /// 現在のリンゴスコアを取得
    /// </summary>
    public int GetCurrentAppleScore()
    {
        return currentAppleScore;
    }

    public void UpdateStageName(string stageName)
    {
        if (stageNameText_Title != null) stageNameText_Title.text = stageName;
        if (stageNameText_Game != null) stageNameText_Game.text = stageName;
        if (stageNameText_GameOver != null) stageNameText_GameOver.text = stageName;
    }

    public void UpdateStageProgressVisual(int currentIndex)
    {
        for (int i = 0; i < stageImages.Length; i++)
        {
            if (stageImages[i] != null)
            {
                stageImages[i].color = (i == currentIndex) ? highlightColor : defaultColor;
            }
        }
    }
}
