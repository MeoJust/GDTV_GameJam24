//I'm in a hurry
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartScreenManager : MonoBehaviour
{
    [SerializeField] float _delay = 5f;
    [SerializeField] GameObject[] _txts;

    [SerializeField] Button _skipBTN;
    [SerializeField] Button _continueBTN;

    void Start()
    {
        ShowTXT0();
        Invoke(nameof(ShowTXT1), _delay);
        Invoke(nameof(ShowTXT2), _delay * 2);
        Invoke(nameof(ShowTXT3), _delay * 3);
        Invoke(nameof(ShowTXT4), _delay * 4);
        Invoke(nameof(ShowTXT5), _delay * 5);
        Invoke(nameof(ShowTXT6), _delay * 6);

        Invoke(nameof(ShowContinueBTN), _delay * 7 + 5);

        _skipBTN.onClick.AddListener(NextScene);
        _continueBTN.onClick.AddListener(NextScene);

        _continueBTN.gameObject.SetActive(false);
    }

    void ShowTXT0()
    {
        _txts[0].SetActive(true);
    }
    void ShowTXT1()
    {
        _txts[1].SetActive(true);
    }
    void ShowTXT2()
    {
        _txts[2].SetActive(true);
    }
    void ShowTXT3()
    {
        _txts[3].SetActive(true);
    }
    void ShowTXT4()
    {
        _txts[4].SetActive(true);
    }
    void ShowTXT5()
    {
        _txts[5].SetActive(true);
    }
    void ShowTXT6()
    {
        _txts[6].SetActive(true);
    }

    void ShowContinueBTN()
    {
        _continueBTN.gameObject.SetActive(true);
    }

    void NextScene(){
        SceneManager.LoadScene("SetScene");
    }
}
