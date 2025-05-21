using UnityEngine;
using System.Collections;
public class Player : MonoBehaviour
{   //velocidademegaman
    public float velocidade = 5.0f;
    //velocidade do disparo
    [SerializeField] private GameObject laser;
    //pulo
    public Rigidbody2D rb;
    private float ForcaDePulo = 5;
    private float EscalaGravidade = 1;
    private float forcaDeQueda = 1;
    private bool EstaNoChao;
    private bool possoAtirar = true;
    // animações
    Animator ani;
    private bool DanoRecebido= false;
    //disparo carregado
    //private float tempoCarregando = 0f;
    //private float tempoParaCargaMax = 1.5f;
    //private bool carregandoTiro = false;
    //private bool tiroCarregado = false;
    //public bool EstarParado;
    
    void Start()
    {
        
        
        rb = GetComponent<Rigidbody2D>();
        ani = GetComponent<Animator>();

    }

    // Update is called once per frame
    void Update()
    {






        tiro();
        movimento();
        pular();

    }
    public void tiro()
    {
        /*/
         * if(EstarParado == true)
        {
           
        }
        \*/
        if (Input.GetMouseButton(0) && DanoRecebido == false)
        {

            ani.SetBool("atirando", true);
            transform.Find("particulas").gameObject.SetActive(true);
        }
        else
        {
            ani.SetBool("atirando", false);
            transform.Find("particulas").gameObject.SetActive(false);
        }
        if (Input.GetMouseButtonUp(0) && possoAtirar && DanoRecebido == false)
        {
            GameObject projetil;
            // carrega tempo
            if (transform.localScale.x > 0)
            {
                projetil = Instantiate(laser, transform.position, Quaternion.identity);
                projetil.GetComponent<Laser>().esquerda = false;

            }
            else if (transform.localScale.x < 0)
            {
                projetil = Instantiate(laser, transform.position, Quaternion.identity);
                projetil.GetComponent<Laser>().esquerda = true;
            }
            StartCoroutine(tempo());
        }
        /*/else if (EstarParado == false && Input.GetMouseButtonUp(0))
        {
            //atirar e andar
        }
        \*/
    }
    public IEnumerator efeitoDano()
    {
        
        DanoRecebido = true;
        yield return new WaitForSeconds(1.0f);
        DanoRecebido = false;

    }
    IEnumerator tempo()
    {
        yield return new WaitForSeconds(0.1f);
        possoAtirar = true;
    }
    void movimento()
    {
       
       
       
        if (DanoRecebido== true)
        {
            ani.SetFloat("correndo", 0); 
            return; 
        }
        float hi = Input.GetAxisRaw("Horizontal");
        transform.Translate(Vector3.right * Time.deltaTime * velocidade * hi);

        
        //conferindo se esta parado
        /*/
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.D))
        {
           EstarParado = false;
            Debug.Log("aaaaaa");
        }
       
        \*/

        // controle AD
        if (hi > 0)
        {
            
            transform.localScale = new Vector3(1f,1f,1f);
            

        }
        else if(hi<0)
        {
            transform.localScale = new Vector3(-1f, 1f, 1f);
            

        }
        ani.SetFloat("correndo", Mathf.Abs(hi));
    }
    void pular()
    {

        //pular
        if (Input.GetKeyDown(KeyCode.Space) && EstaNoChao && DanoRecebido == false)
        {
            rb.AddForce(Vector2.up * ForcaDePulo, ForceMode2D.Impulse);
            EstaNoChao = false;
            
            ani.SetTrigger("pulando"); //animação pular

        }
      
        if (rb.linearVelocity.y > 0)
        {
            rb.gravityScale = EscalaGravidade;
           
        }
        else if (rb.linearVelocity.y < 0)
        {
            rb.gravityScale = forcaDeQueda;
            
        }
        
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Plataforma") )
        {
            EstaNoChao = true;
            
            
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataforma") )
        {
            EstaNoChao = false;


        }
    } //nao dar pulo infinito



}
