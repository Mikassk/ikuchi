using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class espaco : MonoBehaviour
{
    public GameObject espaco_;
    public GameObject baixo;
  

    public SpriteRenderer ep;
    public SpriteRenderer bx;


    // Start is called before the first frame update
    void Start()
    {
        ep = espaco_.GetComponent<SpriteRenderer>();
        bx= baixo.GetComponent<SpriteRenderer>();


    }

    // Update is called once per frame
    void Update()
    {

    }
    public void OnTriggerStay2D(Collider2D colli)
    {
        if (colli.gameObject.layer == 10)
        {
            ep.enabled = true;
            bx.enabled = true;


            Debug.Log("espaco ok");
        }

    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 10)
        {
            ep.enabled = false;
            bx.enabled = false;

            Debug.Log("espaco off");
        }
    }
}
