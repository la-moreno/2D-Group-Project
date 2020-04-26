using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class PauseMenu : MonoBehaviour
{
    private GameObject player;
    private GameObject inventoryUI;
    private Scene scene;
    public static bool gameIsPaused;
    public GameObject pauseMenuUI;
   
    void Start()
    {
        inventoryUI = GameObject.Find("Inventory");
        player = GameObject.FindGameObjectWithTag("Player"); 
        scene = SceneManager.GetActiveScene();
        gameIsPaused = false;

    }


    // Update is called once per frame
    void Update()
    {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (gameIsPaused)
                    Resume();
                else
                    Pause(); 
            }
    }

    public void Resume()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        player.GetComponent<PlayerController>().enabled = true;
        player.GetComponent<PlayerAttack>().enabled = true;
        inventoryUI.SetActive(true); 
        gameIsPaused = false;
    }

    void Pause()
    {
        gameIsPaused = true;
        pauseMenuUI.SetActive(true);
        player.GetComponent<PlayerController>().enabled = false;
        player.GetComponent<PlayerAttack>().enabled = false;
        inventoryUI.SetActive(false); 
        Time.timeScale = 0f;
        
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainMenu");
    }

    public void QuitGame()
    {
        Debug.Log("Leaving Game");
        Application.Quit();
    }

}
