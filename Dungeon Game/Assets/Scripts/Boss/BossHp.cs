using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHp : MonoBehaviour
{
    public int bossHP;
    private BossMovement bm;

    private void Start()
    {
        bossHP = 100;
        bm = GetComponent<BossMovement>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.tag == "Shuriken")
        {
            bossHP -= 1;
            CheckBossHP();
        }
    }

    private void CheckBossHP()
    {
        if(bossHP % 20 == 0)
        {
            bm.ChangeBossForm();
        }
    }


}
