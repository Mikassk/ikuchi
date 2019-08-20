using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class teclaz : MonoBehaviour
{
    public GameObject tclz;
    public GameObject setacim;

    public SpriteRenderer z;
    public SpriteRenderer cim;
    // Start is called before the first frame update
    void Start()
    {
        z = tclz.GetComponent<SpriteRenderer>();   
        cim=setacim.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerStay2D(Collider2D colli)
    {
        if (colli.gameObject.layer == 10)
        {
            z.enabled = true;
            cim.enabled = true;
            gSceneManager.Instance.tutorialok = true;
            Debug.Log("setar ok");
        }

    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 10)
        {
            z.enabled = false;
           
            Debug.Log("setas off");
        }
    }
}
