using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    // Speed
    public static float speedIncrease;
    public float speed;

    // Physics
    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();

        speed *= speedIncrease;
    }

    // Update is called once per frame
    void Update()
    {
        _rb2d.velocity = new Vector2(-speed, _rb2d.velocity.y);
    }

    public void UpdateSpeed()
    {
        speed *= speedIncrease;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            PlayerController p = collision.gameObject.GetComponent<PlayerController>();

            if (p)
            {
                p.Death();
            }
        }
    }
}
