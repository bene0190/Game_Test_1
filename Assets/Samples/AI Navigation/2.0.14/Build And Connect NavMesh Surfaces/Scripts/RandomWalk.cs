using UnityEngine;
using UnityEngine.AI;

namespace Unity.AI.Navigation.Samples
{
    /// <summary>
    /// Walk to a random position and repeat
    /// </summary>
    [RequireComponent(typeof(NavMeshAgent))]
    public class RandomWalk : MonoBehaviour
    {
        public float m_Range = 25.0f;
        NavMeshAgent m_Agent;
        private Vector3 m_StartPosition;

        void Start()
        {
            m_Agent = GetComponent<NavMeshAgent>();
            m_StartPosition = transform.position;
        }

        void Update()
        {
            if (m_Agent.pathPending || !m_Agent.isOnNavMesh || m_Agent.remainingDistance > 0.1f)
                return;

            ChooseRandomDestination();
        }
        void ChooseRandomDestination()
        {
            Vector2 randomPoint = Random.insideUnitCircle * m_Range;
            Vector3 targetPosition = m_StartPosition + new Vector3(randomPoint.x, 0f, randomPoint.y);
            NavMeshHit hit;

            if (NavMesh.SamplePosition(targetPosition, out hit, m_Range, NavMesh.AllAreas))
            {
                m_Agent.SetDestination(hit.position);
            }
        }
    }
}