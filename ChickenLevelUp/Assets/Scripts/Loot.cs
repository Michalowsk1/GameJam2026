using System.Collections;
using UnityEngine;

public class Loot : MonoBehaviour
{
    public Rigidbody2D rb;
    void Start()
    {
        StartCoroutine(Falling());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Falling()
    {
        rb.gravityScale = 1;
        rb.AddForce(Vector2.up * Time.deltaTime * 15, ForceMode2D.Impulse);
        yield return new WaitForSeconds(1.5f);
        rb.gravityScale = 0;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("SPAWNED");
        }
    }
}
