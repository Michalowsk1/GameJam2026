using UnityEngine;

public class cameraScript : MonoBehaviour
{
    [SerializeField] GameObject Player;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -100);

        if (gameObject.transform.position.x > 23) gameObject.transform.position = new Vector3(23, gameObject.transform.position.y, -100);

        if (gameObject.transform.position.x < -24) gameObject.transform.position = new Vector3(-24, gameObject.transform.position.y, -100);

        if (gameObject.transform.position.y > 6.5f) gameObject.transform.position = new Vector3(gameObject.transform.position.x, 6.5f, -100);

        if (gameObject.transform.position.y < -45) gameObject.transform.position = new Vector3(gameObject.transform.position.x, -45, -100);
    }
}
