using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;



public class PGOHandler : MonoBehaviour
{
    private Rigidbody rb = null;

    public bool active = false;
    [Range(1.0f, 100.0f)]
    public float scale = 1.0f;

    public enum KeyCodeFilter
    {

        W = KeyCode.W,
        S = KeyCode.S,
        A = KeyCode.A,
        D = KeyCode.D,
        Up = KeyCode.UpArrow,
        Down = KeyCode.DownArrow,
        Left = KeyCode.LeftArrow,
        Right = KeyCode.RightArrow
    }

    public KeyCodeFilter forward = (KeyCodeFilter)KeyCode.W;
    public KeyCodeFilter backward = (KeyCodeFilter)KeyCode.S;
    public KeyCodeFilter left = (KeyCodeFilter)KeyCode.A;
    public KeyCodeFilter right = (KeyCodeFilter)KeyCode.D;


    // Start is called before the first frame update
    void Start()
    {
        if (active)
        {
            if( (rb = this.GetComponent<Rigidbody>()) == null)
                rb = this.gameObject.AddComponent<Rigidbody>();
            //rb.isKinematic = true;
            this.gameObject.GetComponent<Renderer>().material.color = Color.red;
            Application.targetFrameRate = 60;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (active)
        {
            //Quaternion deltaRotation = Quaternion.Euler(Vector3.down * Time.deltaTime * scale);
            //rb.MoveRotation(rb.rotation * deltaRotation);

            //Traslaciones
            if (Input.GetKey((KeyCode)forward))
                rb.AddForce(Vector3.forward * scale, ForceMode.Force);//rb.MovePosition(transform.position + Vector3.forward * Time.fixedDeltaTime * scale);
            if (Input.GetKey((KeyCode)backward))
                rb.AddForce(Vector3.back * scale, ForceMode.Force);//rb.MovePosition(transform.position + Vector3.back * Time.fixedDeltaTime * scale);
            if (Input.GetKey((KeyCode)left))
                rb.AddForce(Vector3.left * scale, ForceMode.Force);//rb.MovePosition(transform.position + Vector3.left * Time.fixedDeltaTime * scale);
            if (Input.GetKey((KeyCode)right))
                rb.AddForce(Vector3.right * scale, ForceMode.Force);//rb.MovePosition(transform.position + Vector3.right * Time.fixedDeltaTime * scale);
            /*
            if (Input.GetKey(KeyCode.Space) && rb.velocity.y == 0)
                rb.AddForce(Vector3.up * scale, ForceMode.Impulse);//rb.MovePosition(transform.position + Vector3.up * Time.fixedDeltaTime * scale);
            if (Input.GetKey(KeyCode.LeftControl))
                rb.AddForce(Vector3.down * scale, ForceMode.Acceleration);//rb.MovePosition(transform.position + Vector3.down * Time.fixedDeltaTime * scale);
            */
        }
    }
}
