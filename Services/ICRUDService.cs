using TechnicoApplication.Responses;

namespace TechnicoApplication.Services;

public interface ICRUDService<T>{
    public ImmutableResponseStatus Create(T entity);
    public ImmutableResponseStatus Display(T entity);
    public ImmutableResponseStatus Update(T entity);
    public ImmutableResponseStatus Delete(T entity);
}
