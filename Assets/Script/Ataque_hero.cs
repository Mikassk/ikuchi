using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ataque_hero : MonoBehaviour
{
    public SpriteRenderer m_sprite,m_sprite1, m_sprite2, m_sprite3, m_sprite4, m_sprite5;
    public Color mdefault;
    public AudioSource source;
    public AudioClip hit;
    
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        m_sprite = GetComponent<SpriteRenderer>();
        m_sprite1 = GetComponent<SpriteRenderer>();
        m_sprite2 = GetComponent<SpriteRenderer>();
        m_sprite3 = GetComponent<SpriteRenderer>();
        m_sprite4 = GetComponent<SpriteRenderer>();
        m_sprite5 = GetComponent<SpriteRenderer>();

        GameObject ikuchi__ = GameObject.Find("ikuchi");
        m_sprite = ikuchi__.GetComponent<Ikuchi>()._spriterender;

        GameObject ikuchi1 = GameObject.Find("ikuchi_corpo1");
        m_sprite1 = ikuchi1.GetComponent<ikuchicorpo>().sprite;

        GameObject ikuchi2 = GameObject.Find("ikuchi_corpo2");
        m_sprite2 = ikuchi2.GetComponent<ikuchicorpo>().sprite;
        
        GameObject ikuchi3 = GameObject.Find("ikuchi_corpo3");
        m_sprite3 = ikuchi3.GetComponent<ikuchicorpo>().sprite;

        GameObject ikuchi4 = GameObject.Find("ikuchi_corpo4");
        m_sprite4 = ikuchi4.GetComponent<ikuchicorpo>().sprite;
        
        GameObject ikuchi5 = GameObject.Find("ikuchi_corpo5");
        m_sprite5 = ikuchi5.GetComponent<ikuchicorpo>().sprite;
        // m_sprite.color = mdefault;

    }

    // Update is called once per frame
    void Update()
    {
        
    }
   
    void OnTriggerEnter2D (Collider2D coll)
    {
        if (coll.gameObject.layer ==12 || coll.gameObject.layer == 14)
        {
            source.PlayOneShot(hit, 3f);
            gSceneManager.Instance.ikuchi_life -= 1;
            Debug.Log("Ikuchi hp:" + gSceneManager.Instance.ikuchi_life);
            mdefault = m_sprite.color;
            m_sprite.color = Color.red;
            m_sprite1.color = Color.red;
            m_sprite2.color = Color.red;
            m_sprite3.color = Color.red;
            m_sprite4.color = Color.red;
            m_sprite5.color = Color.red;
            StartCoroutine( voltacor());
        }
            
    }

   
    IEnumerator voltacor()
    {
        yield return new WaitForSeconds(0.1f);
        m_sprite.color = Color.white;
        m_sprite1.color = Color.white;
        m_sprite2.color = Color.white;
        m_sprite3.color = Color.white;
        m_sprite4.color = Color.white;
        m_sprite5.color = Color.white;
    }
    
}
