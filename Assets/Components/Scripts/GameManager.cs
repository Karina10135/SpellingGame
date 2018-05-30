using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public string playerName;
    public bool inPlay;
    public bool paused;

    public static GameManager GM;

    private void Start()
    {
        GM = this;
        inPlay = true;
        if (GM != this)
        {
            Destroy(gameObject);
        }
        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (!inPlay)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1f; }

        
    }

    public void PauseGame()
    {
        paused = !paused;

        if (paused)
        {
            Time.timeScale = 0f;

        }
        else { Time.timeScale = 1f; }
    }

    public void SetName(Text name)
    {
        if(name.text.Length == 0) { return; }

        playerName = name.text.ToUpper();
        inPlay = true;

        SceneManager.LoadScene("Main");

        //Camera.main.GetComponent<LockMouse>().enabled = true;



    }

    


}
