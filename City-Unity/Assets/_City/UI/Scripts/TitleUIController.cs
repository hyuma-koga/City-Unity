using UnityEngine;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{
    [SerializeField] private Text appleScoreText;

    //リンゴスコア
    public void SetAppleScore(int score)
    {
        if(appleScoreText != null)
        {
            appleScoreText.text = score.ToString();
        }
    }

    //ゲーム開始
    public void OnStartButtonClicked()
    {
        UIManager.Instance.StartGame();
    }
}
