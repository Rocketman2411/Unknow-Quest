using System;
using UnityEngine;

namespace ScriptHichem.Fuzzy_Logic
{
    public class EnemmiAttackManager : MonoBehaviour
    {
        [Header("Définition GameObject")]
        [SerializeField] GameObject ennemiObject;
        [SerializeField] GameObject playerObject;

        //Variable pour la detection du Player
        private Transform target;
        private Vector3 _ennemiPosition;
        private Vector3 _playerPosition;
        
        private double _distance;
        
        //Variable pour la vitesse du follow
        private EnnemiScriptComponent _ennemiScriptComponent;
        private AttackFolowEnnemi _action;

        private void Awake()
        {
            _ennemiScriptComponent = FindObjectOfType<EnnemiScriptComponent>();
            _action = FindObjectOfType<AttackFolowEnnemi>();
            target = playerObject.transform;
        }

        private double PlayerDistance(Vector3 posE, Vector3 posP)
        {
            //Utilise pythagore  pour calculer la distance
            double z = Math.Abs(posE.z) - Math.Abs(posP.z);
            double x = Math.Abs(posE.x) - Math.Abs(posP.x);
            
            return Math.Sqrt((Math.Pow(z,2))+ (Math.Pow(x,2)));
        }
        void Update()
        {
            _ennemiPosition = ennemiObject.transform.position;
            _playerPosition = playerObject.transform.position;
            
            //Calcule distance à chauqe frame
            _distance = PlayerDistance(_ennemiPosition, _playerPosition);
            
            //Gère le déplacement de l'ennemi vers le player 
            _action.EnnemiFollow(_distance,ennemiObject,target);
            
        }
    }
}
