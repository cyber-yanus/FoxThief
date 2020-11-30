using System;
using DG.Tweening;
using PLayer;
using PLayer.Attac;
using PLayer.Move;
using UnityEngine;
using UnityEngine.Events;


public class PlayerController : MonoBehaviour
{
    [SerializeField] private PlayerState defaultState;
    [SerializeField] private Transform lookTarget;

    
    public UnityEvent deadEvent;

    private MoveController _moveController;
    private JumpController _jumpController;
    private AttacController _attacController;
    
    
    private PlayerState _state;
    private Rigidbody _rb;

    private float _lastPositionX;
    private Tween _rotateTween;
    
    
    
    void Start()
    {
        _state = defaultState;
        
        _rb = GetComponent<Rigidbody>();
        _moveController = GetComponent<MoveController>();
        _jumpController = GetComponent<JumpController>();
        _attacController = GetComponent<AttacController>();

        _lastPositionX = (float) Math.Round(transform.position.x, 2);
    }

    public void Jump()
    {
        _jumpController.Jump();
    }

    public void Down()
    {
        _jumpController.Landing();
    }

    public void Stop()
    {
        _moveController.StopPlayer();
    }

    public void Go()
    {
        _moveController.MovePlayer();
    }

    public void Dead()
    {
        state = PlayerState.Dead;
        
        Stop();
        Jump();    
        deadEvent.Invoke();
    }

    private void RotateCheck()
    {        
        float currentPositionX = (float) Math.Round(transform.position.x, 2);    
        
        _rotateTween.Kill();
        
        if (currentPositionX < _lastPositionX)
        {
            _rotateTween = transform.DORotate(new Vector3(0, -30, 0), .1f).SetEase(Ease.Linear);                
        }
        else if (currentPositionX > _lastPositionX)
        {
            _rotateTween = transform.DORotate(new Vector3(0, 30, 0), .1f).SetEase(Ease.Linear);
        }
        else if (currentPositionX == _lastPositionX)
        {
        
            _rotateTween = transform.DORotate(new Vector3(0, 0, 0), .1f).SetEase(Ease.Linear);
        }

        _lastPositionX = currentPositionX;
    }

    private void Update()
    {
        RotateCheck();
    }

    public PlayerState state
    {
        get => _state;
        set => _state = value;
    }
}
