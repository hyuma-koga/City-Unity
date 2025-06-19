using UnityEngine;
using UnityEngine.UI;

public class TitleUIController : MonoBehaviour
{
    [SerializeField] private Text appleScoreText;

    //�����S�X�R�A
    public void SetAppleScore(int score)
    {
        if(appleScoreText != null)
        {
            appleScoreText.text = score.ToString();
        }
    }

    //�Q�[���J�n
    public void OnStartButtonClicked()
    {
        UIManager.Instance.StartGame();
    }
}
