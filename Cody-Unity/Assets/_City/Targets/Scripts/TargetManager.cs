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

    //��]�̃I���E�I�t
    public void SetRotation(bool isActive)
    {
        if(rotator != null)
        {
            rotator.enabled = isActive;
        }
    }

    //�j�󏈗����O������Ăяo��
    public void Break()
    {
        if(breaker != null)
        {
            breaker.TriggerBreak();
        }
    }
}
