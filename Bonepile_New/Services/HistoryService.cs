using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace Bonepile_New.Services;

public class HistoryService
{
    private readonly BancoContext1 _bancoContext1;
    private readonly BancoContext _bancoContext;

    public HistoryService(BancoContext1 bancoContext1,BancoContext bancoContext)
    {
        _bancoContext1 = bancoContext1;
        _bancoContext = bancoContext;
    }



    //public async Task<HistoryModel> GetInfos(string serial)
    //{

    //    var resultado = await _bancoContext1.rvwHistory
    //       .AsNoTracking()

    //       .FirstOrDefaultAsync(x => x.Serialnumber == serial);


    //    return resultado;



    ////}
    //public async Task<InfoPlacas> GetInfos(string serial_number)
    //{

    //    var resultado3 = await _bancoContext.InfoPlacas
    //      .FromSqlRaw("EXEC db_owner.UDTBONE_Get_Infos_Placas @serial_number", new SqlParameter("@serial_number", serial_number))
    //      .ToListAsync();



       
    //     var resultado = await _bancoContext.InfoPlacas.ToListAsync();

    //      return resultado;

    //}


    //resultado = await historyService.GetInfos(serial);
    //mostrarModalEntrada = resultado != null;

    //var history = await bancoContext1.rvwHistory
    //    .Where(x=>x.Partnumber == resultado.Partnumber)
    //    .ToListAsync();
    //var nick = await bancoContext1.NickName.ToListAsync();
    //var part = await bancoContext1.Part_Number.ToListAsync();
    //var rel = await bancoContext1.Pn_NickName_Relationship.ToListAsync();
    //var customer = await bancoContext1.Customer_Division.ToListAsync(); 


    //var teste = from h in history
    //            join p in part
    //            on h.Partnumber equals p.Name

    //            join s in rel
    //            on p.Id equals s.Part_Number_Id

    //            join n in nick
    //             on s.NickName_Id equals n.Id

    //             join c in customer
    //             on h.CustomerDivisionId equals c.Id

    //            //where(h.Partnumber == resultado.Partnumber) 

    //            select new
    //            {
    //                Partnumber = h.Partnumber,
    //                Modelo = n.Name,
    //                Cliente = c.Name,
    //            };
}
