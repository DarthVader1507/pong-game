using UnityEngine;

public class ScrpitP1 : MonoBehaviour
{
    [SerializeField]private float movespeed;
    private Rigidbody2D rb;
    private Vector2 move;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb=GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        bool isUpPressed = Input.GetKey(KeyCode.UpArrow);//When Up Arrow pressed,value is true
        bool isDownPressed = Input.GetKey(KeyCode.DownArrow);//Similiarly for Down Arrow
        if (isUpPressed)
        {
            move = new Vector2(0, 1f *movespeed);
        }
        else if (isDownPressed)
        {
            move = new Vector2(0, -1f * movespeed);
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
