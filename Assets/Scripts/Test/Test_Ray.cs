using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_Ray : MonoBehaviour
{
    public Transform SP;
    public Transform EP;
    private void Update()
    {
            Vector2 vector2=EP.position-SP.position;
            RaycastHit2D hit=Physics2D.Raycast(SP.position,vector2,Vector2.Distance(SP.position,EP.position));
            
            if(hit.collider!=null)
            Debug.Log(hit.collider.name);
            
            Debug.DrawLine(SP.position,EP.position,Color.red);
    }



}
