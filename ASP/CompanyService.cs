public class CompanyService
{
    private readonly IConfiguration _configuration;

    public CompanyService(IConfiguration configuration)
    {
        _configuration = configuration;
    }
    public string GetCompanyWithMostEmployees()
    {
        var companies = _configuration.GetSection("Companies").Get<List<Company>>();
        if (companies == null || companies.Count == 0)
        {
            return "No companies found in configuration.";
        }
        Company companyWithMostEmployees = companies.OrderByDescending(c => c.NumberOfEmployees).First();
        return $"Company with most employees: {companyWithMostEmployees.Name}";
    }
}