using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _currentMoveSpeed;
    [SerializeField] private float _sensivityMultiplier;
    [SerializeField] private float _minXposition;
    [SerializeField] private float _maxXposition;

    private Rigidbody _rigidbody;
    private float _finalTouchX;
    private float _deltaThreshold;
    private Vector2 _firstTouchPosition;
    private Vector2 _currentTouchPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        ResetInputValues();
    }

    private void Update()
    {
        HandleMovementWithSlide();
    }

    private void FixedUpdate()
    {
        HandleEndlessRun();
    }

    private void HandleEndlessRun()
    {
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _currentMoveSpeed * Time.fixedDeltaTime);
    }

    private void HandleMovementWithSlide()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButton(0))
        {
            _currentTouchPosition = Input.mousePosition;
            Vector2 touchDelta = (_currentTouchPosition - _firstTouchPosition);

            if (_firstTouchPosition == _currentTouchPosition)
            {
                _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _rigidbody.velocity.z);
            }

            _finalTouchX = transform.position.x;

            if (Mathf.Abs(touchDelta.x) >= _deltaThreshold)
            {
                _finalTouchX = (transform.position.x + (touchDelta.x * _sensivityMultiplier));
            }

            _rigidbody.position = new Vector3(_finalTouchX, transform.position.y, transform.position.z);
            _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, _minXposition, _maxXposition), _rigidbody.position.y, _rigidbody.position.z);

            _firstTouchPosition = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            ResetInputValues();
        }
    }

    private void ResetInputValues()
    {
        _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _rigidbody.velocity.z);
        _firstTouchPosition = Vector2.zero;
        _finalTouchX = 0f;
        _currentTouchPosition = Vector2.zero;
    }
}
