using Microsoft.AspNetCore.Mvc;

public class UserDataDto
{
    public string Nama { get; set; }
    public string JenisKelamin { get; set; }
    public int Umur { get; set; }
    public double TinggiBadan { get; set; }
    public double BeratBadan { get; set; }
}

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    bool test = false;
    [HttpPost("hitung-berat-badan-ideal")]
    public IActionResult HitungBeratBadanIdeal([FromBody] UserDataDto userData)
    {
        string message = "";
        if (userData.JenisKelamin == "Pria")
        {
            double beratBadanIdealPria = (userData.TinggiBadan - 100) - ((userData.TinggiBadan - 100) * 0.1);

            // Bandingkan dengan berat badan yang diberikan
            message = (userData.BeratBadan == beratBadanIdealPria)
                ? $"Selamat, berat badan Anda ideal!"
                : $"Mohon maaf, berat badan Anda tidak ideal.";
        }
        if (userData.JenisKelamin == "Wanita")
        {
            double beratBadanIdealWanita = (userData.TinggiBadan - 100) - ((userData.TinggiBadan - 100) * 0.15);

            // Bandingkan dengan berat badan yang diberikan
            message = (userData.BeratBadan == beratBadanIdealWanita)
                ? $"Selamat, berat badan Anda ideal!"
                : $"Mohon maaf, berat badan Anda tidak ideal.";
        }


        return Ok(message);
    }
}
