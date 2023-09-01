using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : TriggerChecker
{
    [SerializeField] private BoxCollider2D _box2D;

    [SerializeField] private bool isColorOverall;
    [SerializeField] private bool isShapeOverall;

    Shake CameraShaker;
    AudioManager AM;

    private void Awake()
    {
        isColorOverall = true;
        isShapeOverall = true;

        if (this.gameObject.tag.ToString() == "Default") isColorOverall = false;
        if (LayerMask.LayerToName(this.gameObject.layer) == "Default") isShapeOverall = false;
    }

    private void Start()
    {
        CameraShaker = Shake.Instance;
        AM = AudioManager.Instance;
    }

    public override void CheckTriggerCondition(Collider2D collision)
    {
        if (isColorOverall)
        {
            if (!this.gameObject.CompareTag(collision.gameObject.tag))
            {
                CameraShaker.ShakeCamera();
                AM.PlayUmphSound();
                return;
            }
        }

        if (isShapeOverall)
        {
            if (this.gameObject.layer != collision.gameObject.layer)
            {
                CameraShaker.ShakeCamera();
                AM.PlayUmphSound();
                return;
            }
        }

        _box2D.enabled = false;
    }

    public override void CheckExitCondition(Collider2D collision)
    {
        _box2D.enabled = true;
    }
}
