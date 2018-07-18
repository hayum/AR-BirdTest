////By: Daniel Soto
////4dsoto@gmail.com
//using UnityEngine;
//using System.Collections;
//using LSCore;
//using LSCore.Base.Extensions;
//
//
//[ExecuteInEditMode]
//public class SimpleLookAt : MonoBehaviour {
//
//    [System.Serializable]
//    public struct WorldUp
//    {
//        [TooltipAttribute("This transform's up axis is scaled by the specified /up/ vector")]
//        public Transform transformUp;
//        [TooltipAttribute("The specified transform's up axis is scaled by this vector")]
//        public Vector3 up;
//
//        public Vector3 Up{
//            get{
//                if( !transformUp )
//                    return up;
//                Vector3 _up = transformUp.up;
//                _up.Scale( up );
//                return _up;
//            }
//        }
//    }
//
//
//    [Tooltip("If null, main camera will be used")]
//    public Transform target;
//    [Tooltip("Extra rotation")]
//    public Vector3 rotate;
//    public bool overwriteRotation;
//    [ShowIf( "overwriteRotation", 1 )]
//    public Vector3 axesToOverwrite = Vector3.zero;
//    [ShowIf( "overwriteRotation", 1 )]
//    public Vector3 rotationOverwrite = Vector3.zero;
//    [Tooltip("This will be used as the World Up axis when looking at the target")]
//    public WorldUp up;
//    [Range( 1, 60 )]
//    public int frameRate = 1;
//    public float changeTargetDuration = 1f;
//
//
//    int _period;
//    Transform _lastTarget;
//    Vector3 _keepRotation;
//
//
//	// Use this for initialization
//    void Start () { //ALLOWS TO ENABLE/DISABLED THIS COMPONENT
//       
//        if( !target && Camera.main != null )
//            target = Camera.main.transform;
//	}
//	
//	// Update is called once per frame
//	void Update () {
//	
//        if( !target || !enabled )
//            return;
//
//        #if UNITY_EDITOR
//        if( !Application.isPlaying )
//        {
//            LookAt();
//            return;
//        }
//        #endif
//
//        if( _lastTarget != target && _lastTarget != null )
//        {
//            ChangeTarget( target );
//        }
//        _period++;
//        if( _period < frameRate )
//            return;
//        
//        _period = 0;
//        _lastTarget = target;
//        LookAt();
//	}
//
//
//    public void ChangeTarget( Transform newTarget )
//    {
//        StartCoroutine( _ChangeTarget( newTarget ) );
//    }
//
//
//    void LookAt()
//    {
//        transform.rotation = Quaternion.Euler( Vector3.zero );
//        /*Vector3 lookDirection = target.position;
//        lookDirection.Scale( lookAxis );
//        lookDirection = transform.position.normalized + lookDirection.normalized;
//        Quaternion lookRotation = Quaternion.LookRotation( lookDirection, up.Up );
//        transform.rotation = lookRotation;*/
//
//        //Vector3 lookTarget = target.position - ( lookAxis * transform.position );
//        /*_keepRotation = transform.rotation.eulerAngles;
//        if( keepRotation.x <= 0f )
//        {
//            _keepRotation.x = 0f;
//        }
//        if( keepRotation.y <= 0f )
//        {
//            _keepRotation.y = 0f;
//        }
//        if( keepRotation.z <= 0f )
//        {
//            _keepRotation.z = 0f;
//        }*/
//        transform.LookAt( target, up.Up );
//        /*if( keepRotation.x > 0f )
//        {
//            transform.rotation = Quaternion.Euler( _keepRotation );
//        }
//        else if( keepRotation.y > 0f )
//        {
//            _keepRotation = transform.rotation.eulerAngles.y;
//        }
//        else if( keepRotation.z > 0f )
//        {
//            _keepRotation = transform.rotation.eulerAngles.z;
//        }*/
//        transform.Rotate( rotate );
//        if( overwriteRotation )
//        {
//            transform.RotateAxes( axesToOverwrite, rotationOverwrite );
//        }
//    }
//    IEnumerator _ChangeTarget( Transform newTarget )
//    {
//        Vector3 _target = target.position;
//        target = null;
//        float time = 0f;
//        while( time < changeTargetDuration )
//        {
//            time += Time.deltaTime;
//            transform.LookAt( Vector3.Slerp( _target, newTarget.position, time ) );
//            yield return null;
//        }
//        target = newTarget;
//    }
//}
