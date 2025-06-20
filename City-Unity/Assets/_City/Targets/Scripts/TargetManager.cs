using UnityEngine;

public class TargetManager : MonoBehaviour
{
    private TargetRotator rotator;
    private TargetBreaker breaker;

    private void Awake()
    {
        rotator = GetComponent<TargetRotator>();
        breaker = GetComponent<TargetBreaker>();
    }

    //回転のオン・オフ
    public void SetRotation(bool isActive)
    {
        if(rotator != null)
        {
            rotator.enabled = isActive;
        }
    }

    //破壊処理を外部から呼び出す
    public void Break()
    {
        if(breaker != null)
        {
            breaker.TriggerBreak();
        }
    }
}
