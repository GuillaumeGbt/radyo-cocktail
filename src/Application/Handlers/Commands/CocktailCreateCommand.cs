using Cocktail.Application.Models.Dtos;
using Cocktail.Application.Repositories;
using Cocktail.Domain.Specifications;
using FluentValidation;
using Mapster;
using MediatR;

namespace Cocktail.Application.Handlers.Commands;

public record CocktailCreateCommand(string Name) : IRequest<CocktailDto>;

public class CocktailCreateValidator : AbstractValidator<CocktailCreateCommand>
{
    public CocktailCreateValidator(IAsyncRepository<Domain.Aggregates.Cocktail> cocktailRepository)
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .MustAsync(async (name, cancellationToken) =>
            {
                var exist = await cocktailRepository.GetAsync(new CocktailSpec().HasName(name), cancellationToken);
                return (exist is null);
            })
            .WithMessage("Cocktail name must be unique");
    }
}

public class CocktailCreateCommandHandler(IAsyncRepository<Domain.Aggregates.Cocktail> cocktailRepository) : IRequestHandler<CocktailCreateCommand, CocktailDto>
{
    public async Task<CocktailDto> Handle(CocktailCreateCommand request, CancellationToken cancellationToken)
    {
        var cocktail = new Domain.Aggregates.Cocktail(request.Name);
        await cocktailRepository.AddAsync(cocktail, cancellationToken);
        return cocktail.Adapt<CocktailDto>();
    }
}