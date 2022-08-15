using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockCollision : MonoBehaviour
{
    public Collider2D characterCollider;
    public Collider2D blockCollisionCollider;

    void Start()
    {
        Physics2D.IgnoreCollision(characterCollider, blockCollisionCollider, true);
        
    }

    
}
