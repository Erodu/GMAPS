using JetBrains.Annotations;
using UnityEngine;

public class VectorExercises : MonoBehaviour
{
    [SerializeField] LineFactory lineFactory;
    [SerializeField] bool Q2a, Q2b, Q2d, Q2e;
    [SerializeField] bool Q3a, Q3b, Q3c, projection;

    private Line drawnLine;

    private Vector2 startPt;
    private Vector2 endPt;

    public float GameWidth, GameHeight;
    private float minX, minY, maxX, maxY;

    private void Start()
    {
        CalculateGameDimensions();
        if (Q2a)
            Question2a();
        if (Q2b)
            Question2b(20);
        if (Q2d)
            Question2d();
        if (Q2e)
            Question2e(20);
        if (Q3a)
            Question3a();
        if (Q3b)
            Question3b();
        if (Q3c)
            Question3c();
        if (projection)
            Projection();
    }

    public void CalculateGameDimensions()
    {
        GameHeight = Camera.main.orthographicSize * 2f;
        GameWidth = Camera.main.aspect * GameHeight;

        maxX = GameWidth / 2; maxY = GameHeight / 2;
        minX = -maxX; minY = -maxY;
    }

    void Question2a()
    {
        startPt = new Vector2(0, 0);
        endPt = new Vector2(5, 2);

        drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
        drawnLine.EnableDrawing(true);

        Vector2 vec2 = endPt - startPt;
        Debug.Log("Magnitude = " + vec2.magnitude);

        /* The starting point (startPt) of the drawn line is set at (0, 0), which is the origin. The ending point (endPt) of this line is whatever we need it to be.
         * We then get the Line Factory script to draw a line that goes from our starting point to the end point, with a width of 0.02f and black in color.
         * In order to know the magnitude of this line, we create a local variable vec2 which is the transform of the line's starting point subtracted from its ending point.
         * We then put a message into the debug log that measures the magnitude using vec2.magnitude.*/
    }

    void Question2b(int n)
    {
        for (int i = 0; i < n; i++)
        {
            //The starting and ending points are randomized within the minimum and maximum X and Y points.

            startPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));
            endPt = new Vector2(Random.Range(minX, maxX), Random.Range(minY, maxY));

            drawnLine = lineFactory.GetLine(startPt, endPt, 0.02f, Color.black);
            drawnLine.EnableDrawing(true);
        }
    }

    void Question2d()
    {
        DebugExtension.DebugArrow(new Vector3(0, 0, 0), new Vector3(5, 5, 0), Color.red, 60f);
    }
    void Question2e(int n)

    {
        for (int i = 0; i < n; i++)
        {
            DebugExtension.DebugArrow(new Vector3(0, 0, 0), 
                new Vector3(Random.Range(-maxX, maxX), Random.Range(-maxY, maxY), Random.Range(-minY, minY)), 
                Color.white, 60f);
        }  
    }

    public void Question3a()
    {
        HVector2D a = new HVector2D(3, 5);
        HVector2D b = new HVector2D(-4, 2);
        HVector2D c = a + b;
        HVector2D minusB = a - b;

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(Vector3.zero, b.ToUnityVector3(), Color.green, 60f);
        //DebugExtension.DebugArrow(Vector3.zero, c.ToUnityVector3(), Color.white, 60f);
        DebugExtension.DebugArrow(Vector3.zero, minusB.ToUnityVector3(), Color.white, 60f);

        DebugExtension.DebugArrow(a.ToUnityVector3(), -b.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude());
        Debug.Log("Magnitude of b = " + b.Magnitude());
        Debug.Log("Magnitude of c = " + c.Magnitude());
    }

    public void Question3b()
    {
        HVector2D a = new HVector2D(3, 5);
        //HVector2D b = new HVector2D(a.ToUnityVector3() * 2.0f);
        HVector2D divB = new HVector2D(a.ToUnityVector3() / 2.0f);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.green, 60f);
        //DebugExtension.DebugArrow(new Vector3(1, 0, 0), b.ToUnityVector3(), Color.green, 60f);
        DebugExtension.DebugArrow(Vector3.left, divB.ToUnityVector3(), Color.red, 60f);
    }

    public void Question3c()
    {
        HVector2D a = new HVector2D(3, 5);

        DebugExtension.DebugArrow(Vector3.zero, a.ToUnityVector3(), Color.red, 60f);

        a.Normalize();
        DebugExtension.DebugArrow(Vector3.left, a.ToUnityVector3(), Color.green, 60f);

        Debug.Log("Magnitude of a = " + a.Magnitude());
    }

    public void Projection()
    {
        HVector2D a = new HVector2D(0, 0);
        HVector2D b = new HVector2D(6, 0);
        HVector2D c = new HVector2D(2, 2);

        HVector2D v1 = b - a;
        HVector2D v2 = c - a;
        //Debug.Log("Magnitude of v2 = " + v2.Magnitude());
        HVector2D proj = v2.Projection(v1);
        //Debug.Log("Magnitude of v2 = " + proj.Magnitude());

        DebugExtension.DebugArrow(a.ToUnityVector3(), b.ToUnityVector3(), Color.red, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), c.ToUnityVector3(), Color.yellow, 60f);
        DebugExtension.DebugArrow(a.ToUnityVector3(), proj.ToUnityVector3(), Color.white, 60f);
    }
}
