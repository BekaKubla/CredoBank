using AutoMapper;
using KredoBank.Application.Services.UserContext;
using KredoBank.Domain.SeedWork;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Statements.Queries.GetStatement
{
    public class GetStatementQueryHandler : IRequestHandler<GetStatementQuery, List<GetStatementResultModel>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserContextService _userContextService;
        public GetStatementQueryHandler(IUnitOfWork unitOfWork,
                                        UserContextService userContextService,
                                        IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _userContextService = userContextService;
            _mapper = mapper;
        }
        public async Task<List<GetStatementResultModel>> Handle(GetStatementQuery request, CancellationToken cancellationToken)
        {
            var currentUser = await _userContextService.GetCurrentUserId();
            var statement = (await _unitOfWork.StatementRepository.GetAllAsync(cancellationToken)).Where(x => x.IsActive && !x.IsDeleted && x.UserId == currentUser.Id).ToList();
            return _mapper.Map<List<GetStatementResultModel>>(statement);
        }
    }
}
