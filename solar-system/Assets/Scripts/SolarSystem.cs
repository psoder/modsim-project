using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class SolarSystem : MonoBehaviour
{
    // Start is called before the first frame update
    readonly float G = 100f;
    readonly float rotateSpeed = 1;
    //readonly float G = 6.67f * Mathf.Pow(10, -11);
    Planet[] planets;

    async void Start()
    {
        // Instanziate Planets
        planets = new Planet[] {
            new Planet(GameObject.Find("Sun"), 0f, 0f, 0f, 0f),
            new Planet(GameObject.Find("Mercury"), 47.36f, 10.89f, 0.03f, 3.38f),
            new Planet(GameObject.Find("Venus"), 35.02f, 6.52f, 2.64f, 3.86f),
            new Planet(GameObject.Find("Earth"), 29.78f, 0.47f, 23.44f, 7.155f),
            new Planet(GameObject.Find("Mars"), 24.01f, 0.24f, 25.19f, 5.65f),
            new Planet(GameObject.Find("Jupiter"), 13.07f, 12.60f, 3.13f, 6.09f),
            new Planet(GameObject.Find("Saturn"), 9.68f, 9.87f, 23.44f, 5.51f),
            new Planet(GameObject.Find("Uranus"), 6.80f, 2.59f, 97.77f, 6.48f),
            new Planet(GameObject.Find("Neptune"), 5.43f, 2.68f, 28.32f, 6.43f)
        };

        // Initalize Velocity
        foreach (Planet p1 in planets)
        {
            foreach (Planet p2 in planets)
            {
                if (!p1.Equals(p2))
                {
                    float r = Vector3.Distance(p1.getPosition(), p2.getPosition());
                    p1.gObject.transform.LookAt(p2.gObject.transform);
                    p1.gObject.GetComponent<Rigidbody>().velocity += p1.gObject.transform.right * Mathf.Sqrt((G * p2.mass) / r);
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
        //print(planets[1].getVelocity());
    }

    private void FixedUpdate()
    {
        // Simulate Gravity
        foreach (Planet p1 in planets)
        {
            foreach (Planet p2 in planets)
            {
                if (!p1.Equals(p2))
                {
                    float r = Vector3.Distance(p1.getPosition(), p2.getPosition());

                    p1.gObject.GetComponent<Rigidbody>().AddForce((p2.getPosition() - p1.getPosition()).normalized * (G * (p1.mass * p2.mass) / (r * r)));
                }
            }
        }

        // Rotation of planets
        foreach (Planet p in planets)
        {
            float pi = (float)Math.PI;
            float x = Mathf.Sin((p.Tilt / 360.0f) * 2.0f * pi);
            float y = Mathf.Cos((p.Tilt / 360.0f) * 2.0f * pi);

            Vector3 Angle = new Vector3(x, y, 0.0f).normalized;
            p.gObject.transform.Rotate(Angle * p.Inclination * Time.deltaTime);

        }
    }
}