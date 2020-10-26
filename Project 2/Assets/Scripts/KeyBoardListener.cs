using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBoardListener : MonoBehaviour
{

    CharacterController controller;
    Renderer renderer;
    [Range(0.0f, 20.0f)]
    public float scale = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        renderer = this.GetComponent<Renderer>();
        //this.transform.localScale += this.transform.localScale; //Para escalar x2
        //this.transform.position = new Vector3(3,5,1); // Para setear en coords. {3,5,1}

        //this.transform.Rotate(0.0f, 30.0f, 0.0f);
        //this.transform.Translate(Vector3.forward * 3, Space.World);
        //this.transform.Translate(Vector3.up * 3, Space.World);
        //this.transform.Translate(Vector3.right * 3, Space.World);

        renderer.material.color = Color.blue;
    }

    // Update is called once per frame
    void Update()
    {
       
        //Rotación
        if (Input.GetKey(KeyCode.Q))
            this.transform.Rotate(0.0f, -0.25f, 0.0f);
        if (Input.GetKey(KeyCode.E))
            this.transform.Rotate(0.0f, 0.25f, 0.0f);

        //Traslaciones
        if (Input.GetKey(KeyCode.W))
            this.transform.Translate((Vector3.forward * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.forward*Time.deltaTime)* scale;
        if (Input.GetKey(KeyCode.S))
            this.transform.Translate((Vector3.back * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.back * Time.deltaTime)* scale;
        if (Input.GetKey(KeyCode.A))
            this.transform.Translate((Vector3.left * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.left * Time.deltaTime)* scale;
        if (Input.GetKey(KeyCode.D))
            this.transform.Translate((Vector3.right * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.right * Time.deltaTime)* scale;
        if (Input.GetKey(KeyCode.Space))
            this.transform.Translate((Vector3.up * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.up * Time.deltaTime)* scale;
        if (Input.GetKey(KeyCode.LeftControl))
            this.transform.Translate((Vector3.down * Time.deltaTime) * scale);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.down * Time.deltaTime)* scale;
    }
}
