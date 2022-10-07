using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface IProductService
{
    List<ProductModel> GetAll();
    ProductModel GetOne(string id);
    void Insert(ProductModel model);
    void Update(ProductModel model);
    void Delete(ProductModel model);
}
public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;

    public ProductService(IProductRepository productRepository)
    {
        this.productRepository = productRepository;
    }

/// <summary>
/// get all metoda
/// </summary>
/// <returns></returns>
    public List<ProductModel> GetAll()
    {
        var dataFromDb = productRepository.GetAll();

        var listOfModel = new List<ProductModel>();

        foreach (var product  in dataFromDb)
        {
            var model = new ProductModel { Id = product.Id.ToString(), Price = product.Price, Name = product.Name, Category = product.Category};
            listOfModel.Add(model);
        }
        
        return listOfModel;
    }
/// <summary>
/// get one metod
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public ProductModel GetOne(string id)
{
    var dataFromDb = productRepository.GetOne(ObjectId.Parse(id));
    var model = new ProductModel { Id = dataFromDb.Id.ToString(), Price = dataFromDb.Price, Name = dataFromDb.Name, Category = dataFromDb.Category};
    return model;
}

public void Insert(ProductModel model)
{
    var obj = new Product { Price = model.Price, Name = model.Name, Category = model.Category};
    productRepository.Insert(obj);
}

public void Update(ProductModel model)
{
    var obj = new Product { Id = ObjectId.Parse(model.Id), Price = model.Price, Name = model.Name, Category = model.Category };
    productRepository.Update(obj);
}

public void Delete(ProductModel model)
{
    var obj = new Product { Id = ObjectId.Parse(model.Id), Price = model.Price, Name = model.Name, Category = model.Category };
    productRepository.Delete(obj);
}
}