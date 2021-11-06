// weekday is a number between 0-6
function getTemperature(lat,lon) {
    
    const Api_key = "a045d37523034b2c55e0e4e0102983d8";
    const weather = document.getElementById("weather");


    $.ajax({
        type: "GET",
        url: "https://api.openweathermap.org/data/2.5/weather?lat=" + lat + "&lon=" + lon + "&appid=" + Api_key,
        dataType: 'jsonp',
        success: function (data) {
            console.log("DATA::", data)
            img = document.createElement("img");
            weather.innerHTML = data["weather"][0]["description"];
            
            img.src = "http://openweathermap.org/img/w/" + data["weather"][0].icon + ".png";
            weather.appendChild(img);  
        }
    });
}
