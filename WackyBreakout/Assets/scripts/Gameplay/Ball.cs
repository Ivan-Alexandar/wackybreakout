using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ball
/// </summary>
public class Ball : MonoBehaviour
{
    // move delay timer
    Timer moveTimer;

    // death timer
    Timer deathTimer;

    //speedup timer
    Rigidbody2D rb2d;
    Timer speedUpTimer;
    float speedUpFactor;
	/// <summary>
	/// Use this for initialization
	/// </summary>
	void Start()
	{
        //speedup effect support
        speedUpTimer = gameObject.AddComponent<Timer>();
        EventManager.AddSpeedUpEffectListener(HandleSpeedUpEffectActivatedEvent);
        rb2d = GetComponent<Rigidbody2D>();
        // start move timer
        moveTimer = gameObject.AddComponent<Timer>();
        moveTimer.Duration = 1;
        moveTimer.Run();

        // start death timer
        deathTimer = gameObject.AddComponent<Timer>();
        deathTimer.Duration = ConfigurationUtils.BallLifeSeconds;
        deathTimer.Run();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
	{
        // move when time is up
        if (moveTimer.Finished)
        {
            moveTimer.Stop();
            StartMoving();
        }

		// die when time is up
        if (deathTimer.Finished)
        {
            // spawn new ball and destroy self
            Camera.main.GetComponent<BallSpawner>().SpawnBall();
            Destroy(gameObject);
        }
        if (speedUpTimer.Finished)
        {
            speedUpTimer.Stop();
            rb2d.velocity *= 1 / speedUpFactor;
        }
	}

    /// <summary>
    /// Spawn new ball and destroy self when out of game
    /// </summary>
    void OnBecameInvisible()
    {
        // death timer destruction is in Update
        if (!deathTimer.Finished)
        {
            // only spawn a new ball if below screen
            float halfColliderHeight = 
                gameObject.GetComponent<BoxCollider2D>().size.y / 2;
            if (transform.position.y - halfColliderHeight < ScreenUtils.ScreenBottom)
            {
                Camera.main.GetComponent<BallSpawner>().SpawnBall();
                HUD.ReduceBallsLeft();
            }
            Destroy(gameObject);
        }
    }

    /// <summary>
    /// Starts the ball moving
    /// </summary>
    void StartMoving()
    {
        // get the ball moving
        float angle = -90 * Mathf.Deg2Rad;
        Vector2 force = new Vector2(
            ConfigurationUtils.BallImpulseForce * Mathf.Cos(angle),
            ConfigurationUtils.BallImpulseForce * Mathf.Sin(angle));
        GetComponent<Rigidbody2D>().AddForce(force);
    }

    /// <summary>
    /// Sets the ball direction to the given direction
    /// </summary>
    /// <param name="direction">direction</param>
    public void SetDirection(Vector2 direction)
    {
        // get current rigidbody speed
        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        float speed = rb2d.velocity.magnitude;
        rb2d.velocity = direction * speed;
    }
    void HandleSpeedUpEffectActivatedEvent(float duration, float speedUpFactor)
    {
        if (!speedUpTimer.Running)
        {
            StartSpeedUpEffect(duration, speedUpFactor);
            rb2d.velocity *= speedUpFactor;
        }
        else
        {
            speedUpTimer.AddTime(duration);
        }
    }
    void StartSpeedUpEffect(float duration, float speedUpFactor)
    {
        this.speedUpFactor = speedUpFactor;
        speedUpTimer.Duration = duration;
        speedUpTimer.Run();
    }
}