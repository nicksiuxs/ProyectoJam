using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircularElectricFieldController : ElectricFieldController
{
    public CircleCollider2D colliderElectricRange;

    [Header("Line Range")]
    public float lineWidth;
    public int vertexCount;
    public LineRenderer lineRenderer;
    public ParticleSystem particles;

    public override void toUpdate()
    {
        setUpCircle();
        modifyParticlesRange();
    }

    public override void toOnDrawGizmos()
    {
        setUpGizmos();
    }

    public override List<Collider2D> getCollidedElements()
    {
        List<Collider2D> colliders = new List<Collider2D>();
        ContactFilter2D contactFilter = new ContactFilter2D();
        contactFilter.SetLayerMask(base.electricLayer);
        contactFilter.useTriggers = true;

        Physics2D.OverlapCollider(colliderElectricRange, contactFilter, colliders);

        return colliders;
    }

    public override void activateParticleSystem()
    {
        particles.Play();
    }

    public override void deactivateParticleSystem()
    {
        particles.Stop();
    }

    private void setUpCircle()
    {
        float radius = colliderElectricRange.radius - (lineWidth / 2f);
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

    private void setUpGizmos()
    {
        Gizmos.DrawWireSphere(gameObject.transform.position, colliderElectricRange.radius);

        float radius = colliderElectricRange.radius - (lineWidth / 2f);

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

    private void modifyParticlesRange()
    {
        var mainParticles = particles.main;
        Vector3 desiredDistance = new Vector3(this.transform.position.x + colliderElectricRange.radius, this.transform.position.y, this.transform.position.z);
        float startSpeed = mainParticles.startSpeedMultiplier;
        mainParticles.startLifetime = Vector3.Distance(this.transform.position, desiredDistance)/startSpeed;
    }
}
