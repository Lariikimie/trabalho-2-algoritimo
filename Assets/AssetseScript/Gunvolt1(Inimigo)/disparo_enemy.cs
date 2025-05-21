using UnityEngine;

public class disparo_enemy : MonoBehaviour
{
    [SerializeField] private float speed = 5.0f;
    Animator ani;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        Destroy(gameObject, 5f);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            
            StatusPlayer status = other.GetComponent<StatusPlayer>();
            status.vida -= Random.Range(1,2);            
            status.AlterarVida(status.vida);
            Animator ani = other.GetComponent<Animator>();
            Player player = other.GetComponent<Player>();
            
            if (ani != null)
            {
                ani.SetTrigger("dano");
                player.StartCoroutine(player.efeitoDano());
            }
            if (status.vida <=0)
            {
                status.morreu();
            }
            Destroy(gameObject);
        }
    }
    
}
