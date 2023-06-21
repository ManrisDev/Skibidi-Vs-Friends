using TMPro;
using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using static UnityEditor.Progress;

public class CasesManager : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _adsButton;
    [SerializeField] private GameObject _exitButton;

    [Header("Random")]
    [SerializeField] private int _minValue = 100;
    [SerializeField] private int _maxValue = 200;

    [SerializeField] private GameObject[] _itemGameObjects;
    [SerializeField] private List<Item> _items = new();
    [SerializeField] private int _caseCount = 2;

    private int _openedCases = 0;
    private int _amount = 0;

    private void Start()
    {
        foreach (var itemGameObject in _itemGameObjects)
        {
            _items.Add(new Item
            {
                openImage = itemGameObject.transform.GetChild(0).GetComponent<Image>(),
                closedImage = itemGameObject.transform.GetChild(1).GetComponent<Image>(),
                textImage = itemGameObject.transform.GetChild(2).gameObject,
                adsIcon = itemGameObject.transform.GetChild(2).GetChild(1).gameObject,
                text = itemGameObject.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>(),
            });
        }

        GenerateCases();
    }

    public void GenerateCases()
    {
        foreach (var item in _items)
        {
            item.openImage.gameObject.SetActive(false);
            item.textImage.SetActive(false);

            item.value = UnityEngine.Random.Range(_minValue, _maxValue);
            item.text.text = item.value.ToString();
        }
    }

    public void OpenCase(int buttonId)
    {
        if (_openedCases < _caseCount + 1)
        {
            _items[buttonId].closedImage.gameObject.SetActive(false);
            _items[buttonId].openImage.gameObject.SetActive(true);
            _items[buttonId].textImage.SetActive(true);
            _items[buttonId].text.gameObject.SetActive(true);
            _items[buttonId].isOpened = true;

            _openedCases++;
            _amount += _items[buttonId].value;

            if (_openedCases == _caseCount)
            {
                SetAds();
            }
        }
        else if (!_items[buttonId].isOpened)
        {
            UIBehaviour.Instance.Advertisement();
            _items[buttonId].adsIcon.SetActive(false);
        }
    }

    public void SetAds()
    {
        foreach (var item in _items)
        {
            if (!item.isOpened)
            {
                item.textImage.SetActive(true);
                item.adsIcon.SetActive(true);
            }
        }

        _adsButton.SetActive(true);
        _exitButton.SetActive(true);
    }

    public void WatchAds()
    {
        UIBehaviour.Instance.Advertisement();
        _amount *= 2;
    }

    public void ExitCases()
    {
        Progress.Instance.Coins += _amount;
        UIBehaviour.Instance.UpdateCoins(Progress.Instance.Coins);
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
    public GameObject adsIcon;
    public TextMeshProUGUI text;
    public int value = 0;
    public bool isOpened = false;
}
