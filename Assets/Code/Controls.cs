using UnityEngine;

public class Controls : MonoBehaviour
{
    public float g = 5f;
    void Start()
    {
        Physics2D.gravity = new Vector2(0, 0);
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Physics2D.gravity = new Vector2(0, -g);
        }
        if (Input.GetKey(KeyCode.UpArrow))
        {
            Physics2D.gravity = new Vector2(0, g);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Physics2D.gravity = new Vector2(-g, 0);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Physics2D.gravity = new Vector2(g, 0);
        }
    }
}