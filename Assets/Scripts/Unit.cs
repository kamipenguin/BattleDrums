﻿using UnityEngine;

[RequireComponent(typeof(HealthController))]
internal class Unit : MonoBehaviour
{
    public Vector2 ForwardDirection;
    public float Speed;

    private HealthController _healthController;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _healthController = GetComponent<HealthController>();
    }

    private void Update()
    {
        gameObject.transform.position += _moveDirection * Speed;
    }

    public void MoveForward()
    {
        _moveDirection = ForwardDirection;
    }

    public void MoveBackWards()
    {
        _moveDirection = -ForwardDirection;
    }

    public virtual void StopMoving()
    {
        _moveDirection = Vector3.zero;
    }

    public virtual void PerformAction()
    {
    }

    public void ApplyDamage(float damage)
    {
        _healthController.Health -= damage;
    }
}