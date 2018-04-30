using System;

namespace Xinerji.Jwt
{
    /// <summary>
    /// Represents a DateTime provider.
    /// </summary>
    public interface IDateTimeProvider
    {
        /// <summary>
        /// Get the current DateTime.
        /// </summary>
        /// <returns></returns>
        DateTimeOffset GetNow();
    }
}