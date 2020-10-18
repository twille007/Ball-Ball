using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_color_material : MonoBehaviour {

    [SerializeField] public List<Material> _player_colors;

    private static Player_color_material _instance;

    public static Player_color_material Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
    }

    public Material Get_material_player_1() {
        return _player_colors[0];
    }

    public Material Get_material_player_2() {
        return _player_colors[1];
    }

}