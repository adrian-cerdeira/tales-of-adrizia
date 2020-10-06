using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour
{
    public ObjectPooler[] pools;
    public Transform spawnPoint;

    public float minDistance;
    public float maxDistance;

    public Transform maxHeightPoint;
    public float maxHeightChange;

    private float _distanceBetween;
    private float[] _platformWidths;

    private float _minHeight;
    private float _maxHeight;
    private float _heightChange;

    // Start is called before the first frame update
    void Start()
    {
        _platformWidths = new float[pools.Length];

        for (int i = 0; i < pools.Length; i++)
        {
            _platformWidths[i] = pools[i].GetPooledObject().GetComponent<BoxCollider2D>().size.x;
        }

        _minHeight = transform.position.y;
        _maxHeight = maxHeightPoint.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsDead) { return; }

        if (transform.position.x < spawnPoint.position.x)
        {
            int selector = Random.Range(0, pools.Length);
            _distanceBetween = Random.Range(minDistance, maxDistance);

            _heightChange = transform.position.y + Random.Range(maxHeightChange, -maxHeightChange);

            if (_heightChange > _maxHeight)
            {
                _heightChange = _maxHeight;
            }
            else if (_heightChange < _minHeight)
            {
                _heightChange = _minHeight;
            }

            transform.position = new Vector3(transform.position.x + (_platformWidths[selector] / 2) + _distanceBetween, _heightChange, transform.position.z);

            GameObject newPlatform = pools[selector].GetPooledObject();
            newPlatform.transform.position = transform.position;
            newPlatform.transform.rotation = transform.rotation;
            newPlatform.SetActive(true);
        }
    }
}
