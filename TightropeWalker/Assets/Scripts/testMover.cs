using UnityEngine;

public class testMover : MonoBehaviour
{
    public Vector3 newPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W) && !Input.GetKey(KeyCode.Space))
        {
            Debug.Log("moving");
            newPos = transform.position += new Vector3(0, 0, 2) * Time.deltaTime;
            transform.position = newPos;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.eulerAngles = new Vector3(90,0,0);
            transform.position = transform.position + new Vector3(0,-1,0);
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.eulerAngles = new Vector3(0, 0, 0);
            transform.position = transform.position + new Vector3(0, 1, 0);
        }
    }
}
