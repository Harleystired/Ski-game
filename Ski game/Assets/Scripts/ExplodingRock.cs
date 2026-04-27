using UnityEngine;

public class ExplodingRock : Obstickl
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    internal override void OnCollision(Collision collision)
    {
        base.OnCollision(collision);
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
