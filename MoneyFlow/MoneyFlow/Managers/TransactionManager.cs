using MoneyFlow.Context;
using MoneyFlow.DTOs;
using MoneyFlow.Entities;

namespace MoneyFlow.Managers
{
    public class TransactionManager(AppDBContext _dbContext)
    {
        public int New(TransactionDTO modelDto)
        {
            var entity = new Transaction
            {
                Date = modelDto.Date,
                TotalAmount = modelDto.TotalAmount,
                Comment = modelDto.Comment,
                ServiceId = modelDto.ServiceId,
                UserId = modelDto.UserId,
            };

            _dbContext.Transaction.Add(entity);

            var affected_rows = _dbContext.SaveChanges();
            
            return affected_rows;
        }
    }
}
