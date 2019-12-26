using UnityEngine;
using System.Collections;

public class DDscript : MonoBehaviour
{
    Vector3 velocity = Vector3.zero;
    public Vector3 gravity;
    public Vector3 flapVelocity;
    private bool isFlapped;
    public float maxSpeed = 5f;
    private float angle;
    public float forwardSpeed = 1f;

    public AudioClip poppingSound;
    public AudioClip owSound;
    public AudioClip flapSound;

    private bool isDeadPlayed = false;
    private bool isStarted = false;

    void Update()
    {
            if ((Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0))
        {
            isStarted = true;
            isFlapped = true;
            foreach (Touch touch in Input.touches)
            {
                if (touch.phase == TouchPhase.Began)
                {
                    isFlapped = true;
                }
                if (touch.phase == TouchPhase.Ended)
                {
                    isFlapped = false;
                }
            }
        }
    }

    void FixedUpdate()
    {
        if (isStarted)
        {
            float soundTime = flapSound.length;
            velocity += gravity * Time.deltaTime;
            soundTime -= Time.deltaTime;

            velocity.x = forwardSpeed;

            if (isFlapped == true)
            {
                AudioSource.PlayClipAtPoint(flapSound, transform.position, 1f);
                isFlapped = false;
                if (velocity.y <= 0)
                {
                    velocity.y = 0;
                }
                velocity += flapVelocity;

            }

            velocity = Vector3.ClampMagnitude(velocity, maxSpeed);
            transform.position += velocity * Time.deltaTime;

            if (velocity.y <= 0)
            {

                angle = Mathf.Lerp(0, -45, -velocity.y / maxSpeed);
            }

            transform.rotation = Quaternion.Euler(0, 0, angle);
        }
    }
    void OnCollisionEnter2D(Collision2D ddHit)
    {
        GameObject pipe = GameObject.FindGameObjectWithTag("Pipes");
        if (pipe)
        {
            if (!isDeadPlayed)
            {
                AudioSource.PlayClipAtPoint(owSound, transform.position, 1f);
                AudioSource.PlayClipAtPoint(poppingSound, transform.position, 1f);
                isDeadPlayed = true;
            }
            Destroy(gameObject.GetComponent<SpriteRenderer>());
            Destroy(gameObject.GetComponent<Collider2D>());
            Invoke("LoadLevel", 2f);
        }
    }
    void LoadLevel()
    {
        Application.LoadLevel(1);

    }
}