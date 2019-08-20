using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pedras : MonoBehaviour
{
    public GameObject pedra;
    public Transform Spawn;
    public bool canSpawn = true;
    public bool code = false;
    public float timer;
   
    
    // Start is called before the first frame update
    void Start()
    {
        Spawn = GetComponent<Transform>();
        timer = 1f;
       

    }

    // Update is called once per frame
    void Update()
    {
        if (canSpawn == true && code == true)
        {
            StartCoroutine(Spawner());
            canSpawn = false;
        }
        if (code == false)
        {
            canSpawn = true;
        }

    }
    public IEnumerator Spawner()
    {
        int x = 0;
        
        for (int i = 0; i < 5f; i++)
        {
            yield return new WaitForSeconds(timer);
            var rock = (GameObject)Instantiate(pedra, Spawn);
            
        }
        code = false;
    }
   
    
}
