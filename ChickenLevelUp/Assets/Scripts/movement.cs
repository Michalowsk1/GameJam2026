using System.Collections;
using UnityEngine;

public class movement : MonoBehaviour
{
    public Animator movementAnimator;
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
        Movement();
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
            Player.transform.localScale = new Vector3(-0.3f, 0.3f, 0.3f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            rb.AddForce(-Vector2.up * Time.deltaTime * speed, ForceMode2D.Impulse);
        }

        if (Input.GetKey(KeyCode.D))
        {
            rb.AddForce(Vector2.right * Time.deltaTime * speed, ForceMode2D.Impulse);
            Player.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f);
        }

        if (rb.linearVelocity == Vector2.zero) { walking = false; speed = 5; } else walking = true;

        if (walking)
        {
            speed += (0.05f + LevelingSystem.speedUpIncrease);
            movementAnimator.SetBool("moving", true);
        }
        else movementAnimator.SetBool("moving", false);
        if (speed > maxSpeed + LevelingSystem.speedIncrease)
            speed = maxSpeed + LevelingSystem.speedIncrease;

        rb.freezeRotation = true;
    }
}
