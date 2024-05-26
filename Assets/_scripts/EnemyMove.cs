using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour
{
    [SerializeField] List<Waypoint> _path = new List<Waypoint>();
    [SerializeField] float _speed = 1f;

    void Start(){
        StartCoroutine(Move());
    }

    IEnumerator Move(){
        foreach(var waypoint in _path){
            Vector3 currentPos = transform.position;
            Vector3 targetPos = waypoint.transform.position;
            float precent = 0;
            while(precent < 1f){
                precent += Time.deltaTime * _speed;
                transform.position = Vector3.Lerp(currentPos, targetPos, precent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
