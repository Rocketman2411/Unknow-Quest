using System;
using UnityEngine;

namespace ScriptHichem.Fuzzy_Logic
{
    public class EnemmiDetection : MonoBehaviour
    {
        [SerializeField] GameObject ennemi;
        [SerializeField] GameObject player;

        private Vector3 _ennemiPosition;
        private Vector3 _playerPosition;
        
        private double _ennemiRange = 5;
        private double _distance;
        
        private void Awake()
        {
            
            //À voir comment trouver la position d'un objet
            _ennemiPosition = ennemi.transform.position;
            _playerPosition = player.transform.position;

            _distance = PlayerDistance(_ennemiPosition,_playerPosition);
        }

        //calcule distance entre l'ennemie et le joueur
        private double PlayerDistance(Vector3 posE, Vector3 posP)
        {
            double z = Math.Abs(posE.z) - Math.Abs(posP.z);
            double x = Math.Abs(posE.x) - Math.Abs(posP.x);
            
            return Math.Sqrt((Math.Pow(z,2))+ (Math.Pow(x,2)));
        }
        void Update()
        {
            if ( _distance <= _ennemiRange )
            {
                Debug.Log("Player DETECTED");
            }
        }
    }
}
