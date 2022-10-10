using AutoMapper;
using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface ICategoryService
{
    List<CategoryModel> GetAll();
    CategoryModel GetOne(string id);
    void Insert(CategoryModel model);
    void Update(CategoryModel model);
    void Delete(CategoryModel model);
}
public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository categoryRepository;
    private readonly IMapper _mapper;

    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper)
    {
        this.categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// get all metoda
    /// </summary>
    /// <returns></returns>
    public List<CategoryModel> GetAll()
    {
        var dataFromDb = categoryRepository.GetAll();
        var listOfModel = _mapper.Map<List<CategoryModel>>(dataFromDb);
        
        return listOfModel;
    }
    /// <summary>
    /// get one metod
    /// </summary>
    /// <param name="id"></param>
    /// <returns></returns>
    public CategoryModel GetOne(string id)
    {
        var dataFromDb = categoryRepository.GetOne(ObjectId.Parse(id));
        var model = _mapper.Map<CategoryModel>(dataFromDb);
        return model;
    }

    public void Insert(CategoryModel model)
    {
    
        categoryRepository.Insert(_mapper.Map<Category>(model));
    }

    public void Update(CategoryModel model)
    {
     
        categoryRepository.Update(_mapper.Map<Category>(model));
    }

    public void Delete(CategoryModel model)
    {
   
        categoryRepository.Delete(_mapper.Map<Category>(model));
    }
}