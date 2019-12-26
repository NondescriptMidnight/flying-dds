using UnityEngine;
using System.Collections;

public class PipeLooper : MonoBehaviour {

    int numPipePanels = 6;

    private float pipeMax = 1.47f;
    private float pipeMin = 0.09f;

    // Use this for initialization
    void Start() {
        GameObject[] pipes = GameObject.FindGameObjectsWithTag("Pipe");

        foreach (GameObject pipe in pipes)
        {
            Vector3 pipePos = pipe.transform.position;
            pipePos.y = Random.Range(pipeMin, pipeMax);
            pipe.transform.position = pipePos;
        }
    }

    void    OnTriggerEnter2D(Collider2D pipeLoop)
    {
        Debug.Log("IsTriggered");
        float widthOfPipe = ((BoxCollider2D)pipeLoop).size.x;
        Vector3 pipePos = pipeLoop.transform.position;
        pipePos.x += widthOfPipe * numPipePanels * Random.Range(1f,1.5f);

        if (pipeLoop.tag == "Pipe")
        {
            pipePos.y = Random.Range(pipeMin, pipeMax);
        }

        pipeLoop.transform.position = pipePos;
    }
}
