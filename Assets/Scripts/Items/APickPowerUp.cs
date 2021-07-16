using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class APickPowerUp : AbstractPickItem
{
    int id;

    private void Start()
    {
        id = itemData.id;
    }

    void TriggerPowerUpEffect()
    {
        switch (id)
        {
            case 25:
                print("Why hello there good sir! Let me teach you about Trigonometry!");
                break;
            case 24:
                print("Hello and good day!");
                break;
            case 23:
                print("Whadya want?");
                break;
            case 22:
                print("Grog SMASH!");
                break;
            case 21:
                print("Ulg, glib, Pblblblblb");
                break;
            default:
                print("Incorrect intelligence level." + id + itemData.itemName);
                break;
        }
    }


    public override void DoSomething()
    {
        print("POWER UP!!");
        // TriggerPowerUpEffect();
    }

    // public abstract void AddHealth();

}
