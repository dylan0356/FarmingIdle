using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaminaBar : MonoBehaviour
{
    public Slider staminaBar;

    public float maxStamina = 100;
    public float currentStamina;

    public static StaminaBar instance;

    private WaitForSeconds regenTick = new WaitForSeconds(0.1f);
    private Coroutine regen;


    private void Awake() {
        instance = this;
    }


    // Start is called before the first frame update
    void Start()
    {
        currentStamina = maxStamina;
        staminaBar.maxValue = maxStamina;
        staminaBar.value = maxStamina;
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UseStamina(float staminaUsed)
    {
        if(currentStamina - staminaUsed >= 0)
        {
            currentStamina -= staminaUsed;
            staminaBar.value = currentStamina;

            if(regen != null) {
                StopCoroutine(regen);
            }

            //Start regen stamina
            regen = StartCoroutine(RegenStaming());


        }
    }

    private IEnumerator RegenStaming() {
        yield return new WaitForSeconds(1);

        while(currentStamina < maxStamina) {
            currentStamina += maxStamina / 100;
            staminaBar.value = currentStamina;
            yield return regenTick;
        }
        regen = null;
    }




    


}
