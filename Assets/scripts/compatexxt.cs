using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class compatexxt : MonoBehaviour
{
    [SerializeField] Text hptext;
    public void OnInit(float damage)
    {
        hptext.text=hptext.ToString();
        Invoke(nameof(OnDespawn),1f);
    }
    public void OnDespawn()
    {
        Destroy(gameObject);
    }
        
}
