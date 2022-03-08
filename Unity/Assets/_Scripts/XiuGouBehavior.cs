using System;
using DG.Tweening;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts
{
    public class XiuGouBehavior : MonoBehaviour
    {
        [SerializeField] private float speed = 0.3f;
        private float direction = 1f;
        [SerializeField] private float fixedInterval = 3.0f;
        [SerializeField] private bool bMove = true;
        [SerializeField] private GameObject sprite;
        [SerializeField] public TextMeshPro nameText;
        private float oriScaleX;

        private void Awake()
        {
            oriScaleX = transform.GetChild(0).localScale.x;
        }

        // Start is called before the first frame update
        void Start()
        {
            // StartCoroutine()
            // InvokeRepeating(nameof(LiuDa), 0f, fixedInterval);
            if (false)
                // if (bMove)
            {
                this.LiuDa();
            }
        }

        /// <summary>
        /// Basically "wander" or "walk". "LiuDa" is a better word, actually :)
        /// </summary>
        void LiuDa()
        {
            var randX = Random.Range(0f, 1f);
            var randZ = Random.Range(0f, 1f);
            var position = Scatter.instance.small.position;
            var position1 = Scatter.instance.big.position;
            var targetX = Mathf.Lerp(position.x, position1.x, randX);
            var targetZ = Mathf.Lerp(position.z, position1.z, randZ);
            var targetPos = new Vector3(targetX, position.y, targetZ);
            var dis = Vector3.Distance(this.transform.position, targetPos);
            var moveDuration = dis / speed;
            var spriteChild = this.transform.GetChild(0);
            if (targetX>= this.transform.position.x)
            {
                if (direction<0)
                {
                    direction = 1f;
                    spriteChild.DOScaleX(direction*oriScaleX, 0.3f);
                }
            }
            else
            {
                if (direction>0)
                {
                    direction = -1f;
                    spriteChild.DOScaleX(direction*oriScaleX, 0.3f);
                }
            }

            this.transform.DOMove(targetPos, moveDuration, false).OnComplete(this.LiuDa);
            // this.transform.DOMove(targetPos, fixedInterval, false).OnStart(() =>
            // {
            //     Debug.Log("start move...");
            // });
            //     .onComplete(() =>
            // {
            //     this.LiuDa();
            // });
        }
    }
}
