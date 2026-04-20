using UnityEngine;

public class testMover : MonoBehaviour
{
    public Vector3 newPos;
    public GameObject body;
    public bool ropeShaking;
    public bool playerFling;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!playerFling)
        {
            if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space))
            {
                Debug.Log("moving");
                newPos = transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
                transform.position = newPos;
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                body.transform.eulerAngles = new Vector3(90, 0, 0);
                body.transform.position = transform.position + new Vector3(0, -1, 0);
            }
            if (Input.GetKeyUp(KeyCode.Space))
            {
                body.transform.eulerAngles = new Vector3(0, 0, 0);
                body.transform.position = transform.position + new Vector3(0, 1, 0);
            }
            if ((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Space)) && ropeShaking)
            {
                playerFling = true;
            }
        }
        else
        {
            transform.position += new Vector3(0, 30, 0) * Time.deltaTime;
        }
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "peanut")
        {
            playerFling = true;
        }
    }
}
