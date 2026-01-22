using DocumentFormat.OpenXml.InkML;
using MediatR;
using Microsoft.EntityFrameworkCore;
using TraversalCoreProject.CQRS.Queries.GuideQueries;
using TraversalCoreProject.CQRS.Results.GuideResults;
using Context = DataAccessLayer.Concrete.Context;

namespace TraversalCoreProject.CQRS.Handlers.GuideHandlers;

public class GetAllGuideQueryHandler:IRequestHandler<GetAllGuideQuery,List<GetAllGuideQueryResult>>
{
   private readonly Context _context;
   public GetAllGuideQueryHandler(Context context)
    {
        _context = context;
    }

    public async Task<List<GetAllGuideQueryResult>> Handle(GetAllGuideQuery request, CancellationToken cancellationToken)
    {
        return await _context.Guides
            .Where(x => x.Name != null && x.Description != null && x.Image != null) // ✅ Null kontrolü
            .Select(x => new GetAllGuideQueryResult
            {
                GuideID = x.GuideID,
                Name = x.Name,
                Description = x.Description,
                Image = x.Image
            })
            .AsNoTracking()
            .ToListAsync(cancellationToken);
    }
}