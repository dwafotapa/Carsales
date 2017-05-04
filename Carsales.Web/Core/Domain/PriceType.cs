using System;

namespace Carsales.Core.Domain
{
    [Flags]
    public enum PriceType
    {
        // Price on application
        POA = 0x0,
        // Excluding goverment charges
        EGC = 0x1,
        // Drive away price
        DAP = 0x2
    }
}