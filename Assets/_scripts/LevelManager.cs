using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] _grounds;

    [SerializeField] GameObject _levelCNV;
    [SerializeField] GameObject _winCNV;
    [SerializeField] GameObject _loseCNV;

    [SerializeField] Button _restartBTN;

    int _killCount = 0;

    void Start()
    {
        HideGrounds();
        ShowGrounds();

        _restartBTN.onClick.AddListener(Restart);

        _winCNV.SetActive(false);
        _loseCNV.SetActive(false);
    }

    void HideGrounds()
    {
        foreach (var ground in _grounds)
        {
            ground.SetActive(false);
        }
    }

    void ShowGrounds()
    {
        int _groundNum = Random.Range(0, _grounds.Length);
        _grounds[_groundNum].SetActive(true);
    }

    public void CountDatKills(){
        _killCount++;
        print("num of kills: " +_killCount);
        if (_killCount == 100){
            Win();
        }
    }

    void Restart(){
        SceneManager.LoadScene("SetScene");
    }

    public void Lose(){
        _levelCNV.SetActive(false);
        _loseCNV.SetActive(true);
        Time.timeScale = 0f;
    }

    void Win(){
        _levelCNV.SetActive(false);
        _winCNV.SetActive(true);
        Time.timeScale = 0f;
    }
}
