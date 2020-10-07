using UnityEngine;

namespace samalonso.zombieasteroids.Behaviors
{
    public class EngineFlareBehavior : MonoBehaviour
    {
        public GameObject engineFlarePrefab;

        private RectTransform flareImage;

        private void Start()
        {
            flareImage = engineFlarePrefab.GetComponent<RectTransform>();
        }

        public void ShowFlare()
        {
            LeanTween.alpha(flareImage, 1.0f, 0.2f);
        }
        
        public void HideFlare()
        {
            LeanTween.alpha(flareImage, 0f, 0.2f);
        }
    }
}


