using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObjects/StageData")]
public class StageData : ScriptableObject
{
    [Header("�X�e�[�W�\���p�v���n�u")]
    public GameObject stagePrefab;

    [Header("�i�C�t�{��")]
    public int knifeCount = 5;
}