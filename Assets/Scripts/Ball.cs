using UnityEngine;
using System.Collections.Generic;

namespace Assets.Scripts
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class Ball : MonoBehaviour
    {
        public Color Color { get => _spriteRenderer.color; }
        protected SpriteRenderer _spriteRenderer;

        //TODO: Implement 2 types of balls which has red and blue colors.
        //OPTIONAL: Think outside the box.
        public List<Color> colorList = new List<Color>();

        protected virtual void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();

        }

        private void Start() 
        {
            colorList.Add(Color.red);
            colorList.Add(Color.blue);
            int randomNumber = Random.Range(0,10);
            //if an even number is randomly selected; create red ball else create blue ball
            if(randomNumber%2==0){
                _spriteRenderer.color = Color.red;
            }
            else{
                _spriteRenderer.color = Color.blue;
            }
        }

        public void SetName(string name)
        {
            this.name = name;
        }


    }
}
