using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private const float spawnRate = 1.5f;
    public List<GameObject> prefabs;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate); 
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
        //return ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
