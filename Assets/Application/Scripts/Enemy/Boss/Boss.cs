using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Boss : MonoBehaviour
{
    public static Boss Instance;
    
    [SerializeField] private int _numberOfForce;
    [SerializeField] private TextMeshProUGUI _countForceText;
    [SerializeField] private ForceManager _forceManager;

    public event UnityAction<Boss> Fight;
    public event UnityAction<int> HealthChanged;
    public event UnityAction Die;

    public int Health { get; private set; } = 100;
    public int MaxHealth { get; private set; } = 100;
    public int MinHealth { get; private set; } = 0;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _countForceText.text = _numberOfForce.ToString();
    }

    public void TakeDamage(int amountDifference)
    {
        Health -= amountDifference;

        if (Health < MinHealth)
        {
            Health = MinHealth;
            Die?.Invoke();
        }

        HealthChanged?.Invoke(Health);
    }

    private void OnTriggerEnter(Collider other)
    {
        PlayerModifier playerModifier = FindObjectOfType<PlayerModifier>();

        if (playerModifier)
        {
            if (_numberOfForce < _forceManager.NumberOfForce)
            {
                Fight?.Invoke(this);
            }
            else if (_numberOfForce >= _forceManager.NumberOfForce)
            {
                UIBehaviour.Instance.GameOver();
            }
        }
    }
}
