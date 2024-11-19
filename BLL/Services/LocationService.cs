using AutoMapper;
using Business.Models;
using DAL.Entities;
using DAL.Interfaces;

namespace BLL.Services;

public interface ILocationService
{
    // Отримання
    Task<IEnumerable<CountryModel>> GetAllCountriesAsync();
    Task<IEnumerable<RegionModel>> GetRegionsByCountryIdAsync(Guid countryId);
    Task<IEnumerable<CityModel>> GetCitiesByRegionIdAsync(Guid regionId);
    Task<IEnumerable<AddressModel>> GetAddressesByCityIdAsync(Guid cityId);

    // Додавання
    Task AddCountryAsync(CountryModel countryModel);
    Task AddRegionAsync(RegionModel regionModel, Guid countryId);
    Task AddCityAsync(CityModel cityModel, Guid regionId);
    Task AddAddressAsync(AddressModel addressModel, Guid cityId);

    // Видалення
    Task DeleteCountryAsync(Guid countryId);
    Task DeleteRegionAsync(Guid regionId);
    Task DeleteCityAsync(Guid cityId);
    Task DeleteAddressAsync(Guid addressId);
}

public class LocationService : ILocationService
{
    private readonly IUnitOfWork _unitOfWork;
    private readonly IMapper _mapper;

    public LocationService(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _unitOfWork = unitOfWork;
        _mapper = mapper;
    }

    // Отримання
    public async Task<IEnumerable<CountryModel>> GetAllCountriesAsync()
    {
        var countries = await _unitOfWork.Countries.GetAllAsync();
        return _mapper.Map<IEnumerable<CountryModel>>(countries);
    }

    public async Task<IEnumerable<RegionModel>> GetRegionsByCountryIdAsync(Guid countryId)
    {
        var regions = await _unitOfWork.Regions.FindAsync(r => r.CountryId == countryId);
        return _mapper.Map<IEnumerable<RegionModel>>(regions);
    }

    public async Task<IEnumerable<CityModel>> GetCitiesByRegionIdAsync(Guid regionId)
    {
        var cities = await _unitOfWork.Cities.FindAsync(c => c.RegionId == regionId);
        return _mapper.Map<IEnumerable<CityModel>>(cities);
    }

    public async Task<IEnumerable<AddressModel>> GetAddressesByCityIdAsync(Guid cityId)
    {
        var addresses = await _unitOfWork.Addresses.FindAsync(a => a.CityId == cityId);
        return _mapper.Map<IEnumerable<AddressModel>>(addresses);
    }

    // Додавання
    public async Task AddCountryAsync(CountryModel countryModel)
    {
        var country = _mapper.Map<Country>(countryModel);
        await _unitOfWork.Countries.AddAsync(country);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddRegionAsync(RegionModel regionModel, Guid countryId)
    {
        var region = _mapper.Map<Region>(regionModel);
        region.CountryId = countryId;
        await _unitOfWork.Regions.AddAsync(region);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddCityAsync(CityModel cityModel, Guid regionId)
    {
        var city = _mapper.Map<City>(cityModel);
        city.RegionId = regionId;
        await _unitOfWork.Cities.AddAsync(city);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task AddAddressAsync(AddressModel addressModel, Guid cityId)
    {
        var address = _mapper.Map<Address>(addressModel);
        address.CityId = cityId;
        await _unitOfWork.Addresses.AddAsync(address);
        await _unitOfWork.SaveChangesAsync();
    }

    // Видалення
    public async Task DeleteCountryAsync(Guid countryId)
    {
        await _unitOfWork.Countries.DeleteByIdAsync(countryId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteRegionAsync(Guid regionId)
    {
        await _unitOfWork.Regions.DeleteByIdAsync(regionId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteCityAsync(Guid cityId)
    {
        await _unitOfWork.Cities.DeleteByIdAsync(cityId);
        await _unitOfWork.SaveChangesAsync();
    }

    public async Task DeleteAddressAsync(Guid addressId)
    {
        await _unitOfWork.Addresses.DeleteByIdAsync(addressId);
        await _unitOfWork.SaveChangesAsync();
    }
}
