//=================================================
// Copyrigh (c) Coalition of Good-Hearted Engineers
// Free To Use To Find Comfort and Peace
//=================================================

using System.Threading.Tasks;
using CashOverFlow.Models.Locations;

namespace CashOverFlow.Services.Foundations.Locations
{
    public interface ILocationService
    {
        ValueTask<Location>AddLocationAsync(Location location);
    }
}
