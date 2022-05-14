using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 change;
    private enum State { idle, running, interact, }
    private State state = State.idle;
    public Animator anim;
    public Transform target;
    public GameObject player1, player2;
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        change = Vector3.zero;
        change.x = Input.GetAxisRaw("Horizontal");
        change.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown("space"))
        {
            if (player1.activeSelf)
            {
                player1.gameObject.SetActive(false);
                player2.gameObject.SetActive(true);
            }
            else
            {
                player1.gameObject.SetActive(true);
                player2.gameObject.SetActive(false);
            }
        }
        if (change != Vector3.zero)
        {
            moveCharacter();
        }
        else
        {
            state = State.idle;
        }
        anim.SetInteger("state", (int)state);
        Debug.Log(state);

    }

    void moveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + change * speed * Time.deltaTime);
        float hdireccition = Input.GetAxis("Horizontal");
        if (hdireccition < 0)
        {
            transform.localScale = new Vector2(-1, 1);
            state = State.running;
        }
        else if (hdireccition > 0)
        {
            transform.localScale = new Vector2(1, 1);
            state = State.running;
        }
    }
}
