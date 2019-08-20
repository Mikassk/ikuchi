using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coluna_esq : MonoBehaviour
{
    public bool coll_esq;
    private SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
     //   sprite = GetComponent<SpriteRenderer>();   
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ikuchi_ = GameObject.Find("ikuchi");
        Ikuchi ikuchi_sc = ikuchi_.GetComponent<Ikuchi>();
        coll_esq = ikuchi_.GetComponent<Ikuchi>().collLT;
        if (ikuchi_sc.isdead == true)
        {
            sprite.enabled = false;

        }

        if (coll_esq == true)
        {
      //      sprite.enabled = false;
            transform.position = new Vector3(transform.position.x, transform.position.y, 0f);

        }
       else if (coll_esq == false)
        {
       //     sprite.enabled = true;
            transform.position = new Vector3(transform.position.x, transform.position.y, -4.5f);

        }
        
    }
}
