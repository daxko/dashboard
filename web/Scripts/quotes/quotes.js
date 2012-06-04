$(function () {
    wire_up_transition_button();
    wire_up_quote_transitions();
});

var transition_timeout;

function wire_up_transition_button() {
    $('#transition_time_button').click(function () {
        set_transition_time();
    });
}

function set_transition_time() {
    var new_value = $('#transition_time_text').val();

    if (new_value > 0) {
        $('#transition_time').val(new_value);

        clearInterval(transition_timeout);
        wire_up_quote_transitions();
    }
}

function wire_up_quote_transitions() {
    var transition_time = $('#transition_time').val() * 1000;

    transition_timeout = setInterval(function () {
        load_next_quote();
    }, transition_time);
}

function load_next_quote() {
    $.ajax({
        url: "/Quotes/RandomQuote",
        type: "GET",
        success: function (result) {
            $('#quote_section').html(result.view);
        }
    }); 
}