using UnityEngine;

public class VerticalObstacle : Obstacle
{
    public float moveDistance = 4f;  // Расстояние, на которое будет двигаться препятствие
    public float moveSpeed = 2f;     // Скорость движения препятствия

    private Vector3 initialPosition;
    private bool isMovingUp = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // Двигаем препятствие вверх и вниз
        if (isMovingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // Проверяем, достигло ли препятствие границы движения
        if (transform.position.y >= initialPosition.y + moveDistance)
        {
            isMovingUp = false;
        }
        else if (transform.position.y <= initialPosition.y)
        {
            isMovingUp = true;
        }
    }
}
