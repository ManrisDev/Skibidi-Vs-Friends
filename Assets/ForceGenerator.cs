using System.Collections.Generic;
using UnityEngine;

public class ForceGenerator : MonoBehaviour
{
    [SerializeField] private Vector2 _forceStep = Vector2.zero;

    private readonly List<GameObject> _enemiesZones = new();

    private float _force = 1;

    private void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            _enemiesZones.Add(gameObject.transform.GetChild(i).gameObject);
        }

        GenerateForces();
    }

    public void GenerateForces()
    {
        foreach (GameObject enemyZone in _enemiesZones)
        {
            for (int i = 0; i < enemyZone.transform.childCount; i++)
            {
                enemyZone.transform.GetChild(i).GetComponent<Enemy>().SetForce(Mathf.CeilToInt(_force));
                _force = Random.Range(_force - _forceStep.x, _force + _forceStep.y);
            }
        }
    }
}
