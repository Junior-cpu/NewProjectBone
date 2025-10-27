using ApexCharts;
using Bonepile_New.Models;
using Bonepile_New.Services;
using Microsoft.JSInterop;
using System;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace Bonepile_New.Pages;

public partial class Index
{
    private List<BonePileModel>? cards;
    private List<BonePileModel>? cards802;
    private List<BonePileModel>? matrepai;
    private List<BonePileModel>? matrepaiP09;
    private List<BonePileModel>? matrepaiP12;

    private List<BonepileChartModel>? chartts;
    private List<BonepileChartModel>? chartts802;
    private List<BonepileChartModel>? charttsMtr;
    private List<BonepileChartModel>? charttsMtrP09;
    private List<BonepileChartModel>? charttsMtrP12;
    private List<BonepileChartModel>? resultados;
    private List<BoneInModel>? bone;
    private List<BorInModel>? bor;
    private List<ConfirmInModel>? confirm;
    private List<BoneOutModel>? boneOut;
    private List<BoneOutModel>? boneInxOut;
    private List<ConfirmOutModel>? confirmOut;
    private List<ConfirmOutModel>? confirmInxOut;
    private List<BorOutModel>? borOut;
    private List<BorOutModel>? borInxOut;

    private string[]? categorias;
    private long[]? series;

    private ApexChart<BonepileChartModel>? chart;
    private ApexChartOptions<BonepileChartModel> options { get; set; } = new();
    List<BonepileChartModel>? charts;

    private double resultMtrP12;
    private double quantidadeMtrP12;

    double resultHoje;
    private double? resultado;

    private string? MyColor ;
    private string? MyColor1 ;
    private string? MyColor2 ;
    private string? MyColor3 ;
    private string? MyColor4 ;

    private string? MyColorQty;
    private string? MyColorQty1;
    private string? MyColorQty2;
    private string? MyColorQty3;
    private string? MyColorQty4;


    private bool isDataLoaded = false;

