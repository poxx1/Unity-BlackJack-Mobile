using UnityEngine;
public class Card : MonoBehaviour
{
    public int Number { get; set; }
    public int Symbol { get; set; }
    
    public Sprite SpriteCard { get; set; }
    private Sprite _spriteCardBack;

    // For MoveTo
    private bool _isMoving;
    private Vector3 _startPosition, _targetPosition;
    private float _timeToReachTarget;
    private float _interpolationMoveTime;

    // For Flip
    private bool _isFlipping;
    private Sprite _newSpriteAfterFlip;
    private Vector3 _startScale, _targetScale;
    private float _timeToReachScale;
    private float _interpolationScaleTime;

    private SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Start()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        // spriteCardBack = _spriteRenderer.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        if (_isMoving)
        {
            _interpolationMoveTime += Time.deltaTime / _timeToReachTarget;
            if (_interpolationMoveTime >= 1f)
            {
                _isMoving = false;
                transform.position = _targetPosition;
            }
            else
            {
                transform.position = Vector3.Lerp(_startPosition, _targetPosition, _interpolationMoveTime);
            }
        }

        if (_isFlipping)
        {
            _interpolationScaleTime += Time.deltaTime / _timeToReachScale;
            if (_interpolationScaleTime >= 1f)
            {
                _isFlipping = false;
                transform.localScale = _targetScale;
                _spriteRenderer.sprite = _newSpriteAfterFlip;
                if (transform.localScale.x == 0f)
                {
                    Flip();
                }
            }
            else
            {
                transform.localScale = Vector3.Lerp(_startScale, _targetScale, _interpolationScaleTime);
            }
        }
    }

    public void MoveTo(Vector3 destination, float time = 0.3f)
    {
        _isMoving = true;
        transform.position = new Vector3(transform.position.x, transform.position.y, destination.z);
        _interpolationMoveTime = 0;
        _startPosition = transform.position;
        _timeToReachTarget = time;
        _targetPosition = destination;
    }

    public void Flip(Sprite newSprite = null, float time = 0.2f)
    {
        bool unflip = transform.localScale.x == 0f;
        float prevScaleX = _startScale.x;
        
        _isFlipping = true;
        _newSpriteAfterFlip = newSprite == null ? SpriteCard : newSprite;
        _startScale = transform.localScale;
        _interpolationScaleTime = 0f;
        _timeToReachScale = time;
        _targetScale = new Vector3(unflip ? prevScaleX : 0f, _startScale.y, _startScale.z);
    }

    public override string ToString()
    {
        return $"Num: {Number} - Sym: {Symbol}";
    }
}