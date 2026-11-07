using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    private Animator _animator;

    // STEP 1 -----------------------------------------------------------------
    // First, we are going to make our Pudu walk to where the player clicked
    //      by using its NavMeshAgent Component.
    // This feature will be done in Steps 1-3.
    //
    // Instead of making the NavMeshAgent a tunable variable in the Inspector,
    //      we're going to use GetComponent to find it.
    // Add a MEMBER VARIABLE here for the NavMeshAgent Component named _agent.
    // It does NOT need to be tunable in the Inspector.

    private NavMeshAgent _agent;

    // STEP 1 -----------------------------------------------------------------


    // STEP 4 -----------------------------------------------------------------
    // Next, we are going to add a teleport ability to the player. 
    // If the player clicks the SPACE bar, they should teleport back to the
    //      location they were at before they clicked.
    //
    // We need a Vector3 to keep track of their LAST KNOWN LOCATION.
    // Add a MEMBER VARIABLE here for that location.
    // It does NOT need to be tunable in the Inspector.
    private Vector3 _lastKnownLocation;

    // STEP 4 -----------------------------------------------------------------

    private Camera _mainCamera;
    private RaycastHit _raycastHit;
    private bool _raycastSuccessful = false;
    private Ray _mouseRay;

    // STEP 2 -----------------------------------------------------------------
    // UNCOMMENT the below method and choose the right method name.
    // We're using this method to initialize a few of our member variables.
    // We only need it to run ONCE, when the game BEGINS.
    // What UNITY METHOD should we use for this?
    //
    // Once you've fixed the method signature, add a line INSIDE this method
    //      to use GetComponent to grab this GameObject's NavMeshAgent and store
    //      it in the _agent MEMBER VARIABLE.
    //
    private void Start( )
    {
        _mainCamera = Camera.main;
        _animator = GetComponent<Animator>();
        _agent = GetComponent<NavMeshAgent>();
    }
    // STEP 2 -----------------------------------------------------------------

    // ------------------------------------------------------------------------
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            _mouseRay = _mainCamera.ScreenPointToRay(Input.mousePosition);
            _raycastSuccessful = Physics.Raycast(_mouseRay, out _raycastHit);

            if (_raycastSuccessful)
            {
                Vector3 mouseHitPosition = _raycastHit.point;

                // STEP 3 -----------------------------------------------------
                // Inside this Update method, I've already written code for you
                //      that finds the location in the game world where the
                //      player clicked.
                // This location is stored in mouseHitPosition.
                // Make the NavMeshAgent move to this position.
                //
                // Feature 2 should work after this step.
                _agent.SetDestination(mouseHitPosition);

                // STEP 3 -----------------------------------------------------

                // STEP 5 -----------------------------------------------------
                // Because this is where our code tells the NavMeshAgent to
                //      walk somewhere new, we should also store our CURRENT
                //      POSITION in our LAST KNOWN LOCATION MEMBER VARIABLE
                //      here.
                // 
                // You'll need this GameObject's Transform's position.
                // See an example in the documentation: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Transform-position.html
                _lastKnownLocation = transform.position;

                // STEP 5 -----------------------------------------------------
            }
        }

        // STEP 6 -------------------------------------------------------------
        // Finally, we want to TELEPORT the player to the LAST KNOWN LOCATION
        //      if the player presses the space key.
        // First, detect IF the player PRESSED the SPACE KEY.
        //      If they did, you'll need to call a new METHOD on their 
        //      NAV MESH AGENT Component.
        // I have not told you about this method >:)
        // It's NOT "Move".
        // You'll need to read the NavMeshAgent documentation and choose
        //      the correct one: https://docs.unity3d.com/6000.0/Documentation/ScriptReference/AI.NavMeshAgent.html
        // Feature 3 should work after this.
        if(Input.GetKeyDown(KeyCode.Space))
        {
            _agent.Warp(_lastKnownLocation);
        }

        // STEP 6 -------------------------------------------------------------

        // Uncomment the below line to fix the Pudu's animation if you want.
        _animator.SetBool("isMoving", _agent.velocity.magnitude > 0.0f);
    }
    
    // ------------------------------------------------------------------------
    private void OnDrawGizmos ()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(_mouseRay);

        Gizmos.color = Color.green;
        Gizmos.DrawSphere(_raycastHit.point, 0.2f);
    }
}
