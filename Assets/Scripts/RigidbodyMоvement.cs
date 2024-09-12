using UnityEngine;

public class RigidbodyMоvement
{
        private const float MIN_DISTANCE_POW = 0.001f;

        private readonly Rigidbody _rb;
        private readonly float _speed;

        private int index = 0;
        Vector3 currentTargetPoint;

        public Vector3 Direction => _rb.velocity.normalized;

        public RigidbodyMоvement(Rigidbody rb, float speed)
        {
            _rb = rb;
            _speed = speed;
        }

        public void MoveByDirectionToPoint(Vector3 targetPoint)
        {
            var direction = (targetPoint - _rb.transform.position).normalized;
            _rb.velocity = new Vector3(direction.x, 0, direction.z) * _speed;
        }

        public void Stop()
        {
            _rb.velocity = Vector3.zero;
        }
}
