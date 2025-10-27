using Bonepile_New.Models;
using Bonepile_New.Pages;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;


namespace Bonepile_New.Data;

public class BancoContext : DbContext
{
    public BancoContext(DbContextOptions<BancoContext> options) : base(options) { }

    public DbSet<BonePileModel> UDTLOOK_UP_BONE_GERAL_HISTORICO1 { get; set; }
    public DbSet<BonepileChartModel> UDTLOOK_UP_BONE_GERAL_HISTORICO_CHART { get; set; }
    public DbSet<BoneInModel> UDTBONE_PLACAS_IN_BONE { get; set; }
    public DbSet<BorInModel> UDTBONE_PLACAS_IN_BOR_TEST { get; set; }
    public DbSet<ConfirmInModel> UDTBONE_PLACAS_IN_CONFIRM_TEST { get; set; }
    public DbSet<BorOutModel> UDTBONE_HISTORICO_OUT_BOR_TEST { get; set; }
    public DbSet<BoneOutModel> UDTBONE_HISTORICO_OUT { get; set; }
    public DbSet<ConfirmOutModel> UDTBONE_HISTORICO_OUT_CONFIRM_TEST { get; set; }
    public DbSet<HardRepairModel> UDTHARD_REPAIR_BASE_PLACAS { get; set; }
    public DbSet<Armario_BoneModel> UDTBONE_GERAR_ARMARIO_IN_BONE_PILE { get; set; }
    public DbSet<InfoPlacas> InfoPlacas { get; set; }
    public DbSet<GetValor> GetValor { get; set; }
    public DbSet<BonepileArmario> UDTBONE_BONE_PILE_ARMARIO { get; set; }



    public async Task AdicionarProdutoAsync(BoneInModel model) =>
          await Database.ExecuteSqlRawAsync("EXEC db_owner.UDTBONE_Entrada_de_Placa_New  @serial, @cliente,@part,@modelo,@local,@acao,@falha,@valor",
            new[]
            {
                new SqlParameter("@serial",model.Serial_Number),
                new SqlParameter("@cliente",model.Cliente),
                new SqlParameter("@part",model.Part_Number),
                new SqlParameter("@modelo",model.Modelo),
                new SqlParameter("@local",model.Local.ToUpper()),
                new SqlParameter("@acao",model.Acao),
                new SqlParameter("@falha",model.Falha),
                new SqlParameter("@valor",model.Valor),
            
            });

    public async Task AdicionarProdutoListaAsync(List<BoneInModel> model)
    {
        foreach (var item in model)
        {


          await Database.ExecuteSqlRawAsync("EXEC db_owner.UDTBONE_Entrada_de_Placa_New   @serial, @cliente,@part,@modelo,@local,@acao,@falha,@valor",
            new[]
            {

                    new SqlParameter("@serial",item.Serial_Number),
                    new SqlParameter("@cliente",item.Cliente),
                    new SqlParameter("@part",item.Part_Number),
                    new SqlParameter("@modelo",item.Modelo),
                    new SqlParameter("@local",item.Local.ToUpper()),
                    new SqlParameter("@acao",item.Acao),
                    new SqlParameter("@falha",item.Falha),
                    new SqlParameter("@valor",item.Valor),

            });
        }

    }
    

    public async Task ExcluirProdutoAsync(BoneOutModel model) =>

      await Database.ExecuteSqlRawAsync("EXEC db_owner.UDTBONE_Saida_de_Placa1  @local,@serial,@part,@cliente,@modelo,@conclusao,@falha,@entrada,@aging,@valor",
        new[]
        {
                new SqlParameter("@local",model.Local.Trim()),
                new SqlParameter("@serial",model.Serial_Number),
                new SqlParameter("@part",model.Part_Number),           
                new SqlParameter("@cliente",model.Cliente),
                new SqlParameter("@modelo",model.Modelo),
                new SqlParameter("@conclusao",model.Acao),
                new SqlParameter("@falha",model.Falha),
                new SqlParameter("@entrada",model.Entrada),
                new SqlParameter("@aging",model.Aging),
                new SqlParameter("@valor",model.Valor),
        

        });



    public async Task UpdateProdutoAsync(BoneInModel model) =>

      await Database.ExecuteSqlRawAsync("EXEC db_owner.UDTBONE_AtualizaStatus_de_Placa_New  @serial,@local,@acao",
        new[]
        {
                new SqlParameter("@serial",model.Serial_Number),
                new SqlParameter("@local",model.Local.Trim()),
                new SqlParameter("@acao",model.Acao),
        });


    public async Task<List<BoneInModel>> GetBoneIn(DateTime dataInicio, string serialnumber, string client, string accao)
    {
        new SqlParameter("@dataInicio", dataInicio);
        new SqlParameter("@serialnumber", serialnumber);
        new SqlParameter("@client", client);
        new SqlParameter("@accao", accao);

        return await UDTBONE_PLACAS_IN_BONE
            .FromSqlRaw("EXEC db_owner.UDTBONE_PLACAS_IN_BONE_GET  @dataInicio,@serialnumber,@client,@accao", dataInicio, serialnumber, client, accao)
            .ToListAsync();

    }

    public async Task BuscaInfo(string serial_number)
    {

        var resultado3 =  InfoPlacas
        .FromSqlRaw("EXEC db_owner.UDTBONE_Get_Infos_Placas @serial_number", new SqlParameter("@serial_number", serial_number))
        .ToListAsync();

        







    }
}
               




