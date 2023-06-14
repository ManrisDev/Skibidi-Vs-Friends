using System.Collections;
using UnityEngine;

public class BossFight : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetPosition;
    [SerializeField] private Transform _playerTargetPosition;
    [SerializeField] private float _speedChangeCameraPosition;
    [SerializeField] private float _speedChangePlayerPosition;
    [SerializeField] private float _rotationAngleCamera;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private CameraMove _cameraMove;
    [SerializeField] private GameObject _effectHitPrefab;
    [SerializeField] private Transform _particleHitPosition;
    [SerializeField] private ParticleSystem _effectDiePrefab;

    private Boss _boss;
    private Animator _animator;
    private bool isFight = false;

    private void Update()
    {
        if (isFight)
            if (Input.GetMouseButton(0))
            {
                PlayerAnimationController.Instance.BossHit();
                SoundsManager.Instance.PlaySound("BossHit");
                Instantiate(_effectHitPrefab, _particleHitPosition.position, transform.rotation);
            }
    }

    private void OnEnable()
    {
        _boss = FindObjectOfType<Boss>();
        _animator = transform.GetChild(0).GetComponent<Animator>();

        _boss.Fight += OnBossFighted;
        _boss.Die += OnBossDied;
    }

    private void OnDisable()
    {
        _boss.Fight -= OnBossFighted;
        _boss.Die -= OnBossDied;
    }

    // Сражение началось
    private void OnBossFighted(Boss boss)
    {
        //_playerMove.Stop();
        _cameraMove.enabled = false;
        PlayerAnimationController.Instance.Prepair();
        Invoke("SetFight", 1f);
        StartCoroutine(MoveTowardsTarget(_camera, _cameraTargetPosition, _speedChangeCameraPosition));
        StartCoroutine(MoveTowardsTarget(_player, _playerTargetPosition, _speedChangePlayerPosition));
        _camera.rotation = Quaternion.Euler(0, _rotationAngleCamera, 0);
    }

    private void OnBossDied()
    {
        _effectDiePrefab.Play();
        _animator.SetTrigger("Die");
        isFight = false;
    }

    private IEnumerator MoveTowardsTarget(Transform startPosition, Transform targetPosition, float speedChangePosition)
    {
        while (startPosition != targetPosition)
        {
            startPosition.position = Vector3.MoveTowards(startPosition.position, targetPosition.position, speedChangePosition);
            yield return null;
        }
    }

    private void SetFight()
    {
        isFight = true;
        UIBehaviour.Instance.BossFight();
    }
}
