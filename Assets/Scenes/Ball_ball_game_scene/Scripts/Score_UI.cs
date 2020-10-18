using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Score_UI : MonoBehaviour {

    private static Score_UI _instance;

    public Text _player_1_goals;
    public Text _player_2_goals;

    public Image _player_1_image;
    public Image _player_2_image;

    public static Score_UI Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
        _player_1_goals.text = "0";
        _player_2_goals.text = "0";
    }

    void Start() {
        _player_1_image.color = Player_color_material.Get_instance().Get_material_player_1().color;
        _player_2_image.color = Player_color_material.Get_instance().Get_material_player_2().color;
    }

    private void Update_player_1_goals() {
        _player_1_goals.text = Player_controller.Get_instance().Get_player(0).Get_goals().ToString();
    }

    private void Update_player_2_goals() {
        _player_2_goals.text = Player_controller.Get_instance().Get_player(1).Get_goals().ToString();
    }

    public void Update_UI() {
        _player_1_goals.text = Player_controller.Get_instance().Get_player(0).Get_goals().ToString();
        _player_2_goals.text = Player_controller.Get_instance().Get_player(1).Get_goals().ToString();
    }

}
