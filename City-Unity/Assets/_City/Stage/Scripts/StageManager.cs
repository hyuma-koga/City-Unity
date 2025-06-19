using System.Collections;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    public static StageManager Instance { get; private set; }

    [SerializeField] private GameObject[] stagePrefabs;
    [SerializeField] private Transform stageParent;

    [SerializeField] private GameObject bossNoticeUI;
    [SerializeField] private float bossNoticeDuration = 1f;

    private int currentStageIndex = 0;
    private GameObject currentStage;

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

    private void Start()
    {
        LoadStage(currentStageIndex);
    }

    public void LoadNextStage() // Å© ÉXÉyÉãèCê≥
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
            StartCoroutine(ShowBossStageUIAndLoad()); // Å© ä÷êîñºèCê≥
        }
        else
        {
            LoadStage(currentStageIndex);
        }
    }

    private void LoadStage(int index)
    {
        currentStage = Instantiate(stagePrefabs[index], stageParent);
    }

    private IEnumerator ShowBossStageUIAndLoad() // Å© ñºëOÇàÍívÇ≥ÇπÇÈ
    {
        bossNoticeUI.SetActive(true);
        yield return new WaitForSecondsRealtime(bossNoticeDuration);
        bossNoticeUI.SetActive(false);
        LoadStage(currentStageIndex);
    }
}