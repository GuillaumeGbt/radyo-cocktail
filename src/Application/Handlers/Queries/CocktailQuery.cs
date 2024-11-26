using Cocktail.Application.Models.Dtos;
using Cocktail.Application.Repositories;
using Cocktail.Application.Specifications;
using MediatR;
using System.Collections.Generic;

namespace Cocktail.Application.Handlers.Queries;

public record CocktailQuery(string? IngredientName = null) : IRequest<IEnumerable<CocktailDto>>;

public class CocktailQueryHandler(IQueryProcessor<Domain.Aggregates.Cocktail> cocktailRepository) : IRequestHandler<CocktailQuery, IEnumerable<CocktailDto>>
{
    public async Task<IEnumerable<CocktailDto>> Handle(CocktailQuery request, CancellationToken cancellationToken)
    {
        CocktailSpec cocktailSpec = new CocktailSpec()
            .WithIngredients()
            .WithStep();

        if (request.IngredientName is not null && request.IngredientName != string.Empty)
            cocktailSpec.ByIngredients(request.IngredientName);

        IEnumerable<CocktailDto> cocktails = await cocktailRepository.ListAsync(cocktailSpec, cancellationToken);

        return cocktails;
    }
}
