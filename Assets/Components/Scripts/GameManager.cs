using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public string playerName;
    public bool inPlay;

    public static GameManager GM;

    private void Start()
    {
        GM = this;
    }

    private void Update()
    {
        if (!inPlay)
        {
            Time.timeScale = 0f;
        }
        else { Time.timeScale = 1f; }
    }

    public void SetName(Text name)
    {
        playerName = name.text;
            //name.ToString();
        inPlay = true;

        Camera.main.GetComponent<LockMouse>().enabled=true;

    }
    
    public void CheckName(GameObject name)
    {
        //if (name.GetComponent<InputField>().text.Contains())
        //{

        //}
    }

}
