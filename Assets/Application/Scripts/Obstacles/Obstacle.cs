using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    [SerializeField] private int _obstacleValue;
    [SerializeField] private GameObject _hitParticle;

    public int ObstacleValue => _obstacleValue;
    public event UnityAction<Obstacle> Offend;

    private void OnTriggerEnter(Collider other)
    {
        _hitParticle.SetActive(true);
        Offend?.Invoke(this);
    }
}
