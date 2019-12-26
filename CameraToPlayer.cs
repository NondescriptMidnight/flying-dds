using UnityEngine;
using System.Collections;

public class CameraToPlayer : MonoBehaviour {

    Transform player;

    float offSetX;

	// Use this for initialization
	void Start () {
        GameObject playerGO = GameObject.FindGameObjectWithTag("Player");

        if (playerGO == null)
        {
            Debug.LogError("couldn't find an object with tag");
            return;
        }

        player = playerGO.transform;

        offSetX = transform.position.x - player.position.x;

	}
	
	// Update is called once per frame
	void Update () {

        if (player != null)
        {
            Vector3 cameraPos = transform.position;
            cameraPos.x = player.position.x + offSetX;
            transform.position = cameraPos;
        }
	
	}
}
