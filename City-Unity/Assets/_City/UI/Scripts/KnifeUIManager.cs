using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class KnifeUIManager : MonoBehaviour
{
    [SerializeField] private GameObject knifeIconPrefab;
    [SerializeField] private Transform knifeContainer;

    private List<GameObject> knifeIcons = new List<GameObject>();

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
}
