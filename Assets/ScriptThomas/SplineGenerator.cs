using UnityEngine;

public class SplineGenerator : MonoBehaviour
{
    public Vector3[] pointsControl;
        public int resolution = 10;
        public bool loop = false;
    
        private Vector3[] points;
        private int segments;
    
        void Start() 
        {
            segments = pointsControl.Length - 1;
            points = new Vector3[resolution * segments + 1];
    
            for (int i = 0; i < segments; i++) {
                for (int j = 0; j < resolution; j++) {
                    float t = (float) j / resolution;
                    points[i * resolution + j] = CalculerPointsSpline(pointsControl[i], pointsControl[i + 1], t);
                }
            }
    
            points[resolution * segments] = pointsControl[loop ? 0 : segments];
        }
    
        private Vector3 CalculerPointsSpline(Vector3 point1, Vector3 point2, float t) 
        {
            float t2 = Mathf.Pow(t,2);
            float t3 = Mathf.Pow(t,3);
            Vector3 tangent = (point2 - point1).normalized;
            float coeff1 = 2 * t3 - 3 * t2 + 1;
            float coeff2 = t3 - 2 * t2 + t;
            float coeff3 = -2 * t3 + 3 * t2;
            float coeff4 = t3 - t2;
            return coeff1 * point1 + coeff2 * tangent + coeff3 * point2 + coeff4 * tangent;
        }
    
        public Vector3 GetPoint(float t) 
        {
            if (t >= 1)
            {
                t = 0.999999f;
            }
            int segment = Mathf.FloorToInt(t * segments);
            int index = Mathf.Clamp(segment * resolution, 0, points.Length - 1);
            float segmentT = (t - (float) segment / segments) * segments;
            return Vector3.Lerp(points[index], points[index + 1], segmentT * resolution - index);
        }
}
