using UnityEngine;

public class TargetRotator : MonoBehaviour
{
    [Header("基本設定")]
    [SerializeField] private float baseSpeed = 50f;
    [SerializeField] private bool useRandomSpeed = false;
    [SerializeField] private float minSpeed = 30f;
    [SerializeField] private float maxSpeed = 100f;

    [Header("方向切り替え設定")]
    [SerializeField] private bool changeDirection = true;
    [SerializeField] private float directionChangeInterval = 3f;

    [Header("加速・減速設定")]
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
        //回転
        transform.Rotate(0, 0, currentSpeed * direction * Time.deltaTime);

        //方向切り替えタイマー
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

        //加減速処理
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
