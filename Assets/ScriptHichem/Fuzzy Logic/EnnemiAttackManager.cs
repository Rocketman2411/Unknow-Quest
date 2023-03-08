using System;
using UnityEngine;

namespace ScriptHichem.Fuzzy_Logic
{
    public class EnemmiAttackManager : MonoBehaviour
    {
        [SerializeField] GameObject ennemiObject;
        [SerializeField] GameObject playerObject;

        //Variable pour la detection du Player
        private Transform target;
        private Vector3 _ennemiPosition;
        private Vector3 _playerPosition;
        
        private double _radarRange = 5;
        private double _distance;

        private EnnemiScriptComponent _ennemiScriptComponent;
        private bool lifeState;
        private float speed = 2;

        private void Awake()
        {
            _ennemiScriptComponent = FindObjectOfType<EnnemiScriptComponent>();
            target = playerObject.transform;
        }
        
        private double PlayerDistance(Vector3 posE, Vector3 posP)
        {
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
            
            if ( _distance <= _radarRange)
            {
                if (_ennemiScriptComponent.life == 100)
                {
                    ennemiObject.transform.position = Vector3.MoveTowards(ennemiObject.transform.position,
                                                                                target.position, 
                                                                   speed * Time.deltaTime);
                }
                else
                {
                    if (_ennemiScriptComponent.life < 100 && _ennemiScriptComponent.life > 80 )
                    {
                        ennemiObject.transform.position = Vector3.MoveTowards(ennemiObject.transform.position,
                                                                                    target.position, 
                                                                       ((speed*0.8f) * Time.deltaTime));
                    }

                    if (_ennemiScriptComponent.life < 80 && _ennemiScriptComponent.life > 50)
                    {
                        ennemiObject.transform.position = Vector3.MoveTowards(ennemiObject.transform.position,
                                                                                    target.position, 
                                                                     ((speed*0.5f) * Time.deltaTime));
                    }
                }
                
            }
            
            
        }
    }
}
