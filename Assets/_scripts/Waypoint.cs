using UnityEngine;

public class Waypoint : MonoBehaviour
{
    [SerializeField] bool _isPlaceable;
    [SerializeField] GameObject _placeTarget;

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

        print("now hovering: " + transform.name);
        _placeTarget.transform.position = transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            print("clicked: " + transform.name);
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
}
