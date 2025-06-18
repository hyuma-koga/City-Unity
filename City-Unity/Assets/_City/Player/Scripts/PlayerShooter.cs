using UnityEngine;
using System.Collections;

public class PlayerShooter : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private Transform spawnPoint;
    [SerializeField] private float shootSpeed = 20f;
    [SerializeField] private float spawnDelay = 0.05f;
    [SerializeField] private PlayerCounter playerCounter;
    [SerializeField] private KnifeUIManager knifeUIManager;

    private GameObject currentPlayer;
    private int remainingKnives;

    private void Start()
    {
        if (playerCounter != null)
        {
            remainingKnives = playerCounter.GetPlayerToBreak();
            knifeUIManager.InitializeIcons(remainingKnives);
        }

        SpawnNextPlayer();
    }

    public void ShootCurrentPlayer()
    {
        if (currentPlayer == null || remainingKnives <= 0)
        {
            return;
        }

        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.bodyType = RigidbodyType2D.Dynamic;
        }

        PlayerMover mover = currentPlayer.GetComponent<PlayerMover>();
        if (mover != null)
        {
            mover.Launch(Vector2.up * shootSpeed);
        }

        currentPlayer = null;
        remainingKnives--;
        knifeUIManager.UseOneKnife();

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
        currentPlayer = Instantiate(playerPrefab, spawnPoint.position, Quaternion.identity);

        Rigidbody2D rb = currentPlayer.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Kinematic;
        }

        StartCoroutine(AnimateSpawn(currentPlayer, spawnPoint.position));
    }

    private IEnumerator AnimateSpawn(GameObject player, Vector3 targetPosition, float duration = 0.5f)
    {
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
            timer += Time.deltaTime;
            float t = timer / duration;

            player.transform.position = Vector3.Lerp(startPos, targetPosition, t);

            if (sr != null)
            {
                sr.color = new Color(1f, 1f, 1f, t);
            }

            yield return null;
        }

        player.transform.position = targetPosition;
        if (sr != null)
        {
            sr.color = Color.white;
        }
    }
}
