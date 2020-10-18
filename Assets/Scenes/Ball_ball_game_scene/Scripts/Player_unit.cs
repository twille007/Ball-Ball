using System.Collections;
using System.Collections.Generic;

public class Player_unit {
    private readonly int _player_id;

    public Player_unit(int player_id) {
        _player_id = player_id;
    }

    public int Get_player_id() {
        return _player_id;
    }
}
