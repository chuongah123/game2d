using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kunai : MonoBehaviour
{
    public GameObject hitvfx;
    public Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
       OnInit();
    }
    public void OnInit()
    {
        rb.velocity = transform.right * 5f;
        Invoke(nameof(OnDespawn), 3f);
    }
    public void OnDespawn()
    {
        Destroy(gameObject);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "enemy")
        {
            collision.GetComponent<charecter>().OnHit(30f);
            Instantiate(hitvfx,transform.position,transform.rotation);
            OnDespawn();

        }
    }
}
