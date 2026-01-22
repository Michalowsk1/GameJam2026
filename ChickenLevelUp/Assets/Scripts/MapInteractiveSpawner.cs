using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapInteractiveSpawner : MonoBehaviour
{
    public Vector3 flowerSpawn;
    public List<Vector3> tempFlowerPositions = new List<Vector3>();
    public List<Vector3> confirmedFlowerPositions = new List<Vector3>();
    [SerializeField] GameObject[] flowers;
    [SerializeField] GameObject[] nests;

    int flowersToSpawn;
    void Start()
    {
        flowerGenerator();
    }

    // Update is called once per frame
    void Update()
    {
        if (confirmedFlowerPositions.Count == 10)
        {
            flowerSpawner();
            confirmedFlowerPositions.Clear();
        }
    }

    void flowerGenerator()
    {
        Vector3 tempPos = GenerateFlowerPosition();
        if (tempFlowerPositions.Count < 10)
        {
            tempFlowerPositions.Add(tempPos);
            flowerGenerator();
        }
        foreach (Vector3 pos in tempFlowerPositions)
        {
            if (Vector3.Distance(tempPos, pos) > 2 && confirmedFlowerPositions.Count < 10)
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
            foreach (Vector3 pos in confirmedFlowerPositions)
            {
                Instantiate(flowers[Random.Range(0, flowers.Length)], pos, Quaternion.identity);
                spawned++;
            }
        }
    }


    Vector3 GenerateFlowerPosition()
    {
        float yPos = Random.Range(-12, 1);
        flowerSpawn = new Vector3(Random.Range(-20, 20), yPos,yPos);
        return flowerSpawn;
    }
}
