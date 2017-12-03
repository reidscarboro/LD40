using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public static GameController instance;

    public Ball prefab_ball;

    private List<Ball> balls;
    private Hole hole;

    void Awake()
    {
        instance = this;
        balls = new List<Ball>();
        hole = FindObjectOfType<Hole>();
    }

    void Update()
    {
        hole.CheckBalls(balls);
    }

    public static void RegisterBall(Ball ball)
    {
        instance.balls.Add(ball);
    }

    public static void BallHole(Ball ball)
    {
        instance.balls.Remove(ball);
        Destroy(ball.gameObject);
    }

    public static void Shoot(Vector2 force)
    {
        foreach (Ball ball in instance.balls)
        {
            ball.AddForce(force);
            ball.DisableForceVector();
        }
    }

    public static void DrawForceVectors(Vector2 force)
    {
        foreach (Ball ball in instance.balls)
        {
            ball.DrawForceVector(force);
        }
    }

    public static void SpawnBall(Vector2 position, Vector2 speed)
    {
        if (instance.balls.Count < 20)
        {
            Ball ball = Instantiate(instance.prefab_ball, position, Quaternion.identity);
            ball.AddForce(speed);
        }
        
    }
}
