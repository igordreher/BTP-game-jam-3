using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimDirection : MonoBehaviour
{
    [SerializeField] Camera _camera;
    Vector2 _projectedMousePosition;
    Vector2 _lookingDirection;
    float _lookingAngle;

    void Awake()
    {
    }

    void Update()
    {
        SetRotation();
    }

    void SetRotation()
    {
        _projectedMousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        _lookingDirection = _projectedMousePosition - (Vector2)transform.position;
        _lookingAngle = Mathf.Atan2(_lookingDirection.y, _lookingDirection.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0, 0, _lookingAngle);
    }
}
