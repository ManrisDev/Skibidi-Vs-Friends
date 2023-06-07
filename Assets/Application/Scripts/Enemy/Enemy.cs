using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    public event UnityAction<Enemy> Die;

    private void OnTriggerEnter(Collider other)
    {
        Die?.Invoke(this);
    }
}
