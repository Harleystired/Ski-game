using UnityEngine;

public class Obstickl : MonoBehaviour
{
    
    public delegate void PlayerHitAction();
    public static event PlayerHitAction OnPlayerHit;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        OnCollision(collision);
    }

    internal virtual void OnCollision(Collision collision)
    {
        if(collision.collider.tag.Equals("Player"))
        {
            Debug.Log("Player collided with " + name);
        }
        OnPlayerHit.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
