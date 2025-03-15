using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _speed = 5f, _frameRate = 6f;
    [SerializeField] private bool _canInteract = true;

    [SerializeField] private Sprite[] _idle;
    [SerializeField] private Sprite[] _walkUp;
    [SerializeField] private Sprite[] _walkDown;
    [SerializeField] private Sprite[] _walkHorizontal;
    
    private Rigidbody2D _rb;
    private SpriteRenderer _sr;
    private Animator _animator;

    private int _idx;
    private float _timer;

    private float _soundTimer;
    private AudioSource _footstep;

    // private string current_scene;

    // public GameObject InfoBankObj;
    
    private int DirectionToIndex(Vector2 dir)
    {
        _idx = dir.x switch
        {
            > 0 or < 0 => 1,
            _ => dir.y switch
            {
                > 0 => 0,
                < 0 => 2,
                _ => _idx
            }
        };

        return _idx;
    }
    
    private Sprite[] GetSpriteArray(Vector2 dir)
    {
        return dir switch
        {
            {x: > 0} => _walkHorizontal,
            {x: < 0} => _walkHorizontal,
            {y: > 0} => _walkUp,
            {y: < 0} => _walkDown,
            _ => _idle
        };
    }
    
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _sr = GetComponent<SpriteRenderer>();
        _footstep = GetComponentInChildren<AudioSource>();
        _animator = GetComponent<Animator>();

        if(PlayerPrefs.HasKey("x")) {
            gameObject.transform.position += new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), 0);
        }

        // current_scene = SceneManager.GetActiveScene().name;

        // Debug.Log("Current scene: " + current_scene);

    }

    private void FixedUpdate()
    {
        if (!_canInteract)
        {
            //_sr.sprite = _idle[_idx]; //UNCOMMENT LATER!! once animation is here :)
            _rb.linearVelocity = new Vector2(0, 0);
            return;
        }

        
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        
        var dir = new Vector2(horizontal, vertical);

        var directionAngle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        _animator.SetBool("IsWalking", dir != Vector2.zero);
        _animator.SetFloat("DirectionAngle", directionAngle);
        var spriteIndex = DirectionToIndex(dir);
        //if (dir != Vector2.zero)
        //{
        //    var time = (int)(_timer % 4);
        //    _sr.sprite = GetSpriteArray(dir)[time];
        //    _sr.flipX = dir.x == 0 ? _sr.flipX : dir.x > 0;
        //}
        //else
        //{
        //    _sr.sprite = _idle[spriteIndex];
        //}
        
        _rb.linearVelocity = dir * _speed;
        _timer += Time.deltaTime * _frameRate;

        
        if ((int) _soundTimer % 2 == 0) {
            //_footstep.Play(); //it's not working :(
        }

        PlayerPrefs.SetFloat("x", this.gameObject.transform.position.x);
        PlayerPrefs.SetFloat("y", this.gameObject.transform.position.y);

    }

    // private void Update()
    // {
    //     if (Input.GetKeyUp(KeyCode.Space)) {
    //         Debug.Log("Activating scene change");
    //         if (current_scene == "Present") {
    //             SceneManager.LoadScene("Not Present");
    //         }
    //         if (current_scene == "Not Present") {
    //             SceneManager.LoadScene("Present");
    //         }
    //     }
    // }

    public bool GetCanInteract() 
    {
        return _canInteract;
    }

    public void SetCanInteract(bool a) 
    {
        _canInteract = a;
    }
}
