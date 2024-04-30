using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;

public class Mahasiswa
{
    public string nama { get; set; }
    public string NIM { get; set; }
    public List<string> course { get; set; }
    public int year { get; set; }

}

namespace modul9_1302220140.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class mahasiswaController : ControllerBase
    {

        private static List<Mahasiswa> mahasiswaList = new List<Mahasiswa>
        {
            new Mahasiswa{nama = "Raphael Permana Barus",NIM ="1302220140", course = new List<string>(){"KPL", "PBO", "Basdat"}, year = 2022 },
            new Mahasiswa{nama = "Dafa Raimi Suandi",NIM ="1302223156", course = new List<string>(){"KPL", "PBO", "Basdat"}, year = 2022 },
            new Mahasiswa{nama = "Haikal Risnandar",NIM ="1302221050", course = new List<string>(){ "KPL", "PBO", "Basdat" }, year = 2022 },
            new Mahasiswa{nama = "Fersya Zufar",NIM ="1302223090", course = new List<string>(){ "KPL", "PBO", "Basdat" }, year = 2022 },
            new Mahasiswa{nama = "Mahesa Athaya Zain",NIM ="1302220105", course = new List<string>(){ "KPL", "PBO", "Basdat" }, year = 2022 },
            new Mahasiswa{nama = "Darryl Frizangelo Rambi",NIM ="1302223154", course = new List < string >() { "KPL", "PBO", "Basdat" }, year = 2022 },
        };

        // GET /api/mahasiswa
        [HttpGet]
        public IEnumerable<Mahasiswa> GetMahasiswa()
        {
            return mahasiswaList;
        }

        // GET /api/mahasiswa/{id}
        [HttpGet("{id}")]
        public IActionResult GetMahasiswa(int id)
        {
            if (id >= 0 && id < mahasiswaList.Count)
            {
                return Ok(mahasiswaList[id]);
            }
            else
            {
                return NotFound();
            }
        }

        // POST /api/mahasiswa
        [HttpPost]
        public IActionResult PostMahasiswa([FromBody] Mahasiswa input)
        {
            mahasiswaList.Add(input);
            return CreatedAtAction(nameof(GetMahasiswa), new { id = mahasiswaList.Count - 1 }, input);
        }

        // DELETE /api/mahasiswa/{id}
        [HttpDelete("{id}")]
        public IActionResult DeleteMahasiswa(int id)
        {
            if (id >= 0 && id < mahasiswaList.Count)
            {
                mahasiswaList.RemoveAt(id);
                return NoContent();
            }
            else
            {
                return NotFound();
            }
        }
    }
}