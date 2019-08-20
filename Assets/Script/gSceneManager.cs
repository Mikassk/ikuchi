using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class gSceneManager : MonoBehaviour
{
    /** musicas **/
    public AudioClip gameoverSound;
    public AudioClip menuSound;
    public AudioClip gameSound;
    public AudioClip tutorialSound;
    

    /** SFX **/
    public AudioClip clicksound;
    public AudioClip quitsound;
    public AudioSource source;
    public AudioClip creditsound;
    public AudioClip ikuchisound;

    public Button startbutton;
    public Button quit;

    public int CurrentScene = 0;
    public string GameScene = "Game";
    public string CreditsScene = "GameOver";

    public bool tutorialok=false;


   // private float dt = 0;
    public float life ;
    public float ikuchi_life;
    public bool endGame = false;
    public static gSceneManager Instance { get; set; }
    public static string[] Levels = { "stage 1", "stage2", "credits" };
    private static int _level;

    public SceneField startScene;
    public SceneField gameScene;
    public SceneField gameoverScene;
    public SceneField proxScene;
    public SceneField actualScene;
    public SceneField creditScene;
    public SceneField tutorialScene;


  /*  public static int Level
    {
        get { return _level; }
        set
        {
            SceneManager.LoadScene(Levels[value], LoadSceneMode.Single);
            _level = value;
        }
    }*/

    public void Awake()
    {
        source = GetComponent<AudioSource>();
        source.clip = menuSound;
        source.Play();


    }
    // Start is called before the first frame update
    public void Start()
    {
        if (Instance != null)
            Destroy(this);
        Instance = this;
        DontDestroyOnLoad(gameObject);
        actualScene = startScene;
        startbutton.onClick.AddListener(OnStart);
        quit.onClick.AddListener(Onquit);
        


    }
   

    public void OnStart()
    {

      //  dt = 0f;     
        Debug.Log("Start");
        source.PlayOneShot(clicksound, 1f);
        StartCoroutine(startgame());

               
    }
    public void Onquit()
    {
        source.PlayOneShot(quitsound, 3f);
        StartCoroutine(quitgame());
        
    }
    public void Update()
    {
        if (Input.GetKey("escape"))
        {
            Screen.fullScreen = !Screen.fullScreen;
        }
      
        Debug.Log("life: " + life);

        if(proxScene == tutorialScene && actualScene != tutorialScene)
        {
            actualScene = tutorialScene;
            source.clip = tutorialSound;
            source.Play();
            SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
        }
        if (proxScene == gameoverScene && actualScene !=gameoverScene && life <=0)
        {
            actualScene = gameoverScene;
            SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
            source.Stop();
            source.PlayOneShot(gameoverSound, 3f);
        }
        if (proxScene == gameScene && actualScene != gameScene)
        {
            actualScene = gameScene;
            SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
            source.clip = gameSound;
            source.Play();
        }
        if (proxScene == creditScene && actualScene != creditScene)
        {
            actualScene = creditScene;
            source.PlayOneShot(ikuchisound, 3f);
            StartCoroutine(creditsound_());
            
        }
        



    }
    IEnumerator creditsound_()
    {
        yield return new WaitForSeconds(3f);
        SceneManager.LoadScene(proxScene, LoadSceneMode.Single);
        source.clip = creditsound;
        source.Play();

    }
    IEnumerator startgame()
    {
        yield return new WaitForSeconds(0.3f);
        proxScene = tutorialScene;

    }
    IEnumerator quitgame()
    {
        yield return new WaitForSeconds(0.2f);
        Application.Quit();
    }
    // Update is called once per frame
   /* public static void LoadLevel(int level)
    {
        Level = level;
    }
    */
}
    
