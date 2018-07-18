using UnityEngine;
using System.Collections;


[RequireComponent( typeof( MeshRenderer ) )]
public class RendererAnimation : MonoBehaviour {

    public Texture2D[] frames;
    public float minTime = 0.18f;
    public float maxTime = 0.2f;


    Material _material;
    float _time;
    float _lastSeed = 10f;
    int _currentFrame;
    int _CurrentFrame {
        get{
            return _currentFrame;
        }
        set{
            if( value >= frames.Length )
            {
                _currentFrame = 0;
            }
            else if( value < 0 )
            {
                _currentFrame = frames.Length - 1;
            }
            else _currentFrame = value;
        }
    }


	// Use this for initialization
	void Start () {
	
        Seed();
        _material = GetComponent<MeshRenderer>().material;
	}
	
	// Update is called once per frame
	void Update () {
	
        _time += Time.deltaTime;
        if( _time >= _lastSeed )
        {
            _time = 0f;//reset
            Seed();
            _CurrentFrame++;
            _material.SetTexture( "_MainTex", frames[ _CurrentFrame ] );
        }
	}

    void Seed()
    {
        _lastSeed = Random.Range( minTime, maxTime );
    }
}
