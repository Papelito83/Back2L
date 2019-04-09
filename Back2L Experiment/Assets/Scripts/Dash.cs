using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Dash : MonoBehaviour
{
    private Character characterMovement;
    private PhysicsObject characterPhysic;

    [SerializeField] private float dashCoolDown = 1f;
    [SerializeField] private float dashCoolDownLeft;

    [SerializeField] private float dashTime;
    [SerializeField] private float dashTimeLeft;

    [SerializeField] private float dashCoeff;

    bool IsActive = false;

    
    private void Awake()
    {
        dashCoeff = 5f;
        dashTime = 0.1f;
        dashTimeLeft = dashTime;
        dashCoolDownLeft = 0f;
    }

    private void Start()
    {
        characterMovement = GetComponent<Character>();
        characterPhysic = GetComponent<PhysicsObject>();
    }

    private void Update()
    {
        if (OnCooldDown())
        {
            dashCoolDownLeft -= Time.deltaTime;
        }

        if (!IsActive)
            dashTimeLeft = dashTime;
    }

    public void Started()
    {
        IsActive = true;
        StartAbility();
    }

    public void StartAbility()
    {
        if (IsActive)
        {
            characterPhysic.StopVerticalVelocity();
            if (dashTimeLeft <= 0)
            {
                IsActive = false;
                dashCoolDownLeft = dashCoolDown;
            }
            else
            {
                dashTimeLeft -= Time.deltaTime;
                if (characterMovement.DirectionFlipped())
                    characterMovement.MoveHorizontal(-1, dashCoeff);
                else
                    characterMovement.MoveHorizontal(1, dashCoeff);
            }
        }
    }

    public bool Ended()
    {
        return !IsActive;
    }

    public bool OnCooldDown()
    {
        return dashCoolDownLeft > 0f;
    }
}

