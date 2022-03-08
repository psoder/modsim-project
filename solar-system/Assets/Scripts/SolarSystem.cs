using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Planet{
    public GameObject gObject;
    public string name;
    public float Inclination;
    public float Velocity;
    public float Tilt;
    public float mass;

    public Planet(GameObject x, string y, float u, float i, float o){
        gObject = x;
        name = y;
        Inclination = u;

        Velocity = i;

        Tilt = o;
        mass = gObject.GetComponent<Rigidbody>().mass;
    }
    
    public Vector3 getVelocity(){
        return gObject.GetComponent<Rigidbody>().velocity;
    }

    public Vector3 getPosition(){
        return gObject.transform.position;
    }
}
public class SolarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    readonly float G = 100f;
    readonly float rotateSpeed = 1;
    //readonly float G = 6.67f * Mathf.Pow(10, -11);
    GameObject[] celestials;
    Planet[] planetArray = new Planet[9];
    float[] orbitalInclination = {3.38f, 3.86f, 7.155f, 5.65f, 6.09f, 5.51f, 6.48f, 6.43f};
    float[] EquatorialRotationV = {10.89f, 6.52f, 0.47f, 0.24f, 12.6f, 9.87f,2.59f, 2.68f};
    float[] AxialtTilt = {0.03f, 2.64f, 23.44f, 25.19f, 3.13f, 23.44f, 97.77f, 28.23f};
    string[] planetNames = {"Sun", "Mercury", "Venus", "Earth", "Mars", "Jupiter", "Saturn", "Uranus", "Neptune"};
    async void Start()
    {
        celestials = GameObject.FindGameObjectsWithTag("Celestial");
        initPlanetArray();
        initVelocity();
        //print(planetArray[1].getVelocity());
    }

    // Update is called once per frame
    void Update()
    {
        //Gravity();
    }

    private void FixedUpdate(){
            Gravity();
            //Rotation();
            angleRotationCorrect();
    }   
    async void Gravity(){
        
        foreach(Planet p1 in planetArray){
            foreach(Planet p2 in planetArray){
                if (!p1.Equals(p2)){
                    float r = Vector3.Distance(p1.getPosition(), p2.getPosition());

                    p1.gObject.GetComponent<Rigidbody>().AddForce((p2.getPosition() - p1.getPosition()).normalized * (G * (p1.mass * p2.mass) / (r*r)));
                }
            }
        }
        
    }

    void initVelocity(){
        foreach(Planet p1 in planetArray){
            foreach(Planet p2 in planetArray){
                if (!p1.Equals(p2)){
                    float r = Vector3.Distance(p1.gObject.transform.position, p2.gObject.transform.position);
                    p1.gObject.transform.LookAt(p2.gObject.transform);

                    p1.gObject.GetComponent<Rigidbody>().velocity += p1.gObject.transform.right * Mathf.Sqrt((G*p2.mass) / r); 
                }
            } 
            //Omloppsbana
            
            p1.gObject.GetComponent<Rigidbody>().velocity = Quaternion.AngleAxis(p1.Inclination, Vector3.left) * p1.gObject.GetComponent<Rigidbody>().velocity;
            /*
            Vector3 direction = new Vector3(0.0f,0.0f,orbitalInclination[counter]).normalized;
            
            float magni = planet1.GetComponent<Rigidbody>().velocity.magnitude;
            planet1.GetComponent<Rigidbody>().velocity = magni * direction;
            print(planet1.GetComponent<Rigidbody>().velocity.normalized);
            */
        }   
    }
    //inte KLAR, Har problem med vektorerna
    void angleRotationCorrect(){
        string name = "Sun";
        foreach(Planet p in planetArray){
                float temp = (float)Math.PI;
                float x = Mathf.Sin((p.Tilt/360.0f)*2.0f*temp);
                float y = Mathf.Cos((p.Tilt/360.0f)*2.0f*temp);

                Vector3 Angle = new Vector3(x,y,0.0f).normalized;
                p.gObject.transform.Rotate(Angle * p.Inclination * Time.deltaTime);

        }

    }
    void initPlanetArray(){
        int index = 0;
        bool solen = false;
        foreach(string x in planetNames){
            foreach(GameObject g in celestials){
                if(g.name.Equals("Sun") && !solen){
                    planetArray[index] = new Planet(g,"Sun",0,0,0);
                    index++;
                    solen = true;
                }
                else if(g.name.Equals(x)){
                    planetArray[index] = new Planet(g,x,orbitalInclination[index -1],EquatorialRotationV[index-1 ],AxialtTilt[index-1]);
                    index++;
                }
            }   
        }

    }
    //värdelös
    void Rotation(){
        foreach(GameObject planet1 in celestials){
            int counter = 1;
            if(planet1.Equals(celestials[0])){
                
                planet1.transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
            }
            else{
                //planet1.transform.Rotate((Vector3(0.0f, 1.0f, 0.0f) * Time.deltaTime), Space.Self);
                planet1.transform.Rotate(new Vector3(0, EquatorialRotationV[counter], 0) * Time.deltaTime);
                counter ++;
            }

            //planet1.transform.Rotate(new Vector3(0, rotateSpeed, 0) * Time.deltaTime);
        }
    }
    
}