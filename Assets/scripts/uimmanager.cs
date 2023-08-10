using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class uimmanager : MonoBehaviour
{
    public static uimmanager instance;
   /* public static uimmanager Instance
    {
       get
        { 
            if(instance == null)
            {
                instance = FindObjectOfType<uimmanager>();
                return instance;
            }

        }

    }*/
    private void Awake()
    {
        instance=this;
    }
    [SerializeField] Text cherrytext;
    public void setcherry(int cherry)
    {
        cherrytext.text=cherry.ToString();
    }

}
