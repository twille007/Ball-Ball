using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {

    private Vector3 _position;

    private Vector3 _throw_in_position;

    private int _last_player_hit_the_ball;

    private bool _throw_in;

    private bool _edge_ball;

    private Rigidbody _rigidbody;

    void Start() {
        _rigidbody = GetComponent<Rigidbody>();
    }

    void Update() {
        _position = transform.position;
        Hold_ball_in_game();
        /*
         if(Is_ball_in_game()) {

        }
        else {
            if(_throw_in) {
                //Debug.Log("Es dürfte nun einen Einwurf geben für Spieler " + _last_player_hit_the_ball);
            }
            else if(_edge_ball) {
                //Debug.Log("Es dürfte nun einen Eckball geben für Spieler " + _last_player_hit_the_ball);

            }
            else {
                Debug.Log("Should not go in here.");
            }
        }
        */

    }

    public void Ball_in_goal() {
        Debug.Log("wuhu, ein Tor für ");
    }

    public bool Is_goal() {
        return false;
    }



    private void Hold_ball_in_game() {
        Vector3 temp_angular_velocity = _rigidbody.angularVelocity;
        Vector3 temp_velocity = _rigidbody.velocity;

        if(_position.z <= -82) {
            Stop_ball_movement();
            _rigidbody.angularVelocity = new Vector3(temp_angular_velocity.x, temp_angular_velocity.y, -temp_angular_velocity.z);
            _rigidbody.velocity = new Vector3(temp_velocity.x, temp_velocity.y, -temp_velocity.z);
        }

        if(_position.z >= 82) {
            Stop_ball_movement();
            _rigidbody.angularVelocity = new Vector3(temp_angular_velocity.x, temp_angular_velocity.y, -temp_angular_velocity.z);
            _rigidbody.velocity = new Vector3(temp_velocity.x, temp_velocity.y, -temp_velocity.z);

        }

        if(_position.x <= -122) {
            Stop_ball_movement();
            _rigidbody.angularVelocity = new Vector3(-temp_angular_velocity.x, temp_angular_velocity.y, temp_angular_velocity.z);
            _rigidbody.velocity = new Vector3(-temp_velocity.x, temp_velocity.y, temp_velocity.z);
        }

        if(_position.x >= 122) {
            Stop_ball_movement();
            _rigidbody.angularVelocity = new Vector3(-temp_angular_velocity.x, temp_angular_velocity.y, temp_angular_velocity.z);
            _rigidbody.velocity = new Vector3(-temp_velocity.x, temp_velocity.y, temp_velocity.z);
        }
    }

    private bool Is_ball_in_game() {
        bool ball_is_in_game = true;
        if(_position.z <= -82 || _position.z >= 82) {
            ball_is_in_game = false;
            _throw_in_position = _position;
            Stop_ball_movement();
            Make_ball_ready_for_throw_in();
        }
        if(_position.x <= -122 || _position.x >= 122) {
            ball_is_in_game = false;
            Stop_ball_movement();
            Make_ball_ready_for_edge_ball();
        }
        return ball_is_in_game;
    }

    private void Stop_ball_movement() {
        _rigidbody.angularVelocity = Vector3.zero;
        _rigidbody.velocity = Vector3.zero;
    }

    public void Reset_ball() {
        _rigidbody.position = new Vector3(0, 0, 0);
        Stop_ball_movement();
    }

    private void Make_ball_ready_for_throw_in() {
        _throw_in = true;
        //TODO:
    }

    private void Make_ball_ready_for_edge_ball() {
        _edge_ball = true;
        //TODO:
    }

    void OnCollisionEnter(Collision collision) {
        //TODO: enum instead of hardcoded string
        if(collision.gameObject.transform.parent.name == "Ball_player_1") {
            _last_player_hit_the_ball = 1;
        }
        else if(collision.gameObject.transform.parent.name == "Ball_player_2") {
            _last_player_hit_the_ball = 2;
        }
    }

}

