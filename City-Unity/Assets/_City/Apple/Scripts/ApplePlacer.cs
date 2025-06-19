using UnityEngine;

public class ApplePlacer : MonoBehaviour
{
    [SerializeField] private GameObject applePrefab;
    [SerializeField] private int appleCount = 3;
    [SerializeField] private float radius = 1.6f;

    public void PlaceApples()
    {
        for (int i = 0; i < appleCount; i++)
        {
            float angle = i * 360f / appleCount;
            Vector3 offset = new Vector3(Mathf.Cos(angle * Mathf.Deg2Rad), Mathf.Sin(angle * Mathf.Deg2Rad)) * radius;
            GameObject apple = Instantiate(applePrefab, transform.position + offset, Quaternion.identity, transform);
            apple.transform.up = offset.normalized;

            AppleHitHandler hit = apple.GetComponent<AppleHitHandler>();
            if (hit != null)
            {
                hit.Setup(this.GetComponentInParent<AppleManager>());
            }
        }
    }
}
