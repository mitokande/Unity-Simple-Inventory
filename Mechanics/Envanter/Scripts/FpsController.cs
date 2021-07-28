using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FpsController : MonoBehaviour
{
    public Rigidbody rb;
    public float speed;
    Vector3 movedirection;
    public GameObject Envanter;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Envanter.SetActive(!Envanter.activeSelf);
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * 5, ForceMode.Impulse);
        }
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        movedirection = transform.forward * vertical + transform.right * horizontal;
    }

    public void FixedUpdate()
    {
        //transform.Translate(movedirection.normalized * Time.deltaTime * speed);
        transform.position = transform.position + movedirection.normalized * Time.deltaTime * speed;
        //rb.MovePosition(transform.position + movedirection.normalized*Time.deltaTime*speed);
        //rb.AddForce(movedirection.normalized * speed, ForceMode.Force);
    }
}
