using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _currentMoveSpeed;
    [SerializeField] private float _sensivityMultiplier;
    [SerializeField] private float _minXposition;
    [SerializeField] private float _maxXposition;
    [SerializeField] private ParticleSystem _warpSpeedEffect;
    [SerializeField] private float _speedX;

    private Rigidbody _rigidbody;
    [SerializeField] private float _finalTouchX;
    [SerializeField] private float _deltaThreshold;
    [SerializeField] private float _originalSpeed;
    [SerializeField] private Vector2 _firstTouchPosition;
    [SerializeField] private Vector2 _currentTouchPosition;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _originalSpeed = _currentMoveSpeed;
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
        _rigidbody.velocity = new Vector3(_rigidbody.velocity.x, _rigidbody.velocity.y, _currentMoveSpeed * Time.deltaTime);
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
            touchDelta.x /= Screen.width;

            if (_firstTouchPosition == _currentTouchPosition)
            {
                _rigidbody.velocity = new Vector3(0f, _rigidbody.velocity.y, _rigidbody.velocity.z);
            }

            _finalTouchX = transform.position.x;

            if (Mathf.Abs(touchDelta.x) >= _deltaThreshold)
            {
                _finalTouchX = (transform.position.x + (touchDelta.x * _sensivityMultiplier * Time.deltaTime));
            }

            float positionX = Mathf.MoveTowards(transform.position.x, _finalTouchX, _speedX * Time.deltaTime);
            _rigidbody.position = new Vector3(positionX, transform.position.y, transform.position.z);
            _rigidbody.position = new Vector3(Mathf.Clamp(_rigidbody.position.x, _minXposition, _maxXposition), 
                _rigidbody.position.y, _rigidbody.position.z);

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

    public void Stop()
    {
        _currentMoveSpeed = 0f;
    }

    public void ApplyNitro(float timeApplyNitro, float nitroMultiplier)
    {
        if (_currentMoveSpeed == _originalSpeed)
        {
            _currentMoveSpeed *= nitroMultiplier;
            _warpSpeedEffect.gameObject.SetActive(true);

            Invoke("StopNitro", timeApplyNitro);
        }
    }

    private void StopNitro()
    {
        _currentMoveSpeed = _originalSpeed;
        _warpSpeedEffect.gameObject.SetActive(false);
    }
}
