using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public int score;
    static Manager instance = null;
    public GameObject player;

    public static Manager Get()
    {
        return instance;
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else if (instance != this)
        {
            Destroy(gameObject);
        }
    }
    void Start()
    {
        Explosion.addScoreBox += ScoreBox;
        Explosion.addScoreEnemy += ScoreEnemy;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ScoreBox()
    {
        score += 100;
    }
    void ScoreEnemy()
    {
        score += 250;
    }

    void StartGame()
    {

    }
    private void OnDisable()
    {
        Explosion.addScoreBox -= ScoreBox;
        Explosion.addScoreEnemy -= ScoreEnemy;
    }
}
