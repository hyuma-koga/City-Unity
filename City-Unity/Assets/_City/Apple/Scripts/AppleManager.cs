using Unity.VisualScripting;
using UnityEngine;

public class AppleManager : MonoBehaviour
{
    [SerializeField] private ApplePlacer applePlacer;
    [SerializeField] private GameHUDController gameHUDController;

    private void Start()
    {
        if(applePlacer != null)
        {
            applePlacer.PlaceApples();
        }

        UIManager.Instance?.UpdateAppleScore(UIManager.Instance.GetCurrentAppleScore());
    }

    public void AddApplePoint(int value = 1)
    {
        UIManager.Instance?.AddAppleScore(value);
    }


    public void SetDependencies(ApplePlacer placer, GameHUDController hud)
    {
        applePlacer = placer;
        gameHUDController = hud;
    }

}
