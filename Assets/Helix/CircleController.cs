using System.Collections.Generic;
using UnityEngine;

public class CircleController : MonoBehaviour
{

    [SerializeField] private GameObject piecePrefab;
    [SerializeField] private int pieceCount = 12;
    private readonly List<GameObject> pieces = new List<GameObject>();
    public enum LevelDifficulty
    {
        Simple,
        Middle,
        Hard
    }

    public void Initialize(int index, float height)
    {
        transform.localPosition = new Vector3(0, index * height, 0);

        CreateCircle();
        Debug.Log("Initialize çalýþtý");

    }

    private void CreateCircle()
    {
        float angleStep = 360f / pieceCount;
        Debug.Log("CreateLevelCreateCircle çalýþtý");

        for (int i = 0; i < pieceCount; i++)
        {
            var piece = Instantiate(piecePrefab, transform);

            piece.transform.localPosition = Vector3.zero;
            piece.transform.localRotation = Quaternion.Euler(0, i * angleStep, 0);

            pieces.Add(piece);
        }
    }

    public void Prepare(LevelDifficulty difficulty)
    {
        switch (difficulty)
        {
            case LevelDifficulty.Simple:
                PrepareSimple(pieces.Count / 2);
                break;

            case LevelDifficulty.Middle:
                PrepareMiddle(pieces.Count / 3);
                break;

            case LevelDifficulty.Hard:
                PrepareHard();
                break;
        }
    }

    public void PrepareSimple(int nonactiveAmount)
    {
        ResetPieces();
        Debug.Log("PrepareSimple çalýþtý");

        int gapSize = Random.Range(3, 5);
        int startIndex = Random.Range(0, pieces.Count);

        for (int i = 0; i < gapSize; i++)
        {
            int index = (startIndex + i) % pieces.Count;
            pieces[index].SetActive(false);
        }
    }
    public void PrepareMiddle(int nonactiveAmount)
    {
        ResetPieces();

        int startIndex = Random.Range(0, pieces.Count);
        int mainGapSize = Random.Range(2, 4);

        for (int i = 0; i < mainGapSize; i++)
        {
            int index = (startIndex + i) % pieces.Count;
            pieces[index].SetActive(false);
        }

        int smallGapSize = 1;

        int secondStart;
        do
        {
            secondStart = Random.Range(0, pieces.Count);
        }
        while (IsTooClose(secondStart, startIndex, mainGapSize));

        pieces[secondStart].SetActive(false);
    }
    public void PrepareHard()
    {
        ResetPieces();

        int gapSize = Random.Range(1, 2); 

        int startIndex = Random.Range(0, pieces.Count);

        for (int i = 0; i < gapSize; i++)
        {
            int index = (startIndex + i) % pieces.Count;
            pieces[index].SetActive(false);
        }
    }

    private bool IsTooClose(int index, int start, int size)
    {
        for (int i = 0; i < size; i++)
        {
            int check = (start + i) % pieces.Count;
            if (check == index)
                return true;
        }
        return false;
    }

    private void ResetPieces()
    {
        foreach (var piece in pieces)
        {
            piece.SetActive(true);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
