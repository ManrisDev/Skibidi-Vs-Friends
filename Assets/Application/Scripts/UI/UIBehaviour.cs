using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    public static UIBehaviour Instance;

    [SerializeField] TextMeshProUGUI _levelText;

    [SerializeField] GameObject _startMenuPanel;
    [SerializeField] GameObject _inGamePanel;
    [SerializeField] GameObject _finalPanel;
    [SerializeField] GameObject _gameOverPanel;
    [SerializeField] GameObject _casesPanel;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    private void Start()
    {
        _startMenuPanel.SetActive(true);
        _levelText.text = SceneManager.GetActiveScene().name;
    }

    public void Play()
    {
        _startMenuPanel.SetActive(false);
        _inGamePanel.SetActive(true);
        FindObjectOfType<PlayerBehaviour>().Play();
    }

    public void Victory()
    {
        _finalPanel.SetActive(true);
        _casesPanel.SetActive(true);
    }

    public void Continue()
    {
        _gameOverPanel.SetActive(false);
    }

    public void GameOver()
    {
        _gameOverPanel.SetActive(true);
    }

    public void Restart()
    {
        LevelBehaviour.Instance.Restart();
    }

    public void Adverisement()
    {

    }
}
