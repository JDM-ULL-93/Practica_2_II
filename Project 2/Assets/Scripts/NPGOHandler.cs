using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPGOHandler : MonoBehaviour
{
    public bool active = false;
    [Range(0.0f, 20.0f)]
    public float scale = 1.0f;
    [Range(0.0f, 100.0f)]
    public float explosionForce = 5.0f;
    public enum KeyCodeFilter
    {

        W = KeyCode.W,
        S = KeyCode.S,
        A = KeyCode.A,
        D = KeyCode.D,
        Up = KeyCode.UpArrow,
        Down = KeyCode.DownArrow,
        Left = KeyCode.LeftArrow,
        Right = KeyCode.RightArrow,

        I = KeyCode.I,
        L = KeyCode.L,
        J = KeyCode.J,
        M = KeyCode.M
    }

    public KeyCodeFilter forward = (KeyCodeFilter)KeyCode.W;
    public KeyCodeFilter backward = (KeyCodeFilter)KeyCode.S;
    public KeyCodeFilter left = (KeyCodeFilter)KeyCode.A;
    public KeyCodeFilter right = (KeyCodeFilter)KeyCode.D;

    private Rigidbody rb;
    private GameObject[] cilindros;
    // Start is called before the first frame update
    void Start()
    {
        if (this.active)
        {
            cilindros = GameObject.FindGameObjectsWithTag("Cilindros");
            this.GetComponent<Renderer>().material.color = Color.blue;
            if ((rb = this.GetComponent<Rigidbody>()) == null)
                rb = this.gameObject.AddComponent<Rigidbody>();
            rb.isKinematic = true;
            Application.targetFrameRate = 60;
        }
            
    }


    void alejaCilindros(Vector3 mov)
    { //En mov tengo el desplazamiento del GO asociado al script
        foreach (GameObject cilindro in cilindros)
        {
            if ( //Check para ver si se esta acercando
                Vector3.Distance(transform.position - mov, cilindro.transform.position)
                >
                Vector3.Distance(transform.position, cilindro.transform.position))
            {
                var proportion = 1.0f / Vector3.Distance(this.transform.position, cilindro.transform.position);
                cilindro.transform.Translate(mov * proportion);
            }
        }
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        if (this.active)
        {
            //Rotación
            if (Input.GetKey(KeyCode.Q))
                this.transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y - 5.0f, 0.0f); //this.transform.Rotate(0.0f, -0.25f, 0.0f);
                
            if (Input.GetKey(KeyCode.E))
                this.transform.rotation = Quaternion.Euler(0.0f, transform.rotation.eulerAngles.y + 5.0f, 0.0f); //this.transform.Rotate(0.0f, 0.25f, 0.0f);

           

            //Traslaciones
            if (Input.GetKey((KeyCode)forward))
            {
                var mov = (Vector3.forward * Time.deltaTime) * scale;
                this.transform.Translate(mov);//this.gameObject.transform.position = this.gameObject.transform.position + (Vector3.forward*Time.deltaTime)* scale;
                alejaCilindros(mov);
            }
               
            if (Input.GetKey((KeyCode)backward))
            {
                var mov = (Vector3.back * Time.deltaTime) * scale;
                this.transform.Translate(mov);
                alejaCilindros(mov);

            }
                
            if (Input.GetKey((KeyCode)left))
            {
                var mov = (Vector3.left * Time.deltaTime) * scale;
                this.transform.Translate(mov);
                alejaCilindros(mov);
            }
                
            if (Input.GetKey((KeyCode)right))
            {
                var mov = (Vector3.right * Time.deltaTime) * scale;
                this.transform.Translate(mov);
                alejaCilindros(mov);
            }
                
            /*
            if (Input.GetKey(KeyCode.Space))
                this.transform.Translate((Vector3.up * Time.deltaTime) * scale);
            if (Input.GetKey(KeyCode.LeftControl))
                this.transform.Translate((Vector3.down * Time.deltaTime) * scale);
            */
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Collider[] colliders = Physics.OverlapSphere(this.transform.position, 10.0f);
                foreach (Collider collider in colliders)
                    if(collider.attachedRigidbody != null && collider.gameObject.CompareTag("A"))
                        collider.attachedRigidbody.AddExplosionForce(explosionForce, this.transform.position, 10.0f,3.0f,ForceMode.VelocityChange);
            }
         }
    }

    //Eventos onTrigger son disparados cuando en BoxCollider --> isTrigger = true ;
    //Eventos onCollision son disparados cuando existe un RigidBody asociado al GO y este choca con un RigidBody de otro objeto (& IsTrigger = false)
    private void OnCollisionEnter(Collision collision)
    {
        Color random = new Color(Random.Range(0.0f,1.0f), Random.Range(0.0f, 1.0f), Random.Range(0.0f, 1.0f));
        collision.gameObject.GetComponent<Renderer>().material.color = random;
    }

    /*private void OnCollisionStay(Collision collision)
    {
        if (Input.GetKey(KeyCode.Space))
        {
            float x = 0, y = 0, z = 0;
            for(var i = 0; i < collision.contactCount; i++)
            {
                ContactPoint pointCollision = collision.GetContact(i);
                x += pointCollision.point.x;
                y += pointCollision.point.y;
                z += pointCollision.point.z;
            }
            Vector3 mean = new Vector3(x / collision.contactCount, y / collision.contactCount, z / collision.contactCount);
            Vector3 dir = mean - this.transform.position;
            collision.rigidbody.AddForce(dir.normalized* 50.0f, ForceMode.Impulse);
            //var pointCollision = other.gameObject.GetComponent<Collider>().ClosestPointOnBounds(transform.position);
            //other.gameObject.GetComponent<Rigidbody>().AddForce(-pointCollision,ForceMode.Impulse);
        }
    }*/
}
