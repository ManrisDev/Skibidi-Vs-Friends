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
        _bossFightPanel.SetActive(false);
        _casesPanel.SetActive(true);
    }

    public void BossFight()
    {
        _bossFightPanel.SetActive(true);
    }

    public void DamageBoss(int damage)
    {
        Boss.Instance.TakeDamage(damage);
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

    public void Advertisement()
    {

    }
}
