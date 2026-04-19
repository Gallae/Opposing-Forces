using UnityEngine;

public class camFollowPlayer : MonoBehaviour
{
    public GameObject target;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z < target.transform.position.z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, target.transform.position.z);
        }
    }
}
