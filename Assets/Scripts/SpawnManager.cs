using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject _Spawn1, _Spawn2, _Spawn3, _Spawn4;
    public GameObject _Bat, _Pumpkin, _Witch, _Wraith;
    GameObject _EnemyChosen;

    private GameObject _EnemySpawnedAt1, _EnemySpawnedAt2, _EnemySpawnedAt3, _EnemySpawnedAt4;
    private VariablesForEachSpawn _Spawn1Variables, _Spawn2Variables, _Spawn3Variables, _Spawn4Variables;
    public static bool _miniBossSpawned;
    private int _randomLocation, _randomEnemy, _currentScoreTier;

    //First, grabs our scripts from each respective spawn, then uses/sets their respective variables
    void Start()
    {
        _Spawn1Variables = _Spawn1.GetComponent<VariablesForEachSpawn>();
        _Spawn2Variables = _Spawn2.GetComponent<VariablesForEachSpawn>();
        _Spawn3Variables = _Spawn3.GetComponent<VariablesForEachSpawn>();
        _Spawn4Variables = _Spawn4.GetComponent<VariablesForEachSpawn>();

        _miniBossSpawned = false;
        _currentScoreTier = 0;
        _randomLocation = Random.Range(0, 4);
        _randomEnemy = Random.Range(0, 4);
        StartCoroutine(attemptToSpawnAtPosition(_randomLocation,_randomEnemy));
    }

    void Update() {
        freeUnusedLanes();
    }

    //Allows enemies to spawn in empty lanes
    private void freeUnusedLanes()
    {
        if (!_miniBossSpawned) {
            if (_Spawn1Variables.spawnedEnemy == null)
                _Spawn1Variables.spawnLocked = false;

            if (_Spawn2Variables.spawnedEnemy == null)
                _Spawn2Variables.spawnLocked = false;

            if (_Spawn3Variables.spawnedEnemy == null)
                _Spawn3Variables.spawnLocked = false;

            if (_Spawn4Variables.spawnedEnemy == null)
                _Spawn4Variables.spawnLocked = false;
        }
    }

    //Recursively attempts to randomly spawn enemies as long as the game is active :)
    private IEnumerator attemptToSpawnAtPosition(int _spawnPosition, int _enemyIndex)
    {
        _randomLocation = Random.Range(0, 4);
        _randomEnemy = Random.Range(0, 4);

        if (PlaneController._gameIsActive)
        {
            yield return new WaitForSeconds(2);

            if (_enemyIndex == 0)
                _EnemyChosen = _Bat;
            else if (_enemyIndex == 1)
                _EnemyChosen = _Pumpkin;
            else if (_enemyIndex == 2)
                _EnemyChosen = _Witch;
            else if (_enemyIndex == 3)
                _EnemyChosen = _Wraith;

            if (scorePermitsMiniBoss() && !_miniBossSpawned) {
                StartCoroutine(despawnAllEnemies());
                _miniBossSpawned = true;
                _EnemySpawnedAt3 = Instantiate(_EnemyChosen, _Spawn3.transform.position, Quaternion.identity);
                //_Spawn3Variables.spawnedEnemy = _EnemySpawnedAt3;
            }
            else {
                if (_spawnPosition == 0 && !_Spawn1Variables.spawnLocked)
                {
                    _EnemySpawnedAt1 = Instantiate(_EnemyChosen, _Spawn1.transform.position, Quaternion.identity);
                    _Spawn1Variables.spawnedEnemy = _EnemySpawnedAt1;
                    _Spawn1Variables.spawnLocked = true;
                }
                else if (_spawnPosition == 1 && !_Spawn2Variables.spawnLocked)
                {
                    _EnemySpawnedAt2 = Instantiate(_EnemyChosen, _Spawn2.transform.position, Quaternion.identity);
                    _Spawn2Variables.spawnedEnemy = _EnemySpawnedAt2;
                    _Spawn2Variables.spawnLocked = true;
                }
                else if (_spawnPosition == 2 && !_Spawn3Variables.spawnLocked)
                {
                    _EnemySpawnedAt3 = Instantiate(_EnemyChosen, _Spawn3.transform.position, Quaternion.identity);
                    _Spawn3Variables.spawnedEnemy = _EnemySpawnedAt3;
                    _Spawn3Variables.spawnLocked = true;
                }
                else if (_spawnPosition == 3 && !_Spawn4Variables.spawnLocked)
                {
                    _EnemySpawnedAt4 = Instantiate(_EnemyChosen, _Spawn4.transform.position, Quaternion.identity);
                    _Spawn4Variables.spawnedEnemy = _EnemySpawnedAt4;
                    _Spawn4Variables.spawnLocked = true;
                }
            }
        }
        else
        {
            StartCoroutine(despawnAllEnemies());

            //In case a restart is called by the player:
            yield return new WaitForSeconds(5);
        }
        StartCoroutine(attemptToSpawnAtPosition(_randomLocation, _randomEnemy));
    }

    private IEnumerator despawnAllEnemies()
    {
        if (_Spawn1Variables.spawnedEnemy != null)
        {
            _Spawn1Variables.spawnedEnemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            _Spawn1Variables.spawnedEnemy.GetComponent<Collider2D>().enabled = false;
        }

        if (_Spawn2Variables.spawnedEnemy != null)
        {
            _Spawn2Variables.spawnedEnemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            _Spawn2Variables.spawnedEnemy.GetComponent<Collider2D>().enabled = false;
        }

        if (_Spawn3Variables.spawnedEnemy != null)
        {
            _Spawn3Variables.spawnedEnemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            _Spawn3Variables.spawnedEnemy.GetComponent<Collider2D>().enabled = false;
        }

        if (_Spawn4Variables.spawnedEnemy != null)
        {
            _Spawn4Variables.spawnedEnemy.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            _Spawn4Variables.spawnedEnemy.GetComponent<Collider2D>().enabled = false;
        }

        if (_miniBossSpawned)
        {
            _EnemySpawnedAt3.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, .5f);
            _EnemySpawnedAt3.GetComponent<Collider2D>().enabled = false;
        }

        yield return new WaitForSeconds(.5f);
        if (_Spawn1Variables.spawnedEnemy != null)
            Destroy(_Spawn1Variables.spawnedEnemy);
        if (_Spawn2Variables.spawnedEnemy != null)
            Destroy(_Spawn2Variables.spawnedEnemy);
        if (_Spawn3Variables.spawnedEnemy != null)
            Destroy(_Spawn3Variables.spawnedEnemy);
        if (_Spawn4Variables.spawnedEnemy != null)
            Destroy(_Spawn4Variables.spawnedEnemy);
        if (_miniBossSpawned)
            Destroy(_EnemySpawnedAt3);

        _Spawn1Variables.spawnLocked = true;
        _Spawn2Variables.spawnLocked = true;
        _Spawn3Variables.spawnLocked = true;
        _Spawn4Variables.spawnLocked = true;
    }

    private bool scorePermitsMiniBoss()
    {
        int scoreDifference = ScoreManager._score - _currentScoreTier;
        if (scoreDifference >= 2000)
        {
            _currentScoreTier = ScoreManager._score;
            return true;
        }
        return false;
    }
}