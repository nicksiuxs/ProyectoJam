using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public abstract class ElectricBehaviour : MonoBehaviour
{
    public bool isOn;
    public bool alwaysOn;
    public float electricFieldRange;
    public LayerMask electricLayer;
    public CircleCollider2D circleCollider;

    [Header("Range Circle")]
    public LineRenderer lineRenderer;
    public float lineWidth;
    public int vertexCount;

    // Start is called before the first frame update
    void Start()
    {
        setUp();
        toStart();
    }

    void OnValidate()
    {
        setUp();
    }

    void Update()
    {
        SetupCircle();
        Debug.Log("sirve");
        toUpdate();
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
        toOnDrawGizmos();
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

    public abstract void toStart();
    public abstract void toUpdate();
    public abstract void toOnDrawGizmos();

    public abstract Collider2D[] getCollidedElements();
    public abstract List<ElectricBehaviour> handleActivate();
    public abstract void handleDeactivate();
}
