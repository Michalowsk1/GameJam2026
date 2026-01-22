using UnityEngine;

public class FlowerInteraction : InteractivePopUp
{
    [SerializeField] GameObject Loot;


    // Update is called once per frame
    void Update()
    {
        Detection();

        if(inRange && Input.GetKey(KeyCode.E))
        {
            Instantiate(Loot, gameObject.transform.position, Quaternion.identity);
        }
    }
}
