namespace MoneyFlow.Entities;

public class Transaction
{

    public int TransactionId { get; set; }
    public int ServiceId { get; set; }

    public DateOnly Date { get; set; }

    public int MyProperty { get; set; }


    public int UserId { get; set; }

    public string Commment { get; set;  }

    public decimal Total { get; set; }

    public Service Service { get; set; }

    public User User { get; set; }


}
