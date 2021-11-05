// weekday is a number between 0-6
function getTemperature(lat,lon) {
    
    const Api_key = "a045d37523034b2c55e0e4e0102983d8";
    const weather = document.getElementById("weather");


    $.ajax({
        type: "GET",
        url: 'http://api.openweathermap.org/data/2.5/weather?lat=' + lat + '&lon=' + lon + '&appid=' + Api_key,
        success: function (data) {
            weather.innerHTML = data["weather"].description;
            


            // load the image of the state weather icon (rainy , sunny..)
            //document.getElementById(divId + "_weatherImg").src = "http://openweathermap.org/img/w/" + data["weather"][index].icon + ".png";
            //console.log(weatherContent[0]["description"]);
            //document.getElementById(divId + "_weather").innerHTML =
                //weatherContent[0]["main"] + ", " + weatherContent[index]["temp"] + '&#8451;';
        }
    });
}


