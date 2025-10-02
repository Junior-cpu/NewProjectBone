using Bonepile_New.Data;
using Bonepile_New.Models;
using Microsoft.EntityFrameworkCore;

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
        //return await _context.UDTBONE_GERAR_ARMARIO_IN_BONE_PILE
        //    .ToListAsync();

        var teste = await _context.UDTBONE_GERAR_ARMARIO_IN_BONE_PILE.ToListAsync();

        return teste;
    }

    public async Task<Armario_BoneModel> GetArmarioId(int qtd_g)
    {


        var teste = await _context.UDTBONE_GERAR_ARMARIO_IN_BONE_PILE.FirstAsync(x=>x.qtda_Gavetas == qtd_g);
            

        return teste;
    }
}
