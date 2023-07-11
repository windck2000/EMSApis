using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using EMSApi.Dbcontext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Mvc;
using EMSApi.Tool;


var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(optis =>
optis.AddPolicy(name: MyAllowSpecificOrigins,
builder =>
{
    builder.WithOrigins("http://106.55.190.224:82", "http://localhost:5296")
    .AllowAnyMethod()
    .AllowAnyHeader();
}));

// Add services to the container.
builder.Services
    .AddAuthorization()
    .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(JwtBearerDefaults.AuthenticationScheme,options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,//是否验证Issuer
                ValidateAudience = true,//是否验证Audience
                ValidateLifetime = true,//是否验证失效时间
                ValidateIssuerSigningKey = true,//是否验证SecurityKey
                ValidAudience = "guetClient",//Audience
                ValidIssuer = "guetServer",//Issuer，这两项和签发jwt的设置一致
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("123456789012345678901234567890123456789"))//拿到SecurityKey
            };
        });
builder.Services.AddDbContext<Emscontext>(options => options.UseSqlServer("name = ConnectionStrings:sqlsever"));
var app = builder.Build();
app.UseCors(MyAllowSpecificOrigins);
app.UseAuthentication();
app.UseAuthorization();
// Configure the HTTP request pipeline.


app.MapGet("/getaccount", async (Emscontext emscontext) =>
{
    var data = await emscontext.accounts.ToListAsync();
    return data.Select(x => new Account() {Id = x.Id, Name = x.Name, Email = x.Email, CreationDate = x.CreationDate, permission = x.permission, Accounts = x.Accounts,Gender = x.Gender,Position = x.Position,Department = x.Department,Avatar = x.Avatar });
});

