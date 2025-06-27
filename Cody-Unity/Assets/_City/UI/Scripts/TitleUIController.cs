using UnityEngine;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{
    [SerializeField] private Text appleScoreText;
    [SerializeField] private Text knifeHitScoreText;

    //�����S�X�R�A
    public void SetAppleScore(int score)
    {
        if (appleScoreText != null)
        {
            appleScoreText.text = score.ToString();
        }

        // KnifeHitScore��UIManager����擾���ĕ\��
        int knifeHitScore = UIManager.Instance.GetKnifeHitScore();
        if (knifeHitScoreText != null)
        {
            knifeHitScoreText.text = knifeHitScore.ToString();
        }
    }

    //�Q�[���J�n
    public void OnStartButtonClicked()
    {
        UIManager.Instance.StartGame();
    }
}