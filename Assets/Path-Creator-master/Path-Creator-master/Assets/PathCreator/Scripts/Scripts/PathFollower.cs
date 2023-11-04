using UnityEngine;
using UnityEngine.AI;

namespace PathCreation.Examples
{
    // Moves along a path at constant speed.
    // Depending on the end of path instruction, will either loop, reverse, or stop at the end of the path.
    public class PathFollower : MonoBehaviour
    {
        public Transform target;

        public float speed; // current speed of this object (calculated from delta since last frame)



        public PathCreator pathCreator;
        public EndOfPathInstruction endOfPathInstruction;
        float distanceTravelled;
        public int pointOrigin;
        public int numpoints;
        public bool is_moving_forward;
        public bool is_moving_backwards;
        private void Awake()
        {
            GenerateSpeed();
            GenerateOrigin();
            MovingDirection();
        }
        void Start()
        {

            if (pathCreator != null)
            {
                // Subscribed to the pathUpdated event so that we're notified if the path changes during the game
                pathCreator.pathUpdated += OnPathChanged;
            }

        }
        private void GenerateSpeed()
        {
            speed = Random.Range(1.5f, 4.0f);
        }
        private void GenerateOrigin()
        {
            numpoints = pathCreator.path.NumPoints;

            pointOrigin = Random.Range(0, numpoints);
            transform.position = pathCreator.path.GetPoint(pointOrigin);
            transform.rotation = pathCreator.path.GetRotation(pointOrigin);
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }

        private void MovingDirection()
        {
            int direction = Random.Range(0, 2);
            if (direction == 0)
            {
                is_moving_forward = true;
                is_moving_backwards = false;
            }
            else if (direction == 1)
            {
                is_moving_forward = false;
                is_moving_backwards = true;
            }


        }

        void Update()
        {
            NavMeshAgent agente = GetComponent<NavMeshAgent>();
            if (agente.speed != speed)
            {
                agente.speed = speed;
            }
            if (is_moving_forward == false)
            {
                distanceTravelled -= speed * Time.deltaTime;

                agente.destination = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                // transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //    transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);

            }
            else
            {
                distanceTravelled += speed * Time.deltaTime;
                agente.destination = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //   transform.position = pathCreator.path.GetPointAtDistance(distanceTravelled, endOfPathInstruction);
                //  transform.rotation = pathCreator.path.GetRotationAtDistance(distanceTravelled, endOfPathInstruction);


            }


        }
        // If the path changes during the game, update the distance travelled so that the follower's position on the new path
        // is as close as possible to its position on the old path
        void OnPathChanged()
        {
            distanceTravelled = pathCreator.path.GetClosestDistanceAlongPath(transform.position);
        }


    }
}