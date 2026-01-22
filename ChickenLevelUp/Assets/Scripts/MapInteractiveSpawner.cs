using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MapInteractiveSpawner : MonoBehaviour
{
    //Map Spawns
    public Vector3 flowerSpawn;
    public List<Vector3> tempObjectsPositions = new List<Vector3>();
    public List<Vector3> confirmedObjectPositions = new List<Vector3>();
    [SerializeField] GameObject[] InteractableObjects;
    [SerializeField] GameObject grass;

    // Levels Info
    int maxNumOfObjects = 30;
    public static int spawned = 0;
    void Start()
    {
        flowerGenerator();
        grassSpawner();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(spawned);
        if (confirmedObjectPositions.Count == maxNumOfObjects)
        {
            flowerSpawner();
            confirmedObjectPositions.Clear();
        }

        if (spawned < maxNumOfObjects / 2)
            flowerGenerator();
    }

    void flowerGenerator()
    {
        Vector3 tempPos = GenerateFlowerPosition();
        if (tempObjectsPositions.Count < maxNumOfObjects)
        {
            tempObjectsPositions.Add(tempPos);
            flowerGenerator();
        }
        foreach (Vector3 pos in tempObjectsPositions)
        {
            if (Vector3.Distance(tempPos, pos) > 2 && confirmedObjectPositions.Count < maxNumOfObjects)
            {
                confirmedObjectPositions.Add(pos);
            }
        }

    }

    void flowerSpawner()
    {
        if (spawned < maxNumOfObjects)
        {
            foreach (Vector3 pos in confirmedObjectPositions)
            {
                Instantiate(InteractableObjects[Random.Range(0, InteractableObjects.Length)], pos, Quaternion.identity);
                spawned++;
            }
        }
    }


    Vector3 GenerateFlowerPosition()
    {
        float yPos = Random.Range(-45, 1);
        flowerSpawn = new Vector3(Random.Range(-20, 20), yPos,yPos);
        return flowerSpawn;
    }

    void grassSpawner()
    {
        for(int i = 0;  i < 75; i++)
        {
            Instantiate(grass, new Vector2(Random.Range(-20,20), Random.Range(-45,1)), Quaternion.identity);
        }
    }
}
