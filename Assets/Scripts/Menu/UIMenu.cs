
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenu : MonoBehaviour
{
    public Manager manager;
    public void OnClickGame()
    {
        manager.StartGame();
    }
    public void OnClickCredtis()
    {
        SceneManager.LoadScene("Credits");
    }
}
