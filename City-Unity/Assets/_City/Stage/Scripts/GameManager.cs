using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    [Header("�v���C���[�ݒ�")]
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
            Destroy(currentPlayer); // �O�̃v���C���[������
        }

        currentPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity, playerParent);
    }
}