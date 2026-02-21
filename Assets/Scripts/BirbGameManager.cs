using System.Linq;
using TMPro;
using UnityEngine;
using System;

public class BirbGameManager : MonoBehaviour
{
    private bool isGameOver = false;

    public GameObject woodPrefab;
    private float spawnerTimer = 0.0f;
    private float rateOfSpawn = 3.0f;
    public Transform[] posRefArray;

    public TextMeshProUGUI timerText;
    private float currentTime;
    private bool timerActive = false;
    public float startTime = 60f;

    public GameObject gameOverScreen;

    private void Start()
    {
        currentTime = startTime;
        timerActive = true;
    }

    private void Update()
    {
        if (isGameOver)
        {
            return;
        }

        if (timerActive)
        {
            if (currentTime > 0)
            {
                currentTime -= Time.deltaTime;
                UpdateTimerDisplay(currentTime);
            }
            else
            {
                timerActive = false;
                currentTime = 0;
                // Add "Game Over" logic here or trigger an event
                Debug.Log("Timer finished!");
            }
        }
        spawnerTimer += Time.deltaTime;

        if (spawnerTimer >= rateOfSpawn)
        {
            SpawnWood();
            spawnerTimer = 0;
        }
    }

    private void SpawnWood()
    {
        int randomPosIdx = UnityEngine.Random.Range(0, posRefArray.Length); // Explicitly using UnityEngine.Random
        Instantiate(woodPrefab, posRefArray[randomPosIdx].position, Quaternion.identity);
    }

    private void UpdateTimerDisplay(float timeInSeconds)
    {
        // Use TimeSpan to easily format minutes and seconds
        TimeSpan t = TimeSpan.FromSeconds(timeInSeconds);
        string timeString = string.Format("{0:00}:{1:00}", t.Minutes, t.Seconds);

        timerText.text = timeString;
    }

    public void EnableGameOver()
    {
        gameOverScreen.SetActive(true);
        isGameOver = true;
    }
}
