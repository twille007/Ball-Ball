using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_controller : MonoBehaviour {
    private static Player_controller _instance;

    public GameObject _player_unit_prefab;

    private List<Player> _player;
    private List<GameObject> _player_units;

    private Dictionary<Player_unit, GameObject> _unit_to_gameobject;

    private static readonly int PLAYER_NUMBER = 2;
    private static readonly int UNITS_PER_PLAYER = 3;

    private static int ID_COUNTER;

    public static Player_controller Get_instance() {
        return _instance;
    }

    void Awake() {
        if(_instance == null) {
            _instance = this;
        }
        _player = new List<Player>();
        _unit_to_gameobject = new Dictionary<Player_unit, GameObject>();
        ID_COUNTER = 0;
    }

    // Start is called before the first frame update
    void Start() {
        Initialize_player(PLAYER_NUMBER, UNITS_PER_PLAYER);
    }

    public void Initialize_player(int number_of_players, int units_per_player) {
        if(_player_units == null) {
            _player_units = new List<GameObject>();
        }
        for(int i = 0; i < number_of_players; i++) {
            Player player = new Player();
            ID_COUNTER++;
            _player.Add(player);
            Initialize_units(player.Get_player_id(), units_per_player);
        }
    }

    public int Get_next_id() {
        return ID_COUNTER;
    }

    public void Initialize_units(int player_id, int units_per_player) {

        int player_offset = 1;

        for(int j = 0; j < units_per_player; j++) {
            Player_unit unit = new Player_unit(player_id);
            if(player_id % 2 == 0) {
                player_offset = -1;
            }
            else {
                player_offset = 1;
            }
            Vector3 position = new Vector3(30 * player_offset, 0, j * 20);
            position.z -= 20;
            GameObject unit_gameobject = Instantiate(_player_unit_prefab, position, Quaternion.identity, this.transform);

            if(player_id == 0) {
                unit_gameobject.name = "Ball_player_1";
                MeshRenderer mesh_renderer_unit = unit_gameobject.GetComponentInChildren<MeshRenderer>();
                mesh_renderer_unit.material = Player_color_material.Get_instance().Get_material_player_1();
            }
            else if(player_id == 1) {
                unit_gameobject.name = "Ball_player_2";
                MeshRenderer mesh_renderer_unit = unit_gameobject.GetComponentInChildren<MeshRenderer>();
                mesh_renderer_unit.material = Player_color_material.Get_instance().Get_material_player_2();
            }
            _player[player_id].Add_unit_to_player(unit);
            _unit_to_gameobject[unit] = unit_gameobject;
            _player_units.Add(unit_gameobject);
        }
    }

    public GameObject Get_gameobject_from_unit(Player_unit unit) {
        return _unit_to_gameobject[unit];
    }


    public Player Get_player(int id) {
        return _player[id];
    }
}
