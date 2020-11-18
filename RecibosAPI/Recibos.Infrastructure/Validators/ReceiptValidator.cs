using FluentValidation;
using Recibos.Core.DTOs;

namespace Recibos.Infrastructure.Validators
{
    public class ReceiptValidator : AbstractValidator<ReceiptDto>
    {
        public ReceiptValidator() 
        {
            RuleFor(receipt => receipt.Amount)
                .NotNull();
            RuleFor(receipt => receipt.Comments)
                .NotNull();
            RuleFor(receipt => receipt.Date)
                .NotNull();
            RuleFor(receipt => receipt.CurrencyId)
                .NotNull();
            RuleFor(receipt => receipt.SupplierId)
                .NotNull();
        }
    }
}
