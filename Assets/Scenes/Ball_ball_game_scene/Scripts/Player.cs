using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    private List<Player_unit> _units;

    private int _id;

    private int _goals;

    private int _selected_unit_id = 0;



    public Player() {
        _id = Player_controller.Get_instance().Get_next_id();
        _units = new List<Player_unit>();
        _goals = 0;
    }

    public void Add_unit_to_player(Player_unit unit) {
        _units.Add(unit);
    }

    public int Get_player_id() {
        return _id;
    }

    public Player_unit Get_first_unit() {
        _units[_selected_unit_id].Get_player_id();
        return _units[_selected_unit_id];
    }

    public Player_unit Get_next_unit() {
        _selected_unit_id++;
        if(_selected_unit_id >= _units.Count) {
            _selected_unit_id = 0;
        }
        return _units[_selected_unit_id];
    }

    public Player_unit Get_previous_unit() {
        _selected_unit_id--;
        if(_selected_unit_id < 0) {
            _selected_unit_id = _units.Count - 1;
        }
        return _units[_selected_unit_id];
    }

    public void Shot_goal() {
        _goals++;
        Score_UI.Get_instance().Update_UI();
    }

    public int Get_goals() {
        return _goals;
    }

}
