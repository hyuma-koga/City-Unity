using UnityEngine;
using UnityEngine.UI;

public class GameClearUIController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text appleScoreText;
    [SerializeField] private Text stageNameText;

    public void Show(int appleScore, string stageName)
    {
        panel?.SetActive(true);

        if (appleScoreText != null) appleScoreText.text = $" {appleScore}";
        if (stageNameText != null) stageNameText.text = $" {stageName}";
    }

    public void Hide()
    {
        panel?.SetActive(false);
    }
}