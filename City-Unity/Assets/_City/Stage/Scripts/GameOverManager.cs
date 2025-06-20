using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    public static GameOverManager Instance;

    [Header("UIä÷òA")]
    [SerializeField] private GameObject gameOverUI;
    [SerializeField] private GameObject titleUI;
    [SerializeField] private GameObject gameUI;

    [Header("ÉQÅ[ÉÄä÷òA")]
    [SerializeField] private StageManager stageManager;
    [SerializeField] private PlayerShooter playerShooter;
    [SerializeField] private GameObject player;

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

    public void ShowGameOver()
    {
        Time.timeScale = 0f;
        gameOverUI?.SetActive(true);
        gameUI?.SetActive(false);
        player?.SetActive(false);
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        gameOverUI?.SetActive(false);
        gameUI?.SetActive(true);
        player?.SetActive(true);

        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();
        if (rb != null) rb.simulated = true;

        stageManager.RestartFromBeginning();
        playerShooter.ResetKnifeCountFromStageData();
    }

    public void ReturnToTitle()
    {
        Time.timeScale = 0f;
        gameOverUI?.SetActive(false);
        gameUI?.SetActive(false);
        titleUI?.SetActive(true);
        player?.SetActive(false);
    }
}