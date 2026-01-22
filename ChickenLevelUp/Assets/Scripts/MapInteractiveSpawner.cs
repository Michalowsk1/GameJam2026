using System.Collections.Generic;
using UnityEngine;

public class MapInteractiveSpawner : MonoBehaviour
{
    public Vector2 flowerSpawn;
    List<Vector2> flowerPositions = new List<Vector2>();
    [SerializeField] GameObject[] flowers;
    [SerializeField] GameObject[] nests;
    void Start()
    {
        for(int i = 0; i < 25; i++)
        {
            flowerSpawn = new Vector2(Random.Range(-20, 20), Random.Range(-12, 7));
            GameObject flowerPrefab = Instantiate(flowers[Random.Range(0,flowers.Length)], flowerSpawn, Quaternion.identity);
            flowerPositions.Add(flowerSpawn);

            foreach(Vector2 position in flowerPositions)
            {
                if (Vector2.Distance(position, flowerSpawn) < 2)
                {
                    Destroy(flowerPrefab);
                    i--;
                }
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FlowerSpawner()
    {

    }
}
