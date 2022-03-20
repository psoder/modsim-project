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
            new Planet(GameObject.Find("Mercury"), 47.36f, 0.2558f, 0.03f, 3.38f),
            new Planet(GameObject.Find("Venus"), 35.02f, 0.0617f, 2.64f, 3.86f),
            new Planet(GameObject.Find("Earth"), 29.78f, 0.0042f, 23.44f, 7.155f),
            new Planet(GameObject.Find("Mars"), 24.01f, 0.0041f, 25.19f, 5.65f),
            new Planet(GameObject.Find("Jupiter"), 13.07f, 0.0101f, 3.13f, 6.09f),
            new Planet(GameObject.Find("Saturn"), 9.68f, 0.0094f, 23.44f, 5.51f),
            new Planet(GameObject.Find("Uranus"), 6.80f, 0.0058f, 97.77f, 6.48f),
            new Planet(GameObject.Find("Neptune"), 5.43f, 0.0062f, 28.32f, 6.43f)
        };

        // Sets the inital velocity of the planets
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
        }

        //FIPPEL DIRECTION
        foreach (Planet p in planets)
        {
            Vector3 v_direction = p.gObject.GetComponent<Rigidbody>().velocity.normalized;
            Vector3 v_directionSun = (planets[0].getPosition() - p.getPosition()).normalized;
            Vector3 crossV = Vector3.Cross(v_directionSun, v_direction);
            crossV = Quaternion.AngleAxis(90 - p.Tilt, Vector3.left) * crossV;
            p.gObject.transform.rotation = Quaternion.LookRotation(crossV);
        }

        // Move the planets into the right trajectory.
        foreach (Planet p in planets)
        {
            if (!p.gObject.name.Equals("Sun"))
            {
                p.gObject.GetComponent<TrailRenderer>().enabled = false;    // Disable to remove ugly jump

                p.gObject.transform.position = new Vector3(p.getPosition().x,
                    Mathf.Tan((p.Inclination / 360.0f) * 2.0f * (float)Math.PI) *
                    Vector3.Distance(p.getPosition(), planets[0].getPosition()), 0);

                p.gObject.GetComponent<TrailRenderer>().enabled = true;
            }
        }
    }

    // Updates at a fixed interval
    void FixedUpdate()
    {
        foreach (Planet p1 in planets)
        {
            // Simulate Gravity
            foreach (Planet p2 in planets)
            {
                p1.gObject.GetComponent<Rigidbody>().AddForce((Gravity(p1, p2)));
            }

            // rotation along the y axis, which is calculated in the start function (perpendicular to the ). 
            p1.gObject.transform.Rotate(0, 1000 * p1.Rotation, 0, Space.Self);
        }
    }


    // Calculates the force the second planet is exerting on the first.
    Vector3 Gravity(Planet p1, Planet p2)
    {
        if (p1.Equals(p2)) { return Vector3.zero; }

        Vector3 v = (p2.getPosition() - p1.getPosition());
        float r = v.magnitude;
        v = v.normalized;
        v *= (G * (p1.mass * p2.mass) / (r * r));
        return v;
    }

}