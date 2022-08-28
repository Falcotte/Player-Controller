using System.Collections.Generic;
using UnityEngine;

namespace AngryKoala.Extensions
{
    public static class TransformExtensions
    {
        /// <summary>
        /// Sets x position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        public static void SetX(this Transform transform, float x)
        {
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
        }

        /// <summary>
        /// Sets y position of the transform
        /// </summary>
        /// <param name="y">y value</param>
        public static void SetY(this Transform transform, float y)
        {
            transform.position = new Vector3(transform.position.x, y, transform.position.z);
        }

        /// <summary>
        /// Sets z position of the transform
        /// </summary>
        /// <param name="z">z value</param>
        public static void SetZ(this Transform transform, float z)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, z);
        }

        /// <summary>
        /// Sets x and y position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public static void SetXY(this Transform transform, float x, float y)
        {
            transform.position = new Vector3(x, y, transform.position.z);
        }

        /// <summary>
        /// Sets x and z position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="z">z value</param>
        public static void SetXZ(this Transform transform, float x, float z)
        {
            transform.position = new Vector3(x, transform.position.y, z);
        }

        /// <summary>
        /// Sets y and z position of the transform
        /// </summary>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public static void SetYZ(this Transform transform, float y, float z)
        {
            transform.position = new Vector3(transform.position.x, y, z);
        }

        /// <summary>
        /// Sets local x position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        public static void SetLocalX(this Transform transform, float x)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, transform.localPosition.z);
        }

        /// <summary>
        /// Sets local y position of the transform
        /// </summary>
        /// <param name="y">y value</param>
        public static void SetLocalY(this Transform transform, float y)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, transform.localPosition.z);
        }

        /// <summary>
        /// Sets local z position of the transform
        /// </summary>
        /// <param name="z">z value</param>
        public static void SetLocalZ(this Transform transform, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, z);
        }

        /// <summary>
        /// Sets local x and y position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="y">y value</param>
        public static void SetLocalXY(this Transform transform, float x, float y)
        {
            transform.localPosition = new Vector3(x, y, transform.localPosition.z);
        }

        /// <summary>
        /// Sets local x and z position of the transform
        /// </summary>
        /// <param name="x">x value</param>
        /// <param name="z">z value</param>
        public static void SetLocalXZ(this Transform transform, float x, float z)
        {
            transform.localPosition = new Vector3(x, transform.localPosition.y, z);
        }

        /// <summary>
        /// Sets local y and z position of the transform
        /// </summary>
        /// <param name="y">y value</param>
        /// <param name="z">z value</param>
        public static void SetLocalYZ(this Transform transform, float y, float z)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, y, z);
        }

        /// <summary>
        /// Sets position and rotation of the transform
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <returns></returns>
        public static void PosRot(this Transform transform, Vector3 position, Quaternion rotation)
        {
            transform.position = position;
            transform.rotation = rotation;
        }

        /// <summary>
        /// Sets position and scale of the transform
        /// </summary>
        /// <param name="position"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void PosScale(this Transform transform, Vector3 position, Vector3 scale)
        {
            transform.position = position;
            transform.localScale = scale;
        }

        /// <summary>
        /// Sets rotation and scale of the transform
        /// </summary>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void RotScale(this Transform transform, Quaternion rotation, Vector3 scale)
        {
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        /// <summary>
        /// Sets position, rotation and scale of the transform
        /// </summary>
        /// <param name="position"></param>
        /// <param name="rotation"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        public static void PosRotScale(this Transform transform, Vector3 position, Quaternion rotation, Vector3 scale)
        {
            transform.position = position;
            transform.rotation = rotation;
            transform.localScale = scale;
        }

        /// <summary>
        /// Performs a recursive search to find a child of the transform by name
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
        /// Performs a LookAt with transform's x direction
        /// </summary>
        public static void LookAtWithX(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }

        /// <summary>
        /// Performs a LookAt with transform's x direction
        /// </summary>
        public static void LookAtWithX(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.down * 90, Space.Self);
        }

        /// <summary>
        /// Performs a LookAt with transform's y direction
        /// </summary>
        public static void LookAtWithY(this Transform transform, Transform target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }

        /// <summary>
        /// Performs a LookAt with transform's y direction
        /// </summary>
        public static void LookAtWithY(this Transform transform, Vector3 target)
        {
            transform.LookAt(target);
            transform.Rotate(Vector3.right * 90, Space.Self);
        }

        /// <summary>
        /// Performs a LookAt with a set speed
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
        /// Performs a LookAt with a set speed
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
        /// Performs a LookAt with a set speed with transform's x direction
        /// </summary>
        public static void LookAtWithXGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.right, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDirection);
        }

        /// <summary>
        /// Performs a LookAt with a set speed with transform's x direction
        /// </summary>
        public static void LookAtWithXGradually(this Transform transform, Vector3 target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.right, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithX(newDirection);
        }

        /// <summary>
        /// Performs a LookAt with a set speed with transform's y direction
        /// </summary>
        public static void LookAtWithYGradually(this Transform transform, Transform target, float maxRadiansDelta)
        {
            Vector3 targetDirection = target.position - transform.position;
            Vector3 newDirection = Vector3.RotateTowards(transform.up, targetDirection, maxRadiansDelta, 0.0f);

            transform.LookAtWithY(newDirection);
        }

        /// <summary>
        /// Performs a LookAt with a set speed with transform's y direction
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
