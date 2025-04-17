using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer), typeof(EdgeCollider2D))]
public class MouseLineDrawer : MonoBehaviour
{
    public float pointSpacing = 0.1f;

    private LineRenderer lineRenderer;
    private EdgeCollider2D edgeCollider;
    private List<Vector2> colliderPoints = new List<Vector2>();
    private List<Vector3> linePoints = new List<Vector3>();

    void Awake()
    {
        lineRenderer = GetComponent<LineRenderer>();
        edgeCollider = GetComponent<EdgeCollider2D>();

        lineRenderer.positionCount = 0;
        edgeCollider.points = new Vector2[0];
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            linePoints.Clear();
            colliderPoints.Clear();
            lineRenderer.positionCount = 0;
            edgeCollider.points = new Vector2[0];
        }

        if (Input.GetMouseButton(1))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = 0f;

            if (linePoints.Count == 0 || Vector3.Distance(mousePos, linePoints[linePoints.Count - 1]) >= pointSpacing)
            {
                // Add to line
                linePoints.Add(mousePos);
                lineRenderer.positionCount = linePoints.Count;
                lineRenderer.SetPosition(linePoints.Count - 1, mousePos);

                // Add to collider (2D Vector)
                colliderPoints.Add(mousePos);
                edgeCollider.points = colliderPoints.ToArray();
            }
        }
    }
}
