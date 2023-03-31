using KredoBank.Application.Common;
using KredoBank.Application.Services.UserContext;
using KredoBank.Domain.SeedWork;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace KredoBank.Application.Statements.Commands.DeleteStatement
{
    public class DeleteStatementCommandHandler : IRequestHandler<DeleteStatementCommand, ResultModel>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserContextService _userContextService;
        public DeleteStatementCommandHandler(IUnitOfWork unitOfWork,
                                             UserContextService userContextService)
        {
            _unitOfWork = unitOfWork;
            _userContextService = userContextService;
        }
        public async Task<ResultModel> Handle(DeleteStatementCommand request, CancellationToken cancellationToken)
        {
            var currentUser = await _userContextService.GetCurrentUserId();
            var currentStatement = await _unitOfWork.StatementRepository.GetSingleAsync(x => x.Id == request.StatementId &&
                                                                                        x.IsActive &&
                                                                                        !x.IsDeleted &&
                                                                                        x.UserId == currentUser.Id,
                                                                                        cancellationToken);
            if (currentStatement == null)
            {
                throw new Exception("განცხადება ვერ მოიძებნა");
            }

            currentStatement.DeleteStatement();
            _unitOfWork.StatementRepository.Update(currentStatement);
            await _unitOfWork.SaveChangeAsync();

            return new ResultModel
            {
                ResultMessage = "განცხადება წარმატებით წაიშალა"
            };
        }
    }
}
