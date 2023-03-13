using UnityEngine;

public class SplineGenerator : MonoBehaviour
{
        public Vector3[] pointsControles;
        public int res = 10;
        private Vector3[] points;
        private int bouttes;
        public bool loop;
        void Awake() 
        {
            bouttes = pointsControles.Length - 1;
            points = new Vector3[res * bouttes + 1];
    
            for (int i = 0; i < bouttes; i++) {
                for (int j = 0; j < res; j++) {
                    float t = (float) j / res;
                    Vector3 point1 = pointsControles[i];
                    Vector3 point2 = pointsControles[i + 1];
                    Vector3 tangente = (point2 - point1).normalized;
                    float coeff1 = 2 * t * t * t - 3 * t * t + 1;
                    float coeff2 = t * t * t - 2 * t * t + t;
                    float coeff3 = -2 * t * t * t + 3 * t * t;
                    float coeff4 = t * t * t - t * t;
                    points[i * res + j] = coeff1 * point1 + coeff2 * tangente + coeff3 * point2 + coeff4 * tangente;
                }
            }

            if (loop)
                points[points.Length - 1] = pointsControles[0];
            else
                points[points.Length - 1] = pointsControles[bouttes];
                
        }
        public Vector3 TrouverPoint(float t) 
        {
            if (t >= 1)
                t = 0.999999f;
            int boutteNuméro = Mathf.FloorToInt(t * bouttes);
            int i = Mathf.Clamp(boutteNuméro * res, 0, points.Length - 1);
            float boutteTemps = (t - (float) boutteNuméro / bouttes) * bouttes;
            return Vector3.Lerp(points[i], points[i + 1], boutteTemps * res - i);
        }
}
