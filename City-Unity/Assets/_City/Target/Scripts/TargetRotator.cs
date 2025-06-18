using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    [Header("��{�ݒ�")]
    [SerializeField] private float baseSpeed = 50f;
    [SerializeField] private bool useRandomSpeed = false;
    [SerializeField] private float minSpeed = 30f;
    [SerializeField] private float maxSpeed = 100f;

    [Header("�����؂�ւ��ݒ�")]
    [SerializeField] private bool changeDirection = true;
    [SerializeField] private float directionChangeInterval = 3f;

    [Header("�����E�����ݒ�")]
    [SerializeField] private bool enableSmoothSpeedChange = false;
    [SerializeField] private float speedChangeRate = 10f;

    private float currentSpeed;
    private float targetSpeed;
    private float direction = 1f;
    private float timer;

    private void Start()
    {
        currentSpeed = baseSpeed;
        targetSpeed = currentSpeed;

        if (useRandomSpeed)
        {
            SetRandomSpeed();
        }
    }

    private void Update()
    {
        //��]
        transform.Rotate(0, 0, currentSpeed * direction * Time.deltaTime);

        //�����؂�ւ��^�C�}�[
        if (changeDirection)
        {
            timer += Time.deltaTime;

            if(timer >= directionChangeInterval)
            {
                direction *= -1;
                timer = 0f;

                if (useRandomSpeed)
                {
                    SetRandomSpeed();
                }
            }
        }

        //����������
        if (enableSmoothSpeedChange)
        {
            currentSpeed = Mathf.MoveTowards(currentSpeed, targetSpeed, speedChangeRate * Time.deltaTime);
        }
        else
        {
            currentSpeed = targetSpeed;
        }
    }

    private void SetRandomSpeed()
    {
        targetSpeed = Random.Range(minSpeed, maxSpeed);
    }
}
