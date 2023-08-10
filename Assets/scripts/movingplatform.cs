using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movingplatform : MonoBehaviour
{
    [SerializeField] private Transform apoint, bpoint;
    [SerializeField] private float speed;
    Vector3 taget;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = apoint.position;
        taget = bpoint.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, taget, speed * Time.deltaTime);
        if (Vector2.Distance(transform.position, apoint.position) < 0.1f)
        {
            taget = bpoint.position;
        }
        else if (Vector2.Distance(transform.position, bpoint.position) < 0.1f)
        {
            taget = apoint.position;
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag =="Player")
        {
            collision.transform.SetParent(transform);
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.transform.SetParent(null);
        }
    }
}
