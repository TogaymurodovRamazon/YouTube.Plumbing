using EntityLayer.WebApplication.ViewModels.TestimonalVM;
using FluentValidation;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.WebApplication.TestimonalValidation
{
    public class TestimonalUpdateValidation : AbstractValidator<TestimonalUpdateVM>
    {
        public TestimonalUpdateValidation()
        {
            RuleFor(x => x.Comment)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Comment"))
                .MaximumLength(2000).WithMessage(ValidationMessages.MaximumCharachterAllowence("Comment", 2000));
            RuleFor(x => x.FullName)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FullName"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("FullName", 100));
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Title"))
                .MaximumLength(100).WithMessage(ValidationMessages.MaximumCharachterAllowence("Title", 100));
            /**RuleFor(x => x.FileName)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileName"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileName"));
            RuleFor(x => x.FileType)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("FileType"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("FileType"));**/
        }
    }
}
