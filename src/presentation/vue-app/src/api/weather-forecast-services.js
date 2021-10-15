import api from "./api-v2-config"; // "@/api/api-v2-config";
export async function getWeatherForecastV2Axios(city){
    return await api.post(`WeatherForecast/?city=${city}`);
}