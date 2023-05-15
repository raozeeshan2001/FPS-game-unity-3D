using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
   Rigidbody rb;
   public float speed = 5f;
     public float sensitivity = 2f;
    public Camera cam;
    public float jumpforce = 150f;
    public bool isjump = false;

  private  void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>(); 
    }

    
   private void FixedUpdate()
    {
        playermovement();
       playerrotation();

    }
    void playermovement()
    {
        float movex = Input.GetAxisRaw("Horizontal");
        float movez = Input.GetAxisRaw("Vertical");

        Vector3 moveplayer = new Vector3(movex, 0, movez);
       transform.Translate(moveplayer*Time.fixedDeltaTime *speed, Space.Self);
        //jump
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isjump==false)
            {
                rb.AddForce(Vector3.up * jumpforce);
                isjump = true;
            }
           
        }

    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag=="ground")
        {
            isjump = false;
        }
    }
    void playerrotation()
    {
        float rotatey = Input.GetAxisRaw("Mouse X");
        Vector3 rotation = new Vector3(0, rotatey, 0)*sensitivity;
        transform.Rotate(rotation);

        float rotatex = Input.GetAxisRaw("Mouse Y");
        Vector3 camrotation = new Vector3(rotatex, 0, 0) * sensitivity;
       cam.transform.Rotate(-camrotation);
    }
}
