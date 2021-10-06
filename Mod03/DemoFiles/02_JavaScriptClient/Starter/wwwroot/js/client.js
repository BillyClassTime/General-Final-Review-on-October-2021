const uri = 'api/Destinations';

function getData() {
    fetch(uri)
    .then(response => response.json())
    .then(function(data) {
        data.forEach(element => {
            document.getElementById('destinations').innerHTML += '<li id="' + element.id + '">' + 
            element.id + ': ' + element.cityName + ' - ' + element.airport + '</li>';
        });
    })
}

