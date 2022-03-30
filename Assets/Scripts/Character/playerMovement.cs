using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    //SerializeField é um bagui do Unity que meio q deixa a variavel publica só que sendo privada ao mesmo tempo,
    //serve mais para linkar objetos nos componentes
    [SerializeField] private float speedMeter = 5.0f;
    //Componente
    [SerializeField] private Rigidbody2D rb;
    //Vector2 é uma classe que, por alto, tem dois valores dentro dela, por isso o movement.x e movement.y, no Unity3D é usado o Vector3 para o z
    private Vector2 movement;
    //Componente
    [SerializeField] private Animator animator;
    private float lastUp;

    void Start()
    {
        rb.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {

        //GetAxis retorna um valor de -1 a 1 pela tecla ou botão pressionado, o Raw ali acho q joga o valor sempre pro extremo(1 ou -1)
        //Para ver mais, cheque a documentação de Input na Unity
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.E))
        {
            Interact();
        }
        //if para fazer a animação ficar para cima quando o ultimo movimento foi ter ido pra cima,
        //e ficar pra baixo quando o ultimo movimento é ter ido pra baixo
        if (movement.y > 0.01)
        {
            lastUp = 0.333f;
        }
        if (movement.y < -0.01)
        {
            lastUp = 0;
        }
        if (movement.x > 0.01)
        {
            lastUp = 1f;
        }
        if (movement.x < -0.01)
        {
            lastUp = 0.666f;
        }

        //Processo das animaçõse
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetFloat("Olhando", lastUp);
    }

    //FixedUpdate é chamado em uma taxa fixa de vezes(acho que 15 por segundo sla), parecido com o Update q é a todo frame.
    void FixedUpdate() 
    {
        if (movement.x != 0 && movement.y != 0) // Check for diagonal movement
        {
            // limite de movimento diagonal
            movement *= 0.7f;
        }
        rb.MovePosition(rb.position + movement * speedMeter * Time.fixedDeltaTime);
    }

    private void Interact()
    {

        float dirOlhar = animator.GetFloat("Olhando");        
        Vector2 interagePos = new Vector3(transform.position.x, transform.position.y - 2);
        
        if (dirOlhar == 0.333f)
        {
            interagePos = new Vector3(transform.position.x, transform.position.y+1f);
        }
        else if (dirOlhar == 0.666f)
        {
            interagePos = new Vector3(transform.position.x - 1f, transform.position.y-0.7f);
        }
        else if (dirOlhar == 0.000f)
        {
            interagePos = new Vector3(transform.position.x, transform.position.y - 2f);
        }
        else if (dirOlhar == 1.000f)
        {
            interagePos = new Vector3(transform.position.x + 1f, transform.position.y-0.7f);
        }
        LayerMask layerInterage = LayerMask.GetMask("Interage");
        Debug.DrawLine(transform.position, interagePos, Color.green, 1f);
        Collider2D hit = Physics2D.OverlapCircle(interagePos, 0.1f, layerInterage);
        if(hit != null)
        {
            hit.GetComponent<IInteragivel>()?.Interage();
        }
    }

}
