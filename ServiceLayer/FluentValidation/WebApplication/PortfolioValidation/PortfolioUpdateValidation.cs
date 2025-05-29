using EntityLayer.WebApplication.ViewModels.PortfolioVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.PortfolioValidation
{
    public class PortfolioUpdateValidation : AbstractValidator<PortfolioUpdateVM>
    {
        public PortfolioUpdateValidation()
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(200).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 200));
            /**RuleFor(x => x.FileName)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileName"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileName"));
            RuleFor(x => x.FileType)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileType"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileType"));**/
        }
    }
}
