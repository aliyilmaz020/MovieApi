using Microsoft.AspNetCore.Identity;

namespace MovieApi.Application.Identity;
public class CustomIdentityErrorDescriber : IdentityErrorDescriber
{
    public override IdentityError PasswordTooShort(int length)
         => new()
         {
             Code = nameof(PasswordTooShort),
             Description = $"Şifre en az {length} karakter olmalıdır."
         };

    public override IdentityError PasswordRequiresUpper()
        => new()
        {
            Code = nameof(PasswordRequiresUpper),
            Description = "Şifre en az 1 büyük harf içermelidir."
        };

    public override IdentityError PasswordRequiresLower()
        => new()
        {
            Code = nameof(PasswordRequiresLower),
            Description = "Şifre en az 1 küçük harf içermelidir."
        };

    public override IdentityError PasswordRequiresDigit()
        => new()
        {
            Code = nameof(PasswordRequiresDigit),
            Description = "Şifre en az 1 rakam içermelidir."
        };

    public override IdentityError DuplicateEmail(string email)
        => new()
        {
            Code = nameof(DuplicateEmail),
            Description = "Bu e-posta adresi zaten kullanılıyor."
        };

    public override IdentityError DuplicateUserName(string userName)
        => new()
        {
            Code = nameof(DuplicateUserName),
            Description = "Bu kullanıcı adı zaten alınmış."
        };

    public override IdentityError InvalidUserName(string? userName)
        => new()
        {
            Code = nameof(InvalidUserName),
            Description = "Kullanıcı adı geçersiz karakter içeriyor."
        };
}
