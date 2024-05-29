using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> _path = new List<Waypoint>();
    [SerializeField] float _speed = 1f;

    public Action IsStuckAction;

    bool _isCanWalk = true;
    int _currentWaypointIndex = 0;

    public IEnumerator Move()
    {
        for (int i = _currentWaypointIndex; i < _path.Count; i++)
        {
            Waypoint waypoint = _path[i];
            if (waypoint.IsWalkable() && _isCanWalk)
            {
                Vector3 targetPos = waypoint.transform.position;
                yield return MoveTo(targetPos);
                _currentWaypointIndex++;
            }
            else
            {
                _isCanWalk = false;
                IsStuckAction.Invoke();
                break;
            }
        }
    }

    IEnumerator MoveTo(Vector3 targetPos)
    {
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
}
