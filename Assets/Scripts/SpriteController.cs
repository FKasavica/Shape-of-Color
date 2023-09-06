using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SpriteController : MonoBehaviour
{
    public static SpriteController Instance;
    [SerializeField] SpriteRenderer _spriteRenderer;

    [Header("SPRITES")]

    [SerializeField] Sprite Square;
    [SerializeField] private Vector2 _squareColliderSize;
    [Space(10)]

    [SerializeField] Sprite Triangle;
    [SerializeField] private Vector2 _triangleColliderSize;
    [Space(10)]

    [SerializeField] Sprite Circle;
    [SerializeField] private Vector2 _circleColliderSize;
    [Space(10)]

    [SerializeField] private BoxCollider2D _box2DPlayer;
    [Space(20)]
    [SerializeField] private Transform body;
    private Vector3 _initialScale;
    private PlayerInput _input;
    private Rigidbody2D _rb;

    private void Awake()
    {
        Instance = this;
        _input = PlayerInput.Instance;
        _initialScale = body.localScale;
        _rb = GetComponent<Rigidbody2D>();
    }
    public void ChangeColor(Color _color, string newTag)
    {
        if (_color == Color.red) _spriteRenderer.color = Color.red;
        if (_color == Color.blue) _spriteRenderer.color = Color.blue;
        if (_color == Color.yellow) _spriteRenderer.color = Color.yellow;

        gameObject.tag = newTag;

        ScaleTransform();
    }

    public void ChangeShape(string _shape, int newLayer)
    {
        if (_shape == "Triangle")
        {
            _spriteRenderer.sprite = Triangle;
            _box2DPlayer.size = _triangleColliderSize;
        }
        if (_shape == "Circle")
        {
            _spriteRenderer.sprite = Circle;
            _box2DPlayer.size = _circleColliderSize;
        }
        if (_shape == "Square")
        {
            _spriteRenderer.sprite = Square;
            _box2DPlayer.size = _squareColliderSize;
        }

        gameObject.layer = newLayer;

        ScaleTransform();
    }

    private void ScaleTransform()
    {
        _input.enabled = false;
        _rb.velocity = Vector2.zero;

        body.DOScale(_initialScale * 0.3f, 0.3f)
            .OnComplete(() =>
            {
                body.DOScale(_initialScale, 0.3f)
                .OnComplete(() =>
                {
                    _input.enabled = true;
                });
            });
    }
}
