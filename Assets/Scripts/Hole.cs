using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hole : MonoBehaviour {

    private List<Ball> ballsInHole = new List<Ball>();

    public void CheckBalls(List<Ball> balls)
    {
        
        foreach (Ball ball in balls)
        {
            float distance = Vector2.Distance(transform.position, ball.transform.position);

            if (distance < transform.localScale.x / 4)
            {
                ballsInHole.Add(ball);
            }
            else if (distance < transform.localScale.x / 2)
            {
                ball.AddForce(transform.position - ball.transform.position);
            }
        }

        foreach (Ball ball in ballsInHole)
        {
            GameController.BallHole(ball);
        }
        ballsInHole.Clear();
    }
}
