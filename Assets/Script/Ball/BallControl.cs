using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour
{
    private Rigidbody2D rigidbody2D;

    public float xInitialForce;
    public float yInitialForce;

    private Vector2 trajectoryOrigin;
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();

        RestartGame();

        trajectoryOrigin = transform.position;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ResetBall()
    {
        transform.position = Vector2.zero;

        rigidbody2D.velocity = Vector2.zero;
    }

    private void RestartGame()
    {
        ResetBall();

        Invoke("PushBall", 2);
    }

    private void PushBall()
    {
        //float yRandomInitialForce = Random.Range(-yInitialForce, yInitialForce);

        float randomDirection = Random.Range(0, 2);

        if (randomDirection < 1.0f)
        {
            rigidbody2D.AddForce(new Vector2(-xInitialForce, yInitialForce));
        }
        else
        {
            rigidbody2D.AddForce(new Vector2(xInitialForce, yInitialForce));
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        trajectoryOrigin = transform.position;
    }

    public Vector2 TrajectoryOrigin
    {
        get { return trajectoryOrigin; }
    }
}
