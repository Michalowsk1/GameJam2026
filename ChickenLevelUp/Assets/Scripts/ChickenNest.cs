using System.Collections;
using UnityEngine;

public class ChickenNest : InteractivePopUp
{
    float taskTimer = 4.9f;
    public Animator animatorProgress;
    public Animator animatorDone;
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
            if(LevelingSystem.level == 3)
            {
                taskTimer -= Time.deltaTime * 4;
                animatorProgress.speed = 4;
            }
        }
        else
        {
            animatorProgress.SetBool("Heating", false);
            taskTimer = 4.9f;
        }



        if (taskTimer <= 0)
        {
            Debug.Log("Warmed");
            animatorDone.SetBool("done", true);
            MapInteractiveSpawner.spawned--;
            LevelingSystem.eggCount++;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            enemyAI.score += 2;
            Destroy(gameObject);
            MapInteractiveSpawner.spawned--;
        }
    }
}
