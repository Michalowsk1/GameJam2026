using TMPro;
using UnityEngine;

public class Results : MonoBehaviour
{
    public static bool loss;
    public static bool win;
    //Victory
    [SerializeField] GameObject victoryPrefab;
    //Defeat
    [SerializeField] GameObject defeatPrefab;
    void Start()
    {
        victoryPrefab.SetActive(false);
        defeatPrefab.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(win)
        {
            Time.timeScale = 0;
            victoryPrefab.SetActive(true);
        }

        else if (loss)
        {
            Time.timeScale = 0;
            defeatPrefab.SetActive(true);
        }
    }
}