app.MapPost("/Login",async (Emscontext emscontext, LoginDto logindto) =>
{
    var pas =  Tool.Createmd5(logindto.Password).Result;
    var data = await emscontext.accounts.Where(x => x.Accounts == logindto.UserName && x.Password == pas).ToListAsync();
    if (data.Count == 1)
    {
        var query = from permissioncs in emscontext.Permissioncs
                    join emscontexts in emscontext.accounts
                    on permissioncs.PermissioncsName equals emscontexts.permission
                    select permissioncs;
        var jwtToken = await GetToken.GetToke(data[0].Accounts, data[0].permission, query.Distinct().ToList());

        

        return new UserDto() { Name = data[0].Accounts, Token = jwtToken ,Email = data[0].Email,Avatar = data[0].Avatar,Permissioncs = query.Distinct().ToList() };
    }
    else
    {
        return new UserDto() { Name = null, Token = null,Email = null};
    }
});
app.MapPost("/addapplication",async (Emscontext emscontext,[FromBody] AccountApplication account) =>
{
    account.Password = Tool.Createmd5(account.Password).Result;
    account.State = "R";
    await  emscontext.accountApplications.AddAsync(account);
   return emscontext.SaveChangesAsync();
});
app.MapDelete("/deletepermissioncs", (Emscontext emscontext, [FromBody] Permissioncs permissioncs)=>
{
    emscontext.Permissioncs.Remove(permissioncs);
    return emscontext.SaveChangesAsync();
});
app.MapGet("/getpermissioncs", async(Emscontext emscontext) =>
{
    return  await emscontext.Permissioncs.Select(x => x.PermissioncsName).ToListAsync();
});
app.MapGet("/getoisition",async(Emscontext emscontext)=>
{
    return await emscontext.positions.ToListAsync();
});
app.MapPut("/deleteaccount", async (Emscontext emscontext, Account account) =>
{
    emscontext.accounts.Remove(account);
    return await emscontext.SaveChangesAsync();
});
app.MapPut("/putaccount", async (Emscontext emscontext,[FromBody] Account account ) =>
{
 var accont =  await emscontext.accounts.Where(x=>x.Id == account.Id).FirstAsync();
    accont.permission = account.permission;
    accont.Department = account.Department;
    accont.Email = account.Email;
    accont.Gender = account.Gender;
    accont.Name =account.Name;
    accont.Position = account.Position;
    return await emscontext.SaveChangesAsync();
});
app.MapGet("/getaccountapplication",async (Emscontext emscontext) =>
{
   return await emscontext.accountApplications.ToListAsync();
});
app.MapPut("/putpassapplication", async (Emscontext emscontext,AccountApplication account) =>
{
   var msg =  emscontext.accountApplications.Update(account);
   await emscontext.accounts.AddAsync(new Account {Accounts = account.Account,CreationDate = account.UpdateDateTime,Department="NULL",Email=account.Email,Gender = "未知",Name = account.Name,Password = account.Password,permission = "NULL",Position ="NULL"});
   return emscontext.SaveChangesAsync();
});
app.MapPut("/putrefuseapplication",(Emscontext emscontext,AccountApplication account) =>
{
    emscontext.Update(account);
    return emscontext.SaveChangesAsync();
});
app.MapGet("/getmodelconfiguration", (Emscontext emscontext) =>
{
   return emscontext.modelConfigurations.ToListAsync();
});
app.MapGet("/gettestitem", (Emscontext emscontext) =>
{
    return emscontext.testItems.ToListAsync();
});
app.MapGet("/gettestmodel", (Emscontext emscontext) =>
{
    return emscontext.models.ToListAsync();
});
app.MapPost("/addtestitem",async (Emscontext emscontext,TestItem testItem) =>
{
    await emscontext.testItems.AddAsync(testItem);
    return  emscontext.SaveChangesAsync();
});
app.MapPost("/deletetestitem", async (Emscontext emscontext,TestItem test) =>
{
    emscontext.modelConfigurations.RemoveRange(emscontext.modelConfigurations.Where(x => x.ModelName == test.Identifier && x.TestItem == test.TestName));
  return  await emscontext.SaveChangesAsync();
});
app.MapPost("/addmodel", async (Emscontext emscontext,Model model) =>
{
   await emscontext.models.AddAsync(model);
    return emscontext.SaveChangesAsync();
});
app.MapPost("/deletemodel", async (Emscontext emscontext,[FromBody]Model model) =>
{
    emscontext.models.RemoveRange(await emscontext.models.Where(x=>x.ModelName == model.ModelName).ToListAsync());
    return await emscontext.SaveChangesAsync();
});
app.MapPost("/deletemodelitem", async (Emscontext emscontext,[FromBody]Model model) =>
{
    emscontext.modelConfigurations.RemoveRange(await emscontext.modelConfigurations.Where(x => x.ModelName == model.ModelName).ToListAsync());
    return await emscontext.SaveChangesAsync();
});
app.MapPost("/addmodelconfin",(Emscontext emscontetext,ModelConfiguration model) =>
{
    if (!(emscontetext.modelConfigurations.Where(x=>x.ModelName == model.ModelName).Where(x=>x.TestItem == model.TestItem).Count() >= 1))
    {
        emscontetext.modelConfigurations.Add(model);
        emscontetext.SaveChangesAsync();
        return "OK";
    }
    else
    {
        return "測試項目已添加";
    }
});
app.MapPost("/deletemodelconfin", (Emscontext emscontext,ModelConfiguration modelConfiguration) =>
{
   var modelConfigurations = emscontext.modelConfigurations.Where(x=>x.ModelName == modelConfiguration.ModelName).Where(x=>x.TestItem == modelConfiguration.TestItem).ToList();
    foreach (var item in modelConfigurations)
    {
        emscontext.modelConfigurations.Remove(item);
    }
    return emscontext.SaveChangesAsync();
});
app.MapGet("/gettestproject", (Emscontext emscontext) =>
{
    return emscontext.testProjects.ToListAsync();
});
app.MapPost("/gettestprojectmodel",async (Emscontext emscontext,[FromBody]string v) =>
{
  return await emscontext.testProjectModes.Where(x => x.ProjectNo == v).ToListAsync();
});
app.MapGet("/gettestprojectmodels", async (Emscontext emscontext) =>
{
    return await emscontext.testProjectModes.ToListAsync();
});
app.MapPost("/addtestproject", async (Emscontext emscontext,TestProject testProject) =>
{
    if (!(emscontext.testProjects.Where(x => x.ProjectNo == testProject.ProjectNo).Count() > 0))
    {
        await emscontext.testProjects.AddAsync(testProject);
        await emscontext.SaveChangesAsync();
        return "OK";
    }
    else
    {
        return "項目已存在";
    }
});
app.MapPost("/deletetestproject", (Emscontext emscontext,TestProject testProject) =>
{
    emscontext.testProjects.Remove(testProject);
    return emscontext.SaveChangesAsync();
});
app.MapGet("/gettestequioment", (Emscontext  emscontext) =>
{
    return emscontext.testEquipment.ToListAsync();
});
app.MapPost("/getmodelconfigurations", (Emscontext emscontext,[FromBody]string v) =>
{
   return  emscontext.modelConfigurations.Where(x => x.ModelName == v).ToListAsync();
});
app.MapGet("/", (HttpContext context) => 
{
    return context.Connection.LocalIpAddress.ToString();
});
app.MapPost("/addtestequioment",async (Emscontext emscontext,[FromBody]TestEquipment testEquipment) =>
{
    if (emscontext.testEquipment.ContainsAsync(testEquipment).Result)
    {
        return "0";
    }
    else
    {
      await  emscontext.testEquipment.AddAsync(testEquipment);
      await  emscontext.SaveChangesAsync();
       return "1";
    }

});
app.MapPut("/putequiomentrepair", (Emscontext emscontext,TestEquipment test) =>
{
    emscontext.testEquipment.Update(test);
    return emscontext.SaveChangesAsync();
});
app.MapPost("/deletetestqyiomentrepair", (Emscontext emscontext, [FromBody] TestEquipment test) =>
{
    emscontext.testEquipment.Remove(test);
    return emscontext.SaveChangesAsync();
});
app.MapPost("/addtestprojectmode",async (Emscontext emscontext,[FromBody] List<TestProjectMode> testProjectModes) =>
{
   await emscontext.testProjectModes.AddRangeAsync(testProjectModes);
   await  emscontext.SaveChangesAsync();
});
app.MapPut("/updatetestprojectmode",async (Emscontext emscontext,List<TestProjectMode> testProjectMode) =>
{
    emscontext.testProjectModes.UpdateRange(testProjectMode);
  await  emscontext.SaveChangesAsync();
});
app.MapPost("/deletetestprojectmode",async (Emscontext emscontext, string[] strins) =>
{
    if (strins[3] == "y")
    {
        var d = await emscontext.testProjectModes.Where(x => x.ProjectNo == strins[2] && x.TestMode == strins[0]).ToListAsync();
        emscontext.testProjectModes.RemoveRange(d);
    }
    else
    {
        var d = await emscontext.testProjectModes.Where(x => x.ProjectNo == strins[2] && x.TestMode == strins[0]&&x.TestItem == strins[1]).ToListAsync();
        emscontext.testProjectModes.RemoveRange(d);
    }
   await emscontext.SaveChangesAsync();
});
app.MapPut("/puttestproject", async (Emscontext emscontext,TestProject testProject) =>
{
    emscontext.testProjects.Update(testProject);
    await emscontext.SaveChangesAsync();
});
app.MapPost("/deleteprojectmode", async (Emscontext emscontext, [FromBody] string v) =>
{
    var d = await emscontext.testProjectModes.Where(x => x.ProjectNo == v).ToListAsync();
    emscontext.testProjectModes.RemoveRange(d);
    await emscontext.SaveChangesAsync();
});
app.MapGet("/getsetting", async (Emscontext emscontext) =>
{
    return await emscontext.settings.ToListAsync();

});
app.MapPost("/updatesetting", async (Emscontext emscontext,[FromBody] List<Setting> setting) =>
{
    emscontext.settings.UpdateRange(setting);
   return await emscontext.SaveChangesAsync();
});
app.MapPost("/addfunctions", async (Emscontext emscontext, [FromBody] Functions functions) =>
{
  await  emscontext.AddAsync(functions);
  return await  emscontext.SaveChangesAsync();
});
app.MapGet("/getfunctions",  async (Emscontext emscontext) =>
{
   return await   emscontext.Functions.ToListAsync();
});
app.MapGet("/getpermissioncss",  async (Emscontext emscontext) =>
{
   return await  emscontext.Permissioncs.ToListAsync();
});
app.MapPost("/addfile",async (HttpContext httpContext,Emscontext emscontext) =>
{
    string part = "C:\\temp\\";
        var formFile = httpContext.Request.Form.Files;
    if (Directory.Exists(part))
    {
        Directory.CreateDirectory(part);
    }
        foreach (var item in formFile)
        {
            var nuiqueFileName = Path.GetRandomFileName();
            
            var nuiqueFilePath = Path.Combine(part, nuiqueFileName);
            using (var stream = System.IO.File.Create(nuiqueFilePath))
            {
                await item.CopyToAsync(stream);
            }
        }
});
app.MapPost("/addpermissioncs",  (Emscontext emscontext,Permissioncs permissioncs) =>
{
    if (emscontext.Permissioncs.Count(x => x.PermissioncsName == permissioncs.PermissioncsName && x.FunctionsRemarks == permissioncs.FunctionsRemarks && x.PermissioncsDescription == permissioncs.PermissioncsDescription) == 0)
    {
        permissioncs.Id = emscontext.Permissioncs.Count() == 0 ? 1: emscontext.Permissioncs.Max(x => x.Id) + 1;
        emscontext.Add(permissioncs);
    }
    return emscontext.SaveChanges();
});
app.MapPost("/deletepermissioncs", (Emscontext emscontext, Permissioncs permissioncs) =>
{
    emscontext.Permissioncs.Remove(permissioncs);
    return emscontext.SaveChanges();
});
app.MapGet("/getdepartments", async (Emscontext emscontext) =>
{
    return  await emscontext.departments.ToListAsync();
});
app.MapPost("/adddepartments", async (Emscontext emscontext, Departments departments) =>
{
    await  emscontext.departments.AddAsync(departments);
    return emscontext.SaveChanges();
});
app.MapPost("/deletedepartments",  (Emscontext emscontext, Departments departments) =>
{
    var data = emscontext.departments.Where(x => x.DepartmentsName == departments.DepartmentsName);
    emscontext.departments.RemoveRange(data);
    return emscontext.SaveChanges();
});
app.MapPost("/deletealldepartments", (Emscontext emscontext,  Departments[] departments) =>
{
    emscontext.departments.RemoveRange(departments);
    return emscontext.SaveChanges();
});
app.Run();



public class LoginDto
{
    public string UserName { get; set; }
    public string Password { get; set; }
}
public class UserDto
{
    public string Name { get; set; }
    public string Token { get; set; }

    public string Avatar { get; set; }

    public string Email { get; set; }

    public List<Permissioncs> Permissioncs { get; set; }
}

public static class GetToken
{
    public static async Task <string> GetToke(string name,string role,List<Permissioncs> permissioncs)
    {
        var claims = new Claim[]
        {
            new Claim(ClaimTypes.Name,name),
            new Claim(ClaimTypes.Role,role),
            new Claim("Power",await JsonContent.Create(permissioncs).ReadAsStringAsync())
        };

        var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("123456789012345678901234567890123456789"));
        var expires = DateTime.Now.AddDays(1);
        var token = new JwtSecurityToken(
            issuer: "guetServer",
            audience: "guetClient",
            claims: claims,
            notBefore: DateTime.Now,
            expires: expires,
            
            signingCredentials: new SigningCredentials(key, SecurityAlgorithms.HmacSha256));

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

   
}

