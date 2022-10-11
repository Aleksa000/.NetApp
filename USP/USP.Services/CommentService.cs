using AutoMapper;
using MongoDB.Bson;
using USP.Data;
using USP.Models;
using USP.Repositories;

namespace USP.Services;

public interface ICommentService
{
    List<CommentModel> GetAll();
    CommentModel GetOne(string id);
    void Insert(CommentModel model);
    void Update(CommentModel model);
    void Delete(CommentModel model);
}
public class CommentService : ICommentService
{
    private readonly ICommentRepository commentRepository;
    private readonly IMapper _mapper;

    public CommentService(ICommentRepository commentRepository, IMapper mapper)
    {
        this.commentRepository = commentRepository;
        _mapper = mapper;
    }

    /// <summary>
    /// get all metoda
    /// </summary>
    /// <returns></returns>
    public List<CommentModel> GetAll()
    {
        var dataFromDb = commentRepository.GetAll();
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
        var dataFromDb = commentRepository.GetOne(ObjectId.Parse(id));
        var model = _mapper.Map<CommentModel>(dataFromDb);
        return model;
    }

    public void Insert(CommentModel model)
    {
    
        commentRepository.Insert(_mapper.Map<Comment>(model));
    }

    public void Update(CommentModel model)
    {
     
        commentRepository.Update(_mapper.Map<Comment>(model));
    }

    public void Delete(CommentModel model)
    {
   
        commentRepository.Delete(_mapper.Map<Comment>(model));
    }
}