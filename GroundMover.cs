using UnityEngine;
using System.Collections;

public class GroundMover : MonoBehaviour {
    private float speed = -2f;

    void FixedUpdate()
    {
        Vector3 moverParalax = transform.position;
        moverParalax.x += speed * Time.deltaTime;
        transform.position = moverParalax;
    }
}
