namespace AvanceradDotNet_Labb4.Services
{
    public interface ILabb4<T>
    {
        public IEnumerable<T> GetAll();
        public T GetById(int id);
        public T Add(T entity);
        public T Update(T entity);
        public T Delete(T entity);

    }
}
