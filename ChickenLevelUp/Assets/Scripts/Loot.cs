using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    void Start()
    {
        StartCoroutine(Falling());
    }

    // Update is called once per frame
    void Update()
    {
        Destroy(gameObject, 5);
    }

    IEnumerator Falling()
    {
        bc.enabled = false;
        rb.gravityScale = 1;
        rb.AddForce(Vector2.up * Time.deltaTime * 10, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1f);
        rb.gravityScale = 0;
        rb.linearVelocity = new Vector2(0, 0);
        bc.enabled = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            int rand = Random.Range(0, 25);
            if (rand < 2)
            LevelingSystem.multiDropChance++;
            LevelingSystem.seedCount++;
            Destroy(gameObject);
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            enemyAI.score += 2;
            MapInteractiveSpawner.spawned--;
            Destroy(gameObject);
        }
    }
}
