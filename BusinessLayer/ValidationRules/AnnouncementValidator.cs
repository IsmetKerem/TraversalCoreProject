using DTOLayer.DTOs.AnnouncementDTOs;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.ValidationRules;

public class AnnouncementValidator:AbstractValidator<AnnouncementAddDto>
{
    public AnnouncementValidator()
    {
        RuleFor(x=>x.Title).NotEmpty().WithMessage("Başlık boş geçilemez");
        RuleFor(x=>x.Content).NotEmpty().WithMessage("Duyuru boş geçilemez");
        RuleFor(x => x.Title).MinimumLength(5).WithMessage("Başlık minumum 5 karakter olmalı");
        RuleFor(x => x.Content).MinimumLength(20).WithMessage("Duyuru minumum 20 karakter olmalı");
        RuleFor(x => x.Title).MaximumLength(50).WithMessage("Duyuru başlığı maksimum 50 karakter olabilir");
        RuleFor(x => x.Content).MaximumLength(500).WithMessage("Duyuru içeriği maksimum 500 karakter olabilir");
        
    }
}