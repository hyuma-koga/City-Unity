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

    [Header("�X�e�[�W�i�s�C���[�W")]
    [SerializeField] private Image[] stageImages;  
    [SerializeField] private Color defaultColor = Color.white;
    [SerializeField] private Color highlightColor = Color.yellow;

    [SerializeField] private Text hitScoreText_Title;
    [SerializeField] private Text hitScoreText_Game;
    [SerializeField] private Text hitScoreText_GameOver;
    [SerializeField] private Text hitScoreText_GameClear;

    private int currentAppleScore = 0;
    private int KnifeHitScore = 0;
    public int GetKnifeHitScore() => KnifeHitScore;

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
        ShowTitleUI(); // �N�����Ƀ^�C�g����ʂ�\��
    }

    /// <summary>
    /// �����S�X�R�A���X�V���A�SUI�ɔ��f
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
            titleUIController.SetAppleScore(score); // �������Ń^�C�g��UI�ɂ����f
        }
    }

    /// <summary>
    /// �w�肵�������������S�X�R�A�����Z
    /// </summary>
    public void AddAppleScore(int amount)
    {
        currentAppleScore += amount;
        UpdateAppleScore(currentAppleScore); // UI�ɂ����f
    }

    /// <summary>
    /// �^�C�g����ʂ�\�����A�X�R�A�Ȃǂ�\��
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
    /// �Q�[�����J�n�iUI�ƃ^�C���X�P�[���؂�ւ��j
    /// </summary>
    public void StartGame()
    {
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;

        UpdateAppleScore(currentAppleScore);

        var currentStageData = StageManager.Instance.GetCurrentStageData();
        UpdateStageName(currentStageData.stageDisplayName);

        // �X�e�[�W�f�[�^���珉���i�C�t�����擾����UI������
        int knifeCount = StageManager.Instance.GetCurrentStageData().knifeCount;
        gameHUDController?.InitializeIcons(knifeCount);
    }

    public GameHUDController GetGameHUDController()
    {
        return gameHUDController;
    }

    /// <summary>
    /// ���݂̃����S�X�R�A���擾
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

    public void UpdateKnifeHitScore(int score)
    {
        if (hitScoreText_Title != null) hitScoreText_Title.text = score.ToString();
        if (hitScoreText_Game != null) hitScoreText_Game.text = score.ToString();
        if (hitScoreText_GameOver != null) hitScoreText_GameOver.text = score.ToString();
        if (hitScoreText_GameClear != null) hitScoreText_GameClear.text = score.ToString();
    }

    public void AddKnifeHitScore(int amount)
    {
        KnifeHitScore += amount;
        UpdateKnifeHitScore(KnifeHitScore);
    }
}
