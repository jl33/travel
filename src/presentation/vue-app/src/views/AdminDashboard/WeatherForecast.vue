<template>
    <div><div><div class="text-h2 my-4">WeatherForecast</div></div></div>
</template>
<script>
    import { getWeatherForecastV2Axios } from "@/api/weather-forecast-services";
    export default {
        name: "WeatherForecast",
        async mounted() {
            await getWeatherForecastV2Axios("TPE");
        },
    };
</script>