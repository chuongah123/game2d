using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class idlesate : issate
{
    float ramdomtime;
    float timer;
    public void OnEnter(enemy enemy)
    {
        enemy.stopmoving();
        timer = 0;
        ramdomtime = Random.Range(2f, 4f);
    }

    public void OnExecute(enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer>ramdomtime)
        {
            enemy.changestate(new paltroltate());
        }
       
    }

    public void OnExit(enemy enemy)
    {

    }
}
