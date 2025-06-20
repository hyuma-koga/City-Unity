using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObjects/StageData")]
public class StageData : ScriptableObject
{
    [Header("ステージ構成用プレハブ")]
    public GameObject stagePrefab;

    [Header("ナイフ本数")]
    public int knifeCount = 5;
}