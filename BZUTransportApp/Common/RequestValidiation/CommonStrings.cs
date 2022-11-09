namespace Common.RequestValidiation
{
    public static class CommonStrings
    {
        public const string EmailRegex = "(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|\"(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21\\x23-\\x5b\\x5d-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])*\")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\\[(?:(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9]))\\.){3}(?:(2(5[0-5]|[0-4][0-9])|1[0-9][0-9]|[1-9]?[0-9])|[a-z0-9-]*[a-z0-9]:(?:[\\x01-\\x08\\x0b\\x0c\\x0e-\\x1f\\x21-\\x5a\\x53-\\x7f]|\\\\[\\x01-\\x09\\x0b\\x0c\\x0e-\\x7f])+)\\])";

        public const string StrongPasswordRegex = "^(?=(.*[a-z]){3,})(?=(.*[A-Z]){2,})(?=(.*[0-9]){2,})(?=(.*[!@#$%^&*()\\-__+.]){1,}).{8,}$";

        // regex is so basic it need to modifed
        public const string PhoneRegex = "^(^\\s*?\\d{10,14})$";

        public const string BadPassWordMessage = "\r\n            \"كلمة المرور لا تطابق معاير الامان:\" +\r\n            \" 1. يجب ان تكون من 8 حروف\" +\r\n            \" 2. حرفان في الأحرف الكبيرة\" +\r\n            \" 3. حرف خاص واحد على الاقل\" +\r\n            \" 4. رقمين\" +\r\n            \" 5. ثلاث احرف صغيرة\"";
    }
}
