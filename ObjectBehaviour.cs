using UnityEngine;
using System.Collections;

public class ObjectBehaviour : MonoBehaviour
{

    public AudioClip voiceSound;

    public int scoreValue = 1;

    private bool checkForNull = false;

    private float waiter;

    public GameObject puffEffect;

    public int scoreCount;



    void Start()
    {
        waiter = 0.2f;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        Die();
    }

    void Die()
    {
        SpriteRenderer objectSprite = gameObject.GetComponent<SpriteRenderer>();
        Collider2D objectCollider = gameObject.GetComponent<Collider2D>();
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player)
        {
            ScoreTrackering.scoreNum += 1;
            scoreCount = ScoreTrackering.scoreNum;
            AudioSource.PlayClipAtPoint(voiceSound, Camera.main.transform.position, 1.0f);
            GameObject puffPuff = Instantiate(puffEffect, transform.position, Quaternion.identity) as GameObject;
            Destroy(puffPuff, 0.5f);
            Destroy(gameObject);
        }
    }
}
