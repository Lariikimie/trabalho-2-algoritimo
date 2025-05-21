using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour
{   
    //disparo
    public GameObject[] disparos;
    public int disparoAleatorio;
    //animaçao disparo
    
    Animator Anim;
    //brilho
    SpriteRenderer sr;
    Color CorOriginal;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Anim = GetComponent<Animator>();
        StartCoroutine(Sorteio());
        sr = GetComponent<SpriteRenderer>();
        CorOriginal = sr.color;

    }
   
    IEnumerator Sorteio()
    {
        
       while(true)// while= if mas se ele for verdadeiro tudo dentro é executado
       {
            if(Anim.GetCurrentAnimatorStateInfo(0).IsName("idle_enemy"))
            {
                disparoAleatorio = Random.Range(0, disparos.Length);


                if (disparoAleatorio == 0)
                {

                    Anim.Play("shot");
                    yield return new WaitForSeconds(2.0f);


                    Instantiate(disparos[0], transform.position +new Vector3(-0.73f, -0.237f), Quaternion.identity);

                }
                else if (disparoAleatorio == 1)
                {
                    Anim.Play("shot_energy");
                    yield return new WaitForSeconds(2.0f);
                    
                    Instantiate(disparos[1],transform.position + new Vector3(-0.73f, -0.825f), Quaternion.identity);
                }

                yield return new WaitForSeconds(2.0f);

            }
            else
            {
                // animaçao ta em looping 
                yield return null;
            }


        }

    }
    public void DanoRecebido()
    {
        StartCoroutine(brilhar());
    }
    IEnumerator brilhar()
    {
        sr.color = Color.red;
        yield return new WaitForSeconds(0.1f);
        sr.color = CorOriginal;
    }
}
