using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootSpeed = 20f;
    [SerializeField] private float spawnDelay = 0.05f;
    [SerializeField] private PlayerCounter playerCounter;
    [SerializeField] private GameHUDController gameHUDController;

    private GameObject currentPlayer;
    private int remainingKnives;
    private bool hasSpawned = false;

    public void ShootCurrentPlayer()
    {
        if (currentPlayer == null || remainingKnives <= 0)
        {
            Debug.LogError("currentPlayer が null またはナイフが残っていません！");
            return;
        }

        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        PlayerMover mover = currentPlayer.GetComponent<PlayerMover>();
        mover?.Launch(Vector2.up * shootSpeed);

        currentPlayer = null;
        remainingKnives--;
        gameHUDController?.UseOneKnife();

        if (remainingKnives > 0)
        {
            StartCoroutine(DelayedSpawnNextPlayer());
        }
        else
        {
            Debug.Log("ナイフをすべて使い切りました！");
        }
    }

    private IEnumerator DelayedSpawnNextPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        SpawnNextPlayer();
    }

    private void SpawnNextPlayer()
    {
        if (hasSpawned)
        {
            return;
        }

        hasSpawned = true;

        if (spawnPoint == null)
        {
            Debug.LogWarning("SpawnPointが設定されていません！");
            return;
        }

        ForceClearCurrentPlayer();

        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);
        currentPlayer.SetActive(true);

        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        StartCoroutine(AnimateSpawn(currentPlayer, spawnPoint.position));
        StartCoroutine(ResetSpawnFlagAfterDelay());
    }

    private IEnumerator AnimateSpawn(GameObject player, Vector3 targetPosition, float duration = 0.5f)
    {
        if (player == null)
        {
            yield break;
        }

        SpriteRenderer sr = player.GetComponent<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = new Color(1f, 1f, 1f, 0f);
        }

        Vector3 startPos = targetPosition + new Vector3(0f, -1.5f, 0f);
        float timer = 0f;

        player.transform.position = startPos;

        while (timer < duration)
        {
            if (player == null)
            {
                yield break;
            }

            timer += Time.deltaTime;
            float t = timer / duration;

            player.transform.position = Vector3.Lerp(startPos, targetPosition, t);
            if (sr != null)
            {
                sr.color = new Color(1f, 1f, 1f, t);
            }

            yield return null;
        }

        if (player == null)
        {
            yield break;
        }
        player.transform.position = targetPosition;
        if (sr != null)
        {
            sr.color = Color.white;
        }
    }

    public void ResetKnifeCountFromStageData()
    {
        StageData data = StageManager.Instance?.GetCurrentStageData();
        if (data == null)
        {
            return;
        }

        remainingKnives = data.knifeCount;
        gameHUDController?.InitializeIcons(remainingKnives);
        SpawnNextPlayer();
    }

    public void ResetPlayerState()
    {
        ForceClearCurrentPlayer();

        remainingKnives = 0;
        hasSpawned = false;

        // 初回ステージ情報に基づいてリセット
        ResetKnifeCountFromStageData();
    }

    public void SetSpawnPoint(Transform newSpawnPoint)
    {
        spawnPoint = newSpawnPoint;
    }

    public void SetPlayerCounter(PlayerCounter counter)
    {
        playerCounter = counter;
    }

    private IEnumerator ResetSpawnFlagAfterDelay()
    {
        yield return new WaitForSeconds(0.1f);
        hasSpawned = false;
    }

    public void ForceClearCurrentPlayer()
    {
        if (currentPlayer != null)
        {
            Destroy(currentPlayer);
            currentPlayer = null;
        }
    }
}