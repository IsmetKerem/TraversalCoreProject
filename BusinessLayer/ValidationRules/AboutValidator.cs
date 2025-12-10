using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AboutValidator:AbstractValidator<About>
{
    public AboutValidator()
    {
        RuleFor(x => x.Decription).NotEmpty().WithMessage("Açıklama boş geçemezsiniz");
        RuleFor(x => x.Image1).NotEmpty().WithMessage("Lütfen görsel seçiniz!");
        RuleFor(x => x.Decription).MinimumLength(50).WithMessage("Lütfen en az 50 karakterlik açıklama giriniz..");
        RuleFor(x => x.Decription).MaximumLength(1500).WithMessage("Lütfen açıklamayı kısaltınız..");
    }
    
}