using UnityEngine;

public class HorizontalObtacle : Obstacle
{
    [SerializeField] private int _amplitude = 1;
    [SerializeField] private float _frequency = 0.1f;

    private void Update()
    {
        float x = Mathf.Cos(Time.time * _frequency) * _amplitude;
        float y = transform.position.y;
        float z = transform.position.z;

        transform.position = new Vector3(x, y, z);
    }
}
