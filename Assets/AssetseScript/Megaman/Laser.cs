using UnityEngine;

public class Laser : MonoBehaviour
{

    private float velocidade = 25;
    public bool esquerda = true ;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       

        if(esquerda == false )
        {
            
            transform.Translate(Vector2.right * velocidade * Time.deltaTime);
            

        }

        else if(esquerda == true )
        {
            transform.Translate(Vector2.left * velocidade * Time.deltaTime);
        }
        Destroy(gameObject, 1f);
        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("enemy"))
        {
            other.GetComponent<Enemy>().DanoRecebido();
            StatusEnemy status = other.GetComponent<StatusEnemy>();
            status.vida -= 1;
            if(status.vida <=0)
            {
                status.morreu();
            }
            Destroy(gameObject);

        }
    }
}
