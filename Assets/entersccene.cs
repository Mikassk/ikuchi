using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class entersccene : MonoBehaviour
{
    public AudioSource source;
    public AudioClip enter;

    public bool ok = false;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ok == true && gSceneManager.Instance.proxScene != gSceneManager.Instance.gameScene)
        {
            Debug.Log("poucasideias");
            if (Input.GetKey("up") && gSceneManager.Instance.tutorialok ==true ){
                Debug.Log("aaa");
                source.clip = enter;
                source.Play();
                StartCoroutine(enterGame());
               
            }
           
        }
       

    }
    public void OnTriggerStay2D(Collider2D colli)
    {
        if (colli.gameObject.layer == 10)
        {
            ok = true;

            Debug.Log("ok");
        }

    }
    public void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.layer == 10)
        {
            ok = false;

            Debug.Log("not ok");
        }
    }
    IEnumerator enterGame()
    {
        yield return new WaitForSeconds(0.5f);
        gSceneManager.Instance.proxScene = gSceneManager.Instance.gameScene;
    }


}
