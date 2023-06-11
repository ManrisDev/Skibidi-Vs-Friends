using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;

public class CasesManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _adsButton;
    [SerializeField] private GameObject _exitButton;

    [Header("Random")]
    [SerializeField] private int minValue = 100;
    [SerializeField] private int maxValue = 200;

    [SerializeField] private Item[] items;
    [SerializeField] private int caseCount = 3;
    private int openedCases = 0;

    private void Start()
    {
        GenerateCases();
    }

    public void GenerateCases()
    {
        int randomValue;
        foreach (var item in items)
        {
            item.openImage.gameObject.SetActive(false);
            item.textImage.gameObject.SetActive(false);

            randomValue = UnityEngine.Random.Range(minValue, maxValue);
            item.text.text = randomValue.ToString();
        }
    }

    public void OpenCase(int buttonId)
    {
        if (openedCases != caseCount)
        {
            items[buttonId].closedImage.gameObject.SetActive(false);
            items[buttonId].openImage.gameObject.SetActive(true);
            items[buttonId].textImage.gameObject.SetActive(true);
            items[buttonId].text.gameObject.SetActive(true);
            items[buttonId].isOpened = true;
            openedCases++;
            if (openedCases == caseCount)
            {
                SetAds();
            }
        }
    }

    public void SetAds()
    {
        foreach (var item in items)
        {
            if (!item.isOpened)
            {
                item.textImage.gameObject.SetActive(true);
                item.adsIcon.gameObject.SetActive(true);
            }
        }

        _adsButton.SetActive(true);
        _exitButton.SetActive(true);
    }

    public void WatchAds()
    {
        UIBehaviour.Instance.Advertisement();
    }

    public void ExitCases()
    {
        gameObject.SetActive(false);
        LevelBehaviour.Instance.NextLevel();
    }
}

[Serializable]
public class Item
{
    public Image closedImage;
    public Image openImage;
    public GameObject textImage;
    public TextMeshProUGUI text;
    public GameObject adsIcon;
    public bool isOpened = false;
}
