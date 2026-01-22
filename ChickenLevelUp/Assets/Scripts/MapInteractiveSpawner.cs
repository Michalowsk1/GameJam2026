using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapInteractiveSpawner : MonoBehaviour
{
    public Vector2 flowerSpawn;
    int flowerCount;
    public List<Vector2> tempFlowerPositions = new List<Vector2>();
    public List<Vector2> confirmedFlowerPositions = new List<Vector2>();
    [SerializeField] GameObject[] flowers;
    [SerializeField] GameObject[] nests;
    void Start()
    {
        flowerGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmedFlowerPositions.Count == 10)
            flowerSpawner();
    }

    void flowerGenerator()
    {
        Vector2 tempPos = GenerateFlowerPosition();
        if (tempFlowerPositions.Count < 100)
        {
            tempFlowerPositions.Add(tempPos);
            flowerGenerator();
        }
        foreach (Vector2 pos in tempFlowerPositions)
        {
            if (Vector2.Distance(tempPos, pos) > 2 && confirmedFlowerPositions.Count < 10)
            {
                confirmedFlowerPositions.Add(pos);
            }
        }

    }

    void flowerSpawner()
    {
        int spawned = 0;
        if (spawned < 10)
        {
            foreach (Vector2 pos in confirmedFlowerPositions)
            {
                Instantiate(flowers[Random.Range(0, flowers.Length)], pos, Quaternion.identity);
                spawned++;
            }
        }
    }


    Vector2 GenerateFlowerPosition()
    {
        float yPos = Random.Range(-12, 7);
        flowerSpawn = new Vector3(Random.Range(-20, 20), yPos,yPos);
        return flowerSpawn;
    }
}
