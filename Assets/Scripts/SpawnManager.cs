using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts
{
    public class SpawnManager : MonoBehaviour
    {
        [SerializeField] private GameObject _ballPrefab;

        private List<Ball> _balls = new List<Ball>();
        public UnityEvent SpawnEvent;
        public static event Action IsInstantiated;
        public static event Action IsRemoved;

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mousePosition.z = 0f;
                SpawnBallAtMouseAndGiveName(mousePosition, "Colored Ball");
            }
            else if (Input.GetMouseButtonDown(1))
            {
                //TODO: This should remove all red balls, right?
                //it only deletes the first red ball, instead we should iterate the whole list 
                
                for(int i=0; i<_balls.Count; i++)
                {
                    if (_balls[i].Color == Color.red)
                    {
                        RemoveBall(_balls[i]);
                        i--;
                        //break;
                    }
                }
            }
        }

        public void RemoveBall(Ball ball)
        {
            //TODO: Implement a way to remove a ball from the scene and the list.
            //I also added sound event when red balls are removed
            IsRemoved?.Invoke();
            _balls.Remove(ball);
            Destroy(ball.gameObject);

        }

        private void SpawnBallAtMouseAndGiveName(Vector3 mousePosition, string name)
        {
            //TODO: Spawn a random color of ball at the position of the mouse click and play spawn sound.
            //OPTIONAL: Use events for playing sounds.
            Color randomColor = new Color(Random.value, Random.value, Random.value);
            InstantiateBall(mousePosition, name, randomColor);

            //Sound
            //PlaySpawnSound();
            IsInstantiated?.Invoke();

        }

        private Ball InstantiateBall(Vector3 position, string name, Color color)
        {
            //GameObject ballGameObject = Instantiate(_ballPrefab, position, Quaternion.identity);
            Ball ball = Instantiate(_ballPrefab, position, Quaternion.identity).GetComponent<Ball>(); //TODO: What's a better way to do this?
            ball.SetName(name);
            ball.GetComponent<SpriteRenderer>().color = color;
            _balls.Add(ball);
            return ball;
        }
    }
}