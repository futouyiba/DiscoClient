using UnityEngine.SceneManagement;
using UnityEngine;


namespace DistantLands
{
    [AddComponentMenu("Distant Lands/Tailor/UI/Scene Loading")]
    public class SceneLoading : MonoBehaviour
    {

        // Start is called before the first frame update
        public void Load(int scene)
        {

            SceneManager.LoadScene(scene);

        }
    }
}