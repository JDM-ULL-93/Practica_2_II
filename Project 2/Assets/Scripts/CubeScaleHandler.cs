using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScaleHandler : MonoBehaviour
{
    BoxCollider collider;
    // Start is called before the first frame updat
    void Start()
    {
        this.GetComponent<Renderer>().material.color = Color.magenta;
        collider = this.GetComponent<BoxCollider>();
        collider.size *= 7.0f;
        collider.isTrigger = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider other)
    {
        Vector3 puntoColision = this.GetComponent<Collider>().ClosestPointOnBounds(other.transform.position);
        float distanciaCollision = Vector3.Distance(transform.position, puntoColision);
        float distancia = 10.0f;
        float aux = distanciaCollision / distancia;
        Vector3 max = new Vector3(5, 5, 5);
        if(other.CompareTag("Player"))
            this.transform.localScale *= 0.9f;
        else if(this.transform.localScale.x < 2 )
            this.transform.localScale *= 1.1f;
    }
}
