using UnityEngine;
using TileMap;

public class RandomMove : MonoBehaviour
{
    [HideInInspector] public Tile tile;
    [SerializeField, Range(0, 10)] private float speed = 10;
    public Vector2 direction;
    public Vector2 targetPosition;
    private Vector2 position
    {
        get
            => (Vector2)this.transform.position;
        set
            => this.transform.position = new Vector3(value.x, value.y, -0.1f);
    }

    private void Start()
    {
        CalculateNewTargetPosition();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 difference = position - targetPosition;

        if ((difference + direction * Time.deltaTime).magnitude > difference.magnitude)
            CalculateNewTargetPosition();

        position += direction * Time.deltaTime;
    }

    private void CalculateNewTargetPosition()
    {
        targetPosition = new Vector2(Random.Range(-0.4f, 0.4f), Random.Range(-0.25f, 0.55f)) + tile.Position;

        direction = (targetPosition - position).normalized * speed;
    }
}
