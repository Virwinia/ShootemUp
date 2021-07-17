using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 A FUTURO, SI ESTE CÓDIGO SE VA DE LAS MANOS, QUIZÁS PODRÍA SEGUIR HACIENDO HERENCIA....
*/

public class APickPowerUp : AbstractPickItem
{
    int id;
    PlayerDataHandler playerData;
    bool isPicked;

    private void Start()
    {
        id = itemData.id;
    }

    void TriggerPowerUpEffect()
    {
        switch (id)
        {
            case 23:
                print("Whadya want?");
                break;
            case 22:
                print("Grog SMASH!");
                break;
            case 21:
                PlayerDataHandler.playerDataInstance.ShieldActivation(true);   // Get Shield
                break;
            default:
                print("Incorrect intelligence level." + id + itemData.itemName);
                break;
        }
    }


    public override void DoSomething()
    {
        TriggerPowerUpEffect();
    }






}
