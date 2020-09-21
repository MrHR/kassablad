using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using Kassablad.api.Data;
using Kassablad.api.Models;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ChartController : ControllerBase
    {
        private readonly KassabladContext _context;
        private readonly double barWidthPercentage = 0.7;
        private readonly double lineTensionPercentage = 0.3;

        public ChartController(KassabladContext context)
        {
            _context = context;
        }

        //TODO: make this into stored procedure once no more sqlite/use compiled queries linq
        public async Task<List<NomValues>> GetNomValues() {
            var nomValuesList = _context.KassaNomination
                .Join(_context.Nominations,
                    kassaNom => kassaNom.NominationId,
                    nom => nom.Id,
                    (kassaNom, nom) => new { KassaNom = kassaNom, Nom = nom }
                )
                .Join(_context.Kassa,
                    nomKassaId => nomKassaId.KassaNom.KassaId,
                    kassaId => kassaId.Id,
                    (nomKassaId, kassaId) => new { NomKassaId = nomKassaId, KassaId = kassaId }
                )
                .Join(_context.KassaContainer,
                    kassa => kassa.KassaId.KassaContainerId,
                    kassaContainer => kassaContainer.Id,
                    (kassa, KassaContainer) => new { Kassa = kassa, KassaContainer = KassaContainer }
                )
                .Where(x => x.Kassa.NomKassaId.KassaNom.Active == true && x.Kassa.NomKassaId.Nom.Active == true)
                .Select(x => new NomValues() {
                    KassaContainerId = x.KassaContainer.Id,
                    KassaId = x.Kassa.KassaId.Id,
                    KassaType = x.Kassa.KassaId.Type,
                    BeginUur = x.KassaContainer.BeginUur,
                    Value = x.Kassa.NomKassaId.KassaNom.Amount * x.Kassa.NomKassaId.Nom.Multiplier
                });

            return await nomValuesList.ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Chart>> GetProfitChart(string startDate = "", string endDate = "")
        {
            var profitChart = new Chart() {
                Labels = new List<String>(),
                Datasets = new List<Dataset>()
            };
            var StartDate = (startDate != "" && startDate != "undefined") ? Convert.ToDateTime(startDate) : DateTime.Now.AddMonths(-1);
            var EndDate = (endDate != "" && endDate != "undefined") ? Convert.ToDateTime(endDate) : DateTime.Now;
            var nomValues = await GetNomValues();

            var beginKassas = nomValues
            .Where(x => x.KassaType == "begin")
            .GroupBy(x => x.KassaId)
            .Select(x => new {
                Key = x.Key,
                KassaContainerId = x.Select(a => a.KassaContainerId).First(),
                BeginUur = x.Select(a => a.BeginUur).First(),
                Type = x.Select(a => a.KassaType).First(),
                Total = x.Sum(a => a.Value)
            }).ToList();

            var endKassas = nomValues
            .Where(x => x.KassaType == "end")
            .GroupBy(x => x.KassaId)
            .Select(x => new {
                Key = x.Key,
                KassaContainerId = x.Select(a => a.KassaContainerId).First(),
                BeginUur = x.Select(a => a.BeginUur).First(),
                Type = x.Select(a => a.KassaType).First(),
                Total = x.Sum(a => a.Value)
            }).ToList();

            var kassaVerschillen = endKassas
            .Join(beginKassas,
                endKassa => endKassa.KassaContainerId,
                beginKassa => beginKassa.KassaContainerId,
                (endKassa, beginKassa) => new { EndKassa = endKassa, beginKassa = beginKassa }
            )
            .Select(x => new {
                Key = x.EndKassa.Key,
                KassaContainerId = x.EndKassa.KassaContainerId,
                BeginUur = x.EndKassa.BeginUur,
                Difference = x.EndKassa.Total - x.beginKassa.Total,
                EndKassa = x.EndKassa,
                BeginKassa = x.beginKassa
            }).ToList();

            if(EndDate != null && StartDate != null) {
                kassaVerschillen = kassaVerschillen
                    .Where(
                        x => x.BeginKassa.BeginUur >= StartDate 
                        && x.BeginKassa.BeginUur <= EndDate
                    ).ToList();
            }

            kassaVerschillen.ForEach(x => {
                string label = x.BeginUur.ToString("dd MMM yyyy");
                profitChart.Labels.Add(label);
            });

            //Dagwinst
            profitChart.Datasets.Add(new Dataset() {
                label = "Dagwinst",
                data = kassaVerschillen.Select(x => x.Difference).ToList(),
                // backgroundColor = kassaVerschillen.Select(x => "rgba(24, 144, 255, 1)").ToList(),
                lineTension = lineTensionPercentage,
                borderColor = "rgba(24, 144, 255, 1)",
                fill = "origin",
                backgroundColor = "rgba(24, 144, 255, 1)",
                barPercentage = barWidthPercentage
                // fillColor = "rgba(24, 144, 255, 1)",
                // fillBetweenSet = 1,
                // fillBetweenColor = "rgba(24, 144, 255, 1)"
            });

            return profitChart;
        }

        [HttpGet]
        [Route("~/api/[controller]/beginvsendchart")]
        public async Task<ActionResult<Chart>> GetBeginVsEndChart(string startDate = "", string endDate = "") {
            var profitChart = new Chart() {
                Labels = new List<String>(),
                Datasets = new List<Dataset>()
            };
            var StartDate = (startDate != "" && startDate != "undefined") ? Convert.ToDateTime(startDate) : DateTime.Now.AddMonths(-1);
            var EndDate = (endDate != "" && endDate != "undefined") ? Convert.ToDateTime(endDate) : DateTime.Now;
            var nomValues = await GetNomValues();
            var endKassas = nomValues
            .Where(x => x.KassaType == "end")
            .GroupBy(x => x.KassaId)
            .Select(x => new {
                Key = x.Key,
                KassaContainerId = x.Select(a => a.KassaContainerId).First(),
                BeginUur = x.Select(a => a.BeginUur).First(),
                Type = x.Select(a => a.KassaType).First(),
                Total = x.Sum(a => a.Value)
            }).ToList();

            var beginKassas = nomValues
            .Where(x => 
                x.KassaType == "begin"
                && endKassas.Exists(y => y.KassaContainerId == x.KassaContainerId)
            )
            .GroupBy(x => x.KassaId)
            .Select(x => new {
                Key = x.Key,
                KassaContainerId = x.Select(a => a.KassaContainerId).First(),
                BeginUur = x.Select(a => a.BeginUur).First(),
                Type = x.Select(a => a.KassaType).First(),
                Total = x.Sum(a => a.Value)
            }).ToList();

            //Check DateRange
            if(EndDate != null && StartDate != null) {
                endKassas = endKassas
                    .Where(
                        x => x.BeginUur >= StartDate 
                        && x.BeginUur <= EndDate
                    ).ToList();

                beginKassas = beginKassas
                    .Where(
                        x => x.BeginUur >= StartDate 
                        && x.BeginUur <= EndDate
                    ).ToList();
            }

            //Labels
            beginKassas.ForEach(x => {
                string label = x.BeginUur.ToString("dd MMM yyyy");
                profitChart.Labels.Add(label);
            });

            //Begin Kassa
            profitChart.Datasets.Add(new Dataset() {
                label="Beginkassa",
                data = beginKassas.Select(x => x.Total).ToList(),
                lineTension = lineTensionPercentage,
                borderColor = "rgba(242, 99, 123, 1)",
                fill = "origin",
                backgroundColor = "rgba(242, 99, 123, 1)",
                barPercentage = barWidthPercentage
            });

            //Eindkassa
            profitChart.Datasets.Add(new Dataset() {
                label="Eindkassa",
                data = endKassas.Select(x => x.Total).ToList(),
                lineTension = lineTensionPercentage,
                borderColor = "rgba(24, 144, 255, 1)",
                fill = "origin",
                backgroundColor = "rgba(24, 144, 255, 1)",
                barPercentage = barWidthPercentage
            });

            return profitChart;
        }

        public class NomValues {
            public int KassaContainerId { get; set; }
            public int KassaId { get; set; }
            public string KassaType { get; set; }
            public DateTime BeginUur { get; set; }
            public decimal Value { get; set; }
        }
        
        public class Chart {
            public List<string> Labels { get; set; } // Dates
            public List<Dataset> Datasets { get; set; }
        }

        public class Dataset {
            public string label { get; set; } // color label
            public List<decimal> data { get; set; } // prijzen
            public string backgroundColor { get; set; } // dot color
            public double lineTension { get; set; }
            public string borderColor { get; set; }
            public string fill { get; set; }
            public string fillColor { get; set; }
            public int fillBetweenSet { get; set; }
            public string fillBetweenColor { get; set; }
            public double barPercentage { get; set; }
        }
    }
}