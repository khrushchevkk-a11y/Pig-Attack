using UnityEngine;

public class Leg : MonoBehaviour
{
    public HingeJoint2D joint;
    public float kickSpeed = 600f;
    public float returnSpeed = 300f;
    private Player player;
    public bool IsKicking => kickTimer > 0f && player != null && player.IsGrounded;
    private float kickTimer;
    private int direction ;

    public void Kick(int newDirection)
    {
        if (player == null || !player.IsGrounded) return;
        direction = newDirection;
        kickTimer = 0.2f;
    }
    public void CancelKick()
    {
        kickTimer = 0f;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        if (joint == null) joint = GetComponent<HingeJoint2D>();
        if (joint != null && joint.connectedBody != null)
            player = joint.connectedBody.GetComponent<Player>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player == null || !player.IsGrounded) CancelKick();
        kickTimer = kickTimer - Time.fixedDeltaTime;
        JointMotor2D motor = joint.motor;
        if (IsKicking)
        {
            motor.motorSpeed = -kickSpeed * direction;
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
