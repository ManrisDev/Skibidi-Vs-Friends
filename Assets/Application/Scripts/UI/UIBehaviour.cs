using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    [SerializeField] GameObject _joystickPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _startMenuPanel.SetActive(true);
        _joystickPanel.SetActive(false);
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        _startMenuPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        _forceCanvas.SetActive(true);
        _joystickPanel.SetActive(true);
        FindObjectOfType<PlayerBehaviour>().Play();
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

    public void DamageBoss(int damage)
    {
        Boss.Instance.TakeDamage(damage);
    }

    public void Continue()
    {
        _gameOverPanel.SetActive(false);
        _joystickPanel.SetActive(true);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
        _joystickPanel.SetActive(false);
    }

    public void Restart()
    {
        LevelBehaviour.Instance.Restart();
    }

    public void Advertisement()
    {

    }
}
