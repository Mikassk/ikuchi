using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_Hero : MonoBehaviour
{
    // -- VARIAVEIS -- //
    
    private Rigidbody2D _rb;
    private float jumpForce = 700;
    private float posPulo = 0f;
    public float distPulo = 0f;
    private float dtJump = 0f;
    private Animator _anim;

    //raycast jumper

    
    private float dist;
  
    

    // ground detector
    public bool grounded = false;

    // -- CLASS MIKO --//

        public class Miko
    {
        public float speed;
        public float mHP;
        public float mForca;
        public float mDefesa;
        public char Name; //talvez eu tire um variado ou coloque no gameManager
    }

    Miko miko = new Miko(); // construtor miko


    // Start is called before the first frame update
    void Awake()
    {
       _rb = GetComponent<Rigidbody2D>();
       _anim = GetComponent<Animator>();
        

    }

    void Update()
    {
       
          
      
            // COMANDS //

        if (Input.GetKeyDown(KeyCode.Z)) // ataque basico
        {
            Debug.Log("attack");
            _anim.SetTrigger("attack");
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
        if (Input.GetAxis("Horizontal") < 0)
        {
            _anim.SetBool("run", true);
            transform.localScale = new Vector3(-1, 1, 1);

        }
        if  (Input.GetAxis("Horizontal") > 0)
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
            Debug.DrawRay(transform.position, Vector2.down*dist, Color.green);
        }

        // -- fim raycast -- //
        if (grounded == true)
        {
            _anim.SetBool("jump", false);
            dtJump = 0f;
            distPulo = 0f;
            var dt = Time.deltaTime;
            miko.speed = 15f;
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
            Debug.Log("posicao do pulo" +posPulo);
            Debug.Log("jumping");
            grounded = false;
           _rb.AddForce(Vector2.up * jumpForce );
            
        }
        if (Input.GetKeyDown("down"))
        {
            _rb.AddForce(Vector2.down * 500);
        }
    }



    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 9)
        {           
            grounded = true;
        }        
    }    
}
