using UnityEngine;

namespace samalonso.zombieasteroids.Behaviors
{
    public class FlipImageEffectBehavior : MonoBehaviour
    {
        public float SecondsToChange;
        
        void Start()
        {
            InvokeRepeating("RotateImage", SecondsToChange, SecondsToChange);
        }

        private void RotateImage()
        {
            var imageRectTransform = gameObject.GetComponent<RectTransform>();
            
            imageRectTransform.Rotate(new Vector3( 0, 180, 0 ));
        }
    }
}

