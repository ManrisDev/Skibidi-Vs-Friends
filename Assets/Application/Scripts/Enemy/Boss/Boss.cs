using TMPro;
using UnityEngine;

public class Boss : MonoBehaviour
{
    [SerializeField] private int _numberOfForce;
    [SerializeField] private TextMeshProUGUI _countForceText;

    private void Start()
    {
        _countForceText.text = _numberOfForce.ToString();
    }

    private void OnTriggerEnter(Collider other)
    {
    }
}
