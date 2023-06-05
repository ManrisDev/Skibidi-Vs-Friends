using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _oldMousePositionX;
    private float _eulerY;

    void Update()
    {
        transform.position += Vector3.forward * Time.deltaTime * _speed;

        if (Input.GetMouseButtonDown(0))
        {
            _oldMousePositionX = Input.mousePosition.x;
        }

        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + new Vector3(Input.mousePosition.x - _oldMousePositionX, 0f, 0f);
            /*newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);*/
            transform.Translate(newPosition * _speed * Time.deltaTime);

            float deltaX = Input.mousePosition.x - _oldMousePositionX;
            _oldMousePositionX = Input.mousePosition.x;

            _eulerY += deltaX;
            _eulerY = Mathf.Clamp(_eulerY, -20f, 20f);
            transform.eulerAngles = new Vector3(0, _eulerY, 0);
        }
    }
}