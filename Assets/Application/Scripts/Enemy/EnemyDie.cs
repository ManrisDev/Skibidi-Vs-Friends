using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EnemyDie : MonoBehaviour
{
    //[SerializeField] private ScoreProgress _scoreProgress;
    //[SerializeField] private ScoreView _scoreView;

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
        //_scoreProgress.AddScore(enemy.Value);
        //_scoreView.UpdateScore();
        enemy.Die -= OnEnemyDied;
        _enemies.Remove(enemy);
        Destroy(enemy.gameObject);
    }
}
