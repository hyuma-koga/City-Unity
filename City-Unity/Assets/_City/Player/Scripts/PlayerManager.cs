using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    private PlayerShooter shooter;

    private void Awake()
    {
        shooter = GetComponent<PlayerShooter>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            shooter?.ShootCurrentPlayer();
        }
    }
}
