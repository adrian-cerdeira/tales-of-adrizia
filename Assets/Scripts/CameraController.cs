using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;

    private Vector3 _lastPlayerPosition;
    private float _distanceToMove;

    // Start is called before the first frame update
    void Start()
    {
        _lastPlayerPosition = target.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerController.IsDead) { return; }
        _distanceToMove = target.position.x - _lastPlayerPosition.x;
        transform.position = new Vector3(transform.position.x + _distanceToMove, transform.position.y, transform.position.z);
        _lastPlayerPosition = target.position;
    }
}
