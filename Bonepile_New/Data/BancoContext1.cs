using Bonepile_New.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace Bonepile_New.Data;

public class BancoContext1:DbContext
{
    public BancoContext1(DbContextOptions<BancoContext1> options) : base(options)
    {
      
    }
    public DbSet<HistoryModel> rvwHistory { get; set; }
    public DbSet<Nickname> NickName { get; set; }
    public DbSet<PartNumber> Part_Number { get; set; }
    public DbSet<Relationship> Pn_NickName_Relationship { get; set; }
    public DbSet<CustomerDivision> Customer_Division { get; set; }
   
}

