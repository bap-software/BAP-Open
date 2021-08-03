$(document).ready(function () {
    $(".select-state").select2({
        tags: true
    });
})

function fillStates(countrySelector = ".select-country", stateSelector = ".select-state") {
    var countryName = $(countrySelector).val();
    $.ajax({
        method: "GET",
        url: "/Administration/States/GetStates",
        data: { "countryName": countryName }
    })
    .done(function (data, status, xhr) {
        var options = '';
        for (var i = 0; i < data.length; i++) {
            options += '<option value="' + data[i].Name + '">' + data[i].Name + '</option>';
        }
        $(stateSelector).html(options);
    })
}