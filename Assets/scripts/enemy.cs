using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class enemy : charecter
{
    [SerializeField] private float actackrange;
    [SerializeField] private float movespeed;
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject actackpl;
    private issate crstate;
    private bool isright = true;
    private charecter target;
    public charecter Target => target;

    private void Update()
    {
        if(crstate!=null && !isDead)
        {                                       
            crstate.OnExecute(this);
        }
    }

    public override void OnInit()
    {
        base.OnInit();
        changestate(new idlesate());
        deactiveshoot();
    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        Destroy(healthbar.gameObject); 
        Destroy(gameObject);
    }
    protected override void OnDeath()
    {
        changestate(null);
        base.OnDeath();
    }
  
   
    public void changestate(issate newstate)
    {
        if(crstate != null)
        {
            crstate.OnExit(this);
        }
        Debug.LogError(crstate + "--" + newstate);
        crstate= newstate;
        if(crstate != null )
        {
            crstate.OnEnter(this);
        }
    }
    internal void settarget(charecter Charecter)
    {
        this.target = Charecter;
        if(istagetinrange())
        {
            changestate(new actackstate());
        }else
        if(Target!=null)
        {
            changestate(new paltroltate());
        }
        else
        {
            changestate(new idlesate());
        }
    }
    public void moving()
    {
        changeanim("erun");
        rb.velocity = transform.right * movespeed;

    }
    public void stopmoving()
    {
        changeanim("eidle");
        rb.velocity = Vector2.zero;
    }
    public void actack()
    {
        changeanim("eactack");
        activeshoot();
        Invoke(nameof(deactiveshoot), 0.5f);
    }
    public bool istagetinrange()
    {
        if (target != null && Vector2.Distance(target.transform.position, transform.position) <= actackrange)
        { return true; }
        else { return false; }
     
    }
    private void activeshoot()
    {
        actackpl.SetActive(true);
    }
    private void deactiveshoot()
    {
        actackpl.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="enemywall")
        {
            ChangeDirection(!isright);
        }
    }

    public void ChangeDirection(bool isright)
    {
       this.isright = isright;
        transform.rotation =isright? Quaternion.Euler(Vector3.zero):Quaternion.Euler(Vector3.up*180);
    }


}
