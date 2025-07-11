using UnityEngine;

public class TitleTextMover : MonoBehaviour
{
    [SerializeField] private float amplitude = 30f;
    [SerializeField] private float speed = 1f;
    [SerializeField] private float phaseOffset = 0f;

    private RectTransform rectTransform;
    private Vector2 initialAnchoredPos;

    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        initialAnchoredPos = rectTransform.anchoredPosition;
    }

    private void Update()
    {
        // ← 時間停止中でも進むように変更！
        float offset = Mathf.Sin(Time.unscaledTime * speed + phaseOffset) * amplitude;
        rectTransform.anchoredPosition = initialAnchoredPos + new Vector2(offset, 0f);
    }
}