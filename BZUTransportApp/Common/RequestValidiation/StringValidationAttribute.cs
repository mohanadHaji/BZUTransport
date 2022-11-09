namespace Common.RequestValidiation
{
    using System.ComponentModel.DataAnnotations;
    using System.Text.RegularExpressions;

    public class StringValidationAttribute : ValidationAttribute
    {
        public string Regex { get; set; } = string.Empty;

        /* this should validate the input string based on the regex
         * and return an error message
         * 
         * ToDo: this code should print out error messages but is not working for now
         * however the validiation it self is working
         */
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            Regex regex = new Regex(Regex);

            if (regex.IsMatch(value.ToString()))
                return ValidationResult.Success;

            return new ValidationResult(ErrorMessage, new[] { validationContext.DisplayName });
        }
    }
}
