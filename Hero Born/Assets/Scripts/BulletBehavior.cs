using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    public float onescreenDelay = 3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, onescreenDelay);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
