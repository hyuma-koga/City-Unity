using UnityEngine;

public class PlayerStick : MonoBehaviour
{
    [SerializeField] private float bounceForce = 5f;
    private bool hasStuck = false;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (hasStuck)
        {
            return;
        }

        //的に刺さった時
        if (other.CompareTag("Target"))
        {
            hasStuck = true;

            //的にくっつけて回転
            transform.SetParent(other.transform);

            //刺さった位置を少し奥に移動
            transform.position += transform.up * 0.5f;

            //物理停止
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Kinematic;
            }

            //衝突しないようにトリガー化(柄のめり込み防止)
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
            {
                col.isTrigger = true;
            }

            //Targetにヒット演出
            TargetHitFeedback feedback = other.GetComponent<TargetHitFeedback>();
            if (feedback != null)
            {
                feedback.PlayHitEffect();
            }

            //プレイヤーカウンターに通知
            PlayerCounter counter = other.GetComponentInParent<PlayerCounter>();
            if (counter != null)

            {
                counter.AddPlayer();
            }
        }

        //他のナイフに刺さった時→
        if (other.CompareTag("Player"))
        {
            Debug.Log("ナイフ同士が衝突!ゲームオーバー!");

            //弾き返し
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 dir = (transform.position - other.transform.position).normalized;
                rb.AddForce(dir * bounceForce, ForceMode2D.Impulse);
            }

            //ゲームオーバー処理
            if(GameOverManager.Instance != null)
            {
                GameOverManager.Instance.ShowGameOver();
            }
        }
    }
}