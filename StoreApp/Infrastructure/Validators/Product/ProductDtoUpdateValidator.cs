using Entities.Dtos.Product;
using FluentValidation;

namespace StoreApp.Infrastructure.Validators.Product;
public class ProductDtoUpdateValidator : AbstractValidator<ProductDtoForUpdate>
{
    public ProductDtoUpdateValidator()
    {
        RuleFor(p => p.ProductName)
            .NotEmpty().WithMessage("Product name is required.")
            .MinimumLength(5).WithMessage("Product name must be at least 5 characters.")
            .MaximumLength(100).WithMessage("Product name must be less than 100 characters.");

        RuleFor(p => p.Price)
            .NotEmpty().WithMessage("Price is required.")
            .GreaterThan(0).WithMessage("Price must be greater than 0.");

        RuleFor(p => p.Summary)
            .NotEmpty().WithMessage("Summary is required.")
            .MaximumLength(500).WithMessage("Summary must be less than 500 characters.");

        RuleFor(p => p.CategoryId)
            .GreaterThan(0).WithMessage("Category ID must be a positive integer.")
            .When(p => p.CategoryId.HasValue);
    }
}

