using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : charecter
{
    [SerializeField] private Rigidbody2D rb;
    
    [SerializeField] private LayerMask glayer;
    [SerializeField] private float speed = 5;
    [SerializeField] private float jumpforce = 350;
    [SerializeField] private kunai kunnaipb;
    [SerializeField] private Transform shootpoint;
    [SerializeField] private GameObject actackpl;
    private bool isgrounded =true;
    private bool isrunshoot = false;
    private bool isjump = false;
    private bool isdie = false;
    private float hozi;
    
    private int cherry = 0;
    private Vector3 savepoint;
    private void Awake()
    {
        cherry = PlayerPrefs.GetInt("cherry",0);
    }
    void Update()
    {
        if(isDead) 
        { return; }
       isgrounded=(checkgrounded());
       // hozi = Input.GetAxisRaw("Horizontal");
        if(isrunshoot)
        {
            return;
        }
        if (isgrounded)
        {
            if (isjump)
            { 
                return;
            }
            if (Input.GetKeyDown(KeyCode.Space) && isgrounded)
            {
                Jump();
            }

            if (Mathf.Abs(hozi) > 0.1f)
            {
                changeanim("run");
            }
            if (Input.GetKeyDown(KeyCode.Q) && isgrounded)
            {
               Runshoot();
            }
            if (Input.GetKeyDown(KeyCode.V) && isgrounded)
            {
                Shoot();
            }
        }
        if (!isgrounded && rb.velocity.y < 0)
        {
            changeanim("jumpout");
            isjump = false;
        }

        if (Mathf.Abs(hozi) >0.1f)
        {
            changeanim("run");
            rb.velocity = new Vector2(hozi *  speed, rb.velocity.y);
            transform.rotation = Quaternion.Euler(new Vector3(0,hozi > 0 ? 0:180,0));
        }else if(isgrounded)
        {
            changeanim("idle");
            rb.velocity = Vector2.zero;
        }
    }
    public override void OnInit  ()
    {   
        base.OnInit ();
        isdie = false;
        isrunshoot = false;
        transform.position = savepoint;
        changeanim("idle");
        deactiveshoot();
        SavePoint();
        uimmanager.instance.setcherry(cherry);

    }
    public override void OnDespawn()
    {
        base.OnDespawn();
        OnInit();
    }
    protected override void OnDeath()
    {
        base.OnDeath();
       
    }
    private bool checkgrounded()
    {
        RaycastHit2D hit=Physics2D.Raycast(transform.position, Vector2.down,1.1f, glayer);
        return hit.collider != null;
    }

    public void Runshoot()
    {
        rb.velocity = Vector2.zero;
        changeanim("runshoot");
        isrunshoot = true;
        Invoke(nameof(resetattack), 0.5f);
        activeshoot();
        Invoke(nameof(deactiveshoot), 0.5f);

    }
    public void Shoot()
    {
        
        changeanim("shoot");
        isrunshoot= true;
        Invoke(nameof(resetattack), 0.5f);
        Instantiate(kunnaipb, shootpoint.position, shootpoint.rotation);

    }
    private void resetattack()
    {
        changeanim("idle");
        isrunshoot = false;
    

    }
    public void Jump()
    {
        isjump = true;
        changeanim("jump");
        rb.AddForce(jumpforce * Vector2.up);
    }
    internal void SavePoint()
    { 
        savepoint=transform.position;
    }
    private void activeshoot()
    {
        actackpl.SetActive(true);
    }
    private void deactiveshoot()
    {
        actackpl.SetActive(false);
    }
    public void setmove(float hozi)
    {
        this.hozi=hozi;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag=="cherry")
        {
            cherry++;
            PlayerPrefs.SetInt("cherry",cherry);
            uimmanager.instance.setcherry(cherry);
            Destroy(collision.gameObject);
        }
        if(collision.tag=="death")
        {
            isdie=true;
            changeanim("die");
            Invoke(nameof(OnInit), 1f);
        }
    }
}
