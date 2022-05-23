using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    private float spawnRate = 1.5f;
    public List<GameObject> prefabs;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI gameoverText;
    public Button restartButton;
    public GameObject TitleScreen;

    private int score = 0;
    public bool gameActive = false;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartGame(int diff)
    {
        spawnRate = spawnRate / diff;
        gameActive = true;
        score = 0;
        Debug.Log("Game spawn rate = " + spawnRate);
        StartCoroutine(SpawnTarget());
        UpdateScore(0);
        TitleScreen.gameObject.SetActive(false);
    }

    public void GameOver()
    {
        gameActive = false;
        gameoverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
    }
    IEnumerator SpawnTarget()
    {
        while (gameActive)
        {
            yield return new WaitForSeconds(spawnRate);
            Instantiate(prefabs[Random.Range(0, prefabs.Count)]);
        }
        //return ;
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

    public void GameRestart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
