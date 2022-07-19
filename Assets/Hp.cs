using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Hp : MonoBehaviour
{
    [SerializeField]
    private Image hpbar;

    private float maxHp = 100;
    public float curHp = 100;
    float imsi = 0.00001f;
    private SpriteRenderer spriteRenderer;
    public float DamagedTime;

    void Start()
    {
        hpbar.fillAmount = curHp / maxHp;
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            curHp -= 10;
        }
        hpbar.fillAmount = curHp / maxHp;
        HandheHp();
    }
    private void HandheHp()
    {
        curHp -= imsi;
    }

    public void TakeDamage(float damage)
    {
        curHp -= damage;
        OnDamaged();
    }
    void OnDamaged()
    {
        gameObject.layer = 9;
        spriteRenderer.color = new Color(1, 0, 0, 0.4f);

        Invoke("OffDamaged", DamagedTime);
    }

    void OffDamaged()
    {
        spriteRenderer.color = new Color(1, 1, 1, 1);
        gameObject.layer = 8;
    }
}
