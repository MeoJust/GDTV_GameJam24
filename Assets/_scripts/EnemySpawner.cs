using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<Waypoint> _path = new List<Waypoint>();

    [SerializeField] float _startDelayMin = 3f;
    [SerializeField] float _startDelayMax = 7f;

    [SerializeField] float _timeStartMin = 3f;
    [SerializeField] float _timeStartMax = 7f;

    [SerializeField] GameObject _enemyPrefab;

    PointsManager _pointsManager;

    void Awake()
    {
        _pointsManager = FindObjectOfType<PointsManager>();

    }

    void Start()
    {
        SpawnRandom();
    }

    void SpawnDatThings()
    {
        if (_pointsManager.GetZumbyCount <= 0) return;

        GameObject _enemy = Instantiate(_enemyPrefab, transform.position, Quaternion.identity);
        _enemy.GetComponent<EnemyMove>().Path = _path;

        _pointsManager.UpdateZumbyCount();
    }

    void SpawnRandom()
    {
        float spawnInterval = Random.Range(_timeStartMin, _timeStartMax);
        float startDelay = Random.Range(_startDelayMin, _startDelayMax);
        InvokeRepeating(nameof(SpawnDatThings), startDelay, spawnInterval);

    }
}