using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulbosController : MonoBehaviour
{
    //Components 
    [Header("Components")]
    Transform player;
    Rigidbody rb;
    [SerializeField] Transform feet;

    //Vectors
    Vector3 forceVector;

    //Floats
    [Header("Vars")]
    [SerializeField] float forceMultiplier;
    public float maxVelocity;
    [SerializeField] float checkDistance = 1f;
    [SerializeField] float jumpForce = 1f;
    float currentJumpForce;
    [Range(0,1)][SerializeField] float floatiness;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<PlayerMovement>().transform.Find("FollowPos").transform;
    }

    private void Update()
    {
        forceVector = directionVector();

        if (HasObjectBlocking() && forceVector.magnitude > 1f)
        {
            if (Grounded())
                Jump();
        }

        if (Vector3.Magnitude(rb.velocity) > maxVelocity)
        {
            rb.velocity = rb.velocity.normalized * maxVelocity;
        }

        if (HasObjectBlocking()){
            print("Hola");
        }


    }

    private void FixedUpdate()
    {
        //Drive
        rb.AddForce(forceVector * forceMultiplier, ForceMode.Force);
        //Friction
        rb.AddForce(forceVector * rb.velocity.magnitude * 0.1f, ForceMode.Force);
        //NOISE
        rb.AddForce(new Vector3(Random.Range(-3.0f, 3.0f), 0, Random.Range(-1.0f, 1.0f)));

        //Jump
        if (currentJumpForce != 0)
        {
            rb.AddForce(currentJumpForce * Vector3.up, ForceMode.Force);
            currentJumpForce -= currentJumpForce * (1 - floatiness);
            if (currentJumpForce < 0)
                currentJumpForce = 0;
        }

        if (rb.velocity.y < 0)
        {
            rb.velocity += Physics.gravity * 3f * Time.fixedDeltaTime;
        }
    }
void Jump()
    {
        currentJumpForce = jumpForce;
        //rb.AddForce(jumpForce * Vector3.up, ForceMode.Impulse);
    }

    bool HasObjectBlocking()
    {
        Vector3 velocity = rb.velocity.normalized;
        velocity.y = 0;
        RaycastHit hit;
        if (Physics.Raycast(transform.position, velocity, out hit, checkDistance))
            if (hit.transform.tag == "Obstacle"){
                
                print(hit.transform.gameObject.name);
                Debug.DrawRay(transform.position, velocity, Color.red, checkDistance);

            return true;
            }

                
        return false;
    }

    bool Grounded()
    {
        if (Physics.Raycast(feet.position, Vector3.down, 0.25f))
            return true;
        else
            return false;
    }

    Vector3 directionVector()
    {
        return new Vector3(player.position.x - transform.position.x, 0, player.position.z - transform.position.z);
    }
}