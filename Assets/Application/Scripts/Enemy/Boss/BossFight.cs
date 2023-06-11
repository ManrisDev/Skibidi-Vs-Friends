using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;

public class BossFight : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetPosition;
    [SerializeField] private Transform _playerTargetPosition;
    //[SerializeField] private Slider _bossHealthBar;
    [SerializeField] private float _speedChangeCameraPosition;
    [SerializeField] private float _speedChangePlayerPosition;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerMove _playerMove;
    [SerializeField] private CameraMove _cameraMove;

    private Boss _boss;

    private void Start()
    {
        //_bossHealthBar.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _boss = FindObjectOfType<Boss>();

        _boss.Fight += OnBossFighted;
    }

    private void OnDisable()
    {
        _boss.Fight -= OnBossFighted;
    }

    private void OnBossFighted(Boss boss)
    {
        _playerMove.Stop();
        _cameraMove.enabled = false;
        //_bossHealthBar.gameObject.SetActive(true);
        StartCoroutine(MoveTowardsTarget(_camera, _cameraTargetPosition, _speedChangeCameraPosition));
        StartCoroutine(MoveTowardsTarget(_player, _playerTargetPosition, _speedChangePlayerPosition));
        _camera.rotation = Quaternion.Euler(0, -60, 0);
    }

    private IEnumerator MoveTowardsTarget(Transform startPosition, Transform targetPosition, float speedChangePosition)
    {
        while (startPosition != targetPosition)
        {
            startPosition.position = Vector3.MoveTowards(startPosition.position, targetPosition.position, speedChangePosition);
            yield return null;
        }
    }
}
