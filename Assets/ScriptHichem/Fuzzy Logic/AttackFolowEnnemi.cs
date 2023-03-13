using UnityEngine;

namespace ScriptHichem.Fuzzy_Logic
{
    public class AttackFolowEnnemi : MonoBehaviour
    {
        private EnnemiScriptComponent _ennemiScript;
        private float _speed = 3;
        private double _radarRange = 5;

        private void Awake()
        {
            _ennemiScript = FindObjectOfType<EnnemiScriptComponent>();
        }

        private bool IsEnoughClose(double d)
        {
            if (d < _radarRange )
            {
                return true;
            }

            return false;
        }
        public void EnnemiFollow(double d, GameObject e, Transform t)
        {
            if ( IsEnoughClose(d))
            {
                if (_ennemiScript.life == 100)
                {
                        e.transform.position = Vector3.MoveTowards(e.transform.position,
                                                t.position, 
                                                _speed * Time.deltaTime);
                }
                else
                {
                    if (_ennemiScript.life < 100 && _ennemiScript.life > 80 )
                    {
                            e.transform.position = Vector3.MoveTowards(e.transform.position,
                                                        t.position, 
                                                        ((_speed*0.8f) * Time.deltaTime));
                    }
            
                    if (_ennemiScript.life < 80 && _ennemiScript.life > 50)
                    {
                            e.transform.position = Vector3.MoveTowards(e.transform.position,
                                                        t.position, 
                                                        ((_speed*0.5f) * Time.deltaTime));
                    }
                            
                    if (_ennemiScript.life < 50 && _ennemiScript.life > 30)
                    {
                            e.transform.position = Vector3.MoveTowards(e.transform.position,
                                                        t.position, 
                                                        ((_speed*0.4f) * Time.deltaTime));
                    }
                            
                    if (_ennemiScript.life < 30)
                    {
                            e.transform.position = Vector3.MoveTowards(e.transform.position,
                                                        t.position, 
                                                        ((_speed*0.3f) * Time.deltaTime));
                    }
                }
            }
            if (_ennemiScript.life == 0)
            {
                Destroy(e);
            }
        }
    }
}
