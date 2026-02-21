using System.Linq;
using TMPro;
using UnityEngine;

public class BirbGameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public GameObject woodPrefab;
    private float spawnerTimer = 0.0f;
    private float rateOfSpawn = 3.0f;
    public Transform[] posRefArray;

    public TMP_Text scoreText;
    private int score = 0;

    public GameObject gameOverScreen;

    private void Start()
    {
        UpdateScoreText();
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        spawnerTimer += Time.deltaTime;

        if(spawnerTimer >= rateOfSpawn)
        {
            SpawnWood();
            spawnerTimer = 0;
        }
    }


    private void SpawnWood()
    {
        int randomPosIdx = Random.Range(0, posRefArray.Length);
        Instantiate(woodPrefab, posRefArray[randomPosIdx].position, Quaternion.identity);
    }

    public void AddScore()
    {
        score++;
        UpdateScoreText();
    }
    private void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    public void EnableGameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }

}
