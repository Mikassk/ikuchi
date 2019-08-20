using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class goSceneManager : MonoBehaviour
{
    public Button restart;
    public Button quit;
    public AudioClip restartsound;
    public AudioSource source;
    public AudioClip quitsound;

    void Awake()
    {
        source = GetComponent<AudioSource>();
    } 
    // Start is called before the first frame update
    void Start()
    {
       
        Debug.Log(gSceneManager.Instance.CurrentScene);

        restart.onClick.AddListener(OnStart);
        quit.onClick.AddListener(Onquit);
        source.clip = restartsound;
       // source.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Onquit()
    {
        source.clip = quitsound;
        source.Play();
        StartCoroutine(quit_());
    }
    public void OnStart()
    {
        gSceneManager.Instance.life = 80;
        gSceneManager.Instance.ikuchi_life = 100;


        source.Play();
        StartCoroutine(som());
    }
    IEnumerator quit_()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
    IEnumerator som()
    {
       
        yield return new WaitForSeconds(1f);
        gSceneManager.Instance.proxScene = gSceneManager.Instance.gameScene;
    }
 }
