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

    /// <summary>
    /// �v���C���[���X�|�[������i�X�e�[�W�؂�ւ����ɂ��Ă΂��j
    /// </summary>
    /// <param name="spawnPos">�X�e�[�W���̃X�|�[���ʒu</param>
    public void SpawnPlayer(Vector3 spawnPos)
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer); // �O�̃v���C���[������
        }

        currentPlayer = Instantiate(playerPrefab, spawnPos, Quaternion.identity, playerParent);

        // KnifeManager��X�R�A���Z�b�g�Ȃǂ�����΂����ŌĂяo��
        // KnifeManager.Instance.InitializeKnives();
        // ScoreManager.Instance.ResetScore();
    }
}
