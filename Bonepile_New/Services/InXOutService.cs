//using Bonepile_New.Data;
//using Bonepile_New.Models;
//using Microsoft.EntityFrameworkCore;

//namespace Bonepile_New.Services;

//public class InXOutService
//{
//    private readonly BancoContext _context;

//    public InXOutService(BancoContext context)
//    {
//        _context = context;     
//    }

//    public async Task<List<PcbModel>> GetInxOut()
//    {
//        var dataAtual = DateTime.Today;
//        var inxOut = await _context.UDTBONE_HISTORICO_OUT
//            //.AsNoTracking()
//            //.Where(x=>x.Entrada >= dataAtual)
//            .ToListAsync();

        //var bor = await _context.UDTBONE_HISTORICO_OUT_BOR_TEST
        //    .AsNoTracking()
        //    .Where(x => x.Entrada >= dataAtual)
        //    .ToListAsync();
        //var confirm = await _context.UDTBONE_HISTORICO_OUT_CONFIRM_TEST
        //    .AsNoTracking()
        //    .Where(x => x.Entrada >= dataAtual)
        //    .ToListAsync();

        //var result = from o in inxOut
        //             join b in bor
        //             on o.Cliente equals b.Cliente
        //             join c in confirm
        //             on o.Cliente equals c.Cliente

        //             group o by o.Cliente into full

        //             select new
        //             {
        //                 Cliente = full.Key,
        //                 qt = full.Count()
        //             };

       // return (List<PcbModel>)result;
//       return inxOut;
//    }
//}
