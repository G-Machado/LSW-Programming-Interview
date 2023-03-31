using UnityEngine;

public class SpriteLayerOrder : MonoBehaviour
{
    public SpriteRenderer spriteRenderer;

    [Range(-3, 3)]
    public float offset;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        spriteRenderer.sortingOrder = (int) (((transform.position.y * -1) - offset) * 1000);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Vector3 start = transform.position;
        Vector3 end = start + Vector3.up * offset;

        Gizmos.DrawLine(start, end);
        Gizmos.DrawIcon(end, "offset.png");
    }
}