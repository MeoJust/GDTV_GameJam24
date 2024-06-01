using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PointsManager : MonoBehaviour
{
    [SerializeField] int _startPoints = 400;

    [SerializeField] TextMeshProUGUI _pointsTXT;
    [SerializeField] TextMeshProUGUI _zumbyTXT;
    [SerializeField] GameObject _warningTXTGO;
    [SerializeField] Button _addPointsBTN;

    int _points;
    int _zumbyCount = 100;

    void Start()
    {
        _warningTXTGO.SetActive(false);

        _points = _startPoints;
        _zumbyTXT.text = _zumbyCount.ToString();
        UpdatePointsTXT();

        _addPointsBTN.onClick.AddListener(AddPoints);
    }

    public void UpdatePointsTXT()
    {
        _pointsTXT.text = _points.ToString();
    }

    public void UpdateZumbyCount()
    {
        _zumbyCount -= 1;
        _zumbyTXT.text = _zumbyCount.ToString();
    }

    void AddPoints()
    {
        _points += 1;
        UpdatePointsTXT();
    }

    public int GetPoints
    {
        get => _points;
        set => _points = value;
    }

    public int GetZumbyCount{
        get => _zumbyCount;
        set => _zumbyCount = value;
    }

    
    public void ShowWarning(){
        _warningTXTGO.SetActive(true);
        Invoke(nameof(HideWarning), 1f);
    }

    void HideWarning(){
        _warningTXTGO.SetActive(false);
    }
}
