using System;

namespace LeadGenAdminEntities.Error
{
    public class LeadGenerationValidationException : Exception
    {
        /// <summary>
        /// Localized string for error message.
        /// </summary>
        public string ErrorCode { get; set; }
        public LeadGenerationValidationException(string errorCode, string errorMessage) : base(errorMessage)
        {
            ErrorCode = errorCode;
        }
    }
}
