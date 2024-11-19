using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL.Repositories;

public interface IAddressRepository : IRepository<Address> { }
public interface ICityRepository : IRepository<City> { }
public interface IRegionRepository : IRepository<Region> { }
public interface ICountryRepository : IRepository<Country> { }

public class AddressRepository : RepositoryBase<Address>, IAddressRepository
{
    public AddressRepository(DbContext context) : base(context) { }
}

public class CityRepository : RepositoryBase<City>, ICityRepository
{
    public CityRepository(DbContext context) : base(context) { }
}

public class RegionRepository : RepositoryBase<Region>, IRegionRepository
{
    public RegionRepository(DbContext context) : base(context) { }
}

public class CountryRepository : RepositoryBase<Country>, ICountryRepository
{
    public CountryRepository(DbContext context) : base(context) { }
}