var builder = WebApplication.CreateBuilder();
builder.Services.AddSingleton<CompanyService>();
builder.Configuration.AddXmlFile("companies.xml");
builder.Configuration.AddJsonFile("companies.json");
builder.Configuration.AddIniFile("companies.ini");
builder.Configuration.AddJsonFile("profile.json");

var app = builder.Build();

app.Map("/", (CompanyService companyService, IConfiguration configuration) =>
{
    var companyInfo = companyService.GetCompanyWithMostEmployees();

    var profileName = configuration["Name"];
    var profileSurname = configuration["Surname"];
    var profileAge = configuration.GetValue<int>("Age");
    var profileBirthDay = configuration["BirthDay"];

    return $@"
        {companyInfo}
        Name: {profileName}
        Surname: {profileSurname}
        Age: {profileAge}
        Birth: {profileBirthDay}
    ";
});

app.Run();
