using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroInfo : MonoBehaviour
{
    public static int money;
    public static int level;
    public static HP hp;
    public static int atk;
    

    public class HP
    {
        int nowhp;
        int maxhp;

        public HP(int now, int max)
        {
            nowhp = now;
            maxhp = max;
        }
    }

    HeroInfo(int money, int level, int nowhp, int maxhp, int atk)
    {
        HeroInfo.money = money;
        HeroInfo.level = level;
        hp = new HP(nowhp, maxhp);
        HeroInfo.money = money;
    }

    // Start is called before the first frame update
    void Start()
    {
        HeroInfo heroinfo = new HeroInfo(1000, 1, 100, 100, 1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
