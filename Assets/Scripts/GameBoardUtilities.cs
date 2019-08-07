using UnityEngine;

public static class GameBoardUtilities
{
    // Determine if a Float is Zero
    // More accurate than simple comparator 
    public static bool FloatIsZero(float _fValue)
    {
        bool bRet = false;

        if ((_fValue < Mathf.Epsilon) && (_fValue > - Mathf.Epsilon))
        {
            bRet = true;
        }

        return bRet;
    }
}
