using UnityEngine;
using UnityEngine.SceneManagement;

namespace UI
{
    public class Buttons : MonoBehaviour
    {
        public void Play()
        {
            SceneManager.LoadScene(1);
        }

        public void Next()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    
    }
}
