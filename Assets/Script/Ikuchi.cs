using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikuchi : MonoBehaviour
{
    //variaveis //
    private float dt;
    public bool coluna = false;
    private Animator _anim;
    public SpriteRenderer _spriterender;
    private BoxCollider2D _boxcoll;
    private PolygonCollider2D _poly;
    public bool autoTiling_;
    public GameObject corpo1;
    public GameObject corpo2;
    public GameObject corpo3;
    public GameObject corpo4;
    public GameObject corpo5;
   // public GameObject coluna_esquerda, coluna_direita;

    public bool walk, collRT, collLT, idle,isdead;
    // FIM - variaveis // 


        // atributos // 
   
        public float hp;
        public float speed;
       



        // funções principais // 
  
    void Awake()
    {
        speed = 12f;
        //hp = 150;
        idle = true;
        _anim = GetComponent<Animator>();
        _spriterender = GetComponent<SpriteRenderer>();
       
        _boxcoll = GetComponent<BoxCollider2D>();
        //_poly = GetComponent<PolygonCollider2D>();
       

    } 

    void Start()
    {
        
        StartCoroutine(state_idle());

    } 
    void Update()
    {
        GameObject spawn1_ = GameObject.Find("spawn1");
        pedras spawn1__ = spawn1_.GetComponent<pedras>();

        GameObject spawn3_ = GameObject.Find("spawn3");
        pedras spawn3__ = spawn3_.GetComponent<pedras>();

        GameObject spawn2_ = GameObject.Find("spawn2");
        pedras spawn2__ = spawn2_.GetComponent<pedras>();

        GameObject spawn4_ = GameObject.Find("spawn4");
        pedras spawn4__ = spawn4_.GetComponent<pedras>();

        GameObject spawn6_ = GameObject.Find("spawn6");
        pedras spawn6__ = spawn6_.GetComponent<pedras>();

        GameObject spawn5_ = GameObject.Find("spawn5");
        pedras spawn5__ = spawn5_.GetComponent<pedras>();

        GameObject spawn7_ = GameObject.Find("spawn7");
        pedras spawn7__ = spawn7_.GetComponent<pedras>();

        GameObject spawn8_ = GameObject.Find("spawn8");
        pedras spawn8__ = spawn8_.GetComponent<pedras>();

        GameObject spawn9_ = GameObject.Find("spawn9");
        pedras spawn9__ = spawn9_.GetComponent<pedras>();

        GameObject spawn10_ = GameObject.Find("spawn10");
        pedras spawn10__ = spawn10_.GetComponent<pedras>();

        if (gSceneManager.Instance.ikuchi_life <= 80)
        {
            speed = 15;
           
            spawn1__.GetComponent<pedras>().timer = 1.2f;
            spawn3__.GetComponent<pedras>().timer = 1.2f;
            spawn2__.GetComponent<pedras>().timer = 1.2f;
            spawn4__.GetComponent<pedras>().timer = 1.2f;
            spawn6__.GetComponent<pedras>().timer = 1.2f;
            spawn5__.GetComponent<pedras>().timer = 1.2f;
            spawn7__.GetComponent<pedras>().timer = 1.2f;
            spawn8__.GetComponent<pedras>().timer = 1.2f;
            spawn9__.GetComponent<pedras>().timer = 1.2f;
            spawn10__.GetComponent<pedras>().timer = 1.2f;

        }
        if (gSceneManager.Instance.ikuchi_life <= 50)
        {
            speed = 18;
            spawn1__.GetComponent<pedras>().timer = 1f;
            spawn3__.GetComponent<pedras>().timer = 1f;
            spawn2__.GetComponent<pedras>().timer = 1f;
            spawn4__.GetComponent<pedras>().timer = 1f;
            spawn6__.GetComponent<pedras>().timer = 1f;
            spawn5__.GetComponent<pedras>().timer = 1f;
            spawn7__.GetComponent<pedras>().timer = 1f;
            spawn8__.GetComponent<pedras>().timer = 1f;
            spawn9__.GetComponent<pedras>().timer = 1f;
            spawn10__.GetComponent<pedras>().timer = 1f;
        }

        if (gSceneManager.Instance.ikuchi_life <= 30)
        {
            speed = 22;
            spawn1__.GetComponent<pedras>().timer = 0.8f;
            spawn3__.GetComponent<pedras>().timer = 0.8f;
            spawn2__.GetComponent<pedras>().timer = 0.8f;
            spawn4__.GetComponent<pedras>().timer = 0.8f;
            spawn6__.GetComponent<pedras>().timer = 0.8f;
            spawn5__.GetComponent<pedras>().timer = 0.8f;
            spawn7__.GetComponent<pedras>().timer = 0.8f;
            spawn8__.GetComponent<pedras>().timer = 0.8f;
            spawn9__.GetComponent<pedras>().timer = 0.8f;
            spawn10__.GetComponent<pedras>().timer = 0.8f;
        }

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
      //  Debug.Log(walk);    


    }

    void FixedUpdate()
    {

        if (gSceneManager.Instance.ikuchi_life <= 0 && isdead ==false)
        {
            isdead = true;
            StartCoroutine(dead());
        }
       
        if (walk == true)
        {
            state_walk();
        }

    }




        // **************************     STATES  *************************** //

        // State idle - Inicia no Void Start 1x 
      
    public IEnumerator state_idle()
    {
        
        idle = true;
        collRT = true;
        //_anim.SetBool("walking", false);
        yield return new WaitForSeconds(2f);
        _anim.SetBool("walking", true);
        yield return new WaitForSeconds(0.35f);
        idle = false;
        collRT = false;
        walk = true;

            
        
    }
    // State Walk - Inicia com bool Walk = true, ikuchi movimenta horizontalmente

    public void state_walk() 
    {
       
       
        
        _anim.SetBool("coll_lt", false);
        _anim.SetBool("coll_rt", false);

        if (coluna == true && isdead ==false)
        {
          //  Reset(_poly);
            // ResetCollider();
            //_anim.SetBool("walking", true);
            transform.position = new Vector3(transform.position.x,2.6f, transform.position.z);
            transform.Translate(Vector2.right * speed * Time.deltaTime);

        }
        else if (coluna == false &&isdead==false)
        {
         //   Reset();
            //ResetCollider();
            //  _anim.SetBool("walking", true);
            transform.position = new Vector3(transform.position.x, 2.6f, transform.position.z);
            transform.Translate(Vector2.left * speed * Time.deltaTime);
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
        

        //_anim.SetBool("walking", false);
        _anim.SetBool("coll_lt", true);
      //  Reset();
        // ResetCollider();
        yield return new WaitForSeconds(1f);
       
        transform.position = new Vector3(-16f, 8.5f, 0);

        yield return new WaitForSeconds(4f);
        collLT = false;
        _anim.SetBool("coll_lt", false);
        

        yield return new WaitForSeconds(0.3f);
        
        walk = true;
             

    }

    // State Coluna Direita - Inicia na colisão com a coluna direita, Ataque vertical

    public IEnumerator state_colunart()
    {
        Debug.Log("estado coluna direito");

        coluna = false;
        walk = false;
        
        StartCoroutine(Flip());

       // _anim.SetBool("walking", false);
        _anim.SetBool("coll_rt", true);
        collRT = true;
        // Reset();
        //  ResetCollider();        
        yield return new WaitForSeconds(1f);

        transform.position = new Vector3(30.4f, 8.5f, 0);
         StartCoroutine(droppedra());
        yield return new WaitForSeconds(12f);
        _anim.SetBool("coll_lt", false);
        collRT = false;

        yield return new WaitForSeconds(0.3f);
        walk = true;

    }

    IEnumerator dead()
    {
        if (isdead == true)
        {
            speed = 0f;
            if (collLT == true)
            {
                _anim.SetBool("dead", true);
            }
            if (collRT == true)
            {
                _anim.SetBool("dead", true);
            }
            if (collRT == false)
            {
                _anim.SetBool("dead_walk", true);
            }
            if (collLT == false)
            {
                _anim.SetBool("dead_walk", true);
            }
            yield return new WaitForSeconds(2f);
            gSceneManager.Instance.proxScene = gSceneManager.Instance.creditScene;

        }
    }
    // *********************          FIM STATES          ********************* //


    // Códigos de testes e alterações // 

    public IEnumerator droppedra()
    {
        GameObject spawn1_ = GameObject.Find("spawn1");
        pedras spawn1__ = spawn1_.GetComponent<pedras>();
        spawn1__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn3_ = GameObject.Find("spawn3");
        pedras spawn3__ = spawn3_.GetComponent<pedras>();
        spawn3__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn2_ = GameObject.Find("spawn2");
        pedras spawn2__ = spawn2_.GetComponent<pedras>();
        spawn2__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn4_ = GameObject.Find("spawn4");
        pedras spawn4__ = spawn4_.GetComponent<pedras>();
        spawn4__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn6_ = GameObject.Find("spawn6");
        pedras spawn6__ = spawn6_.GetComponent<pedras>();
        spawn6__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn5_ = GameObject.Find("spawn5");
        pedras spawn5__ = spawn5_.GetComponent<pedras>();
        spawn5__.GetComponent<pedras>().code = true;
        
        yield return new WaitForSeconds(0.15f);

        GameObject spawn7_ = GameObject.Find("spawn7");
        pedras spawn7__ = spawn7_.GetComponent<pedras>();
        spawn7__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn9_ = GameObject.Find("spawn9");
        pedras spawn9__ = spawn9_.GetComponent<pedras>();
        spawn9__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn8_ = GameObject.Find("spawn8");
        pedras spawn8__ = spawn8_.GetComponent<pedras>();
        spawn8__.GetComponent<pedras>().code = true;

        yield return new WaitForSeconds(0.15f);

        GameObject spawn10_ = GameObject.Find("spawn10");
        pedras spawn10__ = spawn10_.GetComponent<pedras>();
        spawn10__.GetComponent<pedras>().code = true;
        
    }

    private IEnumerator Flip()
    {
        
        yield return new WaitForSeconds(1f);
        if (coluna == true)
        {
            transform.localScale = new Vector2(-17, transform.localScale.y);
        }
        else
        {
            transform.localScale = new Vector2(17, transform.localScale.y);
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
