using UnityEngine;
using TMPro;

public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI timeText;
    public int timeLeft;
    float secondTimer;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        timeLeft = 2;
    }

    // Update is called once per frame
    void Update()
    {
        secondTimer += Time.deltaTime;
        if (timeLeft > 0)
        {
            if(secondTimer > 1)
            {
                timeLeft--;
                secondTimer = 0;
            }
        }
        else
        {
            timeLeft = 0;
        }
        float minutes = Mathf.FloorToInt(timeLeft / 60);
        float seconds = Mathf.FloorToInt(timeLeft % 60);
        timeText.text = timeLeft.ToString();
    }
}
