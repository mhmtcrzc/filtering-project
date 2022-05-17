using System;

namespace FilteringProject
{
    // Bitflags for express Table Type using a single integer value.
    [Flags]
    public enum TableTypes
    {
        None = 0,
        Fast = 1,
        OneOnOne = 2,
        Revenge = 4,       
    }
}
