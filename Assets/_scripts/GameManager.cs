using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

public bool IsShowMarks = false;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
