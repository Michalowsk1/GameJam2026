using UnityEngine;
using System.Collections.Generic;

public class enemyAI : MonoBehaviour
{
    public List<float> distanceList = new List<float>();
    [SerializeField] GameObject Player;
    [SerializeField] Rigidbody2D rb;
    public static int score;
    float timer;
    Vector2 movementDirection;
    void Start()
    {
        score = 0;
    }

    // Update is called once per frame
    void Update()
    {
        walkingAI();
        rb.freezeRotation = true;
        if (Vector2.Distance(gameObject.transform.position, Player.transform.position) < 6)
        {
            Vector2 DirectionToOpponent = new Vector2((Player.transform.position.x - gameObject.transform.position.x), (Player.transform.position.y - gameObject.transform.position.y)).normalized;
            rb.AddForce(-DirectionToOpponent * 2, ForceMode2D.Impulse);
        }
    }

    void walkingAI()
    {
        timer += Time.deltaTime;
        if (timer > 5)
        {
            movementDirection = new Vector2(Random.Range(-5, 5), Random.Range(-5, 5));
            timer = 0;
        }
        rb.linearVelocity = movementDirection * 4;

    }
}
