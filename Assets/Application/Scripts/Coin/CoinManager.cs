using UnityEngine;

public class CoinManager : MonoBehaviour
{
    public static CoinManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        UpdateView();
    }

    public void AddMoney(int value)
    {
        Progress.Instance.Coins += value;
        UpdateView();
    }

    // 1-width 2-height
    public void SpendMoney(int value, string typeOfReduction) {
        if (value <= Progress.Instance.Coins)
        {
            Progress.Instance.Coins -= value;
            if (typeOfReduction.Equals("width"))
            {
                ImprovementsBehaviour.Instance.IncreaseCostOfWidthImprovements();
                PlayerModifier.Instance.AddWidth(25);
            }
            else if (typeOfReduction.Equals("height"))
            {
                ImprovementsBehaviour.Instance.IncreaseCostOfHeightImprovements();
                PlayerModifier.Instance.AddHeight(25);
            }
            ForceManager.Instance.AddForce(25);

            UpdateView();
        }
    }

    public void UpdateView()
    {
        UIBehaviour.Instance.UpdateCoins(Progress.Instance.Coins);
    }
}
