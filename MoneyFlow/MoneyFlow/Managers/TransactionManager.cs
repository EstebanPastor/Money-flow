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

        public List<HistoryDTO> GetHistory(DateOnly startDate, DateOnly EndDate, int UserId)
        {
            var rawList = _dbContext.Transaction
                .Where(item => item.UserId == UserId && item.Date >= startDate && item.Date <= EndDate)
                .Select(item => new
                {
                    item.Date,
                    ServiceName = item.Service != null ? item.Service.Name : "Sin servicio",
                    item.TotalAmount
                })
                .ToList();

            var list = rawList.Select(item => new HistoryDTO
            {
                Date = item.Date.ToString("dd/MM/yyyy"),
                Month = item.Date.ToString("MMMM"),
                TypeService = item.ServiceName,
                Service = item.ServiceName,
                TotalAmount = item.TotalAmount.ToString() ?? "0"
            }).ToList();

            return list;
        }
    }
}
