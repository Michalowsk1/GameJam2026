using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggText;
    [SerializeField] TextMeshProUGUI seedText;
    [SerializeField] TextMeshProUGUI timeText;
    public static float timeLeft;
    float secondTimer;
    void Start()
    {
        timeLeft = 45;
    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = LevelingSystem.eggCount + "/" + LevelingSystem.eggRequirement;
        seedText.text = LevelingSystem.seedCount + "/" + LevelingSystem.seedRequirement;
        timer();
    }

    void timer()
    {
        secondTimer += Time.deltaTime;
        if (timeLeft > 0)
        {
            if (secondTimer > 1)
            {
                timeLeft--;
                secondTimer = 0;
            }
        }
        else
        {
            timeLeft = 0;
            Results.loss = true;
        }
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timeText.text = timeLeft.ToString();
    }
}
