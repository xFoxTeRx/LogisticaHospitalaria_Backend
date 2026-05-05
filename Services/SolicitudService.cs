using LogisticaHospitalaria_Backend.DTOs;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

public class SolicitudService
{
    private readonly HttpClient _httpClient;

    public SolicitudService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<SolicitudDTO?> ObtenerSolicitudAsync(int id)
    {
        string url = $"http://10.77.200.50:5000/api/solicitudes/{id}";
        return await _httpClient.GetFromJsonAsync<SolicitudDTO>(url);
    }
}
