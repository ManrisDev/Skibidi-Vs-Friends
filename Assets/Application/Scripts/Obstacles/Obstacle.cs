using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _obstacleValue;

    public int ObstacleValue => _obstacleValue;
    public event UnityAction<Obstacle> Offend;

    private void OnTriggerEnter(Collider other)
    {
        Offend?.Invoke(this);
    }
}
