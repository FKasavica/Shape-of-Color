using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Button : TriggerChecker
{
    [SerializeField] private Color _color;
    [SerializeField] private string _shape;

    private SpriteRenderer _spriteRenderer;
    SpriteController _player;

    [SerializeField] private bool isColorOverall;
    [SerializeField] private bool isShapeOverall;
    private void Awake()
    {
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        isColorOverall = true;
        isShapeOverall = true;

        if (this.gameObject.tag.ToString() == "Default") isColorOverall = false;
        if (LayerMask.LayerToName(this.gameObject.layer) == "Default") isShapeOverall = false;

        if (this.gameObject.tag.ToString() == "Red") _spriteRenderer.color = Color.red;
        if (this.gameObject.tag.ToString() == "Blue") _spriteRenderer.color = Color.blue;
        if (this.gameObject.tag.ToString() == "Yellow") _spriteRenderer.color = Color.yellow;

        _color = _spriteRenderer.color;
        _shape = LayerMask.LayerToName(this.gameObject.layer);
    }
    private void Start()
    {
        _player = SpriteController.Instance;
    }

    public override void ApplyEffect(Collider2D collision, bool none)
    {
        if (isColorOverall)
        {
            _player.ChangeColor(_color, gameObject.tag);
        }
        if (isShapeOverall)
        {
            _player.ChangeShape(_shape, gameObject.layer);
        }
    }

    public override void CheckExitCondition(Collider2D collision) { }

    public override bool CheckCondition(Collider2D collision)
    {
        return true;
    }
}
