using UnityEngine;
using System.Collections;

public class CapRotAround : MonoBehaviour
{
    //public int m_PlayerNumber = 1;
    public float m_speed = 12f;
    public float m_turnSpees = 180f;

    private string m_MouvementAxisName;
    private string m_TurnAxisName;
    private Rigidbody m_Rigidbody;
    private float m_MovementInputValue;
    private float m_TurnInputValue;

    private void Awake()
    {
        m_Rigidbody = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        m_MouvementAxisName = "Vertical" ;
        m_TurnAxisName = "Horizontal" ;
    }

    private void Update()
    {
        m_MovementInputValue = Input.GetAxis(m_MouvementAxisName);
        m_TurnInputValue = Input.GetAxis(m_TurnAxisName);
    }

    private void FixedUpdate()
    {
        Move();
        Turn();
    }

    private void Move()
    {
        Vector3 movement = transform.forward * m_MovementInputValue * m_speed * Time.deltaTime;
        m_Rigidbody.MovePosition(m_Rigidbody.position + movement);
    }

    private void Turn()
    {
        float turn = m_TurnInputValue * m_turnSpees * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_Rigidbody.MoveRotation(m_Rigidbody.rotation * turnRotation);
    }
}

