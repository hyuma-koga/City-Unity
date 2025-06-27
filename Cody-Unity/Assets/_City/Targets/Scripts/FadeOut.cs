using UnityEngine;

public class FadeOut : MonoBehaviour
{
    [SerializeField] private float duration = 1.5f;

    private SpriteRenderer sr;
    private float timer = 0f;

    private void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        timer += Time.deltaTime;
        float alpha = Mathf.Lerp(1f, 0f, timer / duration);
        if(sr != null)
        {
            sr.color = new Color(1, 1, 1, alpha);
        }

        if(timer >= duration)
        {
            Destroy(gameObject);
        }
    }
}
