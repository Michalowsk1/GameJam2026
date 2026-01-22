using JetBrains.Annotations;
using System.Collections;
using UnityEngine;

public class LevelingSystem : MonoBehaviour
{
    public static int speedIncrease;
    public static float speedUpIncrease;
    public static float eggCount = 0;
    public static float seedCount = 0;
    public static int eggRequirement = 2;
    public static int seedRequirement = 5;

    //STATS
    public static float cluckingPower;
    public static int multiDropChance;
    public static float TaskSpeedIncreaser;

    //LEVEL
    public static int roundCount;
    public static int level;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        StatsMananger(); levelRequirements();
    }

    void StatsMananger()
    {
        switch (level)
        {
            case 0:
                speedIncrease = 0;
                speedUpIncrease = 0;
                cluckingPower = 0;
                multiDropChance = 0;
                TaskSpeedIncreaser = 1;
                break;

            case 1:
                speedIncrease = 2;
                speedUpIncrease = 0.1f;
                cluckingPower = 1;
                multiDropChance = 1;
                TaskSpeedIncreaser = 1.5f;
                break;
            case 2:
                speedIncrease = 4;
                speedUpIncrease = 0.2f;
                cluckingPower = 2;
                multiDropChance = 2;
                TaskSpeedIncreaser = 2;
                break;
        }
    }

    void levelRequirements()
    {
        if(eggCount == eggRequirement && seedCount == seedRequirement)
        {
            level++;
            eggCount = 0;
            seedCount = 0;
            eggRequirement = eggRequirement * 2;
            seedRequirement = seedRequirement * 2;
        }
    }

    
}
