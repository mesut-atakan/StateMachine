using UnityEngine;

namespace NotsGame.Core.NSM
{
    [CreateAssetMenu(fileName = nameof(PatrolState), menuName = Constants.COMPANY_NAME + "/States/" + nameof(PatrolState))]
    public class PatrolState : State
    {
        [SerializeField] private Transform[] patrolPoints;
        [SerializeField] private float stepSpeed = 3;
        [SerializeField] private float distance = 0.2f;

        private int _currentPointIndex = 0;
        private Transform _currentTargetPoint;

        private Transform GetNextPoint
        {
            get
            {
                _currentTargetPoint = patrolPoints[_currentPointIndex];

                _currentPointIndex++;
                if (_currentPointIndex >= patrolPoints.Length)
                {
                    _currentPointIndex = 0;
                }
                return _currentTargetPoint;
            }
        }

        public override void OnEnter(Transform stateOwner)
        {
            base.OnEnter(stateOwner);
            _currentTargetPoint = GetNextPoint;
            Debug.Log("Patrol State Enter");
        }

        public override void OnExit()
        {
            base.OnExit();
            Debug.Log("Patrol State Exit");
        }

        public override void OnFixedUpdate()
        {
            base.OnFixedUpdate();

            
                Move();
        }

        private void Move()
        {
            if (!DistanceControl())
            {
                stateOwner.position = Vector3.MoveTowards(stateOwner.position, _currentTargetPoint.position, stepSpeed * Time.deltaTime);
            }
            else
            {
                _currentTargetPoint = GetNextPoint;
            }
            Debug.Log("Move");
        }

        private bool DistanceControl()
        {
            if (stateOwner == null || _currentTargetPoint == null) return false;
            return Vector3.Distance(stateOwner.position, _currentTargetPoint.position) < distance;
        }

        private void OnDrawGizmos()
        {
            if (patrolPoints != null && patrolPoints.Length > 0)
            {
                Gizmos.color = Color.yellow;
                foreach (Transform point in patrolPoints)
                {
                    Gizmos.DrawWireSphere(point.position, 1);
                }
            }
        }
    }
}