using System.Collections;
using UnityEngine;

public class movement : MonoBehaviour
{
    [SerializeField] GameObject Player;
    [SerializeField]Rigidbody2D rb;
    public float speed = 5;
    public bool walking;
    bool inRange;
    int maxSpeed = 7;

    bool startAnim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }



    // Update is called once per frame
    void Update()
    {
        Movement(); NestAnimation();
    }

    void Movement()
    {

        if (Input.GetKey(KeyCode.W))
        {
            rb.AddForce(Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.A))
        {
            rb.AddForce(-Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if (rb.linearVelocity == Vector2.zero) { walking = false; speed = 5; } else walking = true;

        if (walking)
            speed += (0.05f + LevelingSystem.speedUpIncrease);
        if(speed > maxSpeed + LevelingSystem.speedIncrease)
            speed = maxSpeed + LevelingSystem.speedIncrease;
    }

    void NestInteraction()
    {
        if (Vector2.Distance(Player.transform.position, gameObject.transform.position) < 2.5f)
            inRange = true;

        if (inRange && Input.GetKey(KeyCode.E))
            startAnim = true;

    }

    IEnumerator NestAnimation()
    {
        yield return null;
    }

    void FlowerInteraction()
    {

    }
}
