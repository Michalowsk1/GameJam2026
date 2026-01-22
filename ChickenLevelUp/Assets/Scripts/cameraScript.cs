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
        gameObject.transform.position = new Vector3(Player.transform.position.x, Player.transform.position.y, -1);

        if (gameObject.transform.position.x > 8.5) gameObject.transform.position = new Vector3(8.5f, gameObject.transform.position.y, -1);

        if (gameObject.transform.position.x < -9) gameObject.transform.position = new Vector3(-9, gameObject.transform.position.y, -1);

        if (gameObject.transform.position.y > 7) gameObject.transform.position = new Vector3(gameObject.transform.position.x, 7, -1);

        if (gameObject.transform.position.y < -7) gameObject.transform.position = new Vector3(gameObject.transform.position.x, -7, -1);
    }
}
