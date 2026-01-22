using System.Collections;
using UnityEngine;

public class ChickenNest : InteractivePopUp
{
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detection();

        if(inRange && Input.GetKey(KeyCode.E))
        {
            Debug.Log("YEAH");
        }
    }
}
