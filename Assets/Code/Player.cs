using UnityEngine;

public class Player : MonoBehaviour
{
    /*
        Regarding this wall of variables, I don't know the best practice for Unity
        since I'm just starting out, but in my opinion, this looks hideous and I
        should feel bad. Looking below, it just looks so ugly. Please, if you ever
        continue this, me, clean up below.
    */
    private Rigidbody2D rb;
    private Vector3 origPos;
    private GameObject[] obstacles;
    private Vector3[] obstaclesOrigPos;
    private GameObject key;
    private static Object _keyPrefab;
    private Vector3 keyOrigPos;
    private bool keyObtained = false;
    public bool done = false;
    internal void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        origPos = gameObject.transform.position;
        obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        obstaclesOrigPos = new Vector3[obstacles.Length];
        for (int i = 0; i < obstacles.Length; i++)
        {
            obstaclesOrigPos[i] = obstacles[i].transform.position;
        }
        key = GameObject.FindGameObjectsWithTag("Key")[0];
        _keyPrefab = Resources.Load("Key");
        keyOrigPos = key.transform.position;
    }
    internal void OnCollisionEnter2D(Collision2D c)
    {
        if (c.collider.tag == "Star" || c.collider.tag == "Ztar")
        {
            // this whole if statement is one such instance of ugliness.
            Physics2D.gravity = new Vector2(0, 0);
            rb.velocity = new Vector2(0f, 0f);
            rb.rotation = 0f;
            rb.angularVelocity = 0f;
            gameObject.transform.position = origPos;
            for (int i = 0; i < obstacles.Length; i++)
            {
                Rigidbody2D _rb = obstacles[i].GetComponent<Rigidbody2D>();
                obstacles[i].transform.position = obstaclesOrigPos[i];
                _rb.velocity = new Vector2(0f, 0f);
                _rb.rotation = 0f;
                _rb.angularVelocity = 0f;
            }
            if(keyObtained)
                key = (GameObject)Instantiate(_keyPrefab, keyOrigPos, new Quaternion());
            Rigidbody2D _rb1 = key.GetComponent<Rigidbody2D>();
            _rb1.rotation = 0f;
            _rb1.angularVelocity = 0f;
            keyObtained = false;
        }
        else if (keyObtained && c.collider.tag == "Objective")
        {
            // still ugly, but a bit less
            GameObject obj = GameObject.FindGameObjectsWithTag("Objective")[0];
            obj.GetComponent<SpriteRenderer>().color = Color.green;
            done = true;
            foreach(var o in GameObject.FindGameObjectsWithTag("Star"))
                Destroy(o);
            foreach(var o in GameObject.FindGameObjectsWithTag("Ztar"))
                Destroy(o);
            gameObject.GetComponent<OrbitalGravity>().ya = false;
            gameObject.GetComponent<ScoreDisplay>().ya = true;
        }
        else if (c.collider.tag == "Key")
        {
            // I think this is fine(?)
            GameObject obj = GameObject.FindGameObjectsWithTag("Key")[0];
            Destroy(obj);
            keyObtained = true;

        }
    }
}