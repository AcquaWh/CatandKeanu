using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    [SerializeField]
    Button btnNewGame;
    [SerializeField]
    Button btnQuitGame;

    void Awake()
    {
        btnNewGame.onClick.AddListener(NewGame);
        btnQuitGame.onClick.AddListener(QuitGame);
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level-1");
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
