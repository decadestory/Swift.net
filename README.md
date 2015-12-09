# Swift.Net
This Is A Light-Weight And Fast-Develop .Net Framework.
# Usage
### STEP 1 Create Your Entities

```
public class DemoEntity : BaseEntity
{
  public int Id { get; set; }
  public string Name { get; set; }
  public string Phone { get; set; }
  public string Nric { get; set; }
  public int Age { get; set; }
  public float Height { get; set; }
  public int? Sex { get; set; }
}
```
### STEP 2 Create The Mapper
Put this Mappers into the Mapper Directory which In Entity Project. 

```
public class DemoEnityMapper : BaseMap<DemoEntity>
   {
       public override void Init()
       {
          ToTable("DemoEntity");
          HasKey(m => m.Id);
       }

   }
```
### STEP 3 Create The Resposity
```
public class DemoResp : BaseRep<DemoEntity>
{

}
```
### STEP 4 Create The Service
```
public class DemoSvc : BaseSvc<DemoEntity>
{
  DemoResp dr = new DemoResp();
  public int AddEntity(DemoEntity obj)
  {
    return Add(obj);
  }
}
```
### STEP 5 So,We Test

Now We Just Config This:
```
<connectionStrings>
  <add name="DbConnection" connectionString="Data Source=.;Initial Catalog=SwiftNet;User ID=sa;Password=sa"
  providerName="System.Data.SqlClient" />
</connectionStrings>
```
And This:
```
<appSettings>
  <!--实体程序集名称-->
  <add key="SwiftEntityAssembly" value="Swift.Demo.Entity"/>
  <!--是否自动创建数据库,此配置可以省略，省略则默认创建数据库-->
  <add key="SwiftCreateDb" value="true"/>
</appSettings>
```
Now,Test:
```
public void TestMethod1()
{
  var svc = new DemoSvc();
  var obj = new DemoEntity {
                Name = "jerry",
                Nric = "32148461641649616",
                Phone = "189615645",
                Age = 1111,
                Height = 234,
                Sex = 1,
                Remark = "这是一个备注",
            };
  var res = svc.AddEntity(obj);
}
```
