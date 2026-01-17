using DTOLayer.DTOs.AppUserDTOs;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AppUserRegisterValidator:AbstractValidator<AppUserRegisterDTOs>
{
    public AppUserRegisterValidator()
    {
        RuleFor(x => x.UserName).NotEmpty().WithMessage("ad alanı boş geçilemez");
        RuleFor(x=>x.SurName).NotEmpty().WithMessage("soyad alanı boş geçilemez");
        RuleFor(x=>x.Mail).NotEmpty().WithMessage("mailalanı boş geçilemez");
        RuleFor(x=>x.Password).NotEmpty().WithMessage("şifre alanı boş geçilemez");
        RuleFor(x=>x.ConfirmPassword).NotEmpty().WithMessage("lütfen tekrar şifreinizi girinn bu alan  boş geçilemez");

        RuleFor(x => x.Name).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
        RuleFor(x => x.Name).MaximumLength(20).WithMessage("Lütfen en fazla 20 karakter veri girişi yapınız");

        RuleFor(x => x.Password).Equal(y => y.ConfirmPassword).WithMessage("Şifreler birbiriyle uyuşmuyor");
    }
}