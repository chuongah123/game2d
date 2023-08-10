using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafllow : MonoBehaviour
{
    public Transform taget;
    public Vector3 offset;
    public float speed=5;
    // Start is called before the first frame update
    void Start()
    {
        taget = FindObjectOfType<playercontroller>().transform;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        transform.position = Vector3.Lerp(transform.position,taget.position+offset,Time.deltaTime*speed);
    }
}
