using UnityEngine;
using System.Collections;

// PRINTS EVERY 2 SECONDS
// In this example we show how to invoke a coroutine and
// continue executing the function in parallel.

//--------------------------------------------------------

/*
public class Coroutine : MonoBehaviour
{
    // In this example we show how to invoke a coroutine and
    // continue executing the function in parallel.

    private IEnumerator coroutine;

    void Start()
    {

        print("Starting " + Time.time);

        // gives the coroutine a 5 frame pause.
        coroutine = WaitAndPrint(5.0f);

        // Starts the coroutine
        StartCoroutine(coroutine);

        print("Before WaitAndPrint Finishes " + Time.time);
    }

    // every 2 seconds perform the print()
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time);
        }
    }
}
*/
//-----------------------------------------------------

/*
public class Coroutine : MonoBehaviour
{
    IEnumerator Start()
    {
   
        print("Starting " + Time.time);

        // Start function WaitAndPrint as a coroutine. And wait until it is completed.
        // the same as yield return WaitAndPrint(2.0f);
        yield return StartCoroutine(WaitAndPrint(2.0f));
        print("Done " + Time.time);
    }

    // suspend execution for waitTime seconds
    IEnumerator WaitAndPrint(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        print("WaitAndPrint " + Time.time);
    }
}
*/
//---------------------------------------------------------------------

public class Coroutine : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(coroutineA());
    }

    IEnumerator coroutineA()
    {
        // wait for 1 second
        Debug.Log("coroutineA created");
        yield return new WaitForSeconds(1.0f);
        yield return StartCoroutine(coroutineB());
        Debug.Log("coroutineA running again");
    }

    IEnumerator coroutineB()
    {
        Debug.Log("coroutineB created");
        yield return new WaitForSeconds(2.5f);
        Debug.Log("coroutineB enables coroutineA to run");
    }
}
