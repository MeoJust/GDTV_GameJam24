using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] GameObject[] _grounds;

    int _killCount = 0;

    void Start()
    {
        HideGrounds();
        ShowGrounds();
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
    }
}
