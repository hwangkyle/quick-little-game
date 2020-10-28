using UnityEngine;
using System.Linq;

public class OrbitalGravity : MonoBehaviour
{
    private Transform[] starTransforms;
    private Transform[] ztarTransforms;
    private Rigidbody2D rb;
    public float g = 3f;
    public bool ya = true; // this is such stupidity but it works

    internal void Start()
    {
        starTransforms = GameObject.FindGameObjectsWithTag("Star").Select(star => star.transform).ToArray();
        ztarTransforms = GameObject.FindGameObjectsWithTag("Ztar").Select(ztar => ztar.transform).ToArray();
        rb = GetComponent<Rigidbody2D>();
    }

    internal void FixedUpdate()
    {
        if(ya)
            rb.AddForce(GravitationalForce);
    }   

    public Vector3 GravitationalForce
    {
        get
        {
            var force = Vector3.zero;
            foreach (var starTransform in starTransforms)
            {
                var offset = starTransform.position - transform.position;
                var scale = Mathf.Max(0.001f, offset.sqrMagnitude);
                force += offset.normalized*(g/scale);
            }
            foreach (var ztarTransform in ztarTransforms)
            {
                var offset = ztarTransform.position - transform.position;
                var scale = Mathf.Max(0.001f, offset.sqrMagnitude);
                force += offset.normalized*(-g/scale);
            }
            return force;
        }
    }
}