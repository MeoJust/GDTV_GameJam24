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

    // void OnEnable()
    // {
    //     StartCoroutine(Move());
    // }

    public IEnumerator Move()
    {
        foreach (var waypoint in _path)
        {
            if (waypoint.IsWalkable() && _isCanWalk)
            {
                Vector3 currentPos = transform.position;
                Vector3 targetPos = waypoint.transform.position;
                float precent = 0;
                while (precent < 1f)
                {
                    precent += Time.deltaTime * _speed;
                    transform.position = Vector3.Lerp(currentPos, targetPos, precent);
                    yield return new WaitForEndOfFrame();
                }
            }
            else{
                _isCanWalk = false;
                IsStuckAction.Invoke();
            }
        }
    }
}
