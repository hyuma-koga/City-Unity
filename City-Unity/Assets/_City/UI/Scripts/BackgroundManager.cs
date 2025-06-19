using UnityEngine;

public class BackgroundManager : MonoBehaviour
{
    private static BackgroundManager instance;

    void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // �V�[���؂�ւ��ł��c��
        }
        else
        {
            Destroy(gameObject); // ���łɑ��݂��Ă���Ώd���r��
        }
    }
}