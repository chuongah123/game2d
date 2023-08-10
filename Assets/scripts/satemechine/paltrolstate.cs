using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class paltroltate : issate
{
    float ramdomtime;
    float timer;
    public void OnEnter(enemy enemy)
    {
        timer = 0;
        ramdomtime = Random.Range(3f, 6f);
    }

    public void OnExecute(enemy enemy)
    {
        timer += Time.deltaTime;
        if (enemy.Target!=null)
        { enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
         if (enemy.istagetinrange())
            {
                enemy.changestate(new actackstate());
            }
            else { enemy.moving(); }
         
        }
        else
        {
            if (timer > ramdomtime)
            { enemy.moving(); }
            else
            { enemy.changestate(new idlesate()); }
        }

    }

    public void OnExit(enemy enemy)
    {
        
    }
}
