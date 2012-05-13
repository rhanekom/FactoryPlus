using System;

namespace FactoryPlus
{
    public static class Factory
    {
        #region Globals

        private static readonly IFactorySession staticSession = new FactorySession();

        #endregion
    }
}
