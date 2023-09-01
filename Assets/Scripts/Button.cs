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

    public override void CheckTriggerCondition(Collider2D collision)
    {
        if (isColorOverall)
        {
            _player.ChangeColor(_color);
            _player.gameObject.tag = this.gameObject.tag;
            _player.transform.DOScale(1f, 0.3f);
        }
        if (isShapeOverall)
        {
            _player.ChangeShape(_shape);
            _player.gameObject.layer = this.gameObject.layer;
        }
    }

    public override void CheckExitCondition(Collider2D collision) { }
}
