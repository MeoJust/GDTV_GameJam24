using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    public List<Waypoint> Path = new List<Waypoint>();
    [SerializeField] float _speed = 1f;

    public Action IsStuckAction;

    bool _isCanWalk = true;
    int _currentWaypointIndex = 0;

    Waypoint _currentWaypoint;

    public IEnumerator Move()
    {
        for (int i = _currentWaypointIndex; i < Path.Count; i++)
        {
            Waypoint waypoint = Path[i];
            if (waypoint.IsWalkable && _isCanWalk)
            {
                Vector3 targetPos = waypoint.transform.position;
                yield return MoveTo(targetPos, waypoint);
                _currentWaypointIndex++;
            }
            else
            {
                _isCanWalk = false;
                IsStuckAction.Invoke();
                break;
            }
        }

        if (_currentWaypointIndex >= Path.Count)
        {
            Waypoint lastWaypoint = Path[Path.Count - 1];
            lastWaypoint.IsPlaceable = true;
        }
    }

    IEnumerator MoveTo(Vector3 targetPos, Waypoint currentWaypoint)
    {
        currentWaypoint.IsPlaceable = false;
        SetCurrentWaypoint(currentWaypoint);

        if (_currentWaypointIndex > 0)
        {
            Waypoint previousWaypoint = Path[_currentWaypointIndex - 1];
            previousWaypoint.IsPlaceable = true;
        }


        Vector3 currentPos = transform.position;
        float percent = 0;
        while (percent < 1f)
        {
            percent += Time.deltaTime * _speed;
            transform.position = Vector3.Lerp(currentPos, targetPos, percent);
            yield return new WaitForEndOfFrame();
        }
    }

    public void ResumeMove()
    {
        if (!_isCanWalk)
        {
            _isCanWalk = true;
            StartCoroutine(Move());
        }
    }

    public void SetIsCanWalk(bool value)
    {
        _isCanWalk = value;
    }

    public void SetCurrentWaypoint(Waypoint waypoint){
_currentWaypoint = waypoint;
    }

        public Waypoint GetCurrentWaypoint()
    {
return _currentWaypoint;
    }
}
