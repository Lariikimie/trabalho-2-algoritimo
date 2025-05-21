using UnityEngine;
using UnityEngine.SceneManagement;

public class StatusEnemy : MonoBehaviour
{
    [SerializeField] private string nomeLevel;
    public float vida = 10;
    

    // Update is called once per frame
    public void morreu()
    {
        
        Destroy(gameObject);
        SceneManager.LoadScene(nomeLevel);

    }
}
