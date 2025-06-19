using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private static BackgroundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // シーン切り替えでも残す
        }
        else
        {
            Destroy(gameObject); // すでに存在していれば重複排除
        }
    }
}