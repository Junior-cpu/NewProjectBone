using Bonepile_New.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.JSInterop;

namespace Bonepile_New.Pages;

public partial class ArmarioBone
{
    public Armario_BoneModel model = new Armario_BoneModel();
    private List<Armario_BoneModel>? armarios { get; set; } = new List<Armario_BoneModel>();
    private List<BoneInModel>? boneIn { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? gaveteiro { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? debug1 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range0a3 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range4a7 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range8a14 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range15a30 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range31a60 { get; set; } = new List<BoneInModel>();
    private List<BoneInModel>? range60 { get; set; } = new List<BoneInModel>();
    private List<InfoPlacas> resultado = new List<InfoPlacas>();
    public IEnumerable<BoneInModel>? listPosicoes;
    public List<string>? list;


    public List<BoneInModel> listPosicoes1 { get; set; } = new List<BoneInModel>();
    private int resultado0a3 = 0;
    private int resultado4a7 = 0;
    private int resultado8a14 = 0;
    private int resultado15a30 = 0;
    private int resultado31a60 = 0;
    private int resultado60 = 0;
    private int debug = 0;
    private int total = 0;



    int qtd_g = 20;

    public string? ar { get; set; } = "";
    public string? serial ="";

    protected override async Task OnInitializedAsync()
    {


        armarios = await boneService.GetArmario();

        model = await boneService.GetArmarioId(qtd_g);

        list = bancoContext.UDTBONE_PLACAS_IN_BONE
           .Select(x => x.Local).ToList();



        resultado0a3 = bancoContext.UDTBONE_PLACAS_IN_BONE
             .Count(x => x.Aging >= 0 && x.Aging <= 3);

        resultado4a7 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging >= 4 && x.Aging <= 7);

        resultado8a14 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 7 && x.Aging < 15);

        resultado15a30 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 14 && x.Aging < 31);

        resultado31a60 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 30 && x.Aging < 61);

        resultado60 = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Aging > 60);

        debug = bancoContext.UDTBONE_PLACAS_IN_BONE
            .Count(x => x.Local == "DEBUG_1".Trim());

        total = bancoContext.UDTBONE_PLACAS_IN_BONE.Count();
        // StateHasChanged();
    }

    private bool mostrarModalTotal = false;
    private bool mostrarModalDebug = false;
    private bool mostrarModal0a3 = false;
    private bool mostrarModal4a7 = false;
    private bool mostrarModal8a14 = false;
    private bool mostrarModal15a30 = false;
    private bool mostrarModal31a60 = false;
    private bool mostrarModal60 = false;
    private bool mostrarModalGaveteiro = false;
    private bool mostrarModalEntrada = false;



    private async Task AbrirModal()
    {
        boneIn = await bonepileService.GetTotalAsync();
        mostrarModalTotal = true;
    }

    private async Task AbrirModalDebug()
    {
        debug1 = await bonepileService.GetDebugAsync();
        mostrarModalDebug = true;
    }

    private async Task AbrirModal0a3()
    {
        range0a3 = await bonepileService.Get0a3Async();
        mostrarModal0a3 = true;
    }
    private async Task AbrirModal4a7()
    {
        range4a7 = await bonepileService.Get4a7Async();
        mostrarModal4a7 = true;
    }
    private async Task AbrirModal8a14()
    {
        range8a14 = await bonepileService.Get8a14Async();
        mostrarModal8a14 = true;
    }
    private async Task AbrirModal15a30()
    {
        range15a30 = await bonepileService.Get15a30Async();
        mostrarModal15a30 = true;
    }
    private async Task AbrirModal31a60()
    {
        range31a60 = await bonepileService.Get31a60Async();
        mostrarModal31a60 = true;
    }
    private async Task AbrirModal60()
    {
        range60 = await bonepileService.Get60Async();
        mostrarModal60 = true;
    }

    private async Task AbrirModalGaveta(string ar)
    {
        gaveteiro = await bonepileService.GetGavetaAsync(ar);
        mostrarModalGaveteiro = true;
    }
    private async Task AbrirModalEntrada()
    {
        // gaveteiro = await bonepileService.GetGavetaAsync(ar);
        mostrarModalEntrada = true;
    }


    private Task FecharModalTotal()
    {
        mostrarModalTotal = false;
        return Task.CompletedTask;
    }

    private Task FecharModalDebug()
    {
        mostrarModalDebug = false;
        return Task.CompletedTask;
    }

    private Task FecharModal0a3()
    {
        mostrarModal0a3 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal4a7()
    {
        mostrarModal4a7 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal8a14()
    {
        mostrarModal8a14 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal15a30()
    {
        mostrarModal15a30 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal31a60()
    {
        mostrarModal31a60 = false;
        return Task.CompletedTask;
    }
    private Task FecharModal60()
    {
        mostrarModal60 = false;
        return Task.CompletedTask;
    }

    private Task FecharModalGaveteiro()
    {
        mostrarModalGaveteiro = false;
        return Task.CompletedTask;
    }
    private Task FecharModalEntrada()
    {
        mostrarModalEntrada = false;
        return Task.CompletedTask;
    }

    async Task Success() =>
    await JS.InvokeAsync<object>("alert", "Successful login!");

    private void OnValidSubmit()
    {
        // my code
    }
    string partnumber = "";
    string cliente = "";
    string modelo = "";
    string falha = "";
    string local = "";
    string acao = "";
    //private bool isButtonDisabled = true;
    private async Task BuscaInfo(string serial_number)
    {
      // var resultado = await historyService.GetInfos(serial);
        var resultado3 = await bancoContext.InfoPlacas
        .FromSqlRaw("EXEC db_owner.UDTBONE_Get_Infos_Placas @serial_number", new SqlParameter("@serial_number", serial_number))
        .ToListAsync();

         resultado = await bancoContext.InfoPlacas.ToListAsync();

        partnumber = resultado[0].Partnumber;
        cliente = resultado[0].Cliente;
        modelo= resultado[0].Modelo;
        falha = resultado[0].Failure;
        mostrarModalEntrada = true;

       
    }

}



//SLL32522JVVL