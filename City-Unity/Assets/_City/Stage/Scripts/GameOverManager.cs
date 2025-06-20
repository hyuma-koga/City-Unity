using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UI関連")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;
    [SerializeField] private Text appleScoreText;

    [Header("ゲーム関連")]
    [SerializeField] private StageManager stageManager;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private GameObject player;

    [Header("ゲームクリアUI")]
    [SerializeField] private GameObject gameClearUI;
    [SerializeField] private GameClearUIController gameClearUIController;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI?.SetActive(true);
        gameUI?.SetActive(false);
        player?.SetActive(false);

        int score = UIManager.Instance.GetCurrentAppleScore();
        if (appleScoreText != null)
        {
            appleScoreText.text = $"{score}";
        }
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverUI?.SetActive(false);
        gameUI?.SetActive(true);

        UIManager.Instance.UpdateAppleScore(0);
        UIManager.Instance.UpdateKnifeHitScore(0);

        playerShooter?.ResetPlayerState();
        stageManager.RestartFromBeginning();
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 0f;
        gameOverUI?.SetActive(false);
        gameClearUI?.SetActive(false);
        gameUI?.SetActive(false);
        titleUI?.SetActive(true);

        UIManager.Instance.UpdateAppleScore(0);
        UIManager.Instance.UpdateKnifeHitScore(0);

        playerShooter?.ResetPlayerState();
        stageManager.RestartFromBeginning();
    }

    public void ShowGameClear()
    {
        Time.timeScale = 0f;
        gameUI?.SetActive(false);
        player?.SetActive(false);
        gameClearUI?.SetActive(true);

        int appleScore = UIManager.Instance.GetCurrentAppleScore();
        string stageName = StageManager.Instance.GetCurrentStageData().stageDisplayName;
        int hitScore = UIManager.Instance.GetKnifeHitScore();

        gameClearUIController?.Show(appleScore, stageName, hitScore);

        StartCoroutine(ReturnToTitleAfterDelay(3f));
    }

    private IEnumerator ReturnToTitleAfterDelay(float delay)
    {
        yield return new WaitForSecondsRealtime(delay);
        gameClearUIController?.Hide();
        ReturnToTitle();
    }
}