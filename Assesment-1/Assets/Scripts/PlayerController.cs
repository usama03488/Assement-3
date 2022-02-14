using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;
    public Vector2 velocity;
    public bool isJumped = false;
    public GameObject Isattached;
    public GameObject sprite;
    // Start is called before the first frame update
    void Start()
    {
   
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    { //these are the movemnts of player
        transform.Translate(Vector3.forward * 3f * Time.deltaTime);

        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.left * 10f * Time.deltaTime);
         
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 10f * Time.deltaTime);
           
        }
        //if this player jumps he will loss his animal and get onto other one
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = CalculateVelocity(sprite.transform.position, transform.position, 1f);
            isJumped = true;
            transform.parent = null;
            if (Isattached != null)
            {
                Isattached.transform.parent = null;
                Isattached.GetComponent<AnimalController>().IsATTACHED(false);
            }

        }

     
    }
    //this function calculate the velocity in which the player jumps
    Vector3 CalculateVelocity(Vector3 target, Vector3 origin, float time)
    {
        Vector3 distance = target - origin;
        distance.y = 2f;
        Vector3 distanceXZ = distance;
        distanceXZ.y = 0f;

        float Sy = distance.y;
        float Sxz = distanceXZ.magnitude;
        float Vxz = Sxz / time;
        float Vy = Sy / time + 0.5f * Mathf.Abs(Physics.gravity.y) * time;

        Vector3 result = distanceXZ.normalized;
        result *= Vxz;
        result.y = Vy;
        return result;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //when player collides with animal player become its parent

        if (collision.gameObject.CompareTag("Animal"))
        {
            Isattached = collision.gameObject;
           Isattached.transform.parent = gameObject.transform;
            Isattached.GetComponent<AnimalController>().IsATTACHED(true);
        }
        //if (collision.gameObject.CompareTag("Obstacle"))
        //{
        //    Destroy(gameObject);
        //    Debug.Log("Game over");
        //}
    }
    
  
    

}