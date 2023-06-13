using UnityEngine;

public class DisappearingObstacle : Obstacle
{
    [SerializeField] private float _disappearingTime;
    [SerializeField] private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        if (_currentTime >= _disappearingTime)
        {
            _currentTime = 0;

            if (gameObject.GetComponent<Renderer>().enabled == true)
            {
                gameObject.GetComponent<Renderer>().enabled = false;

                gameObject.GetComponent<BoxCollider>().GetComponent<Collider>().enabled = false;
            }
            else
            {
                gameObject.GetComponent<Renderer>().enabled = true;
                gameObject.GetComponent<BoxCollider>().GetComponent<Collider>().enabled = true;
            }
        }
    }
}
