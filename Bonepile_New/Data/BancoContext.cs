using Bonepile_New.Models;
using Microsoft.EntityFrameworkCore;


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
   
   


}
