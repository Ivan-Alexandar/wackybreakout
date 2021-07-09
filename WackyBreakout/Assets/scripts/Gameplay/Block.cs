using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// A block
/// </summary>
public class Block : MonoBehaviour
{
    protected int points;
	PointsAdded pointsAdded;
	/// <summary>
	/// Use this for initialization
	/// </summary>
	virtual protected void Start()
	{
		pointsAdded = new PointsAdded();
		EventManager.AddPointsAddedInvoker(this);
		
	}
	
	/// <summary>
	/// Update is called once per frame
	/// </summary>
	void Update()
	{
		
	}

    /// <summary>
    /// Destroys the block on collision with a ball
    /// </summary>
    /// <param name="coll">Coll.</param>
    virtual protected void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Ball"))
        {
			pointsAdded.Invoke(points);
            Destroy(gameObject);
        }
    }
	public void AddPointsAddedListener(UnityAction<int> listener)
    {
		pointsAdded.AddListener(listener);
    }
}
