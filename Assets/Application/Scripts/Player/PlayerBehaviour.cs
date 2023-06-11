using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _smoke;
    [SerializeField] PlayerMove _playerMove;
    //[SerializeField] PreFinishBehaviour _preFinishBehaviour;
    [SerializeField] Animator _animator;

    void Start()
    {
        //_playerMove.enabled = false;
        //_preFinishBehaviour.enabled = false;
    }

    public void Play() 
    {
        _smoke.SetActive(true);
        _playerMove.enabled = true;
    }

    public void StartPreFinishBehaviour() {
        _playerMove.enabled = false;
        //_preFinishBehaviour.enabled = true;
    }

    public void StartFinishBehaviour() {
        _playerMove.enabled = false;
        //_preFinishBehaviour.enabled = false;
        //_animator.SetTrigger("Dance");
        UIBehaviour.Instance.Victory();
    }
}
