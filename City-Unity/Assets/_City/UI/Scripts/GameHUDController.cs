using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class GameHUDController : MonoBehaviour
{
    [Header("ナイフアイコン設定")]
    [SerializeField] private GameObject knifeIconPrefab;
    [SerializeField] private Transform knifeContainer;

    [Header("リンゴスコア表示")]
    [SerializeField] private Text appleScoreGameText;

    [Header("ナイフヒットスコア表示")]
    [SerializeField] private Text knifeHitScoreText;

    private List<GameObject> knifeIcons = new List<GameObject>();

    //ナイフアイコン初期化
    public void InitializeIcons(int count)
    {
        //既存のアイコンを削除
        foreach (var icon in knifeIcons)
        {
            Destroy(icon);
        }

        knifeIcons.Clear();

        //指定数だけアイコンを生成
        for(int i = 0; i < count; i++)
        {
            GameObject icon = Instantiate(knifeIconPrefab, knifeContainer);
            knifeIcons.Add(icon);
        }
    }

    //ナイフ一本使用
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

    //リンゴスコア更新
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