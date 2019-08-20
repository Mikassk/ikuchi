using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class seta_direcional : MonoBehaviour
{
    public GameObject setadr;
    public GameObject setaesq;
    

    public SpriteRenderer dr;
    public SpriteRenderer esq;
   

    
    // Start is called before the first frame update
    void Start()
    {
        dr = setadr.GetComponent<SpriteRenderer>();
        esq = setaesq.GetComponent<SpriteRenderer>();
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnTriggerStay2D(Collider2D colli)
    {
        if (colli.gameObject.layer == 10)
        {
            dr.enabled = true;
            esq.enabled = true;
            
            Debug.Log("setar ok");
        }
        
    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if(coll.gameObject.layer == 10)
        {
            dr.enabled = false;
            esq.enabled = false;
        
            Debug.Log("setas off");
        }
    }
}
