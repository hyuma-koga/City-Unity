using UnityEngine;

[CreateAssetMenu(fileName = "StageData", menuName = "ScriptableObjects/StageData")]
public class StageData : ScriptableObject
{
    [Header("�X�e�[�W�\���p�v���n�u")]
    public GameObject stagePrefab;

    [Header("�i�C�t�{��")]
    public int knifeCount = 5;

    [Header("��Փx�i��F1�`5�j")]
    public int difficulty = 1;

    [Header("���������S��")]
    public int initialAppleCount = 0;

    // ���ɂ��X�e�[�W�ŗL�̐ݒ�����R�ɒǉ��\
}