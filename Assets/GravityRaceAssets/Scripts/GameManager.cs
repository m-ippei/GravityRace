using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public UnityEngine.UI.Text label;
    private float timer = 0;
    private float countdown = 3.0f;
    private string gameState = "ready";
	
	// Update is called once per frame
	void Update () {
        if (gameState=="start")
        {
            timer += Time.deltaTime;
            label.text = "TIME: " + timer.ToString("f2");
        }
        else if(gameState == "ready")
        {
            if(countdown < 0)
            {
                gameState = "start";
            }
            countdown -= Time.deltaTime;
            label.text = "Ready... " + countdown.ToString("f2");
        }else if(gameState == "end")
        {
            label.text = "CLEAR TIME: " + timer.ToString("f2") + "\nRestart:SPACE KEY or Y Button";
        }
        
	}

    public string state()
    {
        return gameState;
    }

    public void changeState(string state)
    {
        gameState = state;
    }
}
