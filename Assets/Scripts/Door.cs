using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerChecker
{
    [SerializeField] private BoxCollider2D _box2D;

    [SerializeField] private bool isColorOverall;
    [SerializeField] private bool isShapeOverall;

    private Animator _animator;

    Shake CameraShaker;
    AudioManager AM;

    private void Awake()
    {
        isColorOverall = true;
        isShapeOverall = true;

        if (gameObject.CompareTag("Default")) isColorOverall = false;
        if (gameObject.layer == 0) isShapeOverall = false;

        if (TryGetComponent(out Animator anim))
        {
            _animator = anim;
        }
    }

    private void Start()
    {
        CameraShaker = Shake.Instance;
        AM = AudioManager.Instance;
    }

    public override void ApplyEffect(Collider2D collision, bool conditionMet)
    {
        if(conditionMet)
        {
            if (_animator) _animator.SetBool("canPass", true);
            _box2D.enabled = false;
        }
        else
        {
            CameraShaker.ShakeCamera();
            AM.PlayUmphSound();
        }
        //if (isColorOverall)
        //{
        //    if (!this.gameObject.CompareTag(collision.gameObject.tag))
        //    {
        //        CameraShaker.ShakeCamera();
        //        AM.PlayUmphSound();
        //        return;
        //    }
        //}

        //if (isShapeOverall)
        //{
        //    if (this.gameObject.layer != collision.gameObject.layer)
        //    {
                
        //        return;
        //    }
        //}

        
    }

    public override void CheckExitCondition(Collider2D collision)
    {
        if (_animator) _animator.SetBool("canPass", false);
        _box2D.enabled = true;
    }

    public override bool CheckCondition(Collider2D collision)
    {
        bool condition1 = true;
        bool condition2 = true;

        if (isColorOverall)
        {
            condition1 = gameObject.CompareTag(collision.gameObject.tag);
        }
        if (isShapeOverall)
        {
            condition2 = gameObject.layer == collision.gameObject.layer;
        }

        return condition1 && condition2;
    }
}
