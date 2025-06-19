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

    // ��񂲃X�R�A�X�V
    public void UpdateAppleScore(int score)
    {
        currentAppleScore = score;

        if (gameHUDController != null)
        {
            gameHUDController.UpdateAppleScore(score);
        }

        if (titleUIController != null)
        {
            titleUIController.SetAppleScore(score);
        }
    }

    // �^�C�g����ʂ�\��
    public void ShowTitleUI()
    {
        titleUI.SetActive(true);
        gameUI.SetActive(false);
        Time.timeScale = 0f;

        // �N�����X�R�A�\���i���F0�j
        titleUIController?.SetAppleScore(currentAppleScore);
    }

    // �Q�[���J�n����
    public void StartGame()
    {
        titleUI.SetActive(false);
        gameUI.SetActive(true);
        Time.timeScale = 1f;
    }
}
