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

        //�I�Ɏh��������
        if (other.CompareTag("Target"))
        {
            hasStuck = true;

            //�I�ɂ������ĉ�]
            transform.SetParent(other.transform);

            //�h�������ʒu���������Ɉړ�
            transform.position += transform.up * 0.5f;

            //������~
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.linearVelocity = Vector2.zero;
                rb.bodyType = RigidbodyType2D.Kinematic;
            }

            //�Փ˂��Ȃ��悤�Ƀg���K�[��(���̂߂荞�ݖh�~)
            Collider2D col = GetComponent<Collider2D>();
            if (col != null)
            {
                col.isTrigger = true;
            }

            //Target�Ƀq�b�g���o
            TargetHitFeedback feedback = other.GetComponent<TargetHitFeedback>();
            if (feedback != null)
            {
                feedback.PlayHitEffect();
            }

            //�v���C���[�J�E���^�[�ɒʒm
            PlayerCounter counter = other.GetComponentInParent<PlayerCounter>();
            if (counter != null)

            {
                counter.AddPlayer();
            }
        }

        //���̃i�C�t�Ɏh����������
        if (other.CompareTag("Player"))
        {
            Debug.Log("�i�C�t���m���Փ�!�Q�[���I�[�o�[!");

            //�e���Ԃ�
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if(rb != null)
            {
                Vector2 dir = (transform.position - other.transform.position).normalized;
                rb.AddForce(dir * bounceForce, ForceMode2D.Impulse);
            }

            //�Q�[���I�[�o�[����
            if(GameOverManager.Instance != null)
            {
                GameOverManager.Instance.ShowGameOver();
            }
        }
    }
}