using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Bonepile_New.Services;

public class BonepileService
{
    private readonly BancoContext _context;
  

    public BonepileService(BancoContext context)
    {
        _context = context;
 
    }


    public async Task<List<BonePileModel>> GetCards()
    {
        var dataAtual = DateTime.Today;

        var cards = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
            .Where(x => x.Almoxarifado == "801" && x.Data_Insercao >= dataAtual
                       && x.Local.Trim() != "MATREPAI"
                       && x.Local.Trim() != "RECEBE"
                       && x.Local.Trim() != "MATR_P09"
                       && x.Local.Trim() != "MATR_P12")
            .ToListAsync();
   
        return cards;
    }
    public async Task<List<BonePileModel>> GetCardsOntem()
    {
        var data = DateTime.Now;
        var datas = data.DayOfWeek == DayOfWeek.Monday;
        var dataAtual = DateTime.Today;
        var dataOntem = dataAtual.AddDays(-1);
        var dataAtual1 = DateTime.Today;
        var dataOntem1 = dataAtual1.AddDays(-3);
        var dataOntem2 = dataAtual1.AddDays(-2);
        if (datas != true)
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem && x.Data_Insercao < dataAtual && x.Almoxarifado == "801"
                       && x.Local.Trim() != "MATREPAI"
                       && x.Local.Trim() != "RECEBE"
                       && x.Local.Trim() != "MATR_P09"
                       && x.Local.Trim() != "MATR_P12")
                 .ToListAsync();

