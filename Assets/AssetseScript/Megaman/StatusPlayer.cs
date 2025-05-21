using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StatusPlayer : MonoBehaviour
{
    [SerializeField] private string nomeLevel;
    public Slider slider;
    public GameObject BarraVida;
    public float vida = 10;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            Application.Quit();
        }
    }
    public void AlterarVida(float vidaSlider)
    {

        slider.value = vidaSlider;

    }
    public void morreu()
    {
        Destroy(gameObject);
        SceneManager.LoadScene(nomeLevel);

    }
}
