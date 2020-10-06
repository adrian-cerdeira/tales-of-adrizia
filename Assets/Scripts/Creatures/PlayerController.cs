using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Speed
    public float walkSpeed = 5;
    public float autoSpeed = 5;
    public float speedMultiplier;

    public float mileStoneIncrease;
    private float _mileStoneCounter;

    // Jump
    public float jumpForce = 5;
    public float jumpTime;

    private bool _jumped;
    private float _curJumpTime;

    // Ground Detection
    public LayerMask groundMask;
    public float groundMaskRadius;
    public Transform groundCheck;
    private bool _grounded;

    // Death
    public static bool IsDead = false;

    public AudioSource deathSound;

    private Transform _deathZone;

    // Physics
    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        IsDead = false;
        _rb2d = GetComponent<Rigidbody2D>();
        _deathZone = GameObject.Find("DestroyPoint").transform;
        _curJumpTime = jumpTime;

        _mileStoneCounter = mileStoneIncrease;

        EnemyController.speedIncrease = speedMultiplier;
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsDead)
        {
            _grounded = Physics2D.OverlapCircle(groundCheck.position, groundMaskRadius, groundMask);

            if(transform.position.x > _mileStoneCounter)
            {
                _mileStoneCounter += mileStoneIncrease;

                mileStoneIncrease *= speedMultiplier;
                EnemyController.speedIncrease *= speedMultiplier;

                autoSpeed *= speedMultiplier;
                walkSpeed *= speedMultiplier;
            }

            _rb2d.velocity = new Vector2(autoSpeed, _rb2d.velocity.y);

            Moving();
            Jumping();

            if(transform.position.y <= _deathZone.position.y && !IsDead)
            {
                Death();
            }
        }
    }

    private void Moving()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        if (moveX != 0)
        {
            transform.Translate(new Vector2(moveX * walkSpeed * Time.deltaTime, 0));
        }
    }

    private void Jumping()
    {
        if (Input.GetKey(KeyCode.Space) && _grounded)
        {
            _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
            _jumped = true;
        }

        if (Input.GetKey(KeyCode.Space) && _jumped)
        {
            if (_curJumpTime > 0)
            {
                _rb2d.velocity = new Vector2(_rb2d.velocity.x, jumpForce);
                _curJumpTime -= Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.Space))
        {
            _curJumpTime = 0;
            _jumped = false;
        }

        if (_grounded)
        {
            _curJumpTime = jumpTime;
        }
    }

    public void Death()
    {
        
        IsDead = true;
        _rb2d.velocity = Vector2.zero;
        _rb2d.angularVelocity = 0;

        if (!deathSound.isPlaying)
        {
            StartCoroutine(PlayDeath());
        }
    }

    IEnumerator PlayDeath()
    {
        LevelController.LevelAudio.Stop();
        deathSound.Play();

        yield return new WaitWhile(() => deathSound.isPlaying);

        SceneManager.LoadScene(2);
    }
}