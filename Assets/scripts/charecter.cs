using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class charecter : MonoBehaviour
{
    [SerializeField] private Animator anim;
    [SerializeField] protected healthbar healthbar;
    [SerializeField] protected compatexxt combattexpf;
    private float hp;
    private string cranimname;

    public bool isDead => hp <= 0;
    private void Start()
    {
        OnInit();
    }
    public virtual void OnInit()
    {
        hp = 100;
        healthbar.OnInit(100,transform);
    }
    public virtual void OnDespawn()
    {
    
    }
    protected virtual void OnDeath()
    {
        changeanim("edie");
        Invoke(nameof(OnDespawn), 2f);
    }
    protected void changeanim(string animname)
    {
        if (cranimname != animname)
        {
            anim.ResetTrigger(animname);
            cranimname = animname;
            anim.SetTrigger(cranimname);
        }
    }
    public void OnHit(float damage)
    {
        if (hp >= damage)
        { 
             hp -= damage;
            if(hp <= damage)
            {
                hp = 0;
                OnDeath();
            }
            healthbar.setnewhp(hp);
            Instantiate(combattexpf, transform.position + Vector3.up, Quaternion.identity).OnInit(damage);
        }
    }


}
   
