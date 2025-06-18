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