    protected override async Task OnInitializedAsync()
    {

        //=================================801==============================================

        cards = await bonepileService.GetCards();
        isDataLoaded = true;

        var total = cards.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };
        }).ToList();

        var resultHoje = total.Sum(x => x.valorTotal);
        var cards1 = await bonepileService.GetCardsOntem();
        var total1 = cards1.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal1 = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };

          

        }).ToList();
        var qtyOntem = (cards1.Sum(p => int.Parse(p.Unid_Estoq)));
        var qtyHoje = (cards.Sum(p => int.Parse(p.Unid_Estoq)));

        var quantidade = qtyHoje - qtyOntem;

        var resultOntem = total1.Sum(x => x.valorTotal1);

        var result = Math.Round(resultHoje, 2) - Math.Round(resultOntem,2);

        var resultado = result;
    
        cards[0].Preco_Medio_Mensal_Em_USD = resultado;
        cards[0].Id = quantidade;

        if (resultado < 0)
        {
            MyColor = "darkgreen";
        }
        else if (resultado > 0)
        {
            MyColor = "red";
        }
        else
        {
            MyColor = "black";
        }

        if (cards[0].Id < 0)
        {
            MyColorQty = "darkgreen";
        }
        else if (cards[0].Id > 0)
        {
            MyColorQty = "red";
        }
        else
        {
            MyColorQty = "black";
        }
        //=============================802==========================================================

        cards802 = await bonepileService.GetCards802();

        var total802 = cards802.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };
        }).ToList();

        var resultHoje802 = total802.Sum(x => x.valorTotal);
        var cards1802 = await bonepileService.GetCardsOntem802();
        var total1802 = cards1802.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal1 = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };



        }).ToList();
        var qtyOntem802 = (cards1802.Sum(p => int.Parse(p.Unid_Estoq)));
        var qtyHoje802 = (cards802.Sum(p => int.Parse(p.Unid_Estoq)));

        var quantidade802 = qtyHoje802 - qtyOntem802;

        var resultOntem802 = total1802.Sum(x => x.valorTotal1);

        var result802 = Math.Round(resultHoje802,2) - Math.Round(resultOntem802,2);

        var resultado802 = result802;
        cards802[0].Preco_Medio_Mensal_Em_USD = resultado802;
        cards802[0].Id = quantidade802;

        if (cards802[0].Preco_Medio_Mensal_Em_USD < 0)
        {
            MyColor1 = "darkgreen";
        }
        else if (cards802[0].Preco_Medio_Mensal_Em_USD > 0)
        {
            MyColor1 = "red";
        }
        else
        {
            MyColor1 = "black";
        }


        if (cards802[0].Id < 0) 
        {
            MyColorQty1 = "darkgreen";
        }
        else if (cards802[0].Id > 0)
        {
            MyColorQty1 = "red";
        }
        else
        {
            MyColorQty1 = "black";
        }


        //===========================matrepai================================================

        matrepai = await bonepileService.GetCardsMtr();

        var totalMtr = matrepai.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };
        }).ToList();

        var resultHojeMtr = totalMtr.Sum(x => x.valorTotal);
        var cards1Mtr = await bonepileService.GetCardsOntemMtr();
        var total1Mtr = cards1Mtr.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal1 = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };



        }).ToList();
        var qtyOntemMtr = (cards1Mtr.Sum(p => int.Parse(p.Unid_Estoq)));
        var qtyHojeMtr = (matrepai.Sum(p => int.Parse(p.Unid_Estoq)));

        var quantidadeMtr = qtyHojeMtr - qtyOntemMtr;

        var resultOntemMtr = total1Mtr.Sum(x => x.valorTotal1);

        var resultMtr = Math.Round(resultHojeMtr,2) - Math.Round(resultOntemMtr,2);

        var resultadoMtr = resultMtr;
        matrepai[0].Preco_Medio_Mensal_Em_USD = resultadoMtr;
        matrepai[0].Id= quantidadeMtr;

        if (resultadoMtr < 0)
        {
            MyColor2 = "darkgreen";
        }
        else if (resultadoMtr > 0)
        {
            MyColor2 = "red";
        }
        else
        {
            MyColor2 = "black";
        }
        if (matrepai[0].Id < 0)
        {
            MyColorQty2 = "darkgreen";
        }
        else if (matrepai[0].Id > 0)
        {
            MyColorQty2 = "red";
        }
        else
        {
            MyColorQty2 = "black";
        }

        //===========================matrepaiP09================================================

        matrepaiP09 = await bonepileService.GetCardsMtrP09();

        var totalMtrP09 = matrepaiP09.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };
        }).ToList();

        var resultHojeMtrP09 = totalMtrP09.Sum(x => x.valorTotal);
        var cards1MtrP09 = await bonepileService.GetCardsOntemMtrP09();
        var total1MtrP09 = cards1MtrP09.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal1 = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };



        }).ToList();
        var qtyOntemMtrP09 = (cards1MtrP09.Sum(p => int.Parse(p.Unid_Estoq)));
        var qtyHojeMtrP09 = (matrepaiP09.Sum(p => int.Parse(p.Unid_Estoq)));

        var quantidadeMtrP09 = qtyHojeMtrP09 - qtyOntemMtrP09;

        var resultOntemMtrP09 = total1MtrP09.Sum(x => x.valorTotal1);

        var resultMtrP09 = Math.Round(resultHojeMtrP09,2) - Math.Round(resultOntemMtrP09,2);

        var resultadoMtrP09 = resultMtrP09;
        matrepaiP09[0].Preco_Medio_Mensal_Em_USD = resultadoMtrP09;
        matrepaiP09[0].Id= quantidadeMtrP09;

        if (resultadoMtrP09 < 0)
        {
            MyColor3 = "darkgreen";
        }
        else if (resultadoMtrP09 > 0)
        {
            MyColor3 = "red";
        }
        else
        {
            MyColor3 = "black";
        }
        if (matrepaiP09[0].Id < 0)
        {
            MyColorQty3 = "darkgreen";
        }
        else if (matrepaiP09[0].Id > 0)
        {
            MyColorQty3 = "red";
        }
        else
        {
            MyColorQty3 = "black";
        }

        //===========================matrepaiP12================================================

        matrepaiP12 = await bonepileService.GetCardsMtrP12();

        var totalMtrP12 = matrepaiP12.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };
        }).ToList();

        var resultHojeMtrP12 = totalMtrP12.Sum(x => x.valorTotal);
        var cards1MtrP12 = await bonepileService.GetCardsOntemMtrP12();
        var total1MtrP12 = cards1MtrP12.Select(p =>
        {
            int unid_Estoq;
            bool sucesso = int.TryParse(p.Unid_Estoq, out unid_Estoq);

            return new
            {
                valorTotal1 = sucesso ? unid_Estoq * p.Preco_Medio_Mensal_Em_USD : 0
            };



        }).ToList();
        var qtyOntemMtrP12 = (cards1MtrP12.Sum(p => int.Parse(p.Unid_Estoq)));
        var qtyHojeMtrP12 = (matrepaiP12.Sum(p => int.Parse(p.Unid_Estoq)));

         quantidadeMtrP12 = qtyHojeMtrP12 - qtyOntemMtrP12;

        var resultOntemMtrP12 = total1MtrP12.Sum(x => x.valorTotal1);

         resultMtrP12 = Math.Round(resultHojeMtrP12,2) - Math.Round(resultOntemMtrP12,2);

     

        if (resultMtrP12 < 0)
        {
            MyColor4 = "darkgreen";
        }
        else if (resultMtrP12 > 0)
        {
            MyColor4 = "red";
        }
        else
        {
            MyColor4 = "black";
        }
        if (quantidadeMtrP12 < 0)
        {
            MyColorQty4 = "darkgreen";
        }
        else if (quantidadeMtrP12 > 0)
        {
            MyColorQty4 = "red";
        }
        else
        {
            MyColorQty4 = "black";
        }


        //=======================================Charts================================================================================

        chartts = await bonepileChartService.GetChartAsync();
        chartts802 = await bonepileChartService.GetChartAsync();
        charttsMtr = await bonepileChartService.GetChartAsync();
        charttsMtrP09 = await bonepileChartService.GetChartAsync();
        charttsMtrP12 = await bonepileChartService.GetChartAsync();

        bone = await bonepileChartService.GetBoneIn();
        boneInxOut = await bonepileChartService.GetBoneInxOut();
        confirm = await bonepileChartService.GetConfirmIn();
        confirmInxOut = await bonepileChartService.GetConfirmInxOut();
        bor = await bonepileChartService.GetBorIn();
        boneOut = await bonepileChartService.GetBoneOut();
        confirmOut = await bonepileChartService.GetConfirmOut();
        borOut = await bonepileChartService.GetBorOut();
        borInxOut = await bonepileChartService.GetBorInxOut();



        var sevendays = DateTime.Today;
        var days = sevendays.AddDays(-7);

        var resultados = from c in chartts
                         where c.Data_Insercao >= days && c.Almoxarifado == "801"
                         orderby c.Data_Insercao
                         group c by c.Data_Insercao into teste

                         select new
                         {
                             Data = teste.Key.ToString("dd/MM/yy"),
                             valor = teste.Sum(x=> int.Parse(x.Unid_Estoq) * x.Preco_Medio_Mensal_Em_Usd).ToString("F2"),
                             
                         };

        var sevendays802 = DateTime.Today;
        var days802 = sevendays.AddDays(-7);

        var resultados802 = from c in chartts802
                         where c.Data_Insercao >= days && c.Almoxarifado == "802" && c.Local != "MATREPAI"
                         && c.Local != "MATR_P09" && c.Local != "MATR_P12" && c.Local != "RECEBE"
                            orderby c.Data_Insercao
                         group c by c.Data_Insercao into teste

                         select new
                         {
                             Data = teste.Key.ToString("dd/MM/yy"),
                             valor = teste.Sum(x => int.Parse(x.Unid_Estoq) * x.Preco_Medio_Mensal_Em_Usd).ToString("F2"),

                         };

        var sevendaysmtr = DateTime.Today;
        var daysmtr = sevendays.AddDays(-7);

        var resultadosMtr = from c in chartts802
                            where c.Data_Insercao >= days && c.Local == "MATREPAI"
                            orderby c.Data_Insercao
                            group c by c.Data_Insercao into teste

                            select new
                            {
                                Data = teste.Key.ToString("dd/MM/yy"),
                                valor = teste.Sum(x => int.Parse(x.Unid_Estoq) * x.Preco_Medio_Mensal_Em_Usd).ToString("F2"),

                            };

        var sevendaysmtrP09 = DateTime.Today;
        var daysmtrP09 = sevendays.AddDays(-7);

        var resultadosMtrP09 = from c in chartts802
                            where c.Data_Insercao >= days && c.Local == "MATR_P09"
                               orderby c.Data_Insercao
                            group c by c.Data_Insercao into teste

                            select new
                            {
                                Data = teste.Key.ToString("dd/MM/yy"),
                                valor = teste.Sum(x => int.Parse(x.Unid_Estoq) * x.Preco_Medio_Mensal_Em_Usd).ToString("F2"),

                            };

        var sevendaysmtrP12 = DateTime.Today;
        var daysmtrP12 = sevendays.AddDays(-7);

        var resultadosMtrP12 = from c in chartts802
                            where c.Data_Insercao >= days && c.Local == "MATR_P12"
                               orderby c.Data_Insercao
                            group c by c.Data_Insercao into teste

                            select new
                            {
                                Data = teste.Key.ToString("dd/MM/yy"),
                                valor = teste.Sum(x => int.Parse(x.Unid_Estoq) * x.Preco_Medio_Mensal_Em_Usd).ToString("F2"),

                            };
 

        var boneIn = bone.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "REPARO".Trim() ? "ANALISE" : "ANALISE",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = null,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var confirms = confirm.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "REPARO".Trim() ? "ANALISE" : "ANALISE",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = null,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var ConfirmInxOuts1 = confirmInxOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "PASS".Trim() ? "ANALISE" : "PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });
        var BorInxOuts = borInxOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "PASS".Trim() ? "ANALISE" : "PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var bors = bor.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "REPARO".Trim() ? "ANALISE" : "ANALISE",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = null,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var boneOuts = boneOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "SCRAP".Trim() ? "PASS" : "PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });
        var boneOuts1 = boneInxOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "PASS".Trim() ? "ANALISE" : "PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var confirmOuts = confirmOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "SCRAP".Trim() ? "PASS" : "PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var borsOuts = borOut.Select(b => new UnionModel
        {

            Id = b.Id,
            Local = b.Local,
            Serial_Number = b.Serial_Number,
            Part_Number = b.Part_Number,
            Cliente = b.Cliente,
            Modelo = b.Modelo,
            Acao = b.Acao == "SCRAP".Trim() ? "PASS" :"PASS",
            Falha = b.Falha,
            Entrada = b.Entrada,
            Saida = b.Saida,
            Aging = b.Aging,
            Valor = b.Valor

        });

        var resultadoFinal = boneOuts
            .Union(boneIn)
            .Union(confirms)
            .Union(bors)
            .Union(confirmOuts)
            .Union(borsOuts)
            .Union(ConfirmInxOuts1)
            .Union(boneOuts1)
            .Union(BorInxOuts);

        var unions = from r in resultadoFinal
                     group r by r.Acao into teste
                     select new
                     {
                         Acao = teste.Key,
                         qt = teste.Count()
                         //Entrada = r.Acao == "Analise" ? "Entrada" : "Saida",
                         //Saida = r.Acao == "Pass" ? "Saida" : (r.Acao == "scrap" ? "scrap" : "Entrada"),
                     };

       
                  

        await jsRuntime.InvokeVoidAsync("createChart.starts", resultados);
        await jsRuntime.InvokeVoidAsync("createChart1.starts1", resultados802);
        await jsRuntime.InvokeVoidAsync("createChart2.starts2", resultadosMtr);
        await jsRuntime.InvokeVoidAsync("createChart3.starts3", resultadosMtrP09);
        await jsRuntime.InvokeVoidAsync("createChart4.starts4", resultadosMtrP12);
        await jsRuntime.InvokeVoidAsync("createChart5.starts5", unions);
 


    }
}
