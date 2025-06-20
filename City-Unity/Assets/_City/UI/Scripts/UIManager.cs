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
    /// �^�C�g����ʂ�\�����A�X�R�A�Ȃǂ�\��
    /// </summary>
    public void ShowTitleUI()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;

        titleUIController?.SetAppleScore(currentAppleScore);
    }

    /// <summary>
    /// �Q�[�����J�n�iUI�ƃ^�C���X�P�[���؂�ւ��j
    /// </summary>
    public void StartGame()
    {
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;

        currentAppleScore = 0;
        UpdateAppleScore(currentAppleScore);

        // �X�e�[�W�f�[�^���珉���i�C�t�����擾����UI������
        int knifeCount = StageManager.Instance.GetCurrentStageData().knifeCount;
        gameHUDController?.InitializeIcons(knifeCount);
    }

    /// <summary>
    /// �X�e�[�W�ύX����UI�X�V
    /// </summary>
    public void OnStageChanged(int stageIndex)
    {
        // �X�e�[�W�ɉ��������o��UI�ύX���K�v�ł���Βǉ�
        // �Ⴆ�΃X�e�[�W���x���\����X�e�[�W���X�V�Ȃ�
    }

    public GameHUDController GetGameHUDController()
    {
        return gameHUDController;
    }
}
