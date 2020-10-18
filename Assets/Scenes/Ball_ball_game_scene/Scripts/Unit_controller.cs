using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit_controller : MonoBehaviour {


    private Rigidbody _rigidbody_player_1;
    private Rigidbody _rigidbody_player_2;

    private Player player_1;
    private Player player_2;

    Player_unit _unit_player_1;
    Player_unit _unit_player_2;

    private bool _game_is_paused;

    private float _movement_horizontal_player_1 = 0;
    private float _movement_vertical_player_1 = 0;
    private float _movement_horizontal_player_2 = 0;
    private float _movement_vertical_player_2 = 0;


    private static readonly float SPEED_MULTIPLIER = 50000f;

    void Start() {
        player_1 = Player_controller.Get_instance().Get_player(0);
        player_2 = Player_controller.Get_instance().Get_player(1);

        _unit_player_1 = player_1.Get_first_unit();
        _unit_player_2 = player_2.Get_first_unit();

        _rigidbody_player_1 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_1).GetComponentInChildren<Rigidbody>();
        _rigidbody_player_2 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_2).GetComponentInChildren<Rigidbody>();
    }

    //TODO: make one controller for each player. better concurency behaviour.
    // Update is called once per frame
    void Update() {

        if(Input.GetKeyDown(KeyCode.Q)) {
            _unit_player_1 = player_1.Get_previous_unit();
            _rigidbody_player_1 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_1).GetComponentInChildren<Rigidbody>();
        }

        if(Input.GetKey(KeyCode.W)) {
            if(_movement_vertical_player_1 < 1) {
                StartCoroutine(Increase_vertical_speed_player_1());
            }
        }

        if(Input.GetKeyDown(KeyCode.E)) {
            _unit_player_1 = player_1.Get_next_unit();
            _rigidbody_player_1 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_1).GetComponentInChildren<Rigidbody>();
        }

        if(Input.GetKey(KeyCode.A)) {
            if(_movement_horizontal_player_1 > -1) {
                StartCoroutine(Decrease_horizontal_speed_player_1());
            }
        }

        if(Input.GetKey(KeyCode.S)) {
            if(_movement_vertical_player_1 > -1) {
                StartCoroutine(Decrease_vertical_speed_player_1());
            }
        }

        if(Input.GetKey(KeyCode.D)) {
            if(_movement_horizontal_player_1 < 1) {
                StartCoroutine(Increase_horizontal_speed_player_1());
            }
        }

        if(Input.GetKey(KeyCode.U)) {
            _unit_player_2 = player_2.Get_previous_unit();
            _rigidbody_player_2 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_2).GetComponentInChildren<Rigidbody>();
        }

        if(Input.GetKey(KeyCode.I)) {
            if(_movement_vertical_player_2 < 1) {
                StartCoroutine(Increase_vertical_speed_player_2());
            }
        }

        if(Input.GetKey(KeyCode.O)) {
            _unit_player_2 = player_2.Get_next_unit();
            _rigidbody_player_2 = Player_controller.Get_instance().Get_gameobject_from_unit(_unit_player_2).GetComponentInChildren<Rigidbody>();
        }

        if(Input.GetKey(KeyCode.J)) {
            if(_movement_horizontal_player_2 > -1) {
                StartCoroutine(Decrease_horizontal_speed_player_2());
            }
        }
        if(Input.GetKey(KeyCode.K)) {
            if(_movement_vertical_player_2 > -1) {
                StartCoroutine(Decrease_vertical_speed_player_2());
            }
        }
        if(Input.GetKey(KeyCode.L)) {
            if(_movement_horizontal_player_2 < 1) {
                StartCoroutine(Increase_horizontal_speed_player_2());
            }
        }

        if(Input.GetKeyDown(KeyCode.Escape)) {
            if(_game_is_paused) {
                Resume();
                Menu_UI.Get_instance().Deactivate_menu();
            }
            else {
                Pause();
                Menu_UI.Get_instance().Activate_menu();
            }

        }

        Vector3 movement_player_1 = new Vector3(_movement_horizontal_player_1 * SPEED_MULTIPLIER * Time.deltaTime, 0.0f, _movement_vertical_player_1 * SPEED_MULTIPLIER * Time.deltaTime);
        Vector3 movement_player_2 = new Vector3(_movement_horizontal_player_2 * SPEED_MULTIPLIER * Time.deltaTime, 0.0f, _movement_vertical_player_2 * SPEED_MULTIPLIER * Time.deltaTime);

        // 3-ways to set direction.
        _rigidbody_player_1.AddForce(movement_player_1);
        _rigidbody_player_2.AddForce(movement_player_2);

        //_rigidbody_player_1.MovePosition(_rigidbody_player_1.transform.position + (movement_player_1 * Time.deltaTime));
        //_rigidbody_player_2.MovePosition(_rigidbody_player_2.transform.position + (movement_player_2 * Time.deltaTime));

        //_rigidbody_player_1.velocity = movement_player_1;
        //_rigidbody_player_2.velocity = movement_player_2;
    }

    private void Resume() {
        Time.timeScale = 1f;
        _game_is_paused = false;
    }

    private void Pause() {
        Time.timeScale = 0;
        _game_is_paused = true;
    }

    // make one-function for acceleration for every direction.
    ///////////////////
    // Player 1:
    ///////////////////

    //W-Key
    private IEnumerator Increase_vertical_speed_player_1() {
        _movement_vertical_player_1 += 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.W));
        _movement_vertical_player_1 = 0;
    }

    //A-Key
    private IEnumerator Decrease_horizontal_speed_player_1() {
        _movement_horizontal_player_1 -= 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.A));
        _movement_horizontal_player_1 = 0;
    }

    //S-Key
    private IEnumerator Decrease_vertical_speed_player_1() {
        _movement_vertical_player_1 -= 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.S));
        _movement_vertical_player_1 = 0;
    }

    //D-Key
    private IEnumerator Increase_horizontal_speed_player_1() {
        _movement_horizontal_player_1 += 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.D));
        _movement_horizontal_player_1 = 0;
    }


    ///////////////////
    // Player 2:
    ///////////////////

    //I-Key
    private IEnumerator Increase_vertical_speed_player_2() {
        _movement_vertical_player_2 += 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.I));
        _movement_vertical_player_2 = 0;
    }

    //J-Key
    private IEnumerator Decrease_horizontal_speed_player_2() {
        _movement_horizontal_player_2 -= 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.J));
        _movement_horizontal_player_2 = 0;
    }

    //K-Key
    private IEnumerator Decrease_vertical_speed_player_2() {
        _movement_vertical_player_2 -= 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.K));
        _movement_vertical_player_2 = 0;
    }

    //L-Key
    private IEnumerator Increase_horizontal_speed_player_2() {
        _movement_horizontal_player_2 += 0.1f;
        yield return new WaitUntil(() => !Input.GetKey(KeyCode.L));
        _movement_horizontal_player_2 = 0;
    }

}
