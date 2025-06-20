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

    public void SpawnPlayer(Vector3 spawnPos)
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer); // 前のプレイヤーを消す
        }

        currentPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity, playerParent);
    }
}