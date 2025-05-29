using EntityLayer.WebApplication.ViewModels.ContactVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.ContactValidation
{
    public class ContactAddValidation : AbstractValidator<ContactAddVM>
    {
        public ContactAddValidation()
        {
            RuleFor(x => x.Location)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Location"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Location"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Location", 200));
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Email", 100));
            RuleFor(x => x.Call)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Call"))
                .MaximumLength(20).WithMessage(ValidationMessages.MaximumCharachterAllowence("Call", 20));
            RuleFor(x => x.Map)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Map"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Map"));
        }
    }
}
