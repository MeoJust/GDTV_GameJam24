using UnityEngine;

public class StartDefs : MonoBehaviour
{
[SerializeField] GameObject _defenderPrefab;

Waypoint _waypoint;

void Start(){

    _waypoint = GetComponent<Waypoint>();   

    Instantiate(_defenderPrefab, transform.position, Quaternion.Euler(0, 180, 0));

    _waypoint.IsPlaceable = false;
    _waypoint.IsWalkable = false;
}
}
