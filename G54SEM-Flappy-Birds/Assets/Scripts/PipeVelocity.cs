using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeVelocity : MonoBehaviour {

    void FixedUpdate()
    {
        Rigidbody2D r = GetComponent<Rigidbody2D>();        
        // apply the updated velocity to the rigid body
        r.velocity = new Vector2(-1.0f,0.0f);
    }
}
