using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _Spawn1, _Spawn2, _Spawn3, _Spawn4;
    public GameObject _Bat;

    private GameObject _EnemySpawnedAt1, _EnemySpawnedAt2, _EnemySpawnedAt3, _EnemySpawnedAt4;
    private VariablesForEachSpawn _Spawn1Variables, _Spawn2Variables, _Spawn3Variables, _Spawn4Variables;
    private int _randomInt;

    //First, grabs our scripts from each respective spawn, then uses/sets their respective variables
    void Start()
    {
        _Spawn1Variables = _Spawn1.GetComponent<VariablesForEachSpawn>();
        _Spawn2Variables = _Spawn2.GetComponent<VariablesForEachSpawn>();
        _Spawn3Variables = _Spawn3.GetComponent<VariablesForEachSpawn>();
        _Spawn4Variables = _Spawn4.GetComponent<VariablesForEachSpawn>();

        _randomInt = Random.Range(0, 4);
        StartCoroutine(attemptToSpawnAtPosition(_randomInt));
    }

    void Update() {
        freeUnusedLanes();
    }

    //Allows enemies to spawn in empty lanes
    private void freeUnusedLanes()
    {
        if (_Spawn1Variables.spawnedEnemy == null)
            _Spawn1Variables.spawnLocked = false;

        if (_Spawn2Variables.spawnedEnemy == null)
            _Spawn2Variables.spawnLocked = false;

        if (_Spawn3Variables.spawnedEnemy == null)
            _Spawn3Variables.spawnLocked = false;

        if (_Spawn4Variables.spawnedEnemy == null)
            _Spawn4Variables.spawnLocked = false;
    }

    //Recursively attempts to spawn enemies :)
    private IEnumerator attemptToSpawnAtPosition(int _spawnPosition)
    {
        yield return new WaitForSeconds(4);
        if (_spawnPosition==0 && !_Spawn1Variables.spawnLocked) {
            _EnemySpawnedAt1 = Instantiate(_Bat, _Spawn1.transform.position, Quaternion.identity);
            _Spawn1Variables.spawnedEnemy = _EnemySpawnedAt1;
            _Spawn1Variables.spawnLocked = true;
        }
        else if (_spawnPosition == 1 && !_Spawn2Variables.spawnLocked) {
            _EnemySpawnedAt2 = Instantiate(_Bat, _Spawn2.transform.position, Quaternion.identity);
            _Spawn2Variables.spawnedEnemy = _EnemySpawnedAt2;
            _Spawn2Variables.spawnLocked = true;
        }
        else if (_spawnPosition == 2 && !_Spawn3Variables.spawnLocked)
        {
            _EnemySpawnedAt3 = Instantiate(_Bat, _Spawn3.transform.position, Quaternion.identity);
            _Spawn3Variables.spawnedEnemy = _EnemySpawnedAt3;
            _Spawn3Variables.spawnLocked = true;
        }
        else if (_spawnPosition == 3 && !_Spawn4Variables.spawnLocked)
        {
            _EnemySpawnedAt4 = Instantiate(_Bat, _Spawn4.transform.position, Quaternion.identity);
            _Spawn4Variables.spawnedEnemy = _EnemySpawnedAt4;
            _Spawn4Variables.spawnLocked = true;
        }

        _randomInt = Random.Range(0, 4);
        StartCoroutine(attemptToSpawnAtPosition(_randomInt));
    }
}