using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterController : MonoBehaviour
{

    public Score scoreManager;
    public float speed = 30.0f;
    public float rotationSpeed = 150;
    public float force = 65f;
    public float forceSpaceHeld = 2f;
    public int    jumps = 0;
    public int maxJumps = 5;
    public int waitTimeTillNextJump = 3;
    bool isgrounded = true;

    Rigidbody rb;
    Transform t;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        StartCoroutine(waiter());
    }

    // Everyone Second decrease jump
    IEnumerator waiter()
    {
        print("Waiting");
        if(jumps > 0)
            jumps -= 1;

        yield return new WaitForSeconds(waitTimeTillNextJump);

        StartCoroutine(waiter());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
            rb.velocity += this.transform.forward * speed * Time.deltaTime;
        else if (Input.GetKey(KeyCode.S))
            rb.velocity -= this.transform.forward * speed * Time.deltaTime;

        if (Input.GetKey(KeyCode.D))
            t.rotation *= Quaternion.Euler(0, rotationSpeed * Time.deltaTime, 0);
        else if (Input.GetKey(KeyCode.A))
            t.rotation *= Quaternion.Euler(0, - rotationSpeed * Time.deltaTime, 0);

        if (isgrounded == true && jumps != 0)
        {
            jumps = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space) && jumps < maxJumps)
        {
            if(jumps == 0)
                force = 90f;
            jumps += 1;
            rb.AddForce(t.up * force);
        }

        if (Input.GetKey(KeyCode.Space))
            rb.AddForce(t.up * forceSpaceHeld);

        if (Input.GetKey(KeyCode.M))
            SceneManager.LoadScene(0);
    }

    //make sure u replace "Plane" with your gameobject name.on which player is standing
    void OnCollisionEnter(Collision theCollision)
    {
        if (theCollision.gameObject.tag == "Plane")
        {
            isgrounded = true;
            rb.drag = 2;
            force = 1000f;
        }

        if(theCollision.gameObject.tag == "Egg")
        {
            scoreManager.AddPoint();
            Destroy(theCollision.gameObject);
        }

        if(theCollision.gameObject.tag == "GoldenEgg")
        {
            scoreManager.AddDoublePoints();
            Destroy(theCollision.gameObject);
        }
    }

    //consider when character is jumping .. it will exit collision.
    void OnCollisionExit(Collision theCollision)
    {
        if (theCollision.gameObject.name == "Plane")
        {
            isgrounded = false;
            rb.drag = 2;
            force = 90f;
        }
    }
}