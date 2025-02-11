using UnityEngine;

public class Bow : MonoBehaviour
{

    [SerializeField] private Camera cam;

    [SerializeField] private GameObject arrow;

    Vector3 targetPoint;
    public Transform attackPoint;

    public AnimationCurve shootForceCurve;
    public float maxShootForce;
    float shootForce;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        ChargeBow();
        EvaluateShootForce();
    }

    void EvaluateShootForce()
    {
        shootForce = shootForceCurve.Evaluate(chargeAmmount) * maxShootForce;
    }


    float chargeAmmount = 0;
    void ChargeBow()
    {
        if (Input.GetMouseButton(1))
        {
            chargeAmmount += Time.deltaTime;
            chargeAmmount = Mathf.Clamp01(chargeAmmount);
            Debug.Log(chargeAmmount);
        }
        if (Input.GetMouseButtonUp(1))
        {
            FireArrow();
            Debug.Log(chargeAmmount);
            chargeAmmount = 0;
        }
    }

    void FireArrow()
    {
        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if (Physics.Raycast(ray, out hit))
        {
            targetPoint = hit.point;
            Debug.Log("hitFound");
        } else 
        {
            targetPoint = ray.GetPoint(75);
            Debug.Log("hitNotFound");
        }
        Vector3 direction = targetPoint - attackPoint.position;

        GameObject currentArrow = Instantiate(this.arrow, attackPoint.position, Quaternion.identity);
        Debug.Log("arrowInstantiated");
        currentArrow.transform.LookAt(targetPoint);

        currentArrow.GetComponent<Rigidbody>().AddForce(direction.normalized * shootForce, ForceMode.Impulse);
    }
}
