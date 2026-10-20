using UnityEngine;

public class Leg : MonoBehaviour
{
    public HingeJoint2D joint;
    public float kickSpeed = 600f;
    public float returnSpeed = 300f;
    public bool IsKicking => kickTimer > 0f;
    private float kickTimer;
    private int direction ;

    public void Kick(int newDirection)
    {
        direction = newDirection;
        kickTimer = 0.2f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        kickTimer = kickTimer - Time.fixedDeltaTime;
        JointMotor2D motor = joint.motor;
        if (IsKicking)
        {
            motor.motorSpeed = kickSpeed * direction;
        }
        else
        {
            motor.motorSpeed = Mathf.Clamp(
                -joint.jointAngle * 10f, -returnSpeed, returnSpeed);
        }
        motor.maxMotorTorque = 200f;
        joint.useMotor = true;
        joint.motor = motor;

    }
}
