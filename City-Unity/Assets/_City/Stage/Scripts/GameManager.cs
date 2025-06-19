using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("プレイヤー設定")]
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform playerParent;

    private GameObject currentPlayer;

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

    /// <summary>
    /// プレイヤーをスポーンする（ステージ切り替え時にも呼ばれる）
    /// </summary>
    /// <param name="spawnPos">ステージ内のスポーン位置</param>
    public void SpawnPlayer(Vector3 spawnPos)
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer); // 前のプレイヤーを消す
        }

        currentPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity, playerParent);

        // KnifeManagerやスコアリセットなどがあればここで呼び出し
        // KnifeManager.Instance.InitializeKnives();
        // ScoreManager.Instance.ResetScore();
    }
}
