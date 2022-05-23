using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    private const float spawnRate = 1.5f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    private int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnTarget());
        UpdateScore(0); 
    }

    IEnumerator SpawnTarget()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnRate);
            //UpdateScore(1);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
        //return ;
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int scoreDelta)
    {
        score += scoreDelta;
        //score = score + scoreDelta;
        if(score < 0)
        {
            score = 0;
        }
        scoreText.text = " Score: " + score;
    }
}
