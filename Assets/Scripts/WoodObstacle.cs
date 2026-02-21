using UnityEngine;

public class WoodObstacle : MonoBehaviour
{
    private float speed = 5.0f;

    private void Start()
    {
        Destroy(gameObject, 5.0f);
    }

    void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
    }
}
