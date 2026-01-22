using TMPro;
using UnityEngine;

public class UI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI eggText;
    [SerializeField] TextMeshProUGUI seedText;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        eggText.text = LevelingSystem.eggCount + "/" + LevelingSystem.eggRequirement;
        seedText.text = LevelingSystem.seedCount + "/" + LevelingSystem.seedRequirement;
    }
}
