using UnityEngine;
public class ScriptP2 : MonoBehaviour
{
    [SerializeField]private float movespeed;
    [SerializeField]private GameObject ball;
    private Rigidbody2D rb;
    private Vector2 move;
    [SerializeField]private int level;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
        if (level>=4){
            level=4;//Only 5 levels are there(including 0)
        }
        movespeed=movespeed+(level*1f);//Increasing the speed of the paddle as the level increases
    }

    // Update is called once per frame
    void Update()
    {
        if (ball.transform.position.y > transform.position.y+0.5f)//The paddle will move up or down depending on the position of the ball
        {
            move = new Vector2(0, 1f *movespeed);
        }
        else if (ball.transform.position.y < transform.position.y-0.5f)
        {
            move= new Vector2(0, -1f * movespeed);
        }
        else
        {
            move = new Vector2(0, 0);
        }   
    }
    void FixedUpdate()
    {
        rb.linearVelocity = move;
        Vector3 clampedPosition = transform.position;//Clamping the position of the paddle
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -5.32f, 5.23f);
        transform.position = clampedPosition;
    }
}
