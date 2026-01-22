using JetBrains.Annotations;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    public static int speedIncrease;
    public static float speedUpIncrease;

    //STATS
    int MaxHealth;
    int health;
    int damage;
    int cluckingPower;
    int multiDropChance;
    float TaskSpeedIncreaser;

    //LEVEL
    public static int roundCount;
    public static int xp;
    int level;
    int xpRequirement;
    void Start()
    {
        speedIncrease = 0; speedUpIncrease = 0; health = 10; damage = 1; cluckingPower = 1; multiDropChance = 1; TaskSpeedIncreaser = 0;
    }

    // Update is called once per frame
    void Update()
    {
        LevelingUp();
    }

    int XPRequirementCalculator()
    {
        xpRequirement = 10 + (5 * level);
        return xpRequirement;
    }

    void LevelingUp()
    {
        if(xp >= XPRequirementCalculator())
        {
            level++;
            health = MaxHealth;
            xp = 0;
            StatIncreaser();
        }
    }

    void StatIncreaser()
    {
        MaxHealth = MaxHealth + (2 * level);
        damage = damage + (3 * level);

        if (level % 2 == 0)
            cluckingPower++;
        else
        {
            multiDropChance++;
            TaskSpeedIncreaser += 0.1f;
        }

    }

}
