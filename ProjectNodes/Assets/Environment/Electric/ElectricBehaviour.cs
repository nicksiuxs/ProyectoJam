using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;
    public float electricFieldRange;
    public LayerMask electricLayer;
    public CircleCollider2D circleCollider;

    [Header("Range Circle")]
    public LineRenderer lineRenderer;
    public float lineWidth = 0.2f;
    public int vertexCount = 50;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
    }

    void OnValidate()
    {
        setUp();
    }

    void Update()
    {
        SetupCircle();
    }

    public void setUp()
    {
        circleCollider.radius = electricFieldRange;
    }

    private void SetupCircle()
    {
        float radius = electricFieldRange - (lineWidth / 2f);
        lineRenderer.widthMultiplier = lineWidth;

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        lineRenderer.positionCount = vertexCount;
        for (int i = 0; i < lineRenderer.positionCount; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            lineRenderer.SetPosition(i, pos);
            theta += deltaTheta;
        }
    }

    void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, electricFieldRange);

        float radius = electricFieldRange - (lineWidth / 2f);

        float deltaTheta = (2f * Mathf.PI) / vertexCount;
        float theta = 0f;

        Vector3 oldPos = Vector3.zero;
        for (int i = 0; i < vertexCount + 1; i++)
        {
            Vector3 pos = new Vector3(radius * Mathf.Cos(theta), radius * Mathf.Sin(theta), 0f);
            Gizmos.DrawLine(oldPos, transform.position + pos);
            oldPos = transform.position + pos;

            theta += deltaTheta;
        }
    }
}
