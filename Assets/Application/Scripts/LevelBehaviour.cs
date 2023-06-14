using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelBehaviour : MonoBehaviour
{
    public static LevelBehaviour Instance;

    [SerializeField] CoinManager _coinManager;

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
    }

    public void NextLevel()
    {
        int next = SceneManager.GetActiveScene().buildIndex + 1;
        if (next < SceneManager.sceneCountInBuildSettings) {
            _coinManager.SaveToProgress();
            SceneManager.LoadScene(next);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
