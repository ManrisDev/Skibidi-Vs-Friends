using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class BossFight : MonoBehaviour
{
    [SerializeField] private Transform _cameraTargetPosition;
    [SerializeField] private Transform _playerTargetPosition;
    //[SerializeField] private Slider _bossHealthBar;
    [SerializeField] private float _speedChangeCameraPosition;
    [SerializeField] private float _speedChangePlayerPosition;
    [SerializeField] private Transform _camera;
    [SerializeField] private Transform _player;
    [SerializeField] private PlayerBehaviour _playerBehaviour;
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
        _playerBehaviour.StartPreFinishBehaviour();
        //_bossHealthBar.gameObject.SetActive(true);
        StartCoroutine(ChangeCameraPosition());
        StartCoroutine(ChangePlayerPosition());
        _camera.LookAt(transform.position);
    }

    private IEnumerator ChangePlayerPosition()
    {
        while (_player.position != _playerTargetPosition.position)
        {
            _player.position = Vector3.MoveTowards(_player.position, _playerTargetPosition.position, _speedChangePlayerPosition);
            yield return null;
        }
    }

    private IEnumerator ChangeCameraPosition()
    {
        while (_camera.position != _cameraTargetPosition.position)
        {
            _camera.position = Vector3.MoveTowards(_camera.position, _cameraTargetPosition.position, _speedChangeCameraPosition);
            yield return null;
        }
    }
}
