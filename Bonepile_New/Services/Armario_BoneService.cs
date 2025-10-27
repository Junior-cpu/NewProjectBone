using Bonepile_New.Data;
using Bonepile_New.Models;
using Bonepile_New.Pages;
using Bonepile_New.Shared;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.IdentityModel.Tokens;
using System.Data;
using System.Data.Common;

namespace Bonepile_New.Services;

public class Armario_BoneService
{
    private readonly BancoContext _context;
    public Armario_BoneService(BancoContext context)
    {
        _context = context;
    }

    public async Task<List<Armario_BoneModel>> GetArmario()
    {

        var teste = await _context.UDTBONE_GERAR_ARMARIO_IN_BONE_PILE.ToListAsync();

        return teste;
    }

    public async Task<Armario_BoneModel> GetArmarioId(int qtd_g)
    {


        var teste = await _context.UDTBONE_GERAR_ARMARIO_IN_BONE_PILE.FirstAsync(x => x.qtda_Gavetas == qtd_g);


        return teste;
    }


    public async Task SalvaBoneIn(BoneInModel model) =>
        await _context.AdicionarProdutoAsync(model);

    public async Task SalvaBoneInLista(List<BoneInModel> model) =>
       await _context.AdicionarProdutoListaAsync(model);


    public async Task SalvaBoneOut(BoneOutModel model) =>
       await _context.ExcluirProdutoAsync(model);

    public async Task<BoneInModel> GetBoneIn(string serial)
    {
        return _context.UDTBONE_PLACAS_IN_BONE.FirstOrDefault(x => x.Serial_Number == serial);
    }

    public async Task AtualizaStatusdAsync(BoneInModel model) =>
       await _context.UpdateProdutoAsync(model);


    public async Task BuscarInfo(string serialnumber) =>
      await _context.BuscaInfo(serialnumber);

    public async Task<List<BoneInModel>> Buscar(DateTime? dataInicio, string? serialnumber, string? client, string? accao)
    {
       
        if(dataInicio != null)
        {
            DateTime dataIn = dataInicio.Value.Date;
            DateTime dataF = dataIn.AddDays(1);
            DateTime dataOut = dataF.AddSeconds(-1);

            var query = _context.UDTBONE_PLACAS_IN_BONE.AsQueryable();

            if (dataInicio.HasValue)
                query = query.Where(x => x.Entrada >= dataIn && x.Entrada <= dataOut);

            if (!string.IsNullOrWhiteSpace(serialnumber))
                query = query.Where(x => x.Serial_Number.Contains(serialnumber));

            if (!string.IsNullOrWhiteSpace(client))
                query = query.Where(x => x.Cliente.Contains(client));

            if (!string.IsNullOrWhiteSpace(accao))
                query = query.Where(x => x.Acao.Contains(accao));


            return await query.ToListAsync();

        }
        else
        {
            DateTime? dataIn = null;
          
            DateTime? dataOut = null;

            var query = _context.UDTBONE_PLACAS_IN_BONE.AsQueryable();

            if (dataInicio.HasValue)
                query = query.Where(x => x.Entrada >= dataIn && x.Entrada <= dataOut);

            if (!string.IsNullOrWhiteSpace(serialnumber))
                query = query.Where(x => x.Serial_Number.Contains(serialnumber));

            if (!string.IsNullOrWhiteSpace(client))
                query = query.Where(x => x.Cliente.Contains(client));

            if (!string.IsNullOrWhiteSpace(accao))
                query = query.Where(x => x.Acao.Contains(accao));


            return await query.ToListAsync();
        }


    }

    public async Task<List<BoneOutModel>> BuscarOut(DateTime? dataInicio, DateTime? dataFim, string serialnumber, string client, string accao)
    {

        if (dataInicio != null)
        {
            DateTime dataIn = dataInicio.Value.Date;
            DateTime dataF = dataIn.AddDays(1);
            DateTime dataOut = dataF.AddSeconds(-1);

              

            var query = _context.UDTBONE_HISTORICO_OUT.AsQueryable();

            if (dataInicio.HasValue)
                query = query.Where(x => x.Entrada >= dataIn && x.Entrada <= dataOut);

            //if (dataFim.HasValue)
            //    query = query.Where(x => x.Saida >= dataEnd && x.Saida <= dataEn);

            if (!string.IsNullOrWhiteSpace(serialnumber))
                query = query.Where(x => x.Serial_Number.Contains(serialnumber));

            if (!string.IsNullOrWhiteSpace(client))
                query = query.Where(x => x.Cliente.Contains(client));

            if (!string.IsNullOrWhiteSpace(accao))
                query = query.Where(x => x.Acao.Contains(accao));


            return await query.ToListAsync();

        }else if( dataFim != null)
        {
   

            DateTime dataEnd = dataFim.Value.Date;
            DateTime dataE = dataEnd.AddDays(1);
            DateTime dataEn = dataE.AddSeconds(-1);

            var query = _context.UDTBONE_HISTORICO_OUT.AsQueryable();

            //if (dataInicio.HasValue)
            //    query = query.Where(x => x.Entrada >= dataIn && x.Entrada <= dataOut);

            if (dataFim.HasValue)
                query = query.Where(x => x.Saida >= dataEnd && x.Saida <= dataEn);

            if (!string.IsNullOrWhiteSpace(serialnumber))
                query = query.Where(x => x.Serial_Number.Contains(serialnumber));

            if (!string.IsNullOrWhiteSpace(client))
                query = query.Where(x => x.Cliente.Contains(client));

            if (!string.IsNullOrWhiteSpace(accao))
                query = query.Where(x => x.Acao.Contains(accao));


            return await query.ToListAsync();
        }
        else
        {
            DateTime? dataIn = null;

            DateTime? dataOut = null;
            DateTime? dataEnd = null;
            DateTime? dataEn = null;

            DateTime Ano = new DateTime(DateTime.Today.Year,1,1);


            var query = _context.UDTBONE_HISTORICO_OUT.AsQueryable().Where(x=>x.Entrada > Ano && x.Saida > Ano );

            if (dataInicio.HasValue)
                query = query.Where(x => x.Entrada >= dataIn && x.Entrada <= dataOut);

            if (!string.IsNullOrWhiteSpace(serialnumber))
                query = query.Where(x => x.Serial_Number.Contains(serialnumber));

            if (!string.IsNullOrWhiteSpace(client))
                query = query.Where(x => x.Cliente.Contains(client));

            if (!string.IsNullOrWhiteSpace(accao))
                query = query.Where(x => x.Acao.Contains(accao));


            return await query.ToListAsync();
        }

    }



    public async Task<List<BoneInModel>> GetAll()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .ToListAsync();
    }

    public async Task<List<BoneInModel>> GetAll2()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x=>x.Local == "".Trim())
            .ToListAsync();
    }



}
