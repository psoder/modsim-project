using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    readonly float G = 100f;
    //readonly float G = 6.67f * Mathf.Pow(10, -11);
    GameObject[] celestials;
    void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        InitialVelocity();
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity();
    }

    private void FixedUpdate(){
            Gravity();
    }
    void Gravity(){
        foreach(GameObject planet1 in celestials){
            foreach(GameObject planet2 in celestials){
                if (!planet1.Equals(planet2)){
                
                    float m1 = planet1.GetComponent<Rigidbody>().mass;
                    float m2 = planet2.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(planet1.transform.position, planet2.transform.position);

                    planet1.GetComponent<Rigidbody>().AddForce((planet2.transform.position - planet1.transform.position).normalized * (G * (m1 * m2) / (r*r)));
                }
            }
        }
    }

    void InitialVelocity(){
        foreach(GameObject planet1 in celestials){
            foreach(GameObject planet2 in celestials){
                if (!planet1.Equals(planet2)){
                    float m2 = planet2.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(planet1.transform.position, planet2.transform.position);
                    planet1.transform.LookAt(planet2.transform);

                    planet1.GetComponent<Rigidbody>().velocity += planet1.transform.right * Mathf.Sqrt((G*m2) / r);

                }
            }
            
        }
    }
}
