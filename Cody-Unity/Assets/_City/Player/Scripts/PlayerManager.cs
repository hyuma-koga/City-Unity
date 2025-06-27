using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerManager : MonoBehaviour
{
    private PlayerShooter shooter;

    private void Awake()
    {
        shooter = GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }

        if (Input.GetMouseButtonDown(0))
        {
            shooter?.ShootCurrentPlayer();
        }
    }
}