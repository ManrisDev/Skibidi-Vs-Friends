using TMPro;
using UnityEngine;

public class ForceManager : MonoBehaviour
{
    public static ForceManager Instance;

    [SerializeField] private int _numberOfForce;
    //[SerializeField] private TextMeshProUGUI _countForceInGameText;
    private TextMeshProUGUI _countForceUIText;
    public int NumberOfForce => _numberOfForce;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _countForceUIText = FindObjectOfType<UIBehaviour>().transform.GetChild(1).GetChild(1).GetComponent<TextMeshProUGUI>();
        //_countForceInGameText.text = _numberOfForce.ToString();
        _countForceUIText.text = _numberOfForce.ToString();
    }

    public void AddForce(int value)
    {
        _numberOfForce += value;
        //_countForceInGameText.text = _numberOfForce.ToString();
        _countForceUIText.text = _numberOfForce.ToString();
    }
}
