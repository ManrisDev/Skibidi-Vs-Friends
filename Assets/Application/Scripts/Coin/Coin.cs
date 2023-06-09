using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{

    [SerializeField] private float _rotationSpeed;
    [SerializeField] private GameObject _effectPrefab;

    void Update()
    {
        transform.Rotate(0, _rotationSpeed * Time.deltaTime, 0);
    }

    private void OnTriggerEnter(Collider other)
    {
        FindObjectOfType<CoinManager>().AddOne();
        Destroy(gameObject);
        Instantiate(_effectPrefab, transform.position, transform.rotation);
    }

}
