using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeLevel : MonoBehaviour
{
    private bool[] tasks = new bool [100];
    private bool[] repeatedTasks = new bool [100];
    public spawn bulletspawner;
    public void Start() {
        Time.fixedDeltaTime = 0.1f;
    }
    public void FixedUpdate() {

        if (TimeManager.isTime(1f, ref tasks[0])){
           bulletspawner.index=0;
            bulletspawner.SpawnBullets();
        }
                if (TimeManager.isTime(5f, ref tasks[1])){
           bulletspawner.index=2;
            bulletspawner.SpawnBullets();
        }

                if (TimeManager.isTime(10f, ref tasks[2])){
            bulletspawner.index=0;
            bulletspawner.SpawnBullets();
        }
                        if (TimeManager.isTime(15f, ref tasks[3])){
            bulletspawner.index=3;
            bulletspawner.SpawnBullets();
        }
                                if (TimeManager.isTime(20f, ref tasks[4])){
            bulletspawner.index=1;
            bulletspawner.SpawnBullets();
        }




    }
}
