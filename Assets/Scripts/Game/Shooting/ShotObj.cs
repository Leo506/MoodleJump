using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Shooting
{
    public class ShotObj : MonoBehaviour
    {
        [SerializeField] float speed;
        [SerializeField] float lifeTime;

        Vector2 direction;

        bool canMove = false;

        public void Init(Vector2 dir)
        {
            direction = dir;
            canMove = true;
            StartCoroutine(Life());
        }

        private void Update()
        {
            if (canMove)
                transform.Translate(direction * speed * Time.deltaTime);
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Enemy")
            {
                Destroy(collision.gameObject);
                Destroy(this.gameObject);
            }
        }

        IEnumerator Life()
        {
            yield return new WaitForSeconds(lifeTime);
            Destroy(gameObject);
        }
    }
}