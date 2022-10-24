using AutoMapper;
using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface ICommentService
{
    List<CommentModel> GetAll();
    long TotalCount ();
    List<CommentModel> PaginationSearch(int? startIndex,int? numberOfObject);
    CommentModel GetOne(string id);
    void Insert(CommentModel model);
    void Update(CommentModel model);
    void Delete(CommentModel model);
}
public class CommentService : ICommentService
{
    private readonly ICommentRepository _commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        _commentRepository = commentRepository;
        _mapper = mapper;
    }

/// <summary>
/// get all metoda
/// </summary>
/// <returns></returns>
    public List<CommentModel> GetAll()
    {
        var dataFromDb = _commentRepository.GetAll();
        var listOfModel = _mapper.Map<List<CommentModel>>(dataFromDb);
        
        return listOfModel;
    }
/// <summary>
/// Total count method
/// </summary>
/// <returns></returns>
public long TotalCount()
{
    return _commentRepository.NumberOfDocuments();
}

/// <summary>
/// pagination search
/// </summary>
/// <returns></returns>
    public List<CommentModel> PaginationSearch(int? startIndex,int? numberOfObject)
{
    if (startIndex is not { }) startIndex = 0;
    if (numberOfObject is not { }) numberOfObject = 10;
        
        
    var dataFromDb = _commentRepository.PaginationSearch(startIndex,numberOfObject);
    var listOfModel = _mapper.Map<List<CommentModel>>(dataFromDb);
        
    return listOfModel;
    }

/// <summary>
/// get one metod
/// </summary>
/// <param name="id"></param>
/// <returns></returns>
public CommentModel GetOne(string id)
{
    var dataFromDb = _commentRepository.GetOne(ObjectId.Parse(id));
    var model = _mapper.Map<CommentModel>(dataFromDb);
    return model;
}

public void Insert(CommentModel model)
{
    
    _commentRepository.Insert(_mapper.Map<Comment>(model));    
}

public void Update(CommentModel model)
{
    
    _commentRepository.Update(_mapper.Map<Comment>(model));
}

public void Delete(CommentModel model)
{
   
    _commentRepository.Delete(_mapper.Map<Comment>(model));
}
}