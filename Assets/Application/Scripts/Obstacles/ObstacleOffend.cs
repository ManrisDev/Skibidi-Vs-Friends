using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObstacleOffend : MonoBehaviour
{
    private List<Obstacle> _obstacles;

    private void OnEnable()
    {
        _obstacles = FindObjectsOfType<Obstacle>().ToList();

        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.Offend += OnObstacleOffended;
        }
    }

    private void OnDisable()
    {
        foreach (Obstacle obstacle in _obstacles)
        {
            obstacle.Offend -= OnObstacleOffended;
        }
    }

    private void OnObstacleOffended(Obstacle obstacle)
    {
        PlayerModifier playerModifier = FindObjectOfType<PlayerModifier>();
        if (playerModifier)
        {
            playerModifier.Decrease(obstacle.ObstacleValue);
        }
        obstacle.Offend -= OnObstacleOffended;
        _obstacles.Remove(obstacle);
        Destroy(obstacle.gameObject);
    }
}
