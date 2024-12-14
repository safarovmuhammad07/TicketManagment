using DoMain.Models;
using Infrastructure.AppResponse;

namespace Infrastructure.Interfaces;

public interface ILocationService
{
    Responce<List<Location>> GetLocations();
    Responce<Location> GetLocationById(int id);
    Responce<bool> AddLocation(Location location);
    Responce<bool> UpdateLocation(Location location);
    Responce<bool> DeleteLocation(int id);
}