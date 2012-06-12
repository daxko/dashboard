$(function () {
    wire_up_ops_status_refresh();
});

function wire_up_ops_status_refresh() {
    var refresh_time = $('#refresh_time').val() * 1000;

    setInterval(function () {
        load_ops_status();
    }, refresh_time);
}

function load_ops_status() {
    $.ajax({
        url: "/Uptime/GetOpsApplicationStatus",
        type: "GET",
        success: function (result) {
            $('#ops_status').html(result.view);
        }
    }); 
}