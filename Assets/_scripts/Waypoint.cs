using System;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool _isPlaceable;
    [SerializeField] bool _isWalkable;
    [SerializeField] GameObject _placeTarget;
    [SerializeField] GameObject _knight;

    public Action<Waypoint> OnWayCleared;

    GameObject _targetInstance;

    void Start(){
        if(_isPlaceable){
        _targetInstance = Instantiate(_placeTarget, transform.position, Quaternion.identity);
        SetTheTarget(false);
        }
    }


    void OnMouseOver()
    {
        if (!_isPlaceable) { return; }

        SetTheTarget(true);

        //print("now hovering: " + transform.name);
        _placeTarget.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            //print("clicked: " + transform.name);
            GameObject knight = Instantiate(_knight, transform.position, Quaternion.Euler(0, 180, 0));
            knight.GetComponent<Health>().OnDie += SetClear;
            _isPlaceable = false;
            _isWalkable = false;
        }
    }

    void OnMouseExit()
    {
        SetTheTarget(false);
    }

    void SetTheTarget(bool value){
        if(_targetInstance)
            _targetInstance.SetActive(value);
    }

    void SetClear(){
        _isPlaceable = true;
        _isWalkable = true;

        OnWayCleared?.Invoke(this);
    }

    public bool IsWalkable() => _isWalkable;
}
