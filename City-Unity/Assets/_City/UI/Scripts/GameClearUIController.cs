using UnityEngine;
using UnityEngine.UI;

public class GameClearUIController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text appleScoreText;
    [SerializeField] private Text stageNameText;
    [SerializeField] private Text hitScoreText; // �� �ǉ�

    public void Show(int appleScore, string stageName, int hitScore) // �� �����ǉ�
    {
        panel?.SetActive(true);

        if (appleScoreText != null) appleScoreText.text = $" {appleScore}";
        if (stageNameText != null) stageNameText.text = $" {stageName}";
        if (hitScoreText != null) hitScoreText.text = $" {hitScore}"; // �� �ǉ�
    }

    public void Hide()
    {
        panel?.SetActive(false);
    }
}