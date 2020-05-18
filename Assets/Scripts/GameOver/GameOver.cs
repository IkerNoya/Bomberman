
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Text score;
    public Manager manager;
    void Start()
    {
        manager = FindObjectOfType<Manager>();
        score.text = "Score: " + manager.score.ToString();
    }
    public void OnClickGame()
    {
        manager.StartGame();
    }
    public void OnClickMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    public void OnClickCredits()
    {
        SceneManager.LoadScene("Credits");
    }

}
