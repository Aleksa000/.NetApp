using AutoMapper;
using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface IProductService
{
    List<ProductModel> GetAll();
    long TotalCount ();
    List<ProductModel> PaginationSearch(int? startIndex,int? numberOfObject);
    ProductModel GetOne(string id);
    void Insert(ProductModel model);
    void Update(ProductModel model);
    void Delete(ProductModel model);
}
public class ProductService : IProductService
{
    private readonly IProductRepository productRepository;
    private readonly IMapper _mapper;

    public ProductService(IProductRepository productRepository, IMapper mapper)
    {
        this.productRepository = productRepository;
        _mapper = mapper;
    }

/// <summary>
/// get all metoda
/// </summary>
/// <returns></returns>
    public List<ProductModel> GetAll()
    {
        var dataFromDb = productRepository.GetAll();
        var listOfModel = _mapper.Map<List<ProductModel>>(dataFromDb);
        
        return listOfModel;
    }
/// <summary>
/// Total count method
/// </summary>
/// <returns></returns>
public long TotalCount()
{
    return productRepository.NumberOfDocuments();
}

/// <summary>
/// pagination search
/// </summary>
/// <returns></returns>
    public List<ProductModel> PaginationSearch(int? startIndex,int? numberOfObject)
{
    if (startIndex is not { }) startIndex = 0;
    if (numberOfObject is not { }) numberOfObject = 10;
        
        
    var dataFromDb = productRepository.PaginationSearch(startIndex,numberOfObject);
    var listOfModel = _mapper.Map<List<ProductModel>>(dataFromDb);
        
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
    var model = _mapper.Map<ProductModel>(dataFromDb);
    return model;
}

public void Insert(ProductModel model)
{
    
    productRepository.Insert(_mapper.Map<Product>(model));    
}

public void Update(ProductModel model)
{
    
    productRepository.Update(_mapper.Map<Product>(model));
}

public void Delete(ProductModel model)
{
   
    productRepository.Delete(_mapper.Map<Product>(model));
}
}