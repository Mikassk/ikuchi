using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikuchi : MonoBehaviour
{
    //variaveis //
    private float dt;
    public bool coluna = false;
    private Animator _anim;
    private SpriteRenderer _spriterender;
    private BoxCollider2D _boxcoll;
    public bool autoTiling_;
    public GameObject corpo1;
    public GameObject corpo2;
    public GameObject corpo3;
    public GameObject corpo4;
    public GameObject corpo5;
    

    public bool walk, collRT, collLT, idle;
    // FIM - variaveis // 


        // classe // 
    public class ikuchi
    {
        public float hp;
        public float speed;
        public float armor;
        public float forca;
    } 
    ikuchi ikuchi_ = new ikuchi();

    // fim - classe //


        // funções principais // 
  
    void Awake()
    {
        
        _anim = GetComponent<Animator>();
        _spriterender = GetComponent<SpriteRenderer>();
       
        _boxcoll = GetComponent<BoxCollider2D>();
        

    } 

    void Start()
    {
        StartCoroutine(state_idle());

    

    } 
    void Update()
    {
        if (transform.lossyScale.x >= 0)
        {
            _boxcoll.size = new Vector2(_spriterender.bounds.size.x / transform.lossyScale.x,
                                                _spriterender.bounds.size.y / transform.lossyScale.y);
        }
        else
        {
            _boxcoll.size = new Vector2(_spriterender.bounds.size.x / -transform.lossyScale.x,
                                               _spriterender.bounds.size.y / transform.lossyScale.y);
        }
        Debug.Log(walk);    


    }

    void FixedUpdate()
    {
        if (walk == true)
        {
            state_walk();
        }

    }

        // fim - funções principais // 


        // **************************     STATES  *************************** //

        // State idle - Inicia no Void Start 1x 
      
    public IEnumerator state_idle()
    {
        _anim.SetBool("walking", false);
      
        yield return new WaitForSeconds(2f);
        walk = true;
            
        
    }
    // State Walk - Inicia com bool Walk = true, ikuchi movimenta horizontalmente

    public void state_walk() 
    {

       ikuchi_.speed = 4f;
        _anim.SetBool("walking", true);
        _anim.SetBool("coll_lt", false);
        _anim.SetBool("coll_rt", false);

        if (coluna == true)
        {
          
            transform.Translate(Vector2.right * ikuchi_.speed * Time.deltaTime);

        }
        else
        {
           
            transform.Translate(Vector2.left * ikuchi_.speed * Time.deltaTime);
         }
       } 

    // State Coluna Esquerda - Inicia na colisão com a coluna esquerda, Ataque de rabo

    public IEnumerator state_colunalt()
    {
        
        Debug.Log("estado coluna esquerdo");
        coluna = true;
        walk = false;
        collLT = true;
        StartCoroutine(Flip());

        _anim.SetBool("walking", false);
        _anim.SetBool("coll_lt", true);
        yield return new WaitForSeconds(1f);
        transform.position = new Vector3(-6f, 7.99f, 0);

        //dt += Time.deltaTime;

        // if (dt >= 0.5f)
        // {
        yield return new WaitForSeconds(4f);
             collLT = false;
            _anim.SetBool("coll_lt", false);
            walk = true;
           
       // }
          
    } 

    // State Coluna Direita - Inicia na colisão com a coluna direita, Ataque vertical

    public IEnumerator state_colunart()
    {
        Debug.Log("estado coluna direito");

        coluna = false;
        walk = false;
        collRT = true;
        StartCoroutine(Flip());

        _anim.SetBool("walking", false);
        _anim.SetBool("coll_rt", true);


        //    dt += Time.deltaTime;
        //   if (dt >= 0.5f)
        // {
        yield return new WaitForSeconds(4f);
        collRT = false;
            _anim.SetBool("coll_lt", false);
            walk = true;
    //    }

      
    } 

    // *********************          FIM STATES          ********************* //


   // Códigos de testes e alterações // 

    private IEnumerator Flip()
    {
        
        yield return new WaitForSeconds(1f);
        if (coluna == true)
        {
            transform.localScale = new Vector2(-15, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(15, transform.localScale.y);
        }        
    } 

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 11)
        {
            
            Debug.Log("colidiu coluna esquerda");
           StartCoroutine( state_colunalt());
           
        }

        if(collision.gameObject.layer == 15)
        {
          
            Debug.Log("colidiu coluna direita");
           StartCoroutine (state_colunart());
         }
        
    } 
 
} //EXIT - CODE 
