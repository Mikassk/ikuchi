using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroypedra : MonoBehaviour
{
    private Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnCollisionEnter2D(Collision2D colli)
    {
        if (colli.gameObject.layer == 9 || colli.gameObject.layer == 10 || colli.gameObject.layer == 16)
        {
            _anim.SetBool("nochao", true);
            StartCoroutine(destroy());
            //
        }
    }
    public IEnumerator destroy()
    {
        yield return new WaitForSeconds(0.3f);
            Destroy(gameObject);
    }
}
