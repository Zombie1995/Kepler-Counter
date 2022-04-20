using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    public float Mass;
    public Vector3 CurVel;

    public void Influence(List<Gravity> objs, float timeStep, float gravitConst)
    {
        foreach (Gravity otherObj in objs){
            if (otherObj != this){
                float dist_sqrd = (transform.position - otherObj.transform.position).sqrMagnitude;
                Vector3 dirOfAcc = (transform.position - otherObj.transform.position).normalized;
                
                Vector3 accelerationToObj = dirOfAcc * (gravitConst * Mass / dist_sqrd);
                
                otherObj.CurVel += accelerationToObj * timeStep;
            }
        }
    }

    public void Move(float timeStep) 
    {
        transform.position += (CurVel / 2) * timeStep;
    }
}
