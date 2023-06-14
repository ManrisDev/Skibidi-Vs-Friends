using UnityEngine;

public class Shop : MonoBehaviour
{

    [SerializeField] CoinManager _coinManager;
    PlayerModifier _playerModifier;

    private void Start()
    {
        _playerModifier = FindObjectOfType<PlayerModifier>();
    }

    public void BuyWidth()
    {
        if (_coinManager.NumberOfCoins >= 100)
        {
            _coinManager.SpendMoney(100);
            Progress.Instance.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.Width += 25;
            _playerModifier.SetWidth(Progress.Instance.Width);
            ForceManager.Instance.AddForce(25);
        }
    }

    public void BuyHeigth()
    {
        if (_coinManager.NumberOfCoins >= 100)
        {
            _coinManager.SpendMoney(100);
            Progress.Instance.Coins = _coinManager.NumberOfCoins;
            Progress.Instance.Height += 25;
            _playerModifier.SetHeight(Progress.Instance.Height);
            ForceManager.Instance.AddForce(25);
        }
    }

}
