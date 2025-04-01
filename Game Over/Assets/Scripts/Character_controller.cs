using UnityEngine;

public class Character_controller : MonoBehaviour
{
    public float velocidad;
    public float fuerzaSalto;
    public int saltosMaximos;
    public LayerMask capaSuelo;

    private new Rigidbody2D rigidbody;
    private BoxCollider2D boxColider;
    private bool mirandoDerecha = true;
    private int saltosRestantes;
    private Animator animator;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        boxColider = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcesarMovimiento();
        ProcesarSalto();
    }

    bool EstaEnSuelo() 
    {
       RaycastHit2D raycastHit = Physics2D.BoxCast(boxColider.bounds.center, new Vector2(boxColider.bounds.size.x, boxColider.bounds.size.y), 0f, Vector2.down, 0.2f, capaSuelo);
        return raycastHit.collider != null;
    }

    void ProcesarSalto() 
    {
        if (EstaEnSuelo())
        {
            saltosRestantes = saltosMaximos;
        }

        if (Input.GetKeyDown(KeyCode.Space) && saltosRestantes > 0) 
        {
            saltosRestantes = saltosRestantes - 1;
            rigidbody.linearVelocity = new Vector2(rigidbody.linearVelocity.x, 0f);
            rigidbody.AddForce(Vector2.up*fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    void ProcesarMovimiento()

    {
        // Logica de Movimiento.
        float inputMovimiento = Input.GetAxis("Horizontal");

        if (inputMovimiento != 0f) 
        {
            animator.SetBool("IsRunning", true);
        }

        else 
        {
            animator.SetBool("IsRunning", false);
        }

        rigidbody.linearVelocity = new Vector2 (inputMovimiento * velocidad, rigidbody.linearVelocity.y);

        GestionarOrientacion(inputMovimiento);
    }

    void GestionarOrientacion(float inputMovimiento) 
    {
        // Si se cumple condicion
        if ((mirandoDerecha == true && inputMovimiento < 0) || (mirandoDerecha == false && inputMovimiento > 0)) 
        {
            //Ejecutar codigo de volteado
            mirandoDerecha = !mirandoDerecha;
            transform.localScale = new Vector2(-transform.localScale.x, transform.localScale.y);
        }

    }
}
