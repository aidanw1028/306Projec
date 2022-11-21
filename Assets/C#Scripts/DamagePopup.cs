using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopup : MonoBehaviour
{
    private const float DISAPPEAR_TIMER_MAX = 1.0f;

    private TextMeshPro textMesh;
    private float lifetime;
    private Color textColor;
    private Vector3 moveVector;


    public static DamagePopup Create(Vector3 position, int damageAmount, Transform pop, bool isCritical)
    {
        Transform damagePopupTransform = Instantiate(pop, position, Quaternion.identity);
        DamagePopup damagePopup = damagePopupTransform.gameObject.GetComponent<DamagePopup>();
        damagePopup.Setup(damageAmount, isCritical);

        return damagePopup;
    }

    private void Awake()
    {
        textMesh = transform.GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        transform.position += moveVector * Time.deltaTime;
        moveVector -= moveVector * 4.0f * Time.deltaTime;

        if (lifetime > DISAPPEAR_TIMER_MAX * 0.5f)
        {
            float increaseScaleAmount = 1.0f;
            transform.localScale += Vector3.one * increaseScaleAmount * Time.deltaTime;
        } else
        {
            float decreaseScaleAmount = 1.0f;
            transform.localScale -= Vector3.one * decreaseScaleAmount * Time.deltaTime;
        }
        lifetime -= Time.deltaTime;
        if (lifetime < 0)
        {
            float disappearSpeed = 3.0f;
            textColor.a -= disappearSpeed * Time.deltaTime;
            textMesh.color = textColor;

            if (textColor.a < 0)
            {
                Destroy(gameObject);
            }
        }
    }

    public void Setup(int damageAmount, bool isCritical)
    {
        textMesh.SetText(damageAmount.ToString());
        if (!isCritical)
        {
            textMesh.fontSize = 4;
            textColor = new Color32(255, 200, 0, 255);

        } else
        {
            textMesh.fontSize = 6;
            textColor = new Color32(255, 50, 0, 255);
        }

        textMesh.color = textColor;
        lifetime = DISAPPEAR_TIMER_MAX;

        moveVector = new Vector3(1, 1) * 5.0f;
    }
    
}
