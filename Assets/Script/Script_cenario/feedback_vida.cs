using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class feedback_vida : MonoBehaviour
    
{
    public int life_miko; 
    public Animator anim;
    public SceneField verificarscena;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {
        verificarscena = gSceneManager.Instance.actualScene;
        if (gSceneManager.Instance.life <= 40 && gSceneManager.Instance.life > 30 && verificarscena != "gameoverScene")
        {
            anim.SetInteger("life_", 1);
        }
        if(gSceneManager.Instance.life <= 30 && gSceneManager.Instance.life > 20 && verificarscena != "gameoverScene")
        {
            anim.SetInteger("life_", 2);
        }
        if (gSceneManager.Instance.life <= 20 && gSceneManager.Instance.life > 10 && verificarscena != "gameoverScene")
        {
            anim.SetInteger("life_", 3);
        }
        if (gSceneManager.Instance.life <= 10 && gSceneManager.Instance.life > 0 && verificarscena != "gameoverScene")
        {
            anim.SetInteger("life_", 4);
        }
    }
}
