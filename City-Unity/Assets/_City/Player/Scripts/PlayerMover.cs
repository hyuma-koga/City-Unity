using UnityEngine;

public class PlayerMover : MonoBehaviour
{
    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Launch(Vector2 velocity)
    {
        rb.linearVelocity = velocity;
    }
}
