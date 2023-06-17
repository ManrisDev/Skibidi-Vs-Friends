using UnityEngine;

public class Progress : MonoBehaviour
{
    public static Progress Instance;

    public int Coins = 1000;

    private void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
