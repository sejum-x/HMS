using AutoMapper;
using BLL.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public interface IGenderService
{
    Task<IEnumerable<GenderModel>> GetAllGendersAsync();
    Task AddGenderAsync(GenderModel genderModel);
    Task UpdateGenderAsync(Guid genderId, string newName);
    Task DeleteGenderAsync(Guid genderId);
}

public class GenderService : IGenderService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public GenderService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    public async Task<IEnumerable<GenderModel>> GetAllGendersAsync()
    {
        var genders = await _unitOfWork.Genders.GetAllAsync();
        return _mapper.Map<IEnumerable<GenderModel>>(genders);
    }

    public async Task AddGenderAsync(GenderModel genderModel)
    {
        var gender = _mapper.Map<Gender>(genderModel);

        await _unitOfWork.Genders.AddAsync(gender);
        await _unitOfWork.SaveChangesAsync();
    }


    public async Task UpdateGenderAsync(Guid genderId, string newName)
    {
        var gender = await _unitOfWork.Genders.GetByIdAsync(genderId);
        if (gender == null) throw new KeyNotFoundException("Gender not found.");

        gender.Name = newName;
        _unitOfWork.Genders.Update(gender);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteGenderAsync(Guid genderId)
    {
        await _unitOfWork.Genders.DeleteByIdAsync(genderId);
        await _unitOfWork.SaveChangesAsync();
    }
}