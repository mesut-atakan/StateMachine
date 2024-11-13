using Sirenix.OdinInspector;
using UnityEngine;

namespace NotsGame.Core.StateSystem
{
    public class PatrolState : State
    {
        public override StateType stateType => StateType.Patrol;

        [SerializeField] private Transform[] points;
        [SerializeField] private float _targetDistance = 0.3f;
        [SerializeField] private float stepSpeed = 0.3f;

        [SerializeField, ReadOnly] private Transform _targetPoint;
        private int _targetPointIndex = 0;

        private int NextPointIndex => (_targetPointIndex++) % points.Length;

        private void Awake()
        {
            _targetPointIndex = 0;
        }

        private void OnDrawGizmos()
        {
            if (points != null && points.Length > 0)
            {
                Gizmos.color = Color.yellow;
                foreach (Transform t in points)
                {
                    Gizmos.DrawWireSphere(t.position, _targetDistance);

                }
            }
        }

        public override void OnEnter()
        {
            Debug.Log("Karakter Nobete Basladi");
            NextPoint();
        }

        public override void OnUpdate()
        {
            Debug.Log("Karakter Nobete Devam Ediyor");
            Patrol();
        }

        public override void OnExit()
        {
            Debug.Log("Karakter Nobeti Bitirdi!");
        }

        private void Patrol()
        {
            if (_targetPoint == null)
            {
                Debug.LogWarning("Null Referance Exception `_targetPoint`", gameObject);
                return;
            }

            float distance = Vector3.Distance(transform.position, _targetPoint.position);
            Debug.Log($"Distance => {distance}", gameObject);
            if (distance > _targetDistance)
            {
                transform.position = Vector3.MoveTowards(transform.position, _targetPoint.position, stepSpeed);
            }
            else
            {
                NextPoint();
            }
        }

        private void NextPoint()
        {
            _targetPoint = points[NextPointIndex];
        }
    }
}