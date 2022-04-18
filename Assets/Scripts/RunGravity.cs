using System.Collections.Generic;
using UnityEngine;

public class RunGravity : MonoBehaviour
{
    [Header("Required Assets")]
    [SerializeField] private AreaDrawer _drawer;
    [SerializeField] private List<Gravity> Objs;
    
    [Header("Parameters")]
    public float TimeStep = 0.001f;
    public int SimSpeed = 1;
    public float GravConst = 1.0f;

    private void Start() 
    {
        Time.fixedDeltaTime = TimeStep;
    }

    private void FixedUpdate()
    {
        for (int i = 0; i < SimSpeed; i++) 
        {
            foreach (Gravity obj in Objs)
            {
                obj.Influence(Objs, TimeStep, GravConst);
            }

            foreach (Gravity obj in Objs)
            {
                obj.Move(TimeStep);
            }

            _drawer.DrawAreas(TimeStep);
        }
    }
}
