using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObjects/StageData")]
public class StageData : ScriptableObject
{
    [Header("ステージ構成用プレハブ")]
    public GameObject stagePrefab;

    [Header("ナイフ本数")]
    public int knifeCount = 5;

    [Header("難易度（例：1～5）")]
    public int difficulty = 1;

    [Header("初期リンゴ数")]
    public int initialAppleCount = 0;

    // 他にもステージ固有の設定を自由に追加可能
}