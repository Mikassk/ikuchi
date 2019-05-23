using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ikuchicorpo : MonoBehaviour
{

    public bool anim;
    private SpriteRenderer sprite;
    private BoxCollider2D boxcoll;
    private Rigidbody2D rb;
    public bool desable = false;
    // Start is called before the first frame update
    void Awake()
    {
        sprite = GetComponent<SpriteRenderer>();
        boxcoll = GetComponent<BoxCollider2D>();
        rb = GetComponent<Rigidbody2D>();
       



    }
    void Start()
    {
        sprite.enabled = false;
        boxcoll.enabled = false;

     




    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (desable == true)
        {
            sprite.enabled = false;
            boxcoll.enabled = false;
        }
        
    }
    void Update()
    {

        GameObject ikuchi_ = GameObject.Find("ikuchi");
        Ikuchi ikuchi_sc = ikuchi_.GetComponent<Ikuchi>();
        anim = ikuchi_.GetComponent<Ikuchi>().walk;
        if (anim == true)
        {
            desable = false;
            sprite.enabled = true;
            boxcoll.enabled = true;
            
           
        }
        //else
        //{
        //    sprite.enabled = false;
        //    boxcoll.enabled = false;
        //}
        
       
    }


    void OnTriggerExit2D(Collider2D colli)
    {
        
        if (colli.gameObject.layer == 13)
        {
            Debug.Log("saiu: " + colli.gameObject.name);
            desable = true;
            
        }
        
          
    }
   
}
    