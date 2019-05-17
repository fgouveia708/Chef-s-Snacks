using ChefSnacks.Core.Entities;
using System.Collections.Generic;

namespace ChefSnacks.Core.Interfaces
{
    public interface ISnackService
    {
        IEnumerable<Snack> GetSnacks();
    }
}
