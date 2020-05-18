using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{

    public int score;
    static Manager instance = null;
    public GameObject player;
    Vector3 initialPos = new Vector3(8, 0.55f, -9);

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
        Player.die += Die;
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
    void Die()
    {
        SceneManager.LoadScene("GameOver");
    }

    public void StartGame()
    {
        player.GetComponent<Player>().hp = 2;
        player.GetComponent<Player>().Dead = false;
        player.GetComponent<Player>().end = false;
        player.gameObject.transform.position = initialPos;
        score = 0;
        SceneManager.LoadScene("GamePlay");
    }
    private void OnDisable()
    {
        Explosion.addScoreBox -= ScoreBox;
        Explosion.addScoreEnemy -= ScoreEnemy;
        Player.die -= Die;
    }
}
