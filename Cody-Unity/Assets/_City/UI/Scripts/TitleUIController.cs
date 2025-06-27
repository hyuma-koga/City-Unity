using UnityEngine;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{
    [SerializeField] private Text appleScoreText;
    [SerializeField] private Text knifeHitScoreText;

    //リンゴスコア
    public void SetAppleScore(int score)
    {
        if (appleScoreText != null)
        {
            appleScoreText.text = score.ToString();
        }

        // KnifeHitScoreをUIManagerから取得して表示
        int knifeHitScore = UIManager.Instance.GetKnifeHitScore();
        if (knifeHitScoreText != null)
        {
            knifeHitScoreText.text = knifeHitScore.ToString();
        }
    }

    //ゲーム開始
    public void OnStartButtonClicked()
    {
        UIManager.Instance.StartGame();
    }
}