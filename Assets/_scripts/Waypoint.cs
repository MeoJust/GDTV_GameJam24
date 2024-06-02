using System;
using TMPro;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool _isPlaceable;
    [SerializeField] bool _isWalkable;
    [SerializeField] GameObject _placeTarget;
    [SerializeField] GameObject _knight;

    PointsManager _pointsManager;
    [SerializeField] GameObject _marksTXT;

    public Action<Waypoint> OnWayCleared;

    GameObject _targetInstance;

    void Start()
    {
        _pointsManager = FindObjectOfType<PointsManager>();

        if (_isPlaceable)
        {
            _targetInstance = Instantiate(_placeTarget, transform.position, Quaternion.identity);
            SetTheTarget(false);
        }

        SetMarks();
    }

    void OnMouseOver()
    {
        if (!_isPlaceable) { return; }

        SetTheTarget(true);

        //print("now hovering: " + transform.name);
        _placeTarget.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            if (_pointsManager.GetPoints < 20)
            {
                _pointsManager.ShowWarning();
                return;
            }

            //print("clicked: " + transform.name);
            GameObject knight = Instantiate(_knight, transform.position, Quaternion.Euler(0, 180, 0));
            _pointsManager.GetPoints -= 20;
            _pointsManager.UpdatePointsTXT();
            knight.GetComponent<Health>().OnDie += SetClear;
            _isPlaceable = false;
            _isWalkable = false;
        }
    }

    void OnMouseExit()
    {
        SetTheTarget(false);
    }

    void SetTheTarget(bool value)
    {
        if (_targetInstance)
            _targetInstance.SetActive(value);
    }

    void SetClear()
    {
        _isPlaceable = true;
        _isWalkable = true;

        OnWayCleared?.Invoke(this);
    }

    public bool IsWalkable
    {
        get => _isWalkable;
        set => _isWalkable = value;
    }

    public bool IsPlaceable
    {
        get => _isPlaceable;
        set => _isPlaceable = value;
    }

    void SetMarks()
    {
        _marksTXT.gameObject.SetActive(GameManager.Instance.IsShowMarks);
        print(GameManager.Instance.IsShowMarks);
    }
}
