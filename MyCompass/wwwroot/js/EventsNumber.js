function CountNumberOfEventsByTrip() {
    $.ajax({
        type: "GET",
        url: "https://localhost:44323/TripEvents/CountNumberOfEventsByTrip",
        dataType: 'json',
        success: function (data) {
            var tableRow = document.getElementById("information");
            data.forEach(row => {
                var rowData = document.createElement("tr");
                var placeNameData = document.createElement("td");
                var numberOfEventsData = document.createElement("td");
                placeNameData.innerHTML = row.place;
                numberOfEventsData.innerHTML = row.count;

                rowData.appendChild(placeNameData);
                rowData.appendChild(numberOfEventsData);
                tableRow.appendChild(rowData);
            });
        }
    });
}


function tableCreate() {
    const body = document.body,
        tbl = document.createElement('table');
    tbl.style.width = '100px';
    tbl.style.border = '1px solid black';

    for (let i = 0; i < 3; i++) {
        const tr = tbl.insertRow();
        for (let j = 0; j < 2; j++) {
            if (i === 2 && j === 1) {
                break;
            } else {
                const td = tr.insertCell();
                td.appendChild(document.createTextNode(`Cell I${i}/J${j}`));
                td.style.border = '1px solid black';
                if (i === 1 && j === 1) {
                    td.setAttribute('rowSpan', '2');
                }
            }
        }
    }
    body.appendChild(tbl);
}