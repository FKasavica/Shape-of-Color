using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private void Awake()
    {
        Instance = this;
    }
    public void ChangeColor(Color _color)
    {
        if (_color == Color.red) _spriteRenderer.color = Color.red;
        if (_color == Color.blue) _spriteRenderer.color = Color.blue;
        if (_color == Color.yellow) _spriteRenderer.color = Color.yellow;
    }

    public void ChangeShape(string _shape)
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
    }
}
