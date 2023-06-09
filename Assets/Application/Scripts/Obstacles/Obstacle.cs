using UnityEngine;
using UnityEngine.Events;

public class Obstacle : MonoBehaviour
{
    public event UnityAction<Obstacle> Offend;

    private void OnTriggerEnter(Collider other)
    {
        Offend?.Invoke(this);
    }
}
