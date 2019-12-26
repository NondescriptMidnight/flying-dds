using UnityEngine;
using System.Collections;

public class ObjectGizmo : MonoBehaviour {


    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(transform.position, 1);
    }
}
