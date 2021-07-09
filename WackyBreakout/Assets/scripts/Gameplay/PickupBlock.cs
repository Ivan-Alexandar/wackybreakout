using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A pickup block
/// </summary>
public class PickupBlock : Block
{
    [SerializeField]
    Sprite freezerSprite;
    [SerializeField]
    Sprite speedupSprite;

    FreezerEffectActivated freezerEventActivated;
    SpeedUpEffectActivated speedUpEffectActivated;



    float speedUpFactor;
    float effectDuration;
    PickupEffect effect;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    override protected void Start()
    {
        // set points
        points = ConfigurationUtils.PickupBlockPoints;
        base.Start();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {

    }

    protected override void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
            if (effect == PickupEffect.Freezer)
            {
                freezerEventActivated.Invoke(effectDuration);
            }
            else if (effect == PickupEffect.Speedup)
            {
                speedUpEffectActivated.Invoke(effectDuration, speedUpFactor);
            }
            base.OnCollisionEnter2D(coll);
        }



    }

    /// <summary>
    /// Sets the effect for the pickup
    /// </summary>
    /// <value>pickup effect</value>
    public PickupEffect Effect
    {
        set
        {
            effect = value;

            // set sprite
            SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
            if (effect == PickupEffect.Freezer)
            {

                spriteRenderer.sprite = freezerSprite;
                effectDuration = ConfigurationUtils.FreezerDuration;
                freezerEventActivated = new FreezerEffectActivated();
                EventManager.AddFreezerEffectInvoker(this);


            }
            else
            {
                spriteRenderer.sprite = speedupSprite;
                effectDuration = ConfigurationUtils.SpeedUpDuration;
                speedUpFactor = ConfigurationUtils.SpeedUpEffect;
                speedUpEffectActivated = new SpeedUpEffectActivated();
                EventManager.AddSpeedUpEffectInvoker(this);

            }
        }
    }
    ///<summary>
    /// Adds a listener for the FreezerEffectActivated event
    /// </summary>
    public void AddFreezerEffectListener(UnityAction<float> listener)
    {
        freezerEventActivated.AddListener(listener);
    }
    public void AddSpeedUpEffectListener(UnityAction<float, float> listener)
    {
        speedUpEffectActivated.AddListener(listener);
    }

}
