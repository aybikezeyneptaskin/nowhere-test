using UnityEngine;

namespace Assets.Scripts.Managers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance{get; private set;}

        //[SerializeField] private AudioSource _spawnSound;
        [SerializeField] AudioClip _spawnSound;
        [SerializeField] AudioClip _removeSound;
        AudioSource _audioSource;

        private void Awake()
        {
            //TODO: What's a better way to implement this singleton?

            //if no instance
            if (Instance == null)
            {
                Instance = this;
            }
            //if there are instances other than this
            else if(Instance != this)
            {
                Destroy(this);
            }

            _audioSource = GetComponent<AudioSource>();
        }

        public void PlaySpawnSound()
        {
            _audioSource.PlayOneShot(_spawnSound);
        }

        public void PlayRemoveSound()
        {
            _audioSource.PlayOneShot(_removeSound);
        }

        private void OnEnable() 
        {   
            SpawnManager.IsInstantiated += PlaySpawnSound;
            SpawnManager.IsRemoved += PlayRemoveSound;
        }
        
        private void OnDisable() 
        {
            SpawnManager.IsInstantiated -= PlaySpawnSound;
            SpawnManager.IsRemoved -= PlayRemoveSound;
        }
    }
}