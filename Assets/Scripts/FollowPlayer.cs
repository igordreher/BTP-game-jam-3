using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    Transform _player;

    void Awake()
    {
        _player = GameObject.Find("Player").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        transform.position = new Vector3(_player.position.x, _player.position.y, transform.position.z);    
    }
}
