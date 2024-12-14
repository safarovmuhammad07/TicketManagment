using DoMain.Models;
using Infrastructure.AppResponse;

namespace Infrastructure.Interfaces;

public interface IPurchaseService
{
    Responce<List<Purchase>> GetPurchases();
    Responce<Purchase> GetPurchasesById(int Id);
    Responce<bool> AddPurchase(Purchase purchase);
    Responce<bool> UpdatePurchase(Purchase purchase);
    Responce<bool> DeletePurchase(Purchase purchase);
    
}