using UnityEngine;

public class PlayerModifier : MonoBehaviour
{

    [SerializeField] int _width;
    [SerializeField] int _height;
    float _widthMultiplier = 0.003f;
    float _heightMultiplier = 0.003f;
    [SerializeField] Renderer _renderer;
    [SerializeField] Transform _colliderTransform;
    [SerializeField] Transform _playerModel;

    [SerializeField] AudioSource _increaseSound;

    private void Start()
    {
        //SetWidth(Progress.Instance.Width);
        //SetHeight(Progress.Instance.Height);
    }

    void Update()
    {
        _playerModel.localScale = new Vector3(1.0f + _width * _widthMultiplier, 1.0f + _height * _heightMultiplier, 1.0f + _width * _widthMultiplier);
        _colliderTransform.localScale = new Vector3(1.0f + _width * _widthMultiplier, 1.0f + _height * _heightMultiplier, 1.0f + _width * _widthMultiplier);
    }

    public void AddWidth(int value)
    {
        _width += value;
        //UpdateWidth();
        if (value > 0)
        {
            _increaseSound.Play();
        }
    }

    public void AddHeight(int value)
    {
        _height += value;
        if (value > 0)
        {
            _increaseSound.Play();
        }
    }

    public void SetWidth(int value)
    {
        _width = value;
        //UpdateWidth();
    }

    public void SetHeight(int value)
    {
        _height = value;
    }

    public void HitBarrier()
    {
        if (_height > 0)
        {
            _height -= 50;
        }
        else if (_width > 0)
        {
            _width -= 50;
            UpdateWidth();
        }
        else
        {
            Die();
        }
    }

    void UpdateWidth()
    {
        _renderer.material.SetFloat("_PushValue", _width * _widthMultiplier);
    }

    public void Die()
    {
        UIBehaviour.Instance.GameOver();
        Destroy(gameObject);
    }
}
