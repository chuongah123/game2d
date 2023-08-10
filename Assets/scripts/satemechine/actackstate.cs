using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class actackstate : issate
{
    float timer;
    public void OnEnter(enemy enemy)
    {

        if (enemy.Target != null)
        {
            enemy.ChangeDirection(enemy.Target.transform.position.x > enemy.transform.position.x);
            enemy.stopmoving();
            enemy.actack();
            Debug.Log("actack");
        }
        timer = 0;
    }

    public void OnExecute(enemy enemy)
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f )
        {
            enemy.changestate(new paltroltate());
        }

    }

    public void OnExit(enemy enemy)
    {

    }
}
