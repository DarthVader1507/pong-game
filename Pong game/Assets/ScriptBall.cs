using UnityEngine;
using UnityEngine.UI;

public class ScriptBall : MonoBehaviour
{
    //Objects declared here
    private Rigidbody2D rb;
    [SerializeField]private Text player_score;
    [SerializeField]private Text AI_score;
    [SerializeField]private GameObject player_paddle;
    [SerializeField]private GameObject AI_paddle;
    public float StartingSpeed;//Public-can be viewed and set by user,accessed by other scripts
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();//Instead of dragging and dropping ball into rb,this gets component of Rigidbody2D directly(the ball)
        StartBall();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void StartBall()
    {
        bool isRight = UnityEngine.Random.value >= 0.5f;
        float xVelocity = -1.4f;
        if (isRight)
        {
            xVelocity = 1.4f;
        }
        float yVelocity = UnityEngine.Random.Range(-1f,1f);
        while (yVelocity == 0){
            yVelocity = UnityEngine.Random.Range(-1f,1f);
        }
        rb.linearVelocity = new Vector2(xVelocity * StartingSpeed,yVelocity * StartingSpeed);
    }
    private void ResetBall()
    {
        rb.linearVelocity = Vector2.zero;
        transform.position = Vector2.zero;
        player_paddle.transform.position = new Vector2(-8f,0);
        AI_paddle.transform.position = new Vector2(8f,0);
        Invoke("StartBall",2f);
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.name=="RightBorder")
        {
            player_score.text=(int.Parse(player_score.text)+1).ToString();
            ResetBall();
        }
        if(other.gameObject.name=="LeftBorder")
        {
            AI_score.text=(int.Parse(AI_score.text)+1).ToString();
            ResetBall();
        }
    }
}
