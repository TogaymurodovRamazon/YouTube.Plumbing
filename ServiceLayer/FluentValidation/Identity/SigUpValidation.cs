﻿using EntityLayer.Identity.ViewModels;
using FluentValidation;
using ServiceLayer.Messages.Identity;
using ServiceLayer.Messages.WebApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.FluentValidation.Identity
{
    public class SigUpValidation : AbstractValidator<SignUpVM>
    {
        public SigUpValidation()
        {
            RuleFor(x => x.Username)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Username"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Username"));
            RuleFor(x=> x.Email)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Email"))
                .EmailAddress().WithMessage(IdentityMessages.CheckEmailAddress());
            RuleFor(x => x.Password)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Password"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Password"));
            RuleFor(x => x.ConfirmPassword)
                .NotEmpty().WithMessage(ValidationMessages.NullEmptyMessage("Confirm Password"))
                .NotNull().WithMessage(ValidationMessages.NullEmptyMessage("Confirm Password"))
                .Equal(x => x.Password).WithMessage(IdentityMessages.ComparePassword());
        }
    }
}
