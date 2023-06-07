using UnityEngine;

public class CameraMove : MonoBehaviour
{
    [SerializeField] private Transform _target;

    private void Start()
    {
        transform.parent = null;
    }

    private void LateUpdate()
    {
        if (_target)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, _target.position.z);
        }
    }
}
