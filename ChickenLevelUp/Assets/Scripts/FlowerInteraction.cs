using UnityEngine;

public class FlowerInteraction : InteractivePopUp
{
    [SerializeField] GameObject Loot;

    public float lootDropTimer;
    public bool clucked;
    int multiLootOdds = 1;
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
            int rand = Random.Range(0, 5 - LevelingSystem.multiDropChance);
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
        }

        if (clucked)
        {
            lootDropTimer -= Time.deltaTime;
        }
        else lootDropTimer = 0;
    }
}
