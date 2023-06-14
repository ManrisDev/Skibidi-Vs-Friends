using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] GameObject _smoke;
    [SerializeField] PlayerMove _playerMove;

    void Start() => _playerMove.enabled = false;

    public void Play() 
    {
        _smoke.SetActive(true);
        _playerMove.enabled = true;
    }

    public void StartFinishBehaviour() {
        _playerMove.enabled = false;
        UIBehaviour.Instance.Victory();
    }
}
