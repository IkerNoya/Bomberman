using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class UIMenu : MonoBehaviour
{
    public Manager manager;
    public void OnClickGame()
    {
        SceneManager.LoadScene("GamePlay");
    }
    public void OnClickCredtis()
    {
        SceneManager.LoadScene("Credits");
    }
}
