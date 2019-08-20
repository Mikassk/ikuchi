using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class coluna_dir : MonoBehaviour
{
    public bool coll_dr;
    public int sortingOrder = 0;
    public SpriteRenderer sprite;
   
    // Start is called before the first frame update
    void Start()
    {
       // sprite = GetComponent<SpriteRenderer>();   
       
    }

    // Update is called once per frame
    void Update()
    {
        GameObject ikuchi_ = GameObject.Find("ikuchi");
        Ikuchi ikuchi_sc = ikuchi_.GetComponent<Ikuchi>();
        coll_dr = ikuchi_.GetComponent<Ikuchi>().collRT;
        // idle_ = ikuchi_.GetComponent<Ikuchi>().idle;
       // sprite.sortingOrder = sortingOrder;
       if(ikuchi_sc.isdead == true)
        {
            sprite.enabled = false;

        }

        if (coll_dr == true)
        {
            // sprite.enabled = false;
            // gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, 0f);
        //    sprite.sortingOrder =
       //     sortingOrder = 0;

        }
       else if (coll_dr == false)
        {
            // sprite.enabled = true;
            // gameObject.transform.position = new Vector3(transform.position.x, transform.position.y, -4.5f);
        //    sprite.sortingLayerName = "3";
       //     sortingOrder = 3;

        }
        
    }
}
