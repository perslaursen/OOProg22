
public interface IDesolvable<TDesolved> where TDesolved : class
{
    TDesolved Desolve();
}

//public interface IDesolvable<TDesolved, TData> where TDesolved : class
//{
//    TDesolved Desolve(TData data);
//}

