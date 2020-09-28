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
using System.IO;
using ClosedXML.Excel;

namespace Kassablad.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    // [Authorize]
    public class ReportingController : ControllerBase
    {
        private readonly KassabladContext _context;

        public ReportingController(KassabladContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetReportingController(string startDate = "", string endDate = "")
        {
            string contentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            string fileName = $"kasboek-{DateTime.Now.ToString("yyyymmdd")}.xlsx";
            var kassaContainers = await GetKassaContainerObjectQuery()
                .OrderByDescending(x => x.BeginUur)
                .ToListAsync();
            var kasboek = new Kasboek();

            if(startDate != "" && startDate != "undefined" && endDate != "" && endDate != "undefined") 
            {
                var StartDate = (startDate != "" && startDate != "undefined") ? Convert.ToDateTime(startDate) : DateTime.Now.AddMonths(-1);
                var EndDate = (endDate != "" && endDate != "undefined") ? Convert.ToDateTime(endDate) : DateTime.Now;
                kassaContainers = kassaContainers
                .Where(x => x.BeginUur >= StartDate && x.BeginUur <= EndDate)
                .ToList();
            }

            try
            {
                using(var workbook = new XLWorkbook())
                {
                    IXLWorksheet worksheet = workbook.Worksheets.Add("Kasboek Inkomsten");
                    worksheet.Cell(1, 1).Value = "Id";
                    worksheet.Cell(1, 2).Value = "Datum";
                    worksheet.Cell(1, 3).Value = "Dag";
                    worksheet.Cell(1, 4).Value = "Activiteit";
                    worksheet.Cell(1, 5).Value = "Openingsuur";
                    worksheet.Cell(1, 6).Value = "Sluitingsuur";
                    worksheet.Cell(1, 7).Value = "Aantal uren open";
                    worksheet.Cell(1, 8).Value = "Naam Tapper";
                    worksheet.Cell(1, 9).Value = "Afgesloten door";
                    worksheet.Cell(1, 10).Value = "Inkomsten";
                    worksheet.Cell(1, 11).Value = "Aantal geschatte bezoekers";
                    for (int i = 1; i <= kassaContainers.Count(); i++) {
                        var duration = kassaContainers[i - 1].BeginUur - kassaContainers[i - 1].BeginUur;
                        decimal inkomsten = 0;
                        kassaContainers[i - 1].BeginKassa.NominationList.ForEach(nom => {
                            var value = nom.Amount * nom.Nomination.Multiplier;
                            inkomsten += value;
                        });
                        worksheet.Cell(i + 1, 1).Value = kassaContainers[i - 1].Id;
                        worksheet.Cell(i + 1, 2).Value = kassaContainers[i - 1].BeginUur.ToString("yyyy-MM-dd");
                        worksheet.Cell(i + 1, 3).Value = kassaContainers[i - 1].BeginUur.ToString("DDD");
                        worksheet.Cell(i + 1, 4).Value = kassaContainers[i - 1].Activiteit;
                        worksheet.Cell(i + 1, 5).Value = kassaContainers[i - 1].BeginUur.ToString("hh:mm");
                        worksheet.Cell(i + 1, 6).Value = kassaContainers[i - 1].EindUur.ToString("hh:mm");
                        worksheet.Cell(i + 1, 7).Value = duration.TotalHours;
                        worksheet.Cell(i + 1, 8).Value = kassaContainers[i - 1].NaamTapper;
                        worksheet.Cell(i + 1, 9).Value = kassaContainers[i - 1].NaamTapperSluit;
                        worksheet.Cell(i + 1, 10).Value = inkomsten;
                        worksheet.Cell(i + 1, 11).Value = kassaContainers[i - 1].Bezoekers;
                    }

                    using (var stream = new MemoryStream())
                    {
                        workbook.SaveAs(stream);
                        var content = stream.ToArray();
                        return File(content, contentType, fileName);
                    }
                }
            }
            catch(Exception ex)
            {
                return NotFound();
            }
        }

        private IQueryable<ObjKassaContainer> GetKassaContainerObjectQuery(int id = 0) 
        {
            var objKassaContainerQuery = from kc in _context.KassaContainer
                from bk in _context.Kassa 
                from ek in _context.Kassa
                where (id == 0 || (id != 0 && kc.Id == id))
                    && bk.KassaContainerId == kc.Id 
                    && bk.Type == "begin"
                    && ek.KassaContainerId == kc.Id
                    && ek.Type == "end"
                select new ObjKassaContainer {
                    Id = kc.Id,
                    Active = kc.Active,
                    Afroomkluis = kc.Afroomkluis,
                    BeginUur = kc.BeginUur,
                    EindUur = kc.EindUur,
                    Bezoekers = kc.Bezoekers,
                    CreatedBy = kc.CreatedBy,
                    DateAdded = kc.DateAdded,
                    DateUpdated = kc.DateUpdated,
                    InkomstBar = kc.InkomstBar,
                    InkomstLidkaart = kc.InkomstLidkaart,
                    NaamTapper = kc.NaamTapper,
                    NaamTapperSluit = kc.NaamTapperSluit,
                    Notes = kc.Notes,
                    Activiteit = kc.Activiteit,
                    UpdatedBy = kc.UpdatedBy,
                    BeginKassa = new ObjKassa {
                        Active = bk.Active,
                        Id = bk.Id,
                        CreatedBy = bk.CreatedBy,
                        DateAdded = bk.DateAdded,
                        DateUpdated = bk.DateUpdated,
                        KassaContainerId = bk.KassaContainerId,
                        Type = bk.Type,
                        UpdatedBy = bk.UpdatedBy,
                        NominationList = (from kn in _context.KassaNomination
                            from n in _context.Nominations
                            where kn.KassaId == bk.Id && n.Id == kn.NominationId
                            select new ObjNomination {
                                Active = kn.Active,
                                Amount = kn.Amount,
                                CreatedBy = kn.CreatedBy,
                                UpdatedBy = kn.UpdatedBy,
                                DateAdded = kn.DateAdded,
                                KassaId = kn.KassaId,
                                Id = kn.Id,
                                NominationId = kn.NominationId,
                                Nomination = n
                            }).OrderBy(x => x.Nomination.Id).ToList()
                    },
                    EindKassa = new ObjKassa {
                        Active = ek.Active,
                        Id = ek.Id,
                        CreatedBy = ek.CreatedBy,
                        DateAdded = ek.DateAdded,
                        DateUpdated = ek.DateUpdated,
                        KassaContainerId = ek.KassaContainerId,
                        Type = ek.Type,
                        UpdatedBy = ek.UpdatedBy,
                        NominationList = (from kn in _context.KassaNomination
                            from n in _context.Nominations
                            where kn.KassaId == ek.Id && n.Id == kn.NominationId
                            select new ObjNomination {
                                Active = kn.Active,
                                Amount = kn.Amount,
                                CreatedBy = kn.CreatedBy,
                                UpdatedBy = kn.UpdatedBy,
                                DateAdded = kn.DateAdded,
                                KassaId = kn.KassaId,
                                Id = kn.Id,
                                NominationId = kn.NominationId,
                                Nomination = n
                            }).ToList()
                    }
                };

            return objKassaContainerQuery;
        }

        public class Kasboek {
            public List<Cafeblad> data { get; set; }
        }

        public class Cafeblad {
            public int Id { get; set; }
            public DateTime BeginUur { get; set; }
            public DateTime EindUur { get; set; }
            public string Dag { get; set; }
            public string Datum { get; set; }
            public string Activiteit { get; set; }
            public int GeopendeUren { get; set; }
            public string NaanmTapper { get; set; }
            public string NaamTapperSluit { get; set; }
            public decimal Inkomsten { get; set; }
            public int bezoekers { get; set; }
        }
        public class NomValues {
            public int KassaContainerId { get; set; }
            public int KassaId { get; set; }
            public string KassaType { get; set; }
            public DateTime BeginUur { get; set; }
            public decimal Value { get; set; }
        }

        public class ObjKassaContainer : KassaContainer {
            public ObjKassa BeginKassa { get; set; }
            public ObjKassa EindKassa { get; set; }
        }

        public class ObjKassa : Kassa {
            public List<ObjNomination> NominationList { get; set; }
        }

        public class ObjNomination : KassaNomination { 
            public Nominations Nomination { get; set; }
        }
    }
}