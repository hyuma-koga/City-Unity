using UnityEngine;
using UnityEngine.UI;

public class GameClearUIController : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private Text appleScoreText;
    [SerializeField] private Text stageNameText;
    [SerializeField] private Text hitScoreText; // Å© í«â¡

    public void Show(int appleScore, string stageName, int hitScore) // Å© à¯êîí«â¡
    {
        panel?.SetActive(true);

        if (appleScoreText != null) appleScoreText.text = $" {appleScore}";
        if (stageNameText != null) stageNameText.text = $" {stageName}";
        if (hitScoreText != null) hitScoreText.text = $" {hitScore}"; // Å© í«â¡
    }

    public void Hide()
    {
        panel?.SetActive(false);
    }
}