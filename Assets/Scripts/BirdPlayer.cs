using UnityEngine;
using UnityEngine.InputSystem;

public class BirdPlayer : MonoBehaviour
{
    public BirbGameManager gameManager;

    public Rigidbody2D rBody;
    public PlayerInput playerInput;
    private InputAction action1;
    private float flapPower = 6.0f;

    private void Start()
    {
        action1 = playerInput.actions.FindAction("Action1");
    }

    private void Update()
    {
        if (action1.WasPressedThisFrame())
        {
            rBody.linearVelocityY = flapPower;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Enemy")
        {
            gameManager.EnableGameOver();
            Destroy(gameObject);
        }
        if (collision.tag == "Goal")
        {
            gameManager.AddScore();
        }
    }
}
