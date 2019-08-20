using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Hero : MonoBehaviour
{
    // -- VARIAVEIS -- //

    private Rigidbody2D _rb;
    private float jumpForce = 900;
    private float posPulo = 0f;
    private float distPulo = 0f;
    private float dtJump = 0f;
    private Animator _anim;
        
    public SpriteRenderer sprite;

    public AudioClip ataque;
    public AudioClip andandodireita;
    public AudioClip andandoesquerda;
    public AudioClip pulando;
    public AudioSource source;

    private float dist;

    private bool dead = false;


    // ground detector
    public bool grounded = false;

    // -- CLASS MIKO --//

    public class Miko
    {
        public float speed;
        public float hp;
        public float Forca;
        public float Defesa;
        public char Name; //talvez eu tire um variado ou coloque no gameManager
    }

    Miko miko = new Miko(); // construtor miko


    // Start is called before the first frame update
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        source = GetComponent<AudioSource>();

    }

    void Start()
    {
        miko.speed = 8f;
    }
    void Update()
    {

        if (gSceneManager.Instance.life <= 0 && dead == false && gSceneManager.Instance.actualScene!=gSceneManager.Instance.gameoverScene)
        {
            dead = true;
            StartCoroutine(anim_dead());

        }
        // COMANDS //

        if (Input.GetKeyDown(KeyCode.Z)) // ataque basico
        {
            Debug.Log("attack");
            _anim.SetTrigger("attack");
            source.PlayOneShot(ataque, 1.0f);
        }
        if (Input.GetKeyDown(KeyCode.X)) // ataque vassoura
        {
            Debug.Log("Varrer");
        }

        if (Input.GetKeyDown(KeyCode.Alpha1)) // poder 1
        {
            Debug.Log("Pwer 1");
        }
        if (Input.GetKeyDown(KeyCode.Alpha2)) // poder 2
        {
            Debug.Log("Pwer 2");
        }
        if (Input.GetKeyDown(KeyCode.Alpha3)) // poder 3
        {
            Debug.Log("Pwer 3");
        }
        //if (Input.GetKey("Down") && gSceneManager.Instance.tutorialok ==true)
       // {
       //     Debug.Log("aaaa");
        //}
        if (Input.GetAxis("Horizontal") < 0)
        {
            _anim.SetBool("run", true);
            transform.localScale = new Vector3(-1, 1, 1);
         }
        if (Input.GetAxis("Horizontal") > 0)
        {
            _anim.SetBool("run", true);
            transform.localScale = new Vector3(1, 1, 1);
        }
        if (Input.GetAxis("Horizontal") == 0)
        {
            _anim.SetBool("run", false);
       
        }
    }



    void FixedUpdate()
    {
        // -- raycast pulo -- //
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector2.down, out hit))
        {
            dist = hit.distance;
            Debug.DrawRay(transform.position, Vector2.down * dist, Color.green);
        }

        // -- fim raycast -- //
        if (grounded == true)
        {
            _anim.SetBool("jump", false);
            dtJump = 0f;
            distPulo = 0f;
            var dt = Time.deltaTime;

            float moveHorizontal = Input.GetAxis("Horizontal");

            transform.position = new Vector3(transform.position.x + moveHorizontal * miko.speed * dt, transform.position.y);


        }
        else
        {
            distPulo = transform.position.x;
            //  Debug.Log("distancia pulo" + distPulo);
            float dsPulo;
            dsPulo = (Mathf.Abs(distPulo)) - (Mathf.Abs(posPulo));
            Debug.Log("Distancia percorrida" + dsPulo);
            //if (Mathf.Abs(dsPulo) <= 4) { 
            var dt = Time.deltaTime;
            miko.speed = 10f;
            float moveHorizontal = Input.GetAxis("Horizontal");


            transform.position = new Vector3(transform.position.x + moveHorizontal * miko.speed * dt, transform.position.y);
            _rb.AddForce(Vector2.down * 1300 * dtJump);

            //  }

            //  _rb.AddForce(Vector2.down * 25);
            // _rb.AddForce(new Vector2(transform.position.x, 25));

        }

        if (Input.GetButtonDown("Jump") && (grounded == true))
        {
            _anim.SetBool("jump", true);
            dtJump += Time.fixedDeltaTime;
            posPulo = transform.position.x;
            Debug.Log("posicao do pulo" + posPulo);
            Debug.Log("jumping");
            grounded = false;
            _rb.AddForce(Vector2.up * jumpForce);

        }
        if (Input.GetKeyDown("down"))
        {
            _rb.AddForce(Vector2.down * 500);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9 || collision.gameObject.layer == 18)
        {
            grounded = true;
        }
        if (collision.gameObject.layer == 12 || collision.gameObject.layer == 17)
        {
           
            if (gSceneManager.Instance.life >= 0)
            {
                gSceneManager.Instance.life -= 1;
                sprite.color = Color.red;
                StartCoroutine(voltacor());
            }
        }
    }

    IEnumerator anim_dead()
    {
        dead = false;
        yield return new WaitForSeconds(0.1f);
        _anim.SetTrigger("isdead");
        yield return new WaitForSeconds(1f);
        gSceneManager.Instance.proxScene = gSceneManager.Instance.gameoverScene;
       
    }
      IEnumerator voltacor()
    {
        yield return new WaitForSeconds(0.1f);
        sprite.color = Color.white;
    }
}
