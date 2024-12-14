using System.Net;
using Dapper;
using DoMain.Models;
using Infrastructure.AppResponse;
using Infrastructure.DataContext;
using Infrastructure.Interfaces;

namespace Infrastructure.Services;

public class LocationService(DapperContext context):ILocationService
{
    public Responce<List<Location>> GetLocations()
    {
        var sql = @"select * from locations";
        var res = context.GetConnection().Query<Location>(sql).ToList();
        return new Responce<List<Location>>(res);
    }

    public Responce<Location> GetLocationById(int id)
    {
        var sql = @"select * from locations where id = @id";
        var res = context.GetConnection().Query<Location>(sql, new { id }).FirstOrDefault();
        return res==null
            ? new Responce<Location>(HttpStatusCode.NotFound, "NOT FOUND")
            :new Responce<Location>(res);
    }

    public Responce<bool> AddLocation(Location location)
    {
        var sql = @"insert into Locations(City,Adress,LocationType) values (@City,@Adress,@LocationType)";
        var res = context.GetConnection().Execute(sql, location);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.InternalServerError, "Intervae Eror from Server")
            : new Responce<bool>(HttpStatusCode.Created, "Location is created");
    }

    public Responce<bool> UpdateLocation(Location location)
    {
        var sql = @"Update Locations set City=@City,Adress=@Adress,LocationType=@LocationType where id = @id";
        var res = context.GetConnection().Execute(sql, location);
        return res == 0 
            ? new Responce<bool>(HttpStatusCode.NotFound, "NOT FOUND")
            :new Responce<bool>(HttpStatusCode.OK, "Location is updated");
    }

    public Responce<bool> DeleteLocation(int id)
    {
        var sql = @"delete from locations where id = @id";
        var res = context.GetConnection().Execute(sql, new { id }) ;
        return res==0 
            ? new Responce<bool>(HttpStatusCode.NotFound, "NOT FOUND") 
            : new Responce<bool>(HttpStatusCode.OK, "Location is deleted");
        
    }
}