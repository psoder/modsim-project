using UnityEngine;

public class Planet
{
    public GameObject gObject;
    public float Velocity; // Orbial velocity in km/s 
    public float EqVelocity; // Equatorial velocity in km/s 
    public float Inclination; // Orbital inclatnation to the suns equator in degrees
    public float Tilt; // Axial tilt to orbit in degrees 
    public float mass;

    /// <sumary>
    /// Creates a planet
    /// </sumary>
    /// <param name="gameObject">The Unity Game Object</param>
    /// <param name="velocity">Orbial velocity in km/s </param>
    /// <param name="eqVelocity">Equatorial velocity in km/s </param>
    /// <param name="tilt">Axial tilt to orbit in degrees </param>
    /// <param name="inclination">Orbital inclatnation to the suns equator in degrees</param>
    public Planet(GameObject gameObject, float velocity, float eqVelocity, float tilt, float inclination)
    {
        gObject = gameObject;
        Inclination = inclination;

        Velocity = velocity;

        Tilt = tilt;
        mass = gObject.GetComponent<Rigidbody>().mass;
    }

    public Vector3 getVelocity()
    {
        return gObject.GetComponent<Rigidbody>().velocity;
    }

    public Vector3 getPosition()
    {
        return gObject.transform.position;
    }
}