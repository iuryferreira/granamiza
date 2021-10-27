using FluentValidation;
using Granamiza.Shared;

namespace Granamiza.Api.Models;

public class Income : Model
{
    public Income (string title, decimal value)
    {
        Title = title;
        Value = value;
        Validate(this, new IncomeValidator());
    }

    public string Title { get; init; }
    public decimal Value { get; init; }

}

public class IncomeValidator : AbstractValidator<Income>
{
    public IncomeValidator ()
    {
        RuleFor(income => income.Title).NotEmpty();
        RuleFor(income => income.Value).NotEmpty().GreaterThan(0);
    }
}

