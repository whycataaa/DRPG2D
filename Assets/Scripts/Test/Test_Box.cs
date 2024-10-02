using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Box : MonoBehaviour
{
    Rigidbody2D rb;
    float Speed=5;
    Vector3 point;
    [SerializeField]float offset;
    bool IsLeft=true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        point= transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x>point.x+offset)
        {
            IsLeft=false;
        }else if(transform.position.x<point.x)
        {
            IsLeft=true;
        }
        if(IsLeft)
        {
            rb.velocity=new Vector2(Speed,0);
        }
        else
        {
            rb.velocity=new Vector2(-Speed,0);
        }

    }
}
