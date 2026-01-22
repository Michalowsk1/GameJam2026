using System.Collections;
using UnityEngine;

public class ChickenNest : InteractivePopUp
{
    float taskTimer = 4.9f;
    public Animator animatorProgress;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Detection();

        if (inRange && Input.GetKey(KeyCode.E))
        {
            taskTimer -= Time.deltaTime;
            animatorProgress.SetBool("Heating", true);
        }
        else
        {
            animatorProgress.SetBool("Heating", false);
            taskTimer = 4.9f;
        }

        if (taskTimer <= 0)
            Debug.Log("Finished");
    }
}
