using Unity.VisualScripting;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private ApplePlacer applePlacer;
    [SerializeField] private GameHUDController gameHUDController;

    private int appleScore = 0;

    private void Start()
    {
        if(applePlacer != null)
        {
            applePlacer.PlaceApples();
        }

        UpdateUI();
    }

    public void AddApplePoint(int value = 1)
    {
        appleScore += value;
        UpdateUI();
    }

    private void UpdateUI()
    {
        if(gameHUDController != null)
        {
            gameHUDController.UpdateAppleScore(appleScore);
        }
    }

    public void SetDependencies(ApplePlacer placer, GameHUDController hud)
    {
        applePlacer = placer;
        gameHUDController = hud;
    }

}
