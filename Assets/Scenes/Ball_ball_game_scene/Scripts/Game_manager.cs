using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_manager : MonoBehaviour {

    private static Game_manager _instance;


    public static Game_manager Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
    }

    public void Reload_scene() {
        //SceneManager.LoadScene("Ball_ball_game_scene");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        Time.timeScale = 1f;
    }

    public void Exit_game() {
        Application.Quit();
    }
}