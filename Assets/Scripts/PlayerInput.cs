using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] private Joystick joystick;
    [Space(10)]
    private float _speed;
    [SerializeField] private float _angler;
    [SerializeField] private float _scaler;
    [Space(10)]
    [SerializeField] private GameObject _body;
    private Vector2 _control0 = new(0, 0);

    Rigidbody2D _rb;
    AudioManager AM;
    [SerializeField] Animator Animator;
    public static PlayerInput Instance;
    public bool Joystick;

    private void Awake()
    {
        Instance = this;
        _rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        AM = AudioManager.Instance;
        _speed = GameManager.Instance.PlayerSpeed;
    }
    private void Update()
    {
        if (Joystick)
        {
            _rb.velocity = _speed * Time.deltaTime * new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;

            RotatePlayer(Input.GetAxis("Horizontal"));
            if (!AM.MoveSound.isPlaying) AM.MoveSound.Play();
            Animator.SetBool("IsMoving", true);
        }
        else
        {
            _rb.velocity = _speed * Time.deltaTime * new Vector2(joystick.Horizontal, joystick.Vertical);

            RotatePlayer(joystick.Horizontal);
            if (!AM.MoveSound.isPlaying && _rb.velocity != _control0)
            {
                AM.MoveSound.Play();
                Animator.SetBool("IsMoving", true);
            }
        }
        Debug.Log(_rb.velocity);

        if (_rb.velocity == _control0)
        {
            if (AM.MoveSound.isPlaying) AM.MoveSound.Pause();
            Animator.SetBool("IsMoving", false);
        }
    }

    public void RotatePlayer(float f)
    {
        if (f < 0)
        {
            transform.localScale = new Vector3(-_scaler, _scaler, _scaler);
            _body.transform.rotation = Quaternion.Euler(0, 0, _angler);
        }
        else if (f > 0)
        {
            transform.localScale = new Vector3(_scaler, _scaler, _scaler);
            _body.transform.rotation = Quaternion.Euler(0, 0, -_angler);
        }
        else
        {
            _body.transform.rotation = Quaternion.Euler(0, 0, 0);
        }
    }

    void SetLocalScale()
    {
        
    }
}
