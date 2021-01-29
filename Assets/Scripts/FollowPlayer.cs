using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    [SerializeField] float smoothSpeed;
    [SerializeField] bool smoothMovement;
    Transform _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        Vector3 desiredPosition = new Vector3(_player.position.x, _player.position.y, transform.position.z);
        Vector3 smoothPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        if (smoothMovement)
            transform.position = smoothPosition;
        else
            transform.position = desiredPosition;
    }
}
