using AutoMapper;
using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface IWorkService
{
    List<WorkModel> GetAll();
    long TotalCount ();
    List<WorkModel> PaginationSearch(int? startIndex,int? numberOfObject);
    WorkModel GetOne(string id);
    void Insert(WorkModel model);
    void Update(WorkModel model);
    void Delete(WorkModel model);
}
public class WorkService : IWorkService
{
    private readonly IWorkRepository _workRepository;
    private readonly IMapper _mapper;

    public WorkService(IWorkRepository workRepository, IMapper mapper)
    {
        _workRepository = workRepository;
        _mapper = mapper;
    }

/// <summary>
/// get all metoda
/// </summary>
/// <returns></returns>
    public List<WorkModel> GetAll()
    {
        var dataFromDb = _workRepository.GetAll();
        var listOfModel = _mapper.Map<List<WorkModel>>(dataFromDb);
        
        return listOfModel;
    }
/// <summary>
/// Total count method
/// </summary>
/// <returns></returns>
public long TotalCount()
{
    return _workRepository.NumberOfDocuments();
}

/// <summary>
/// pagination search
/// </summary>
/// <returns></returns>
    public List<WorkModel> PaginationSearch(int? startIndex,int? numberOfObject)
{
    if (startIndex is not { }) startIndex = 0;
    if (numberOfObject is not { }) numberOfObject = 10;
        
        
    var dataFromDb = _workRepository.PaginationSearch(startIndex,numberOfObject);
    var listOfModel = _mapper.Map<List<WorkModel>>(dataFromDb);
        
    return listOfModel;
    }

/// <summary>
/// get one metod
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public WorkModel GetOne(string id)
{
    var dataFromDb = _workRepository.GetOne(ObjectId.Parse(id));
    var model = _mapper.Map<WorkModel>(dataFromDb);
    return model;
}

public void Insert(WorkModel model)
{
    
    _workRepository.Insert(_mapper.Map<Work>(model));    
}

public void Update(WorkModel model)
{
    
    _workRepository.Update(_mapper.Map<Work>(model));
}

public void Delete(WorkModel model)
{
   
    _workRepository.Delete(_mapper.Map<Work>(model));
}
}