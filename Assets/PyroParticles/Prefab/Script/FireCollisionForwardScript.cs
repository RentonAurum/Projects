using UnityEngine;
using System.Collections;

namespace DigitalRuby.PyroParticles
{
    public interface ICollisionHandler
    {
        void HandleCollision(GameObject obj, Collision c);
    }

    /// <summary>
    /// This script simply allows forwarding collision events for the objects that collide with something. This
    /// allows you to have a generic collision handler and attach a collision forwarder to your child objects.
    /// In addition, you also get access to the game object that is colliding, along with the object being
    /// collided into, which is helpful.
    /// </summary>
    public class FireCollisionForwardScript : MonoBehaviour
    {
        public ICollisionHandler CollisionHandler;
        public Enemy_AI_Caster casterStats;

        private void OnTriggerEnter(Collider other)
        {
            if (other.tag == "Player")
            {
                casterStats.rangedStats.atk = 30;
                other.gameObject.GetComponent<Player_Stats>().takeDamage(casterStats.rangedStats.atk);
                Debug.Log("Danni : " + casterStats.rangedStats.atk);
                //Instantiate(destroyEff, transform.position, Quaternion.identity);
                //Destroy(gameObject);
            }
        }

        public void OnCollisionEnter(Collision col)
        {
            CollisionHandler.HandleCollision(gameObject, col);
        }
    }
}
