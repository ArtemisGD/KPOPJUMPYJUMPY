using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{


    public bool isPaused;

    public void PauseGame()
    {
        isPaused = !isPaused; //true
        print(message: "Valor actual de isPaused" + isPaused);
        if (isPaused)
            Time.timeScale = 0;
        else if (!isPaused)
            Time.timeScale = 1;
    }


}
