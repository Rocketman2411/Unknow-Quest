using UnityEngine;

public class SplineGenerator : MonoBehaviour
{
    public Vector3[] pointsControl;
        public int res = 10;
        public bool loop = false;
    
        private Vector3[] points;
        private int segments;
    
        void Awake() 
        {
            segments = pointsControl.Length - 1;
            points = new Vector3[res * segments + 1];
    
            for (int i = 0; i < segments; i++) {
                for (int j = 0; j < res; j++) {
                    float t = (float) j / res;
                    Vector3 point1 = pointsControl[i];
                    Vector3 point2 = pointsControl[i + 1];
                    Vector3 tangent = (point2 - point1).normalized;
                    float coeff1 = 2 * t * t * t - 3 * t * t + 1;
                    float coeff2 = t * t * t - 2 * t * t + t;
                    float coeff3 = -2 * t * t * t + 3 * t * t;
                    float coeff4 = t * t * t - t * t;
                    
                    points[i * res + j] = coeff1 * point1 + coeff2 * tangent + coeff3 * point2 + coeff4 * tangent;
                }
            }
            points[res * segments] = pointsControl[segments];
        }
        public Vector3 GetPoint(float t) 
        {
            if (t >= 1)
            {
                t = 0.999999f;
            }
            int segment = Mathf.FloorToInt(t * segments);
            int index = Mathf.Clamp(segment * res, 0, points.Length - 1);
            float segmentT = (t - (float) segment / segments) * segments;
            return Vector3.Lerp(points[index], points[index + 1], segmentT * res - index);
        }
}