            return teste1;
        }
        else
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem1 && x.Data_Insercao < dataOntem2 && x.Almoxarifado == "801"
                       && x.Local.Trim() != "MATREPAI"
                       && x.Local.Trim() != "RECEBE"
                       && x.Local.Trim() != "MATR_P09"
                       && x.Local.Trim() != "MATR_P12")
                 .ToListAsync();

            return teste1;
        }
    }



    public async Task<List<BonePileModel>> GetCards802()
    {
        var dataAtual = DateTime.Today;

        var cards = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
            .Where(x => x.Data_Insercao >= dataAtual
               && x.Almoxarifado == "802"
               && x.Local.Trim() != "MATREPAI"
               && x.Local.Trim() != "RECEBE"
               && x.Local.Trim() != "MATR_P09"
               && x.Local.Trim() != "MATR_P12")
            .ToListAsync();

        return cards;
    }


    public async Task<List<BonePileModel>> GetCardsOntem802()
    {
        var data = DateTime.Now;
        var datas = data.DayOfWeek == DayOfWeek.Monday;
        var dataAtual = DateTime.Today;
        var dataOntem = dataAtual.AddDays(-1);
        var dataAtual1 = DateTime.Today;
        var dataOntem1 = dataAtual1.AddDays(-3);
        var dataOntem2 = dataAtual1.AddDays(-2);
        
        if(datas != true)
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem
                   && x.Data_Insercao < dataAtual
                   && x.Almoxarifado == "802"
                   && x.Local.Trim() != "MATREPAI"
                   && x.Local.Trim() != "RECEBE"
                   && x.Local.Trim() != "MATR_P09"
                   && x.Local.Trim() != "MATR_P12")
                 .ToListAsync();

            return teste1;
        }
        else
        {
           var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
             .AsNoTracking()
             .Where(x => x.Data_Insercao >= dataOntem1
               && x.Data_Insercao < dataOntem2
               && x.Almoxarifado == "802"
               && x.Local.Trim() != "MATREPAI"
               && x.Local.Trim() != "RECEBE"
               && x.Local.Trim() != "MATR_P09"
               && x.Local.Trim() != "MATR_P12")
             .ToListAsync();

            return teste1;
        }
    }


    public async Task<List<BonePileModel>> GetCardsMtr()
    {
        var dataAtual = DateTime.Today;

        var cards = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
            .Where(x => x.Data_Insercao >= dataAtual
               && x.Local.Trim() == "MATREPAI")
            .ToListAsync();

        return cards;
    }
    public async Task<List<BonePileModel>> GetCardsOntemMtr()
    {
        var data = DateTime.Now;
        var datas = data.DayOfWeek == DayOfWeek.Monday;
        var dataAtual = DateTime.Today;
        var dataOntem = dataAtual.AddDays(-1);
        var dataAtual1 = DateTime.Today;
        var dataOntem1 = dataAtual1.AddDays(-3);
        var dataOntem2 = dataAtual1.AddDays(-2);

        if(datas != true)
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem
                   && x.Data_Insercao < dataAtual
                   && x.Local.Trim() == "MATREPAI")
                 .ToListAsync();
            return teste1;
        }
        else
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
          .AsNoTracking()
          .Where(x => x.Data_Insercao >= dataOntem1
            && x.Data_Insercao < dataOntem2
            && x.Local.Trim() == "MATREPAI")
          .ToListAsync();
            return teste1;
        }
    }


    public async Task<List<BonePileModel>> GetCardsMtrP09()
    {
        var dataAtual = DateTime.Today;

        var cards = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
            .Where(x => x.Data_Insercao >= dataAtual
               && x.Local.Trim() == "MATR_P09")
            .ToListAsync();

        return cards;
    }
    public async Task<List<BonePileModel>> GetCardsOntemMtrP09()
    {
        var data = DateTime.Now;
        var datas = data.DayOfWeek == DayOfWeek.Monday;
        var dataAtual = DateTime.Today;
        var dataOntem = dataAtual.AddDays(-1);
        var dataAtual1 = DateTime.Today;
        var dataOntem1 = dataAtual1.AddDays(-3);
        var dataOntem2 = dataAtual1.AddDays(-2);

        if(datas != true)
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem
                   && x.Data_Insercao < dataAtual
                   && x.Local.Trim() == "MATR_P09")
                 .ToListAsync();
            return teste1;
        }
        else
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
             .AsNoTracking()
             .Where(x => x.Data_Insercao >= dataOntem1
               && x.Data_Insercao < dataOntem2
               && x.Local.Trim() == "MATR_P09")
             .ToListAsync();
            return teste1;
        }
    }



    public async Task<List<BonePileModel>> GetCardsMtrP12()
    {
        var dataAtual = DateTime.Today;

        var cards = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
            .Where(x => x.Data_Insercao >= dataAtual
               && x.Local.Trim() == "MATR_P12")
            .ToListAsync();

        return cards;
    }
    public async Task<List<BonePileModel>> GetCardsOntemMtrP12()
    {
        var data = DateTime.Now;
        var datas = data.DayOfWeek == DayOfWeek.Monday;
        var dataAtual = DateTime.Today;
        var dataOntem = dataAtual.AddDays(-1);
        var dataAtual1 = DateTime.Today;
        var dataOntem1 = dataAtual1.AddDays(-3);
        var dataOntem2 = dataAtual1.AddDays(-2);

        if(datas != true)
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
                 .AsNoTracking()
                 .Where(x => x.Data_Insercao >= dataOntem
                   && x.Data_Insercao < dataAtual
                   && x.Local.Trim() == "MATR_P12")
                 .ToListAsync();
            return teste1;
        }
        else
        {
            var teste1 = await _context.UDTLOOK_UP_BONE_GERAL_HISTORICO1
             .AsNoTracking()
             .Where(x => x.Data_Insercao >= dataOntem1
               && x.Data_Insercao < dataOntem2
               && x.Local.Trim() == "MATR_P12")
             .ToListAsync();
            return teste1;
        }

    }

    public async Task<List<BoneInModel>> GetTotalAsync()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .ToListAsync();
    }
    public async Task<List<BoneInModel>> GetDebugAsync()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x=>x.Local == "DEBUG_1".Trim())
            .ToListAsync();
    }

    public async Task<List<BoneInModel>> Get0a3Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging >= 0 && x.Aging <= 3)
            .ToListAsync();
    }
    public async Task<List<BoneInModel>> Get4a7Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging >= 4 && x.Aging < 8)
            .ToListAsync();
    }

    public async Task<List<BoneInModel>> Get8a14Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging > 7 && x.Aging < 15)
            .ToListAsync();
    }
    public async Task<List<BoneInModel>> Get15a30Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging > 14 && x.Aging < 31)
            .ToListAsync();
    }

    public async Task<List<BoneInModel>> Get31a60Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging > 30 && x.Aging < 61)
            .ToListAsync();
    }

    public async Task<List<BoneInModel>> Get60Async()
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x => x.Aging > 60)
            .ToListAsync();
    }
    public async Task<List<BoneInModel>> GetGavetaAsync(string ar)
    {
        return await _context.UDTBONE_PLACAS_IN_BONE
            .AsNoTracking()
            .Where(x=>x.Local == ar.Trim())
            .ToListAsync();
    }


}

