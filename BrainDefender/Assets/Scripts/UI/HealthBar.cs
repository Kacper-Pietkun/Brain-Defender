using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private float reduceHealtBarTime;
    private EnemyActions enemyActions;
    private Image healtBarImage;

    private void Awake()
    {
        healtBarImage = GetComponent<Image>();
        enemyActions = transform.parent.parent.GetComponent<EnemyActions>();
        enemyActions.OnTakenDamage += TakenDamage;
    }

    private void TakenDamage(float damagePercent, int actualHealtPoints)
    {
        StartCoroutine(ReduceHealtBar(healtBarImage.fillAmount, healtBarImage.fillAmount - damagePercent));
    }

    private IEnumerator ReduceHealtBar(float startValue, float endValue)
    {
        float passedTime = 0;
        while(passedTime < reduceHealtBarTime)
        {
            passedTime += Time.deltaTime;
            healtBarImage.fillAmount = Mathf.Lerp(startValue, endValue, passedTime / reduceHealtBarTime);
            TryChangeHealtBarColor();
            yield return new WaitForEndOfFrame();
        }
        healtBarImage.fillAmount = endValue;
        if (endValue <= 0) 
            Destroy(gameObject.transform.parent.gameObject);
    }

    private void TryChangeHealtBarColor()
    {
        if (healtBarImage.fillAmount <= 0.2f)
            healtBarImage.color = Color.red;
        else if (healtBarImage.fillAmount <= 0.5f)
            healtBarImage.color = Color.yellow;
        else if (healtBarImage.fillAmount <= 1f) // In case enemy was healed (to be implemented)
            healtBarImage.color = Color.green;
    }

}
