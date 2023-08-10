using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class healthbar : MonoBehaviour
{
    [SerializeField] Image imagefill;
    [SerializeField] Vector3 offset;
    float hp;
    float maxhp;
    private Transform target;
    // Update is called once per frame
    void Update()
    {
        imagefill.fillAmount = Mathf.Lerp(imagefill.fillAmount, hp / maxhp, Time.deltaTime * 5f);
        transform.position=target.position + offset;
    }
    public void OnInit(float maxhp,Transform target)
    {
        this.target = target;
        this.maxhp = maxhp;
        hp=maxhp;
        imagefill.fillAmount = 1;
    } 
    public void setnewhp(float hp)
    {
        this.hp = hp;
       // imagefill.fillAmount = hp/maxhp;
    }
}
