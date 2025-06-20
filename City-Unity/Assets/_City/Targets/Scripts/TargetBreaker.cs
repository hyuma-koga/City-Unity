using System.Collections;
using UnityEngine;

public class TargetBreaker : MonoBehaviour
{
    [SerializeField] private GameObject[] fragmentPrefabs;
    [SerializeField] private int spawnCount = 24;
    [SerializeField] private float scatterForce = 5f;

    private bool isBroken = false;

    public void TriggerBreak()
    {
        if (isBroken)
        {
            return;
        }

        isBroken = true;

        foreach (var renderer in GetComponentsInChildren<SpriteRenderer>())
        {
            renderer.enabled = false;
        }

        foreach (var collider in GetComponents<Collider2D>())
        {
            collider.enabled = false;
        }

        for (int i = 0; i < spawnCount; i++)
        {
            if (fragmentPrefabs == null || fragmentPrefabs.Length == 0)
            {
                Debug.LogError("fragmentPrefabs が空です！");
                return;
            }

            GameObject frag = Instantiate(
                fragmentPrefabs[Random.Range(0, fragmentPrefabs.Length)],
                transform.position,
                Quaternion.Euler(0, 0, Random.Range(0f, 360f))
            );

            Rigidbody2D rb = frag.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                Vector2 dir = Random.insideUnitCircle.normalized;
                rb.AddForce(dir * scatterForce, ForceMode2D.Impulse);
            }
        }

        StartCoroutine(DestroyAndLoadNextStage());
    }

    private IEnumerator DestroyAndLoadNextStage()
    {
        yield return new WaitForSeconds(1f);

        if (StageManager.Instance != null)
        {
            if (StageManager.Instance.IsLastStage())
            {
                GameOverManager.Instance.ShowGameClear(); // ゲームクリアUIを表示
            }
            else
            {
                StageManager.Instance.LoadNextStage(); // 通常の次ステージへ進む
            }
        }

        Destroy(gameObject);
    }
}