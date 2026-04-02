using UnityEngine;

public class LevelManager : MonoBehaviour
{
    [SerializeField] private CircleController circlePrefab;
    [SerializeField] private int circleCount = 10;
    [SerializeField] private float heightOffset = 10f;
    [SerializeField] private Transform cylinder;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        CreateLevel();
        Debug.Log("Start çalýþtý");

    }

    private void CreateLevel()
    {
        if (cylinder == null)
        {
            Debug.LogError("Cylinder atanmamýþ!");
            return;
        }

        for (int i = 0; i < circleCount; i++)
        {
            Debug.Log("CreateLevel çalýþtý");

            var circle = Instantiate(circlePrefab, cylinder);

            circle.Initialize(i, heightOffset);

            if (i < 3)
                circle.Prepare(CircleController.LevelDifficulty.Simple);
            else if (i < 7)
                circle.Prepare(CircleController.LevelDifficulty.Middle);
            else
                circle.Prepare(CircleController.LevelDifficulty.Hard);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
