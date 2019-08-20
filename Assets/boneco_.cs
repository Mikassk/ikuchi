using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boneco_ : MonoBehaviour
{
    public AudioSource source;
    public AudioClip bate;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 16)
        {
            Debug.Log("bateu em mim");
            source.PlayOneShot(bate, 3f);
            anim.SetTrigger("ishit");
        }
    }
}
