namespace DifficultSimpleCompare;

public class TransactionComparer : IEqualityComparer<Transaction>
{
    public bool Equals(Transaction? x, Transaction? y)
    {
        if (x == null || y == null) throw new ArgumentNullException(); // null не обрабатываем
        
        if (x.TargetId.HasValue && y.TargetId.HasValue && x.TargetId != y.TargetId) return false; // early exit: если получатель платежа заполнен для обоих транзакций и они не равны, то это явно разные транзакции.
        
        if (!string.IsNullOrEmpty(x.Uid) && !string.IsNullOrEmpty(y.Uid)) // сравниваем уникальные идентификаторы, только если они оба заполнены
        {
            return string.Equals(x.Uid, y.Uid, StringComparison.OrdinalIgnoreCase);
        }

        if (!string.IsNullOrEmpty(x.Account) && !string.IsNullOrEmpty(y.Account)) // то же для номеров счетов
        {
            return string.Equals(x.Account, y.Account, StringComparison.OrdinalIgnoreCase);
        }

        return false; // ничего не сработало, значит это разные транзакции
    }

    public virtual int GetHashCode(Transaction obj) => 
        HashCode.Combine(
            obj.TargetId.GetHashCode(),
            obj.Uid?.GetHashCode(),
            obj.Account?.GetHashCode()
        );
}

public class PatchedTransactionComparer : TransactionComparer
{
    public override int GetHashCode(Transaction obj) => 0;
}
