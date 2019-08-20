using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class game : MonoBehaviour
{
   
    public bool win=false;
    public bool lose=false;
   // public AudioClip gameoverSound;
   // public AudioSource source;
    // Start is called before the first frame update
    public void Start()
    {
        //  source = GetComponent<AudioSource>();

        DontDestroyOnLoad(gameObject);
        Debug.Log(gSceneManager.Instance.CurrentScene);
            
    }

    public void Update()
    {

      
       if (gSceneManager.Instance.life <= 0)
        {
            win = true;
        }
        if(lose ==true && win == false)
        {
           // gSceneManager.Instance.proxScene = gSceneManager.Instance.gameoverScene;
        }
        if(lose ==false && win == true)
        {

        }
    
    }


    // Update is called once per frame
  
}
