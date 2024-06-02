using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetSceneManager : MonoBehaviour
{
    [SerializeField] Button _enableBTN;
    [SerializeField] Button _disableBTN;

    void Start()
    {
        Time.timeScale = 1f;

        _enableBTN.onClick.AddListener(() => SetMarks(true));
        _disableBTN.onClick.AddListener(() => SetMarks(false));
    }

    void SetMarks(bool value)
    {
        GameManager.Instance.IsShowMarks = value;
        print("set marks: " + value);
        SceneManager.LoadScene("SampleScene");
    }
}