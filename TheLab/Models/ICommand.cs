using System;
namespace TheLab.Models
{

    public interface ICommand<T>
    {
        T Execute(T input);
        T Undo();
        T Redo();
    }
}
