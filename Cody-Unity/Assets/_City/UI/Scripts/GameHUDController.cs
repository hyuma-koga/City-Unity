using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameHUDController : MonoBehaviour
{
    [Header("�i�C�t�A�C�R���ݒ�")]
    [SerializeField] private GameObject knifeIconPrefab;
    [SerializeField] private Transform knifeContainer;

    [Header("�����S�X�R�A�\��")]
    [SerializeField] private Text appleScoreGameText;

    [Header("�i�C�t�q�b�g�X�R�A�\��")]
    [SerializeField] private Text knifeHitScoreText;

    private List<GameObject> knifeIcons = new List<GameObject>();

    //�i�C�t�A�C�R��������
    public void InitializeIcons(int count)
    {
        //�����̃A�C�R�����폜
        foreach (var icon in knifeIcons)
        {
            Destroy(icon);
        }

        knifeIcons.Clear();

        //�w�萔�����A�C�R���𐶐�
        for(int i = 0; i < count; i++)
        {
            GameObject icon = Instantiate(knifeIconPrefab, knifeContainer);
            knifeIcons.Add(icon);
        }
    }

    //�i�C�t��{�g�p
    public void UseOneKnife()
    {
        if(knifeIcons.Count == 0)
        {
            return;
        }

        GameObject lastIcon = knifeIcons[knifeIcons.Count - 1];
        Destroy(lastIcon);
        knifeIcons.RemoveAt(knifeIcons.Count - 1);
    }

    //�����S�X�R�A�X�V
    public void UpdateAppleScore(int score)
    {
        if (appleScoreGameText != null)
        {
            appleScoreGameText.text = score.ToString();
        }
    }

    public void UpdateKnifeHitScore(int score)
    {
        if (knifeHitScoreText != null)
        {
            knifeHitScoreText.text = score.ToString();
        }
    }
}