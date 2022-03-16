using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Accelerometer : MonoBehaviour
{

    [SerializeField] private Rigidbody2D _ballRigid;
    [SerializeField] private float _force;

    private void  FixedUpdate()
    {
        Vector2 acceleration = Input.acceleration;
        _ballRigid.velocity = new Vector2(acceleration.x * _force, acceleration.y * _force);
    }
}
