using UnityEngine;

public class AppleHitHandler : MonoBehaviour
{
    [Header("割れたリンゴのプレハブ")]
    [SerializeField] private GameObject brokenLeftPrefab;
    [SerializeField] private GameObject brokenRightPrefab;
    [SerializeField] private float breakForce = 3f;

    private AppleManager appleManager;
    private bool isHit = false;

    public void Setup(AppleManager manager)
    {
        appleManager = manager;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isHit) return;

        if (other.CompareTag("Player")) // ナイフと衝突したとき
        {
            isHit = true;

            if (appleManager != null)
            {
                appleManager.AddApplePoint();
            }

            BreakApple();
        }
    }

    private void BreakApple()
    {
        // 分割リンゴの生成位置と回転を元に
        Quaternion originalRotation = transform.rotation;

        GameObject left = Instantiate(brokenLeftPrefab, transform.position, originalRotation);
        GameObject right = Instantiate(brokenRightPrefab, transform.position, originalRotation);

        // ✅ スケールを明示的に設定（元のリンゴと同じにしたいなら数値で指定）
        Vector3 fixedScale = new Vector3(0.45f, 0.45f, 1f);
        left.transform.localScale = fixedScale;
        right.transform.localScale = fixedScale;

        // Rigidbody2D に力を加えて落下＋回転
        Rigidbody2D rbLeft = left.GetComponent<Rigidbody2D>();
        Rigidbody2D rbRight = right.GetComponent<Rigidbody2D>();

        if (rbLeft != null)
        {
            rbLeft.bodyType = RigidbodyType2D.Dynamic;
            rbLeft.AddForce(new Vector2(-1f, 2f) * breakForce, ForceMode2D.Impulse);
            rbLeft.AddTorque(20f, ForceMode2D.Impulse);
        }

        if (rbRight != null)
        {
            rbRight.bodyType = RigidbodyType2D.Dynamic;
            rbRight.AddForce(new Vector2(1f, 2f) * breakForce, ForceMode2D.Impulse);
            rbRight.AddTorque(-20f, ForceMode2D.Impulse);
        }

        Destroy(gameObject);
    }
}