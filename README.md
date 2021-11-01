# [ASP.NET Core](https://docs.microsoft.com/tr-tr/aspnet/core/) ile Blog

    dotnet new mvc
 komut satırıyla ile ASP.NET Core MVC projesi oluşturulmuştur.

    dotnet tool install --global dotnet-ef
    dotnet tool install -g dotnet-aspnet-codegenerator
[Entity Framework Core](https://docs.microsoft.com/tr-tr/ef/core/cli/dotnet) ve [ASPNET-CodeGenerator](https://docs.microsoft.com/tr-tr/aspnet/core/fundamentals/tools/dotnet-aspnet-codegenerator) araçları kullanılmıştır.

---
**Eklenen Paketler**

    dotnet add package Microsoft.EntityFrameworkCore.SqlServer
    dotnet add package Microsoft.EntityFrameworkCore.Design
    dotnet add package Microsoft.EntityFrameworkCore.Tools
    dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson
    dotnet add package Microsoft.VisualStudio.Web.CodeGeneration.Design
    dotnet add package Microsoft.AspNetCore.Identity.EntityFrameworkCore

---

    dotnet ef dbcontext scaffold "Server=ALPER\SQLEXPRESS; Database=BlogDB; Trusted_Connection=True; MultipleActiveResultSets=true;" Microsoft.EntityFrameworkCore.SqlServer -o "Models" --context-dir "Data" -c "BlogDbContext" --no-onconfiguring
Veritabanı modelleri oluşturulmuştur.

![MSSQL Database](https://lh3.googleusercontent.com/pw/AM-JKLXnfYjF8ueRtAWG_3Zll4eADNUS6gJHNaGVCsd8tuEP63LPbsNeQ3Oh0PO-R0cMGgB098bEMimCK0BifxYSb8-2NZIr9Z9b1pbyZbpupBqySvigCtr-qYs9jNbcsUUMsOoXsGwnKdBCTW1qDxEym3IV=w1171-h658-no?authuser=0)![homepage](https://lh3.googleusercontent.com/pw/AM-JKLVF38BbsYb1IQPOdFWX2K_aB9kjJ7abksto84dsxparTSp0fJiI7JG71uUBIl7ix8be9E7eWjp4_U06N5i4jR-jvfXFmCP1o-uMtaXk5RBpm3pifU46W9-d8J1MadeGfTI2qvX0NJRUpP6HhH-OIuyQ=w1171-h658-no?authuser=0)![blog](https://lh3.googleusercontent.com/pw/AM-JKLUrNEQN8Q5N9MTwar7_Ux_m2o04EPsRg2Oxc4EZAZBlwrULq321to7i2ez6fQvlMwLN1iJnNbK_ANcbVfmFohIums3b9wOcwItytfgFrkjKbhJ84C8B_DUrCL2_j4rjbvhGQwbfhW43Zaz_W2VNOQCr=w1282-h658-no?authuser=0)![login](https://lh3.googleusercontent.com/pw/AM-JKLWL3VFHkAF4qZdXfgXB0YumfmqkJQg6mCNLlb0Ck_IkE5y4DP36MRt5H69kKxqKnL4bUWhozdrt5purXkPbW5pXt9mRFdxbLFs25UURCUF4cl0gAsyF0_0RG0mnu6SpOxkURB0Sb7kXflB7As8XTsvg=w1171-h658-no?authuser=0)![admin](https://lh3.googleusercontent.com/pw/AM-JKLVqBM6o5hQDngjzQq2VMm18oYq1NOz77aKMjvQR2TAYGBt0mjchBF-2l4Ea5voU1ofNTSW4CBlPkQo8zBsA6rrFDLEgQ0yXJxb9fx_2-z3oI1qyXxW04Cd9opBcN50GDreFTzkav3HqXDTkWJ9VBgXG=w1171-h658-no?authuser=0)![admin detail](https://lh3.googleusercontent.com/pw/AM-JKLXdzxc8iykOkZsizyEYyycbsy5SXWYh5RjMpJwVrM7Uo9HOeaFSzy7xk18cBL2DaLieDta8DSX4yfdPa9E6OtGZcnirpenVG_3cBO6yZqYHLh9h-I42c-9j7bWOHYNDNRrKPW2Nzg1Kg4UUdmJgUb0V=w1171-h658-no?authuser=0)![blog new](https://lh3.googleusercontent.com/pw/AM-JKLUBBFbVMkg2Utec8_H-Bwvm5vrhg6tCzJ93q6yJV3UlKz4jb4uR_nAOgLraPRU_wluzz_m4KcTnwrcKo4zE8vrW-7np784-NTKofjbqGDefdWqmDpJUU8in8J7X4g_KtdN9mUcLBuUT4TyX2bW5vj2q=w1171-h658-no?authuser=0)![blog delete](https://lh3.googleusercontent.com/pw/AM-JKLUzwbPLFn7XuLwqFBaN4FkO3vfxQEXsjck9XmtBBwXzHZYiM8xb0bkLRFysbgU0zAJQSEzChmX5ITgFtXEYOds0-eRf8lA1XMwVf_LveMx9sdx3rOYTwULSTC068Au_PsFAZDcJ-lPvPbnfE7AujMAG=w1171-h658-no?authuser=0)![blog edit](https://lh3.googleusercontent.com/pw/AM-JKLXG4c46cWpP13nejHTOhWvfi3_JiRvcpRjnpcyiT6wKMi7c6ops-THQS3boJHVXBWAMei_9_-Zdi7h0zUcCpwhLISiCMYobhXdHXeqSh6CTziBeIHLvIy_xamaYce0XhOj_96gSxjmUMMw87DDXssnt=w1171-h658-no?authuser=0)