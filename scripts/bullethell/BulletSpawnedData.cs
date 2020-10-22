using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName="Data",menuName="Script/BulletSpawnedData", order=1)]

public class BulletSpawnedData : ScriptableObject
{
    public GameObject bulletResource;
    public float minRotation;
    public float maxRotation;
    public int numberOfBullets;
    public bool isRandom;

    public float cooldown;
    public float bulletSpeed;
    public Vector2 bulletVelocity;
    public bool isNotParent=true;

}
