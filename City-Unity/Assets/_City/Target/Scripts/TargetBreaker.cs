using UnityEngine;

public class TargetBreaker : MonoBehaviour
{
    [SerializeField] private GameObject[] fragmentPrefabs;
    [SerializeField] private int spawnCount = 24;
    [SerializeField] private float scatterForce = 5f;

    public void TriggerBreak()
    {
        for (int i = 0; i < spawnCount; i++)
        {
            if (fragmentPrefabs == null || fragmentPrefabs.Length == 0)
            {
                Debug.LogError("fragmentPrefabs ‚ª‹ó‚Å‚·I");
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

        Destroy(gameObject);
    }
}