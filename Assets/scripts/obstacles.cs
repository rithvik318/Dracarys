using UnityEngine;

public class Obstacle : MonoBehaviour
{
    private float leftEdge;
    private float gameSpeed;

    private void Start()
    {
        leftEdge = Camera.main.ScreenToWorldPoint(Vector3.zero).x - 2f;
        gameSpeed = GameManager.Instance.gameSpeed;
    }

    private void Update()
    {
        transform.position += gameSpeed * Time.deltaTime * Vector3.left;

        if (transform.position.x < leftEdge)
        {
            Destroy(gameObject);
        }
    }
}
