using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawn : MonoBehaviour
{ public BulletSpawnedData[] spawnData;
    public int index=0;
    BulletSpawnedData GetSpawnData(){
        return spawnData[index];
    }

     float timer;
    public bool isSeqRandom;
    public bool auto;

    float [] rotations;
    

    void Start()
    {
        timer = GetSpawnData().cooldown;
        rotations = new float[GetSpawnData().numberOfBullets];
        if (!GetSpawnData().isRandom)
        {

            DistributedRotations();
        }
    }

    // Update is called once per frame
    void Update()
    { if (auto)
    {
        if (timer <= 0)
        {
            if (isSeqRandom){
                index=Random.Range(0, spawnData.Length);
            }
            else
            {
               index+=1;
                if (index>= spawnData.Length)
                {
                 index=0;
                } 
            }
            SpawnBullets();
            timer = GetSpawnData().cooldown;
        }
        
    }
        
        timer -= Time.deltaTime;
    }

    public float[] RandomRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            rotations[i] = Random.Range(GetSpawnData().minRotation, GetSpawnData().maxRotation);
        }
        return rotations;

    }
  
    public float[] DistributedRotations()
    {
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            var fraction = (float)i / ((float)GetSpawnData().numberOfBullets - 1);
            var difference = GetSpawnData().maxRotation - GetSpawnData().minRotation;
            var fractionOfDifference = fraction * difference;
            rotations[i] = fractionOfDifference + GetSpawnData().minRotation; 
        }
        foreach (var r in rotations) print(r);
        return rotations;
    }
    public GameObject[] SpawnBullets()
    {
        if (GetSpawnData().isRandom)
        {
            RandomRotations();
        }

        GameObject[] spawnedBullets = new GameObject[GetSpawnData().numberOfBullets];
        for (int i = 0; i < GetSpawnData().numberOfBullets; i++)
        {
            spawnedBullets[i] = Instantiate(GetSpawnData().bulletResource, transform);
            
            var b = spawnedBullets[i].GetComponent<Bullet>();
            b.rotation = rotations[i];
            b.speed = GetSpawnData().bulletSpeed;
            b.velocity = GetSpawnData().bulletVelocity;
        }
        return spawnedBullets;
    }
}
