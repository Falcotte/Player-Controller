using System.Collections.Generic;
using UnityEngine;

namespace AngryKoala.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Transform'un x pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        public static void SetX(this Transform transform, float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// Transform'un y pozisyonunu setler
        /// </summary>
        /// <param name="y">Y degeri.</param>
        public static void SetY(this Transform transform, float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        /// <summary>
        /// Transform'un z pozisyonunu setler
        /// </summary>
        /// <param name="z">Z degeri.</param>
        public static void SetZ(this Transform transform, float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        /// <summary>
        /// Transform'un x ve y pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        /// <param name="y">Y degeri.</param>
        public static void SetXY(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }

        /// <summary>
        /// Transform'un x ve z pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        /// <param name="z">Z degeri.</param>
        public static void SetXZ(this Transform transform, float x, float z)
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }

        /// <summary>
        /// Transform'un y ve z pozisyonunu setler
        /// </summary>
        /// <param name="y">Y degeri.</param>
        /// <param name="z">Z degeri.</param>
        public static void SetYZ(this Transform transform, float y, float z)
        {
            transform.position = new Vector3(transform.position.x, y, z);
        }

        /// <summary>
        /// Transform'un local x pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        public static void SetLocalX(this Transform transform, float x)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }

        /// <summary>
        /// Transform'un local y pozisyonunu setler
        /// </summary>
        /// <param name="y">Y degeri.</param>
        public static void SetLocalY(this Transform transform, float y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }

        /// <summary>
        /// Transform'un local z pozisyonunu setler
        /// </summary>
        /// <param name="z">Z degeri.</param>
        public static void SetLocalZ(this Transform transform, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
        }

        /// <summary>
        /// Transform'un local x ve y pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        /// <param name="y">Y degeri.</param>
        public static void SetLocalXY(this Transform transform, float x, float y)
        {
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }

        /// <summary>
        /// Transform'un local x ve z pozisyonunu setler
        /// </summary>
        /// <param name="x">X degeri.</param>
        /// <param name="z">Z degeri.</param>
        public static void SetLocalXZ(this Transform transform, float x, float z)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }

        /// <summary>
        /// Transform'un local y ve z pozisyonunu setler
        /// </summary>
        /// <param name="y">Y degeri.</param>
        /// <param name="z">Z degeri.</param>
        public static void SetLocalYZ(this Transform transform, float y, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, z);
        }

        /// <summary>
        /// Transform'un pozisyonunu ve rotasyonunu setler
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static void PosRot(this Transform transform, Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Transform'un pozisyonunu ve scale'ini setler
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static void PosScale(this Transform transform, Vector3 position, Vector3 scale)
        {
            transform.position = position;
            transform.localScale = scale;
        }

        /// <summary>
        /// Transform'un rotasyonunu ve scale'ini setler
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static void RotScale(this Transform transform, Quaternion rotation, Vector3 scale)
        {
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        /// <summary>
        /// Transform'un pozisyonunu, rotasyonunu ve scale'ini setler
        /// </summary>
        /// <param name="v"></param>
        /// <param name="x"></param>
        /// <returns></returns>
        public static void PosRotScale(this Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        /// <summary>
        /// Transform'un child'ini bulmak icin recursive bir arama yapar
        /// </summary>
        /// <param name="transform"></param>
        /// <param name="name"></param>
        /// <param name="includeInactive"></param>
        /// <returns></returns>
        public static Transform FindRecursive(this Transform transform, string name, bool includeInactive = false)
        {
            foreach(Transform child in transform.GetComponentsInChildren<Transform>(includeInactive))
            {
                if(child.name.Equals(name))
                {
                    return child;
                }
            }
            return null;
        }

        /// <summary>
        /// Transform'un x yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithX(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }

        /// <summary>
        /// Transform'un x yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithX(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }

        /// <summary>
        /// Transform'un y yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithY(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }

        /// <summary>
        /// Transform'un y yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithY(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }

        /// <summary>
        /// Belirli bir hizla LookAt yapar
        /// </summary>
        public static void LookAtGradually(this Transform transform, Transform target, float maxRadiansDelta, bool stableUpVector = false)
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadiansDelta, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
            if(stableUpVector)
            {
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);
            }
        }

        /// <summary>
        /// Belirli bir hizla LookAt yapar
        /// </summary>
        public static void LookAtGradually(this Transform transform, Vector3 target, float maxRadiansDelta, bool stableUpVector = false)
        {
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, targetDirection, maxRadiansDelta, 0.0f);

            transform.rotation = Quaternion.LookRotation(newDirection);
            if(stableUpVector)
            {
                transform.localRotation = Quaternion.Euler(0f, transform.localRotation.eulerAngles.y, 0f);
            }
        }

        /// <summary>
        /// Belirli bir hizla transform'un x yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithXGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.right, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDirection);
        }

        /// <summary>
        /// Belirli bir hizla transform'un x yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithXGradually(this Transform transform, Vector3 target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.right, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDirection);
        }

        /// <summary>
        /// Belirli bir hizla transform'un y yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithYGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.up, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithY(newDirection);
        }

        /// <summary>
        /// Belirli bir hizla transform'un y yonuyle LookAt yapar
        /// </summary>
        public static void LookAtWithYGradually(this Transform transform, Vector3 target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.up, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithY(newDirection);
        }

        public static void TraversePathByDistance(this Transform transform, List<Vector3> path, float distance)
        {
            Vector3 position;

            float remainingDistance = distance;
            int currentPathNode = 0;

            if(path.Count == 0)
            {
                return;
            }
            else
            {
                position = path[0];
            }

            while(remainingDistance >= 0f)
            {
                if(currentPathNode == path.Count - 1)
                {
                    position = path[currentPathNode];
                    break;
                }

                float distanceToNextPathNode = Vector3.Distance(path[currentPathNode], path[currentPathNode + 1]);

                if(distanceToNextPathNode >= remainingDistance)
                {
                    position = Vector3.MoveTowards(position, path[currentPathNode + 1], remainingDistance);
                    break;
                }
                else
                {
                    position = path[currentPathNode + 1];
                    currentPathNode++;
                    remainingDistance -= distanceToNextPathNode;
                }
            }

            transform.position = position;
        }

        public static void TraversePathByDistance(this Transform transform, List<Transform> path, float distance)
        {
            Vector3 position;

            float remainingDistance = distance;
            int currentPathNode = 0;

            if(path.Count == 0)
            {
                return;
            }
            else
            {
                position = path[0].position;
            }

            while(remainingDistance >= 0f)
            {
                if(currentPathNode == path.Count - 1)
                {
                    position = path[currentPathNode].position;
                    break;
                }

                float distanceToNextPathNode = Vector3.Distance(path[currentPathNode].position, path[currentPathNode + 1].position);

                if(distanceToNextPathNode >= remainingDistance)
                {
                    position = Vector3.MoveTowards(position, path[currentPathNode + 1].position, remainingDistance);
                    break;
                }
                else
                {
                    position = path[currentPathNode + 1].position;
                    currentPathNode++;
                    remainingDistance -= distanceToNextPathNode;
                }
            }

            transform.position = position;
        }
    }
}
