using UnityEngine;

public class SpawnIngredientController : MonoBehaviour
{
    
    [SerializeField] private MeshCollider _plane;  //������� ���� ��� ��������� ��������
    [SerializeField] private int _maxCountGeneratedIngredients; //������������ ���������� ��������������� ������������
    [SerializeField] private float _cooldownTimeForRespawnIngredient = 5f; //����� ����� ���������� ��������
    [SerializeField] private bool _isReadyForSpawn = true;
    [SerializeField] private Vector3 _spawnPosition;
    [SerializeField] private Vector3 _sizeCollider = new Vector3(1f, 1f, 1f);
    [SerializeField] private Transform _parentForGeneratedIngredient; //�������� ��� �������� ��������������� ������������

    private Collider[] _colliders;      //������ ����������� ����������� ��� ��������� �������
    private int _currentGeneratedIngredients;

    private void Start()
    {
        _currentGeneratedIngredients = 0;
    }

    private void OnEnable()
    {
        EventController.onTimerOver += StartTimer;
    }
    private void OnDisable()
    {
        EventController.onTimerOver -= StartTimer;
    }   

    void Update()
    {
        if (_isReadyForSpawn && _currentGeneratedIngredients < _maxCountGeneratedIngredients)
        {
            _isReadyForSpawn = false;
            EventController.onTimerStarted?.Invoke(_cooldownTimeForRespawnIngredient);            
            GenerateIngredient();
        }
        else return;
    }

    private void StartTimer()
    {
        _isReadyForSpawn = true;
    }

    private void GenerateIngredient()
    {
        GenerateSpawnPosition();
        if (CheckSpanwPosition(_spawnPosition))
        {
            GameObject generateIngedient =  EventController.onGeneratedIngredient?.Invoke();
            Instantiate(generateIngedient, _spawnPosition, Quaternion.identity, _parentForGeneratedIngredient);
            _currentGeneratedIngredients++;
        }
        else
        {
            GenerateIngredient();
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
         float posX = Random.Range(_plane.transform.position.x - Random.Range(0, _plane.bounds.extents.x), 
            _plane.transform.position.x + Random.Range(0, _plane.bounds.extents.x));
        float posZ = Random.Range(_plane.transform.position.z - Random.Range(0, _plane.bounds.extents.z),
            _plane.transform.position.z + Random.Range(0, _plane.bounds.extents.z));
        _spawnPosition = new Vector3(posX, 1.5f, posZ);

        return _spawnPosition;
    }

    private bool CheckSpanwPosition(Vector3 spanwPos)
    {
        _colliders = Physics.OverlapBox(spanwPos, _sizeCollider);
        if (_colliders.Length > 0) return false;
        else return true;
    }
}
