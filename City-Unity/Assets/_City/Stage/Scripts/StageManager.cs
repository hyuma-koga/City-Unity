using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private GameObject[] stagePrefabs;
    [SerializeField] private Transform stageParent;

    [SerializeField] private GameObject bossNoticeUI;
    [SerializeField] private float bossNoticeDuration = 1f;

    [SerializeField] private StageData[] stageDatas;
    [SerializeField] private PlayerShooter playerShooter;

    private int currentStageIndex = 0;
    private GameObject currentStage;


    private void Start()
    {
        LoadStage(currentStageIndex);
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void LoadNextStage() // �� �X�y���C��
    {
        currentStageIndex++;

        if (currentStageIndex >= stagePrefabs.Length)
        {
            return;
        }

        if (currentStage != null)
        {
            Destroy(currentStage);
        }

        if (currentStageIndex == stagePrefabs.Length - 1)
        {
            StartCoroutine(ShowBossStageUIAndLoad()); // �� �֐����C��
        }
        else
        {
            LoadStage(currentStageIndex);
        }
    }

    private void LoadStage(int index)
    {
        Debug.Log($"Loading stage: {index}");

        if (index < 0 || index >= stagePrefabs.Length)
        {
            Debug.LogError("Invalid stage index!");
            return;
        }

        GameObject stage = Instantiate(stagePrefabs[index], stageParent);
        currentStage = stage;

        StageData data = stageDatas[index];
        if (data == null)
        {
            Debug.LogError("StageData is null at index " + index);
        }
        else
        {
            Debug.Log("Stage Display Name: " + data.stageDisplayName);
            UIManager.Instance?.UpdateStageName(data.stageDisplayName);
        }

        Transform spawn = stage.transform.Find("SpawnPoint"); // �� �X�e�[�WPrefab���� SpawnPoint ������O��
        if (spawn != null && playerShooter != null)
        {
            playerShooter.SetSpawnPoint(spawn); // PlayerShooter �ɓn��
        }

        PlayerCounter counter = stage.GetComponentInChildren<PlayerCounter>();
        if (counter != null && playerShooter != null)
        {
            playerShooter.SetPlayerCounter(counter);
        }

        playerShooter?.ResetKnifeCountFromStageData();
        UIManager.Instance?.UpdateAppleScore(UIManager.Instance.GetCurrentAppleScore());
        AppleManager appleManager = stage.GetComponentInChildren<AppleManager>();
        if (appleManager != null)
        {
            ApplePlacer placer = appleManager.GetComponentInChildren<ApplePlacer>();
            if (placer != null)
            {
                appleManager.SetDependencies(placer, UIManager.Instance.GetGameHUDController());
            }
        }
        
        UIManager.Instance?.UpdateStageProgressVisual(index);
    }

    private IEnumerator ShowBossStageUIAndLoad() // �� ���O����v������
    {
        bossNoticeUI.SetActive(true);
        yield return new WaitForSecondsRealtime(bossNoticeDuration);
        bossNoticeUI.SetActive(false);
        LoadStage(currentStageIndex);
    }

    public StageData GetCurrentStageData()
    {
        return stageDatas[currentStageIndex];
    }

    public void RestartFromBeginning()
    {
        currentStageIndex = 0;

        if (currentStage != null)
        {
            Destroy(currentStage);
        }

        LoadStage(currentStageIndex);
    }

    public bool IsLastStage()
    {
        return currentStageIndex == stagePrefabs.Length - 1;
    }
}