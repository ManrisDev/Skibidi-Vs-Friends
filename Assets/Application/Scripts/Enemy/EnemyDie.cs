using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    private List<Enemy> _enemies;

    private void OnEnable()
    {
        _enemies = FindObjectsOfType<Enemy>().ToList();

        foreach (Enemy enemy in _enemies)
        {
            enemy.Die += OnEnemyDied;
        }
    }

    private void OnDisable()
    {
        foreach (Enemy enemy in _enemies)
        {
            enemy.Die -= OnEnemyDied;
        }
    }

    private void OnEnemyDied(Enemy enemy)
    {
        PlayerModifier playerModifier = FindObjectOfType<PlayerModifier>();
        if (playerModifier)
        {
            playerModifier.AddWidth(5);
            playerModifier.AddHeight(5);
        }
        enemy.Die -= OnEnemyDied;
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
