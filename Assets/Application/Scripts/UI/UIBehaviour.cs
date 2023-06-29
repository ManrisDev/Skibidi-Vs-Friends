using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public static UIBehaviour Instance;

    [Header("Panels")]
    [SerializeField] GameObject _startMenuPanel;
    [SerializeField] GameObject _inGamePanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _casesPanel;
    [SerializeField] GameObject _bossFightPanel;
    [SerializeField] GameObject _joystickPanel;

    [Header("Player")]
    [SerializeField] GameObject _forceCanvas;
    [SerializeField] TextMeshProUGUI _levelText;
    [SerializeField] TextMeshProUGUI _coinText;
    [SerializeField] TextMeshProUGUI _widthCostText;
    [SerializeField] TextMeshProUGUI _heightCostText;

    [Header("Sound")]
    [SerializeField] Button musicButton;
    [SerializeField] Button effectsButton;
    [SerializeField] Sprite notSprite;
    [SerializeField] Sprite yesSprite;

    [Header("Game Over Panel")]
    [SerializeField] GameObject _continueButton;
    [SerializeField] GameObject _restartButton;

    private bool muteMusic = false;
    private bool muteEffects = false;

    private readonly string WidthType = "width";
    private readonly string HeightType = "height";

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _startMenuPanel.SetActive(true);
        PlayerMove.Instance.StopMovement();
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        _startMenuPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _forceCanvas.SetActive(true);
        PlayerMove.Instance.ResumeMovement();
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void Mute(string type)
    {
        Image image;
        bool state;
        if (type.Equals("music"))
        {
            image = musicButton.transform.GetChild(1).GetComponent<Image>();
            muteMusic = !muteMusic;
            state = muteMusic;
            SoundsManager.Instance.Mute(type, muteMusic);
        }
        else
        { 
            image = effectsButton.transform.GetChild(1).GetComponent<Image>();
            muteEffects = !muteEffects;
            state = muteEffects;
            SoundsManager.Instance.Mute(type, muteEffects);
        }

        if (!state)
            image.sprite = yesSprite;
        else
            image.sprite = notSprite;
    }

    public void Victory()
    {
        _bossFightPanel.SetActive(false);
        _casesPanel.SetActive(true);
    }

    public void BossFight()
    {
        _bossFightPanel.SetActive(true);
        _joystickPanel.SetActive(false);
    }



    public void Continue()
    {
        _gameOverPanel.SetActive(false);
        _joystickPanel.SetActive(true);
        PlayerModifier.Instance.Reberth();
        PlayerMove.Instance.ResumeMovement();
    }

    public void GameOver(bool _isBoss)
    {
        if (_isBoss)
            BlockContinueButton();

        _gameOverPanel.SetActive(true);
        _joystickPanel.SetActive(false);
        PlayerMove.Instance.StopMovement();
    }

    private void BlockContinueButton()
    {
        _continueButton.SetActive(false);
        _restartButton.GetComponent<RectTransform>().localPosition = new Vector3(0, -440, 0);
    }

    public void Restart()
    {
        LevelBehaviour.Instance.Restart();
    }

    public void Advertisement()
    {
        Debug.Log("Показываю рекламу");
    }

    public void UpdateCoins(int count)
    {
        _coinText.text = count.ToString();
    }

    public void UpdateWidthCost(int cost)
    {
        _widthCostText.text = cost.ToString();
    }

    public void UpdateHeightCost(int cost)
    {
        _heightCostText.text = cost.ToString();
    }

    public void HeightIncrease()
    {
        CoinManager.Instance.SpendMoney(ImprovementsBehaviour.Instance.CostOfHeightImprovements, HeightType);
        SoundsManager.Instance.PlaySound("Increase");
    }

    public void WidthIncrease()
    {
        CoinManager.Instance.SpendMoney(ImprovementsBehaviour.Instance.CostOfWidthImprovements, WidthType);
        SoundsManager.Instance.PlaySound("Increase");
    }
}
