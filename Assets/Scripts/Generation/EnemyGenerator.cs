using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public ObjectPooler pooler;
    public Transform spawnPoint;

    public float respawnTimer;

    public Transform maxHeightPoint;
    public float maxHeightChange;

    private float _heightChange;
    private float _minHeight;
    private float _maxHeight;

    private float _respawnCounter;

    // Start is called before the first frame update
    void Start()
    {
        _respawnCounter = respawnTimer;

        _minHeight = spawnPoint.transform.position.y;
        _maxHeight = maxHeightPoint.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsDead) { return; }

        if(_respawnCounter <= 0)
        {
            _heightChange = spawnPoint.transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if(_heightChange > _maxHeight) { _heightChange = _maxHeight; }
            else if(_heightChange < _minHeight) { _heightChange = _minHeight; }


            GameObject enemy = pooler.GetPooledObject();
            enemy.GetComponent<EnemyController>().UpdateSpeed();
            enemy.transform.position = new Vector3(spawnPoint.transform.position.x, _heightChange, transform.position.z);
            enemy.transform.rotation = transform.rotation;
            enemy.SetActive(true);

            _respawnCounter = respawnTimer;
        }
        else
        {
            _respawnCounter -= Time.deltaTime;
        }
    }
}