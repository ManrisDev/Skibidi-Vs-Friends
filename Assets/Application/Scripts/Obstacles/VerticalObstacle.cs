using UnityEngine;

public class VerticalObstacle : Obstacle
{
    public float moveDistance = 4f;  // ����������, �� ������� ����� ��������� �����������
    public float moveSpeed = 2f;     // �������� �������� �����������

    private Vector3 initialPosition;
    private bool isMovingUp = true;

    private void Start()
    {
        initialPosition = transform.position;
    }

    private void Update()
    {
        // ������� ����������� ����� � ����
        if (isMovingUp)
        {
            transform.Translate(Vector3.up * moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.down * moveSpeed * Time.deltaTime);
        }

        // ���������, �������� �� ����������� ������� ��������
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
