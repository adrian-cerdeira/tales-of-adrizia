using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationController : MonoBehaviour
{
    public AnimationClip anim;
    public float additionalWait = 0f;

    private Animator _animator;
    private float _waitTime;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        _waitTime = anim.length + additionalWait;
        InvokeRepeating("PlayAnim", additionalWait, _waitTime);

    }

    void PlayAnim()
    {
        _animator.SetTrigger("Blink");
    }
}
