using UnityEngine;
using UnityEngine.AI;

//using Collections;
//using Collections.Generic;
namespace PathCreation.Examples
{
    public class NpcSpawner : MonoBehaviour
{
    public GameObject ghoulPrefab;
    public int numberOfGhouls;
    public PathCreator pathCreator;
        public int numpoints;
        Quaternion spawnRotation;
        public PathFollower pathFollower;
        public void Awake()
    {
        for (int i = 0; i < numberOfGhouls; i++)
        {
                numpoints = pathCreator.path.NumPoints;

               var pointOrigin = Random.Range(0, numpoints);
            var spawnPosition = pathCreator.path.GetPoint(pointOrigin);
                 spawnRotation = pathCreator.path.GetRotation(pointOrigin) ;
            if (noOverlap(spawnPosition) < 1)
            {
                    
                var ghoulNPC = Instantiate(ghoulPrefab, spawnPosition, spawnRotation);
                    pointOrigin = pathFollower.pointOrigin;

                }
                else
            {
                while (noOverlap(spawnPosition) >= 1)
                {
                        pointOrigin = Random.Range(0, numpoints);
                        spawnPosition = pathCreator.path.GetPoint(pointOrigin);
                        spawnRotation = pathCreator.path.GetRotation(pointOrigin);
                    }
                var ghoulNPC = Instantiate(ghoulPrefab, spawnPosition, spawnRotation);
                    pointOrigin = pathFollower.pointOrigin;
            }

        }
    }
    public int noOverlap(Vector3 pos)
    {
        Collider[] hits = Physics.OverlapSphere(pos, 0.5f);
        return hits.Length;
    }
}
}
