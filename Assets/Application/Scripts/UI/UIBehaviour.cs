using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIBehaviour : MonoBehaviour
{
    public static UIBehaviour Instance;

    [SerializeField] TextMeshProUGUI _levelText;

    [SerializeField] GameObject _startMenuPanel;
    [SerializeField] GameObject _inGamePanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _casesPanel;
    [SerializeField] GameObject _bossFightPanel;
    [SerializeField] GameObject _forceCanvas;

    [SerializeField] Button musicButton;
    [SerializeField] Button effectsButton;
    [SerializeField] Sprite notSprite;
    [SerializeField] Sprite yesSprite;

    private bool muteMusic = false;
    private bool muteEffects = false;

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
            image = musicButton.transform.GetChild(0).GetComponent<Image>();
            muteMusic = !muteMusic;
            state = muteMusic;
            SoundsManager.Instance.Mute(type, muteMusic);
        }
        else
        { 
            image = effectsButton.transform.GetChild(0).GetComponent<Image>();
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
        PlayerMove.Instance.StopMovement();
    }

    public void DamageBoss(int damage)
    {
        Boss.Instance.TakeDamage(damage);
    }

    public void Continue()
    {
        _gameOverPanel.SetActive(false);
        PlayerMove.Instance.ResumeMovement();
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        PlayerMove.Instance.StopMovement();
    }

    public void Restart()
    {
        LevelBehaviour.Instance.Restart();
    }

    public void Advertisement()
    {

    }
}
