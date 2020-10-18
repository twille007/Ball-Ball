using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal_detection : MonoBehaviour {

    void OnTriggerEnter(Collider ball_collider) {
        if(ball_collider.GetComponent<Ball>() != null) {
            if(name == "goal_left") {
                Player_controller.Get_instance().Get_player(1).Shot_goal();
            }
            else if(name == "goal_right") {
                Player_controller.Get_instance().Get_player(0).Shot_goal();
            }
            Ball ball = ball_collider.GetComponent<Ball>();
            StartCoroutine(Shot_goal(ball));
        }
    }

    private IEnumerator Shot_goal(Ball ball) {
        ball.Ball_in_goal();
        yield return new WaitForSeconds(1);
        ball.Reset_ball();
    }

}
