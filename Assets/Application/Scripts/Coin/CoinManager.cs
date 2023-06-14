using TMPro;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    public int NumberOfCoins;
    [SerializeField] private TextMeshProUGUI _text;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        NumberOfCoins = Progress.Instance.Coins;
        _text.text = NumberOfCoins.ToString();
    }

    public void AddOne()
    {
        NumberOfCoins += 1;
        _text.text = NumberOfCoins.ToString();
    }

    public void SaveToProgress() {
        Progress.Instance.Coins = NumberOfCoins;
    }

    public void SpendMoney(int value) {
        NumberOfCoins -= value;
        _text.text = NumberOfCoins.ToString();
    }

}
