namespace BZUTransport.Models
{
    using BZUCommon.RequestValidiation;
    using BZUTransport.Models.ErrorModels;
    using Microsoft.Extensions.Logging;
    using System.ComponentModel.DataAnnotations;

    public class User
    {
        private readonly ILogger logger;

        public User(ILogger logger, int carCapacity = 4)
        {
            this.logger = logger;
            this.CarCapacity = carCapacity;
        }

        private string _Name { get; set; }

        private string _EmailAddress { get; set; }

        private string _Password { get; set; }

        private string _ConfirmPassword { get; set; }

        private string _PhoneNumber { get; set; }


        [Required]
        //[StringValidation(ErrorMessage = "الاسم لا يجب ان يكون فارغا", Regex = "" )]
        public string Name
        {
            get { return this._Name; }
            set
            {
                if (Ensure.StringRegexValidation(value, "", this.logger))
                {
                    this._Name = value;
                    this.ErrorMessages.Name = string.Empty;
                }
                else
                {
                    this.ErrorMessages.Name = "الاسم لا يجب ان يكون فارغا";
                }
            }
        }

        [Required]
        //[StringValidation(ErrorMessage = "البريد الاكتروني خاطئ", Regex = CommonStrings.EmailRegex)]
        [EmailAddress]
        public string EmailAddress
        {
            get { return this._EmailAddress; }
            set
            {
                if (Ensure.StringRegexValidation(value, CommonStrings.EmailRegex, this.logger))
                {
                    this._EmailAddress = value;
                    this.ErrorMessages.EmailAddress = string.Empty;
                }
                else
                {
                    this.ErrorMessages.EmailAddress = "البريد الاكتروني خاطئ";
                }
            }
        }

        [Required]
        //[StringValidation(ErrorMessage = CommonStrings.BadPassWordMessage, Regex = CommonStrings.StrongPasswordRegex)]
        public string Password
        {
            get { return this._Password; }
            set
            {
                if (Ensure.StringRegexValidation(value, CommonStrings.StrongPasswordRegex, this.logger))
                {
                    this._Password = value;
                    this.ErrorMessages.Password = string.Empty;
                }
                else
                {
                    this.ErrorMessages.Password = CommonStrings.BadPassWordMessage;
                }
            }
        }

        [Required]
        //[StringValidation(ErrorMessage = CommonStrings.BadPassWordMessage, Regex = CommonStrings.StrongPasswordRegex)]
        public string ConfirmPassword
        {
            get
            {
                return this._ConfirmPassword;
            }
            set
            {
                if (string.Equals(value, this.Password))
                {
                    this._ConfirmPassword = value;
                    this.ErrorMessages.ConfirmPassword = string.Empty;
                }
                else
                {
                    this.ErrorMessages.ConfirmPassword = "كلمة سر غير مشابهة";
                }
            }
        }

        [Required]
        //[StringValidation(ErrorMessage = "رقم خاطئ", Regex = CommonStrings.PhoneRegex)]
        [Phone]
        public string PhoneNumber
        {
            get
            {
                return this._PhoneNumber;
            }
            set
            {
                if (Ensure.StringRegexValidation(value, CommonStrings.PhoneRegex, this.logger))
                {
                    this._PhoneNumber = value;
                    this.ErrorMessages.PhoneNumber = string.Empty;
                }
                else
                {
                    this.ErrorMessages.PhoneNumber = "رقم خاطئ";
                }
            }
        }

        public bool IsCarOwner{ get; set; }

        public int CarCapacity { get; set; }

        public string CarName { get; set; }

        public string OtherNotes { get; set; }

        /// <summary>
        /// It saves ever paramter error meesage because the error reporting is not working correctly in maui right now
        /// We can remove it in the future when the validation attribute start working again.
        /// </summary>
        public UserRegisterError ErrorMessages { get; set; } = new UserRegisterError();
    }
}
