using UnityEngine;

public class FlowerInteraction : InteractivePopUp
{
    public static int seedCount;
    [SerializeField] GameObject Loot;
    public Animator flowerAnim;
    public float lootDropTimer;
    public bool clucked;
    int multiLootOdds = 1;

    public static bool done;
    // Update is called once per frame
    void Update()
    {
        Detection();
        if (inRange && Input.GetKeyDown(KeyCode.E) && clucked == false)
        {
            clucked = true;
            lootDropTimer = Random.Range(2.5f, 5.0f) - LevelingSystem.cluckingPower;
        }

        if (lootDropTimer <= 0 && clucked)
        {
            int rand = Random.Range(0, 7 - LevelingSystem.multiDropChance);
            if (multiLootOdds > rand)
            {
                for (int i = 0; i < Random.Range(2, 4); i++)
                {
                    Instantiate(Loot, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2), Quaternion.identity);
                }
            }
            else
            {
                Instantiate(Loot, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y + 2), Quaternion.identity);
                clucked = false;
            }
            flowerAnim.SetBool("done", true);
            MapInteractiveSpawner.spawned--;
        }

        if (clucked)
        {
            lootDropTimer -= Time.deltaTime;
        }
        else lootDropTimer = 0;
    }
}
