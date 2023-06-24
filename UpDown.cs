using UnityEngine;

public class UpDown : MonoBehaviour
{
    [SerializeField] private Transform targetA, targetB;
    [SerializeField] private float speed = 4f; // Change this to suit your game.
    private bool movingToB = true;

    private Vector3 _direction;

    public Vector3 Direction { get => _direction; set => _direction = value; }
    public float Speed { get => speed; set => speed = value; }

    void FixedUpdate()
    {
        if (movingToB)
        {
            MoveToTarget(targetB);
        }
        else
        {
            MoveToTarget(targetA);
        }
    }

    private void MoveToTarget(Transform target)
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);

        if (transform.position == target.position)
        {
            movingToB = !movingToB;
            return;
        }
        _direction = (target.position - transform.position).normalized;
    }
}


