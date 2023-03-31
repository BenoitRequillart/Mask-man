using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    private GameObject player;
    private Health playerHealth;
    [SerializeField]
    private int currentStage;
    [SerializeField]
    private List<UnityEditor.SceneAsset> stages;
    [SerializeField]
    private GameObject gameCanva;
    [SerializeField]
    private GameObject pauseCanva;
    [SerializeField]
    private GameObject gameOverCanva;
    [SerializeField]
    private EndPointController endPoint;
    private void Awake()
    {
        playerHealth = player.GetComponent<Health>();
        playerHealth.OnDeath += GameOver;
        endPoint.AsEnd += NextStage;
        currentStage -= 1;
    }

    private void GameOver()
    {
        gameOverCanva.SetActive(true);
        gameCanva.SetActive(false);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void NextStage()
    {
        currentStage += 1;
        if (currentStage < stages.Count)
        {
            SceneManager.LoadScene(stages[currentStage].name);
        }
        else
        {
            SceneManager.LoadScene("MainMenu");
        }
    }
    public void LoadStage()
    {
        SceneManager.LoadScene(stages[currentStage].name);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
