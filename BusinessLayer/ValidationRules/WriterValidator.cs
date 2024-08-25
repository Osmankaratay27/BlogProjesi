using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class WriterValidator:AbstractValidator<Writer>
    {
        public WriterValidator() { 
        
            RuleFor(x=>x.WriterName).NotEmpty().WithMessage("Yazar adı soyadı kısmı boş geçilemez");
            RuleFor(x=>x.WriterMail).NotEmpty().WithMessage("Mail kısmı boş geçilemez");
            RuleFor(x=>x.WriterPassword).NotEmpty().WithMessage("Şifre kısmı boş geçilemez");
            RuleFor(x=>x.WriterName).MinimumLength(2).WithMessage("Lütfen en az 2 karakter girişi yapın");
            RuleFor(x=>x.WriterName).MaximumLength(50).WithMessage("Lütfen en fazla 50 karakterlik veri girişi yapın");
            RuleFor(p => p.WriterMail).Matches(@"[@]+").WithMessage("Mail adresi ' @ ' icermelidir");
            RuleFor(p => p.WriterMail).Matches(@"[.com]+").WithMessage("Mail adresi '.com ' icermelidir");
            RuleFor(p => p.WriterPassword).Matches(@"[A-Z]+").WithMessage("Sifre en az bir büyük harf içermelidir");
            RuleFor(p => p.WriterPassword).Matches(@"[a-z]+").WithMessage("Sifre en az bir küçük harf içermelidir");
            RuleFor(p => p.WriterPassword).Matches(@"[0-9]+").WithMessage("Sifre en az bir rakam içermelidir");
        }
    }
}
