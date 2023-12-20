using Domain;

namespace Application;

public interface IContextProvider
{
    public IContext GetContext();
}