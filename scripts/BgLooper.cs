using UnityEngine;
using System.Collections;

public class BgLooper : MonoBehaviour
{

    int numBGPanels = 2;
    void OnTriggerEnter2D(Collider2D loopCol)
    {
        float widthOfBGObject = ((BoxCollider2D)loopCol).size.x;

        Vector3 pos = loopCol.transform.position;
        pos.x += widthOfBGObject * numBGPanels;
        loopCol.transform.position = pos;
    }
}
