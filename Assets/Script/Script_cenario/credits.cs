using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class credits : MonoBehaviour
{
    public Button quit;
    public AudioSource source;
    public AudioClip quitsound;
    // Start is called before the first frame update
    void Start()
    {
        source = GetComponent<AudioSource>();
        quit.onClick.AddListener(Onquit);
        source.clip = quitsound;
    }

    
    public void Onquit()
    {
        source.clip = quitsound;
        source.Play();
        StartCoroutine(quit_());
    }

    IEnumerator quit_()
    {
        yield return new WaitForSeconds(0.5f);
        Application.Quit();
    }
}
