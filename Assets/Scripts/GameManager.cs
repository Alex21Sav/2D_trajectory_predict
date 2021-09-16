using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    #region Singleton
    public static GameManager Instance;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }

    #endregion

    [SerializeField] private float _pushForce = 4f;

    private Camera _camera;
    private bool _isDragging = false;

    private Vector2 _startPoint;
    private Vector2 _endPoint;
    private Vector2 _direction;
    private Vector2 _force;
    private float _distance;

    public Ball Ball;
    public Trajectory Trajectory;


    private void Start()
    {
        _camera = Camera.main;
        Ball.DesactivateRigidbody();

    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            OnDragStart();
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isDragging = false;
            OnDragEnd();
        }

        if (_isDragging)
        {
            OnDrag();
        }

    }

    private void OnDragStart()
    {
        Ball.DesactivateRigidbody();
        _startPoint = _camera.ScreenToWorldPoint(Input.mousePosition);

        Trajectory.Show();
    }

    private void OnDrag()
    {
        _endPoint = _camera.ScreenToWorldPoint(Input.mousePosition);
        _distance = Vector2.Distance(_startPoint, _endPoint);
        _direction = (_startPoint - _endPoint).normalized;
        _force = _direction * _distance * _pushForce;

        Debug.DrawLine(_startPoint, _endPoint);

        Trajectory.UpdateDots(Ball.BallPosition, _force );
    }

    private void OnDragEnd()
    {
        Ball.ActivateRigidbody();

        Ball.Push(_force);

        Trajectory.Hide();
    }
}
